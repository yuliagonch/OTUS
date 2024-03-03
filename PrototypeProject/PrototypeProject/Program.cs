

using PrototypeProject.Model;

namespace PrototypeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape square = new Square(10, "Квадрат");
            // Клонирование объекта через кастомный IMyCloneable
            Shape clonedSquare = square.Clone("Прототип квадрата");
            Console.WriteLine("Исходная фигура:");
            square.GetInfo();
            Console.WriteLine("Клонированная фигура:");
            clonedSquare.GetInfo();

            Console.WriteLine("");
            Shape circle = new Circle(99, "Круг");
            // Клонирование объекта через системный ICloneable,
            // из-за чего приходится делать преобразование типов
            Shape clonedCircle = (Shape)circle.Clone();
            // Клонирование объекта через кастомный IMyCloneable
            Shape prototypeCircle = circle.Clone("Прототип круга");
            Console.WriteLine("Исходная фигура:");
            circle.GetInfo();
            Console.WriteLine("Клонированная фигура:");
            clonedCircle.GetInfo();
            Console.WriteLine("Еще одна клонированная фигура:");
            prototypeCircle.GetInfo();

            Console.ReadKey();
        }
    }
}
