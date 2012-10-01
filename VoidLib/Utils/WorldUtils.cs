using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoidLib.Common.Objects;
using VoidLib.Helpers;

namespace VoidLib.Utils
{
    public class WorldUtils
    {
        public static void targetGUID(ulong GUID)
        {
            ObjectManager.Memory.WriteUInt64((uint)ObjectManager.Memory.MainModule.BaseAddress + 0xC6BC08, GUID);
        }

        public static void TargetUnit(WowUnit unit)
        {
            ObjectManager.Memory.WriteUInt64((uint)ObjectManager.Memory.MainModule.BaseAddress + 0xC6BC08, unit.GUID);
        }

        public static void Interact()
        {
            LUAHelper.DoString("RunBinding(\"INTERACTTARGET\")");
        }

        public static Continent getContinent()
        {
            return (Continent)uint.Parse(LUAHelper.GetLUA("GetCurrentMapContinent()"));
        }
    }
}
