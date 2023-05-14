using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteLamp : ModItem
	{
		// This example uses LocalizedText.Empty to prevent any translation key from being generated. This can be used for items that definitely won't have a tooltip, keeping the localization file cleaner.
		public override LocalizedText Tooltip => LocalizedText.Empty;

		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteLamp>());
			Item.width = 12;
			Item.height = 12;
			Item.value = 3000; // in copper coins
		}
	}
}

