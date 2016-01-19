using System;
using NUnit.Framework;
using GasketModelGUI;
using Inventor;

namespace UnitTests
{
    public class InventorAPITest
    {
        private InventorApi _inventorApi = new InventorApi();

        [Test, Description("Позитивная инициализация")]
        public void InitPositive()
        {
            //Подаем ссылку на приложение
            Assert.DoesNotThrow(() => _inventorApi.Initialization(_inventorApi.InventorApplication));

            //Очищаем документ
            foreach (Document document in _inventorApi.InventorApplication.Documents)
            {
                document.Close(true);
            }
        }

        [Test, Description("Негативная инициализация")]
        public void InitNegative()
        {
            //Подаем ссылку на приложение
            Assert.Throws<AccessingNullException>(() => _inventorApi.Initialization(null));

            //Очищаем документ
            foreach (Document document in _inventorApi.InventorApplication.Documents)
            {
                document.Close(true);
            }
        }
    }
}
