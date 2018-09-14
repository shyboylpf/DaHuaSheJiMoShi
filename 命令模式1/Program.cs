using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令模式1
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
            waiter.SetOrder(bakeMuttonCommand2);
            waiter.SetOrder(bakeChikenWingCommand1);
            waiter.CancelOrder(bakeMuttonCommand1);
            waiter.SetOrder(bakeMuttonCommand2);
            // 点完菜通知厨房
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
        private IList<Command> orders = new List<Command>();
        public void SetOrder(Command command)
        {
            if (command.ToString() == "命令模式1.BakeChickenWingCommand")  // 鸡翅没了的意思
            {
                Console.WriteLine("服务员 : 鸡翅没了有 , 请点别的烧烤. ");
            }
            else
            {
                orders.Add(command);
                Console.WriteLine("增加订单 : "+command.ToString() + " 时间 : "+DateTime.Now.ToString());
            }
        }
        public void CancelOrder(Command command)
        {
            orders.Remove(command);
            Console.WriteLine("取消订单 : " + command.ToString() + " 时间 : " + DateTime.Now.ToString());
        }
        public void Notify()
        {
            foreach(Command command in orders)
            {
                command.ExcuteComman();
            }
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
