using System;
using System.Collections;
using System.IO;
using Sphinx.Client.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Commands.Moles;
using Sphinx.Client.Connections;
using Sphinx.Client.Connections.Moles;
using Sphinx.Client.Network;
using Sphinx.Client.IO;
using Sphinx.Client.Network.Moles;
using Sphinx.Client.UnitTests.Mock.Commands;
using Sphinx.Client.UnitTests.Mock.Connections;
using Sphinx.Client.UnitTests.Mock.IO;
using Sphinx.Client.UnitTests.Mock.Network;

namespace Sphinx.Client.UnitTests.Test.Commands
{
    
	[TestClass]
	public class CommandWithResultBase_UnitTest
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
				var commandBase = CreateCommandWithResultBase(connection);
				Assert.AreEqual(commandBase.Connection, connection);
			}
		}

		[TestMethod]
		public void ResultTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				var target = CreateCommandWithResultBase(connection);
				var accessor = GetCommandAccessor(target);
				var expected = new CommandResultBaseMock();
				accessor.Result = expected;
				Assert.AreEqual(expected, target.Result);
			}
		}

		[TestMethod]
		[HostType("Moles")]
		public void ExecuteTest()
		{
			bool baseExecuteIsCalled = false;
			MCommandBase.AllInstances.Execute = delegate { baseExecuteIsCalled = true; };
			using (ConnectionBase connection = new ConnectionMock())
			{
				var target = CreateCommandWithResultBase(connection);

				target.Execute();

				Assert.IsNotNull(target.Result);
				Assert.IsTrue(baseExecuteIsCalled);
			}
		}

		[TestMethod]
		[HostType("Moles")]
		public void SerializeTest()
		{
			using (ConnectionMock connection = new ConnectionMock())
			{
				ArrayList calls = new ArrayList();
				ArrayList buffer = new ArrayList();
				connection.SetFormatterFactory(new ArrayListFormatterFactoryMock(buffer));

				const string commandinfoSerializeIsCalled = "commandInfo Serialize is called";
				MCommandInfo commandInfo = new MCommandInfo
				{
					SerializeIBinaryWriter = (writer) => calls.Add(commandinfoSerializeIsCalled)
				};
				
				var target = CreateCommandWithResultBase(connection);
				target.CommandInfoGet = () => commandInfo;
				const string serializeRequestIsCalled = "SerializeRequest is called";
				target.SerializeRequestIBinaryWriter = (writer) => calls.Add(serializeRequestIsCalled);
				var accessor = GetCommandAccessor(target);
				const string writebytesIsCalled = "WriteBytes is called";
				var streamAdapter = new SStreamAdapter(new MemoryStream())
				{
					WriteBytesByteArrayInt32 = (array, len) => calls.Add(writebytesIsCalled)
				};

				accessor.Serialize(streamAdapter);

				CollectionAssert.AreEqual(buffer, new int[] { 0 });
				CollectionAssert.AreEqual(calls, new [] { commandinfoSerializeIsCalled, serializeRequestIsCalled, writebytesIsCalled });
			}			
		}

		[TestMethod]
		[HostType("Moles")]
		public void DeserializeTest()
		{
			using (ConnectionMock connection = new ConnectionMock())
			{
				ArrayList calls = new ArrayList();
				ArrayList buffer = new ArrayList();
				connection.SetFormatterFactory(new ArrayListFormatterFactoryMock(buffer));
				const CommandStatus expectedStatus = CommandStatus.Ok;
				buffer.Add((short) expectedStatus);
				const short expectedCommandVersion = 1;
				buffer.Add(expectedCommandVersion);
				const int expectedLength = 1;
				buffer.Add(expectedLength);
				buffer.Add(1); // body stub

				var target = CreateCommandWithResultBase(connection);
				const string validateResponseIsCalled = "ValidateResponse is called";
				target.ValidateResponseIBinaryReaderInt16 = (bodyReader, serverCommandVersion) =>
				{
					if (serverCommandVersion == expectedCommandVersion)
						calls.Add(validateResponseIsCalled);
				};
				const string deserializeResponseIsCalled = "DeserializeResponse is called";
				target.DeserializeResponseIBinaryReader = (bodyReader) =>
				{
					calls.Add(deserializeResponseIsCalled);
				};
				const string streamAdapterReadBytesIsCalled = "ReadBytes is called";
				var streamAdapter = new SStreamAdapter(new MemoryStream())
				{
					ReadBytesByteArrayInt32 = (array, len) =>
					{
						if (len == expectedLength)
							calls.Add(streamAdapterReadBytesIsCalled);
						return len;
					}
				};
				var accessor = GetCommandAccessor(target);
				accessor.Result = new CommandResultBaseMock();

				accessor.Deserialize(streamAdapter);

				Assert.AreEqual(expectedStatus, target.Result.Status);
				CollectionAssert.AreEqual(calls, new[] { streamAdapterReadBytesIsCalled, validateResponseIsCalled, deserializeResponseIsCalled });
			}
		}

		#region Helper methods
		private CommandWithResultBase_Accessor<TResult> GetCommandAccessor<TResult>(CommandWithResultBase<TResult> command)
			where TResult : CommandResultBase, new()
		{
			PrivateObject po = new PrivateObject(command);
			CommandWithResultBase_Accessor<TResult> accessor = new CommandWithResultBase_Accessor<TResult>(po);
			return accessor;
		}

		private SCommandWithResultBase<CommandResultBaseMock> CreateCommandWithResultBase(ConnectionBase connection)
		{
			var command = new SCommandWithResultBase<CommandResultBaseMock>(connection)
              	{
              		ValidateParameters01 = () => { }
              	};
			command.CallBase = true;
			return command;
		}
		#endregion
	}
}
