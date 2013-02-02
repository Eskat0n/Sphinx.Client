using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Network;
using Sphinx.Client.UnitTests.Helpers;
using Sphinx.Client.UnitTests.Mock.IO;
using Sphinx.Client.UnitTests.Test.Extensions;

namespace Sphinx.Client.UnitTests.Test
{
    [TestClass]
    public class BinaryFormattersMockUnitTest
    {
        public BinaryFormattersMockUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ReadWriteBytesTest()
        {
            MemoryStream ms = new MemoryStream();
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(new StreamAdapter(ms));
            byte[] arr = new byte[] {1, 2, 3, 5, 6, 7, 8, 9, 0};
            writer.Write(arr);
            ms.Position = 0;
            string actual = Encoding.UTF8.GetString(ms.ToArray());
            string expected = "<array>1,2,3,5,6,7,8,9,0</array>";
            Assert.AreEqual(actual, expected);

            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(new StreamAdapter(ms));
            byte[] res = reader.ReadBytes(arr.Length);
            MyAssert.AreEqual(arr, res);
        }

        [TestMethod]
        public void ReadWriteByteTest()
        {
            MemoryStream ms = new MemoryStream();
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(new StreamAdapter(ms));
            byte a = 123;
            writer.Write(a);
            ms.Position = 0;
            string actual = Encoding.UTF8.GetString(ms.ToArray());
            string expected = "<byte>" + a + "</byte>";
            Assert.AreEqual(actual, expected);

            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(new StreamAdapter(ms));
            byte b = reader.ReadByte();
            Assert.AreEqual(a, b);

        }

        [TestMethod]
        public void ReadWriteInt16Test()
        {
            MemoryStream ms = new MemoryStream();
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(new StreamAdapter(ms));
            short a = 12345;
            writer.Write(a);
            ms.Position = 0;
            string actual = Encoding.UTF8.GetString(ms.ToArray());
            string expected = "<short>" + a + "</short>";
            Assert.AreEqual(actual, expected);

            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(new StreamAdapter(ms));
            short b = reader.ReadInt16();
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void ReadWriteInt32Test()
        {
            MemoryStream ms = new MemoryStream();
        	IStreamAdapter adapter = new StreamAdapter(ms);
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(adapter);
            int a = 1234567890;
            writer.Write(a);
            ms.Position = 0;
            string actual = Encoding.UTF8.GetString(ms.ToArray());
            string expected = "<int>" + a + "</int>";
            Assert.AreEqual(actual, expected);

            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(adapter);
            int b = reader.ReadInt32();
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void ReadWriteInt64Test()
        {
            MemoryStream ms = new MemoryStream();
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(new StreamAdapter(ms));
            long a = 1234567890123456789;
            writer.Write(a);
            ms.Position = 0;
            string actual = Encoding.UTF8.GetString(ms.ToArray());
            string expected = "<long>" + a + "</long>";
            Assert.AreEqual(actual, expected);

            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(new StreamAdapter(ms));
            long b = reader.ReadInt64();
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void ReadWriteSingleTest()
        {
            MemoryStream ms = new MemoryStream();
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(new StreamAdapter(ms));
            float a = 1.2345f;
            writer.Write(a);
            ms.Position = 0;
            string actual = Encoding.UTF8.GetString(ms.ToArray());
            string expected = "<float>" + a + "</float>";
            Assert.AreEqual(actual, expected);

            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(new StreamAdapter(ms));
            float b = reader.ReadSingle();
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void ReadWriteDoubleTest()
        {
            MemoryStream ms = new MemoryStream();
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(new StreamAdapter(ms));
            double a = 1234567890.123456789f;
            writer.Write(a);
            ms.Position = 0;
            string actual = Encoding.UTF8.GetString(ms.ToArray());
            string expected = "<double>" + a + "</double>";
            Assert.AreEqual(actual, expected);

            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(new StreamAdapter(ms));
            double b = reader.ReadDouble();
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void ReadWriteStringTest()
        {
            MemoryStream ms = new MemoryStream();
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(new StreamAdapter(ms));
            string a = "abcdef<test&escaping>";
            writer.Write(a);
            ms.Position = 0;
            string actual = Encoding.UTF8.GetString(ms.ToArray());
            string expected = "<string>" + XmlUtils.XmlEncode(a) + "</string>";
            Assert.AreEqual(actual, expected);

            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(new StreamAdapter(ms));
            string b = reader.ReadString();
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void ReadWriteDateTimeTest()
        {
            MemoryStream ms = new MemoryStream();
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(new StreamAdapter(ms));
            DateTime a = new DateTime(2000, 1, 1, 1, 1, 1); // 01.01.2000 01:01:01
            writer.Write(a);
            ms.Position = 0;
            string actual = Encoding.UTF8.GetString(ms.ToArray());
            string expected = "<datetime>" + a + "</datetime>";
            Assert.AreEqual(actual, expected);

            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(new StreamAdapter(ms));
            DateTime b = reader.ReadDateTime();
            Assert.AreEqual(a, b);
        }

        [TestMethod]
        public void ReadWriteComplexTest()
        {
            MemoryStream ms = new MemoryStream();
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(new StreamAdapter(ms));
            DateTime dat = new DateTime(2002, 2, 2, 2, 2, 2); // 02.02.2002 02:02:02
            writer.Write(dat);
            string str = "test string";
            writer.Write(str);
            int integer = 223344;
            writer.Write(integer);
            float single = 1.2345f;
            writer.Write(single);
            byte[] bytes = new byte[] {5,4,3,2,1};
            writer.Write(bytes);
            long int64 = 1234567890;
            writer.Write(int64);

            ms.Position = 0;

            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(new StreamAdapter(ms));
            DateTime adat = reader.ReadDateTime();
            Assert.AreEqual(dat, adat);
            string astr = reader.ReadString();
            Assert.AreEqual(str, astr);
            int aint = reader.ReadInt32();
            Assert.AreEqual(integer, aint);
            float asingle = reader.ReadSingle();
            Assert.AreEqual(single, asingle);
            byte[] abytes = reader.ReadBytes(bytes.Length);
            MyAssert.AreEqual(bytes, abytes);
            long aint64 = reader.ReadInt64();
            Assert.AreEqual(int64, aint64);
        }

        [TestMethod]
        public void ReadWriteComplexDataTypeValidationTest()
        {
            MemoryStream ms = new MemoryStream();
            // serialize some data
            XmlWriterMock writer = new XmlWriterMock(new StreamAdapter(ms));

            int integer = 123;
            writer.Write(integer);
            string str = "test string";
            writer.Write(str);

            ms.Position = 0;
            // deserialize serialized data
            XmlReaderMock reader = new XmlReaderMock(new StreamAdapter(ms));
            try
            {
                // current reader position at <date> tag 
                reader.ReadString();
                Assert.Fail("Reader data type checking is failed");
            }
            catch (XmlException)
            {
                // test passed
            }
        }
    }
}
