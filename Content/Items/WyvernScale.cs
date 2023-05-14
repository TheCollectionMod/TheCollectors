using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TheCollectors.Content.Items
{
	public class WyvernScale : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wyvern Scale");
			// Be sure to have "using Terraria.Localization".
			//DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Escama de guiverno");
			//Tooltip.SetDefault("This is a modded item.");
			//Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Escama de guiverno");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 20;
			Item.value = Item.sellPrice(0, 0, 3, 0);
			Item.rare = ItemRarityID.Orange;
			Item.maxStack = 999;
		}
	}
}
