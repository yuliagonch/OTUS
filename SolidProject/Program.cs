
namespace SolidProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Init();

            ConsoleKeyInfo input;
            ILogger logger = new Logger();
            ILogger customLogger = new NewCustomLoger();
            Settings settings = new Settings();
            NumberGuessGame newGame = new NumberGuessGame(settings, logger);

            do
            {
                Console.WriteLine();
                Console.WriteLine("Нажмите клавишу из меню:");                
                input = Console.ReadKey();
                Console.WriteLine();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        settings.ShowSettings();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        settings.EditSettings(customLogger);
                        break;
                    default:
                        newGame.StartGame();
                        break;
                }

            } while (input.Key != ConsoleKey.Escape);
        }

        public static void Init()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("---------------------Игра \"Угадай число\"--------------------------");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("\"1\" - Настройки программы");
            Console.WriteLine("\"2\" - Редактирование настроек программы");
            Console.WriteLine("Any Key - старт программы");
            Console.WriteLine("Esc - Выход из программы");
            Console.WriteLine("------------------------------------------------------------------");
        }
    }
}