using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeProject
{
    internal interface IMyCloneable
    {
        IMyCloneable Clone(string name);
        void GetInfo();
    }
}
