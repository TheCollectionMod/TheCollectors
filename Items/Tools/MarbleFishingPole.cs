using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;


namespace TheCollectors.Items.Tools
{
	public class MarbleFishingPole : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Marble Fishing Pole");

			// Allows the pole to fish in lava
			ItemID.Sets.CanFishInLava[Item.type] = false;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ReinforcedFishingPole);
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.shoot = ModContent.ProjectileType<Projectiles.BobberMarble>();
			Item.shootSpeed = 20f;
			Item.fishingPole = 18;
			Item.value = Item.sellPrice(0, 0, 25, 0);
			Item.value = Item.buyPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
		}
	}
}
