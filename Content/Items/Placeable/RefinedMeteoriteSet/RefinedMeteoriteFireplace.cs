using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet
{
	public class RefinedMeteoriteFireplace : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Refined Meteorite Fireplace");
			// Tooltip.SetDefault("Life regen is increased when near a fireplace");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.Fireplace);
			Item.width = 24;
			Item.height = 32;
			Item.createTile = ModContent.TileType<Tiles.RefinedMeteoriteSet.RefinedMeteoriteFireplace>();
		}
	}
}
