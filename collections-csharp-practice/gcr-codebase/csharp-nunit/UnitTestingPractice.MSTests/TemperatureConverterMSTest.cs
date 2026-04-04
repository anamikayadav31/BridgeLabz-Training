using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingPractice;

namespace UnitTestingPractice.MSTests
{
    [TestClass]
    public class TemperatureConverterMSTest
    {
        private TemperatureConverter converter = null!;

        [TestInitialize]
        public void Setup()
        {
            converter = new TemperatureConverter();
        }

        [TestMethod]
        public void CelsiusToFahrenheit_ZeroCelsius_Returns32()
        {
            double result = converter.CelsiusToFahrenheit(0);
            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void CelsiusToFahrenheit_100Celsius_Returns212()
        {
            double result = converter.CelsiusToFahrenheit(100);
            Assert.AreEqual(212, result);
        }

        [TestMethod]
        public void FahrenheitToCelsius_32Fahrenheit_ReturnsZero()
        {
            double result = converter.FahrenheitToCelsius(32);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void FahrenheitToCelsius_212Fahrenheit_Returns100()
        {
            double result = converter.FahrenheitToCelsius(212);
            Assert.AreEqual(100, result);
        }
    }
}
