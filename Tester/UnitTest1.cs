using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PP_LAB_1;
using System.Collections.Generic;
using GeneratorCS;

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

            Program.result res = new Program.result(0, 0);

            res = Program.knapsack(weight, values, 2); //(weight, values, capacity)

            Assert.IsNotNull(res);
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

        [TestMethod]
        public void TestZeroCapacity()
        {
            List<int> values = new List<int>();
            List<int> weight = new List<int>();
            Program.result res = new Program.result(0, 0);

            res = Program.knapsack(weight, values, 0); //(weight, values, capacity)

            Assert.IsNull(res);
        }

        [TestMethod]
        public void TestCasual()
        {
            List<int> values = new List<int>();
            List<int> weight = new List<int>();
            int count = 10;
            int valueMax = 5;
            RandomNumberGenerator rng = new RandomNumberGenerator(1);

            for (int i = 0; i < count; i++)
            {
                values.Add(rng.nextInt(1, valueMax));
                weight.Add(rng.nextInt(1, valueMax) + 5);
            }
            Program.result res = new Program.result(0, 0);

            res = Program.knapsack(weight, values, 4); //(weight, values, capacity)

            Assert.AreEqual(res.packed.Count, 0);
        }

        [TestMethod]
        public void TestRandCase()
        {
            List<int> values = new List<int>();
            List<int> weight = new List<int>();
            bool flag = false;
            RandomNumberGenerator rng = new RandomNumberGenerator(1);
            
            for (int i = 0; i < 5; i++)
                values.Add(rng.nextInt(1, 5));
            for (int i = 0; i < 5; i++)
                weight.Add(rng.nextInt(1, 5));

            Program.result res = new Program.result(0, 0);

            res = Program.knapsack(weight, values, 5); //(weight, values, capacity)

            if (res.packed.Count == 2 && res.packed[0] == 1 && res.packed[0] == 1 && res.cost == 2 && res.load == 3)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void TestDiffSeed()
        {
            List<int> values = new List<int>();
            List<int> weight = new List<int>();
            bool flag = false;
            RandomNumberGenerator rng = new RandomNumberGenerator(2);

            for (int i = 0; i < 5; i++)
                values.Add(rng.nextInt(1, 5));
            for (int i = 0; i < 5; i++)
                weight.Add(rng.nextInt(1, 5));

            Program.result res = new Program.result(0, 0);

            res = Program.knapsack(weight, values, 5); //(weight, values, capacity)

            if (res.packed.Count == 2 && res.packed[0] == 1 && res.packed[0] == 1 && res.cost == 2 && res.load == 3)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            Assert.IsFalse(flag);
        }
    }
}
