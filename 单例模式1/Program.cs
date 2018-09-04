using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式1
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Sinleton
    {
        private static Sinleton instance;
        private static readonly object syncRoot = new object();
        private Sinleton() { }
        public static Sinleton GetSinleton()
        {
            lock (syncRoot) // 在同一个时刻加了锁的那部分程序只有一个线程可以进入 .
            {
                if (instance == null)
                {
                    instance = new Sinleton();
                }
            }
            return instance;
        }
    }
}
