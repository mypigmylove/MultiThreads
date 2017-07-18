using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th=new Thread((() =>
            {
                for (int i = 0; i < 300; i++)
                {
                    Console.WriteLine("YYY");
                }
            }));

            th.Start();
            th.Join();

            Console.WriteLine("th is end");
            Console.ReadLine();
        }
    }
}
