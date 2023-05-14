using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Pets.LivingSpaceRock
{
	public class LivingSpaceRockItem : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Living Space Rock");
			// Tooltip.SetDefault("Summons a friendly Meteor Head");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 0;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.width = 16;
			Item.height = 30;
			Item.UseSound = SoundID.Item2;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.rare = ItemRarityID.Yellow;
			Item.noMelee = true;
			Item.value = 55000;
			Item.shoot = ModContent.ProjectileType<Pets.LivingSpaceRock.LivingSpaceRockProjectile>();
			Item.buffType = BuffType<Pets.LivingSpaceRock.LivingSpaceRockBuff>();
		}
		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
	}
}