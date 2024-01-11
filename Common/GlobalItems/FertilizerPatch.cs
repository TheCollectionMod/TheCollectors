using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Common.GlobalItems
{
    public class FertilizerPatch : GlobalItem
    {
        public override Nullable<bool> UseItem(Item item, Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (item.type == ItemID.Fertilizer)
            {
                int targetX = (int)(Main.MouseWorld.X / 16f);
                int targetY = (int)(Main.MouseWorld.Y / 16f);

                if (targetX >= 0 && targetX < Main.maxTilesX && targetY >= 0 && targetY < Main.maxTilesY)
                {
                    Tile tile = Main.tile[targetX, targetY];

                    if (tile.HasTile && TileID.Sets.CommonSapling[tile.TileType])
                    {
                        bool growSuccess = WorldGen.GrowTree(targetX, targetY);

                        if (growSuccess)
                        {
                            WorldGen.TreeGrowFXCheck(targetX, targetY);
                            return true;
                        }
                    }
                }
            }
            return null;
        }
    }
}