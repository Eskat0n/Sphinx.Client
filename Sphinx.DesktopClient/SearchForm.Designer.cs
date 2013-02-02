namespace SearchDesktopClient
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
			this.btnSearch = new System.Windows.Forms.Button();
			this.wbResults = new System.Windows.Forms.WebBrowser();
			this.tabcSettings = new System.Windows.Forms.TabControl();
			this.tabpGeneral = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtIndexes = new System.Windows.Forms.TextBox();
			this.gbServer = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.lblPort = new System.Windows.Forms.Label();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.lblHost = new System.Windows.Forms.Label();
			this.gbQuery = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
			this.txtSelectFields = new System.Windows.Forms.TextBox();
			this.lblSelect = new System.Windows.Forms.Label();
			this.txtQuery = new System.Windows.Forms.TextBox();
			this.lblQuery = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.cbMatchType = new System.Windows.Forms.ComboBox();
			this.lblMatchType = new System.Windows.Forms.Label();
			this.lblranking = new System.Windows.Forms.Label();
			this.cbRankingMode = new System.Windows.Forms.ComboBox();
			this.txtLimit = new System.Windows.Forms.TextBox();
			this.lblLimit = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.cbSortMode = new System.Windows.Forms.ComboBox();
			this.txtSortClause = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabpAdditional = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.lblS = new System.Windows.Forms.Label();
			this.gbGroups = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.lblGroupSort = new System.Windows.Forms.Label();
			this.txtGroupSortBy = new System.Windows.Forms.TextBox();
			this.lblGroupDistinct = new System.Windows.Forms.Label();
			this.txtGroupDistinct = new System.Windows.Forms.TextBox();
			this.lblGroupFunc = new System.Windows.Forms.Label();
			this.cbGroupFunc = new System.Windows.Forms.ComboBox();
			this.lblGroupBy = new System.Windows.Forms.Label();
			this.txtGroupBy = new System.Windows.Forms.TextBox();
			this.gbDocIdRange = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.txtMaxDocID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMinDocID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tabpIndexWeights = new System.Windows.Forms.TabPage();
			this.bnavIndexWeights = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
			this.bsourceIndexWeights = new System.Windows.Forms.BindingSource(this.components);
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.gvIndexWeights = new System.Windows.Forms.DataGridView();
			this.gvcolName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvcolValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabpFieldWeights = new System.Windows.Forms.TabPage();
			this.bnavFieldWeights = new System.Windows.Forms.BindingNavigator(this.components);
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.bsourceFieldWeights = new System.Windows.Forms.BindingSource(this.components);
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.gvAttributeWeights = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabpAttrOverride = new System.Windows.Forms.TabPage();
			this.bnavAttributeOverrides = new System.Windows.Forms.BindingNavigator(this.components);
			this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
			this.bsourceAttributeOverrides = new System.Windows.Forms.BindingSource(this.components);
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.gvAttributeOverrides = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.colDocumentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.formValidator = new CustomValidation.FormValidator();
			this.reqHost = new CustomValidation.RequiredFieldValidator();
			this.rangePort = new CustomValidation.RangeValidator();
			this.rangeLimit = new CustomValidation.RangeValidator();
			this.reqPort = new CustomValidation.RequiredFieldValidator();
			this.reqLimit = new CustomValidation.RequiredFieldValidator();
			this.rangeMinDocId = new CustomValidation.RangeValidator();
			this.rangeMaxDocId = new CustomValidation.RangeValidator();
			this.reqSelectFields = new CustomValidation.RequiredFieldValidator();
			this.reqIndexes = new CustomValidation.RequiredFieldValidator();
			this.btnGetStatus = new System.Windows.Forms.Button();
			this.tabcSettings.SuspendLayout();
			this.tabpGeneral.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.gbServer.SuspendLayout();
			this.tableLayoutPanel8.SuspendLayout();
			this.gbQuery.SuspendLayout();
			this.tableLayoutPanel7.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tabpAdditional.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.gbGroups.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.gbDocIdRange.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tabpIndexWeights.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnavIndexWeights)).BeginInit();
			this.bnavIndexWeights.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsourceIndexWeights)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvIndexWeights)).BeginInit();
			this.tabpFieldWeights.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnavFieldWeights)).BeginInit();
			this.bnavFieldWeights.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsourceFieldWeights)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvAttributeWeights)).BeginInit();
			this.tabpAttrOverride.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnavAttributeOverrides)).BeginInit();
			this.bnavAttributeOverrides.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsourceAttributeOverrides)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvAttributeOverrides)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.formValidator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reqHost)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rangePort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rangeLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reqPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reqLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rangeMinDocId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.rangeMaxDocId)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reqSelectFields)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.reqIndexes)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Location = new System.Drawing.Point(490, 224);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// wbResults
			// 
			this.wbResults.AllowNavigation = false;
			this.wbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.wbResults.IsWebBrowserContextMenuEnabled = false;
			this.wbResults.Location = new System.Drawing.Point(4, 253);
			this.wbResults.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbResults.Name = "wbResults";
			this.wbResults.ScriptErrorsSuppressed = true;
			this.wbResults.Size = new System.Drawing.Size(561, 238);
			this.wbResults.TabIndex = 4;
			this.wbResults.TabStop = false;
			// 
			// tabcSettings
			// 
			this.tabcSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabcSettings.Controls.Add(this.tabpGeneral);
			this.tabcSettings.Controls.Add(this.tabpAdditional);
			this.tabcSettings.Controls.Add(this.tabpIndexWeights);
			this.tabcSettings.Controls.Add(this.tabpFieldWeights);
			this.tabcSettings.Controls.Add(this.tabpAttrOverride);
			this.tabcSettings.Location = new System.Drawing.Point(4, 5);
			this.tabcSettings.Name = "tabcSettings";
			this.tabcSettings.SelectedIndex = 0;
			this.tabcSettings.Size = new System.Drawing.Size(561, 213);
			this.tabcSettings.TabIndex = 0;
			// 
			// tabpGeneral
			// 
			this.tabpGeneral.Controls.Add(this.tableLayoutPanel1);
			this.tabpGeneral.Controls.Add(this.gbQuery);
			this.tabpGeneral.Controls.Add(this.groupBox2);
			this.tabpGeneral.Controls.Add(this.groupBox1);
			this.tabpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabpGeneral.Name = "tabpGeneral";
			this.tabpGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabpGeneral.Size = new System.Drawing.Size(553, 187);
			this.tabpGeneral.TabIndex = 2;
			this.tabpGeneral.Text = "General";
			this.tabpGeneral.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
			this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.gbServer, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(543, 44);
			this.tableLayoutPanel1.TabIndex = 19;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.txtIndexes);
			this.groupBox4.Location = new System.Drawing.Point(343, 0);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(197, 41);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Indexes (comma delimited or *)";
			// 
			// txtIndexes
			// 
			this.txtIndexes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtIndexes.Location = new System.Drawing.Point(7, 15);
			this.txtIndexes.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
			this.txtIndexes.Name = "txtIndexes";
			this.txtIndexes.Size = new System.Drawing.Size(171, 20);
			this.txtIndexes.TabIndex = 1;
			this.txtIndexes.Text = "*";
			// 
			// gbServer
			// 
			this.gbServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbServer.Controls.Add(this.tableLayoutPanel8);
			this.gbServer.Location = new System.Drawing.Point(3, 0);
			this.gbServer.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.gbServer.Name = "gbServer";
			this.gbServer.Size = new System.Drawing.Size(334, 41);
			this.gbServer.TabIndex = 1;
			this.gbServer.TabStop = false;
			this.gbServer.Text = "Server";
			// 
			// tableLayoutPanel8
			// 
			this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel8.ColumnCount = 4;
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
			this.tableLayoutPanel8.Controls.Add(this.txtPort, 3, 0);
			this.tableLayoutPanel8.Controls.Add(this.lblPort, 2, 0);
			this.tableLayoutPanel8.Controls.Add(this.txtHost, 1, 0);
			this.tableLayoutPanel8.Controls.Add(this.lblHost, 0, 0);
			this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 11);
			this.tableLayoutPanel8.Name = "tableLayoutPanel8";
			this.tableLayoutPanel8.RowCount = 1;
			this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel8.Size = new System.Drawing.Size(327, 26);
			this.tableLayoutPanel8.TabIndex = 1;
			// 
			// txtPort
			// 
			this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPort.Location = new System.Drawing.Point(233, 3);
			this.txtPort.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(76, 20);
			this.txtPort.TabIndex = 2;
			this.txtPort.Text = "3312";
			// 
			// lblPort
			// 
			this.lblPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPort.AutoSize = true;
			this.lblPort.Location = new System.Drawing.Point(201, 5);
			this.lblPort.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblPort.Name = "lblPort";
			this.lblPort.Size = new System.Drawing.Size(29, 13);
			this.lblPort.TabIndex = 9;
			this.lblPort.Text = "Port:";
			this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtHost
			// 
			this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtHost.Location = new System.Drawing.Point(53, 3);
			this.txtHost.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(128, 20);
			this.txtHost.TabIndex = 1;
			this.txtHost.Text = "127.0.0.1";
			// 
			// lblHost
			// 
			this.lblHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblHost.AutoSize = true;
			this.lblHost.Location = new System.Drawing.Point(18, 5);
			this.lblHost.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblHost.Name = "lblHost";
			this.lblHost.Size = new System.Drawing.Size(32, 13);
			this.lblHost.TabIndex = 0;
			this.lblHost.Text = "Host:";
			this.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gbQuery
			// 
			this.gbQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gbQuery.Controls.Add(this.tableLayoutPanel7);
			this.gbQuery.Location = new System.Drawing.Point(3, 46);
			this.gbQuery.Name = "gbQuery";
			this.gbQuery.Size = new System.Drawing.Size(544, 45);
			this.gbQuery.TabIndex = 3;
			this.gbQuery.TabStop = false;
			this.gbQuery.Text = "Search query";
			// 
			// tableLayoutPanel7
			// 
			this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel7.ColumnCount = 4;
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
			this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel7.Controls.Add(this.txtSelectFields, 3, 0);
			this.tableLayoutPanel7.Controls.Add(this.lblSelect, 2, 0);
			this.tableLayoutPanel7.Controls.Add(this.txtQuery, 1, 0);
			this.tableLayoutPanel7.Controls.Add(this.lblQuery, 0, 0);
			this.tableLayoutPanel7.Location = new System.Drawing.Point(5, 15);
			this.tableLayoutPanel7.Name = "tableLayoutPanel7";
			this.tableLayoutPanel7.RowCount = 1;
			this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel7.Size = new System.Drawing.Size(535, 26);
			this.tableLayoutPanel7.TabIndex = 1;
			// 
			// txtSelectFields
			// 
			this.txtSelectFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSelectFields.Location = new System.Drawing.Point(403, 3);
			this.txtSelectFields.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
			this.txtSelectFields.Name = "txtSelectFields";
			this.txtSelectFields.Size = new System.Drawing.Size(114, 20);
			this.txtSelectFields.TabIndex = 1;
			this.txtSelectFields.Text = "*";
			// 
			// lblSelect
			// 
			this.lblSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSelect.AutoSize = true;
			this.lblSelect.Location = new System.Drawing.Point(363, 5);
			this.lblSelect.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblSelect.Name = "lblSelect";
			this.lblSelect.Size = new System.Drawing.Size(37, 13);
			this.lblSelect.TabIndex = 9;
			this.lblSelect.Text = "Fields:";
			this.lblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtQuery
			// 
			this.txtQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtQuery.Location = new System.Drawing.Point(50, 3);
			this.txtQuery.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
			this.txtQuery.Name = "txtQuery";
			this.txtQuery.Size = new System.Drawing.Size(291, 20);
			this.txtQuery.TabIndex = 0;
			// 
			// lblQuery
			// 
			this.lblQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblQuery.AutoSize = true;
			this.lblQuery.Location = new System.Drawing.Point(9, 5);
			this.lblQuery.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblQuery.Name = "lblQuery";
			this.lblQuery.Size = new System.Drawing.Size(38, 13);
			this.lblQuery.TabIndex = 6;
			this.lblQuery.Text = "Query:";
			this.lblQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.tableLayoutPanel2);
			this.groupBox2.Location = new System.Drawing.Point(3, 91);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(544, 45);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Match and ranking";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 6;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Controls.Add(this.cbMatchType, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblMatchType, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblranking, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.cbRankingMode, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.txtLimit, 5, 0);
			this.tableLayoutPanel2.Controls.Add(this.lblLimit, 4, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 14);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(537, 28);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// cbMatchType
			// 
			this.cbMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbMatchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMatchType.Location = new System.Drawing.Point(53, 3);
			this.cbMatchType.Name = "cbMatchType";
			this.cbMatchType.Size = new System.Drawing.Size(123, 21);
			this.cbMatchType.TabIndex = 0;
			// 
			// lblMatchType
			// 
			this.lblMatchType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMatchType.AutoSize = true;
			this.lblMatchType.Location = new System.Drawing.Point(10, 5);
			this.lblMatchType.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblMatchType.Name = "lblMatchType";
			this.lblMatchType.Size = new System.Drawing.Size(40, 13);
			this.lblMatchType.TabIndex = 22;
			this.lblMatchType.Text = "Match:";
			this.lblMatchType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblranking
			// 
			this.lblranking.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblranking.AutoSize = true;
			this.lblranking.Location = new System.Drawing.Point(189, 5);
			this.lblranking.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblranking.Name = "lblranking";
			this.lblranking.Size = new System.Drawing.Size(50, 13);
			this.lblranking.TabIndex = 6;
			this.lblranking.Text = "Ranking:";
			this.lblranking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbRankingMode
			// 
			this.cbRankingMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbRankingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRankingMode.Location = new System.Drawing.Point(242, 3);
			this.cbRankingMode.Name = "cbRankingMode";
			this.cbRankingMode.Size = new System.Drawing.Size(123, 21);
			this.cbRankingMode.TabIndex = 1;
			// 
			// txtLimit
			// 
			this.txtLimit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtLimit.Location = new System.Drawing.Point(411, 3);
			this.txtLimit.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
			this.txtLimit.Name = "txtLimit";
			this.txtLimit.Size = new System.Drawing.Size(108, 20);
			this.txtLimit.TabIndex = 2;
			this.txtLimit.Text = "100";
			// 
			// lblLimit
			// 
			this.lblLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLimit.Location = new System.Drawing.Point(376, 5);
			this.lblLimit.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblLimit.Name = "lblLimit";
			this.lblLimit.Size = new System.Drawing.Size(32, 15);
			this.lblLimit.TabIndex = 20;
			this.lblLimit.Text = "Limit:";
			this.lblLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.tableLayoutPanel3);
			this.groupBox1.Location = new System.Drawing.Point(3, 137);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(544, 47);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sort results";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.cbSortMode, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.txtSortClause, 3, 0);
			this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 13);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(538, 28);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 5);
			this.label2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Mode:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbSortMode
			// 
			this.cbSortMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbSortMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSortMode.Location = new System.Drawing.Point(53, 3);
			this.cbSortMode.Name = "cbSortMode";
			this.cbSortMode.Size = new System.Drawing.Size(212, 21);
			this.cbSortMode.TabIndex = 0;
			// 
			// txtSortClause
			// 
			this.txtSortClause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSortClause.Location = new System.Drawing.Point(323, 3);
			this.txtSortClause.Margin = new System.Windows.Forms.Padding(3, 3, 19, 3);
			this.txtSortClause.Name = "txtSortClause";
			this.txtSortClause.Size = new System.Drawing.Size(196, 20);
			this.txtSortClause.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(278, 5);
			this.label3.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 20;
			this.label3.Text = "Clause:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabpAdditional
			// 
			this.tabpAdditional.Controls.Add(this.groupBox3);
			this.tabpAdditional.Controls.Add(this.gbGroups);
			this.tabpAdditional.Controls.Add(this.gbDocIdRange);
			this.tabpAdditional.Location = new System.Drawing.Point(4, 22);
			this.tabpAdditional.Name = "tabpAdditional";
			this.tabpAdditional.Padding = new System.Windows.Forms.Padding(3);
			this.tabpAdditional.Size = new System.Drawing.Size(553, 187);
			this.tabpAdditional.TabIndex = 0;
			this.tabpAdditional.Text = "Additional options";
			this.tabpAdditional.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.tableLayoutPanel6);
			this.groupBox3.Location = new System.Drawing.Point(8, 2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(539, 50);
			this.groupBox3.TabIndex = 27;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Comment (for debug)";
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel6.ColumnCount = 2;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel6.Controls.Add(this.txtComment, 1, 0);
			this.tableLayoutPanel6.Controls.Add(this.lblS, 0, 0);
			this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 14);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 1;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(529, 26);
			this.tableLayoutPanel6.TabIndex = 15;
			// 
			// txtComment
			// 
			this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtComment.Location = new System.Drawing.Point(63, 3);
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(463, 20);
			this.txtComment.TabIndex = 0;
			// 
			// lblS
			// 
			this.lblS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblS.Location = new System.Drawing.Point(6, 5);
			this.lblS.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblS.Name = "lblS";
			this.lblS.Size = new System.Drawing.Size(54, 17);
			this.lblS.TabIndex = 23;
			this.lblS.Text = "Text:";
			this.lblS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gbGroups
			// 
			this.gbGroups.Controls.Add(this.tableLayoutPanel5);
			this.gbGroups.Location = new System.Drawing.Point(8, 100);
			this.gbGroups.Name = "gbGroups";
			this.gbGroups.Size = new System.Drawing.Size(539, 70);
			this.gbGroups.TabIndex = 26;
			this.gbGroups.TabStop = false;
			this.gbGroups.Text = "Grouping search results";
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.ColumnCount = 4;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Controls.Add(this.lblGroupSort, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.txtGroupSortBy, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.lblGroupDistinct, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.txtGroupDistinct, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.lblGroupFunc, 0, 0);
			this.tableLayoutPanel5.Controls.Add(this.cbGroupFunc, 1, 0);
			this.tableLayoutPanel5.Controls.Add(this.lblGroupBy, 2, 0);
			this.tableLayoutPanel5.Controls.Add(this.txtGroupBy, 3, 0);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(6, 13);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 2;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.98039F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.01961F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(527, 51);
			this.tableLayoutPanel5.TabIndex = 25;
			// 
			// lblGroupSort
			// 
			this.lblGroupSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblGroupSort.AutoSize = true;
			this.lblGroupSort.Location = new System.Drawing.Point(17, 30);
			this.lblGroupSort.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblGroupSort.Name = "lblGroupSort";
			this.lblGroupSort.Size = new System.Drawing.Size(43, 13);
			this.lblGroupSort.TabIndex = 29;
			this.lblGroupSort.Text = "Sort by:";
			this.lblGroupSort.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtGroupSortBy
			// 
			this.txtGroupSortBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtGroupSortBy.Location = new System.Drawing.Point(63, 28);
			this.txtGroupSortBy.Name = "txtGroupSortBy";
			this.txtGroupSortBy.Size = new System.Drawing.Size(200, 20);
			this.txtGroupSortBy.TabIndex = 2;
			// 
			// lblGroupDistinct
			// 
			this.lblGroupDistinct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblGroupDistinct.AutoSize = true;
			this.lblGroupDistinct.Location = new System.Drawing.Point(276, 30);
			this.lblGroupDistinct.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblGroupDistinct.Name = "lblGroupDistinct";
			this.lblGroupDistinct.Size = new System.Drawing.Size(45, 13);
			this.lblGroupDistinct.TabIndex = 27;
			this.lblGroupDistinct.Text = "Distinct:";
			this.lblGroupDistinct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtGroupDistinct
			// 
			this.txtGroupDistinct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtGroupDistinct.Location = new System.Drawing.Point(324, 28);
			this.txtGroupDistinct.Name = "txtGroupDistinct";
			this.txtGroupDistinct.Size = new System.Drawing.Size(200, 20);
			this.txtGroupDistinct.TabIndex = 3;
			// 
			// lblGroupFunc
			// 
			this.lblGroupFunc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblGroupFunc.AutoSize = true;
			this.lblGroupFunc.Location = new System.Drawing.Point(9, 5);
			this.lblGroupFunc.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblGroupFunc.Name = "lblGroupFunc";
			this.lblGroupFunc.Size = new System.Drawing.Size(51, 13);
			this.lblGroupFunc.TabIndex = 24;
			this.lblGroupFunc.Text = "Function:";
			this.lblGroupFunc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbGroupFunc
			// 
			this.cbGroupFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cbGroupFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbGroupFunc.Location = new System.Drawing.Point(63, 3);
			this.cbGroupFunc.Name = "cbGroupFunc";
			this.cbGroupFunc.Size = new System.Drawing.Size(200, 21);
			this.cbGroupFunc.TabIndex = 0;
			// 
			// lblGroupBy
			// 
			this.lblGroupBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblGroupBy.AutoSize = true;
			this.lblGroupBy.Location = new System.Drawing.Point(268, 5);
			this.lblGroupBy.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.lblGroupBy.Name = "lblGroupBy";
			this.lblGroupBy.Size = new System.Drawing.Size(53, 13);
			this.lblGroupBy.TabIndex = 25;
			this.lblGroupBy.Text = "Group by:";
			this.lblGroupBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtGroupBy
			// 
			this.txtGroupBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtGroupBy.Location = new System.Drawing.Point(324, 3);
			this.txtGroupBy.Name = "txtGroupBy";
			this.txtGroupBy.Size = new System.Drawing.Size(200, 20);
			this.txtGroupBy.TabIndex = 1;
			// 
			// gbDocIdRange
			// 
			this.gbDocIdRange.Controls.Add(this.tableLayoutPanel4);
			this.gbDocIdRange.Location = new System.Drawing.Point(8, 52);
			this.gbDocIdRange.Name = "gbDocIdRange";
			this.gbDocIdRange.Size = new System.Drawing.Size(539, 48);
			this.gbDocIdRange.TabIndex = 25;
			this.gbDocIdRange.TabStop = false;
			this.gbDocIdRange.Text = "Document ID range filter";
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel4.ColumnCount = 4;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Controls.Add(this.txtMaxDocID, 3, 0);
			this.tableLayoutPanel4.Controls.Add(this.label1, 2, 0);
			this.tableLayoutPanel4.Controls.Add(this.txtMinDocID, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 16);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(528, 26);
			this.tableLayoutPanel4.TabIndex = 14;
			// 
			// txtMaxDocID
			// 
			this.txtMaxDocID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMaxDocID.Location = new System.Drawing.Point(379, 3);
			this.txtMaxDocID.Margin = new System.Windows.Forms.Padding(3, 3, 18, 3);
			this.txtMaxDocID.Name = "txtMaxDocID";
			this.txtMaxDocID.Size = new System.Drawing.Size(131, 20);
			this.txtMaxDocID.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(279, 5);
			this.label1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Max. document ID:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtMinDocID
			// 
			this.txtMinDocID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtMinDocID.Location = new System.Drawing.Point(115, 3);
			this.txtMinDocID.Name = "txtMinDocID";
			this.txtMinDocID.Size = new System.Drawing.Size(146, 20);
			this.txtMinDocID.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 5);
			this.label4.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Min. document ID:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabpIndexWeights
			// 
			this.tabpIndexWeights.Controls.Add(this.bnavIndexWeights);
			this.tabpIndexWeights.Controls.Add(this.gvIndexWeights);
			this.tabpIndexWeights.Location = new System.Drawing.Point(4, 22);
			this.tabpIndexWeights.Name = "tabpIndexWeights";
			this.tabpIndexWeights.Size = new System.Drawing.Size(553, 187);
			this.tabpIndexWeights.TabIndex = 3;
			this.tabpIndexWeights.Text = "Index weights";
			this.tabpIndexWeights.UseVisualStyleBackColor = true;
			// 
			// bnavIndexWeights
			// 
			this.bnavIndexWeights.AddNewItem = this.bindingNavigatorAddNewItem;
			this.bnavIndexWeights.AllowMerge = false;
			this.bnavIndexWeights.BindingSource = this.bsourceIndexWeights;
			this.bnavIndexWeights.CountItem = this.bindingNavigatorCountItem;
			this.bnavIndexWeights.DeleteItem = this.bindingNavigatorDeleteItem;
			this.bnavIndexWeights.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bnavIndexWeights.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.bnavIndexWeights.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
			this.bnavIndexWeights.Location = new System.Drawing.Point(0, 162);
			this.bnavIndexWeights.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.bnavIndexWeights.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.bnavIndexWeights.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.bnavIndexWeights.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.bnavIndexWeights.Name = "bnavIndexWeights";
			this.bnavIndexWeights.PositionItem = this.bindingNavigatorPositionItem;
			this.bnavIndexWeights.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.bnavIndexWeights.Size = new System.Drawing.Size(553, 25);
			this.bnavIndexWeights.TabIndex = 1;
			this.bnavIndexWeights.Text = "Index weigths grid navigation";
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
			this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
			this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorAddNewItem.Text = "Add new";
			// 
			// bsourceIndexWeights
			// 
			this.bsourceIndexWeights.DataSource = typeof(SearchDesktopClient.NameValuePair);
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
			this.bindingNavigatorCountItem.Text = "of {0}";
			this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
			// 
			// bindingNavigatorDeleteItem
			// 
			this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
			this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
			this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorDeleteItem.Text = "Delete";
			// 
			// bindingNavigatorMoveFirstItem
			// 
			this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
			this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
			this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveFirstItem.Text = "Move first";
			// 
			// bindingNavigatorMovePreviousItem
			// 
			this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
			this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
			this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMovePreviousItem.Text = "Move previous";
			// 
			// bindingNavigatorSeparator
			// 
			this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorPositionItem
			// 
			this.bindingNavigatorPositionItem.AccessibleName = "Position";
			this.bindingNavigatorPositionItem.AutoSize = false;
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
			this.bindingNavigatorPositionItem.Text = "0";
			this.bindingNavigatorPositionItem.ToolTipText = "Current position";
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveNextItem.Text = "Move next";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveLastItem.Text = "Move last";
			// 
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// gvIndexWeights
			// 
			this.gvIndexWeights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gvIndexWeights.AutoGenerateColumns = false;
			this.gvIndexWeights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvIndexWeights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvcolName,
            this.gvcolValue});
			this.gvIndexWeights.DataSource = this.bsourceIndexWeights;
			this.gvIndexWeights.Location = new System.Drawing.Point(0, 0);
			this.gvIndexWeights.Name = "gvIndexWeights";
			this.gvIndexWeights.Size = new System.Drawing.Size(553, 159);
			this.gvIndexWeights.TabIndex = 0;
			// 
			// gvcolName
			// 
			this.gvcolName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.gvcolName.DataPropertyName = "Name";
			this.gvcolName.HeaderText = "Name";
			this.gvcolName.MinimumWidth = 100;
			this.gvcolName.Name = "gvcolName";
			// 
			// gvcolValue
			// 
			this.gvcolValue.DataPropertyName = "Value";
			this.gvcolValue.FillWeight = 200F;
			this.gvcolValue.HeaderText = "Value";
			this.gvcolValue.MinimumWidth = 125;
			this.gvcolValue.Name = "gvcolValue";
			this.gvcolValue.Width = 200;
			// 
			// tabpFieldWeights
			// 
			this.tabpFieldWeights.Controls.Add(this.bnavFieldWeights);
			this.tabpFieldWeights.Controls.Add(this.gvAttributeWeights);
			this.tabpFieldWeights.Location = new System.Drawing.Point(4, 22);
			this.tabpFieldWeights.Name = "tabpFieldWeights";
			this.tabpFieldWeights.Size = new System.Drawing.Size(553, 187);
			this.tabpFieldWeights.TabIndex = 4;
			this.tabpFieldWeights.Text = "Field weights";
			this.tabpFieldWeights.UseVisualStyleBackColor = true;
			// 
			// bnavFieldWeights
			// 
			this.bnavFieldWeights.AddNewItem = this.toolStripButton1;
			this.bnavFieldWeights.AllowMerge = false;
			this.bnavFieldWeights.BindingSource = this.bsourceFieldWeights;
			this.bnavFieldWeights.CountItem = this.toolStripLabel1;
			this.bnavFieldWeights.DeleteItem = this.toolStripButton2;
			this.bnavFieldWeights.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bnavFieldWeights.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.bnavFieldWeights.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.toolStripButton1,
            this.toolStripButton2});
			this.bnavFieldWeights.Location = new System.Drawing.Point(0, 162);
			this.bnavFieldWeights.MoveFirstItem = this.toolStripButton3;
			this.bnavFieldWeights.MoveLastItem = this.toolStripButton6;
			this.bnavFieldWeights.MoveNextItem = this.toolStripButton5;
			this.bnavFieldWeights.MovePreviousItem = this.toolStripButton4;
			this.bnavFieldWeights.Name = "bnavFieldWeights";
			this.bnavFieldWeights.PositionItem = this.toolStripTextBox1;
			this.bnavFieldWeights.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.bnavFieldWeights.Size = new System.Drawing.Size(553, 25);
			this.bnavFieldWeights.TabIndex = 3;
			this.bnavFieldWeights.Text = "Index weigths grid navigation";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.RightToLeftAutoMirrorImage = true;
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Add new";
			// 
			// bsourceFieldWeights
			// 
			this.bsourceFieldWeights.DataSource = typeof(SearchDesktopClient.NameValuePair);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
			this.toolStripLabel1.Text = "of {0}";
			this.toolStripLabel1.ToolTipText = "Total number of items";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.RightToLeftAutoMirrorImage = true;
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "Delete";
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.RightToLeftAutoMirrorImage = true;
			this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton3.Text = "Move first";
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.RightToLeftAutoMirrorImage = true;
			this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton4.Text = "Move previous";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.AccessibleName = "Position";
			this.toolStripTextBox1.AutoSize = false;
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new System.Drawing.Size(50, 21);
			this.toolStripTextBox1.Text = "0";
			this.toolStripTextBox1.ToolTipText = "Current position";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.RightToLeftAutoMirrorImage = true;
			this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton5.Text = "Move next";
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.RightToLeftAutoMirrorImage = true;
			this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton6.Text = "Move last";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// gvAttributeWeights
			// 
			this.gvAttributeWeights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gvAttributeWeights.AutoGenerateColumns = false;
			this.gvAttributeWeights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvAttributeWeights.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
			this.gvAttributeWeights.DataSource = this.bsourceFieldWeights;
			this.gvAttributeWeights.Location = new System.Drawing.Point(0, 0);
			this.gvAttributeWeights.Name = "gvAttributeWeights";
			this.gvAttributeWeights.Size = new System.Drawing.Size(553, 159);
			this.gvAttributeWeights.TabIndex = 2;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
			this.dataGridViewTextBoxColumn1.HeaderText = "Name";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Value";
			this.dataGridViewTextBoxColumn2.FillWeight = 200F;
			this.dataGridViewTextBoxColumn2.HeaderText = "Value";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 125;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Width = 200;
			// 
			// tabpAttrOverride
			// 
			this.tabpAttrOverride.Controls.Add(this.bnavAttributeOverrides);
			this.tabpAttrOverride.Controls.Add(this.gvAttributeOverrides);
			this.tabpAttrOverride.Location = new System.Drawing.Point(4, 22);
			this.tabpAttrOverride.Name = "tabpAttrOverride";
			this.tabpAttrOverride.Padding = new System.Windows.Forms.Padding(3);
			this.tabpAttrOverride.Size = new System.Drawing.Size(553, 187);
			this.tabpAttrOverride.TabIndex = 1;
			this.tabpAttrOverride.Text = "Attribute overrides";
			this.tabpAttrOverride.UseVisualStyleBackColor = true;
			// 
			// bnavAttributeOverrides
			// 
			this.bnavAttributeOverrides.AddNewItem = this.toolStripButton7;
			this.bnavAttributeOverrides.AllowMerge = false;
			this.bnavAttributeOverrides.BindingSource = this.bsourceAttributeOverrides;
			this.bnavAttributeOverrides.CountItem = this.toolStripLabel2;
			this.bnavAttributeOverrides.DeleteItem = this.toolStripButton8;
			this.bnavAttributeOverrides.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bnavAttributeOverrides.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.bnavAttributeOverrides.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton9,
            this.toolStripButton10,
            this.toolStripSeparator4,
            this.toolStripTextBox2,
            this.toolStripLabel2,
            this.toolStripSeparator5,
            this.toolStripButton11,
            this.toolStripButton12,
            this.toolStripSeparator6,
            this.toolStripButton7,
            this.toolStripButton8});
			this.bnavAttributeOverrides.Location = new System.Drawing.Point(3, 159);
			this.bnavAttributeOverrides.MoveFirstItem = this.toolStripButton9;
			this.bnavAttributeOverrides.MoveLastItem = this.toolStripButton12;
			this.bnavAttributeOverrides.MoveNextItem = this.toolStripButton11;
			this.bnavAttributeOverrides.MovePreviousItem = this.toolStripButton10;
			this.bnavAttributeOverrides.Name = "bnavAttributeOverrides";
			this.bnavAttributeOverrides.PositionItem = this.toolStripTextBox2;
			this.bnavAttributeOverrides.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.bnavAttributeOverrides.Size = new System.Drawing.Size(547, 25);
			this.bnavAttributeOverrides.TabIndex = 5;
			this.bnavAttributeOverrides.Text = "Index weigths grid navigation";
			// 
			// toolStripButton7
			// 
			this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
			this.toolStripButton7.Name = "toolStripButton7";
			this.toolStripButton7.RightToLeftAutoMirrorImage = true;
			this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton7.Text = "Add new";
			// 
			// bsourceAttributeOverrides
			// 
			this.bsourceAttributeOverrides.DataSource = typeof(SearchDesktopClient.AttributeOverrideMapping);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(35, 22);
			this.toolStripLabel2.Text = "of {0}";
			this.toolStripLabel2.ToolTipText = "Total number of items";
			// 
			// toolStripButton8
			// 
			this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
			this.toolStripButton8.Name = "toolStripButton8";
			this.toolStripButton8.RightToLeftAutoMirrorImage = true;
			this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton8.Text = "Delete";
			// 
			// toolStripButton9
			// 
			this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
			this.toolStripButton9.Name = "toolStripButton9";
			this.toolStripButton9.RightToLeftAutoMirrorImage = true;
			this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton9.Text = "Move first";
			// 
			// toolStripButton10
			// 
			this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
			this.toolStripButton10.Name = "toolStripButton10";
			this.toolStripButton10.RightToLeftAutoMirrorImage = true;
			this.toolStripButton10.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton10.Text = "Move previous";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripTextBox2
			// 
			this.toolStripTextBox2.AccessibleName = "Position";
			this.toolStripTextBox2.AutoSize = false;
			this.toolStripTextBox2.Name = "toolStripTextBox2";
			this.toolStripTextBox2.Size = new System.Drawing.Size(50, 21);
			this.toolStripTextBox2.Text = "0";
			this.toolStripTextBox2.ToolTipText = "Current position";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripButton11
			// 
			this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
			this.toolStripButton11.Name = "toolStripButton11";
			this.toolStripButton11.RightToLeftAutoMirrorImage = true;
			this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton11.Text = "Move next";
			// 
			// toolStripButton12
			// 
			this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
			this.toolStripButton12.Name = "toolStripButton12";
			this.toolStripButton12.RightToLeftAutoMirrorImage = true;
			this.toolStripButton12.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton12.Text = "Move last";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// gvAttributeOverrides
			// 
			this.gvAttributeOverrides.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.gvAttributeOverrides.AutoGenerateColumns = false;
			this.gvAttributeOverrides.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvAttributeOverrides.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.colType,
            this.colDocumentId,
            this.dataGridViewTextBoxColumn4});
			this.gvAttributeOverrides.DataSource = this.bsourceAttributeOverrides;
			this.gvAttributeOverrides.Location = new System.Drawing.Point(0, 1);
			this.gvAttributeOverrides.Name = "gvAttributeOverrides";
			this.gvAttributeOverrides.Size = new System.Drawing.Size(553, 159);
			this.gvAttributeOverrides.TabIndex = 4;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
			this.dataGridViewTextBoxColumn3.HeaderText = "Name";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 100;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			// 
			// colType
			// 
			this.colType.DataPropertyName = "Type";
			this.colType.HeaderText = "Type";
			this.colType.Name = "colType";
			this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// colDocumentId
			// 
			this.colDocumentId.DataPropertyName = "DocumentId";
			this.colDocumentId.HeaderText = "Document ID";
			this.colDocumentId.Name = "colDocumentId";
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Value";
			this.dataGridViewTextBoxColumn4.FillWeight = 200F;
			this.dataGridViewTextBoxColumn4.HeaderText = "Value";
			this.dataGridViewTextBoxColumn4.MinimumWidth = 125;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.Width = 200;
			// 
			// formValidator
			// 
			this.formValidator.HostingForm = this;
			// 
			// reqHost
			// 
			this.reqHost.ControlToValidate = this.txtHost;
			this.reqHost.ErrorMessage = "Host is required";
			this.reqHost.Icon = ((System.Drawing.Icon)(resources.GetObject("reqHost.Icon")));
			// 
			// rangePort
			// 
			this.rangePort.ControlToValidate = this.txtPort;
			this.rangePort.ErrorMessage = "Please enter valid integer number of Sphinx port in range 1-65535";
			this.rangePort.Icon = ((System.Drawing.Icon)(resources.GetObject("rangePort.Icon")));
			this.rangePort.MaximumValue = "65535";
			this.rangePort.MinimumValue = "1";
			this.rangePort.Type = CustomValidation.ValidationDataType.Integer;
			// 
			// rangeLimit
			// 
			this.rangeLimit.ControlToValidate = this.txtLimit;
			this.rangeLimit.ErrorMessage = "Please enter valid integer number in range 1-100000";
			this.rangeLimit.Icon = ((System.Drawing.Icon)(resources.GetObject("rangeLimit.Icon")));
			this.rangeLimit.MaximumValue = "100000";
			this.rangeLimit.MinimumValue = "1";
			this.rangeLimit.Type = CustomValidation.ValidationDataType.Integer;
			// 
			// reqPort
			// 
			this.reqPort.ControlToValidate = this.txtPort;
			this.reqPort.ErrorMessage = "Please enter Sphinx server port";
			this.reqPort.Icon = ((System.Drawing.Icon)(resources.GetObject("reqPort.Icon")));
			// 
			// reqLimit
			// 
			this.reqLimit.ControlToValidate = this.txtLimit;
			this.reqLimit.ErrorMessage = "Please enter maximum search results for query";
			this.reqLimit.Icon = ((System.Drawing.Icon)(resources.GetObject("reqLimit.Icon")));
			this.reqLimit.InitialValue = "";
			// 
			// rangeMinDocId
			// 
			this.rangeMinDocId.ControlToValidate = this.txtMinDocID;
			this.rangeMinDocId.ErrorMessage = "Please enter integer document ID";
			this.rangeMinDocId.Icon = ((System.Drawing.Icon)(resources.GetObject("rangeMinDocId.Icon")));
			this.rangeMinDocId.MaximumValue = "2147483647";
			this.rangeMinDocId.MinimumValue = "1";
			this.rangeMinDocId.Type = CustomValidation.ValidationDataType.Integer;
			// 
			// rangeMaxDocId
			// 
			this.rangeMaxDocId.ControlToValidate = this.txtMaxDocID;
			this.rangeMaxDocId.ErrorMessage = "Please enter integer document ID";
			this.rangeMaxDocId.Icon = ((System.Drawing.Icon)(resources.GetObject("rangeMaxDocId.Icon")));
			this.rangeMaxDocId.MaximumValue = "2147483647";
			this.rangeMaxDocId.MinimumValue = "1";
			this.rangeMaxDocId.Type = CustomValidation.ValidationDataType.Integer;
			// 
			// reqSelectFields
			// 
			this.reqSelectFields.ControlToValidate = this.txtSelectFields;
			this.reqSelectFields.ErrorMessage = "Please specify fields to select or use * to select all fields";
			this.reqSelectFields.Icon = ((System.Drawing.Icon)(resources.GetObject("reqSelectFields.Icon")));
			// 
			// reqIndexes
			// 
			this.reqIndexes.ControlToValidate = this.txtIndexes;
			this.reqIndexes.ErrorMessage = "Please specify index names to use or use * to use all available indexes";
			this.reqIndexes.Icon = ((System.Drawing.Icon)(resources.GetObject("reqIndexes.Icon")));
			// 
			// btnGetStatus
			// 
			this.btnGetStatus.Location = new System.Drawing.Point(4, 224);
			this.btnGetStatus.Name = "btnGetStatus";
			this.btnGetStatus.Size = new System.Drawing.Size(75, 23);
			this.btnGetStatus.TabIndex = 5;
			this.btnGetStatus.Text = "Get status";
			this.btnGetStatus.UseVisualStyleBackColor = true;
			this.btnGetStatus.Click += new System.EventHandler(this.btnGetStatus_Click);
			// 
			// SearchForm
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 495);
			this.Controls.Add(this.btnGetStatus);
			this.Controls.Add(this.tabcSettings);
			this.Controls.Add(this.wbResults);
			this.Controls.Add(this.btnSearch);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(550, 500);
			this.Name = "SearchForm";
			this.Text = "Sphinx desktop search client";
			this.Load += new System.EventHandler(this.SearchForm_Load);
			this.tabcSettings.ResumeLayout(false);
			this.tabpGeneral.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.gbServer.ResumeLayout(false);
			this.tableLayoutPanel8.ResumeLayout(false);
			this.tableLayoutPanel8.PerformLayout();
			this.gbQuery.ResumeLayout(false);
			this.tableLayoutPanel7.ResumeLayout(false);
			this.tableLayoutPanel7.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tabpAdditional.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel6.PerformLayout();
			this.gbGroups.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.gbDocIdRange.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tabpIndexWeights.ResumeLayout(false);
			this.tabpIndexWeights.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnavIndexWeights)).EndInit();
			this.bnavIndexWeights.ResumeLayout(false);
			this.bnavIndexWeights.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsourceIndexWeights)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvIndexWeights)).EndInit();
			this.tabpFieldWeights.ResumeLayout(false);
			this.tabpFieldWeights.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnavFieldWeights)).EndInit();
			this.bnavFieldWeights.ResumeLayout(false);
			this.bnavFieldWeights.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsourceFieldWeights)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvAttributeWeights)).EndInit();
			this.tabpAttrOverride.ResumeLayout(false);
			this.tabpAttrOverride.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bnavAttributeOverrides)).EndInit();
			this.bnavAttributeOverrides.ResumeLayout(false);
			this.bnavAttributeOverrides.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bsourceAttributeOverrides)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvAttributeOverrides)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.formValidator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reqHost)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rangePort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rangeLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reqPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reqLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rangeMinDocId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.rangeMaxDocId)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reqSelectFields)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.reqIndexes)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.WebBrowser wbResults;
        private System.Windows.Forms.TabControl tabcSettings;
        private System.Windows.Forms.TabPage tabpAdditional;
        private System.Windows.Forms.TabPage tabpAttrOverride;
        private System.Windows.Forms.TabPage tabpGeneral;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSortMode;
        private System.Windows.Forms.TextBox txtSortClause;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbMatchType;
        private System.Windows.Forms.Label lblMatchType;
        private System.Windows.Forms.Label lblranking;
        private System.Windows.Forms.ComboBox cbRankingMode;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.GroupBox gbQuery;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.GroupBox gbDocIdRange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox txtMaxDocID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMinDocID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbGroups;
        private System.Windows.Forms.ComboBox cbGroupFunc;
        private System.Windows.Forms.Label lblGroupFunc;
        private CustomValidation.FormValidator formValidator;
		private CustomValidation.RequiredFieldValidator reqHost;
        private CustomValidation.RangeValidator rangePort;
        private CustomValidation.RangeValidator rangeLimit;
        private CustomValidation.RequiredFieldValidator reqPort;
        private CustomValidation.RequiredFieldValidator reqLimit;
        private CustomValidation.RangeValidator rangeMinDocId;
        private CustomValidation.RangeValidator rangeMaxDocId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblGroupDistinct;
        private System.Windows.Forms.TextBox txtGroupDistinct;
        private System.Windows.Forms.Label lblGroupBy;
        private System.Windows.Forms.TextBox txtGroupBy;
        private System.Windows.Forms.Label lblGroupSort;
        private System.Windows.Forms.TextBox txtGroupSortBy;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.TextBox txtSelectFields;
        private System.Windows.Forms.Label lblSelect;
        private CustomValidation.RequiredFieldValidator reqSelectFields;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbServer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtIndexes;
        private CustomValidation.RequiredFieldValidator reqIndexes;
        private System.Windows.Forms.TabPage tabpIndexWeights;
        private System.Windows.Forms.DataGridView gvIndexWeights;
        private System.Windows.Forms.BindingSource bsourceIndexWeights;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvcolName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvcolValue;
        private System.Windows.Forms.BindingNavigator bnavIndexWeights;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TabPage tabpFieldWeights;
        private System.Windows.Forms.BindingNavigator bnavFieldWeights;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView gvAttributeWeights;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource bsourceFieldWeights;
        private System.Windows.Forms.BindingNavigator bnavAttributeOverrides;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.DataGridView gvAttributeOverrides;
        private System.Windows.Forms.BindingSource bsourceAttributeOverrides;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnGetStatus;
    }
}

