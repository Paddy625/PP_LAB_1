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

            // === Ustalanie zmiennych ===
            System.Console.Write("Podaj ilosc przedmiotów: ");
            int count = Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("Podaj maksymalną wagę przedmiotów: ");
            int weightMax = Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("Podaj maksymalną wartosc przedmiotów: ");
            int valueMax = Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("Podaj pojemność plecaka: ");
            int capacity = Convert.ToInt32(System.Console.ReadLine());
            // === Losowanie przedmiotów ===
            for (int i = 0; i < count; i++)
                values.Add(rng.nextInt(1, valueMax));
            for (int i = 0; i < count; i++)
                weight.Add(rng.nextInt(1, weightMax));

            // === Wyświetlanie przedmiotów ===
            DisplayObjects(values, weight);

            // === Problem plecakowy ===
            res = knapsack(weight, values, capacity);
            if (res != null)
            {
                System.Console.WriteLine("\nWartość wybranych przedmiotów wynosi:\t" + res.cost);
                System.Console.WriteLine("Waga wybranych przedmiotów wynosi:\t" + res.load);
                return;
            }
            else
                return;
        }

        // === Struktura zawierająca rozwiązanie problemu plecakowego ===
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
        // ==============================================================

        // === Problem plecakowy - rozwiazanie naiwne =======================================
        public static result knapsack(List<int> weight, List<int> values, int capacity)
        {
            if (capacity == 0)
            {
                System.Console.WriteLine("Zerowa pojemność plecaka!");
                return null;
            }
            else
            {
                result res = new result(0, 0);
                System.Console.WriteLine("\nWybrano przedmioty o numerach:");
                for (int i = 0; i < values.Count(); i++)
                {
                    if (res.load + weight[i] <= capacity)
                    {
                        res.load = res.load + weight[i];
                        res.cost = res.cost + values[i];
                        res.packed.Add(i + 1);
                        System.Console.Write("\t" + (i + 1));
                    }
                }
                if (values.Count() == 0)
                {
                    System.Console.WriteLine("Brak przedmiotów mieszczących się w plecaku!");
                    return null;
                }
                else
                    return res;
            }
        }
        // ==================================================================================

        // === Wyświetlanie przedmiotów ==============================
        static void DisplayObjects(List<int> values, List<int> weight)
        {
            System.Console.Write("\nN:\t");
            for (int i = 0; i < values.Count(); i++)
                System.Console.Write(i + 1 + "\t");
            System.Console.Write("\nW:\t");
            foreach (int x in weight)
                System.Console.Write(x + "\t");
            System.Console.Write("\nV:\t");
            foreach (int x in values)
                System.Console.Write(x + "\t");
            System.Console.WriteLine();
            return;
        }
        // ===========================================================
    }
}
