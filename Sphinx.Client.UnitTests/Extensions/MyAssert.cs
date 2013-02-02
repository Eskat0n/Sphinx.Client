using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sphinx.Client.UnitTests.Test.Extensions
{
    public static class MyAssert
    {
        public static void AreEqual(byte[] expected, byte[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            for (byte i = 0; i < actual.Length; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
