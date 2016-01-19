using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Application = Inventor.Application;

namespace GasketModelGUI
{
    public partial class UserInterfaceForm : Form
    {
        /// <summary>
        /// Словарь для хранения параметров юзерконтролов
        /// </summary>
        private readonly Dictionary<UserControl, bool> _userControls = new Dictionary<UserControl, bool>();

        /// <summary>
        /// Параметры модели
        /// </summary>
        private readonly GasketProperties _gasketProperties = new GasketProperties();

        /// <summary>
        /// Модель вала
        /// </summary>
        private GasketModelCreator _gasketModelCreator;

        /// <summary>
        /// САПР API
        /// </summary>
        private InventorApi _inventorApi;

        /// <summary>
        /// Ссылка на приложение.
        /// </summary>
        private readonly Application _inventorApplication;

        private Dictionary<GasketPropertiesEnum, GasketParameterValue> _parameter;

        public UserInterfaceForm()
        {
            InitializeComponent();
            InitParameters();
        }

        private void InitParameters()
        {
            RadiusStern.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.RadiusStern);
            RadiusProw.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.RadiusProw);
            RadiusEdges.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.RadiusEdges);
            AbaloneAround.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.AbaloneAround);
            CenterToTheEdge.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.CenterToTheEdge);
            BeforeShear.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.BeforeShear);
            BetweenCentRad.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.BetweenCentRad);
            GasketWidth.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.GasketWidth);
            GasketHeight.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.GasketHeight);
            GasketLenght.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.GasketLenght);
            FromStartToCenterNose.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.FromStartToCenterNose);
            DepthOfNotchInTheStern.Parameter = _gasketProperties.GetParameter(GasketPropertiesEnum.DepthOfNotchInTheStern);
        }

        /// <summary>
        /// Проверка текстбокса на валидность значения
        /// </summary>
        /// <param name="parameterObjectControl"></param>
        /// <param name="_parameters">Список параметров</param>
        //private void UserControlCheck(ParameterObjectControl parameterObjectControl, 
        //    Dictionary<GasketPropertiesEnum, GasketParameterValue> _parameters)
        //{
        //    try
        //    {
        //        foreach (var parameter in _parameters.Values)
        //        {
        //            parameter = double.Parse(parameterObjectControl.Text);
        //            parameterObjectControl.BackColor = System.Drawing.Color.White;
        //            _userControls[parameterObjectControl] = true;
        //        }
        //    }
        //    catch (ValueException)
        //    {
        //        parameterObjectControl.BackColor = System.Drawing.Color.Tomato;
        //        _userControls[parameterObjectControl] = false;
        //    }
        //    catch (FormatException)
        //    {
        //        parameterObjectControl.BackColor = System.Drawing.Color.Tomato;
        //        _userControls[parameterObjectControl] = false;
        //    }
        //}

        /// <summary>
        /// Открытие Inventor 2016
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void RunInventorButton_Click(object sender, EventArgs e)
        {
            _inventorApi = new InventorApi();
        }

        /// <summary>
        /// Построение модели
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void CreateModelButton_Click(object sender, EventArgs e)
        {
            _inventorApi = new InventorApi();
            _gasketModelCreator = new GasketModelCreator(_gasketProperties, _inventorApi);
            _gasketModelCreator.Build(_gasketProperties);
        }

        /// <summary>
        /// Обработчик юзерконтрола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadiusStern_Load(object sender, EventArgs e)
        {
            //UserControlCheck((ParameterObjectControl)sender, _parameter);
        }
    }
}
