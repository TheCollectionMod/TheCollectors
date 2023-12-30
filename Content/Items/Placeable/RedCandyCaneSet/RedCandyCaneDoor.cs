using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RedCandyCaneSet
{
	public class RedCandyCaneDoor : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.RedCandyCaneSet.RedCandyCaneDoorClosed>());
			Item.width = 14;
			Item.height = 28;
			Item.value = 150;
		}
	}
}