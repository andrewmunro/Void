using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Common.Objects;

namespace BlackRain.Helpers
{
    public class AIHelper
    {
        public static List<WowUnit> unitsWithAgro()
        {
            return ObjectManager.Units.FindAll(unit => !unit.IsPlayer && unit.TargetGUID == ObjectManager.Me.GUID);
        }

        public static void targetGUID(ulong GUID)
        {
            ObjectManager.Memory.WriteUInt64((uint)ObjectManager.Memory.MainModule.BaseAddress + 0xC6BC08, GUID);
        }

        public static void targetGUID(WowUnit unit)
        {
            ObjectManager.Memory.WriteUInt64((uint)ObjectManager.Memory.MainModule.BaseAddress + 0xC6BC08, unit.GUID);
        }
    }
}
