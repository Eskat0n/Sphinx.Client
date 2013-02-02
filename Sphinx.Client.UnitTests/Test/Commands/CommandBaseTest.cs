using System;
using System.Collections;
using Sphinx.Client.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Commands.Moles;
using Sphinx.Client.Connections;
using Sphinx.Client.Connections.Moles;
using Sphinx.Client.UnitTests.Mock.Commands;
using Sphinx.Client.UnitTests.Mock.Connections;

namespace Sphinx.Client.UnitTests.Test.Commands
{

	[TestClass]
	public class CommandBase_UnitTest
	{
		public TestContext TestContext { get; set; }

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		[TestMethod]
		public void ConstructorTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				var commandBase = CreateCommandBase(connection);
				Assert.AreEqual(commandBase.Connection, connection);
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ConstructorTest_ThrowsOnNullConnection()
		{
			CreateCommandBase(null);
		}

		[TestMethod]
		[HostType("Moles")]
		public void ExecuteTest()
		{
			const string performCommandIsCalled = "PerformCommand method is called";
			const string validateParametersIsCalled = "ValidateParameters method is called";
			ArrayList calls = new ArrayList();
			MTcpConnection connection = new MTcpConnection
			{
				PerformCommandCommandBase = (command) => { if (command != null) { calls.Add(performCommandIsCalled); } }
			};
			var target = CreateCommandBase(connection);
			target.ValidateParameters01 = () => calls.Add(validateParametersIsCalled);

			target.Execute();

			CollectionAssert.AreEqual(calls, new[] { validateParametersIsCalled, performCommandIsCalled });
		}

		#region Helper methods
		private CommandWithResultBase_Accessor<TResult> GetCommandAccessor<TResult>(CommandWithResultBase<TResult> command)
			where TResult : CommandResultBase, new()
		{
			PrivateObject po = new PrivateObject(command);
			CommandWithResultBase_Accessor<TResult> accessor = new CommandWithResultBase_Accessor<TResult>(po);
			return accessor;
		}

		private SCommandBase CreateCommandBase(ConnectionBase connection)
		{
			var command = new SCommandBase(connection);
			command.CallBase = true;
			return command;
		}
		#endregion
	}
}