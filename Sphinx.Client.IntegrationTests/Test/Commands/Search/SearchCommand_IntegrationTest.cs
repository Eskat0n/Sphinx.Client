using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Commands.Search;
using Sphinx.Client.Connections;

namespace Sphinx.Client.IntegrationTests.Test.Commands.Search
{
	///<summary>
	/// This is a test class for SearchCommand and is intended
	/// to contain all SearchCommand Integration Tests
	///</summary>
	[TestClass]
	public class SearchCommand_IntegrationTest
	{
		///<summary>
		/// Gets or sets the test context which provides
		/// information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext { get; set; }

		private static ConnectionBase _connection;

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

		#region Test initialization methods
		[ClassInitialize]
		public static void SearchCommand_IntegrationTestInitialize(TestContext testContext)
		{
			_connection = new PersistentTcpConnection(TestSettings.Default.Host, TestSettings.Default.Port);
			_connection.Open();
		}

		[ClassCleanup]
		public static void SearchCommand_IntegrationTestCleanup()
		{
			_connection.Close();
		} 
		#endregion

		[TestMethod]
		public virtual void SimpleSearch()
		{
			var command = new SearchCommand(_connection, new SearchQuery("devil"));
			command.Execute();
			Assert.AreEqual(1, command.Result.QueryResults.Count);
            Assert.AreEqual(4, command.Result.QueryResults[0].Count);
        }
	}
}
