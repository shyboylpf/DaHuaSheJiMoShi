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
            IList<Person> persons = new List<Person>();

            Person man1 = new Man();
            man1.Action = "成功";
            persons.Add(man1);
            Person woman1 = new Woman();
            woman1.Action = "成功";
            persons.Add(woman1);
            foreach (Person item in persons)
            {
                item.GetConclusion();
            }
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
}
