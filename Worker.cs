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
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            value *= 2;

            // асихронно ожидать одну секунду
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            Trace.WriteLine(value);
        }
    }
}
