using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "daniao";
            a[1] = "xiaocai";
            a[2] = "xingli";
            a[3] = "laowai";
            a[4] = "neibuyuangong";
            a[5] = "xiaotou";

            Iterator i = new ConcreateIterator(a);
            object item = i.First();
            while(!i.IsDone())
            {
                Console.WriteLine($"{i.CurrentItem()} 请买票");
                i.Next();
            }
        }
    }
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }
    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }
    class ConcreateIterator : Iterator
    {
        private ConcreteAggregate aggregate;
        private int current = 0;
        public ConcreateIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }
        public override object CurrentItem()
        {
            return aggregate[current];
        }

        public override object First()
        {
            return aggregate[0];
        }

        public override bool IsDone()
        {
            return current >= aggregate.Count;
        }

        public override object Next()
        {
            object ret = null;
            current++;
            if (current < aggregate.Count)
            {
                ret = aggregate[current];
            }
            return ret;
        }
    }
    class ConcreteAggregate : Aggregate
    {
        private IList<object> items = new List<object>();

        public override Iterator CreateIterator()
        {
            return new ConcreateIterator(this);
        }
        public int Count { get { return items.Count; } }
        public object this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index,value); }
        }
    }
}
