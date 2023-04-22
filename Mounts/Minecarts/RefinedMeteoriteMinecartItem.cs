using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Mounts.Minecarts
{
	public class RefinedMeteoriteMinecartItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Refined Meteorite Minecart");
			Tooltip.SetDefault("Template");

			MountID.Sets.Cart[Item.mountType] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = 25000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item69; //nice
			Item.noMelee = true;
			Item.mountType = ModContent.MountType<RefinedMeteoriteMinecart>();
		}

		public override bool CanUseItem(Player player) => false; //the player shouldn't be able to use this item but they can so that's cool I guess don't worry
	}
}