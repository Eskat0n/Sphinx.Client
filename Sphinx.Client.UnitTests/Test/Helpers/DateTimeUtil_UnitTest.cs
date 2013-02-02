using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sphinx.Client.Helpers;

namespace Sphinx.Client.UnitTests.Test.Helpers
{
    
    
    /// <summary>
    ///This is a test class for DateTimeHelperUnitTest and is intended
    ///to contain all DateTimeHelperUnitTest Unit Tests
    ///</summary>
    [TestClass]
    public class DateTimeUtilUnitTest
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
        ///A test for ConvertToUnixTimestamp
        ///</summary>
        [TestMethod]
        public void ConvertToUnixTimestampTest()
        {
            // valid value
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 59, DateTimeKind.Utc); 
            int expected = 59; 
            int actual = DateTimeHelper.ConvertToUnixTimestamp(dateTime);
            Assert.AreEqual(expected, actual);

            // invalid value 1 - before UNIX epoch
            dateTime = new DateTime(1969, 12, 31, 23, 59, 59, DateTimeKind.Utc); 
            try
            {
                DateTimeHelper.ConvertToUnixTimestamp(dateTime);
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }

            // invalid value 2 - signed int overflow
            dateTime = new DateTime(2038, 1, 19, 3, 14, 8, 0, DateTimeKind.Utc); 
            try
            {
                DateTimeHelper.ConvertToUnixTimestamp(dateTime);
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }

        }

        /// <summary>
        ///A test for ConvertFromUnixTimestamp
        ///</summary>
        [TestMethod]
        public void ConvertFromUnixTimestampTest()
        {
            // simple valid value
            int timestamp = 1234567890;
            DateTime expected = new DateTime(2009, 2, 13, 23, 31, 30, DateTimeKind.Utc).ToLocalTime(); 
            DateTime actual = DateTimeHelper.ConvertFromUnixTimestamp(timestamp);
            Assert.AreEqual(expected, actual);
            // valid lower border value
            timestamp = 0;
            expected = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            actual = DateTimeHelper.ConvertFromUnixTimestamp(timestamp);
            Assert.AreEqual(expected, actual);
            // valid upper border value
            timestamp = 2147483647;
            expected = new DateTime(2038, 1, 19, 3, 14, 7, 0, DateTimeKind.Utc).ToLocalTime();
            actual = DateTimeHelper.ConvertFromUnixTimestamp(timestamp);
            Assert.AreEqual(expected, actual);
            // invalid value
            timestamp = -1;
            try
            {
                DateTimeHelper.ConvertFromUnixTimestamp(timestamp);
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }
    }
}
