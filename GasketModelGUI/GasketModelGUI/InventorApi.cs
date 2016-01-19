using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Inventor;
using Application = Inventor.Application;

namespace GasketModelGUI
{
    /// <summary>
    /// Inventor API
    /// </summary>
    public class InventorApi
    {
        #region Fields

        /// <summary>
        /// Ссылка на приложение Инвентора
        /// </summary>
        public Application InventorApplication { get; set; }

        /// <summary>
        /// Документ в приложении
        /// </summary>
        private PartDocument _partDoc;

        /// <summary>
        /// Описание документа
        /// </summary>
        private PartComponentDefinition _partDef;

        /// <summary>
        /// Геометрия приложения
        /// </summary>
        private TransientGeometry _transGeometry;

        /// <summary>
        /// Текущий скетч
        /// </summary>
        private PlanarSketch _currentSketch;

        #endregion

        #region Methods

        /// <summary>
        /// Инициализировать Инвентор и подготовить переменные
        /// </summary>
        public InventorApi()
        {
            try
            {
                //Пытаемся перехватить контроль над приложением инвентора
                InventorApplication = (Application)Marshal.GetActiveObject("Inventor.Application");
            }
            catch (Exception)
            {
                try
                {
                    //Если не получилось перехватить приложение - выкинется ексепшн на то,
                    //что такого приложения нет. Попробуем создать приложение вручную
                    Type _inventorApplicationType = Type.GetTypeFromProgID("Inventor.Application");

                    InventorApplication = (Application)Activator.CreateInstance(_inventorApplicationType);
                    InventorApplication.Visible = true;
                }
                catch (Exception)
                {
                    //Если ничего не получилось - выкинем месседжбокс о том, что инвентор не установлен,
                    //либо по каким-то причинам не получилось до него добраться.
                    //MessageBox.Show(ex2.ToString());
                    MessageBox.Show(@"Не удалось запустить инвентор. Проверьте работоспособность Inventor 2016.");
                }
            }

            // В открытом приложении создаем метрическуюсборку
            _partDoc = (PartDocument)InventorApplication.Documents.Add
                (DocumentTypeEnum.kPartDocumentObject, InventorApplication.FileManager.GetTemplateFile
                        (DocumentTypeEnum.kPartDocumentObject, SystemOfMeasureEnum.kMetricSystemOfMeasure));
            //Описание документа
            _partDef = _partDoc.ComponentDefinition;
            //инициализация метода геометрии
            _transGeometry = InventorApplication.TransientGeometry;
        }

        public void Initialization(Application inputApplication)
        {
            if (inputApplication == null) throw new AccessingNullException();
            // Получение ссылки на приложение.
            InventorApplication = inputApplication;
            
            // В открытом приложении создаем метрическуюсборку
            _partDoc = (PartDocument)InventorApplication.Documents.Add
                (DocumentTypeEnum.kPartDocumentObject, InventorApplication.FileManager.GetTemplateFile
                        (DocumentTypeEnum.kPartDocumentObject, SystemOfMeasureEnum.kMetricSystemOfMeasure));
            // Ссылка на описание документа
            _partDef = _partDoc.ComponentDefinition;
            // Инициализация метода геометрии
            _transGeometry = InventorApplication.TransientGeometry;
        }

        /// <summary>
        /// Создание плоскости переносом плоскостей ZY, ZX, XY
        /// </summary>
        /// <param name="n">Номер плоскости: 1 - ZY, 2 - ZX, 3 - XY</param>
        /// <param name="offset">Относительное смещение плоскости</param>
        public PlanarSketch MakeNewSketch(int n, double offset)
        {
            //Получаем ссылку на рабочую плоскость.
            var mainPlane = _partDef.WorkPlanes[n];

            //Делаем сдвинутую плоскость.
            var offsetPlane = _partDef.WorkPlanes.AddByPlaneAndOffset(mainPlane, offset / 10.0);

            //Создаем на плоскости скетч.
            _currentSketch = _partDef.Sketches.Add(offsetPlane);
            
            offsetPlane.Visible = false;

            return _currentSketch;
        }

        /// <summary>
        /// Рисует прямоугольник по двум точкам
        /// </summary>
        /// <param name="pointOneX">Левая верхняя координата X</param>
        /// <param name="pointOneY">Левая верхняя координата Y</param>
        /// <param name="pointTwoX">Правая нижняя координата X</param>
        /// <param name="pointTwoY">Правая нижняя координата Y</param>
        public void DrawRectangle(double pointOneX, double pointOneY, double pointTwoX, double pointTwoY)
        {
            pointOneX /= 10.0;
            pointOneY /= 10.0;
            pointTwoX /= 10.0;
            pointTwoY /= 10.0;
            var cornerPointOne = _transGeometry.CreatePoint2d(pointOneX, pointOneY);
            var cornerPointTwo = _transGeometry.CreatePoint2d(pointTwoX, pointTwoY);
            _currentSketch.SketchLines.AddAsTwoPointRectangle(cornerPointOne, cornerPointTwo);
        }

        /// <summary>
        /// Рисует круг
        /// </summary>
        /// <param name="centerPointX">Координата X центра круга</param>
        /// <param name="centerPointY">Координата Y центра круга</param>
        /// <param name="diameter">Диаметр круга</param>
        public void DrawCircle(double centerPointX, double centerPointY, double diameter)
        {
            centerPointX /= 10.0;
            centerPointY /= 10.0;
            diameter /= 10.0;
            _currentSketch.SketchCircles.AddByCenterRadius(_transGeometry.CreatePoint2d(centerPointX, centerPointY),
                0.5 * diameter);
        }

