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

using Sphinx.Client.Helpers;

namespace Sphinx.Client.Commands.Attributes
{
    public abstract class AttributeBase
    {
        #region Fields
        private string _name;
		private AttributeType _attributeType;
        
        #endregion

        #region Constructors
        protected AttributeBase()
        {
        }

        protected AttributeBase(string name)
        {
            Name = name;
        }

        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            protected set
            {
                ArgumentAssert.IsNotEmpty(value, "Name");
                _name = value;
            }
        }

    	public virtual AttributeType AttributeType
    	{
    		get { return _attributeType; }
    		protected set { _attributeType = value; }
    	}

    	#endregion

    }
}
