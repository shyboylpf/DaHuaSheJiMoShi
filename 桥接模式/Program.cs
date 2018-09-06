using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction ab = new RefinedAbstraction();

            ab.SetImplementor(new ConcreteImplementorA());
            ab.Operation();

            ab.SetImplementor(new ConcreteImplementorB());
            ab.Operation();

            Abstraction ba = new RefinedBbstraction();
            ba.SetImplementor(new ConcreteImplementorA());
            ba.Operation();
        }
    }
    abstract class Implementor
    {
        public abstract void Operation();
    }
    class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现A的方法执行");
        }
    }
    class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("具体实现B的方法执行");
        }
    }

    class Abstraction
    {
        protected Implementor implementor;
        public void SetImplementor(Implementor implementor)
        {
            this.implementor = implementor;
        }
        public virtual void Operation()
        {
            implementor.Operation();
        }
    }
    class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            base.Operation();
        }
    }
    class RefinedBbstraction : Abstraction
    {
        public override void Operation()
        {
            base.Operation();
        }
    }
}
