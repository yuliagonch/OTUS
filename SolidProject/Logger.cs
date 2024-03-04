using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidProject
{
    public class Logger: ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message)
        {
            Console.Error.WriteLine(message);
        }
    }

    // O - Open-Closed Principle - принцип открытости-закрытости
    // Если потребуется изменить реализацию логгера и сделать другой, 
    // создаем новый класс, наследуемся от ILogger или пишем доп. интерфейс с доп. функциональностью
    public class NewCustomLoger: ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message)
        {
            Console.WriteLine("*****Start logger error*****");
            Console.WriteLine(message);
            Console.WriteLine("*****End logger error*****");
        }
    }
}
