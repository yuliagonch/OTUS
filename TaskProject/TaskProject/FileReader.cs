using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{
    internal class FileReader
    {
        public FileReader() { }

        public int CalcCharsNum(string FileName, char ch)
        {
            int res = 0;

            if (String.IsNullOrEmpty(FileName))
                return res;

            if (!File.Exists(FileName))
            {
                Console.WriteLine($"Файл {FileName} не существует");
                return res;
            }
            
            try
            {
                res = File.ReadAllText(FileName).Count(x => x == ch);

                Console.WriteLine($"{res} символов '{ch}' в файле {FileName}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка расчета количества символов {ch} в файле {FileName}: {ex.Message}");
            }

            return res;
        }

        public void CalcCharsNumByPath(string path, char ch)
        {
            var fileNamesList = this.GetFileNames(path);
            var tasksList = new List<Task>();
            foreach (var file in fileNamesList)
                tasksList.Add(Task.Run(() => this.CalcCharsNum(file, ch)));
            Task.WaitAll(tasksList.ToArray());
        }

        public List<string> GetFileNames(string path)
        {
            List<string> fileNames = new List<string>();

            try
            {
                if (String.IsNullOrEmpty(path))
                {
                    Console.WriteLine($"Пустой путь к папке с файлами {path}");
                    return fileNames;
                }

                if (!Directory.Exists(path))
                {
                    Console.WriteLine($"Пути {path} к папке с файлами не существует");
                    return fileNames;
                }

                var files = Directory.GetFiles(path);

                if (!files.Any())
                {
                    Console.WriteLine($"По пути {path} файлы не найдены");
                    return fileNames;
                }

                return files.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файлов по пути {path}: {ex.Message}");
            }

            return fileNames;
        }
    }
}
