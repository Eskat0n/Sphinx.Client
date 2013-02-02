using System;
using Sphinx.Client.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
using Sphinx.Client.Network;

namespace Sphinx.Client.UnitTests.Test.IO
{
    /// <summary>
    ///This is a test class for BinaryFormatterFactoryUnitTest and is intended
    ///to contain all BinaryFormatterFactoryUnitTest Unit Tests
    ///</summary>
    [TestClass]
    public class BinaryFormatterFactoryUnitTest
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

        /// <summary>
        ///A test for BinaryFormatterFactory Constructor
        ///</summary>
        [TestMethod]
        public void BinaryFormatterFactoryConstructorTest()
        {
            // binary format type argument validation
            try
            {
                new BinaryFormatterFactory((BinaryFormatType) int.MaxValue, Encoding.Default);
                Assert.Fail("ArgumentException exception must be thrown in constructor");
            }
            catch (ArgumentException)
            {
                // test passed
            }

            // encoding argument validation
            try
            {
                new BinaryFormatterFactory(BinaryFormatType.BigEndian, null);
                Assert.Fail("ArgumentException exception must be thrown in constructor");
            }
            catch (ArgumentException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for CreateWriter
        ///</summary>
        [TestMethod]
        public void CreateWriterTest()
        {
            // all arguments are valid
            BinaryFormatType formatType = BinaryFormatType.BigEndian;
            Encoding encoding = Encoding.Default; 
            BinaryFormatterFactory target = new BinaryFormatterFactory(formatType, encoding);
            using (Stream stream = new MemoryStream())
            {
				IBinaryWriter actual = target.CreateWriter(new StreamAdapter(stream));
                Assert.IsInstanceOfType(actual, typeof(BigEndianBinaryWriter));
                Assert.AreEqual(encoding, actual.Encoding);
            }

            // invalid stream object
            try
            {
                target.CreateWriter(null);
                Assert.Fail("ArgumentException exception must be thrown in constructor");
            }
            catch (ArgumentException)
            {
                // test passed
            }

            target = new BinaryFormatterFactory(BinaryFormatType.None, encoding);
            try
            {
                target.CreateWriter(null);
                Assert.Fail("NotSupportedException exception must be thrown in constructor");
            }
            catch (NotSupportedException)
            {
                // test passed
            }

        }

        /// <summary>
        ///A test for CreateReader
        ///</summary>
        [TestMethod]
        public void CreateReaderTest()
        {
            // all arguments are valid
            BinaryFormatType formatType = BinaryFormatType.BigEndian;
            Encoding encoding = Encoding.Default;
            BinaryFormatterFactory target = new BinaryFormatterFactory(formatType, encoding);
            using (Stream stream = new MemoryStream())
            {
                IBinaryReader actual = target.CreateReader(new StreamAdapter(stream));
                Assert.IsInstanceOfType(actual, typeof(BigEndianBinaryReader));
                Assert.AreEqual(encoding, actual.Encoding);
            }

            // invalid stream object
            try
            {
                target.CreateReader(null);
                Assert.Fail("ArgumentException exception must be thrown in constructor");
            }
            catch (ArgumentException)
            {
                // test passed
            }

            target = new BinaryFormatterFactory(BinaryFormatType.None, encoding);
            try
            {
                target.CreateReader(null);
                Assert.Fail("NotSupportedException exception must be thrown in constructor");
            }
            catch (NotSupportedException)
            {
                // test passed
            }
        }
    }
}
