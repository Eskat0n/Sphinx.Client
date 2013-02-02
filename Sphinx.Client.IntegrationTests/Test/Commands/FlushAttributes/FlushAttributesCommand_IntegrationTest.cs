using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Commands.FlushAttributes;
using Sphinx.Client.Commands.Status;
using Sphinx.Client.Connections;

namespace Sphinx.Client.IntegrationTests.Test.Commands.FlushAttributes
{
	///<summary>
    /// This is a test class for FlushAttributesCommand and is intended
    /// to contain all FlushAttributesCommand Integration Tests
	///</summary>
	[TestClass]
	public class FlushAttributesCommand_IntegrationTest
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
        public static void FlushAttributesCommand_IntegrationTestInitialize(TestContext testContext)
		{
			_connection = new PersistentTcpConnection(TestSettings.Default.Host, TestSettings.Default.Port);
			_connection.Open();
		}

		[ClassCleanup]
        public static void FlushAttributesCommand_IntegrationTestCleanup()
		{
			_connection.Close();
		} 
		#endregion

		[TestMethod]
		public virtual void RetrieveServerStatus()
		{
			var command = new FlushAttributesCommand(_connection);
			command.Execute();
			Assert.IsTrue(command.Result.Success);
		}
	}
}
