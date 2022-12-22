using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameContent.Metadata;
using Terraria.ObjectData;

namespace TheCollectors.Items.Placeable.MeteormanStash
{
	public class CopptinAcorn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Copptin Acorn");
			Tooltip.SetDefault("'Grows a Strange Plant small enough to fit in a plant pot'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}

		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 22;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 20;
			//Item.createTile = ModContent.TileType<Tiles.Trees.ShroomiteTreeSapling>("TinTreeSapling");
			Item.rare = ItemRarityID.Orange;
			//Item.createTile = ModContent.TileType<Tiles.ExampleHerb>();
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Trees.CopptinTreeSapling>());
			//Item.createTile = ModContent.TileType<Tiles.Trees.ChlorophyteTreeSapling>();
			//Item.CloneDefaults(ItemID.GemTreeAmberSeed);
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3385, 1);
			recipe.AddTile(mod.TileType("CultivationBox"));
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}*/
	}
}