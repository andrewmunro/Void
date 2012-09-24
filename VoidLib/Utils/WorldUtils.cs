using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Common.Objects;
using BlackRain.Helpers;

namespace BlackRain.Utils
{
    public class WorldUtils
    {
        public static void targetGUID(ulong GUID)
        {
            ObjectManager.Memory.WriteUInt64((uint)ObjectManager.Memory.MainModule.BaseAddress + 0xC6BC08, GUID);
        }

        public static void targetGUID(WowUnit unit)
        {
            ObjectManager.Memory.WriteUInt64((uint)ObjectManager.Memory.MainModule.BaseAddress + 0xC6BC08, unit.GUID);
        }

        public static Continent getContinent()
        {
            return (Continent)uint.Parse(LUAHelper.GetLUA("GetCurrentMapContinent()"));
        }
    }
}