        /// <summary>
        /// Выдавливание
        /// </summary>
        /// <param name="distance">Длинна выдавливания</param>
        /// <param name="extrudeDirection">Направление выдавливания</param>
        public void Extrude(double distance, PartFeatureExtentDirectionEnum extrudeDirection = PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        {
            var extrudeDef = _partDef.Features.ExtrudeFeatures.CreateExtrudeDefinition(_currentSketch.Profiles.AddForSolid(),
                PartFeatureOperationEnum.kJoinOperation);
            extrudeDef.SetDistanceExtent(distance / 10.0, extrudeDirection);
            _partDef.Features.ExtrudeFeatures.Add(extrudeDef);
        }

        /// <summary>
        /// Выдавить с вычитанием
        /// </summary>
        /// <param name="diameter">Диаметр круга</param>
        /// <param name="distance">Дистанция выдавливания</param>
        /// <param name="centerPointX">X координата центра</param>
        /// <param name="centerPointY">Y координата центра</param>
        public void CutExtrudeCircle(double centerPointX, double centerPointY, double diameter, double distance)
        {
            DrawCircle(centerPointX, centerPointY, diameter);
            var extrudeDef = _partDef.Features.ExtrudeFeatures.CreateExtrudeDefinition(_currentSketch.Profiles.AddForSolid(),
                PartFeatureOperationEnum.kCutOperation);
            extrudeDef.SetDistanceExtent(distance / 10.0, PartFeatureExtentDirectionEnum.kPositiveExtentDirection);
            _partDef.Features.ExtrudeFeatures.Add(extrudeDef);
        }

        /// <summary>
        /// Выдавить с вычитанием
        /// </summary>
        /// <param name="distance">Дистанция выдавливания</param>
        /// <param name="pointOneX">X координата первой стороны</param>
        /// <param name="pointOneY">Y координата первой стороны</param>
        /// <param name="pointTwoX">X координата второй стороны</param>
        /// <param name="pointTwoY">Y координата второй стороны</param>
        public void CutExtrudeRectangle(double pointOneX, double pointOneY, double pointTwoX, double pointTwoY, double distance)
        {
            pointOneX /= 10.0;
            pointOneY /= 10.0;
            pointTwoX /= 10.0;
            pointTwoY /= 10.0;
            var cornerPointOne = _transGeometry.CreatePoint2d(pointOneX, pointOneY);
            var cornerPointTwo = _transGeometry.CreatePoint2d(pointTwoX, pointTwoY);
            _currentSketch.SketchLines.AddAsTwoPointRectangle(cornerPointOne, cornerPointTwo);
            var extrudeDef = _partDef.Features.ExtrudeFeatures.CreateExtrudeDefinition(_currentSketch.Profiles.AddForSolid(),
                PartFeatureOperationEnum.kCutOperation);
            extrudeDef.SetDistanceExtent(distance / 10.0, PartFeatureExtentDirectionEnum.kPositiveExtentDirection);
            _partDef.Features.ExtrudeFeatures.Add(extrudeDef);
        }
        
        /// <summary>
        /// Построить линию
        /// </summary>
        /// <param name="startPointX">Начальная координата X</param>
        /// <param name="startPointY">Начальная координата Y</param>
        /// <param name="endPointX">Конечная координата X</param>
        /// <param name="endPointY">Конечная координата Y</param>
        public void DrawLine(double startPointX, double startPointY, double endPointX, double endPointY)
        {
            startPointX /= 10.0;
            startPointY /= 10.0;
            endPointX /= 10.0;
            endPointY /= 10.0;
            var startPoint = _transGeometry.CreatePoint2d(startPointX, startPointY);
            var endPoint = _transGeometry.CreatePoint2d(endPointX, endPointY);
            _currentSketch.SketchLines.AddByTwoPoints(startPoint, endPoint);
        }

        /// <summary>
        /// Продолжает линию с последней точки
        /// </summary>
        /// <param name="endPointX">Координата X конца линии</param>
        /// <param name="endPointY">Координата Y конца линии</param>
        public void DrawLine(double endPointX, double endPointY)
        {
            endPointX /= 10.0;
            endPointY /= 10.0;
            var endPoint = _transGeometry.CreatePoint2d(endPointX, endPointY);
            _currentSketch.SketchLines.AddByTwoPoints(_currentSketch.SketchLines
                [_currentSketch.SketchLines.Count].EndSketchPoint, endPoint);
        }

        /// <summary>
        /// Метод соединяет первую и последнюю точки
        /// </summary>
        public void CloseShape()
        {
            _currentSketch.SketchLines.AddByTwoPoints(
            _currentSketch.SketchLines[_currentSketch.SketchLines.Count].EndSketchPoint,
            _currentSketch.SketchLines[1].StartSketchPoint);
        }

        /// <summary>
        /// Метод меняющий материал части
        /// </summary>
        /// <param name="material">Материал</param>
        public void ChangeMaterial(string material)
        {
            PartDocument partDoc = (PartDocument)InventorApplication.ActiveDocument;

            //Получаем библиотеку
            Materials materialsLibrary = partDoc.Materials;

            //Берем необходимый материал
            Material myMaterial = materialsLibrary[material];

            //Проверка на то, что материал входит в текущую библиотеку
            Material tempMaterial = myMaterial.StyleLocation == StyleLocationEnum.kLibraryStyleLocation
                ? myMaterial.ConvertToLocal()
                : myMaterial;

            //Меняем материал.
            partDoc.ComponentDefinition.Material = tempMaterial;
            partDoc.Update();
        }

        #endregion
    }
}
