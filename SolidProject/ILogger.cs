using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidProject
{
    // I - Interface Segregation Principle - принцип разделения интерфейса
    public interface ILogger
    {
        void Info(string message);
        void Error(string message);
    }
}
