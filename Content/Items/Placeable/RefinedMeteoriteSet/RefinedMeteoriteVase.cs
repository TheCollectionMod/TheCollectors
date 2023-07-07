using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteVase : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.ObsidianVase);
			//Item.width = 12;
			//Item.height = 12;
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteVase>();
			//Item.createTile = TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteVase>();
		}
	}
}