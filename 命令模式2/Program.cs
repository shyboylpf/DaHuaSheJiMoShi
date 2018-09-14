using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式2
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Command c = new ConcreteCommand(receiver);
            Invoker i = new Invoker();

            i.SetCommand(c);
            i.ExecuteCommand();
        }
    }
    abstract class Command
    {
        protected Receiver receiver;
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        abstract public void Execute();
    }
    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver) { }
        public override void Execute()
        {
            receiver.Action();
        }
    }
    class Invoker
    {
        private Command command;
        public void SetCommand(Command command)
        {
            this.command = command;
        }
        public void ExecuteCommand()
        {
            command.Execute();
        }
    }

    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("执行请求!");
        }
    }
}
