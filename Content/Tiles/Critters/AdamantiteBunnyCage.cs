using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TheCollectors.Content.Items.Consumables.Critters;

namespace TheCollectors.Content.Tiles.Critters
{
	public class AdamantiteBunnyCage : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.AmberBunnyCage);
			Item.createTile = ModContent.TileType<AdamantiteBunnyCageTile>();
		}
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<AdamantiteBunnyItem>(), 1)
				.AddIngredient(ItemID.Terrarium, 1)
				.AddTile(TileID.WorkBenches)
				.SortAfterFirstRecipesOf(ItemID.AmberBunnyCage) // places the recipe right after vanilla frog cage recipe.
				.Register();
		}
	}
	public class AdamantiteBunnyCageTile : ModTile
	{
		public override void SetStaticDefaults()
		{
            // Here we just copy a bunch of values from the frog cage tile
            TileID.Sets.CritterCageLidStyle[Type] = TileID.Sets.CritterCageLidStyle[TileID.AmberBunnyCage]; // This is how vanilla draws the roof of the cage
            Main.tileFrameImportant[Type] = Main.tileFrameImportant[TileID.AmberBunnyCage];
            Main.tileLavaDeath[Type] = Main.tileLavaDeath[TileID.AmberBunnyCage];
            Main.tileSolidTop[Type] = Main.tileSolidTop[TileID.AmberBunnyCage];
            Main.tileTable[Type] = Main.tileTable[TileID.AmberBunnyCage];
            AdjTiles = [TileID.AmberBunnyCage, TileID.GoldBunnyCage]; // Just in case another mod uses the frog cage to craft
            AnimationFrameHeight = 54;

            TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.AmberBunnyCage, 0));
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(122, 217, 232), ModContent.GetInstance<AdamantiteBunnyCage>().DisplayName);
		}
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY = 2; // From vanilla
            Main.critterCage = true; // Vanilla doesn't run the animation code for critters unless this is checked
        }
        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
            Tile tile = Main.tile[i, j];
            int tileCageFrameIndex = TileDrawing.GetBigAnimalCageFrame(i, j, tile.TileFrameX, tile.TileFrameY);
            frameYOffset = Main.bunnyCageFrame[tileCageFrameIndex] * AnimationFrameHeight;
        }
	}
}