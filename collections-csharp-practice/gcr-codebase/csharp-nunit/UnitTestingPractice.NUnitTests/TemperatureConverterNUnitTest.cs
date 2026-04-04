using NUnit.Framework;
using UnitTestingPractice;

namespace UnitTestingPractice.NUnitTests
{
    [TestFixture]
    public class TemperatureConverterNUnitTest
    {
        private TemperatureConverter converter = null!;

        [SetUp]
        public void Setup()
        {
            converter = new TemperatureConverter();
        }

        [Test]
        public void CelsiusToFahrenheit_ZeroCelsius_Returns32()
        {
            Assert.That(converter.CelsiusToFahrenheit(0), Is.EqualTo(32));
        }

        [Test]
        public void CelsiusToFahrenheit_100Celsius_Returns212()
        {
            Assert.That(converter.CelsiusToFahrenheit(100), Is.EqualTo(212));
        }

        [Test]
        public void FahrenheitToCelsius_32Fahrenheit_ReturnsZero()
        {
            Assert.That(converter.FahrenheitToCelsius(32), Is.EqualTo(0));
        }

        [Test]
        public void FahrenheitToCelsius_212Fahrenheit_Returns100()
        {
            Assert.That(converter.FahrenheitToCelsius(212), Is.EqualTo(100));
        }
    }
}
