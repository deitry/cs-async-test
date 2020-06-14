using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace cs_async
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            await Test1();
            await Test2();
        }

        static async System.Threading.Tasks.Task Test1()
        {
            Trace.WriteLine("\nTest1");
            var worker = new Worker();
            // await async task
            await worker.DoSomethingAsync();
            Trace.WriteLine("Hello World!");
        }

        static async System.Threading.Tasks.Task Test2()
        {
            Trace.WriteLine("\nTest2");
            var worker = new Worker();
            // create task but await it later
            Task task = worker.DoSomethingAsync();
            Trace.WriteLine("Hello World!");
            await task;
        }
    }
}
