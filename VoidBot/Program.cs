using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoidBot.Core.Managers;
using System.Threading;

namespace VoidBot
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                NavigationManager.DoNavigation();
                Thread.Sleep(1000);
            }
            //ScriptManager.loadScript("../../Assets/01-10 Elwynn Forest.xml");
            Console.Read();
        }
    }
}
