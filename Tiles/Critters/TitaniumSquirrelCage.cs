using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace TheCollectors.Tiles.Critters
{
	public class TitaniumSquirrelCage : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanium Squirrel Cage");
		}
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.AmberBunnyCage);
			Item.createTile = ModContent.TileType<TitaniumSquirrelCageTile>();
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.Consumables.Critters.TitaniumSquirrelItem>(), 1);
			recipe.AddIngredient(ItemID.Terrarium, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
	public class TitaniumSquirrelCageTile : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = true;
			//TileObjectData.newTile.CopyFrom(TileObjectData.StyleSmallCage);  //The StyleSmallCage es la del ratón
			TileObjectData.newTile.CopyFrom(TileObjectData.Style6x3);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
			TileObjectData.addTile(Type);
			AnimationFrameHeight = 54;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Titanium Squirrel Cage");
			AddMapEntry(new Color(200, 200, 200), name);
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<TitaniumSquirrelCage>());
		}
		public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
		{
			Tile tile = Main.tile[i, j];
			Main.critterCage = true;
			int left = i - tile.TileFrameX / 18;
			int top = j - tile.TileFrameY / 18;
			int offset = left / 3 * (top / 3);
			offset %= Main.cageFrames;
			frameYOffset = Main.squirrelCageFrame[offset] * AnimationFrameHeight;
		}
	}
}
