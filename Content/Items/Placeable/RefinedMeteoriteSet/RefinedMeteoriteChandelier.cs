using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	internal class RefinedMeteoriteChandelier : ModItem
	{
		// This example uses LocalizedText.Empty to prevent any translation key from being generated. This can be used for items that definitely won't have a tooltip, keeping the localization file cleaner.
		public override LocalizedText Tooltip => LocalizedText.Empty;

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteChandelier>());
			Item.width = 10;
			Item.height = 24;
			Item.value = 500;
		}
	}
}

