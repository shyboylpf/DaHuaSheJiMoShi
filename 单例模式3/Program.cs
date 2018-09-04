using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        private Singleton() { }
        public static Singleton GetSingleton()
        {
            return instance;
        }
    }
}
