using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace cs_async
{
    public class Worker
    {
        public async Task DoSomethingAsync()
        {
            int value = 13;

            // асихронно ожидать одну секунду
            await Task.Delay(TimeSpan.FromSeconds(1));

            value *= 2;

            // асихронно ожидать одну секунду
            await Task.Delay(TimeSpan.FromSeconds(1));

            Trace.WriteLine(value);
        }
    }
}
