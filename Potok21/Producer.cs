using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Potok21
{
    class Producer
    {
        Thread _thread;
        DataHolder _holder;

        char[] _liters;
        int _length;

        bool _stop = false;

        public Producer(DataHolder holder, char[] liters, int length)
        {
            _holder = holder;
            _liters = liters;
            
            _length = length;
        }
        public void Run()
        {
            _thread = new Thread(Generate);
            _thread.Start();
        }

        public void Break()
        {            
            _stop = true;
            _thread.Join();
        }
        private void Generate()
        {
            StringBuilder line = new StringBuilder();
            Random rnd = new Random();
            while (_stop != true)
            {                  
                for (int j = 0; j < _length; j++)
                {
                    line.Append(_liters[rnd.Next(0, _liters.Length)]);
                    
                }                
               
                _holder.Put(line.ToString());
                line.Clear();                
            }
        }
    }
}
