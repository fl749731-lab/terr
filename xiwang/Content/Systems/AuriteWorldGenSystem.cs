using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace xiwang.Content.Systems
{
    public class AuriteWorldGenSystem : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(t => t.Name == "Shinies");
            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Aurite Ore", GenerateAurite));
            }
        }

        private void GenerateAurite(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Aurite Ore";

            int attempts = (int)(Main.maxTilesX * Main.maxTilesY * 0.00006); // density

            for (int i = 0; i < attempts; i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 200); // cave layer

                if (!IsInSnowCaves(x, y))
                    continue;

                WorldGen.TileRunner(
                    x, y,
                    strength: WorldGen.genRand.Next(3, 6),
                    steps: WorldGen.genRand.Next(4, 9),
                    type: ModContent.TileType<xiwang.Content.Tiles.AuriteOre>(),
                    addTile: true
                );
            }
        }

        private static bool IsInSnowCaves(int x, int y)
        {
            if (y < WorldGen.rockLayer || y >= Main.UnderworldLayer)
                return false;

            // Check a small neighborhood for snow/ice terrain
            for (int i = x - 3; i <= x + 3; i++)
            {
                for (int j = y - 3; j <= y + 3; j++)
                {
                    if (i < 0 || i >= Main.maxTilesX || j < 0 || j >= Main.maxTilesY)
                        continue;

                    Tile t = Main.tile[i, j];
                    if (t == null) continue;

                    ushort tileType = t.TileType;
                    if (tileType == TileID.SnowBlock || tileType == TileID.IceBlock)
                        return true;
                }
            }
            return false;
        }
    }
}

