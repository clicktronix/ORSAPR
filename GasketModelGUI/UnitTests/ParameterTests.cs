using System;
using NUnit.Framework;
using GasketModelGUI;

namespace UnitTests
{
    [TestFixture, Description("Класс тестирования параметров")]
    internal class ParameterTests
    {
        /// <summary>
        /// Объект, который будем тестировать
        /// </summary>
        private GasketParameterValue _parameter = new GasketParameterValue(5.0, 0.0, 10.0);

        /// <summary>
        /// Невалидное значение.
        /// </summary>
        double TestValue = 11.0;

        [Test, Description("Позитивный тест валидного значения")]
        public void SetCorrectValue()
        {
            Assert.DoesNotThrow(() => { _parameter.Value = 5.0; });
        }

        [Test, Description("Негативный тест для невалидного значения, находящегося за границами.")]
        public void SetIncorrectValue()
        {
            
            Assert.Throws<ValueException>(() => { _parameter.Value = TestValue; });
        }
        
        [Test, Description("Тест того, что невалидное значение не сохраняется")]
        public void ValueIsNotSaved()
        {
            try
            {
                _parameter.Value = TestValue;
            }
            catch (Exception)
            {
                Assert.AreNotEqual(_parameter.Value, TestValue);
            }
        }
    }
}
