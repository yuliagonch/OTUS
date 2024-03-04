using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidProject
{
    public class NumberGuessGame
    {
        public NumberGuessGame(ISettings settings, ILogger logger)
        {
            _settings = settings as Settings;
            _logger = logger;
        }

        public void StartGame()
        {
            _logger.Info("\nНачало игры");
            
            Random rnd = new Random();
            int number = rnd.Next(_settings.MinNumber, _settings.MaxNumber);

            if (!TryGuessNumber(number))
                Console.WriteLine($"К сожалению, вы не угадали число. Загадано было число {number}");

            _logger.Info("Конец игры");
        }

        private bool TryGuessNumber(int number)
        {
            try
            {
                int count = 1;
                do
                {
                    Console.WriteLine($"\nПопытка {count} из {_settings.AttemptsCount}.");
                    Console.Write($"Введите число в диапазоне от {_settings.MinNumber} до {_settings.MaxNumber}: ");
                    int userNumber = int.Parse( Console.ReadLine() );

                    if (userNumber == number)
                    {
                        Console.WriteLine("Угадали число!");
                        return true;
                    }
                    else if (userNumber > number)
                        Console.WriteLine("Ваше число больше загаданного");
                    else
                        Console.WriteLine("Ваше число меньше загаданного");

                    count++;

                } while (count <= _settings.AttemptsCount);

                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        private ISettings _settings;
        private ILogger _logger;
    }
}
