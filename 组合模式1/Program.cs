using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 组合模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteCompany root = new ConcreteCompany("北京总公司");
            root.Add(new HRDepartment("总公司人力资源部"));
            root.Add(new FinanceDepartment("总公司财务部"));

            ConcreteCompany comp = new ConcreteCompany("上海华东分公司");
            comp.Add(new HRDepartment("华东分公司人力资源部"));
            comp.Add(new FinanceDepartment("华东分财务部"));
            root.Add(comp);

            ConcreteCompany comp1 = new ConcreteCompany("南京办事处");
            comp1.Add(new HRDepartment("南京办事处人力资源部"));
            comp1.Add(new FinanceDepartment("南京办事处财务部"));
            comp.Add(comp1);

            ConcreteCompany comp2 = new ConcreteCompany("杭州办事处");
            comp2.Add(new HRDepartment("杭州办事处人力资源部"));
            comp2.Add(new FinanceDepartment("杭州办事处财务部"));
            comp.Add(comp2);

            root.Display(1);
            root.LineOfDuty();
            comp.Display(1); // 显示comp的树

        }
    }
    abstract class Company
    {
        protected string name;
        public Company(string name)
        {
            this.name = name;
        }
        public abstract void Add(Company c);
        public abstract void Remove(Company c);
        public abstract void Display(int depth);
        public abstract void LineOfDuty();
    }
    class ConcreteCompany : Company
    {
        private List<Company> childen = new List<Company>();
        public ConcreteCompany(string name) : base(name)
        {
        }
        public override void Add(Company c)
        {
            childen.Add(c);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
            foreach(Company company in childen)
            {
                company.Display(depth+2);
            }
        }

        public override void LineOfDuty()
        {
            foreach(Company company in childen)
            {
                company.LineOfDuty();
            }
        }

        public override void Remove(Company c)
        {
            childen.Remove(c);
        }
    }

    class HRDepartment : Company
    {
        public HRDepartment(string name) : base(name) { }

        public override void Add(Company c)
        {
            
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }

        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 员工招聘培训管理",name);
        }

        public override void Remove(Company c)
        {
            
        }
    }
    class FinanceDepartment : Company
    {
        public FinanceDepartment(string name) : base(name) { }

        public override void Add(Company c)
        {

        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + name);
        }

        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 公司财务收支管理", name);
        }

        public override void Remove(Company c)
        {

        }
    }
}
