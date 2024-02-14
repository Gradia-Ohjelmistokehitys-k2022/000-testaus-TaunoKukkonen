using WareHouse;
namespace WarehouseTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToStock_PositiveNumber_Works()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(stockItem, 5);

            bool result = wareHouse.InStock(stockItem);
            int expected = 5;
            int actual = wareHouse.StockCount(stockItem);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
           
        }
        [TestMethod]
        public void AddToStock_ZeroNumber_ArgumentOutOfRangeExceprion()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wareHouse.AddToStocks(stockItem, 0));
        }
        [TestMethod]
        public void AddToStock_NegativeNumber_ArgumentOutOfRangeExceprion()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => wareHouse.AddToStocks(stockItem, -5));

        }
        [TestMethod]    
        public void InStock_NormalAmount_Works()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(stockItem, 5);

            bool result = wareHouse.InStock(stockItem);
            int expected = 5;
            int actual = wareHouse.StockCount(stockItem);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InStock_AmounReducedToZero_Works()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(stockItem, 5);

            wareHouse.TakeFromStock(stockItem, 5);

            bool result = wareHouse.InStock(stockItem);
            int expected = 0;
            int actual = wareHouse.StockCount(stockItem);

            Assert.IsFalse(result);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void InStock_AmounReducedTonegative_Execption()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(stockItem, 5);

            Assert.ThrowsException<Exception>(() => wareHouse.TakeFromStock(stockItem, 50));

            bool result = wareHouse.InStock(stockItem);
            int expected = 5;
            int actual = wareHouse.StockCount(stockItem);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TakeFromStock_OneItem_Works()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(stockItem, 5);

            wareHouse.TakeFromStock(stockItem, 1);

            bool result = wareHouse.InStock(stockItem);
            int expected = 4;
            int actual = wareHouse.StockCount(stockItem);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TakeFromStock_AllItems_Works()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(stockItem, 5);

            wareHouse.TakeFromStock(stockItem, 5);

            bool result = wareHouse.InStock(stockItem);
            int expected = 0;
            int actual = wareHouse.StockCount(stockItem);

            Assert.IsFalse(result);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TakeFromStock_ZeroItems_Works()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(stockItem, 5);

            wareHouse.TakeFromStock(stockItem, 0);

            bool result = wareHouse.InStock(stockItem);
            int expected = 5;
            int actual = wareHouse.StockCount(stockItem);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddToStock_SameItemTwice_Works()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(stockItem, 5);
            wareHouse.AddToStocks(stockItem, 5);
            bool result = wareHouse.InStock(stockItem);
            int expected = 10;
            int actual = wareHouse.StockCount(stockItem);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void AddToStockStockCountRemoveFromStock_NormalAmount_Works()
        {
            string stockItem = "Omena";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            wareHouse.AddToStocks(stockItem, 5);

            int expected2 = 5;
            int actual2= wareHouse.StockCount(stockItem);

            Assert.AreEqual(expected2, actual2);

            wareHouse.TakeFromStock(stockItem, 5);

            bool result = wareHouse.InStock(stockItem);
            int expected = 0;
            int actual = wareHouse.StockCount(stockItem);

            Assert.IsFalse(result);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void StocCount_NonExixistingItem_Execption()
        {
            string stockItem = "Kissa";
            WareHouse.WareHouse wareHouse = new WareHouse.WareHouse();
            Assert.ThrowsException<Exception>(() => wareHouse.StockCount(stockItem));
        }
    }
}