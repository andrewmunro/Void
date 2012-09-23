using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VoidLib;
using BlackRain.Helpers;
using BlackRain.Common;
using Microsoft.Xna.Framework;
using BlackRain.Common.Objects;

namespace VoidBot.Core.Managers
{
    class HarvestManager
    {
        public void moveToNode(Vector2 node)
        {
            CTMHelper.ClickToMove(node.X, node.Y, ObjectManager.Me.Z);

        }
    }
}
