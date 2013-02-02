using System.Collections;
using Sphinx.Client.Commands.BuildExcerpts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using Sphinx.Client.UnitTests.Mock.IO;

namespace Sphinx.Client.UnitTests.Test.Commands.BuildExcerpts
{
    
    /// <summary>
    /// This is a test class for BuildExcerptsCommandResult and is intended
    /// to contain all BuildExcerptsCommandResult Unit Tests
    ///</summary>
	[TestClass]
	public class BuildExcerptsCommandResult_UnitTest
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
		///A test for BuildExcerptsCommandResult Constructor
		///</summary>
		[TestMethod]
		public void BuildExcerptsCommandResultConstructorTest()
		{
			new BuildExcerptsCommandResult();
		}

		/// <summary>
		///A test for Excerpts
		///</summary>
		[TestMethod]
		public void ExcerptsTest()
		{
			BuildExcerptsCommandResult target = new BuildExcerptsCommandResult(); 
			Assert.IsNotNull(target.Excerpts);
			Assert.IsInstanceOfType(target.Excerpts, typeof(ReadOnlyCollection<string>));
		}

		/// <summary>
		///A test for Deserialize
		///</summary>
		[TestMethod]
		public void DeserializeTest()
		{
			BuildExcerptsCommandResult target = new BuildExcerptsCommandResult();
			ArrayList list = new ArrayList();
			ArrayListReaderMock reader = new ArrayListReaderMock(list);
			list.Add("test1");
			list.Add("test2");

			target.Deserialize(reader, list.Count);

			CollectionAssert.AreEqual(target.Excerpts, list);
		}


	}
}
