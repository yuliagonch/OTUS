using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidProject
{
    public class Settings: ISettings
    {
        public int AttemptsCount { get => _attemptsCount; }
        public int MinNumber { get => _minNumber; }
        public int MaxNumber { get => _maxNumber; }
        
        public Settings()
        {
            _attemptsCount = 1;
            _minNumber = 0;
            _maxNumber = 10;
        }

        public Settings(int attemptsCount, int minNumber, int maxNumber)
        {
            _attemptsCount = attemptsCount;
            _minNumber = minNumber;
            _maxNumber = maxNumber;
        }

        public void ShowSettings()
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("--------------------Настройки программы---------------------------");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Количество попыток отгадывания = {_attemptsCount}");
            Console.WriteLine($"Минимальное число = {_minNumber}");
            Console.WriteLine($"Максимальное число = {_maxNumber}");
            Console.WriteLine("------------------------------------------------------------------");
        }

        public void EditSettings(ILogger logger)
        {
            try
            {
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("--------------Редактирование настроек программы--------------------");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine();

                Console.Write("Введите количество попыток отгадывания = ");
                _attemptsCount = int.Parse(Console.ReadLine());

                Console.Write("Введите минимальное число = ");
                _minNumber = int.Parse(Console.ReadLine());

                Console.Write("Введите максимальное число = ");
                _maxNumber = int.Parse(Console.ReadLine());

                Console.Clear();
                Program.Init();
            }
            catch (Exception ex)
            {

            }
        }

        private int _attemptsCount;
        private int _minNumber;
        private int _maxNumber;
    }
}
