using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using BlackRain.Navigation.Pathfinding;

namespace BlackRain.Navigation
{
    public class Waypoint : PathNode
    {
        public Vector2 Position;
        public List<Waypoint> Connections = new List<Waypoint>();

        public override List<PathNode> getConnections()
        {
            return Connections.ToList<PathNode>();
        }
    }
}
