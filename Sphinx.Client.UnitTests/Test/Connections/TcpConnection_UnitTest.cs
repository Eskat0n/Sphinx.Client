using System;
using System.Net;
using System.Threading;
using Sphinx.Client.Common;
using Sphinx.Client.Connections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Commands;
using System.IO;
using Sphinx.Client.IO;
using Sphinx.Client.Network;
using Sphinx.Client.UnitTests.Mock.Commands;
using Sphinx.Client.UnitTests.Mock.IO;
using Sphinx.Client.UnitTests.Test.Extensions;
using Sphinx.Client.UnitTests.Mock.Network;

namespace Sphinx.Client.UnitTests.Test.Connections
{
    
    ///<summary>
    /// This is a test class for TcpConnection and is intended
    /// to contain all TcpConnection Unit Tests
    ///</summary>
    [TestClass]
    public class TcpConnectionUnitTest
    {
        ///<summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
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

        #region Test
        ///<summary>
        /// A test for Connection Constructor
        ///</summary>
        [TestMethod]
        public virtual void ConnectionConstructorTest_Host()
        {
            // valid value using constructor argument
            string expected = "localhost";
            ConnectionBase target = CreateConnection(expected);
            Assert.AreEqual(expected, target.Host);
            // invalid value by constructor
            try
            {
                string host = null;
                CreateConnection(host);
                Assert.Fail("Constructor must throw ArgumentException");
            }
            catch (ArgumentException)
            {
                // ArgumentException has thrown, test passed
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

            // invalid value by constructor
            try
            {
                string host = String.Empty;
                CreateConnection(host);
                Assert.Fail("Constructor must throw ArgumentException");
            }
            catch (ArgumentException)
            {
                // ArgumentException has thrown, test passed
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        ///<summary>
        ///  test for Connection Constructor
        ///</summary>
        [TestMethod]
        public virtual void ConnectionConstructorTest_HostPort()
        {
            string host = "test";
            int expected = 123;
            // valid value by constructor
            ConnectionBase target = CreateConnection(host, expected);
            Assert.AreEqual(host, target.Host);
            Assert.AreEqual(expected, target.Port);
            expected = 321;
            // invalid value by constructor
            try
            {
                CreateConnection(host, 0);
                Assert.Fail("Constructor must throw ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                // ArgumentOutOfRangeException has thrown, test passed
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        ///<summary>
        /// A test for Connection Constructor
        ///</summary>
        [TestMethod]
        public virtual void ConnectionConstructorTest_IPEndPoint()
        {
            string host = "1.2.3.4";
            int expected = 123;
            // valid value by constructor
            ConnectionBase target = CreateConnection(new IPEndPoint(new IPAddress(new byte[] {1,2,3,4}), expected));
            Assert.AreEqual(host, target.Host);
            Assert.AreEqual(expected, target.Port);
            expected = 321;
            // invalid value by constructor
            try
            {
                IPEndPoint adr = null;
                CreateConnection(adr);
                Assert.Fail("Constructor must throw ArgumentException");
            }
            catch (ArgumentException)
            {
                // ArgumentException has thrown, test passed
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        ///<summary>
        /// A test for Host property
        ///</summary>
        [TestMethod]
        public virtual void HostTest()
        {
            ConnectionBase target = CreateConnection();
            // valid value
		    string expected = "test host name";
            target.Host = expected;
            Assert.AreEqual(expected, target.Host);
            // invalid value
            try
            {
                target.Host = string.Empty;
                Assert.Fail("Property setter must throw ArgumentException");
            }
            catch (ArgumentException)
            {
                // ArgumentException has thrown, test passed
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        ///<summary>
        /// A test for Port property
        ///</summary>
        [TestMethod]
        public virtual void PortTest()
        {
            string host = "test"; 
            int expected = 123; 
            // valid value by constructor
            ConnectionBase target = CreateConnection(host, expected);
            Assert.AreEqual(expected, target.Port);
            expected = 321;
            // valid value by property
            target.Port = expected;
            Assert.AreEqual(expected, target.Port);
            // invalid value by constuctor
            try
            {
                target = CreateConnection(host, 0);
                Assert.Fail("Constructor must throw ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException)
            {
                // ArgumentOutOfRangeException has thrown, test passed
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// A test for IsConnected property
        ///</summary>
        [TestMethod]
        [DeploymentItem("Sphinx.Client.dll")]
        public virtual void IsConnectedTest()
        {
            ConnectionBase conn = CreateConnection("test");
            try
            {
                GetConnectionAccessor(conn).Socket = new ClientSocketMock();
                conn.Open();
                Assert.IsTrue(conn.IsConnected);
                conn.Close();
                Assert.IsFalse(conn.IsConnected);
            }
            finally
            {
                conn.Close();
            }
        }

        ///<summary>
        ///A test for DataStream property
        ///</summary>
        [TestMethod]
        [DeploymentItem("Sphinx.Client.dll")]
        public virtual void DataStreamTest()
        {
            ConnectionBase conn = CreateConnection("test");
            try
            {
                TcpConnection_Accessor accessor = GetConnectionAccessor(conn);
                accessor.Socket = new ClientSocketMock();
                Assert.IsNull(accessor.DataStream);
                conn.Open();
                Assert.IsNotNull(accessor.DataStream);
            }
            finally
            {
                conn.Close();
            }
        }

        ///<summary>
        /// A test for ConnectionTimeout property
        ///</summary>
        [TestMethod]
        public virtual void ConnectionTimeoutTest()
        {
            ConnectionBase conn = CreateConnection("test");
            try
            {
                TcpConnection_Accessor accessor = GetConnectionAccessor(conn);
                accessor.Socket = new ClientSocketMock();
                const int timeout = 100;
                conn.ConnectionTimeout = timeout;
                Assert.AreEqual(timeout, conn.ConnectionTimeout);
                conn.Open();
                // wait "timeout" time and give timer little time to set new property value
                Thread.Sleep(timeout + 100);
                Assert.IsFalse(conn.IsConnected);
            }
            finally
            {
                conn.Close();
            }
        }

        ///<summary>
        /// A test for SendHandshake method
        ///</summary>
        [TestMethod]
        [DeploymentItem("Sphinx.Client.dll")]
        public virtual void SendHandshakeTest()
        {
            ConnectionBase conn = CreateConnection("test");
            try
            {
                TcpConnection_Accessor accessor = GetConnectionAccessor(conn);
                // assign mock socket and open fake stream
                accessor.Socket = new ClientSocketMock();
                // underlying socket sholud be already opened
                accessor.Socket.Open();
                // assign mock binary formatter factory
                XmlFormatterFactoryMock factory = new XmlFormatterFactoryMock();
                accessor._formatterFactory = factory;
                IBinaryWriter writer = factory.CreateWriter(accessor.DataStream);

                // preserialize server reponse (protocol version) and rewind to start pos. (emulate first stage of handshake procedure)
                int protocolVersion = TcpConnection_Accessor.MAJOR_PROTOCOL_VERSION; 
                writer.Write(protocolVersion);
				StreamAdapter_Accessor streamAccessor = GetStreamAccessor((StreamAdapter)accessor.DataStream);
				long pos = streamAccessor.Stream.Position;
				streamAccessor.Stream.Seek(0, SeekOrigin.Begin);

                accessor.SendHandshake();

                // restore stream pos
				streamAccessor.Stream.Seek(pos, SeekOrigin.Begin);
                IBinaryReader reader = factory.CreateReader(accessor.DataStream);
                // read client response 
                int actual = reader.ReadInt32();
                Assert.AreEqual(actual, protocolVersion);
            }
            finally
            {
                conn.Close();
            }
        }

        ///<summary>
        /// A test for PerformCommand
        ///</summary>
        [TestMethod]
        public virtual void PerformCommandTest()
        {
            ConnectionBase conn = CreateConnection("test");
            try
            {
                TcpConnection_Accessor accessor = GetConnectionAccessor(conn);
                // assign mock socket
                accessor.Socket = new ClientSocketMock();
                accessor.Socket.Open();

                XmlFormatterFactoryMock factory = new XmlFormatterFactoryMock();
                accessor.FormatterFactory = factory;
                IBinaryWriter writer = factory.CreateWriter(accessor.DataStream);

                // preserialize server protocol version and rewind to start pos. (emulate first stage of handshake procedure)
                int protocolVersion = TcpConnection_Accessor.MAJOR_PROTOCOL_VERSION; 
                writer.Write(protocolVersion);
				StreamAdapter_Accessor streamAccessor = GetStreamAccessor((StreamAdapter)accessor.DataStream);
				long pos = streamAccessor.Stream.Position;
				streamAccessor.Stream.Seek(0, SeekOrigin.Begin);
                // command id and version
                const ServerCommand id = ServerCommand.Status;
                const short ver = 1;
                MockCommand command = new MockCommand(conn, id, ver);

                accessor.PerformCommand(command);

                accessor.Socket.Open();
				streamAccessor.Stream.Seek(pos, SeekOrigin.Begin);
                IBinaryReader reader = factory.CreateReader(accessor.DataStream);
                // skip protocol version sent by hadshake method
                int clientProtocol = reader.ReadInt32();

                // read & check data sent by mock command code
                ServerCommand actualId = (ServerCommand)reader.ReadInt16();
                Assert.AreEqual(id, actualId);
                short actualVer = reader.ReadInt16();
                Assert.AreEqual(ver, actualVer);
            }
            finally
            {
                conn.Close();
            }
        }

        ///<summary>
        /// A test for Open
        ///</summary>
        [TestMethod]
        public virtual void OpenTest()
        {
            ConnectionBase conn = CreateConnection("test");
            try
            {
                GetConnectionAccessor(conn).Socket = new ClientSocketMock();
                conn.Open();
                Assert.IsTrue(conn.IsConnected);
                conn.Close();
                Assert.IsFalse(conn.IsConnected);
            }
            finally
            {
                conn.Close();
            }
        }

        ///<summary>
        /// A test for Dispose
        ///</summary>
        [TestMethod]
        public virtual void DisposeTest()
        {
            ConnectionBase conn = CreateConnection("test");
            try
            {
                GetConnectionAccessor(conn).Socket = new ClientSocketMock();
                conn.Open();
                Assert.IsTrue(conn.IsConnected);
                conn.Dispose();
                Assert.IsFalse(conn.IsConnected);
            }
            finally
            {
                conn.Close();
            }
        }

        ///<summary>
        /// A test for Dispose(bool)
        ///</summary>
        [TestMethod]
        [DeploymentItem("SphinxSearch.dll")]
        public virtual void ProtectedDisposeTest()
        {
            ConnectionBase conn = CreateConnection("test");
            try
            {
                TcpConnection_Accessor accessor = GetConnectionAccessor(conn);
                accessor.Socket = new ClientSocketMock();
                conn.Open();
                Assert.IsTrue(conn.IsConnected);
                accessor.Dispose(false);
                Assert.IsTrue(conn.IsConnected);
                accessor.Dispose(true);
                Assert.IsFalse(conn.IsConnected);
            }
            finally
            {
                conn.Close();
            }
        }

        ///<summary>
        /// A test for Close
        ///</summary>
        [TestMethod]
        public virtual void CloseTest()
        {
            ConnectionBase conn = CreateConnection("test");
            try
            {
                GetConnectionAccessor(conn).Socket = new ClientSocketMock();
                conn.Open();
                Assert.IsTrue(conn.IsConnected);
                conn.Close();
                Assert.IsFalse(conn.IsConnected);
                conn.Close();
                Assert.IsFalse(conn.IsConnected);
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion 

        #region Helper methods
        protected ConnectionBase CreateConnection()
        {
            return new TcpConnection();
        }

        protected ConnectionBase CreateConnection(string host)
        {
            return new TcpConnection(host);
        }

        protected ConnectionBase CreateConnection(string host, int port)
        {
            return new TcpConnection(host, port);
        }

        protected ConnectionBase CreateConnection(IPEndPoint ipEndPoint)
        {
            return new TcpConnection(ipEndPoint);
        }

		/// <summary>
        /// Returns <see cref="TcpConnection_Accessor"/> object accessor for given <see cref="TcpConnection"/> object.
        /// </summary>
        /// <param name="connection"><see cref="TcpConnection"/> object</param>
        /// <returns><see cref="TcpConnection_Accessor"/> object</returns>
        protected TcpConnection_Accessor GetConnectionAccessor(ConnectionBase connection)
        {
            PrivateObject po = new PrivateObject(connection);
            TcpConnection_Accessor accessor = new TcpConnection_Accessor(po);
            return accessor;
        }

		protected TcpStreamAdapter_Accessor GetStreamAccessor(TcpStreamAdapter adapter)
		{
			PrivateObject po = new PrivateObject(adapter);
			TcpStreamAdapter_Accessor accessor = new TcpStreamAdapter_Accessor(po);
			return accessor;
		}

		protected StreamAdapter_Accessor GetStreamAccessor(StreamAdapter adapter)
		{
			PrivateObject po = new PrivateObject(adapter);
			StreamAdapter_Accessor accessor = new StreamAdapter_Accessor(po);
			return accessor;
		}
	    #endregion    
    }
}
