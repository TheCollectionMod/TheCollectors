using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Pets.Monja
{
    public class MonjaItem : ModItem
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Monja");
            // Tooltip.SetDefault("Summons a Monja light");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults() {
            Item.damage = 0;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shoot = ModContent.ProjectileType<Pets.Monja.MonjaProjectile>();
            Item.width = 16;
            Item.height = 30;
            Item.UseSound = SoundID.Item2;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.rare = ItemRarityID.Yellow;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 5, 50, 0);
            Item.buffType = BuffType<Pets.Monja.MonjaBuff>();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame) { 
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0) 
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}
