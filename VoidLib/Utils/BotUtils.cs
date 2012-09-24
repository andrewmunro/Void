using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Common.Objects;
using BlackRain.Common;

namespace BlackRain.Utils
{
    public class BotUtils
    {
        public static List<WowUnit> getMobsWithBeef()
        {
            return ObjectManager.Units.FindAll(unit => unit.IsUnit && unit.HasUnitFlag(Offsets.UnitFlags.Combat) &&
                                              (unit.TargetGUID == ObjectManager.Me.GUID || (ObjectManager.Me.HasPet && unit.Target == ObjectManager.Me.Pet)));
        }
    }
}
