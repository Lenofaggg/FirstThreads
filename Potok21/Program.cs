using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Potok21
{
    class Program
    {
        static void Main(string[] args)
        {
            DataHolder holder = new DataHolder();

            Console.WriteLine("Введите длинну cлова ");
            int length = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Введите путь к файлу ");
            //string path = Console.ReadLine();

            string path = @"..\..\тест\wrr.txt";

            char[] liters = new char[26];
            //заполнение символами
            for (int i = 65; i <= 90; i++)
                liters[i-65] = (char)i;

            Producer producer = new Producer(holder, liters, length);
            Consumer consumer = new Consumer(holder,new StreamWriter(path));

            producer.Run();
            consumer.Run();

            producer.Break();
            consumer.Break();

            Console.ReadKey();
        }
    }
}
