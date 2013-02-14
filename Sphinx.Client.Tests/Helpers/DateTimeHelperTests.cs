namespace Sphinx.Client.Tests.Helpers
{
    using System;
    using Client.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class DateTimeHelperTests
    {
        [Test]
        public void ConvertToUnixTimestampValidate()
        {
            //2013-01-25 12:54:33.000
            var dateTime = new DateTime(2013, 1, 25, 12, 54, 33);
            var timestamp = DateTimeHelper.ConvertToUnixTimestamp(dateTime);

            Assert.AreEqual(1359118473, timestamp);
        }
    }
}