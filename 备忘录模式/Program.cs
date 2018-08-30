using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 备忘录模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator o = new Originator();
            o.State = "On";
            o.Show();

            Caretaker c = new Caretaker();
            c.memento = o.CreateMemento();

            o.State = "Off";
            o.Show();

            o.SetMemento(c.memento);
            o.Show();
        }
    }
    class Memento
    {
        public string State { get; set; }
        public Memento(string state)
        {
            State = state;
        }
    }
    class Originator
    {
        public string State { get; set; }
        public Memento CreateMemento()
        {
            return new Memento(State);
        }
        public void SetMemento(Memento memento)
        {
            State = memento.State;
        }
        public void Show()
        {
            Console.WriteLine(State);
        }
    }
    class Caretaker
    {
        public Memento memento { get; set; }
    }
}
