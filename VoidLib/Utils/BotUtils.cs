using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoidLib.Common.Objects;
using VoidLib.Common;
using VoidLib;
using Microsoft.Xna.Framework;
using System.Threading;
using VoidLib.Helpers;

namespace VoidLib.Utils
{
    public class BotUtils
    {
        public static List<WowUnit> getMobsWithBeef()
        {

            return ObjectManager.Units.FindAll(unit => ObjectManager.Me.Combat && (unit.TargetGUID == ObjectManager.Me.GUID || (ObjectManager.Me.HasPet && unit.Target == ObjectManager.Me.Pet)));
        }

        public static void AttackUnit(WowUnit unit, float minDistance = 4f)
        {
            WorldUtils.targetGUID(unit.GUID);

            if (unit.Distance > minDistance)
            {
                CTMHelper.ClickToMove(unit.X, unit.Y, 0, CTMHelper.CTMAction.AttackGuid, unit.GUID);
            }
        }

        public static void MoveToUnit(WowUnit unit)
        {
            CTMHelper.ClickToMove(unit.X, unit.Y, 0, CTMHelper.CTMAction.WalkTo, unit.GUID);
        }

        public static void InteractUnit(WowUnit unit, float minDistance = 4f)
        {
            CTMHelper.ClickToMove(unit.X, unit.Y, 0, CTMHelper.CTMAction.InteractNpc, unit.GUID);
        }

        public static void InteractObject(WowObject obj, float minDistance = 4f)
        {
            CTMHelper.ClickToMove(obj.X, obj.Y, 0, CTMHelper.CTMAction.InteractObject, obj.GUID);
        }

        public static void StopMovement()
        {
            CTMHelper.ClickToMove(0, 0, 0, CTMHelper.CTMAction.Stop);
        }

        public static void LookAtUnit(WowUnit unit)
        {
            CTMHelper.ClickToMove(unit.X, unit.Y, unit.Z, CTMHelper.CTMAction.FaceTarget, unit.GUID);
        }

        public static void CastSpell(string spell)
        {
            LUAHelper.DoString("CastSpellByName(\"" + spell + "\")");
        }

        public static void Dismount()
        {
            if (int.Parse(LUAHelper.GetLUA("IsMounted()")) == 1)
            {
                LUAHelper.DoString("Dismount()");
            }
        }


        public static bool IsOnCooldown(string spell)
        {
            LUAHelper.DoString("start, duration, enabled = GetSpellCooldown(\"" + spell + "\");");
            Thread.Sleep(100);
            try
            {
                return int.Parse(LUAHelper.GetLocalizedText("duration")) > 0;
            }
            catch
            {
                return true;
            }
        }
    }
}
