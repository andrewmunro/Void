using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;

namespace VoidTemplate.Core.Managers
{
    class ScriptManager
    {
        static List<Vector3> waypoints = new List<Vector3>();
        static List<Vector3> ghostWaypoints = new List<Vector3>();
        static List<int> factions = new List<int>();
        static int minLevel = 0;
        static int maxLevel = 90;

        private static void clearData()
        {
            minLevel = 0;
            maxLevel = 90;
            waypoints.Clear();
            ghostWaypoints.Clear();
            factions.Clear();
        }

        private static Vector3 xmltoVector3(XmlNode node)
        {
            string[] data = node.InnerText.Split(' ');
            return new Vector3(float.Parse(data[0]), float.Parse(data[1]), 0);
        }

        public static void loadScript()
        {
            clearData();

            XmlDocument script = new XmlDocument();

            script.Load(@"C:\Users\Andrew\Desktop\Profiles(1)\Profiles\1-30 Alliance\1-20\1-20 Human\1-10\01-10 Elwynn Forest.xml");
            XmlNodeList wayList = script.GetElementsByTagName("Waypoint");
            XmlNodeList ghostList = script.GetElementsByTagName("GhostWaypoint");
            XmlNode factionList = script.SelectSingleNode("Factions");
            factions = int.Parse(factionList.InnerText.Split(' '));
            minLevel = int.Parse(script.SelectSingleNode("MinLevel").InnerXml);
            maxLevel = int.Parse(script.SelectSingleNode("MaxLevel").InnerXml);
            for (int i = 0; i < wayList.Count; i++)
            {
                waypoints.Add(xmltoVector3(wayList[i]));
            }
            for (int i = 0; i < ghostList.Count; i++)
            {
                ghostWaypoints.Add(xmltoVector3(ghostList[i]));
            }
            for (int i = 0; i < ghostList.Count; i++)
            {
                factions.Add(int.Parse(ghostList[i].InnerText));
            }
        }

        public static List<Vector3> Waypoints()
        {
            return waypoints;
        }
    }
}
