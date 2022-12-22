using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;

namespace TheCollectors.Items.Placeable.MeteormanStash
{
	public class HellstonePot : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hellstone Pot");
			Tooltip.SetDefault("Plant an acorn here and it will grow a Hellstone ore tree!");
		}

		public override void SetDefaults() {
			Item.width = 28;
			Item.height = 14;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 150;
			Item.rare = ItemRarityID.Orange;
			Item.createTile = TileType<Tiles.MeteormanStash.HellstonePot>();
		}
	}
}