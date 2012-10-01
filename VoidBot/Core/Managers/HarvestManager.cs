using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoidLib;
using BlackRain.Helpers;
using BlackRain.Common;
using Microsoft.Xna.Framework;
using BlackRain.Common.Objects;
using System.Threading;

namespace VoidBot.Core.Managers
{
    class HarvestManager
    {
        public static WowObject node;

        public static float distanceXY()
        {
            return (Vector2.Distance(new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y), new Vector2(node.X, node.Y)));
        }

        public static float distanceZ()
        {
            return (Vector2.Distance(new Vector2(0, ObjectManager.Me.Z), new Vector2(0, node.Z)));
        }

        public void moveToNode()
        {
            if (distanceXY() < 0.05f)
            {
                CTMHelper.ClickToMove(node.X, node.Y, ObjectManager.Me.Z);
            }
            else if (distanceZ() < 0.05f)
            {
                CTMHelper.ClickToMove(node.X, node.Y, node.Z);
            }
            else
            {
                Thread.Sleep(1000);
                harvestNode();
            }
        }

        public void harvestNode()
        {
            if (int.Parse(LUAHelper.GetLUA("IsMounted()")) == 1)
            {
                LUAHelper.DoString("Dismount()");
                Thread.Sleep(500);
                CTMHelper.ClickToMove(node)
            }
        }
    }
}
