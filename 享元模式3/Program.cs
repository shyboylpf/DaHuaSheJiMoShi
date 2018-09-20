using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 享元模式3
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSiteFactory f = new WebSiteFactory();

            WebSite fx = f.GetWebSite("产品展示");
            fx.Use(new User("小菜"));

            WebSite fy = f.GetWebSite("博客");
            fy.Use(new User("小菜"));

            WebSite fz = f.GetWebSite("博客");
            fz.Use(new User("大鸟"));
        }
    }
    public class User
    {
        private string name;
        public User(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }

    abstract class WebSite
    {
        public abstract void Use(User user);
    }

    class ConcreteWebSite : WebSite
    {
        private string name = "";
        public ConcreteWebSite(string name)
        {
            this.name = name;
        }
        public override void Use(User user)
        {
            Console.WriteLine("网站分类: " + name + "用户:" + user.Name);
        }
    }
    class WebSiteFactory
    {
        private Hashtable flyweight = new Hashtable();
        public WebSite GetWebSite(string key)
        {
            if(!flyweight.ContainsKey(key))
            {
                flyweight.Add(key,new ConcreteWebSite(key));
            }
            return (WebSite)flyweight[key];
        }
    }
}
