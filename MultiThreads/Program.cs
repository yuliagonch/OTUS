
using System.Collections.Concurrent;
using System.Diagnostics;

namespace MultiThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = FillArray(100000);
            int[] arr2 = FillArray(1000000);
            int[] arr3 = FillArray(10000000);

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Обычное вычисление суммы элементов массива интов");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            CalcSumNormal(arr1);
            CalcSumNormal(arr2);
            CalcSumNormal(arr3);

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Параллельное вычисление суммы элементов массива интов (List<Task>)");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            CalcSumByTasksList(arr1);
            CalcSumByTasksList(arr2);
            CalcSumByTasksList(arr3);

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Параллельное с помощью LINQ вычисление суммы элементов массива интов");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            CalcSumParallel(arr1);
            CalcSumParallel(arr2);
            CalcSumParallel(arr3);

            Console.ReadKey();
        }

        /// <summary>
        /// Обычное вычисление суммы элементов массива интов
        /// </summary>
        /// <param name="arr">Массив интов</param>
        private static void CalcSumNormal(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int sum = SumArr(arr, 0, arr.Length);

            stopwatch.Stop();

            Console.WriteLine($"Сумма элементов массива (Обычное) = {sum}, время выполнения для массива размером {arr.Length} = {stopwatch.ElapsedMilliseconds} мс");
        }

        /// <summary>
        /// Параллельное вычисление суммы элементов массива интов  (List<Task>)
        /// </summary>
        /// <param name="arr">Массив интов</param>
        /// <param name="iterationsCount">Число итеарций</param>
        private static void CalcSumByTasksList(int[] arr)
        {
            var tasks = new List<Task>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int sum = 0;
            int size = 1000;
            // Делим массив на кусочки по size элементов
            for (int i = 0; i < arr.Length / size; i++)
            {
                int fromIndex = i * size;
                int toIndex = (i + 1) * size;
                Task t = Task.Factory.StartNew(() => SumArr(arr, fromIndex, toIndex));
                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());
            foreach (Task<int> task in tasks)
                sum += task.Result;

            stopwatch.Stop();

            Console.WriteLine($"Сумма элементов массива (Параллельное с List<Task>) = {sum}, время выполнения для массива размером {arr.Length} = {stopwatch.ElapsedMilliseconds} мс");
        }

        /// <summary>
        /// Параллельное с помощью LINQ вычисление суммы элементов массива интов
        /// </summary>
        /// <param name="arr">Массив интов</param>
        private static void CalcSumParallel(int[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int sum = arr.AsParallel().Sum();

            stopwatch.Stop();
            Console.WriteLine($"Сумма элементов массива (Параллельное с Parallel.Foreach) = {sum}, время выполнения для массива размером {arr.Length} = {stopwatch.ElapsedMilliseconds} мс");
        }

        /// <summary>
        /// Вычислиение суммы элементов массива интов
        /// </summary>
        /// <param name="arr">Массив интов</param>
        /// <returns>Рассчитанная сумма элементов массива интов</returns>
        private static int SumArr(int[] arr, int fromIndex, int toIndex)
        {
            int sum = 0;
            for (int i = fromIndex; i < toIndex; i++)
                sum += arr[i];

            return sum;
        }

        /// <summary>
        /// Создать и заполнить массив интов рандоными значениями
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <returns>Массив интов</returns>
        private static int[] FillArray(int size)
        {
            int[] arr = new int[size];

            var rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(0, 100);
            }

            return arr;
        }
    }
}