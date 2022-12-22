using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Pets
{
	public class LivingSpaceRock : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Living Space Rock");
			Tooltip.SetDefault("Summons a friendly Meteor Head");
			//DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Roca espacial viviente");
			//Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Invoca a una amigable Cabeza de Meteorito");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
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
			Item.shoot = ModContent.ProjectileType<Projectiles.Pets.LivingSpaceRock>();
			Item.buffType = BuffType<Buffs.LivingSpaceRock>();
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