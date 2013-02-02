using System;
using System.Net.Sockets;
using Sphinx.Client.Network;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Sphinx.Client.UnitTests.Test.Network
{
    
    
    /// <summary>
    ///This is a test class for TcpSocketAdapterUnitTest and is intended
    ///to contain all TcpSocketAdapterUnitTest Unit Tests
    ///</summary>
    [TestClass]
    public class TcpSocketAdapterUnitTest
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
        ///A test for TcpSocketAdapter Constructor
        ///</summary>
        [TestMethod]
        public void TcpSocketAdapterConstructorTestEmpty()
        {
            using (new TcpSocketAdapter())
            {
            }
        }

        /// <summary>
        ///A test for TcpSocketAdapter Constructor
        ///</summary>
        [TestMethod]
        public void TcpSocketAdapterConstructorTest()
        {
            string host = string.Empty; 
            int port = 0; 
            new TcpSocketAdapter(host, port);
        }

        /// <summary>
        ///A test for Port
        ///</summary>
        [TestMethod]
        public void PortTest()
        {
            TcpSocketAdapter target = new TcpSocketAdapter(); 
            target.Port = 0;
            Assert.AreEqual(0, target.Port);
			target.Port = 10000;
			Assert.AreEqual(10000, target.Port);
		}

        /// <summary>
        ///A test for Host
        ///</summary>
        [TestMethod]
        public void HostTest()
        {
            TcpSocketAdapter target = new TcpSocketAdapter(); 
            target.Host = string.Empty;
			Assert.AreEqual(string.Empty, target.Host);
			target.Host = "test";
			Assert.AreEqual("test", target.Host);
		}

        /// <summary>
        ///A test for DataStream
        ///</summary>
        [TestMethod]
        public void DataStreamTest()
        {
            TcpSocketAdapter target = new TcpSocketAdapter();
        	try {
				var val = target.DataStream;
			}
			catch (InvalidOperationException)
			{
				return;
			}
			Assert.Fail("DataStream getter must throw InvalidOperationException exception when socket is not connected");
        }

        /// <summary>
        ///A test for ConnectionTimeout
        ///</summary>
        [TestMethod]
        public void ConnectionTimeoutTest()
        {
            TcpSocketAdapter target = new TcpSocketAdapter(); 
            int expected = 0; 
            int actual;
            target.ConnectionTimeout = expected;
            actual = target.ConnectionTimeout;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Connected
        ///</summary>
        [TestMethod]
        public void ConnectedTest()
        {
            TcpSocketAdapter target = new TcpSocketAdapter(); 
            Assert.IsFalse(target.Connected);
        }

        /// <summary>
        ///A test for Open
        ///</summary>
        [TestMethod]
        public void OpenTest()
        {
			TcpSocketAdapter target = new TcpSocketAdapter();
			try
			{
				target.Open();
				Assert.Fail("Must throw an ArgumentException");
			}
			catch (ArgumentException)
			{
			}

			target = new TcpSocketAdapter("test", 123);
			try
			{
				target.Open();
				Assert.Fail("Must throw an SocketException");
			}
			catch (SocketException)
			{
			}
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod]
        public void DisposeTest()
        {
            TcpSocketAdapter target = new TcpSocketAdapter();
            target.Dispose();
        }

        /// <summary>
        ///A test for Close
        ///</summary>
        [TestMethod]
        public void CloseTest()
        {
            TcpSocketAdapter target = new TcpSocketAdapter();
            target.Close();
        }

    }
}
