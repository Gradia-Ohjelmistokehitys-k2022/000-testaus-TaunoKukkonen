using System.Numerics;
using System.Threading.Tasks;
using TestingTodoListApp;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddItemToDoList_AddOneItem_Works()
        {
            string task = "laundry";
            TodoList todoList = new TodoList();
            TodoTask todoTask = new TodoTask(task);
            todoList.AddItemToList(todoTask);

            var list = todoList._TodoItems;
            int expected = 1;

            Assert.AreEqual(expected, list.Count);
        }
        [TestMethod]
        public void AddItemToDoList_AddThreeItems_Works()
        {
            string task = "Cut grass";
            TodoList todoList = new TodoList();
            TodoTask cutGrass = new TodoTask(task);
            todoList.AddItemToList(cutGrass);
            todoList.AddItemToList(cutGrass);
            todoList.AddItemToList(cutGrass);
            
            var list = todoList._TodoItems;

            Assert.IsNotNull(list);
            Assert.AreEqual(3, list.Count);
        }
        [TestMethod]
        public void AddItemToDoList_AddThreeItemsDiffiretnValues_Works()
        {
            string task = "cut grass";
            string secondTask = "laundry";
            string thirdTask = "wash dishes";
            TodoList todoList = new TodoList();
            TodoTask cutGrass = new TodoTask(task);
            TodoTask laudry = new TodoTask(secondTask);
            TodoTask dishes = new TodoTask(thirdTask);
            todoList.AddItemToList(dishes);
            todoList.AddItemToList(laudry);
            todoList.AddItemToList(cutGrass);
           

            var list = todoList._TodoItems;
            int expected = 3;

            Assert.IsNotNull(list);
            Assert.AreEqual(expected, list.Count);
        }
        [TestMethod]
        public void AddItemToDoList_AddItemWithSecialChar_Works()
        {
            string task ="?+öäå\"wowza\"";
            TodoList todoList = new TodoList();
            TodoTask todoTask = new TodoTask(task);

            todoList.AddItemToList(todoTask);

            var list = todoList._TodoItems;
            int expected = 1;

            Assert.AreEqual(expected, list.Count);
        }
        [TestMethod]
        public void AddItemToDoList_EmptyList_Works()
        {
            TodoList todoList = new TodoList();
            
            var list = todoList._TodoItems;

            int expected = 0;

            Assert.AreEqual(expected, list.Count);
        }
        [TestMethod]
        public void AddItemToDoList_AddNull_Works()
        {
            string nullstring = null;
            TodoList todoList = new TodoList();
            TodoTask todoTask = new TodoTask(nullstring);

            todoList.AddItemToList(todoTask);

            var list = todoList._TodoItems;
            int expected = 1;

            Assert.AreEqual(expected, list.Count);
            Assert.IsNotNull(list);
        }
        //[TestMethod] en tiedä miten saada jo olevia arvoja
        //public void AddItemToList_ListHasValues_Works()
        //{
        //    TodoList todoList = new TodoList();
        //    todoList.AddItemToList(new TodoTask("Do the dishes"));
        //    todoList.AddItemToList(new TodoTask("Wash your clothes"));
        //    todoList.AddItemToList(new TodoTask("laundry"));

        //    var list = todoList._TodoItems;

        //    int expected = 0;

        //    Assert.AreEqual(expected, list.Count);
        //}
        [TestMethod]
        public void AddToDoList_AddItemsToListMax_OverflowExceptionError()
        {
            string task = "Cut grass";
            TodoList todoList = new TodoList();
            for (BigInteger i = 0; i < new BigInteger(2147483648); i++)
            {
                TodoTask cutGrass = new TodoTask(task);
            }
            var list = todoList._TodoItems;
            Assert.AreEqual(0, list.Count);

        }
        [TestMethod]
        public void RemoveItemFromDoList_AddAndRemoveFromList_Works() 
        {
            string task = "laundry";
            TodoList todoList = new TodoList();
            TodoTask todoTask = new TodoTask(task);
            todoList.AddItemToList(todoTask);

            var list = todoList._TodoItems;
            int actual = list.Count;
            int expected = 1;

            todoList.RemoveItemFromList(1);
            int actual2 = todoList._TodoItems.Count;
            int expected2 = 0;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected2, actual2);
        }
        [TestMethod]
        public void RemoveItemFromToDoList_EmptyList_DoesNothing()
        {
            TodoList todoList = new TodoList();
         

            todoList.RemoveItemFromList(0);
            var list = todoList._TodoItems;
            int actual = list.Count;
            int expected = 0;


            Assert.AreEqual(expected, actual);
        }
        [TestMethod]

        public void RemoveItemFromDoList_AddAndRemoveFromListRemoveLastItem_Works()
        {
            string task = "laundry";
            TodoList todoList = new TodoList();
            TodoTask todoTask = new TodoTask(task);
            todoList.AddItemToList(todoTask);
            todoList.AddItemToList(todoTask);

            var list = todoList._TodoItems;
            int actual = list.Count;
            int expected = 2;

            todoList.RemoveItemFromList(2);
            int actual2 = todoList._TodoItems.Count;
            int expected2 = 1;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected2, actual2);
        }
        [TestMethod]
        public void RemoveItemFromDoList_AddAndRemoveFromListRemoveAll_Works()
        {
            string task = "laundry";
            TodoList todoList = new TodoList();
            TodoTask todoTask = new TodoTask(task);
            todoList.AddItemToList(todoTask);
            todoList.AddItemToList(todoTask);

            var list = todoList._TodoItems;
            int actual = list.Count;
            int expected = 2;

            todoList.RemoveItemFromList(2);
            int actual2 = todoList._TodoItems.Count;
            int expected2 = 1;

            todoList.RemoveItemFromList(1);
            int actual3 = todoList._TodoItems.Count;
            int expected3 = 0;


            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }
        [TestMethod]
        public void CompleteItem_MarkAsDone_Works()
        {
            string task = "laundry";
            TodoList todoList = new TodoList();
            TodoTask todoTask = new TodoTask(task);
            todoList.AddItemToList(todoTask);
            todoList.CompleteItem(1);
            var list = todoList._TodoItems;
            int actual = list.Count;
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CompleteItem_MarkLastOneAsDone_Works()
        {

            string task = "laundry";
            TodoList todoList = new TodoList();
            TodoTask todoTask = new TodoTask(task);
            todoList.AddItemToList(todoTask);
            todoList.AddItemToList(todoTask);
            todoList.CompleteItem(2);
            var list = todoList._TodoItems;
            int actual = list.Count;
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CompleteItem_MarkNullItem_Works()
        {
            TodoList todoList = new TodoList();

            Assert.ThrowsException<InvalidOperationException>(() => todoList.CompleteItem(1));
        }
    }
}