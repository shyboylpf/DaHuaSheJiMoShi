using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 解释器模式2
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayContext context = new PlayContext();
            // 音乐
            Console.WriteLine("上海滩: ");
            context.PlayText = "O 2 E 0.5 G 0.5 A 3";
            Expression expression = null;
            try
            {
                while (context.PlayText.Length > 0)
                {
                    string str = context.PlayText.Substring(0, 1);
                    switch (str)
                    {
                        case "O":
                            expression = new Scale();
                            break;
                        case "C":
                        case "D":
                        case "E":
                        case "F":
                        case "G":
                        case "A":
                        case "B":
                        case "P":
                            expression = new Note();
                            break;
                    }
                    expression.Interpret(context);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class PlayContext
    {
        public string PlayText { get; set; }
    }
    abstract class Expression
    {
        public void Interpret(PlayContext playContext)
        {
            if(playContext.PlayText.Length==0)
            {
                return;
            }
            else
            {
                string playKey = playContext.PlayText.Substring(0, 1);
                playContext.PlayText = playContext.PlayText.Substring(2);
                double playValue = Convert.ToDouble(playContext.PlayText.Substring(0, playContext.PlayText.IndexOf(" ")));
                playContext.PlayText = playContext.PlayText.Substring(playContext.PlayText.IndexOf(" ") + 1);
                Excute(playKey, playValue);
            }
        }
        public abstract void Excute(string key, double value);
    }
    class Note : Expression
    {
        public override void Excute(string key, double value)
        {
            string note = "";
            switch(key)
            {
                case "C":
                    note = "1";
                    break;
                case "D":
                    note = "2";
                    break;
                case "E":
                    note = "3";
                    break;
                case "F":
                    note = "4";
                    break;
                case "G":
                    note = "5";
                    break;
                case "A":
                    note = "5";
                    break;
                case "B":
                    note = "7";
                    break;
            }
            Console.Write("{0} ", note);
        }
    }
    class Scale : Expression
    {
        public override void Excute(string key, double value)
        {
            string scale = "";
            switch (Convert.ToInt32(value))
            {
                case 1:
                    scale = "低音";
                    break;
                case 2:
                    scale = "中音";
                    break;
                case 3:
                    scale = "高音";
                    break;
            }
            Console.WriteLine("{0} ", scale);
        }
    }
    class Speed : Expression
    {
        public override void Excute(string key, double value)
        {
            string speed;
            if (value < 500)
            {
                speed = "快速";
            }
            else if (value >= 1000)
            {
                speed = "慢速";
            }
            else
            {
                speed = "中速";
            }
            Console.WriteLine("{0} ", speed);
        }
    }
}
