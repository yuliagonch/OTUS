

namespace DelegatesProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Поиск максимального элемента коллекции");
            Console.WriteLine("------------------------------------------------------------------");

            List<string> list = new List<string> { "12345", "hfgb", "-12", "12345,345", "jdh546jdhj" };

            var max = list.GetMax(x =>
            {
                try
                {
                    return Convert.ToSingle(x);
                }
                catch
                {
                    return float.MinValue;
                }
            });

            Console.WriteLine($"Max = {max}");

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Поиск файлов в папке");
            Console.WriteLine("------------------------------------------------------------------");

            Console.WriteLine(@"Введите путь к папке для поиска в ней файлов. Пример: 'C:\Temp\'");
            string path = Console.ReadLine();

            FilesHelper filesHelper = new FilesHelper();
            filesHelper.FileFound += (sender, e) =>
            {
                if (e is FileArgs args)
                    Console.WriteLine($"Найден файл {args.FileName}");
            };
            filesHelper.SearchFiles(path);


            Console.ReadKey();
        }
    }
}
