using System;

namespace SingletonDemo
{
    class Program
    {
        private static System.Timers.Timer timer;
        private static int count = 0;
        static void Main(string[] args)
        {
            timer = new System.Timers.Timer(1000);

            //设置执行一次（false）还是一直执行(true)
            timer.AutoReset = true;
            //设置是否执行System.Timers.Timer.Elapsed事件
            timer.Enabled = true;
            //绑定Elapsed事件
            timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerUp);
            Console.ReadKey();
        }

        private static void TimerUp(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (count++ == 5)
            {
                timer.Stop();
            }

            TestSingleton.InterlockedMethod();

            TestSingleton.MethodImplOptionsMethod();

            TestSingleton.LockMethod();
        }
    }
}
