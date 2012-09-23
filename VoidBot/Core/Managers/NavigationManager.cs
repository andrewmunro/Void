using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace VoidBot.Core.Managers
{
    public enum CurrentPath
    {
        WayPoints,
        GhostWaypoints,
        VendorWaypoints,
        RepairWaypoints
    }

    public class NavigationManager
    {
        Vector3 nextWaypoint = new Vector3();

        public static CurrentPath currentPath = CurrentPath.WayPoints;

        public static void DoNavigation()
        {
          
        }
    }
}
