using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RedCandyCaneSet
{
	public class RedCandyCaneBed : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RedCandyCaneSet.RedCandyCaneBed>());
			Item.width = 34;
			Item.height = 22;
			Item.value = 2000;
		}
	}
}