using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 享元模式1
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSiteFactory f = new WebSiteFactory();
            WebSite fx = f.GetWebSite("产品展示");
            fx.Use();

            WebSite fy = f.GetWebSite("产品展示");
            fy.Use();

            WebSite fz = f.GetWebSite("产品展示");
            fz.Use();

            WebSite fl = f.GetWebSite("博客");
            fl.Use();

            Console.WriteLine(f.GetWebSiteCount()); 
        }
    }
    abstract class WebSite
    {
        public abstract void Use();
    }
    class ConcreteWebSite : WebSite
    {
        private string name = "";
        public ConcreteWebSite (string name)
        {
            this.name = name;
        }
        public override void Use()
        {
            Console.WriteLine("网站分类: " + name);
        }
    }
    class WebSiteFactory
    {
        private Hashtable flyweights = new Hashtable();
        public WebSite GetWebSite(string key)
        {
            if (!flyweights.Contains(key))
            {
                flyweights.Add(key, new ConcreteWebSite(key));
            }
            return (WebSite)flyweights[key];
        }
        public int GetWebSiteCount()
        {
            return flyweights.Count;
        }
    }
}
