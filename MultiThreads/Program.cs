
using System.Collections.Concurrent;
using System.Diagnostics;

namespace MultiThreads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");

            string sizeStr = Console.ReadLine();
            int size = 0;
            try
            {
                size = Convert.ToInt32(sizeStr);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return;
            }

            int[] arr = FillArray(size);

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Обычное вычисление суммы элементов массива интов");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            CalcSumNormal(arr, 100000);
            CalcSumNormal(arr, 1000000);
            CalcSumNormal(arr, 10000000);

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Параллельное вычисление суммы элементов массива интов (List<Task>)");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            CalcSumByTasksList(arr, 100000);
            CalcSumByTasksList(arr, 1000000);
            CalcSumByTasksList(arr, 10000000);

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Параллельное с помощью LINQ вычисление суммы элементов массива интов");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();

            CalcSumParallel(arr, 100000);
            CalcSumParallel(arr, 1000000);
            CalcSumParallel(arr, 10000000);

            Console.ReadKey();
        }

        /// <summary>
        /// Обычное вычисление суммы элементов массива интов
        /// </summary>
        /// <param name="arr">Массив интов</param>
        /// <param name="iterationsCount">Число итеарций</param>
        private static void CalcSumNormal(int[] arr, int iterationsCount)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int sum = 0;
            for (int i = 0; i < iterationsCount; i++)
            {
                sum = SumArr(arr);
            }

            stopwatch.Stop();

            Console.WriteLine($"Сумма элементов массива (Обычное) = {sum}, время выполнения {iterationsCount} итераций = {stopwatch.ElapsedMilliseconds} мс");
        }

        /// <summary>
        /// Параллельное вычисление суммы элементов массива интов  (List<Task>)
        /// </summary>
        /// <param name="arr">Массив интов</param>
        /// <param name="iterationsCount">Число итеарций</param>
        private static void CalcSumByTasksList(int[] arr, int iterationsCount)
        {
            var tasks = new List<Task>();
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int sum = 0;
            for (int i = 0; i < iterationsCount; i++)
            {
                Task t = Task.Run(() => sum = SumArr(arr));
                tasks.Add(t);
            }

            Task.WhenAll(tasks);

            stopwatch.Stop();

            Console.WriteLine($"Сумма элементов массива (Параллельное с List<Task>) = {sum}, время выполнения {iterationsCount} тасков = {stopwatch.ElapsedMilliseconds} мс");
        }

        /// <summary>
        /// Параллельное с помощью LINQ вычисление суммы элементов массива интов
        /// </summary>
        /// <param name="arr">Массив интов</param>
        /// <param name="iterationsCount">Число итеарций</param>
        private static void CalcSumParallel(int[] arr, int iterationsCount)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int sum = 0;
            ParallelLoopResult res = Parallel.ForEach(Enumerable.Range(1, iterationsCount), (_) => sum = SumArr(arr));

            if (res.IsCompleted)
            {
                stopwatch.Stop();
                Console.WriteLine($"Сумма элементов массива (Параллельное с Parallel.Foreach) = {sum}, время выполнения {iterationsCount} таскво = {stopwatch.ElapsedMilliseconds} мс");
            }
            }

        /// <summary>
        /// Вычислиение суммы элементов массива интов
        /// </summary>
        /// <param name="arr">Массив интов</param>
        /// <returns>Рассчитанная сумма элементов массива интов</returns>
        private static int SumArr(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
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
                arr[i] = rnd.Next(0, 255);
            }

            return arr;
        }
    }
}