using System.Collections;
using Sphinx.Client.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Commands.Moles;
using Sphinx.Client.IO;
using System.Collections.ObjectModel;
using Sphinx.Client.UnitTests.Mock.IO;

namespace Sphinx.Client.UnitTests.Test.Commands
{
    
	[TestClass]
	public class CommandResultBase_UnitTest
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
		public void WarningsTest()
		{
			CommandResultBase target = CreateCommandResultBase(); 

			Assert.IsNotNull(target.Warnings);
			Assert.IsInstanceOfType(target.Warnings, typeof(ReadOnlyCollection<string>));
		}

		[TestMethod]
		public void StatusTest()
		{
			CommandResultBase target = CreateCommandResultBase();

			target.Status = CommandStatus.Error;

			Assert.AreEqual(target.Status, CommandStatus.Error);
		}

		[TestMethod]
		public void SuccessTest()
		{
			CommandResultBase target = CreateCommandResultBase();
			
			target.Status = CommandStatus.Ok;
			Assert.IsTrue(target.Success);
			
			target.Status = CommandStatus.Warning;
			Assert.IsTrue(target.Success);

			target.Status = CommandStatus.Error;
			Assert.IsFalse(target.Success);
		}

		[TestMethod]
		public void DeserializeWarningTest()
		{
			CommandResultBase target = CreateCommandResultBase(); 
			ArrayList values = new ArrayList();
			IBinaryReader reader = new ArrayListReaderMock(values);
			values.Add("test warning text");

			target.DeserializeWarning(reader);

			CollectionAssert.AreEqual(target.Warnings, values);
		}

		private CommandResultBase CreateCommandResultBase()
		{
			SCommandResultBase target = new SCommandResultBase();
			target.CallBase = true;
			return target;
		}

	}
}
