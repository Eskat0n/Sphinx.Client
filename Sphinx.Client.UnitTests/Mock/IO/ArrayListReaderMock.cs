using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Sphinx.Client.IO;
using Sphinx.Client.Network;
using Sphinx.Client.UnitTests.Helpers;

namespace Sphinx.Client.UnitTests.Mock.IO
{
    public class ArrayListReaderMock : IBinaryReader
    {
		private ArrayList _list;
    	private int _index;

        #region Constructors
		public ArrayListReaderMock(ArrayList list)
		{
			_list = list;
			_index = 0;
		}
        #endregion

    	public ArrayList List
    	{
    		get { return _list; }
			set { _list = value; }
		}

		public int Index
		{
			get { return _index; }
			set { _index = value; }
		}

		#region Implementation of IBinaryReader

		public IStreamAdapter InputStream
    	{
    		get { throw new NotImplementedException(); }
    	}

    	public Encoding Encoding
    	{
    		get { throw new NotImplementedException(); }
    	}

    	public byte[] ReadBytes(int count)
        {
			var content = (byte[])ReadNextItem();
			if (content.Length != count) throw new InvalidDataException("Returned array length mismatch");
			return content;
        }

        public byte ReadByte()
        {
			var content = (byte)ReadNextItem();
            return content;
        }

        public short ReadInt16()
        {
			var content = (short)ReadNextItem();
            return content;
        }

        public int ReadInt32()
        {
			var content = (int)ReadNextItem();
            return content;
        }

        public long ReadInt64()
        {
			var content = (long)ReadNextItem();
			return content;
		}

        public float ReadSingle()
        {
			var content = (float)ReadNextItem();
			return content;
        }

        public double ReadDouble()
        {
			var content = (double)ReadNextItem();
			return content;
        }

        public string ReadString()
        {
			var content = (string)ReadNextItem();
			return content;
        }

        public bool ReadBoolean()
        {
			var content = (bool)ReadNextItem();
			return content;
        }

        public DateTime ReadDateTime()
        {
			var content = (DateTime)ReadNextItem();
			return content;
        }

        #endregion

        #region Helpers
		private object ReadNextItem()
		{
			return _list[_index++];
		}
	    #endregion    
    }
}
