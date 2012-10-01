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
            while (true)
            {
                try
                {
                    Work();
                }
                catch
                {
                    LUAHelper.ResumeMainWowThread();
                }
            }

            Console.Read();
        }


        

       


        private static void Work()
        {
            var proc = Process.GetProcessesByName("wow");

            foreach (var p in proc)
            {
                ObjectManager.Initialize(p);
                ObjectManager.Pulse();

                while (true)
                {
                    //Console.Clear();

                    FindTarget();
                    Combat();
                    Loot();
                    Rest();
                    //WaypointRecorder.Update();

                    Thread.Sleep(100);
                }

            }
        }

        private static Queue<WowUnit> lootUnits = new Queue<WowUnit>();

        public class SharmenSpells
        {
            public const string LIGHTNING_BOLT = "Lightning Bolt";
            public const string PRIMAL_STRIKE = "Primal Strike";
            public const string EARTH_SHOCK = "Earth Shock";
            public const string HEALING_SURGE = "Healing Surge";
            public const string WAR_STOMP = "War Stomp";
            public const string LIGHTNING_SHEILD = "Lightning Sheild";
        }

        public static List<ulong> blackList = new List<ulong>();
        public static List<string> blackNameList = new List<string>()
        {
            "Romo's Half-Size Bunny",
            //"Adult Plainstrider",
            "Mouse"
        };

        public static void FindTarget()
        {
            List<WowUnit> hostileUnits = ObjectManager.Units.FindAll(unit => unit.isHostile && !unit.Dead && !blackList.Contains(unit.GUID) && !blackNameList.Contains(unit.Name) && unit.Health > 1 && unit.Level <= ObjectManager.Me.Level + 1).OrderBy(unit => unit.Distance).ToList();

            if (hostileUnits.Count > 0)
            {

                WowUnit target = hostileUnits[0];

                int trys = 0;
                while (!ObjectManager.Me.Combat || BotUtils.getMobsWithBeef().Count == 0)
                {
                    trys++;
                    Console.WriteLine("Trys: " + trys + " -> " + target.Name + " " + target.Health + " " + target.IsUnit);
                    BotUtils.AttackUnit(target);
                    Thread.Sleep(100);

                    if (trys > 100)
                    {
                        blackList.Add(target.GUID);
                        break;
                    }
                }

                Console.WriteLine("Attacking: " + target.Name + " isHostile: " + target.isHostile + " " + BotUtils.getMobsWithBeef().Count);
            }
        }

        public static void Combat()
        {
            int a = 0;
            while (BotUtils.getMobsWithBeef().Count > 0)
            {
                //Console.Clear();

                List<WowUnit> sortedBeefMobs = BotUtils.getMobsWithBeef().OrderBy(unit => unit.HealthPercentage).ToList();

                if (sortedBeefMobs.Count == 0) break;

                WowUnit lowestHPEnemy = sortedBeefMobs[0];

                WorldUtils.TargetUnit(lowestHPEnemy);

                BotUtils.StopMovement();
                BotUtils.LookAtUnit(lowestHPEnemy);
        
                //BotUtils.AttackUnit(lowestHPEnemy);

                // Spell
                if (ObjectManager.Me.HealthPercentage < 30)
                {
                    BotUtils.CastSpell(SharmenSpells.WAR_STOMP);
                    Thread.Sleep(100);
                    BotUtils.CastSpell(SharmenSpells.HEALING_SURGE);
                    Thread.Sleep(500);
                }
                else
                {
                    if (ObjectManager.Me.Mana > 14) // 2 heals
                    {
                        if (!BotUtils.IsOnCooldown(SharmenSpells.PRIMAL_STRIKE))
                        {
                            BotUtils.CastSpell(SharmenSpells.PRIMAL_STRIKE);
                            Thread.Sleep(200);
                        }
                        else
                        {
                            if (lowestHPEnemy.HealthPercentage > 35)
                            {
                                BotUtils.CastSpell(SharmenSpells.LIGHTNING_BOLT);
                                Thread.Sleep(1800);
                            }
                            else
                            {
                                BotUtils.CastSpell(SharmenSpells.EARTH_SHOCK);
                            }
                        }
                    }
                }

                if (!lootUnits.Contains(lowestHPEnemy))
                {
                    Console.WriteLine("Added New Enemy To Loot: " + lowestHPEnemy.Name);
                    lootUnits.Enqueue(lowestHPEnemy);
                }

                Thread.Sleep(200);
            }
        }

        public static void Loot()
        {
            Console.WriteLine("Loot");

            while (lootUnits.Count > 0)
            {
                WowUnit lootUnit = lootUnits.Dequeue();

                Console.WriteLine("Going to loot " + lootUnit.Name);

                int timeSpent = 0;
                while (lootUnit.Distance > 4)
                {
                    timeSpent++;
                    Thread.Sleep(10);
                    Console.WriteLine("Walking.. [" + lootUnit.Distance + "] " + timeSpent);
                    BotUtils.MoveToUnit(lootUnit);

                    if (timeSpent > 40)
                    {
                        Console.WriteLine("Loot took too long");
                        break;
                    }
                }

                Console.WriteLine("Going to loot...");
                WorldUtils.TargetUnit(lootUnit);
                Thread.Sleep(500);
                WorldUtils.Interact();
                Thread.Sleep(500);
                Console.WriteLine("Done looting... ");
                Thread.Sleep(1000);
            }
        }

        public static void Rest()
        {
            while (ObjectManager.Me.HealthPercentage < 80 && ObjectManager.Me.ManaPercentage < 80)
            {
                Thread.Sleep(300);
                Console.WriteLine("Rest");

                if (ObjectManager.Me.HealthPercentage < 30)
                {
                    BotUtils.CastSpell(SharmenSpells.HEALING_SURGE);
                    Thread.Sleep(1500);
                }

                if (ObjectManager.Me.Combat || BotUtils.getMobsWithBeef().Count > 0)
                    break;
            }
        }

    }
}
