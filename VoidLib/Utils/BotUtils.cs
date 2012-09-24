using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Common.Objects;
using BlackRain.Common;
using VoidLib;
using Microsoft.Xna.Framework;
using System.Threading;

namespace BlackRain.Utils
{
    public class BotUtils
    {
        public static List<WowUnit> getMobsWithBeef()
        {
            return ObjectManager.Units.FindAll(unit => unit.IsUnit && unit.HasUnitFlag(Offsets.UnitFlags.Combat) &&
                                              (unit.TargetGUID == ObjectManager.Me.GUID || (ObjectManager.Me.HasPet && unit.Target == ObjectManager.Me.Pet)));
        }

        public static void AttackUnit(WowUnit unit, float minDistance = 4f)
        {
            WorldUtils.targetGUID(unit.GUID);

            if (unit.Distance > minDistance)
            {
                CTMHelper.ClickToMove(unit.X, unit.Y, 0, CTMHelper.CTMAction.AttackGuid, unit.GUID);
            }
        }

        public static void InteractUnit(WowUnit unit, float minDistance = 4f)
        {
            CTMHelper.ClickToMove(unit.X, unit.Y, 0, CTMHelper.CTMAction.Loot, unit.GUID);
        }

        public static void LookAtUnit(WowUnit unit)
        {
            CTMHelper.ClickToMove(ObjectManager.Me.X, ObjectManager.Me.Y, ObjectManager.Me.Z, CTMHelper.CTMAction.FaceTarget, unit.GUID);
        }
    }
}
