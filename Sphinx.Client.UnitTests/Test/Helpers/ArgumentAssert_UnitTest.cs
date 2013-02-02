using System.Collections.ObjectModel;
using System.ComponentModel;
using Sphinx.Client.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Sphinx.Client.UnitTests.Test.Helpers
{
    
    
    /// <summary>
    ///This is a test class for ArgumentAssert and is intended
    ///to contain all ArgumentAssert Unit Tests
    ///</summary>
    [TestClass]
    public class ArgumentAssertUnitTest
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

        #region Tests
		/// <summary>
        ///A test for IsTrue
        ///</summary>
        [TestMethod]
        public void IsTrueTest()
        {
            string message = string.Empty;
            try
            {
                ArgumentAssert.IsTrue(true, message);
            }
            catch(Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }

            try
            {
                ArgumentAssert.IsTrue(false, message);
                Assert.Fail("Assert method must throw ArgumentException exception");
            }
            catch(ArgumentException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsFalse
        ///</summary>
        [TestMethod]
        public void IsFalseTest()
        {
            string message = string.Empty;
            try
            {
                ArgumentAssert.IsFalse(false, message);
            }
            catch
            {
                Assert.Fail("Assert method must throw no exceptions");
            }

            try
            {
                ArgumentAssert.IsFalse(true, message);
                Assert.Fail("Assert method must throw ArgumentException exception");
            }
            catch (ArgumentException)
            {
                // test passed
            }
        }


        /// <summary>
        ///A test for IsNotNull
        ///</summary>
        public void IsNotNullTestHelper<T>() where T : class, new()
        {
            string argumentName = string.Empty;

            T argumentValue = new T(); 
            try
            {
                ArgumentAssert.IsNotNull<T>(argumentValue, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }

            argumentValue = null;
            try
            {
                ArgumentAssert.IsNotNull<T>(argumentValue, argumentName);
                Assert.Fail("Assert method must throw ArgumentException exception.");
            }
            catch (ArgumentException)
            {
                // test passed
            }
        }

        [TestMethod]
        public void IsNotNullTest()
        {
            IsNotNullTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for IsNotEmpty with string argument
        ///</summary>
        [TestMethod]
        public void IsNotEmptyTestString()
        {
            string argumentName = string.Empty;
            string argumentValue = "test";
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            } 
            
            argumentValue = string.Empty;
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
                Assert.Fail("Assert method must throw ArgumentException exception.");
            }
            catch (ArgumentException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsNotEmpty with generic <T> param.
        ///</summary>
        public void IsNotEmptyTestGerericHelper<T>() where T : class, new()
        {
            ICollection<T> argumentValue = new Collection<T>(); 
            argumentValue.Add(new T());
            string argumentName = string.Empty; 
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }

            argumentValue = null;
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
                Assert.Fail("Assert method must throw ArgumentException exception.");
            }
            catch (ArgumentException)
            {
                // test passed
            }
        }

        [TestMethod]
        public void IsNotEmptyTestGeneric()
        {
            IsNotEmptyTestGerericHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for IsNotEmpty with generic array param.
        ///</summary>
        public void IsNotEmptyTestGenericArrayHelper<T>() where T: class, new()
        {
            T[] argumentValue = new T[] { new T()  };
            string argumentName = string.Empty;
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }

            argumentValue = null;
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
                Assert.Fail("Assert method must throw ArgumentException exception.");
            }
            catch (ArgumentException)
            {
                // test passed
            }
        }

        [TestMethod]
        public void IsNotEmptyTestGenericArray()
        {
            IsNotEmptyTestGenericArrayHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for IsNotEmpty with generic dictionary param.
        ///</summary>
        public void IsNotEmptyTestGenericDictionaryHelper<TKey, TValue>() where TKey: class, new() where TValue: class, new()
        {
            IDictionary<TKey, TValue> argumentValue = new Dictionary<TKey, TValue>();
            argumentValue.Add(new TKey(), new TValue());
            string argumentName = string.Empty; 
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }

            argumentValue = null;
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
                Assert.Fail("Assert method must throw ArgumentException exception.");
            }
            catch (ArgumentException)
            {
                // test passed
            }
        }

        [TestMethod]
        public void IsNotEmptyTestGenericDictionary()
        {
            IsNotEmptyTestGenericDictionaryHelper<GenericParameterHelper, GenericParameterHelper>();
        }

        /// <summary>
        ///A test for IsNotEmpty with ICollection generic param
        ///</summary>
        [TestMethod]
        public void IsNotEmptyTestCollectionGeneric()
        {
            ICollection argumentValue = new byte[] { 1, 2, 3 };
            string argumentName = string.Empty;
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }

            argumentValue = null;
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
                Assert.Fail("Assert method must throw ArgumentException exception.");
            }
            catch (ArgumentException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsNotEmpty
        ///</summary>
        [TestMethod]
        public void IsNotEmptyTestIn32()
        {
            int argumentValue = 1;
            string argumentName = string.Empty;
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }

            argumentValue = 0;
            try
            {
                ArgumentAssert.IsNotEmpty(argumentValue, argumentName);
                Assert.Fail("Assert method must throw ArgumentException exception.");
            }
            catch (ArgumentException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsInRange with long arguments
        ///</summary>
        [TestMethod]
        public void IsInRangeTestInt64()
        {
            string argumentName = string.Empty;
            // close range
            long value = 0;
            try
            {
                ArgumentAssert.IsInRange(value, 0, 0, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // correct range
            value = 1;
            try
            {
                ArgumentAssert.IsInRange(value, 0, 2, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect range
            value = -1;
            try
            {
                ArgumentAssert.IsInRange(value, 0, -1, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test range
            }
            // out of range
            value = 0;
            try
            {
                ArgumentAssert.IsInRange(value, 1, 2, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsInRange with DateTime arguments
        ///</summary>
        [TestMethod]
        public void IsInRangeTestDateTime()
        {
            string argumentName = string.Empty;
            // close range
            DateTime value = new DateTime(1960, 12, 12, 0, 0, 0);
            try
            {
                ArgumentAssert.IsInRange(value, new DateTime(1960, 12, 12, 0, 0, 0), new DateTime(1960, 12, 12, 0, 0, 0), argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // correct range
            value = new DateTime(2007, 11, 19, 11, 22, 33);
            try
            {
                ArgumentAssert.IsInRange(value, new DateTime(2007, 11, 19, 11, 22, 32), new DateTime(2007, 11, 19, 11, 22, 34), argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect range
            value = new DateTime(2009, 05, 20, 1, 2, 3); 
            try
            {
                ArgumentAssert.IsInRange(value, new DateTime(1970, 12, 12, 0, 0, 0), new DateTime(1960, 12, 12, 0, 0, 0), argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test range
            }
            // out of range
            value = new DateTime(2003, 04, 24, 3, 2, 1);
            try
            {
                ArgumentAssert.IsInRange(value, new DateTime(1960, 12, 12, 0, 0, 0), new DateTime(1970, 12, 12, 0, 0, 0), argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsInRange with double argument type
        ///</summary>
        [TestMethod]
        public void IsInRangeTestDouble()
        {
            string argumentName = string.Empty;
            // close range
            double value = 0;
            try
            {
                ArgumentAssert.IsInRange(value, 0, 0, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // correct range
            value = 1;
            try
            {
                ArgumentAssert.IsInRange(value, 0, 2, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect range
            value = -1;
            try
            {
                ArgumentAssert.IsInRange(value, 0, -1, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test range
            }
            // out of range
            value = 0;
            try
            {
                ArgumentAssert.IsInRange(value, 1, 2, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsGreaterThan with long argument type
        ///</summary>
        [TestMethod]
        public void IsGreaterThanTestInt64()
        {
            string argumentName = string.Empty;
            // correct
            long value = 1;
            try
            {
                ArgumentAssert.IsGreaterThan(value, 0, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = 1;
            try
            {
                ArgumentAssert.IsGreaterThan(value, 2, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsGreaterThan with double argument
        ///</summary>
        [TestMethod]
        public void IsGreaterThanTestDouble()
        {
            string argumentName = string.Empty;
            // correct
            double value = 1;
            try
            {
                ArgumentAssert.IsGreaterThan(value, 0, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = 2;
            try
            {
                ArgumentAssert.IsGreaterThan(value, 3, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsGreaterThan with DateTime argument
        ///</summary>
        [TestMethod]
        public void IsGreaterThanTestDateTime()
        {
            string argumentName = string.Empty;
            // correct
            DateTime value = new DateTime(2000, 1, 1);
            try
            {
                ArgumentAssert.IsGreaterThan(value, new DateTime(1999, 1, 1), argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = new DateTime(2000, 1, 1);
            try
            {
                ArgumentAssert.IsGreaterThan(value, new DateTime(2001, 1, 1), argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsGreaterOrEqual with long argument type
        ///</summary>
        [TestMethod]
        public void IsGreaterOrEqualTestInt64()
        {
            string argumentName = string.Empty;
            // equal
            long value = 0;
            try
            {
                ArgumentAssert.IsGreaterOrEqual(value, 0, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // greater
            value = 1;
            try
            {
                ArgumentAssert.IsGreaterOrEqual(value, 0, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = 1;
            try
            {
                ArgumentAssert.IsGreaterOrEqual(value, 2, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsGreaterThan with double argument
        ///</summary>
        [TestMethod]
        public void IsGreaterOrEqualTestDouble()
        {
            string argumentName = string.Empty;
            // equal
            double value = 0;
            try
            {
                ArgumentAssert.IsGreaterOrEqual(value, 0, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // greater
            value = 1;
            try
            {
                ArgumentAssert.IsGreaterOrEqual(value, 0, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = 1;
            try
            {
                ArgumentAssert.IsGreaterOrEqual(value, 2, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsGreaterThan with DateTime argument
        ///</summary>
        [TestMethod]
        public void IsGreaterOrEqualTestDateTime()
        {
            string argumentName = string.Empty;
            // equal
            DateTime value = new DateTime(2000, 1, 1, 1, 1, 1);
            try
            {
                ArgumentAssert.IsGreaterOrEqual(value, new DateTime(2000, 1, 1, 1, 1, 1), argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // greater
            value = new DateTime(1900, 1, 1, 1, 1, 1);
            try
            {
                ArgumentAssert.IsGreaterOrEqual(value, new DateTime(1900, 1, 1, 1, 1, 0), argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = new DateTime(1950, 1, 1, 1, 1, 1);
            try
            {
                ArgumentAssert.IsGreaterOrEqual(value, new DateTime(1970, 1, 1, 1, 1, 1), argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsLessThan with long argument type
        ///</summary>
        [TestMethod]
        public void IsLessThanTestInt64()
        {
            string argumentName = string.Empty;
            // correct
            long value = 1;
            try
            {
                ArgumentAssert.IsLessThan(value, 2, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = 3;
            try
            {
                ArgumentAssert.IsLessThan(value, 2, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsLessThan with double argument
        ///</summary>
        [TestMethod]
        public void IsLessThanTestDouble()
        {
            string argumentName = string.Empty;
            // correct
            double value = 1;
            try
            {
                ArgumentAssert.IsLessThan(value, 2, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = 2;
            try
            {
                ArgumentAssert.IsLessThan(value, 1, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsLessThan with DateTime argument
        ///</summary>
        [TestMethod]
        public void IsLessThanTestDateTime()
        {
            string argumentName = string.Empty;
            // correct
            DateTime value = new DateTime(2009, 12, 31, 23, 59, 59);
            try
            {
                ArgumentAssert.IsLessThan(value, new DateTime(2010, 1, 1, 0, 0, 0), argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = new DateTime(1993, 6, 6, 6, 6, 6);
            try
            {
                ArgumentAssert.IsLessThan(value, new DateTime(1992, 6, 6, 6, 6, 6), argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsLessOrEqual with long argument type
        ///</summary>
        [TestMethod]
        public void IsLessOrEqualTestInt64()
        {
            string argumentName = string.Empty;
            // equal
            long value = 0;
            try
            {
                ArgumentAssert.IsLessOrEqual(value, 0, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // Less
            value = 0;
            try
            {
                ArgumentAssert.IsLessOrEqual(value, 1, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = 2;
            try
            {
                ArgumentAssert.IsLessOrEqual(value, 1, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsLessOrEqual with double argument
        ///</summary>
        [TestMethod]
        public void IsLessOrEqualTestDouble()
        {
            string argumentName = string.Empty;
            // equal
            double value = 0;
            try
            {
                ArgumentAssert.IsLessOrEqual(value, 0, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // Less
            value = 1;
            try
            {
                ArgumentAssert.IsLessOrEqual(value, 2, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = 2;
            try
            {
                ArgumentAssert.IsLessOrEqual(value, 1, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsLessOrEqual with DateTime argument
        ///</summary>
        [TestMethod]
        public void IsLessOrEqualTestDateTime()
        {
            string argumentName = string.Empty;
            // equal
            DateTime value = new DateTime(2012, 12, 12, 12, 12, 12);
            try
            {
                ArgumentAssert.IsLessOrEqual(value, new DateTime(2012, 12, 12, 12, 12, 12), argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // Less
            value = new DateTime(2011, 11, 11, 11, 11, 11);
            try
            {
                ArgumentAssert.IsLessOrEqual(value, new DateTime(2012, 12, 12, 12, 12, 12), argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = new DateTime(2011, 1, 1, 0, 0, 0);
            try
            {
                ArgumentAssert.IsLessOrEqual(value, new DateTime(2010, 1, 1, 0, 0, 0), argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
            catch (ArgumentOutOfRangeException)
            {
                // test passed
            }
        }

        /// <summary>
        ///A test for IsDefinedInEnum
        ///</summary>
        [TestMethod]
        public void IsDefinedInEnumTest()
        {
            string argumentName = string.Empty;
            Type enumType = typeof(DayOfWeek);
            object value = DayOfWeek.Friday; 
            try
            {
                ArgumentAssert.IsDefinedInEnum(enumType, value, argumentName);
            }
            catch (Exception ex)
            {
                Assert.Fail("Assert method must throw no exceptions.\n" + ex.Message);
            }
            // incorrect
            value = 128;
            try
            {
                ArgumentAssert.IsDefinedInEnum(enumType, value, argumentName);
                Assert.Fail("Assert method must throw ArgumentOutOfRangeException exception.");
            }
			catch (InvalidEnumArgumentException)
            {
                // test passed
            }

        }
 
	    #endregion
    }
}
