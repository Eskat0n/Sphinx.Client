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

using System.Collections;
using System.Collections.Generic;

#endregion

namespace Sphinx.Client.Helpers
{

    /// <summary>
    /// Provides a set of static methods for collection operations. This class cannot be inherited. 
    /// </summary>
    public static class CollectionUtil
    {
        /// <summary>
        /// Union two collections
        /// </summary>
        /// <typeparam name="T">collection generic type parameter</typeparam>
        /// <param name="target">Target collection</param>
        /// <param name="source">Source collection</param>
        public static void UnionCollections<T>(ICollection<T> target, IEnumerable<T> source)
        {
            foreach (T item in source)
            {
                if (!target.Contains(item))
                    target.Add(item);
            }
        }

        /// <summary>
        /// Union two plain dictionaries. Dictionary items values will be merged (if item with some key from source dictionary is exists in target dictionary, value in target dictionary item will be updated).
        /// </summary>
        /// <typeparam name="TValue">Dictionary value generic type parameter</typeparam>
        /// <typeparam name="TKey">Dictionary key generic type parameter</typeparam>
        /// <param name="target">Target dictionaries</param>
        /// <param name="source">Source dictionaries</param>
        public static void UnionDictionaries<TKey, TValue>(IDictionary<TKey, TValue> target, IDictionary<TKey, TValue> source)
        {
            foreach (KeyValuePair<TKey,TValue> item in source)
            {
                TKey key = item.Key;
                if (!target.ContainsKey(key))
                {
                    // add value
                    target.Add(item);
                }
                else if (Comparer.Default.Compare(target[key], source[key]) != 0)
                {
                    // update value in target
                    target[key] = source[key];
                }
            }
        }

		/// <summary>
		/// Union two dictionaries with sub-collection of items. If dictionary already contains specifed key, it will be replaced by new collection items.
		/// </summary>
		/// <typeparam name="TValue">Dictionary value generic type parameter</typeparam>
		/// <typeparam name="TKey">Dictionary key generic type parameter</typeparam>
		/// <param name="target">Target dictionaries</param>
		/// <param name="source">Source dictionaries</param>
		public static void UnionDictionaries<TKey, TValue>(IDictionary<TKey, IList<TValue>> target, IDictionary<TKey, IEnumerable<TValue>> source)
		{
			foreach (KeyValuePair<TKey, IEnumerable<TValue>> item in source)
			{
				TKey key = item.Key;
				if (target.ContainsKey(key))
				{
					target.Remove(key);
				}
				// add key and clone source IEnumerable collection 
				target.Add(new KeyValuePair<TKey, IList<TValue>>(item.Key, new List<TValue>(item.Value)));
			}
		}
    }
}
