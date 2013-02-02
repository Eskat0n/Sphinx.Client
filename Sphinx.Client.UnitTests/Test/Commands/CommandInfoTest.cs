using System.Collections;
using System.Collections.Generic;
using Sphinx.Client.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.IO;
using Sphinx.Client.UnitTests.Mock.IO;

namespace Sphinx.Client.UnitTests.Test.Commands
{

	[TestClass]
	public class CommandInfo_UnitTest
	{
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

		[TestMethod]
		public void CommandInfoConstructorTest()
		{
			ServerCommand id = ServerCommand.Keywords;
			short version = 1; 
			CommandInfo target = new CommandInfo(id, version);
			Assert.AreEqual(version, target.Version);
			Assert.AreEqual(id, target.Id);
		}

		[TestMethod]
		public void SerializeTest()
		{
			ServerCommand id = ServerCommand.Excerpt; 
			short version = 2; 
			CommandInfo target = new CommandInfo(id, version);
			ArrayList values = new ArrayList();
			IBinaryWriter writer = new ArrayListWriterMock(values);
			List<short> expected = new List<short> { (short)id, version };
			
			target.Serialize(writer);

			CollectionAssert.AreEqual(expected, values);
		}

	}
}
