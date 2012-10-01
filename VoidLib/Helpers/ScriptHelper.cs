using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Microsoft.Xna.Framework;

namespace VoidLib.Helpers
{
    public class ScriptHelper
    {
        static List<Vector3> waypoints = new List<Vector3>();
        static List<Vector3> ghostWaypoints = new List<Vector3>();
        static List<Vector3> vendorWaypoints = new List<Vector3>();
        static List<Vector3> repairWaypoints = new List<Vector3>();
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
            vendorWaypoints.Clear();
            repairWaypoints.Clear();
        }

        private static Vector3 xmltoVector3(XmlNode node)
        {
            string[] data = node.InnerText.Split(' ');
            return new Vector3(float.Parse(data[0]), float.Parse(data[1]), 0);
        }

        public static void loadScript(string file)
        {
            clearData();

            XmlDocument script = new XmlDocument();

            script.Load(file);
            XmlNodeList wayList = script.GetElementsByTagName("Waypoint");
            XmlNodeList ghostList = script.GetElementsByTagName("GhostWaypoint");
            XmlNodeList vendorList = script.GetElementsByTagName("VendorWaypoint");
            XmlNodeList repairList = script.GetElementsByTagName("RepairWaypoint");
            string[] factionList = script.SelectSingleNode("//Factions").InnerText.Split(' ');
            minLevel = int.Parse(script.SelectSingleNode("//MinLevel").InnerXml);
            maxLevel = int.Parse(script.SelectSingleNode("//MaxLevel").InnerXml);

            for (int i = 0; i < wayList.Count; i++)
            {
                waypoints.Add(xmltoVector3(wayList[i]));
            }
            for (int i = 0; i < ghostList.Count; i++)
            {
                ghostWaypoints.Add(xmltoVector3(ghostList[i]));
            }
            for (int i = 0; i < vendorList.Count; i++)
            {
                vendorWaypoints.Add(xmltoVector3(vendorList[i]));
            }
            for (int i = 0; i < repairList.Count; i++)
            {
                repairWaypoints.Add(xmltoVector3(repairList[i]));
            }
            for (int i = 0; i < factionList.Length; i++)
            {
                factions.Add(int.Parse(factionList[i]));
            }
            /*
            Console.WriteLine(minLevel);
            Console.WriteLine(maxLevel);
            waypoints.ForEach(wp => Console.WriteLine(wp.ToString()));
            ghostWaypoints.ForEach(gwp => Console.WriteLine(gwp.ToString()));
            factions.ForEach(f => Console.WriteLine(f.ToString()));
            Console.Read();
            */
        }

        public static int MinLevel
        {
            get { return minLevel; }
        }

        public static int MaxLevel
        {
            get { return maxLevel; }
        }

        public static List<Vector3> Waypoints
        {
            get { return waypoints; }
        }

        public static List<Vector3> GhostWaypoints
        {
            get { return ghostWaypoints; }
        }

        public static List<Vector3> VendorWaypoints
        {
            get { return vendorWaypoints; }
        }

        public static List<Vector3> RepairWaypoints
        {
            get { return repairWaypoints; }
        }

        public static List<int> Factions
        {
            get { return factions; }
        }
    }
}
