using Sphinx.Client.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Sphinx.Client.UnitTests.Test.Helpers
{
    
    
    /// <summary>
    ///This is a test class for CollectionsHelperUnitTest and is intended
    ///to contain all CollectionsHelperUnitTest Unit Tests
    ///</summary>
    [TestClass]
    public class CollectionUtilUnitTest
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
        ///A test for UnionDictionaries
        ///</summary>
        [TestMethod]
        public void UnionDictionariesTest()
        {
            IDictionary<int, string> target = new Dictionary<int, string>();
            IDictionary<int, string> source = new Dictionary<int, string>();
            // simple add
            target.Add(1, "one");
            source.Add(2, "two");
            CollectionUtil.UnionDictionaries(target, source);
            Assert.IsTrue(target.ContainsKey(2));
            Assert.IsTrue(target.Contains(new KeyValuePair<int,string>(2, "two")));
            Assert.AreEqual(2, target.Count);

            // skip existing
            source.Add(3, "three");
            CollectionUtil.UnionDictionaries(target, source);
            Assert.AreEqual(3, target.Count);

            // replace
            source[3] = "new three";
            CollectionUtil.UnionDictionaries(target, source);
            Assert.AreEqual("new three", target[3]);

        }

        /// <summary>
        ///A test for UnionCollections
        ///</summary>
        [TestMethod]
        public void UnionCollectionsTest()
        {
            ICollection<int> target = new List<int>();
            ICollection<int> source = new List<int>(); 
            // simple add
            target.Add(1);
            source.Add(2);
            CollectionUtil.UnionCollections(target, source);
            Assert.IsTrue(target.Contains(1));
            Assert.AreEqual(2, target.Count);

            // skip existing
            source.Add(3);
            CollectionUtil.UnionCollections(target, source);
            Assert.AreEqual(3, target.Count);
        }

    }
}
