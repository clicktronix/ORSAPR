using System;
using System.Windows.Forms;

namespace GasketModelGUI
{
    public partial class UserInterfaceForm : Form
    {
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
        /// Конструктор формы
        /// </summary>
        public UserInterfaceForm()
        {
            InitializeComponent();
            InitParameters();

            changeFigureFormComboBox.Items.Add("Круг");
            changeFigureFormComboBox.Items.Add("Прямоугольник");
            changeFigureFormComboBox.Items.Add("Треугольник");
            changeFigureFormComboBox.SelectedIndex = 0;
        }
        /// <summary>
        /// Инициализация параметров
        /// </summary>
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
            if (changeFigureFormComboBox.SelectedIndex == 0)
            { _gasketModelCreator.CircleCutoutsBuilder(_gasketProperties); }
            if (changeFigureFormComboBox.SelectedIndex == 1)
            { _gasketModelCreator.RectangleCutoutsBuilder(_gasketProperties); }
            if (changeFigureFormComboBox.SelectedIndex == 2)
            {  _gasketModelCreator.TriangleCutoutsBuilder(_gasketProperties); }
        }

        /// <summary>
        /// Метод для отображения предупреждения
        /// </summary>
        /// <param name="alertMessage">Предупреждающее сообщение</param>
        public void ShowAlert(string alertMessage)
        {
            if (MessageBox.Show(alertMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                Close();
            }
        }

        /// <summary>
        /// Изменение значений комбобокса
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Параметры</param>
        private void changeFigureFormComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (changeFigureFormComboBox.SelectedIndex)
            {
                case -1:
                    ShowAlert("Выберите фигуру!");
                    break;
                case 0:
                    label3.Text = "Радиусы вырезов по краям";
                    break;
                case 1:
                    label3.Text = "Длина cторон вырезов по краям";
                    break;
                case 2:
                    label3.Text = "Длина cторон вырезов по краям";
                    break;
            }
        }
    }
}
