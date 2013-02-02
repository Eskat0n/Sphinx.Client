using Sphinx.Client.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System;
using Sphinx.Client.Network;
using Sphinx.Client.UnitTests.Test.Extensions;

namespace Sphinx.Client.UnitTests.Test.IO
{
    
    /// <summary>
    ///This is a test class for BigEndianBinaryReaderUnitTest and is intended
    ///to contain all BigEndianBinaryReaderUnitTest Unit Tests
    ///</summary>
    [TestClass]
    public class BigEndianBinaryReaderUnitTest
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
        ///A test for BigEndianBinaryReader constructor with encoding
        ///</summary>
        [TestMethod]
        public void BigEndianBinaryReaderConstructorEncodingTest()
        {
            Stream input = new MemoryStream();
            Encoding encoding = Encoding.UTF7;
            BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input), encoding);
            PrivateObject po = new PrivateObject(target);
            BigEndianBinaryReader_Accessor accessor = new BigEndianBinaryReader_Accessor(po);
            Assert.AreSame(accessor.Encoding, encoding);
        }

        /// <summary>
        ///A test for BigEndianBinaryReader constructor when passinng valid stream object
        ///</summary>
        [TestMethod]
        public void BigEndianBinaryReaderConstructorEncodingUtf16Test()
        {
            byte[] array = new byte[] {0, 0, 0, 6, 97, 00, 98, 00, 99, 00};
            using (Stream input = new MemoryStream(array))
            {
                // "abc" string in UTF16LE + prefix int string length in bytes
                Encoding encoding = Encoding.Unicode;
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input), encoding);
                string expected = "abc";
                string actual = target.ReadString();
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        ///A test for BigEndianBinaryReader constructor when passinng invalid stream object
        ///</summary>
        [TestMethod]
        public void BigEndianBinaryReaderConstructorNullStreamTest()
        {
            StreamAdapter input = null;
            try
            {
                new BigEndianBinaryReader(input);
            }
            catch(ArgumentException)
            {
                return; // test passed - ArgumentException has been thrown
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.Fail("Exception must be thrown for null stream object");
        }

        #endregion

        /// <summary>
        ///A test for ReadString
        ///</summary>
        [TestMethod]
        public void ReadStringTest()
        {
            byte[] array = new byte[] { 0, 0, 0, 3, 97, 98, 99 }; // 'abc' string in utf-8 + prefix int string length in bytes
            using (Stream input = new MemoryStream(array))
            {
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input));
                string expected = "abc";
                string actual = target.ReadString();
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        ///A test for ReadInt64
        ///</summary>
        [TestMethod]
        public void ReadInt64Test()
        {
            byte[] array = new byte[] { 0x01, 0x02, 0x03, 0x04, 0xF4, 0xF3, 0xF2, 0xF1 }; // 72623863815729905
            using (Stream input = new MemoryStream(array))
            {
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input));
                long expected = 72623863815729905;
                long actual = target.ReadInt64();
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        ///A test for ReadInt32
        ///</summary>
        [TestMethod]
        public void ReadInt32Test()
        {
            byte[] array = new byte[] { 0x01, 0x02, 0x03, 0x04 }; // 16909060
            using (Stream input = new MemoryStream(array))
            {
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input));
                int expected = 16909060;
                int actual = target.ReadInt32();
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        ///A test for ReadInt16
        ///</summary>
        [TestMethod]
        public void ReadInt16Test()
        {
            byte[] array = new byte[] { 0x01, 0xFF }; // 511
            using (Stream input = new MemoryStream(array))
            {
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input));
                short expected = 511;
                short actual = target.ReadInt16();
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        ///A test for ReadFloat
        ///</summary>
        [TestMethod]
        public void ReadFloatTest()
        {
            byte[] array = new byte[] { 0x3F, 0x9D, 0x70, 0xA4 }; // 1.23 in IEEE Float (32 bit) in Big endian representation with single precision 
            using (Stream input = new MemoryStream(array))
            {
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input));
                float expected = 1.23f;
                float actual = target.ReadSingle();
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        ///A test for ReadDateTime
        ///</summary>
        [TestMethod]
        public void ReadDateTimeTest()
        {
            byte[] array = new byte[] { 0x00, 0x00, 0x00, 0x01 }; // timestamp - 01.01.1970 00:00:01
            using (Stream input = new MemoryStream(array))
            {
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input));
                DateTime expected = new DateTime(1970, 1, 1, 0, 0, 1, DateTimeKind.Utc).ToLocalTime(); // DateTime - 01.01.1970 00:00:01 UTC
                DateTime actual = target.ReadDateTime();
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        ///A test for ReadBytes
        ///</summary>
        [TestMethod]
        public void ReadBytesTest()
        {
            byte[] array = new byte[] { 1, 2, 3 };
            using (Stream input = new MemoryStream(array))
            {
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input));
                int count = array.Length;
                byte[] expected = array;
                byte[] actual = target.ReadBytes(count);
                MyAssert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        ///A test for ReadByte
        ///</summary>
        [TestMethod]
        public void ReadByteTest()
        {
            byte[] array = new byte[] { 0xFF }; // 255
            using (Stream input = new MemoryStream(array))
            {
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input));
                byte expected = 255;
                byte actual = target.ReadByte();
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        ///A test for ReadBoolean
        ///</summary>
        [TestMethod]
        public void ReadBooleanTest()
        {
            byte[] array = new byte[] { 0, 0, 0, 1 }; // 1
            using (Stream input = new MemoryStream(array))
            {
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input));
                bool expected = true;
                bool actual = target.ReadBoolean();
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        ///A test for ReadDouble
        ///</summary>
        [TestMethod]
        public void ReadDoubleTest()
        {
            byte[] array = new byte[] { 0x40, 0x5E, 0xC7, 0xE6, 0xB7, 0x4D, 0xCE, 0x59 }; // 1.23123456789000002231659891549E2 in IEEE Double (64 bit) in Big endian representation with single precision 
            using (Stream input = new MemoryStream(array))
            {
                BigEndianBinaryReader target = new BigEndianBinaryReader(new StreamAdapter(input));
                double expected = 1.23123456789000002231659891549E2;
                double actual = target.ReadDouble();
                Assert.AreEqual(expected, actual);
            }
        }
        
        #endregion
    }
}
