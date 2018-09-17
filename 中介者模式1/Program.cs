using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 中介者模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitedNationsSecurityCouncil UNSC = new UnitedNationsSecurityCouncil();

            USA c1 = new USA(UNSC);
            Iraq c2 = new Iraq(UNSC);

            UNSC.Colleague1 = c1;
            UNSC.Colleague2 = c2;

            c1.Declare("不允许研制核武器");
            c2.Declare("我们没有核武器");
        }
    }
    // 联合国机构
    abstract class UnitedNations
    {
        public abstract void Declare(string message, Country colleague);
    }
    // 国家
    abstract class Country
    {
        protected UnitedNations mediator;
        public Country(UnitedNations mediator)
        {
            this.mediator = mediator;
        }
    }
    // 美国
    class USA : Country
    {
        public USA(UnitedNations mediator) : base(mediator) { }
        // 声明
        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }
        // 获得消息
        public void GetMessage(string message)
        {
            Console.WriteLine("美国获得对方消息: " + message);
        }
    }
    class Iraq : Country
    {
        public Iraq(UnitedNations mediator) : base(mediator) { }
        // 声明
        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }
        public void GetMessage(string message)
        {
            Console.WriteLine("伊拉克获得对方消息: " + message);
        }
    }
    class UnitedNationsSecurityCouncil : UnitedNations
    {
        private USA colleague1;
        private Iraq colleague2;
        public USA Colleague1 { set { colleague1 = value; } }
        public Iraq Colleague2 { set { colleague2 = value; } }
        public override void Declare(string message, Country colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.GetMessage(message);
            }
            else
            {
                colleague1.GetMessage(message);
            }
        }
    }
}
