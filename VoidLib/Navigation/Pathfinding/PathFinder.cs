using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackRain.Navigation.Pathfinding
{
    public class PathFinder
    {
        public static List<PathNode> findPath(PathNode firstNode, PathNode destinationNode)
        {
            List<PathNode> openNodes = new List<PathNode>();
            List<PathNode> closedNodes = new List<PathNode>();

            PathNode currentNode = firstNode;
            PathNode testNode;

            int l = 0;
            int i = 0;
            float g;
            float h;
            float f;

            List<PathNode> connectedNodes;
            float travelCost = 1.0f;

            currentNode.g = 0;
            currentNode.h = euclidianHeuristic(currentNode, destinationNode, travelCost);
            currentNode.f = currentNode.g + currentNode.h;

            while (currentNode != destinationNode)
            {
                Console.WriteLine("Working");
                connectedNodes = currentNode.getConnections();

                l = connectedNodes.Count;

                for (int x = 0; x < l; x++)
                {
                    testNode = connectedNodes[x];

                    if (testNode == currentNode || testNode.traversable == false) continue;

                    g = currentNode.g + travelCost;
                    h = euclidianHeuristic(testNode, destinationNode, travelCost);
                    f = g + h;

                    if (isOpen(testNode, openNodes) || isClosed(testNode, closedNodes))
                    {
                        if (testNode.f > f)
                        {
                            testNode.f = f;
                            testNode.g = g;
                            testNode.h = h;
                            testNode.parentNode = currentNode;
                        }
                    }
                    else
                    {
                        testNode.f = f;
                        testNode.g = g;
                        testNode.h = h;
                        testNode.parentNode = currentNode;
                        openNodes.Add(testNode);
                    }
                }

                closedNodes.Add(currentNode);

                if (openNodes.Count == 0)
                {
                    return null;
                }

                openNodes.OrderBy(on => on.f);
                currentNode = openNodes[0];
            }

            return buildPath(destinationNode, firstNode);
        }

        public static List<PathNode> buildPath(PathNode destinationNode, PathNode startNode)
        {			
			List<PathNode> path = new List<PathNode>();

            PathNode node = destinationNode;
			path.Add(node);

			while (node != startNode)
            {
				node = node.parentNode;
				path.Remove(node);
			}
			
			return path;			
		}

        public static bool isOpen(PathNode node, List<PathNode> openNodes)
        {
			int l = openNodes.Count;;
            for (int i = 0; i < l; ++i)
            {
				if ( openNodes[i] == node ) return true;
			}
			
			return false;			
		}

        public static bool isClosed(PathNode node, List<PathNode> closedNodes)
        {			
			int l = closedNodes.Count;
            for (int i = 0; i < l; ++i)
            {
				if (closedNodes[i] == node ) return true;
			}
			
			return false;
		}

        public static float euclidianHeuristic(PathNode node, PathNode destinationNode, float cost = 1.0f)
		{
			float dx = node.x - destinationNode.x;
			float dy = node.y - destinationNode.y;
			
			return (float)Math.Sqrt(dx * dx + dy * dy) * cost;
		}
    }
}
