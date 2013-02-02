using Sphinx.Client.Commands.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Sphinx.Client.UnitTests.Test.Commands.Collections
{
    
    
    /// <summary>
    ///This is a test class for IndexListWithWildcardUnitTest and is intended
    ///to contain all IndexListWithWildcardUnitTest Unit Tests
    ///</summary>
    [TestClass]
    public class IndexListWithWildcardUnitTest
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
        ///A test for ToString
        ///</summary>
        [TestMethod]
        public void ToStringTest()
        {
            IndexListWithWildcard target = new IndexListWithWildcard();
            // empty list
            string expected = "*";
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
            // 1 item
            target.Add("test1");
            expected = "test1";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            // 2 items
            target.Add("test2");
            expected = "test1,test2";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
            // new item with wildcard
            target.Add("*");
            expected = "*";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
