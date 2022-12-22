using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	internal class RefinedMeteoriteAnimatedLantern : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Firefly in a Bottle");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.FireflyinaBottle);
			Item.rare = ItemRarityID.White;
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteAnimatedLantern>();
		}
	}
}

