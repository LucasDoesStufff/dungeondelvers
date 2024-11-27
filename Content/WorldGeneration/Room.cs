using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using dungeondelvers.Content.CustomHooks;
using Terraria;

namespace dungeondelvers.Content.WorldGeneration
{
    public class Room
    {
        public Vector2 Position;
        public Point16 WorldPosition;
        public Rectangle RoomArea;

        public Room(Vector2 position, int roomWidth, int roomHeight)
        {
            Position = position;
            RoomArea = new((int)position.X, (int)position.Y, roomWidth, roomHeight);
        }
    }
    public enum RoomTypes
    {
        Start = 0,
        Normal = 1,
        Treasure = 2,
        Boss = 3
    }
}
