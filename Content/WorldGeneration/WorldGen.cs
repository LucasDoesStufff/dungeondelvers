/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubworldLibrary;
using Terraria;
using Terraria.WorldBuilding;

namespace dungeondelvers.Content.WorldGeneration
{
    internal class DungeonGeneration : Subworld
    {
        public override int Width => 2000;
        public override int Height => 1500;
        public override List<GenPass> Tasks { get; }

        public override void OnEnter()
        {
            SubworldSystem.hideUnderworld = true;
            Main.worldSurface = 0;
            GenVars.worldSurfaceHigh = 0;
            GenVars.worldSurfaceLow = 0;
            GenVars.rockLayer = Main.maxTilesY / 2;
            GenVars.oceanWaterStartRandomMin = 0;
            GenVars.oceanWaterStartRandomMax = 0;
        }
    }
}*/
