using System;
using GasketModelGUI;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class ParametersTests
    {
        [Test]

        [TestCase(15.0, TestName = "Вводимое значение параметра равно 15")]
        public void NotPositiveValueTest(double testValue)
        {
            Assert.Throws<ValueException>(() => new GasketParameterValue(testValue, 0.0, 10.0));
        }

        [TestCase(5, TestName = "Вводимое значение параметра равно 5")]
        public void PositiveValueTest(double testValue)
        {
            Assert.DoesNotThrow(() => new GasketParameterValue(testValue, 0.0, 10.0));
        }

        [TestCase(double.MaxValue, TestName = "Максимальное значение параметра")]
        public void MaxValueTest(double testValue)
        {
            Assert.Throws<ValueException>(() => new GasketParameterValue(testValue, 0.0, 10.0));
        }
        
        [TestCase(double.MaxValue, double.MaxValue, TestName = "Максимальные значения пределов параметра")]
        public void MaxLimitTest(double testLimit1, double testLimit2)
        {
            Assert.Throws<ValueException>(() => new GasketParameterValue(15, testLimit1, testLimit2));
        }

        [TestCase(double.MinValue, double.MinValue, TestName = "Минимальные значения пределов параметра")]
        public void MinLimitTest(double testLimit1, double testLimit2)
        {
            Assert.Throws<ValueException>(() => new GasketParameterValue(15, testLimit1, testLimit2));
        }

        [TestCase(double.MinValue, TestName = "Минимальное значение параметра")]
        public void MinValueTest(double testValue)
        {
            Assert.Throws<ValueException>(() => new GasketParameterValue(testValue, 0.0, 10.0));
        }

        [TestCase(5, TestName = "Тест того, что невалидное значение не сохраняется")]
        public void ValueIsNotSaved(double testValue)
        {
            GasketParameterValue _parameter = new GasketParameterValue(testValue, 0.0, 10.0);
            try
            {
                _parameter.Value = testValue;
            }
            catch (Exception)
            {
                Assert.AreNotEqual(_parameter.Value, testValue);
            }
        }
    }
}
