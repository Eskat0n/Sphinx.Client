using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sphinx.Client.IO;
using Sphinx.Client.Network;

namespace Sphinx.Client.UnitTests.Mock.IO
{
	public class ArrayListWriterMock : IBinaryWriter
	{
		private ArrayList _list;
    	private int _index;

        #region Constructors
		public ArrayListWriterMock(ArrayList list)
		{
			_list = list;
			Reset();
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

		public IStreamAdapter OutputStream
		{
			get { throw new NotImplementedException(); }
		}

		public Encoding Encoding
		{
			get { throw new NotImplementedException(); }
		}

		public void Write(byte[] data)
		{
			AddItem(data);
		}

		public void Write(byte data)
		{
			AddItem(data);
		}

		public void Write(short data)
		{
			AddItem(data);
		}

		public void Write(int data)
		{
			AddItem(data);
		}

		public void Write(long data)
		{
			AddItem(data);
		}

		public void Write(float data)
		{
			AddItem(data);
		}

		public void Write(double data)
		{
			AddItem(data);
		}

		public void Write(string data)
		{
			AddItem(data);
		}

		public void Write(bool data)
		{
			AddItem(data);
		}

		public void Write(DateTime data)
		{
			AddItem(data);
		}

		public void Flush()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Helpers
		private void AddItem(object value)
		{
			_list.Insert(_index++, value);
		}
		#endregion

		public void Reset()
		{
			_list.Clear();
			_index = 0;
		}
	}
}
