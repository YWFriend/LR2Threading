using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//17 библиотечный Метод возвращает скадярное произведение двух случайных векторов.
//Один параметр: размер векторов

namespace LR2MP
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[], double> mult = Muliply;

            int[] a, b;
            Random rand = new Random();

            a = CreateVector(rand);
            b = CreateVector(rand);
            
            Console.WriteLine("({0}, {1})", a[0], a[1]);
            Console.WriteLine("({0}, {1})", b[0], b[1]);

            IAsyncResult ar = mult.BeginInvoke(a, b, null, null);
            while (!ar.IsCompleted)
            {
                Thread.Sleep(1000);
                Console.WriteLine(".");
            }
            double result = mult.EndInvoke(ar);

            Console.WriteLine("Программа выполенена");
            Console.WriteLine(result);

            Console.ReadKey();
        }
        
        // Создание вектора
        static int[] CreateVector(Random rand)
        {
            int[] vect = { 0, 0 };
            vect[0] = rand.Next(-10, 10);
            vect[1] = rand.Next(-10, 10);
            return vect;
        }


        // Скалярное произведение векторов
        static double Muliply(int[] data1, int[] data2)
        {
            double res;

            Console.WriteLine("Программа выполняется...");

            double lena = Math.Sqrt(Math.Pow(data1[0], 2) + Math.Pow(data1[1], 2));
            double lenb = Math.Sqrt(Math.Pow(data2[0], 2) + Math.Pow(data2[1], 2));

            res = lena * lenb * ((data1[0] * data2[0] + data1[1] * data2[1]) / (lena * lenb));

            Thread.Sleep(5000);

            return res;
        }
    }
}
