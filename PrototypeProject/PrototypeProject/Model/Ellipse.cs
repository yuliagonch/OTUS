using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeProject.Model
{
    /// <summary>
    /// Класс Эллипс наследуется от класса Прямоугольник
    /// </summary>
    internal class Ellipse: Rectangle
    {
        private int _radiusX;
        private int _radiusY;

        public Ellipse(int radiusX, int radiusY, string name)
            : base(radiusX, radiusY, name)
        {
            this._radiusX = radiusX;
            this._radiusY = radiusY;
        }

        public override IMyCloneable Clone(string name)
        {
            return new Ellipse(this._radiusX, this._radiusY, name);
        }

        public override void GetInfo()
        {
            Console.WriteLine($"{this.Name} с полуосями {this._radiusX}, {this._radiusY}");
        }
    }
}
