#region Copyright
// 
// Copyright (c) 2009-2011, Rustam Babadjanov <theplacefordev [at] gmail [dot] com>
// 
// This program is free software; you can redistribute it and/or modify it
// under the terms of the GNU Lesser General Public License version 2.1 as published
// by the Free Software Foundation.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
#endregion
#region Usings

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Sphinx.Client.Resources;

#endregion

namespace Sphinx.Client.Helpers
{
    /// <summary>
    /// Argument asserts checker
    /// </summary>
    internal static class ArgumentAssert
    {
        #region IsNotNull
        /// <exception cref="System.ArgumentNullException" />
        public static void IsNotNull<T>(T argumentValue, string argumentName) where T : class
        {
            if (argumentValue == null)
                throw new ArgumentNullException(argumentName, Messages.Exception_ArgumentIsNull);
        }
        
        #endregion

        #region IsNotEmpty
        /// <exception cref="System.ArgumentException"/>
        public static void IsNotEmpty<T>(T argumentValue, string argumentName) where T : struct
        {
            if (argumentValue.Equals(default(T)))
                throw new ArgumentException(Messages.Exception_ArgumentIsEmpty, argumentName);
        }

        /// <exception cref="System.ArgumentException"/>
        public static void IsNotEmpty(string argumentValue, string argumentName)
        {
            if (String.IsNullOrEmpty(argumentValue) || argumentValue.Trim().Length == 0)
                throw new ArgumentException(Messages.Exception_ArgumentIsEmpty, argumentName);
        }

        /// <exception cref="System.ArgumentException"/>
        public static void IsNotEmpty<T>(T[] argumentValue, string argumentName)
        {
            if (argumentValue == null || argumentValue.Length == 0)
                throw new ArgumentException(Messages.Exception_ArgumentIsEmpty, argumentName);
        }

        /// <exception cref="System.ArgumentException"/>
        public static void IsNotEmpty(ICollection argumentValue, string argumentName)
        {
            if (argumentValue == null || argumentValue.Count == 0)
                throw new ArgumentException(Messages.Exception_ArgumentIsEmpty, argumentName);
        }

        /// <exception cref="System.ArgumentException"/>
        public static void IsNotEmpty<T>(ICollection<T> argumentValue, string argumentName)
        {
            if (argumentValue == null || argumentValue.Count == 0)
				throw new ArgumentException(Messages.Exception_ArgumentCollectionIsEmpty, argumentName);
        }

		/// <exception cref="System.ArgumentException"/>
		public static void IsNotEmpty<TKey, TValue>(IDictionary<TKey, TValue> argumentValue, string argumentName)
        {
            if (argumentValue == null || argumentValue.Count == 0)
				throw new ArgumentException(Messages.Exception_ArgumentDictionaryIsEmpty, argumentName);
        }
        #endregion

