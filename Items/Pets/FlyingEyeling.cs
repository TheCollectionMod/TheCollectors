using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Pets
{
	public class FlyingEyeling : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Flying Eyeling");
			Tooltip.SetDefault("Summons a friendly FlyingEyeling");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.damage = 0;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.width = 26;
			Item.height = 34;
			Item.UseSound = SoundID.Item2;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.rare = ItemRarityID.Yellow;
			Item.noMelee = true;
			Item.value = 55000;
			Item.shoot = ModContent.ProjectileType<Projectiles.Pets.FlyingEyeling>();
			Item.buffType = BuffType<Buffs.FlyingEyeling>();
		}
		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600);
			}
		}
	}
}