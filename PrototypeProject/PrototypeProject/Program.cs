

using PrototypeProject.Model;

namespace PrototypeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMyCloneable square = new Square(10, "Квадрат");
            IMyCloneable clonedSquare = square.Clone("Прототип квадрата");
            Console.WriteLine("Исходная фигура:");
            square.GetInfo();
            Console.WriteLine("Клонированная фигура:");
            clonedSquare.GetInfo();

            Console.WriteLine("");
            Shape circle = new Circle(99, "Круг");
            Shape clonedCircle = (Shape)circle.Clone();
            Console.WriteLine("Исходная фигура:");
            circle.GetInfo();
            Console.WriteLine("Клонированная фигура:");
            clonedCircle.GetInfo();

            Console.ReadKey();
        }
    }
}
