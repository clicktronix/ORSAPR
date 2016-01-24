using System;

namespace GasketModelGUI
{
    /// <summary>
    /// Класс хранит значение и ограничения
    /// </summary>
    public class GasketParameterValue
    {
        #region Fields

        /// <summary>
        /// Значение
        /// </summary>
        private double _value;

        /// <summary>
        /// Минимально возможное значение
        /// </summary>
        private double _min;

        /// <summary>
        /// Максимально возможное значение
        /// </summary>
        private double _max;

        #endregion

        #region Methods
        /// <summary>
        /// Событие об изменении параметра
        /// </summary>
        public event EventHandler ParameterChanged;

        /// <summary>
        /// Сеттер и геттер значения
        /// </summary>
        public double Value
        {
            get { return _value; }
            set
            {
                if (Equals(_value, value) & (value>0))
                    return;
                _value = value;
                Validate();
                ParameterChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        
        /// <summary>
        /// Сеттер и геттер минимального значения
        /// </summary>
        public double Min
        {
            get { return _min; }
            set
            {
                if (Equals(_min, value))
                    return;
                _min = value;
                Validate();
                ParameterChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Сеттер и геттер максимального значения
        /// </summary>
        public double Max
        {
            get { return _max; }
            set
            {
                if (Equals(_max, value))
                    return;
                _max = value;
                Validate();
                ParameterChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Конструктор параметра
        /// </summary>
        /// <param name="value">Начальное значение</param>
        /// <param name="min">Начальное минимальное значение</param>
        /// <param name="max">Начальное максимальное значение</param>
        public GasketParameterValue(double value, double min, double max)
        {
            _value = value;
            _min = min;
            _max = max;
            Validate();
            if (value >= Min && value <= Max)
            {
                _value = value;
            }
            else
            {
                throw new ValueException();
            }
        }

        /// <summary>
        /// Проверка на выход значения за допустимый диапазон
        /// </summary>
        public void Validate()
        {
            if (Value >= Max)
            {
                _value = Max;
            }
            if (Value <= Min)
            {
                _value = Min;
            }
        }
        #endregion
    }
}
