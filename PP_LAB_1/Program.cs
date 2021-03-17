using GeneratorCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP_LAB_1
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomNumberGenerator rng = new RandomNumberGenerator(1);
            List<int> values = new List<int>();
            List<int> weight = new List<int>();
            List<int> packed = new List<int>();
            int cost = 0;
            int load = 0;

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
            System.Console.WriteLine("\n Wybrano przedmioty o numerach: ");

            for (int i = 0; i < count; i++)
            {
                if (load + weight[i] <= capacity)
                {
                    load = load + weight[i];
                    cost = cost + values[i];
                    packed.Add(i + 1);
                    System.Console.Write(i + 1 + "\t");     //dodać listę z przedmiotami
                }
            }
            System.Console.WriteLine("\n Wartość wybranych przedmiotów wynosi: " + cost);
            System.Console.WriteLine("Waga wybranych przedmiotów wynosi: " + load);
            System.Console.ReadLine();
        }
    }
}
