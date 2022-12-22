using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Mounts
{
	public class MeteorHoverboardKey : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Meteor Hoverboard Key");
			Tooltip.SetDefault("Great for exploring floating islands.");
			//DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Llave de Hoverboard");
			//Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Estupendo para explorar islas flotantes.");
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 30;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = 30000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item79;
			Item.noMelee = true;
			Item.mountType = ModContent.MountType<Mounts.MeteorHoverboard>();
		}
	}
}