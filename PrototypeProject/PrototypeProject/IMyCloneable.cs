using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeProject
{
    internal interface IMyCloneable<T> where T : class
    {
        T Clone(string name);
        void GetInfo();
    }
}
