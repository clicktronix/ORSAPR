//using System;
//using NUnit.Framework;
//using GasketModelGUI;
//using Inventor;

//namespace UnitTests
//{
//    class BuildTest
//    {
//        private InventorApi _inventorApi = new InventorApi();
//        private GasketModelCreator _gasketModelCreator;
//        private GasketProperties _gasketProperties;

//        [Test, Description("Позитивное построение")]
//        public void BuildHandlebarPositive(GasketModelCreator gasketModelCreator, GasketProperties gasketProperties)
//        {
//            _gasketProperties = gasketProperties;
//            _gasketModelCreator = gasketModelCreator;

//            //Проверяем, что постройка не выкинула ексепшн.
//            Assert.DoesNotThrow(() => _gasketModelCreator.Build(gasketProperties));

//            //Очищаем документ
//            foreach (Document document in _inventorApi.InventorApplication.Documents)
//            {
//                document.Close(true);
//            }
//        }
//        [Test, Description("Позитивный тест для конструктора")]
//        public void PartBuilderPositive()
//        {
//            //Проверяем конструктор валидной ссылкой.
//            // ReSharper disable once ObjectCreationAsStatement
//            Assert.DoesNotThrow(() => { new GasketModelCreator(_inventorApi.InventorApplication); });

//            //подчищаем за собой
//            foreach (Document document in _inventorApi.InventorApplication.Documents)
//            {
//                document.Close(true);
//            }

//        }

//        [Test, Description("Негативный тест для конструктора")]
//        public void PartBuilderNegative()
//        {
//            //Подаем невалидную ссылку на приложение.
//            // ReSharper disable once ObjectCreationAsStatement
//            Assert.Throws<AccessingNullException>(() => { new GasketModelCreator(null); });
//        }
//    }
//}
