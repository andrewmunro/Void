using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using VoidLib.Navigation.Pathfinding;

namespace VoidLib.Navigation
{
    public class Waypoint
    {
        private float x;
        private float y;
        private float z;
        private uint wid;


        public uint WID
        {
            get { return this.wid; }
        }

        public Vector3 Location
        {
            get { return new Vector3(this.X, this.Y, this.Z); }
        }

        public virtual float X
        {
            get { return this.x; }
        }

        /// <summary>
        /// Returns the object's Y position.
        /// </summary>
        public virtual float Y
        {
            get { return this.y; }
        }

        /// <summary>
        /// Returns the object's Z position.
        /// </summary>
        public virtual float Z
        {
            get { return this.z; }
        }


    }
}
