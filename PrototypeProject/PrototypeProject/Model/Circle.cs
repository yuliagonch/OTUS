using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeProject.Model
{
    /// <summary>
    /// Класс Круг наследуется от класса Квадрат
    /// </summary>
    internal class Circle: Square
    {
        private int _radius;

        public Circle(int radius, string name)
            : base(radius, name)
        {
            this._radius = radius;
        }

        public override Circle Clone(string name)
        {
            return new Circle(this._radius, name);
        }

        public override void GetInfo()
        {
            Console.WriteLine($"{this.Name} с радиусом {this._radius}");
        }
    }
}
