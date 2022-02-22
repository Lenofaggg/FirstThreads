using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok21
{
    public class DataHolder
    {
        //очередь
        private Queue<string> _data = new Queue<string>();
        
        public void Put(string word) 
        {
            lock (_data)
            {
                _data.Enqueue(word);
            }
        }
        
        public string Take()
        {
            string word;
            lock (_data)
            {
                word = _data.Dequeue();
            }
            return word;
        }
        public int Count()
        {
            int count = 0;
            lock (_data)
            {
                count = _data.Count;
            }
            return count;
        }
    }
}
