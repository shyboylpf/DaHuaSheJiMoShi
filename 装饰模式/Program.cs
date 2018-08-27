using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 装饰模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            d1.setComponent(c);
            d2.setComponent(d1);
            d2.Operation();

        }
    }
    // 第二版
    abstract class Component
    {
        public abstract void Operation();
    }
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("具体对象的操作");
        }
    }
    // Decorator类
    abstract class Decorator : Component
    {
        protected Component component;
        public void setComponent(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component!=null)
            {
                component.Operation();
            }
        }
    }
    // ConcreteDecoratorA类
    class ConcreteDecoratorA : Decorator
    {
        private string addedState;
        public override void Operation()
        {
            base.Operation();
            addedState = "New State";
            Console.WriteLine("具体装饰对象A的操作");
        }
    }
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("具体装饰对象B的操作");
        }

        private void AddedBehavior()
        {
            Console.WriteLine("具体装饰对象B的独有操作");
        }
    }
}
