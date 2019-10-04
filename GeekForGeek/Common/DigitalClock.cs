using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeekForGeek.Common
{
    public static class DigitalClock
    {
        public static void ShowTime(CancellationTokenSource cancellationTokenSource)
        {
            var token = cancellationTokenSource.Token;

            Task.Run(() =>
            {
                try
                {
                    while (!cancellationTokenSource.IsCancellationRequested)
                    {
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();

                        //Long operation here...
                        Console.WriteLine(DateTime.Now.ToString());
                        Console.WriteLine("\a");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                finally
                {
                    //Do some cleanup
                    Console.WriteLine("Digital Clock Cancelled.");
                }
            }, token);
        }

        public static void LongRunTask()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            Task.Factory.StartNew(() => ShowTime(cancellationTokenSource), TaskCreationOptions.LongRunning);

            if (Console.Read() == 'q')
            {
                cancellationTokenSource.Cancel();
            }

            //Task t = Task.Factory.StartNew(
            //    () => ShowTime(),
            //    cancellationTokenSource.Token,
            //    TaskCreationOptions.LongRunning,
            //    TaskScheduler.Default);
        }
    }
}
