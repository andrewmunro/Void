using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Injection;
using BlackRain.Common.Objects;
using System.Threading;

namespace BlackRain.Helpers
{
    public class LUAHelper
    {
        static Hook MyHook;

        public static void DoString(string command)
        {
            if (MyHook == null) MyHook = new Hook((uint)ObjectManager.WowProcess.Id, (uint)ObjectManager.WowProcess.MainModule.BaseAddress);
            //ProcessManager.SuspendMainWowThread();

            uint codecave = MyHook.Memory.AllocateMemory();
            uint stringcave = MyHook.Memory.AllocateMemory(command.Length + 1);
            MyHook.Memory.WriteASCIIString(stringcave, command);

            MyHook.Memory.Asm.Clear();
            //AsmUpdateCurMgr();

            MyHook.Memory.Asm.AddLine("mov eax, 0");
            MyHook.Memory.Asm.AddLine("push eax");
            MyHook.Memory.Asm.AddLine("mov eax, {0}", stringcave);
            MyHook.Memory.Asm.AddLine("push eax");
            MyHook.Memory.Asm.AddLine("push eax");
            MyHook.Memory.Asm.AddLine("call {0}", (MyHook.Memory.MainModule.BaseAddress + 0x75350));
            MyHook.Memory.Asm.AddLine("add esp, 0xC");

            //AsmSendResumeMessage();
            MyHook.Memory.Asm.AddLine("retn");

            try
            {
                MyHook.Memory.Asm.InjectAndExecute(codecave);
                Console.WriteLine("[DoString] Ran: " + command);
                Thread.Sleep(10);
            }
            catch (Exception e)
            {
                //ProcessManager.ResumeMainWowThread();
                Console.WriteLine("[DoString] Error!");
                throw e;
            }
            finally
            {
                MyHook.Memory.FreeMemory(codecave);
                MyHook.Memory.FreeMemory(stringcave);
            }
        }
    }
}
