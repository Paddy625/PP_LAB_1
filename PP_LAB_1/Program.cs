using GeneratorCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace PP_LAB_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator rng = new RandomNumberGenerator(1);
            List<int> values = new List<int>();
            List<int> weight = new List<int>();
            int cost = 0;
            int load = 0;
            result res = new result(0, 0);

            System.Console.WriteLine("Podaj ilosc przedmiotów: ");
            int count = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Podaj maksymalną wagę przedmiotów: ");
            int weightMax = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Podaj maksymalną wartosc przedmiotów: ");
            int valueMax = Convert.ToInt32(System.Console.ReadLine());
            System.Console.WriteLine("Podaj pojemność plecaka: ");
            int capacity = Convert.ToInt32(System.Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                values.Add(rng.nextInt(1, valueMax));
                System.Console.Write(i+1 + "\t");
            }
            for (int i = 0; i < count; i++)
            {
                weight.Add(rng.nextInt(1, weightMax));
            }
            System.Console.WriteLine();

            foreach (int x in weight)
            {
                System.Console.Write(x + "\t");
            }

            System.Console.WriteLine();

            foreach (int x in values)
            {
                System.Console.Write(x + "\t");
            }
            
            res = knapsack(weight, values, capacity);
            if (res == null)
            {
                System.Console.ReadLine();
                return;
            }

            System.Console.WriteLine("\n Wartość wybranych przedmiotów wynosi: " + res.cost);
            System.Console.WriteLine("Waga wybranych przedmiotów wynosi: " + res.load);
            System.Console.ReadLine();
        }

        public class result 
        {
            public int load;
            public int cost;
            public List<int> packed;

            public result(int x, int y) 
            {
                cost = x;
                load = y;
                packed = new List<int>();
            }
        }
        public static result knapsack(List<int> weight, List<int> values, int capacity)
        {
            result res = new result(0,0);

            System.Console.WriteLine("\n Wybrano przedmioty o numerach: ");
            for (int i = 0; i < values.Count(); i++)
            {
                if (res.load + weight[i] <= capacity)
                {
                    res.load = res.load + weight[i];
                    res.cost = res.cost + values[i];
                    res.packed.Add(i + 1);
                    System.Console.Write(i + 1 + "\t");
                }
            }
            if (values.Count() == 0)
            {
                System.Console.WriteLine("Nieprawidłowe dane wejściowe");
                return null;
            }
            else
                return res;
        }
    }
}
