using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 访问者模式2
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure o = new ObjectStructure();
            o.Attach(new Man());
            o.Attach(new Woman());

            Success v1 = new Success();
            o.Display(v1);

            Marriage v2 = new Marriage();
            o.Display(v2);
        }
    }
    abstract class Action
    {
        public abstract void GetManConclusion(Man concreteElementA);
        public abstract void GetWomanConclusion(Woman concreteElementB);
    }
    abstract class Person
    {
        public abstract void Accept(Action visitor);
    }
    class Success : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine("{0}{1}时, 背后多半有一个伟大的女人", concreteElementA.GetType().Name, GetType().Name);
        }

        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine("{0}{1}时, 背后多半有一个不成功的男人", concreteElementB.GetType().Name, GetType().Name);
        }
    }
    class Marriage : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine("{0}{1}时, 感慨有期徒刑",concreteElementA.GetType().Name, GetType().Name);
        }

        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine("{0}{1}时, 婚姻保险保平安", concreteElementB.GetType().Name, GetType().Name);
        }
    }
    class Man : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetManConclusion(this);
        }
    }
    class Woman : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetWomanConclusion(this);
        }
    }
    class ObjectStructure
    {
        private IList<Person> elements = new List<Person>();

        public void Attach(Person element)
        {
            elements.Add(element);
        }

        public void Detach(Person element)
        {
            elements.Remove(element);
        }

        public void Display(Action visitor)
        {
            foreach(Person e in elements)
            {
                e.Accept(visitor);
            }
        }
    }
}
