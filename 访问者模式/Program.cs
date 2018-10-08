using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 访问者模式
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
            foreach(Person item in persons)
            {
                item.GetConclusion();
            }
        }
    }
    abstract class Person
    {
        public string Action { get; set; }
        public abstract void GetConclusion();
    }
    class Man : Person
    {
        public override void GetConclusion()
        {
            if(Action == "成功")
            {
                Console.WriteLine("{0}{1}时, 背后多半有一个伟大的女人", this.GetType().Name, Action);
            }
            else if (Action == "失败")
            {
                Console.WriteLine("{0}{1}时, 闷头喝酒", this.GetType().Name, Action);
            }
            else if (Action == "恋爱")
            {
                Console.WriteLine("{0}{1}时, 凡事不懂也要装懂. ",this.GetType().Name,Action);
            }
        }
    }
    class Woman : Person
    {
        public override void GetConclusion()
        {
            if (Action == "成功")
            {
                Console.WriteLine("{0}{1}时, 背后多半有一个不成功的男人", this.GetType().Name, Action);
            }
            else if (Action == "失败")
            {
                Console.WriteLine("{0}{1}时, 眼泪汪汪", this.GetType().Name, Action);
            }
            else if (Action == "恋爱")
            {
                Console.WriteLine("{0}{1}时, 凡事懂也要装不懂. ", this.GetType().Name, Action);
            }
        }
    }
}
