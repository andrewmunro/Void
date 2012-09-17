using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Common.Objects;
using System.Diagnostics;
using System.Threading;
using BlackRain.Common;

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
                    // 16057
                    
                   
                    Console.WriteLine("[LocalPlayer]");
                    Console.WriteLine("Name: " + ObjectManager.Me.Name);

                    if (ObjectManager.Me.Target != null)
                    {
                        Console.WriteLine(ObjectManager.Me.Target.Name + " " + ObjectManager.Me.Target.Health + "/" + ObjectManager.Me.Target.MaximumHealth + " " + ObjectManager.Me.Target.Mana + "/" + ObjectManager.Me.Target.MaximumMana);


                        


                        uint WoWBasePlusCTMBase = ObjectManager.Read<uint>(ObjectManager.WowBaseAddress + (uint)CTM.CTM_Base);

                        float X = ObjectManager.Read<float>(WoWBasePlusCTMBase + (uint)CTM.CTM_X);
                       // float Y = ObjectManager.Read<float>(WoWBasePlusCTMBase + (uint)CTM.CTM_Y);
                        //float Z = ObjectManager.Read<float>(WoWBasePlusCTMBase + (uint)CTM.CTM_Z);

                        //int currentAction = ObjectManager.Read<int>(CTMAddress + (uint)CTM.CTM_GUID);
                        //Console.WriteLine("Current Action:" + X);
                        /*
                        BMagic.WriteInt(CTMAddress + Push, 4);

                        ObjectManager.Write<float>(ObjectManager.WowBaseAddress + (uint)CTM.CTM_Base + (uint)CTM.CTM_X, ObjectManager.Me.Target.X);
                        ObjectManager.Write<float>(ObjectManager.WowBaseAddress + (uint)CTM.CTM_Base + (uint)CTM.CTM_Y, ObjectManager.Me.Target.Y);
                        ObjectManager.Write<float>(ObjectManager.WowBaseAddress + (uint)CTM.CTM_Base + (uint)CTM.CTM_Z, ObjectManager.Me.Target.Z);

                        ObjectManager.Write<uint>(ObjectManager.WowBaseAddress + (uint)CTM.CTM_Base + (uint)CTM.CTM_ACTION, (uint)CTMAction.WalkTo);
                       */
                        /*
                        ObjectManager.Write<float>((uint)CTM_Base + (uint)BlackRain.Common.Offsets.ClickToMove.CTM_Y, ObjectManager.Me.Target.Y);
                        ObjectManager.Write<float>((uint)BlackRain.Common.Offsets.ClickToMove.CTM_Base + (uint)BlackRain.Common.Offsets.ClickToMove.CTM_Z, ObjectManager.Me.Target).;
                        ObjectManager.Write<uint>((uint)BlackRain.Common.Offsets.ClickToMove.CTM_Base + (uint)BlackRain.Common.Offsets.ClickToMove.CTM_Action, (uint)BlackRain.Common.Offsets.CTMAction.WalkTo);
                        */
             


                        //ObjectManager.Me.Target.FuckingDumpThatShit();
                    }

                    //Console.WriteLine("Target: " + ObjectManager.Me.Target.Name);
                    //Console.WriteLine("ToT: " + ObjectManager.Me.Target.Target.Name);
                    //Console.WriteLine("Health: " + ObjectManager.Me.Health + "/" + ObjectManager.Me.MaximumHealth);

                            

                    foreach (WowUnit unit in ObjectManager.Units)
                    {
                        //Console.WriteLine(unit.Name + " " + unit.Health + "/" + unit.MaximumHealth);
                    }

                    //  
                    Console.WriteLine("X:" + ObjectManager.Me.X + " Y:" + ObjectManager.Me.Y + " Z:" + ObjectManager.Me.Z);
                    Thread.Sleep(1000);
                    
                }
            }


            //Console.WriteLine(ObjectManager.GameObjects.Count);


            Console.Read();
        }


        public enum CTM : uint
        {
            CGPlayer_C__ClickToMove = 0x493760,     // 5.0.5 
            CTM_Base = 0xC2BD04,                    // 5.0.5 
            CTM_Push = 0x24,                        // 5.0.5 
            CTM_X = 0x8C,                           // 5.0.5 
            CTM_Y = CTM_X + 0x4,                    // 5.0.5 
            CTM_Z = CTM_X + 0x8,                    // 5.0.5 
            CTM_GUID = 0x1C,                        // 5.0.5 
            CTM_Distance = 0xC                      // 5.0.5 
        }

        public enum CTMAction
        {
            FaceTarget = 0x1,
            Stop = 0x3,
            WalkTo = 0x4,
            InteractNpc = 0x5,
            Loot = 0x6,
            InteractObject = 0x7,
            Unknown1 = 0x8,
            Unknown2 = 0x9,
            AttackPos = 0xA,
            AttackGuid = 0xB,
            WalkAndRotate = 0xC
        };


   

    }
}
