using dungeondelvers.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using SteelSeries.GameSense;

namespace dungeondelvers.Core.AstarPathfinding.Gen
{
    internal class AStarPathfinding : ModSystem
    {
        public record struct PathNode(Point16 Point, int FCost, int HCost);

        private readonly SortedSet<PathNode> path = new SortedSet<PathNode>(); 
        private readonly HashSet<Point16> closedSet = new HashSet<Point16>(); 
        private readonly List<Point16>  reconstructPath = new List<Point16>();
        int timer = 0;
        private Point16 Start { get; set; }
        private Point16 Goal;

        static Point16[] offsets { get; } = new Point16[] { new Point16(-1, 0), new Point16(1, 0), new Point16(0, -1), new Point16(0, 1) };

        public override void PostUpdateWorld()
        {
            timer++;
            if (timer >= 60)
            {
                timer = 0;
                //PopulateLists();
                //ReConstructPath(FindPath(new(1, 1), new(2, 2), new(1, 1)));
            }
        }

        void PopulateLists()
        {
            closedSet.Clear();
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    if (Main.tile[i, j].HasTile)
                    {
                        closedSet.Add(new(i,j));
                    }
                }
            }
        }

        List<Point16> FindPath(Point16 start, Point16 goal, Point16 current)
        {
            closedSet.Add(current);
            for (int i = 0; i < offsets.Length; i++)
            {
                
                Point16 aroundCurrent = offsets[i] + current;
                if(!closedSet.Contains(aroundCurrent))
                {
                    
                    int Hcost = CalculateCost(aroundCurrent, goal);
                    int Gcost = CalculateCost(aroundCurrent, start);
                    int Fcost = Hcost + Gcost;
                    path.Add(new PathNode(aroundCurrent, Fcost, Hcost));

                }
                /// thank you jupiter.ryo for helping
                if (path.Count > 0)
                {
                    // get the minimum F-cost in the path
                    int minFcost = path.Min(p => p.FCost);

                    // get all nodes with the same minimum F-cost
                    var nodesWithMinFcost = path.Where(p => p.FCost == minFcost).ToList();

                    // select the node with the smallest H-cost if there are multiple nodes with the same F-cost
                    var bestNode = nodesWithMinFcost.Count > 1
                        ? nodesWithMinFcost.MinBy(p => p.HCost)
                        : nodesWithMinFcost[0];
                    // add the best node to the reconstruct path and closed set
                    reconstructPath.Add(bestNode.Point);
                    closedSet.Add(bestNode.Point);
                    current = bestNode.Point;
                }
            }
            return current == goal ? reconstructPath : new List<Point16>();
        }

        void ReConstructPath(List<Point16> reconstructPath)
        {
            foreach (var node in reconstructPath)
            {
                WorldGen.PlaceTile(node.X, node.Y, TileID.GrayBrick);
            }
        }

        int CalculateCost(Point16 current, Point16 other) => Math.Abs(current.X - other.X) + Math.Abs(current.Y - other.Y);
    }
}