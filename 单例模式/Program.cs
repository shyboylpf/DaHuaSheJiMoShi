using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton1 = Singleton.GetInstance();
            Singleton singleton2 = Singleton.GetInstance();
            if (singleton1 == singleton2)
            {
                Console.WriteLine("两个对象是相同实例");
            }

        }
    }
    class Singleton
    {
        private static Singleton instance;
        private Singleton() { } // 构造方法让其private , 这就堵死了外界利用new创建此类实例的可能
        public static Singleton GetInstance()
        {
            if(instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
