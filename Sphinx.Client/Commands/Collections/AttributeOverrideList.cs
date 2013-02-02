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
using Sphinx.Client.Commands.Attributes.Override;
using Sphinx.Client.IO;

#endregion

namespace Sphinx.Client.Commands.Collections
{
    /// <summary>
    /// Represents temporary (per-query) per-document attributes values overrides list.
    /// </summary>
    public class AttributeOverrideList : KeyedCollection<string,AttributeOverrideBase>
    {
        #region Constructors
        internal AttributeOverrideList() : base(null, 0) { }
        
        #endregion

        #region Methods

        #region Add method overloads
        /// <summary>
        /// Add new boolean value to override real attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New attribute override object</returns>
        public AttributeOverrideBoolean Add(string name, long id, bool value)
        {
            Dictionary<long, bool> dict = new Dictionary<long, bool>();
            dict.Add(id, value);
            AttributeOverrideBoolean item = new AttributeOverrideBoolean(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new boolean values to override real attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New attribute override object</returns>
        public AttributeOverrideBoolean Add(string name, IDictionary<long, bool> values)
        {
            AttributeOverrideBoolean item = new AttributeOverrideBoolean(name, values);
            Add(item);
            return item;
        }


        /// <summary>
        /// Add new DateTime value to override real attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New attribute override object</returns>
        public AttributeOverrideDateTime Add(string name, long id, DateTime value)
        {
            Dictionary<long, DateTime> dict = new Dictionary<long, DateTime>();
            dict.Add(id, value);
            AttributeOverrideDateTime item = new AttributeOverrideDateTime(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new DateTime values to override real attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New attribute override object</returns>
        public AttributeOverrideDateTime Add(string name, IDictionary<long, DateTime> values)
        {
            AttributeOverrideDateTime item = new AttributeOverrideDateTime(name, values);
            Add(item);
            return item;
        }


        /// <summary>
        /// Add new float value to override real attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New attribute override object</returns>
        public AttributeOverrideFloat Add(string name, long id, float value)
        {
            Dictionary<long, float> dict = new Dictionary<long, float>();
            dict.Add(id, value);
            AttributeOverrideFloat item = new AttributeOverrideFloat(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new float values to override real attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New attribute override object</returns>
        public AttributeOverrideFloat Add(string name, IDictionary<long, float> values)
        {
            AttributeOverrideFloat item = new AttributeOverrideFloat(name, values);
            Add(item);
            return item;
        }


        /// <summary>
        /// Add new int value to override real attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New attribute override object</returns>
        public AttributeOverrideInt32 Add(string name, long id, int value)
        {
            Dictionary<long, int> dict = new Dictionary<long, int>();
            dict.Add(id, value);
            AttributeOverrideInt32 item = new AttributeOverrideInt32(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new int values to override real attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New attribute override object</returns>
        public AttributeOverrideInt32 Add(string name, IDictionary<long, int> values)
        {
            AttributeOverrideInt32 item = new AttributeOverrideInt32(name, values);
            Add(item);
            return item;
        }


        /// <summary>
        /// Add new long value to override real attribute value stored in Sphinx index by document ID.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="id">Document ID</param>
        /// <param name="value">New value</param>
        /// <returns>New attribute override object</returns>
        public AttributeOverrideInt64 Add(string name, long id, long value)
        {
            Dictionary<long, long> dict = new Dictionary<long, long>();
            dict.Add(id, value);
            AttributeOverrideInt64 item = new AttributeOverrideInt64(name, dict);
            Add(item);
            return item;
        }

        /// <summary>
        /// Add new long values to override real attribute values stored in Sphinx index by document IDs.
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="values">Document id and override values map to override</param>
        /// <returns>New attribute override object</returns>
        public AttributeOverrideInt64 Add(string name, IDictionary<long, long> values)
        {
            AttributeOverrideInt64 item = new AttributeOverrideInt64(name, values);
            Add(item);
            return item;
        }

        // NOTE: oveload for Ordinal attributes can't be implemented (use direct syntax Add(new AttributeOverrideOrdinal(..)))
        #endregion

        #region Overrides of KeyedCollection<string,AttributeOverrideBase>
        /// <summary>Extracts the key from the specified <see cref="AttributeOverrideBase"/> object.</summary>
        /// <returns>The string key for the specified element (Name property value).</returns>
        /// <param name="item">The <see cref="AttributeOverrideBase"/> object from which to extract the key.</param>
        protected override string GetKeyForItem(AttributeOverrideBase item)
        {
            return item.Name;
        }

        #endregion

        /// <summary>
        /// Serialize object to stream using specified binary writer.
        /// </summary>
        /// <param name="writer">Binary writer (output formatter) object</param>
        internal void Serialize(IBinaryWriter writer)
        {
            writer.Write(Count);
            foreach (AttributeOverrideBase item in this)
            {
                item.Serialize(writer);
            }
        }

        #endregion

    }
}
