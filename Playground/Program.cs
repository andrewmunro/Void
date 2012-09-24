using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Common.Objects;
using System.Diagnostics;
using System.Threading;
using BlackRain.Common;
using Magic;
using VoidLib;
using BlackRain.Helpers;
using Microsoft.Xna.Framework;

namespace Playground
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
                
                while (true)
                {
                    Console.Clear();
                    //Console.WriteLine(AIHelper.getContinent());
        
                    Thread.Sleep(1000);                    
                }
            }

            Console.Read();
        }

    }
}
