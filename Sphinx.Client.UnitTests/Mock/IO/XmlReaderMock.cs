using System;
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
    public class XmlReaderMock : BinaryReaderBase
    {
        private static readonly Encoding _defaultEncoding = Encoding.ASCII;

        #region Constructors
		public XmlReaderMock(IStreamAdapter input): base(input, _defaultEncoding)
        {
        }

		public XmlReaderMock(IStreamAdapter input, Encoding encoding): base(input, encoding)
        {
        } 

        #endregion

        #region Overrides of BinaryReaderBase

        public override byte[] ReadBytes(int count)
        {
            string content = ReadNextTag("array");
            string[] items = content.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            byte[] bytes = new byte[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                if (i == count) break;
                bytes[i] = Byte.Parse(items[i]);
            }
            return bytes;
        }

        public override byte ReadByte()
        {
            string content = ReadNextTag("byte");
            return byte.Parse(content);
        }

        public override short ReadInt16()
        {
            string content = ReadNextTag("short");
            return short.Parse(content);
        }

        public override int ReadInt32()
        {
            string content = ReadNextTag("int");
            return int.Parse(content);
        }

        public override long ReadInt64()
        {
            string content = ReadNextTag("long");
            return long.Parse(content);
        }

        public override float ReadSingle()
        {
            string content = ReadNextTag("float");
            return float.Parse(content);
        }

        public override double ReadDouble()
        {
            string content = ReadNextTag("double");
            return double.Parse(content);
        }

        public override string ReadString()
        {
            string content = ReadNextTag("string");
            return XmlUtils.XmlDecode(content);
        }

        public override bool ReadBoolean()
        {
            string content = ReadNextTag("bool");
            return bool.Parse(content);
        }

        public override DateTime ReadDateTime()
        {
            string content = ReadNextTag("datetime");
            return DateTime.Parse(content);
        }

        #endregion

        #region Helpers
		private string ReadNextTag(string tagName)
        {
		    string expected = String.Format("<{0}>", tagName);
            string actual = ReadString(expected.Length);
            if (expected.CompareTo(actual) != 0) throw new XmlException(String.Format("Could not find opening tag '{0}', actually found '{1}'", expected, actual));
            StringBuilder result = new StringBuilder();
            string symbol;
            while (true)
            {
                symbol = ReadChar();
                if (symbol == "<") break;
                result.Append(symbol);
            }
		    expected = String.Format("/{0}>", tagName);
            actual = ReadString(expected.Length);
            if (expected.CompareTo(actual) != 0) throw new XmlException(String.Format("Could not find closing tag '{0}', actually found '{1}'", expected, actual));
            return XmlUtils.XmlDecode(result.ToString());
        }

        private string ReadString(int charsCount)
        {
            byte[] bytes = new byte[charsCount];
            // 1-byte encoding is forced for mock reader/writer
            int actuallyReaded = InputStream.ReadBytes(bytes, charsCount);
            if (actuallyReaded != charsCount) throw new EndOfStreamException();
            return Encoding.GetString(bytes);
        }

        private string ReadChar()
        {
			byte[] buffer = new byte[1];
			int byteValue = InputStream.ReadBytes(buffer, 1);
            if (byteValue == 0) throw new EndOfStreamException();
            return Encoding.GetString(buffer);
        }
 
	    #endregion    
    }
}
