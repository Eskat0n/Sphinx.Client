#region Copyright
// 
// Copyright (c) 2009-2011, Rustam Babadjanov <theplacefordev [at] gmail [dot] com>
// 
// This program is free software; you can redistribute it and/or modify it
// under the terms of the GNU Lesser General Public License version 2.1 as published
// by the Free Software Foundation.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
#endregion
#region Usings

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sphinx.Client.Commands.Attributes.Update;
using Sphinx.Client.Helpers;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Collections
{
    public class AttributeUpdateList : KeyedCollection<string,AttributeUpdateBase>
    {
        #region Constructors
        internal AttributeUpdateList() : base(null, 0) { }
        
        #endregion

        #region Methods

        #region Add method overloads
        /// <summary>
        /// Add new boolean value to update attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New object</returns>
        public AttributeUpdateBoolean Add(string name, long id, bool value)
        {
            Dictionary<long, bool> dict = new Dictionary<long, bool>();
            dict.Add(id, value);
            AttributeUpdateBoolean item = new AttributeUpdateBoolean(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new boolean values to Update real attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New object</returns>
        public AttributeUpdateBoolean Add(string name, IDictionary<long, bool> values)
        {
            AttributeUpdateBoolean item = new AttributeUpdateBoolean(name, values);
            Add(item);
            return item;
        }


        /// <summary>
        /// Add new DateTime value to update attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New object</returns>
        public AttributeUpdateDateTime Add(string name, long id, DateTime value)
        {
            Dictionary<long, DateTime> dict = new Dictionary<long, DateTime>();
            dict.Add(id, value);
            AttributeUpdateDateTime item = new AttributeUpdateDateTime(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new DateTime values to update attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New object</returns>
        public AttributeUpdateDateTime Add(string name, IDictionary<long, DateTime> values)
        {
            AttributeUpdateDateTime item = new AttributeUpdateDateTime(name, values);
            Add(item);
            return item;
        }


        /// <summary>
        /// Add new float value to update attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New object</returns>
        public AttributeUpdateFloat Add(string name, long id, float value)
        {
            Dictionary<long, float> dict = new Dictionary<long, float>();
            dict.Add(id, value);
            AttributeUpdateFloat item = new AttributeUpdateFloat(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new float values to update attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New object</returns>
        public AttributeUpdateFloat Add(string name, IDictionary<long, float> values)
        {
            AttributeUpdateFloat item = new AttributeUpdateFloat(name, values);
            Add(item);
            return item;
        }


        /// <summary>
        /// Add new int value to update attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New object</returns>
        public AttributeUpdateInt32 Add(string name, long id, int value)
        {
            Dictionary<long, int> dict = new Dictionary<long, int>();
            dict.Add(id, value);
            AttributeUpdateInt32 item = new AttributeUpdateInt32(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new int values to update attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New object</returns>
        public AttributeUpdateInt32 Add(string name, IDictionary<long, int> values)
        {
            AttributeUpdateInt32 item = new AttributeUpdateInt32(name, values);
            Add(item);
            return item;
        }

		/// <summary>
		/// Add new string value to update attribute value stored in Sphinx index by document ID.
		/// </summary>
		/// <param name="name">Attribute name</param>
		/// <param name="id">Document ID</param>
		/// <param name="value">New value</param>
		/// <returns>New object</returns>
		public AttributeUpdateString Add(string name, long id, string value)
		{
			Dictionary<long, string> dict = new Dictionary<long, string>();
			dict.Add(id, value);
			AttributeUpdateString item = new AttributeUpdateString(name, dict);
			Add(item);
			return item;
		}

		/// <summary>
		/// Add new float values to update attribute values stored in Sphinx index by document IDs.
		/// </summary>
		/// <param name="name">Attribute name</param>
		/// <param name="values">Document id and override values map to override</param>
		/// <returns>New object</returns>
		public AttributeUpdateString Add(string name, IDictionary<long, string> values)
		{
			AttributeUpdateString item = new AttributeUpdateString(name, values);
			Add(item);
			return item;
		}


        /// <summary>
        /// Add new boolean multi-value to update attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New object</returns>
		public AttributeUpdateMultiBoolean Add(string name, long id, IEnumerable<bool> value)
        {
			Dictionary<long, IEnumerable<bool>> dict = new Dictionary<long, IEnumerable<bool>>();
            dict.Add(id, new List<bool>(value));
            AttributeUpdateMultiBoolean item = new AttributeUpdateMultiBoolean(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new boolean multi-values to Update real attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New object</returns>
        public AttributeUpdateMultiBoolean Add(string name, IDictionary<long, IEnumerable<bool>> values)
        {
            AttributeUpdateMultiBoolean item = new AttributeUpdateMultiBoolean(name, values);
            Add(item);
            return item;
        }


        /// <summary>
        /// Add new DateTime multi-value to update attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New object</returns>
		public AttributeUpdateMultiDateTime Add(string name, long id, IEnumerable<DateTime> value)
        {
			IDictionary<long, IEnumerable<DateTime>> dict = new Dictionary<long, IEnumerable<DateTime>>();
            dict.Add(id, value);
            AttributeUpdateMultiDateTime item = new AttributeUpdateMultiDateTime(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new DateTime multi-values to update attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New object</returns>
		public AttributeUpdateMultiDateTime Add(string name, IDictionary<long, IEnumerable<DateTime>> values)
        {
            AttributeUpdateMultiDateTime item = new AttributeUpdateMultiDateTime(name, values);
            Add(item);
            return item;
        }


        /// <summary>
        /// Add new float multi-value to update attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New object</returns>
		public AttributeUpdateMultiFloat Add(string name, long id, IEnumerable<float> value)
        {
			Dictionary<long, IEnumerable<float>> dict = new Dictionary<long, IEnumerable<float>>();
            dict.Add(id, value);
            AttributeUpdateMultiFloat item = new AttributeUpdateMultiFloat(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new float multi-values to update attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New object</returns>
		public AttributeUpdateMultiFloat Add(string name, IDictionary<long, IEnumerable<float>> values)
        {
            AttributeUpdateMultiFloat item = new AttributeUpdateMultiFloat(name, values);
            Add(item);
            return item;
        }


        /// <summary>
        /// Add new int multi-value to update attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New object</returns>
		public AttributeUpdateMultiInt32 Add(string name, long id, IEnumerable<int> value)
        {
			Dictionary<long, IEnumerable<int>> dict = new Dictionary<long, IEnumerable<int>>();
            dict.Add(id, value);
            AttributeUpdateMultiInt32 item = new AttributeUpdateMultiInt32(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new int multi-values to update attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New object</returns>
		public AttributeUpdateMultiInt32 Add(string name, IDictionary<long, IEnumerable<int>> values)
        {
            AttributeUpdateMultiInt32 item = new AttributeUpdateMultiInt32(name, values);
            Add(item);
            return item;
        }

        // NOTE: oveload for Ordinal multi-value attributes can't be implemented (use direct syntax Add(new AttributeUpdateMultiOrdinal(..)))
        #endregion

        #region Overrides of KeyedCollection<string,AttributeUpdateBase>
        /// <summary>Extracts the key from the specified <see cref="AttributeUpdateBase"/> object.</summary>
        /// <returns>The string key for the specified element (Name property value).</returns>
        /// <param name="item">The <see cref="AttributeUpdateBase"/> object from which to extract the key.</param>
        protected override string GetKeyForItem(AttributeUpdateBase item)
        {
            return item.Name;
        }

        #endregion

        public void UnionWith(IEnumerable<AttributeUpdateBase> attributesValues)
        {
            CollectionUtil.UnionCollections(this, attributesValues);
        }

        /// <summary>
        /// Serialize object to stream using specified binary writer.
        /// </summary>
        /// <param name="writer">Binary writer (output formatter) object</param>
        internal void Serialize(IBinaryWriter writer)
        {
            // NOTE: class hierarchy differs from the internal Sphinx binary protocol data format representation, requires split attribute names and document id/value sets.
            List<long> documentIds = new List<long>();
            // pre-serialize attribute names first
            writer.Write(Count);
            foreach (AttributeUpdateBase attr in this)
            {
                writer.Write(attr.Name);
                writer.Write(attr.IsMultiValue);
                // union sets of document IDs from all attributes
                CollectionUtil.UnionCollections(documentIds, attr.GetDocumentsIdSet());
            }

            // write IDs and new values
            writer.Write(documentIds.Count);
            foreach (long id in documentIds)
            {
                // document ID
                writer.Write(id);
                foreach (AttributeUpdateBase attr in this)
                {
                    attr.Serialize(writer, id);
                }
            }
        }
        #endregion

    }
}
