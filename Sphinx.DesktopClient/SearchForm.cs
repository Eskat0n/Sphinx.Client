using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sphinx;
using Sphinx.Client.Commands;
using Sphinx.Client.Commands.Attributes.Override;
using Sphinx.Client.Commands.Collections;
using Sphinx.Client.Commands.Search;
using Sphinx.Client.Commands.Status;
using Sphinx.Client.Common;
using Sphinx.Client.Connections;
using Sphinx.Client.Commands.Attributes;
using Sphinx.Client.Commands.Attributes.Values;
using Match=Sphinx.Client.Commands.Search.Match;
using System.Threading;

namespace SearchDesktopClient
{
    public partial class SearchForm : Form
    {
        private const string RES_HEADER_TEMPLATE = "<html><head><style type='text/css'>html,body,table,p{ font-family: Tahoma,Verdana,Arial,sans-serif; font-size:8.25pt;} h1{ font-size: 12pt;} h2{ font-size: 10pt;} table{ border-collapse: collapse; } table td,table th{ padding: 2pt;}</style></head><body>";
        private const string RES_FOOTER_TEMPLATE = "</body></html>";

        private BindingList<NameValuePair> _indexWeights = new BindingList<NameValuePair>();
        private BindingList<NameValuePair> _fieldWeights = new BindingList<NameValuePair>();
        private BindingList<AttributeOverrideMapping> _attributeOverrides = new BindingList<AttributeOverrideMapping>();

        public SearchForm()
        {
            InitializeComponent();
        }

        #region Properties
        private string Host
        {
            get { return txtHost.Text; }
        }

        private int Port
        {
            get { return int.Parse(txtPort.Text); }
        }

        private string QueryString
        {
            get { return txtQuery.Text.Trim(); }
        }

        private MatchMode MatchMode
        {
            get { return (MatchMode)((NameValuePair)cbMatchType.SelectedItem).Value; }
        }
        
        private MatchRankMode RankingMode
        {
            get { return (MatchRankMode)((NameValuePair)cbRankingMode.SelectedItem).Value; }
        }

        private string Comment
        {
            get { return txtComment.Text; }
        } 

        private ResultsSortMode SortMode
        {
            get { return (ResultsSortMode)((NameValuePair)cbSortMode.SelectedItem).Value; }
        }

        private int MaxMatches
        {
            get
            {
                int val;
                return int.TryParse(txtLimit.Text, out val) ? val : 0;
            }
        }

        private string SortClause
        {
            get { return txtSortClause.Text; }
        }

        private long MinDocumentId
        {
            get
            {
                long id;
                return long.TryParse(txtMinDocID.Text,  out id) ? id : 0;
            }
        }

        private long MaxDocumentId
        {
            get
            {
                long id;
                return long.TryParse(txtMaxDocID.Text, out id) ? id : 0;
            }
        }

        private ResultsGroupFunction GroupFunc
        {
            get { return (ResultsGroupFunction)((NameValuePair)cbGroupFunc.SelectedItem).Value; }
        }

        private string GroupBy
        {
            get { return txtGroupBy.Text; }
        }

        private string GroupSortBy
        {
            get { return txtGroupSortBy.Text; }
        }

        private string GroupDistinct
        {
            get { return txtGroupDistinct.Text; }
        }

        private string SelectFields
        {
            get { return txtSelectFields.Text; }
        }

