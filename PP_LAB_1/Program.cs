using GeneratorCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_LAB_1
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator rng = new RandomNumberGenerator(1);
            List<int> values = new List<int>();

            for (int i = 0; i < 10; i++)
                values.Add(rng.nextInt(1, 29));
            foreach (int x in values)
            {
                System.Console.WriteLine(x);
            }
            System.Console.ReadLine();
        }
    }
}
