using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 状态模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            Work emergencyProjects = new Work();
            emergencyProjects.Hour = 9;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 10;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 12;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 13;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 14;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 17;
            emergencyProjects.TaskFinished = false;
            //emergencyProjects.TaskFinished = true;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 19;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 22;
            emergencyProjects.WriteProgram();

        }
    }
    public abstract class State
    {
        public abstract void WriteProgram(Work w);
    }
    public class ForenoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if(w.Hour < 12)
            {
                Console.WriteLine($"当前时间:{w.Hour} 点 , 上午");
            }
            else
            {
                w.SetState(new NonState());
                w.WriteProgram();
            }
        }
    }
    public class NonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 13)
            {
                Console.WriteLine($"当前时间:{w.Hour} 点 , 中午");
            }
            else
            {
                w.SetState(new AfternoonState());
                w.WriteProgram();
            }
        }
    }
    public class AfternoonState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour < 17)
            {
                Console.WriteLine($"当前时间:{w.Hour} 点 , 下午");
            }
            else
            {
                w.SetState(new EveningState());
                w.WriteProgram();
            }
        }
    }
    public class EveningState : State
    {
        public override void WriteProgram(Work w)
        {
            if (w.Hour > 20 && !w.TaskFinished)
            {
                w.SetState(new ForceEndWordState());
                w.WriteProgram();
            }
            else if (w.TaskFinished)
            {
                w.SetState(new RestState());
                w.WriteProgram();
            }
            else
            {
                if(w.Hour < 21)
                {
                    Console.WriteLine($"当前时间:{w.Hour} 点 , 晚上");
                }
                else
                {
                    w.SetState(new SleepState());
                    w.WriteProgram();
                }
                
            }
        }
    }
    public class SleepState: State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine($"当前时间:{w.Hour} 点 , 睡觉了");
        }
    }
    public class RestState : State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine($"当前时间:{w.Hour} 点 , 下班回家");
        }
    }
    public class ForceEndWordState : State
    {
        public override void WriteProgram(Work w)
        {
            Console.WriteLine($"当前时间:{w.Hour} 点 , 到20点了 , 强制下班回家");
        }
    }

    public class Work
    {
        private State current;
        public Work()
        {
            current = new ForenoonState();
        }
        public int Hour
        {
            get;set;
        }
        public bool TaskFinished { get; set; }
        public void SetState(State s)
        {
            current = s;
        }
        public void WriteProgram()
        {
            current.WriteProgram(this);
        }
    }
}
