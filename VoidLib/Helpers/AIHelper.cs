using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Common.Objects;
using BlackRain.Common;

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

        public static List<WowUnit> getMobsWithBeef()
        {
             return ObjectManager.Units.FindAll(unit => unit.IsUnit && unit.HasUnitFlag(Offsets.UnitFlags.Combat) && (unit.TargetGUID == ObjectManager.Me.GUID || (ObjectManager.Me.HasPet && unit.Target == ObjectManager.Me.Pet)));
        }

        public static bool isHostile(WowUnit unit)
        {
            return (uint)unit.Reaction >= (uint)ReactionType.Neutral;
        }

        public static bool isFriendly(WowUnit unit)
        {
            return unit.Reaction >= ReactionType.Friendly;
        }
    }
}
