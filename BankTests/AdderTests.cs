using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTests
{
    [TestClass]
    internal class AdderTests
    {
        [TestMethod]
        public void TestAdds()
        {
            int a = 1 ;
            int b = 2 ;
            int c = - 1;
            Adder adder = new Adder();
            c=adder.Subtract(a, b);
            Assert.AreEqual(a, c,"Lasku onnistui");
        }
    }
}
