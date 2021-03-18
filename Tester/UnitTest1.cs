using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PP_LAB_1;
using System.Collections.Generic;

namespace Tester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOneElement() //sprawdzenie dzialania dla jednego elementu
        {
            List<int> values = new List<int>();
            List<int> weight = new List<int>();

            values.Add(4);
            weight.Add(2);

            Program.result res = new Program.result(0,0);
            
            res = Program.knapsack(weight, values, 2); //(weight, values, capacity)

            Assert.AreEqual(res.cost,4);
        }

        [TestMethod]
        public void TestZeroElement()
        {
            List<int> values = new List<int>();
            List<int> weight = new List<int>();
            Program.result res = new Program.result(0, 0);

            res = Program.knapsack(weight, values, 2); //(weight, values, capacity)

            Assert.AreEqual(res, null);
        }

    }
}
