using System.Collections.Generic;
using System;

namespace GasketModelGUI
{
    /// <summary>
    /// Свойства модели
    /// </summary>
    public class GasketProperties
    {
        /// <summary>
        /// Словарь параметров 
        /// </summary>
        private readonly Dictionary<GasketPropertiesEnum, GasketParameterValue> _parameters;

        #region Methods

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public GasketProperties()
        {
            _parameters = new Dictionary<GasketPropertiesEnum, GasketParameterValue>
            {
                {GasketPropertiesEnum.RadiusStern, new GasketParameterValue(10.0, 5.0,  12.0)},
                {GasketPropertiesEnum.RadiusProw, new GasketParameterValue(7.0, 2.0, 11.0)},
                {GasketPropertiesEnum.RadiusEdges, new GasketParameterValue(5.0, 2.0, 7.0)},
                {GasketPropertiesEnum.AbaloneAround, new GasketParameterValue(13.0, 12.0, 20.0)},
                {GasketPropertiesEnum.CenterToTheEdge, new GasketParameterValue(10.0, 7.0, 12.0)},
                {GasketPropertiesEnum.BeforeShear, new GasketParameterValue(40.0, 35.0, 50.0)},
                {GasketPropertiesEnum.BetweenCentRad, new GasketParameterValue(20.0, 15.0, 35.0)},
                {GasketPropertiesEnum.GasketWidth, new GasketParameterValue(60.0, 55.0, 80.0)},
                {GasketPropertiesEnum.GasketHeight, new GasketParameterValue(10.0, 1.0, 25.0)},
                {GasketPropertiesEnum.GasketLenght, new GasketParameterValue(92.0, 80.0, 110.0)},
                {GasketPropertiesEnum.FromStartToCenterNose, new GasketParameterValue(80.0, 70.0, 90.0)},
                {GasketPropertiesEnum.DepthOfNotchInTheStern, new GasketParameterValue(20.0, 12.0, 35.0)}
            };
            foreach (var parameter in _parameters.Values)
            {
                parameter.ParameterChanged += ParameterOnParameterChanged;
            }
        }

        /// <summary>
        /// Слот, вызываемый при изменении параметра модели
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Аргументы</param>
        private void ParameterOnParameterChanged(object sender, EventArgs e)
        {
            Validate();
        }

        /// <summary>
        /// Проверка значение и установка ограничений
        /// </summary>
        private void Validate()
        {
            _parameters[GasketPropertiesEnum.GasketLenght].Max = _parameters[GasketPropertiesEnum.AbaloneAround].Value +
                                                          _parameters[GasketPropertiesEnum.FromStartToCenterNose].Value;
            _parameters[GasketPropertiesEnum.GasketLenght].Min = _parameters[GasketPropertiesEnum.AbaloneAround].Value +
                                                          _parameters[GasketPropertiesEnum.FromStartToCenterNose].Value;
            _parameters[GasketPropertiesEnum.GasketLenght].Validate();
        }

        /// <summary>
        /// Получить параметр
        /// </summary>
        /// <param name="gasketPropertiesEnum">Тип параметра</param>
        /// <returns>Полученный параметр</returns>
        public GasketParameterValue GetParameter(GasketPropertiesEnum gasketPropertiesEnum)
        {
            return _parameters[gasketPropertiesEnum];
        }
        #endregion
    }
}
