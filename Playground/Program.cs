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
                    /*
                    while (true)
                    {
                        ulong targetGUID = ObjectManager.Memory.ReadUInt64((uint)ObjectManager.Memory.MainModule.BaseAddress + 0xC6BC08);

                        Console.WriteLine(targetGUID + " vs " + ObjectManager.Me.TargetGUID);
                        WowUnit target = ObjectManager.Units.Find(unit => unit.GUID == targetGUID);

                        if (target != null)
                        {
                            Console.WriteLine("Target: " + target.Name);
                        }


                        Thread.Sleep(1000);
                    }
                    */
                    
                    
                    List<WowUnit> units = ObjectManager.Units.FindAll(u => (u.Name.ToLower().Contains("nightsaber") || u.Name.ToLower().Contains("grell")) && !u.Dead).OrderByDescending(x => x.Distance).ToList();
                    units.Reverse();

                    AIHelper.targetGUID(units[0]);
                    
                   CTMHelper.ClickToMove(units[0].X, units[0].Y, units[0].Z, CTMAction.AttackGuid, units[0].GUID);

             

                   
                 //   Console.WriteLine("Done! " + ObjectManager.Me.Target.Name);
                    //Console.Read();

                    

                    Console.WriteLine("Closest Target: " + units[0].Name);

                    CTMHelper.ClickToMove(units[0].X, units[0].Y, units[0].Z, CTMAction.AttackGuid, units[0].GUID);

                    while (ObjectManager.Me.Target != null)
                    {
                        LUAHelper.DoString("TargetNearestEnemy()");
                            Thread.Sleep(100);
                            if (ObjectManager.Me.Target == null) break;

                        CTMHelper.ClickToMove(ObjectManager.Me.Target.X, ObjectManager.Me.Target.Y, ObjectManager.Me.Target.Z, CTMAction.FaceTarget, ObjectManager.Me.Target.GUID);
                        LUAHelper.DoString("CastSpellByName(\"FrostFire Bolt\")");

                        Console.WriteLine("IsDead: " + ObjectManager.Me.Target.Dead);
                        //LUAHelper.DoString("TargetNearestEnemy()");
                        Thread.Sleep(3000);
                    }
                    


                    LUAHelper.DoString("TargetLastEnemy()");
                    Thread.Sleep(400);
                    LUAHelper.DoString("RunBinding(\"INTERACTTARGET\")");

                   // Console.WriteLine("Done...");
                 //   Console.Read();
                    /*
                    while (ObjectManager.Me.Target == null)
                    {
                        LUAHelper.DoString("TargetNearestEnemy()");
                        Thread.Sleep(500);
                    }

                    while (ObjectManager.Me.Target.Dead)
                    {
                        LUAHelper.DoString("TargetNearestEnemy()");
                        Thread.Sleep(500);
                    }

                    Thread.Sleep(1000);

                    

               

                    Console.WriteLine("Target Killed");

                    //Console.WriteLine("X:" + ObjectManager.Me.X + " Y:" + ObjectManager.Me.Y + " Z:" + ObjectManager.Me.Z);
                    //CTMHelper.ClickToMove(ObjectManager.Me.Target.X, ObjectManager.Me.Target.Y, ObjectManager.Me.Target.Z);
                    
                    /*
                    if (ObjectManager.Me.Target != null)
                    {
                        Console.WriteLine("ClickToMove");
                        Thread.Sleep(100);
                        LUAHelper.DoString("TargetLastTarget()");
                        CTMHelper.ClickToMove(ObjectManager.Me.Target.X, ObjectManager.Me.Target.Y, ObjectManager.Me.Target.Z, CTMAction.Loot, ObjectManager.Me.Target.GUID);
                    }
              
                   // LUAHelper.DoString("InteractUnit(\"target\")");
                   // LUAHelper.DoString("print(" + ObjectManager.Me.Target.GUID + ")");
                   // Console.Read();

                    /*
                    try
                    {
                        LUAHelper.DoString("dave = GetNumSpellTabs()");
                        int bookCount = int.Parse(LUAHelper.GetLocalizedText("dave"));

                        for (int i = 1; i < bookCount + 1; i++)
                        {
                            LUAHelper.DoString("name,texture,offset,numSpells = GetSpellTabInfo(" + i + ")");
                            int numSpells = int.Parse(LUAHelper.GetLocalizedText("numSpells"));
                            string bookName = LUAHelper.GetLocalizedText("name");

                            Console.WriteLine(bookName);

                            for (int spell = 1; spell < numSpells + 1; spell++)
                            {
                                LUAHelper.DoString("name, rank, icon, powerCost, isFunnel, powerType, castingTime, minRange, maxRange = GetSpellInfo(" + spell + ", " + i + ")");

                                string name = LUAHelper.GetLocalizedText("name");
                                string rank = LUAHelper.GetLocalizedText("rank");
                                string powerCost = LUAHelper.GetLocalizedText("powerCost");
                                string powerType = LUAHelper.GetLocalizedText("powerType");

                                Console.WriteLine(" - " + name);
                                Console.WriteLine("   - Rank: " + rank);
                                Console.WriteLine("   - PowerCost: " + powerCost);
                                Console.WriteLine("   - PowerType: " + powerType);

			 
                            }
                        }
                    }
                    catch { }
                     * */
                    
                   
                        //GetSpellBookItemName(3, 0)
                    //LUAHelper.DoString("  for spellId, spellName,spellSubtext in playerSpells() do print(spellId, spellName, spellSubtext) end");

                    //Console.WriteLine(LUAHelper.GetLocalizedText("lucas"));
                    //Console.WriteLine("Press Any Key...");
        
                    Thread.Sleep(1000);                    
                }
            }

            Console.Read();
        }

    }
}
