using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace SingletonDemo
{
    public class TestSingleton
    {
        private static int _dealing = 0;

        /// <summary>
        /// 不会等待，直接提示方法进入失败
        /// </summary>
        public static void InterlockedMethod()
        {
            if (Interlocked.CompareExchange(ref _dealing, 1, 0) == 0)
            {
                Console.WriteLine("Interlocked方法进入成功!" + DateTime.Now);

                Thread.Sleep(3000);

                Interlocked.Exchange(ref _dealing, 0);
            }
            else
            {
                Console.WriteLine("Interlocked方法进入失败!" + DateTime.Now);
            }
        }

        /// <summary>
        /// 方法会等待,必须是静态方法
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void MethodImplOptionsMethod()
        {
            Console.WriteLine("MethodImplOptionsMethod方法进入成功!" + DateTime.Now);

            Thread.Sleep(3000);
        }

        private static readonly object SequenceLock = new object();

        /// <summary>
        /// 方法会等待
        /// </summary>
        public static void LockMethod()
        {
            lock (SequenceLock)
            {
                Console.WriteLine("LockMethod方法进入成功!" + DateTime.Now);

                Thread.Sleep(3000);
            }
        }

    }
}
