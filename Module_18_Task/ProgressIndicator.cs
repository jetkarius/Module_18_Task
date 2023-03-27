using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_18_Task
{
    public class ProgressIndicator : IProgress<double>, IDisposable
    {
        private readonly int _positionX;
        private readonly int _positionY;

        public ProgressIndicator()
        {
            _positionX = Console.CursorLeft;
            _positionY = Console.CursorTop;
        }

        public void Report(double progress)
        {
            Console.SetCursorPosition(_positionX, _positionY);
            Console.WriteLine($"{progress:P1}");
        }

        public void Dispose()
        {
            Console.SetCursorPosition(_positionX, _positionY);
        }
    }
}
