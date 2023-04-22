using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Placeable.RefinedMeteoriteSet
{
	internal class RefinedMeteoriteAnimatedLantern : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteorite Fairy in a Bottle");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.FireflyinaBottle);
			Item.width = 12;
			Item.height = 12;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.White;
			Item.maxStack = 99;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteAnimatedLantern>();
		}
	}
}

