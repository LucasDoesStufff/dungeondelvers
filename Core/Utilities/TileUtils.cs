using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;

namespace dungeondelvers.Core.Utilities
{
    internal static class TileUtils
    {
        /// <summary>
		/// The X position of the Tile
		/// </summary>
		/// <param name="tile"></param>
		/// <returns></returns>
		public static int X(this Tile tile)
        {
            TilePos(tile, out int x, out _);
            return x;
        }

        /// <summary>
		/// The Y position of the Tile
		/// </summary>
		/// <param name="tile"></param>
		/// <returns></returns>
		public static int Y(this Tile tile)
        {
            TilePos(tile, out _, out int y);
            return y;
        }

        /// <summary>
		/// Gets the Position of the tile, the same values that would be inputted in Main.tile to get this Tile
		/// </summary>
		/// <param name="tile"></param>
		/// <param name="x">The outputted X value, if you want the X by itself use Tile.X</param>
		/// <param name="y">The outputted Y value, if you want the Y by itself use Tile.Y</param>
		public static void TilePos(this Tile tile, out int x, out int y)
        {
            uint tileId = Unsafe.BitCast<Tile, uint>(tile);
            x = Math.DivRem((int)tileId, Main.tile.Height, out y); //Thanks to FoxXD_ for the help with this
        }

        /// <summary>
        /// Gets the top-left tile of a multitile
        /// </summary>
        /// <param name="i">The tile X-coordinate</param>
        /// <param name="j">The tile Y-coordinate</param>
        public static Point16 GetTileOrigin(int i, int j)
        {
            //Framing.GetTileSafely ensures that the returned Tile instance is not null
            //Do note that neither this method nor Framing.GetTileSafely check if the wanted coordiates are in the world!
            Tile tile = Framing.GetTileSafely(i, j);

            Point16 coord = new Point16(i, j);
            Point16 frame = new Point16(tile.TileFrameX / 18, tile.TileFrameY / 18);

            return coord - frame;
        }

        /// <summary>
        /// Uses <seealso cref="GetTileOrigin(int, int)"/> to try to get the entity bound to the multitile at (<paramref name="i"/>, <paramref name="j"/>).
        /// </summary>
        /// <typeparam name="T">The type to get the entity as</typeparam>
        /// <param name="i">The tile X-coordinate</param>
        /// <param name="j">The tile Y-coordinate</param>
        /// <param name="entity">The found <typeparamref name="T"/> instance, if there was one.</param>
        /// <returns><see langword="true"/> if there was a <typeparamref name="T"/> instance, or <see langword="false"/> if there was no entity present OR the entity was not a <typeparamref name="T"/> instance.</returns>
        public static bool TryGetTileEntityAs<T>(int i, int j, out T entity) where T : TileEntity
        {
            Point16 origin = GetTileOrigin(i, j);

            //TileEntity.ByPosition is a Dictionary<Point16, TileEntity> which contains all placed TileEntity instances in the world
            //TryGetValue is used to both check if the dictionary has the key, origin, and get the value from that key if it's there
            if (TileEntity.ByPosition.TryGetValue(origin, out TileEntity existing) && existing is T existingAsT)
            {
                entity = existingAsT;
                return true;
            }

            entity = null;
            return false;
        }
    }
}
