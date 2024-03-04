using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidProject
{
    // I - Interface Segregation Principle - принцип разделения интерфейса
    public interface ISettings
    {
        void ShowSettings();
        void EditSettings(ILogger logger);
        public int AttemptsCount { get; }
        public int MinNumber { get; }
        public int MaxNumber { get; }
    }
}
