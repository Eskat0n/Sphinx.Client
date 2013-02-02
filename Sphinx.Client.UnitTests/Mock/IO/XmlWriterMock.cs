using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using Sphinx.Client.IO;
using Sphinx.Client.Network;
using Sphinx.Client.UnitTests.Helpers;

namespace Sphinx.Client.UnitTests.Mock.IO
{
    public class XmlWriterMock : BinaryWriterBase
    {
        private static readonly Encoding _defaultEncoding = Encoding.ASCII;

        #region Constructors
		public XmlWriterMock(IStreamAdapter output): base(output, _defaultEncoding)
        {
        }

		public XmlWriterMock(IStreamAdapter output, Encoding encoding): base(output, encoding)
        {
        }
 
	    #endregion

        #region Overrides of BinaryWriterBase

        public override void Write(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            int num = 0;
            foreach (byte b in data)
            {
                if (num++ > 0) sb.Append(",");
                sb.Append(b);
            }
            WriteAsXmlTag("array", sb.ToString());
        }

        public override void Write(byte data)
        {
            WriteAsXmlTag("byte", data);
        }

        public override void Write(short data)
        {
            WriteAsXmlTag("short", data);
        }

        public override void Write(int data)
        {
            WriteAsXmlTag("int", data);
        }

        public override void Write(long data)
        {
            WriteAsXmlTag("long", data);
        }

        public override void Write(float data)
        {
            WriteAsXmlTag("float", data);
        }

        public override void Write(double data)
        {
            WriteAsXmlTag("double", data);
        }

        public override void Write(string data)
        {
            WriteAsXmlTag("string", XmlUtils.XmlEncode(data));
        }

        public override void Write(bool data)
        {
            WriteAsXmlTag("bool", data);
        }

        public override void Write(DateTime data)
        {
            WriteAsXmlTag("datetime", data);
        }

        #endregion

        #region Helpers
        private void WriteAsXmlTag(string tagName, object data)
        {
            string output = String.Format("<{0}>{1}</{0}>", tagName, data);
            byte[] bytes = Encoding.GetBytes(output);
            OutputStream.WriteBytes(bytes, bytes.Length);
        }
        
        #endregion
    }
}
