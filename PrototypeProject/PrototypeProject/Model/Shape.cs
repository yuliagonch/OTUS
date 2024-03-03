using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeProject.Model
{
    /// <summary>
    /// Базовый класс Фигура
    /// </summary>
    internal class Shape: IMyCloneable<Shape>, ICloneable
    {
        public string Name { get { return _name; } }

        public Shape(string name)
        {
            _name = name;
        }

        public virtual Shape Clone(string name)
        {
            return new Shape(name);
        }

        public virtual void GetInfo()
        {
            Console.WriteLine(_name);
        }

        public object Clone()
        {
            return this.Clone(_name);
        }

        private string _name;
    }
}
