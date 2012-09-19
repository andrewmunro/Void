using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Common.Objects;
using System.Diagnostics;
using System.Threading;
using BlackRain.Common;
using Magic;

namespace Playground
{
    class Program
    {
        //static HookManager hookManager;

        static void Main(string[] args)
        {
            var proc = Process.GetProcessesByName("wow");

            foreach (var p in proc)
            {
                ObjectManager.Initialize(p);
                ObjectManager.Pulse();

                //hookManager = new HookManager(ObjectManager.Memory);
                
                while (true)
                {
                    Console.Clear();
                    // 16057
                    /*
                   
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
                            //CTMHelper.ClickToMove(gameObject.X, gameObject.Y, gameObject.Z, CTMAction.InteractObject, gameObject.GUID);
                        }
                    }
                    Thread.Sleep(1000);

                    Console.WriteLine("Dancing");
                    */
                    ProcessThread wowMainThread = SThread.GetMainThread(p.Id);
                    IntPtr hThread = SThread.OpenThread(wowMainThread.Id);

                    //SThread.ResumeThread(hThread);

                   // SThread.SuspendThread(hThread);

                  //  try
                   // {

                        LuaDoString2("print('dance')");
                   // }
                   // catch (Exception e)
                  //  {
                  //      Console.WriteLine(e);
                  //      Console.WriteLine("Fail: LuaDoString2");
                  //  }

                  //  SThread.ResumeThread(hThread);

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

        
        public static void LuaDoString(string command)
        {
            // Allocate memory

            uint DoStringArg_Codecave = ObjectManager.Memory.AllocateMemory(Encoding.ASCII.GetBytes(command).Length + 1);
            // offset:
            uint FrameScript__Execute = 0x75350;


            // Write value:
            ObjectManager.Memory.WriteBytes(DoStringArg_Codecave, Encoding.ASCII.GetBytes(command));

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
            //hookManager.InjectAndExecute(asm);
            //ObjectManager.Memory.Asm.InjectAndExecute(DoStringArg_Codecave);
            // Free memory allocated 
            ObjectManager.Memory.FreeMemory(DoStringArg_Codecave);
        }


        public static void LuaDoString2(string command)
        {

           

            int nSize = command.Length + 0x100;
            uint codeCave = ObjectManager.Memory.AllocateMemory(nSize);
            uint moduleBase = (uint)ObjectManager.WowProcess.MainModule.BaseAddress;

            ObjectManager.Memory.WriteASCIIString(codeCave, command);

            ObjectManager.Memory.Asm.Clear();

            String[] asm = new String[] 
            {
                "mov eax, " + codeCave,
                "push 0",
                "push eax",
              
                "push eax",
                "mov eax, " + (moduleBase + 0x75350),
                
                "call eax",
                "add esp, 0xC",
                "retn",    
            };

            //hookManager.InjectAndExecute(asm);
            //vLib.InjectAndExecute(asm);
            ObjectManager.Memory.FreeMemory(codeCave);
        }
       
    

        

   

    }
}
