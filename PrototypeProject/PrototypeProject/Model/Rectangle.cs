using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeProject.Model
{
    /// <summary>
    /// Класс Прямоугольник наследует от базового класса Фигура
    /// </summary>
    internal class Rectangle : Shape
    {
        private int _width;
        private int _height;

        public Rectangle(int width, int height, string name)
        : base(name)
        {
            this._width = width;
            this._height = height;
        }

        public override IMyCloneable Clone(string name)
        {
            return new Rectangle(this._width, this._height, name);
        }

        public override void GetInfo()
        {
            Console.WriteLine($"{this.Name} со сторонами {this._width}, {this._height}");
        }
    }
}