        #region IsGreaterOrEqual
        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsGreaterOrEqual(double argumentValue, double borderValue, string argumentName)
        {
            if (argumentValue < borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeGreaterOrEqual, borderValue));
        }

        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsGreaterOrEqual(long argumentValue, long borderValue, string argumentName)
        {
            if (argumentValue < borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeGreaterOrEqual, borderValue));
        }

        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsGreaterOrEqual(DateTime argumentValue, DateTime borderValue, string argumentName)
        {
            if (argumentValue < borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeGreaterOrEqual, borderValue));
        }

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public static void IsGreaterOrEqual(string argumentValue, int length, string argumentName)
		{
			if (argumentValue.Length < length)
				throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeGreaterOrEqual, length));
		}

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public static void IsGreaterOrEqual<T>(ICollection<T> argumentValue, int borderValue, string argumentName)
		{
			if (argumentValue.Count < borderValue)
				throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeGreaterOrEqual, borderValue));
		}
        #endregion

        #region IsGreaterThan
        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsGreaterThan(double argumentValue, double borderValue, string argumentName)
        {
            if (argumentValue <= borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeGreaterThan, borderValue));
        }

        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsGreaterThan(long argumentValue, long borderValue, string argumentName)
        {
            if (argumentValue <= borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeGreaterThan, borderValue));
        }

        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsGreaterThan(DateTime argumentValue, DateTime borderValue, string argumentName)
        {
            if (argumentValue <= borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeGreaterThan, borderValue));
        }

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public static void IsGreaterThan(string argumentValue, int length, string argumentName)
		{
			if (argumentValue.Length <= length)
				throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeGreaterThan, length));
		}

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public static void IsGreaterThan<T>(ICollection<T> argumentValue, int borderValue, string argumentName)
		{
			if (argumentValue.Count <= borderValue)
				throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeGreaterThan, borderValue));
		}

        #endregion

        #region IsLessOrEqual
        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsLessOrEqual(double argumentValue, double borderValue, string argumentName)
        {
            if (argumentValue > borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeLessOrEqual, borderValue));
        }

        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsLessOrEqual(long argumentValue, long borderValue, string argumentName)
        {
            if (argumentValue > borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeLessOrEqual, borderValue));
        }

        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsLessOrEqual(DateTime argumentValue, DateTime borderValue, string argumentName)
        {
            if (argumentValue > borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeLessOrEqual, borderValue));
        }

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public static void IsLessOrEqual(string argumentValue, int length, string argumentName)
		{
			if (argumentValue.Length > length)
				throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeLessOrEqual, length));
		}

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public static void IsLessOrEqual<T>(ICollection<T> argumentValue, int borderValue, string argumentName)
		{
			if (argumentValue.Count > borderValue)
				throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeLessOrEqual, borderValue));
		}

        #endregion

        #region IsLessThan
        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsLessThan(double argumentValue, double borderValue, string argumentName)
        {
            if (argumentValue >= borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeLessThan, borderValue));
        }

        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsLessThan(long argumentValue, long borderValue, string argumentName)
        {
            if (argumentValue >= borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeLessThan, borderValue));
        }

        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsLessThan(DateTime argumentValue, DateTime borderValue, string argumentName)
        {
            if (argumentValue >= borderValue)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeLessThan, borderValue));
        }

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public static void IsLessThan(string argumentValue, int length, string argumentName)
		{
			if (argumentValue.Length >= length)
				throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeLessThan, length));
		}

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public static void IsLessThan<T>(ICollection<T> argumentValue, int borderValue, string argumentName)
		{
			if (argumentValue.Count >= borderValue)
				throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeLessThan, borderValue));
		}

        #endregion

        #region IsInRange
        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsInRange(double argumentValue, double min, double max, string argumentName)
        {
            if (argumentValue < min || argumentValue > max)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeInRange, min, max));
        }

        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsInRange(long argumentValue, long min, long max, string argumentName)
        {
            if (argumentValue < min || argumentValue > max)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeInRange, min, max));
        }

        /// <exception cref="System.ArgumentOutOfRangeException"/>
        public static void IsInRange(DateTime argumentValue, DateTime min, DateTime max, string argumentName)
        {
            if (argumentValue < min || argumentValue > max)
                throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeInRange, min, max));
        }

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public static void IsLessThan(string argumentValue, int min, int max, string argumentName)
		{
			if (argumentValue.Length < min || argumentValue.Length > max)
				throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeInRange, min, max));
		}

		/// <exception cref="System.ArgumentOutOfRangeException"/>
		public static void IsInRange<T>(ICollection<T> argumentValue, int min, int max, string argumentName)
		{
			if (argumentValue.Count < min || argumentValue.Count > max)
				throw new ArgumentOutOfRangeException(argumentName, String.Format(Messages.Exception_ArgumentMustBeInRange, min, max));
		}

	    #endregion    

        #region Enums
        /// <exception cref="System.ArgumentException" />
        public static void IsDefinedInEnum(Type enumType, object value, string argumentName)
        {
            if (!Enum.IsDefined(enumType, value))
				throw new InvalidEnumArgumentException(argumentName, Convert.ToInt32(value), enumType);
        }
        
        #endregion

        #region Boolean
		/// <exception cref="System.ArgumentException" />
        public static void IsTrue(bool expression, string message)
        {
            if (!expression)
                throw new ArgumentException(message);
        }

        /// <exception cref="System.ArgumentException" />
        public static void IsFalse(bool expression, string message)
        {
            if (expression)
                throw new ArgumentException(message);
        }
 
	    #endregion    
    }
}
