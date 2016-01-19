using Inventor;

namespace GasketModelGUI
{
    /// <summary>
    /// Класс инкапсулирует модель, вызывает построение модели
    /// </summary>
    public class GasketModelCreator
    {
        #region Fields

        /// <summary>
        /// Ссылка на приложение Инвентора
        /// </summary>
        public Application InventorApplication { get; set; }

        /// <summary>
        /// Параметры модели
        /// </summary>
        private readonly GasketProperties _gasketProperties;

        /// <summary>
        /// САПР API
        /// </summary>
        private readonly InventorApi _api;

        #endregion

        #region Methods

        /// <summary>
        /// Конструктор с входными параметрами модели
        /// </summary>
        /// <param name="gasketProperties">Параметры модели</param>
        /// <param name="InventorApi">API</param>
        /// <param name="_inventorApplication">Ссылка на приложение</param>
        public GasketModelCreator(GasketProperties gasketProperties, InventorApi InventorApi)
        {
            _gasketProperties = gasketProperties;
            _api = InventorApi;
            InventorApplication = InventorApi.InventorApplication;
        }

        /// <summary>
        /// Функция строит модель
        /// </summary>
        public void Build(GasketProperties gasketProperties)
        {
            if (gasketProperties == null) throw new AccessingNullException();
            // Шаги для прогрессбара
            const int stepCount = 4;

            // Создаем прогрессбар
            ProgressBar progressBar = InventorApplication.CreateProgressBar(false, stepCount, "Построение инжекторной прокладки");
            
            progressBar.Message = @"Построение инжекторной прокладки, пожалуйста подождите";
            progressBar.UpdateProgress();

            progressBar.Message = @"Создание основной модели инжекторной прокладки, пожалуйста подождите";
            progressBar.UpdateProgress();
            // Функция строит основу инжекторной прокладки
            BuildModel();
            
            progressBar.Message = @"Создание отверстий и вырезов инжекторной прокладки, пожалуйста подождите";
            progressBar.UpdateProgress();
            // Функция создает вырезы в детали
            BuildCutouts();
            BuildCircleCutouts();

            progressBar.Message = @"Настройка материалов, пожалуйста подождите";
            progressBar.UpdateProgress();
            // Меняем материал
            _api.ChangeMaterial(@"Aluminum 6061-AHC");

            //Закрываем прогрессбар
            progressBar.Close();
        }

        /// <summary>
        /// Функция строит основу инжекторной прокладки
        /// </summary>
        private void BuildModel()
        {
            var abaloneAround = _gasketProperties.GetParameter(GasketPropertiesEnum.AbaloneAround).Value;
            var beforeShear = _gasketProperties.GetParameter(GasketPropertiesEnum.BeforeShear).Value;
            var gasketWidth = _gasketProperties.GetParameter(GasketPropertiesEnum.GasketWidth).Value;
            var gasketHeight = _gasketProperties.GetParameter(GasketPropertiesEnum.GasketHeight).Value;
            var fromStartToCenterNose = _gasketProperties.GetParameter(GasketPropertiesEnum.FromStartToCenterNose).Value;

            // Создание основной модели прокладки без вырезов
            _api.MakeNewSketch(3, 0);
            _api.DrawCircle(fromStartToCenterNose, 0.0, abaloneAround*2);
            _api.Extrude(gasketHeight);
            _api.DrawRectangle(0.0, gasketWidth/2, beforeShear, -gasketWidth/2);
            _api.Extrude(gasketHeight);

            // Создание среза 
            _api.MakeNewSketch(3, 0);
            _api.DrawLine(beforeShear, -gasketWidth/2, fromStartToCenterNose, -abaloneAround);
            _api.DrawLine(fromStartToCenterNose, abaloneAround);
            _api.DrawLine(beforeShear, gasketWidth/2);
            _api.CloseShape();
            _api.Extrude(gasketHeight);
        }

        /// <summary>
        /// Функция создает вырезы в детали
        /// </summary>
        private void BuildCutouts()
        {
            var radiusStern = _gasketProperties.GetParameter(GasketPropertiesEnum.RadiusStern).Value;
            var radiusProw = _gasketProperties.GetParameter(GasketPropertiesEnum.RadiusProw).Value;
            var gasketHeight = _gasketProperties.GetParameter(GasketPropertiesEnum.GasketHeight).Value;
            var fromStartToCenterNose = _gasketProperties.GetParameter(GasketPropertiesEnum.FromStartToCenterNose).Value;
            var depthOfNotchInTheStern = _gasketProperties.GetParameter(GasketPropertiesEnum.DepthOfNotchInTheStern).Value;

            // Создание прямоугольного выреза на корме детали
            _api.MakeNewSketch(3, 0);
            _api.CutExtrudeRectangle(0.0, radiusStern, depthOfNotchInTheStern, -radiusStern, gasketHeight);
            
            // Создание выреза на носу детали
            _api.MakeNewSketch(3, 0);
            _api.CutExtrudeCircle(fromStartToCenterNose, 0.0, radiusProw * 2, gasketHeight);

            // Создание выреза на корме детали
            _api.MakeNewSketch(3, 0);
            _api.CutExtrudeCircle(depthOfNotchInTheStern, 0.0, radiusStern * 2, gasketHeight);
        }

        /// <summary>
        /// Функция создает вырезы в детали
        /// </summary>
        private void BuildCircleCutouts()
        {
            var radiusEdges = _gasketProperties.GetParameter(GasketPropertiesEnum.RadiusEdges).Value;
            var centerToTheEdge = _gasketProperties.GetParameter(GasketPropertiesEnum.CenterToTheEdge).Value;
            var betweenCentRad = _gasketProperties.GetParameter(GasketPropertiesEnum.BetweenCentRad).Value;
            var gasketWidth = _gasketProperties.GetParameter(GasketPropertiesEnum.GasketWidth).Value;
            var gasketHeight = _gasketProperties.GetParameter(GasketPropertiesEnum.GasketHeight).Value;
            
            // Создание вырезов по краям детали
            _api.MakeNewSketch(3, 0);
            _api.CutExtrudeCircle(centerToTheEdge, gasketWidth / 2 - centerToTheEdge, radiusEdges * 2, gasketHeight);
            _api.CutExtrudeCircle(centerToTheEdge + betweenCentRad, gasketWidth / 2 - centerToTheEdge, radiusEdges * 2, gasketHeight);
            _api.CutExtrudeCircle(centerToTheEdge, -gasketWidth / 2 + centerToTheEdge, radiusEdges * 2, gasketHeight);
            _api.CutExtrudeCircle(centerToTheEdge + betweenCentRad, -gasketWidth / 2 + centerToTheEdge, radiusEdges * 2, gasketHeight);
        #endregion
        }
    }
}