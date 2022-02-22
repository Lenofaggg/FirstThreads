using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Potok21
{
    class Consumer
    {
        Thread _thread;
        DataHolder _holder;
        StreamWriter _sw;

        bool _stop = false;

        public Consumer(DataHolder holder, StreamWriter sw)
        {
            _holder = holder;
            _sw = sw;
        }

        public void Run()
        {
            _thread = new Thread(Print);
            _thread.Start();
            Thread.Sleep(100);
        }

        public void Break()
        {           
            _stop = true;
            _thread.Join();
        }
        private void Print()
        {
            
            while (_stop != true)
            {
                if (_holder.Count() == 0)
                    continue;

                while (_holder.Count() != 0)
                {
                    string line = _holder.Take();
                    _sw.WriteLine(line);                    
                }               
            }           
            _sw.Close();
        }
    }
}
