using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrototypeProject.Model
{
    /// <summary>
    /// Класс Квадрат наследует от базового класса Фигура
    /// </summary>
    internal class Square: Shape
    {
        private int _side;

        public Square(int side, string name)
        : base(name)
        {
            this._side = side;
        }

        public override IMyCloneable Clone(string name)
        {
            return new Square(this._side, name);
        }

        public override void GetInfo()
        {
            Console.WriteLine($"{this.Name} со стороной {this._side}");
        }
    }
}
