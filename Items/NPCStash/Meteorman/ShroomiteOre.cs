using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.NPCStash.Meteorman
{
	public class ShroomiteOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Ore");

			// Be sure to have "using Terraria.Localization".
			//DisplayName.AddTranslation(GameCulture.Spanish, "Meteorito endurecido");

			ItemID.Sets.SortingPriorityMaterials[Item.type] = 89; // influences the inventory sort order. 89 is HallowedBar, higher is more valuable.
		}
		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.MeteormanStash.ShroomiteOre>();
			Item.rare = ItemRarityID.Lime;
			Item.width = 12;
			Item.height = 12;
			Item.value = 3000;
		}
	}
}
