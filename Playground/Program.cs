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
                    
                    //Console.WriteLine("X:" + ObjectManager.Me.X + " Y:" + ObjectManager.Me.Y + " Z:" + ObjectManager.Me.Z);
                    //CTMHelper.ClickToMove(ObjectManager.Me.Target.X, ObjectManager.Me.Target.Y, ObjectManager.Me.Target.Z);
                    LUAHelper.DoString("print(\"Hello World\")");

                    Console.WriteLine(LUAHelper.GetLocalizedText("lucas"));
                    Console.WriteLine("Press Any Key...");
                    Console.Read();
                    Thread.Sleep(1000);                    
                }
            }

            Console.Read();
        }

    }
}
