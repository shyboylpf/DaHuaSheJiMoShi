using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Barbecuer barbecuer = new Barbecuer();
            Command bakeMuttonCommand1 = new BakeMuttonCommand(barbecuer);
            Command bakeMuttonCommand2 = new BakeMuttonCommand(barbecuer);
            Command bakeChikenWingCommand1 = new BakeChickenWingCommand(barbecuer);
            Waiter waiter = new Waiter();

            waiter.SetOrder(bakeMuttonCommand1);
            waiter.Notify();
            waiter.SetOrder(bakeMuttonCommand2);
            waiter.Notify();
            waiter.SetOrder(bakeChikenWingCommand1);
            waiter.Notify();
        }
    }

    public abstract class Command
    {
        protected Barbecuer receiver;
        public Command(Barbecuer receiver)
        {
            this.receiver = receiver;
        }
        abstract public void ExcuteComman();
    }

    class BakeMuttonCommand : Command
    {
        public BakeMuttonCommand(Barbecuer receiver) : base(receiver) { }
        public override void ExcuteComman()
        {
            receiver.BakeMutton();
        }
    }
    class BakeChickenWingCommand : Command
    {
        public BakeChickenWingCommand(Barbecuer receiver) : base(receiver) { }
        public override void ExcuteComman()
        {
            receiver.BakeChickenWing();
        }
    }

    public class Waiter
    {
        private Command command;
        public void SetOrder(Command command)
        {
            this.command = command;
        }
        public void Notify()
        {
            command.ExcuteComman();
        }
    }

    public class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("烤羊肉串!");
        }
        public void BakeChickenWing()
        {
            Console.WriteLine("烤鸡翅!");
        }
    }
}
