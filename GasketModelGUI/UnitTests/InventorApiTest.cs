using NUnit.Framework;
using GasketModelGUI;
using Inventor;

namespace UnitTests
{
    public class InventorAPITest
    {
        private readonly InventorApi _inventorApi = new InventorApi();
        [Test]

        [TestCase(TestName = "Позитивная инициализация приложения")]
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
        [TestCase(TestName = "Негативная инициализация приложения")]
        public void InitNegative()
        {
            //Подаем ссылку на приложение
            Assert.Throws<AccessingNullException>(() => _inventorApi.Initialization(null));
        }
    }
}
