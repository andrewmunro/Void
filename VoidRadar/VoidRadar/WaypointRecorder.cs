using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using VoidLib.Common.Objects;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using VoidLib.Navigation;

namespace VoidRadar
{
    class WaypointRecorder
    {
        public static bool Recording = true;
        public static Waypoint lastWaypoint = new Waypoint() { Position = Vector2.Zero };

        public static void Update()
        {
            if (!Recording) return;

            int distance = 10;

            Vector2 playerPosition = new Vector2(ObjectManager.Me.X, ObjectManager.Me.Y);

            if (Math.Abs(Vector2.Distance(playerPosition, lastWaypoint.Position)) > distance)
            {
                Waypoint newWaypoint = new Waypoint() { Position = playerPosition };
                List<Waypoint> sortWaypoints = WaypointManager.waypoints.FindAll(wp => Vector2.Distance(wp.Position, newWaypoint.Position) <= 12).ToList();

                if (sortWaypoints.Count == 0 || Vector2.Distance(sortWaypoints[0].Position, newWaypoint.Position) > 7)
                {
                    if (lastWaypoint != null) newWaypoint.Connections.Add(lastWaypoint); // Vise Versa

                    newWaypoint.Connections.AddRange(sortWaypoints);

                    WaypointManager.waypoints.Add(newWaypoint);
                }
                else
                {
                    sortWaypoints.RemoveAt(0);
                    sortWaypoints[0].Connections.AddRange(sortWaypoints);

                    lastWaypoint = sortWaypoints[0];
                }
                    lastWaypoint = newWaypoint;
                
            }
        }

        private static void Load()
        {
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    var waypoints = (List<Vector2>)bin.Deserialize(stream);
                    foreach (Vector2 wp in waypoints)
                    {
                        Console.WriteLine(wp.ToString());
                    }
                }
            }
            catch (IOException)
            {
            }
        }

        public static void Save()
        {
            try
            {
                using (Stream stream = File.Open("data.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    //bin.Serialize(stream, waypoints);
                    Console.WriteLine("Saved!");
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Failed! ");
            }
        }
    }
}
