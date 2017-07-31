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
            Thread th = new Thread((() =>
            {
                for (int i = 0; i < 300; i++)
                {
                    Console.WriteLine("YYY");
                }
            }));

            th.Start();
            th.Join();

            Task task = Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Foo");
            });

            Console.WriteLine(task.IsCompleted);
            task.Wait();

            Task<int> taskInt = Task.Run(() =>
                {
                    Thread.Sleep(10000);
                    Console.WriteLine("Foll2");
                    return 3;
                });

            var waiter=taskInt.GetAwaiter();

            waiter.OnCompleted(() =>
            {
                int result = waiter.GetResult();
                Console.WriteLine(waiter.IsCompleted);

            });

            taskInt.ContinueWith((task1 =>
            {
                int result1 = task1.Result;
                Console.WriteLine(result1);

            }));

            var tcs = new TaskCompletionSource<int>();

            new Thread(() =>
            {
                Thread.Sleep(5000);
                tcs.SetResult(54);
            }).Start();

            var qq = tcs.Task;
            Console.WriteLine(qq.GetAwaiter().GetResult());

            Console.WriteLine("th is end");
            Console.ReadLine();
        }
    }
}
