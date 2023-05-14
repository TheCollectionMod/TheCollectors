using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 25;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 89; // influences the inventory sort order. 89 is HallowedBar, higher is more valuable.
			ItemTrader.ChlorophyteExtractinator.AddOption_OneWay(Type, 5, ItemID.HallowedBar, 1);
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteBar>());
			Item.width = 20;
			Item.height = 20;
			Item.rare = ItemRarityID.Orange;
			Item.value = 750;
		}
	}
}
