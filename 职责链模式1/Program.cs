using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 职责链模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonManager jinli = new CommonManager("金利");
            MajorDomo zongjian = new MajorDomo("总监");
            GeneralManager zhongjingli = new GeneralManager("总经理");
            jinli.SetSuperior(zongjian);
            zongjian.SetSuperior(zhongjingli);  // 设置上级 , 完全可以根据需求来改变 .

            Request request = new Request
            {
                RequestType = "请假",
                RequestContent = "小菜请假",
                Number = 1
            };
            jinli.RequestApplication(request);

            Request request4 = new Request
            {
                RequestType = "加薪",
                RequestContent = "小菜要求加薪",
                Number = 1000
            };
            jinli.RequestApplication(request4);
        }
    }
    abstract class Manager
    {
        protected string name;
        protected Manager superior;
        public Manager(string name)
        {
            this.name = name;
        }
        public void SetSuperior(Manager manager)
        {
            this.superior = manager;
        }
        abstract public void RequestApplication(Request request);
    }
    class CommonManager : Manager
    {
        public CommonManager(string name):base(name)
        {

        }
        public override void RequestApplication(Request request)
        {
            if (request.RequestType == "请假" && request.Number <= 2)
            {
                Console.WriteLine("{0} : {1} 数量{2}被批准", name,request.RequestContent,request.Number);
            }
            else
            {
                if(superior!=null)
                {
                    superior.RequestApplication(request);
                }
            }
        }
    }
    class MajorDomo : Manager
    {
        public MajorDomo(string name) : base(name) { }
        public override void RequestApplication(Request request)
        {
            if(request.RequestType == "请假"&&request.Number<=5)
            {
                Console.WriteLine("{0} : {1} 数量{2}被批准", name, request.RequestContent, request.Number);
            }
            else
            {
                if (superior != null)
                {
                    superior.RequestApplication(request);
                }
            }
        }
    }
    class GeneralManager : Manager
    {
        public GeneralManager(string name) : base(name) { }
        public override void RequestApplication(Request request)
        {
            if (request.RequestType == "请假")
            {
                Console.WriteLine("{0} : {1} 数量{2}被批准", name, request.RequestContent, request.Number);
            }
            else if (request.RequestType == "加薪" && request.Number <= 500)
            {
                Console.WriteLine("{0} : {1} 数量{2}被批准", name, request.RequestContent, request.Number);
            }
            else if(request.RequestType=="加薪" && request.Number > 500)
            {
                Console.WriteLine("{0} : {1} 数量{2}再说吧", name, request.RequestContent, request.Number);
            }
        }
    }

    public class Request
    {
        public string RequestType { get; set; }
        public string RequestContent { get; set; }
        public int Number { get; set; }
    }
}
