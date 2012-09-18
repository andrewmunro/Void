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



                        //CTMHelper.ClickToMove(ObjectManager.Me.Target.X, ObjectManager.Me.Target.Y, ObjectManager.Me.Target.Z, CTMAction.InteractNpc, ObjectManager.Me.Target.GUID);


                        
                       
                      
                    }

                    Thread.Sleep(5000);
                    foreach (WowGameObject gameObject in ObjectManager.GameObjects)
                    {
                        if (gameObject.Name.ToLower() == "mailbox")
                        {
                            CTMHelper.ClickToMove(gameObject.X, gameObject.Y, gameObject.Z, CTMAction.InteractObject, gameObject.GUID);
                        }
                    }
                    Thread.Sleep(1000);
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
        /*
        public static void LuaDoString(string command)
        {
            // Allocate memory
            uint DoStringArg_Codecave = MyHook.Memory.AllocateMemory(Encoding.UTF8.GetBytes(command).Length + 1);
            // offset:
            FrameScript__Execute = 0x819210;


            // Write value:
            MyHook.Memory.WriteBytes(DoStringArg_Codecave, Encoding.UTF8.GetBytes(command));

            // Write the asm stuff for Lua_DoString
            String[] asm = new String[] 
            {
                "mov eax, " + DoStringArg_Codecave,
                "push 0",
                "push eax",
                "push eax",
                "mov eax, " + (uint)FrameScript__Execute, // Lua_DoString
                "call eax",
                "add esp, 0xC",
                "retn",    
            };

            // Inject
            MyHook.InjectAndExecute(asm);
            // Free memory allocated 
            MyHook.Memory.FreeMemory(DoStringArg_Codecave);
        }

       
    

        
*/
   

    }
}
