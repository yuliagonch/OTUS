
using System;
using System.Diagnostics;
using TaskProject;

namespace TaskProject
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Stopwatch stopwatch = new Stopwatch();
            var fileReader = new FileReader();

            Console.WriteLine("Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task)");
            stopwatch.Start();

            Task[] tasks = new Task[3];
            tasks[0] = Task.Run(() => fileReader.CalcCharsNum(Path.Combine(Environment.CurrentDirectory, "Files\\File1.txt"), ' '));
            tasks[1] = Task.Run(() => fileReader.CalcCharsNum(Path.Combine(Environment.CurrentDirectory, "Files\\File2.json"), ' '));
            tasks[2] = Task.Run(() => fileReader.CalcCharsNum(Path.Combine(Environment.CurrentDirectory, "Files\\File3.txt"), ' '));
            Task.WaitAll(tasks);

            stopwatch.Stop();
            Console.WriteLine("");
            Console.WriteLine($"Время чтения 3 файлов = {stopwatch.ElapsedMilliseconds} мс");

            Console.WriteLine("");
            Console.WriteLine("Прочитать все файлы из папки и вычислить количество пробелов в них");
            stopwatch.Start();

            string path = Path.Combine(Environment.CurrentDirectory, "Files");
            fileReader.CalcCharsNumByPath(path, ' ');

            stopwatch.Stop();
            Console.WriteLine("");
            Console.WriteLine($"Время чтения файлов из папки {path} = {stopwatch.ElapsedMilliseconds} мс");

            Console.ReadKey();
        }
    }
}
