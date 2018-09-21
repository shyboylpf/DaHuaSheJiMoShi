using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 解释器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            IList<AbstractExpression> list = new List<AbstractExpression>();
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            foreach(AbstractExpression exp in list)
            {
                exp.InterPret(context);
            }

        }
    }
    abstract class AbstractExpression
    {
        public abstract void InterPret(Context context);
    }

    class TerminalExpression : AbstractExpression
    {
        public override void InterPret(Context context)
        {
            Console.WriteLine("终端解释器");
        }
    }

    class NonterminalExpression : AbstractExpression
    {
        public override void InterPret(Context context)
        {
            Console.WriteLine("非终端解释器");
        }
    }

    public class Context
    {
        public string Input { get;set; }
        public string Output { get; set; }

    }
    
}
