using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Pets.FlyingEyeling
{
	public class FlyingEyelingItem : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Flying Eyeling");
			// Tooltip.SetDefault("Summons a friendly Flying Eyeling");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.BoneRattle); // Copy the Defaults of the Zephyr Fish Item.
			/*Item.damage = 0;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.width = 26;
			Item.height = 34;
			Item.UseSound = SoundID.Item2;pues 2
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.rare = ItemRarityID.Yellow;
			Item.noMelee = true;
			Item.value = 55000;*/
			Item.shoot = ModContent.ProjectileType<FlyingEyelingProjectile>();
			Item.buffType = BuffType<FlyingEyelingBuff>();
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