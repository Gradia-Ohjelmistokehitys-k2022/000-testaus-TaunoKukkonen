using System.Collections.Generic;
using TestedApp;

namespace TesterApp
{
    [TestClass]
    public class UnitTest1
    {
        private void SubtractionReturnTrue(int x, int y, int expected)
        {
            Program program = new Program();
            program.subtract(x, y);
            int actual = (int)program.a;
            Assert.AreEqual(expected, actual, "lasku tehty oikein");
        }
        private void SqueraReturTruen(int x, int expected)
        {
            Program program = new Program();
            program.Square(x);
            int actual = (int)program.a;
            Assert.AreEqual(expected, actual);
        }
        private void RootReturnTrue(double x, float expected)
        {
            Program program = new Program();
            program.Root(x);
            float result = program.a;
            Assert.AreEqual(expected, result);
        }
        private void FloatReturnTrue(List<float> x,float expected) 
        {
            Program program = new Program();
            program.MidFloat(x);
            float actual = program.a;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NormaSubratction()
        {
            int x = 10;
            int y = 20;
            int expected = -10;
            SubtractionReturnTrue(x, y, expected);


        }
        [TestMethod]
        public void NegativeSubraction()
        {
            int x = -10;
            int y = -20;
            int expected = 10;
            SubtractionReturnTrue(x, y, expected);
        }
        [TestMethod]
        public void ZeroSubtraction()
        {
            int x = -10;
            int y = 0;
            int expected = -10;
            SubtractionReturnTrue(x, y, expected);
        }
        [TestMethod]
        public void FiveSquered()
        {
            int x = 5;
            int expected = 25;
            SqueraReturTruen(x, expected);

        }
        [TestMethod]
        public void HundredSquered()
        {
            int x = 100;
            int expected = 10000;
            SqueraReturTruen(x, expected);
        }
        [TestMethod]
        public void OverHundredSquered()
        {
            int x = 101;
            int expected = 0;//ei toimi joten palauuttaa 0
            SqueraReturTruen(x, expected);
        }
        [TestMethod]
        public void NegativeSquered()
        {
            int x = -5;
            int expected = 0;//ohjelma ei laske negatiivisia lukuja joten palauttaa 0
            SqueraReturTruen(x, expected);
        }
        [TestMethod]
        public void TwentyOneSquared()
        {
            int x = 25;
            int expected = 5;
            RootReturnTrue(x, expected);
        }
        [TestMethod]
        public void NegativeRoot()
        {
            double x = -25;
            Program program = new Program();
            Assert.ThrowsException<System.NotSupportedException>(() => program.Root(x));
        }
        [TestMethod]
        public void DecimalRoot()
        {
            double x = 100.50;
            float expected = 10.024969100952148f;
            RootReturnTrue(x, expected);
        }
        [TestMethod]
        public void SmallestDoubleNormal()
        {
            List<double> x = new List<double>();
            for (int i = 1; i < 10; i++)
            {
                x.Add(i);
            }
            double expected = 1;
            Program program = new Program();
            program.FindSmallestDouble(x);
            double actual = program.a;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void EmptyDoubleList()
        {
            List<double> x = new List<double>();
            Program program = new Program();
            program.FindSmallestDouble(x);
            double actual = program.a;
            Assert.AreEqual((double)0, actual);
        }
        [TestMethod]
        public void RandomDoubleList()
        {
            Random random = new Random();
            List<double> x = new List<double>();
            Program program = new Program();
            x.Add(-1);
            for (int i = 1; i < 10; i++)
            {
                x.Add(random.NextDouble());
            }
            program.FindSmallestDouble(x);
            double expected = -1;
            double actual = program.a;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void RandomIntList()
        {
            Random random = new Random();
            List<int> x = new List<int>();
            Program program = new Program();
            x.Add(-1);
            for (int i = 1; i < 10; i++)
            {
                x.Add(random.Next(-100, 100));
            }
            program.BiggestInt(x);
            int expected = x.Max();
            int actual = (int)program.a;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllNegativeIntList()
        {
            List<int> x = new List<int>() { -1, -2, -3, -4, -5 };
            Program program = new Program();
            program.BiggestInt(x);
            int expected = -1;
            int actual = (int)program.a;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleElementIntList()
        {
            List<int> x = new List<int>() { 5 };
            Program program = new Program();
            program.BiggestInt(x);
            int expected = 5;
            int actual = (int)program.a;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestAverageOfPositiveNumbers()
        {
            var list = new List<float> { 1.0f, 2.0f, 3.0f };
            float expected = 2.0f;
           FloatReturnTrue(list, expected);
        }

        [TestMethod]
        public void TestAverageOfNegativeNumbers()
        {
            var list = new List<float> { -1.0f, -2.0f, -3.0f };
            float expected = -2.0f;
            FloatReturnTrue(list, expected);
            
        }

        [TestMethod]
        public void TestAverageOfMixedNumbers()
        {
            var list = new List<float> { -1.0f, 0.0f, 1.0f };
            float expected = 0f;
            FloatReturnTrue(list, expected);
            
        }
    }
}