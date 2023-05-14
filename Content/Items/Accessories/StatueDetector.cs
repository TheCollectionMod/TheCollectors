/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;

namespace TheCollectors.Items.Accessories
{
    public class StatueDetector : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radar Statue");
            // Tooltip.SetDefault("Shows the location of nearby statues on the map");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item44;
            Item.autoReuse = false;
        }

        /*public override bool? UseItem(Player player)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return false;
            }

            // Get all nearby statues
            int range = 1000;
            Vector2 playerCenter = player.Center;
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    Tile tile = Main.tile[i, j];
                    if (tile.TileType == TileID.Statues && Vector2.Distance(new Vector2(i * 16, j * 16), playerCenter) < range)
                    {
                        // Mark the tile on the map
                        Main.Map.Update(i, j, 255);
                    }
                }
            }
            return true;
        }
    }
}*/