using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Common;
using Sphinx.Client.IO;
using Sphinx.Client.Network;
using Sphinx.Client.UnitTests.Test.Extensions;

namespace Sphinx.Client.UnitTests.Test.IO
{
    
    /// <summary>
    ///This is a test class for BigEndianBinaryWriterUnitTest and is intended
    ///to contain all BigEndianBinaryWriterUnitTest Unit Tests
    ///</summary>
    [TestClass]
    public class BigEndianBinaryWriterUnitTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        #region Tests

        #region Constructors
        /// <summary>
        ///A test for BigEndianBinaryWriter constructor with encoding
        ///</summary>
        [TestMethod]
        public void BigEndianBinaryWriterConstructorEncodingTest()
        {
            Stream output = new MemoryStream();
            Encoding encoding = Encoding.UTF7;
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output), encoding);
            PrivateObject po = new PrivateObject(target);
            BigEndianBinaryWriter_Accessor accessor = new BigEndianBinaryWriter_Accessor(po);
            Assert.AreSame(accessor.Encoding, encoding);
        }

        /// <summary>
        ///A test for BigEndianBinaryWriter constructor when passinng valid stream object
        ///</summary>
        [TestMethod]
        public void BigEndianBinaryWriterConstructorEncodingUtf16Test()
        {
            byte[] expected = new byte[] { 0, 0, 0, 6, 97, 00, 98, 00, 99, 00 }; // "abc" string in utf16 + int string length in bytes
            MemoryStream output = new MemoryStream();
            Encoding encoding = Encoding.Unicode;
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output), encoding);
            string input = "abc";
            target.Write(input);
            byte[] actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for BigEndianBinaryWriter constructor when passinng invalid stream object
        ///</summary>
        [TestMethod]
        public void BigEndianBinaryWriterConstructorNullStreamTest()
        {
            try
            {
                new BigEndianBinaryWriter(null);
            }
            catch(ArgumentException)
            {
                return; // test passed -ArgumentException has been thrown
            }
            Assert.Fail("Exception must be thrown for null output stream object");
        }

        #endregion

        /// <summary>
        ///A test for Write a byte
        ///</summary>
        [TestMethod]
        public void WriteByteTest()
        {
            MemoryStream output = new MemoryStream();
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output));
            byte expected = 255;
            target.Write(expected);
            byte actual = output.ToArray()[0];
            Assert.AreEqual(expected, actual);
        }

		/// <summary>
        ///A test for Write a short
        ///</summary>
        [TestMethod]
        public void WriteShortTest()
        {
            MemoryStream output = new MemoryStream();
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output));
            short data = 12345;
            byte[] expected = new byte[] { 0x30, 0x39 }; // 12345 in Big endian representation
            target.Write(data);
		    byte[] actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Write an int
        ///</summary>
        [TestMethod]
        public void WriteIntTest()
        {
            MemoryStream output = new MemoryStream();
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output));
            int data = 16776960;
            byte[] expected = new byte[] { 0x00, 0xFF, 0xFF, 0x00 }; // 16776960 in Big endian representation
            target.Write(data);
            byte[] actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for Write a byte array
        ///</summary>
        [TestMethod]
        public void WriteByteArrayTest()
        {
            MemoryStream output = new MemoryStream();
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output));
            byte[] expected = new byte[] { 1, 2, 3 };
            target.Write(expected);
            byte[] actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for Write a string
        ///</summary>
        [TestMethod]
        public void WriteStringTest()
        {
            MemoryStream output = new MemoryStream();
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output));
            string data = "abc"; 
            target.Write(data);
            byte[] expected = new byte[] { 0, 0, 0, 3, 97, 98, 99 }; // 'abc' string in utf-8 + prefix int with string length
            byte[] actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Write a boolean
        ///</summary>
        [TestMethod]
        public void WriteBooleanTest()
        {
            MemoryStream output = new MemoryStream();
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output));
            // false
            bool data = false; 
            target.Write(data);
            byte[] expected = new byte[] { 0, 0, 0, 0 }; // 0  = false
            byte[] actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
            // true
            output.Position = 0;
            data = true;
            target.Write(data);
            expected = new byte[] { 0, 0, 0, 1 }; // otherwise true
            actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Write a DateTime
        ///</summary>
        [TestMethod]
        public void WriteDateTimeTest()
        {
            MemoryStream output = new MemoryStream();
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output));
            DateTime data = new DateTime(1970, 1, 1, 0, 0, 1, DateTimeKind.Utc).ToLocalTime(); // 01.01.1970 00:00:01 UTC
            target.Write(data);
            byte[] expected = new byte[] { 0, 0, 0, 1 }; // 1 sec from Unix epoch
            byte[] actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Write a long
        ///</summary>
        [TestMethod]
        public void WriteLongTest()
        {
            MemoryStream output = new MemoryStream();
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output));
            long data = 1234567890123456789;
            target.Write(data);
            byte[] expected = new byte[] { 0x11, 0x22, 0x10, 0xF4, 0x7D, 0xE9, 0x81, 0x15 };
            byte[] actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Write a float
        ///</summary>
        [TestMethod]
        public void WriteFloatTest()
        {
            MemoryStream output = new MemoryStream();
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output));
            float data = 1.23f; 
            target.Write(data);
            byte[] expected = new byte[] { 0x3F, 0x9D, 0x70, 0xA4 }; // 1.23 in IEEE Float in Big endian representation with single precision (32 bit)
            byte[] actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Write a double
        ///</summary>
        [TestMethod]
        public void WriteDoubleTest()
        {
            MemoryStream output = new MemoryStream();
            BigEndianBinaryWriter target = new BigEndianBinaryWriter(new StreamAdapter(output));
            double data = 1.23123456789000002231659891549E2;
            target.Write(data);
            byte[] expected = new byte[] { 0x40, 0x5E, 0xC7, 0xE6, 0xB7, 0x4D, 0xCE, 0x59 }; // 1.23123456789000002231659891549E2 in IEEE Double in Big endian representation with double precision (64 bit)
            byte[] actual = output.ToArray();
            MyAssert.AreEqual(expected, actual);
        }
 
	#endregion    
    }
}
