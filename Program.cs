using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace cs_async
{
    [MemoryDiagnoser]
    public class AcyncBench
    {
        internal readonly Worker Worker;

        public AcyncBench()
        {
            Worker = new Worker();
        }

        [Benchmark]
        public async System.Threading.Tasks.Task Test1()
        {
            Trace.WriteLine("\nTest1");
            var worker = new Worker();
            // await async task
            await worker.DoSomethingAsync().ConfigureAwait(false);
            Trace.WriteLine("Hello World!");
        }

        [Benchmark]
        public async System.Threading.Tasks.Task Test2()
        {
            Trace.WriteLine("\nTest2");
            var worker = new Worker();
            // create task but await it later
            Task task = worker.DoSomethingAsync();
            Trace.WriteLine("Hello World!");
            await task.ConfigureAwait(false);
        }

        [Benchmark]
        public async System.Threading.Tasks.Task Test3()
        {
            Trace.WriteLine("\nTest3");
            var worker = new Worker();
            // create task but await it later
            var task = worker.DoSomethingAsyncValue();
            var value = await task.ConfigureAwait(false);
            Trace.WriteLine($"Hello World! {value}");
        }
    }

    internal static class Program
    {
        private static void Main(string[] _) => BenchmarkRunner.Run<AcyncBench>();
    }
}
