using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 职责链模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler handler1 = new ConcreteHandler1();
            Handler handler2 = new ConcreteHandler2();
            Handler handler3 = new ConcreteHandler3();
            handler1.SetSuccessor(handler2);
            handler2.SetSuccessor(handler3);

            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };
            foreach(int request in requests)
            {
                handler1.HandleRequest(request);
            }
        }
    }
    abstract class Handler
    {
        protected Handler successor;
        public void SetSuccessor(Handler handler)
        {
            this.successor = handler;
        }
        public abstract void HandleRequest(int request);
    }
    class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if(request >= 0 && request < 10)
            {
                Console.WriteLine("{0} 处理请求 {1}" ,this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if(request >= 10 && request < 20)
            {
                Console.WriteLine("{0}处理请求{1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
    class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if(request >=20 && request < 30)
            {
                Console.WriteLine("{0}处理请求{1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}
