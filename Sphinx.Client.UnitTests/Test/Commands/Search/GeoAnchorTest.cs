using System.Collections;
using Sphinx.Client.Commands.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.IO;
using Sphinx.Client.UnitTests.Mock.IO;

namespace Sphinx.Client.UnitTests.Test.Commands.Search
{
    
    
    /// <summary>
    ///This is a test class for GeoAnchor_UnitTest and is intended
    ///to contain all GeoAnchor_UnitTest Unit Tests
    ///</summary>
	[TestClass()]
	public class GeoAnchor_UnitTest
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
		///A test for GeoAnchor Constructor
		///</summary>
		[TestMethod()]
		public void GeoAnchorConstructorTest1()
		{
			GeoAnchor target = new GeoAnchor();
		}

		/// <summary>
		///A test for GeoAnchor Constructor
		///</summary>
		[TestMethod()]
		public void GeoAnchorConstructorTest()
		{
			string latitudeAttr = string.Empty; 
			float latitudeVal = 0F; 
			string longitudeAttr = string.Empty; 
			float longitudeVal = 0F; 
			GeoAnchor target = new GeoAnchor(latitudeAttr, latitudeVal, longitudeAttr, longitudeVal);
			Assert.AreEqual(latitudeAttr, target.LatitudeAttributeName);
			Assert.AreEqual(latitudeVal, target.LatitudeValue);
			Assert.AreEqual(longitudeAttr, target.LongitudeAttributeName);
			Assert.AreEqual(longitudeVal, target.LongitudeValue);
		}
		/// <summary>
		///A test for LongitudeValue
		///</summary>
		[TestMethod()]
		public void LongitudeValueTest()
		{
			GeoAnchor target = new GeoAnchor(); 
			float expected = 1F; 
			target.LongitudeValue = expected;
			float actual = target.LongitudeValue;
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for LongitudeAttributeName
		///</summary>
		[TestMethod()]
		public void LongitudeAttributeNameTest()
		{
			GeoAnchor target = new GeoAnchor(); 
			string expected = string.Empty; 
			target.LongitudeAttributeName = expected;
			string actual = target.LongitudeAttributeName;
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for LatitudeValue
		///</summary>
		[TestMethod()]
		public void LatitudeValueTest()
		{
			GeoAnchor target = new GeoAnchor(); 
			float expected = 1F; 
			target.LatitudeValue = expected;
			float actual = target.LatitudeValue;
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for LatitudeAttributeName
		///</summary>
		[TestMethod()]
		public void LatitudeAttributeNameTest()
		{
			GeoAnchor target = new GeoAnchor(); 
			string expected = string.Empty; 
			target.LatitudeAttributeName = expected;
			string actual = target.LatitudeAttributeName;
			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		///A test for IsNotEmpty
		///</summary>
		[TestMethod()]
		[DeploymentItem("Sphinx.Client.dll")]
		public void IsNotEmptyTest()
		{
			GeoAnchor target = new GeoAnchor();
			PrivateObject po = new PrivateObject(target);
			GeoAnchor_Accessor targetAccessor = new GeoAnchor_Accessor(po);

			Assert.IsFalse(targetAccessor.IsNotEmpty);
			target.LatitudeAttributeName = "test";
			Assert.IsTrue(targetAccessor.IsNotEmpty);
		}

		/// <summary>
		///A test for Serialize
		///</summary>
		[TestMethod()]
		public void SerializeTest()
		{
			GeoAnchor target = new GeoAnchor(); 
			ArrayList list = new ArrayList();
			ArrayListWriterMock writer = new ArrayListWriterMock(list);

			target.Serialize(writer);
			CollectionAssert.AreEqual(list, new [] { false });

			writer.Reset();

			target.LatitudeAttributeName = "test";
			target.Serialize(writer);
			CollectionAssert.AreEqual(list, new object[] { true, target.LatitudeAttributeName, target.LongitudeAttributeName, target.LatitudeValue, target.LongitudeValue });
		}


	}
}
