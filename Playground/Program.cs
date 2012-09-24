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
using BlackRain.Utils;

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


                    List<WowUnit> hostileUnits = ObjectManager.Units.FindAll(unit => unit.isHostile && !unit.Dead).OrderByDescending(unit => unit.Distance).Reverse().ToList();


                    WowUnit target = hostileUnits[0];

                    Console.WriteLine("Attacking: " + target.Name + " isHostile: " + target.isHostile);
                   

                    while (!target.Dead)
                    {
                        Console.WriteLine("Kill!");
                        BotUtils.AttackUnit(target);

                        LUAHelper.DoString("CastSpellByName(\"Lightning Bolt\")");
                        Thread.Sleep(2000);
                    }

                    WorldUtils.TargetUnit(target);
                    Thread.Sleep(400);
                    LUAHelper.DoString("RunBinding(\"INTERACTTARGET\")");
                  
                    Thread.Sleep(1000);

                    while (ObjectManager.Me.HealthPercentage < 20)
                    {
                        Thread.Sleep(100);
                    }

                    //BotUtils.LookAtUnit(target);

                    

                    Thread.Sleep(1000);
                }
                
            }

            Console.Read();
        }

    }
}
