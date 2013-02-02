using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Connections;

namespace Sphinx.Client.IntegrationTests.Test.Connections
{
	///<summary>
	/// This is a test class for PersistentTcpConnection and is intended
	/// to contain all PersistentTcpConnection Integration Tests
	///</summary>
	[TestClass]
	public class PersistentTcpConnection_IntegrationTest
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

        #region Tests
        ///<summary>
        /// Just try to connect to Sphinx and make handshake
        ///</summary>
        [TestMethod]
		public virtual void ConnectToSphinx()
        {
			using (var connection = new PersistentTcpConnection(TestSettings.Default.Host, TestSettings.Default.Port))
			{
        		connection.Open();
				Assert.IsTrue(connection.IsConnected);
				connection.Close();
				Assert.IsFalse(connection.IsConnected);
			}
        }
		#endregion
	}
}
