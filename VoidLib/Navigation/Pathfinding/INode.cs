using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoidLib.Navigation.Pathfinding
{
    public class PathNode
    {
        public float f, g, h, x, y;
        public PathNode parentNode;
        public bool traversable;

        public virtual List<PathNode> getConnections()
        {
            return null;
        }
    }
}
