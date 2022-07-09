using NUnit.Framework;
using System;
using weborder_reader;

namespace weborder_reader_unittest
{
    [TestFixture]
    public class UiResultTests
    {
        private UiResult uiResult;

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2012, 5, 19, "19. May. 2012")]
        [TestCase(2012, 5, 09, "09. May. 2012")]
        public void DateFormat(int year, int month, int day, string expectedDateString)
        {
            DateTime dateTime = new DateTime(year, month, day);
            uiResult = new UiResult(1, "C", dateTime, 11, 12);
            Assert.That(uiResult.Date, Is.EqualTo(expectedDateString), "Unexpected date");
        }

        [TestCase(400, "400,000")]
        [TestCase(400.15, "400,150")]
        [TestCase(400.158, "400,158")]
        [TestCase(400000.158, "400.000,158")]
        public void PriceAverageFormat(decimal priceAverage, string expectedString)
        {
            DateTime dateTime = new DateTime(2018, 11, 20);
            uiResult = new UiResult(1, "C", dateTime, priceAverage, 12);
            Assert.That(uiResult.PriceAverage, Is.EqualTo(expectedString), "Unexpected string for decimal");
        }

        [TestCase(400, "400,000")]
        [TestCase(400.15, "400,150")]
        [TestCase(400.158, "400,158")]
        [TestCase(400000.158, "400.000,158")]
        public void TotalFormat(decimal total, string expectedString)
        {
            DateTime dateTime = new DateTime(2018, 11, 20);
            uiResult = new UiResult(1, "C", dateTime, 11, total);
            Assert.That(uiResult.Total, Is.EqualTo(expectedString), "Unexpected string for decimal");
        }
    }
}