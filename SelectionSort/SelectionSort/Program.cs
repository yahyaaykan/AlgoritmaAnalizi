using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    using System;

    class SelectionSort
    {
        static void SelectionS(int[] Array)
        {
            int n = Array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                // Dizinin kalan kısmında en küçük elemanın indexini bul
                for (int j = i + 1; j < n; j++)
                {
                    if (Array[j] < Array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Bulunan en küçük elemanı i ile değiştir
                int temp = Array[minIndex];
                Array[minIndex] = Array[i];
                Array[i] = temp;
            }
        }

        // Diziyi ekrana yazdır
        static void PrintArray(int[] Array)
        {
            int n = Array.Length;
            for (int i = 0; i < n; ++i)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine();
        }

      
        public static void Main()
        {
            int[] Array = { 64, 25, 12, 22, 11 };
            Console.WriteLine("Dizinin sıralanmamış hali:");
            PrintArray(Array);

            SelectionS(Array);

            Console.WriteLine("Dizinin sıralanmış hali:");
            PrintArray(Array);
            Console.ReadLine();
        }
    }

}
