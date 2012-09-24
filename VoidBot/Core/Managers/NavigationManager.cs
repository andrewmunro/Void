using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackRain.Helpers;
using BlackRain.Common.Objects;
using VoidLib;

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
        static int nextWaypoint = 0; // Index of what node its on...
        static int nextGhostWaypoint = 0;
        static int nextVendorWaypoint = 0;
        static int nextRepairWaypoint = 0;

        public static CurrentPath currentPath = CurrentPath.WayPoints;

        public static float distance(Vector3 dest)
        {
            return (Vector2.Distance(new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y), new Vector2(dest.X, dest.Y)));
        }

        public static void move(List<Vector3> ways, int nextway)
        {
            Vector3 waypoint = ways[nextway];
            if (distance(waypoint) < 0.05f)
            {
                if (nextway == ways.Count)
                {
                    nextway = 0;
                }
                else
                {
                    nextway++;
                }
            }
            else
            {
                CTMHelper.ClickToMove(waypoint.X, waypoint.Y, waypoint.Z);
            }
        }

        public static void DoNavigation()
        {
            switch (NavigationManager.currentPath)
            {
                case (CurrentPath.WayPoints):
                    move(ScriptHelper.Waypoints, nextWaypoint);
                    break;
                case (CurrentPath.GhostWaypoints):
                    move(ScriptHelper.GhostWaypoints, nextGhostWaypoint);
                    break;
                case (CurrentPath.RepairWaypoints):
                    move(ScriptHelper.RepairWaypoints, nextRepairWaypoint);
                    break;
                case (CurrentPath.VendorWaypoints):
                    move(ScriptHelper.VendorWaypoints, nextVendorWaypoint);
                    break;
                default:
                    break;
            }

        }
    }
}
