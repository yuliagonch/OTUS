using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesProject
{
    public class FilesHelper
    {
        // Происходит при нахождении каждого файла по пути path в методе SearchFiles
        public event EventHandler FileFound;
        
        public FilesHelper() { }
        
        public void SearchFiles(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Путь {path} не существует");
                return;
            }

            var files = Directory.GetFiles(path);

            if (!files.Any())
            {
                Console.WriteLine($"По пути {path} файлы не найдены");
                return;
            }

            Console.WriteLine("\n Нажмите 'Escape' для отмены поиска файлов \n");

            foreach (var file in files)
            {
                Thread.Sleep(500);
                
                if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Поиск файлов остановлен нажатием на 'Escape'");
                    break;
                }

                FileFound?.Invoke(this, new FileArgs { FileName = file});
            }
        }
    }

    public class FileArgs : EventArgs
    {
        public string FileName { get; set; }
    }
}
