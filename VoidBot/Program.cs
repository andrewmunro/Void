using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoidBot.Core.Managers;
using System.Threading;
using BlackRain.Helpers;
using System.Diagnostics;
using BlackRain.Common.Objects;

namespace VoidBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var proc = Process.GetProcessesByName("wow");

            foreach (var p in proc)
            {
                ObjectManager.Initialize(p);
                ObjectManager.Pulse();

                ScriptHelper.loadScript("01-10 Elwynn Forest.xml");

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
}