        private IEnumerable<string> Indexes
        {
            get
            {
                return txtIndexes.Text.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        #endregion

        private void BindFormData()
        {
            // match types
            BindEnumToCombobox(cbMatchType, typeof(MatchMode));
            BindEnumToCombobox(cbRankingMode, typeof(MatchRankMode));
            BindEnumToCombobox(cbSortMode, typeof (ResultsSortMode));
            BindEnumToCombobox(cbGroupFunc, typeof (ResultsGroupFunction));
            bsourceIndexWeights.DataSource = _indexWeights;
            bsourceFieldWeights.DataSource = _fieldWeights;
            BindAttributeTypesToGridCombobox(colType);
            bsourceAttributeOverrides.DataSource = _attributeOverrides;
        }

        private string DoSearch()
        {
            // set hostname and port defaults
            using (TcpConnection connection = new PersistentTcpConnection(Host, Port))
            {

                SearchCommand search = new SearchCommand(connection);
                SearchQuery query = new SearchQuery(QueryString);
                // Sphinx indexes
                query.Indexes.UnionWith(Indexes);
                // select fields clause
                query.Select = SelectFields;
                // match type
                query.MatchMode = MatchMode;
                // ranking
                query.RankingMode = RankingMode;
                // comment
                query.Comment = Comment;
                // sorting
                query.SortMode = SortMode;
                query.SortBy = SortClause;
                // limits
                query.Limit = query.MaxMatches = MaxMatches;
                // document id filtering
                query.MinDocumentId = MinDocumentId;
                query.MaxDocumentId = MaxDocumentId;
                // grouping
                query.GroupFunc = GroupFunc;
                query.GroupBy = GroupBy;
                query.GroupSort = GroupSortBy;
                query.GroupDistinct = GroupDistinct;

                // index weights
                foreach (NameValuePair item in _indexWeights)
                {
                    if (!query.IndexWeights.ContainsKey(item.Name))
                        query.IndexWeights.Add(item.Name, item.Value);
                }

                // fields weights
                foreach (NameValuePair item in _fieldWeights)
                {
                    if (!query.FieldWeights.ContainsKey(item.Name)) 
                        query.FieldWeights.Add(item.Name, item.Value);
                }

                // attribute overrides
                foreach (AttributeOverrideMapping item in _attributeOverrides)
                {
                    AttributeOverrideBase attr;
                    AttributeType type = (AttributeType) item.Type;
                    if (!query.AttributeOverrides.Contains(item.Name))
                    {
                        switch (type)
                        {
                            case AttributeType.Integer:
                                Dictionary<long, int> ints = new Dictionary<long, int>();
                                ints.Add(item.DocumentId, Convert.ToInt32(item.Value));
                                attr = new AttributeOverrideInt32(item.Name, ints);
                                break;
                            case AttributeType.Bigint:
                                Dictionary<long, long> longs = new Dictionary<long, long>();
                                longs.Add(item.DocumentId, Convert.ToInt64(item.Value));
                                attr = new AttributeOverrideInt64(item.Name, longs);
                                break;
                            case AttributeType.Boolean:
                                Dictionary<long, bool> bools = new Dictionary<long, bool>();
                                bools.Add(item.DocumentId, Convert.ToBoolean(item.Value));
                                attr = new AttributeOverrideBoolean(item.Name, bools);
                                break;
                            case AttributeType.Float:
                                Dictionary<long, float> floats = new Dictionary<long, float>();
                                floats.Add(item.DocumentId, float.Parse(item.Value.ToString()));
                                attr = new AttributeOverrideFloat(item.Name, floats);
                                break;
                            case AttributeType.Ordinal:
                                Dictionary<long, int> ordinals = new Dictionary<long, int>();
                                ordinals.Add(item.DocumentId, Convert.ToInt32(item.Value));
                                attr = new AttributeOverrideOrdinal(item.Name, ordinals);
                                break;
                            case AttributeType.Timestamp:
                                Dictionary<long, DateTime> timestamps = new Dictionary<long, DateTime>();
                                timestamps.Add(item.DocumentId, Convert.ToDateTime(item.Value));
                                attr = new AttributeOverrideDateTime(item.Name, timestamps);
                                break;
                            default:
                                throw new InvalidOperationException("Unknown attribute type");
                        }
                        query.AttributeOverrides.Add(attr);
                    }
                    else
                    {
                        attr = query.AttributeOverrides[item.Name];
                        if (type != attr.AttributeType) throw new InvalidOperationException("Attribute type mismatch");
                        switch (type)
                        {
                            case AttributeType.Integer:
                                ((AttributeOverrideInt32) attr).Values.Add(item.DocumentId, Convert.ToInt32(item.Value));
                                break;
                            case AttributeType.Bigint:
                                ((AttributeOverrideInt64)attr).Values.Add(item.DocumentId, Convert.ToInt64(item.Value));
                                break;
                            case AttributeType.Boolean:
                                ((AttributeOverrideBoolean)attr).Values.Add(item.DocumentId, Convert.ToBoolean(item.Value));
                                break;
                            case AttributeType.Float:
                                ((AttributeOverrideFloat)attr).Values.Add(item.DocumentId, float.Parse(item.Value.ToString()));
                                break;
                            case AttributeType.Ordinal:
                                ((AttributeOverrideOrdinal)attr).Values.Add(item.DocumentId, Convert.ToInt32(item.Value));
                                break;
                            case AttributeType.Timestamp:
                                ((AttributeOverrideDateTime)attr).Values.Add(item.DocumentId, Convert.ToDateTime(item.Value));
                                break;
                            default:
                                throw new InvalidOperationException("Unknown attribute type");
                        }
                    }
                }

                // add new query
                search.QueryList.Add(query);

                // run the query and get the results
                string output = "";
                try
                {
                    search.Execute();
                }
                catch (SphinxException ex)
                {
                    output = "<h2 style='color: red;'>Error is occured:<h2>" + ex.Message;
                    return output;
                }
                if (search.Result.Status == CommandStatus.Warning)
                {
                    output = "<h2 style='color: olive;'>Warnings: </h2><ul>";
                    foreach (var s in search.Result.Warnings)
                    {
                        output += "<li>" + s + "</li>";
                    }
                    output += "</ul>";
                }
                foreach (SearchQueryResult res in search.Result.QueryResults)
                {
                    output += ParseResult(res);
                }
                return output;
            }
        }

        private string ParseResult(SearchQueryResult res)
        {
            StringBuilder output = new StringBuilder();
            output.Append(RES_HEADER_TEMPLATE);
            output.AppendFormat("<h1>Server response status: {0}</h1>", Enum.GetName(typeof(CommandStatus), res.Status));
            if (res.HasWarning)
                output.AppendFormat("<h2 style='color: olive;'>Warning: {0}</h2>", res.Warning);
            output.AppendFormat("<h2>Matches count: {0}</h2>", res.Matches.Count);
            output.Append("<table border=1><tr><th>Document ID</th><th>Weight</th><th>Attributes</th></tr>");
            foreach (Match match in res.Matches)
            {
                output.Append("<tr>");
                output.AppendFormat("<td>{0}</td>", match.DocumentId);
                output.AppendFormat("<td>{0}</td>", match.Weight);
                output.AppendFormat("<td><div>Attributes count: {0}</div>", match.AttributesValues.Count);
                output.AppendFormat("<table border=1><tr><th>Name</th><th>Value</th><th>Type</th></tr>");
                foreach (AttributeBase attr in match.AttributesValues)
                {
                    string name = attr.Name;
                    string type = Enum.GetName(typeof(AttributeType), attr.AttributeType);
                    string val = GetAttributeValueAsString(attr);
                    
                    output.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", name, val, type);
                }
                output.Append("</table></td></tr>");
            }
            output.Append("</table>");
            output.AppendFormat("<h2>Words count: {0}</h2>", res.Words.Count);
            output.Append("<table border=1><tr><th>Word</th><th>Hits</th><th>Documents</th></tr>");
            foreach (WordInfo w in res.Words)
            {
                output.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", w.Word, w.Hits, w.Documents);
            }
            output.Append("</table>");
            output.AppendFormat("<p>Elapsed time: {0}</p>", res.ElapsedTime);
            output.AppendFormat("<p>Count in list: {0}</p>", res.Count);
            output.AppendFormat("<p>Total found: {0}</p>", res.TotalFound);

            output.Append(RES_FOOTER_TEMPLATE);
            return output.ToString();
        }

		private string GetAttributeValueAsString(AttributeBase attr)
		{
			object val = ((AttributeValueBase) attr).GetValue();
			if (val is IList)
			{
				StringBuilder sb = new StringBuilder();
				IList coll = (IList)val;
				for (int i=0; i < coll.Count; i++)
				{
					if (i != 0)
						sb.Append(", ");
					sb.Append(coll[i].ToString());
				}
				return sb.ToString();
			}
			return val.ToString();
		}

        private string GetServerStatus()
        {
            StringBuilder sb = new StringBuilder();
            using (TcpConnection connection = new TcpConnection(Host, Port))
            {
                StatusCommand status = new StatusCommand(connection);
                status.Execute();
                    
                sb.Append("<table border=1 style='border-collapse: collapse;' cellpadding='5'><tr><th>Name</th><th>Value</th></tr>");
                foreach (StatusInfo statusInfo in status.Result.StatusInfo)
                {
                    sb.AppendFormat("<tr><td>{0}</td><td>{1}</td></tr>", statusInfo.Name, statusInfo.Value);
                }
                sb.Append("</table>");
            }
            return sb.ToString();
        }

        private void SetActionButtonsEnabled(bool enabled)
        {
            btnGetStatus.Enabled = btnSearch.Enabled = enabled;
        }

        private void PrintResults(string output)
        {
            if (wbResults.Document == null)
            {
                // initialize web-browser control
                wbResults.Navigate("about:blank");
            }
            wbResults.Document.OpenNew(true);
            wbResults.Document.Write(output);
            
        }

        #region Event handlers
		private void SearchForm_Load(object sender, EventArgs e)
        {
		    BindFormData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            formValidator.Validate();
            if (formValidator.IsValid)
            {
                SetActionButtonsEnabled(false);
                PrintResults(DoSearch());
                SetActionButtonsEnabled(true);
            }
        }

        
        private void btnGetStatus_Click(object sender, EventArgs e)
        {
            SetActionButtonsEnabled(false);
            PrintResults(GetServerStatus());
            SetActionButtonsEnabled(true);
        }
        #endregion    


        #region Helper
        private void BindEnumToCombobox(ComboBox list, Type enumerationType)
        {
            Array enumValues = Enum.GetValues(enumerationType);
            List<NameValuePair> dataSource = new List<NameValuePair>(enumValues.Length);
            Regex reNameNormalization = new Regex(@"[A-Z\d]+");
            for (int i=0; i < enumValues.Length; i++)
            {
                int value = (int) enumValues.GetValue(i);
                string name = Enum.GetName(enumerationType, value);
                name = reNameNormalization.Replace(name, " $&").Trim();
                NameValuePair item = new NameValuePair { Name = name, Value = value };
                dataSource.Add(item);
            }
            list.DisplayMember = "Name";
            list.ValueMember = "Value";
            list.DataSource = dataSource;
        }

        private void BindAttributeTypesToGridCombobox(DataGridViewComboBoxColumn list)
        {
            Type enumerationType = typeof (AttributeType);
            Array enumValues = Enum.GetValues(enumerationType);
            List<NameValuePair> dataSource = new List<NameValuePair>(enumValues.Length+1);
            dataSource.Add(new NameValuePair{ Name = "- select value -", Value = 0});
            Regex reNameNormalization = new Regex(@"[A-Z\d]+");
            for (int i = 0; i < enumValues.Length; i++)
            {
                int value = (int)enumValues.GetValue(i);
                if ((value & (int)MultiValueAttribute.MultiFlag) == 0)
                {
                    string name = Enum.GetName(enumerationType, value);
                    name = reNameNormalization.Replace(name, " $&").Trim();
                    NameValuePair item = new NameValuePair {Name = name, Value = value};
                    dataSource.Add(item);
                }
            }
            list.DisplayMember = "Name";
            list.ValueMember = "Value";
            list.DataSource = dataSource;
        }
        #endregion



    }

    [Serializable]
    public class NameValuePair
    {
        private string _name;
        private int _value;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public class AttributeOverrideMapping 
    {
        private string _name;
        private int _type;
        private long _docId;
        private object _value;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public long DocumentId
        {
            get { return _docId; }
            set { _docId = value; }
        }

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

    }
    

}
