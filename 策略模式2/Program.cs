using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // 抽象算法类
    abstract class Strategy
    {
        // 算法方法
        public abstract void AlgorithmInterface();
    }

    // 具体算法A
    class ConcreteStrategyA : Strategy
    {
        // 实现算法A
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法A实现");
        }
    }
    class Context
    {
        Strategy strategy;
        public Context(Strategy strategy)  // 传入具体的策略对象
        {
            this.strategy = strategy;
        }
        // 上下文接口
        public void ContextInterface()  // 根据具体的策略对象 , 调用其算法的方法.
        {
            strategy.AlgorithmInterface();
        }
    }
}
