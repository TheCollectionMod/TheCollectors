using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TheCollectors.Content.Items.Consumables.Critters;

namespace TheCollectors.Content.Tiles.Critters
{
    public class StardustSquirrelCage : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AmberSquirrelCage);
            Item.createTile = ModContent.TileType<StardustSquirrelCageTile>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<StardustSquirrelItem>(), 1)
                .AddIngredient(ItemID.Terrarium, 1)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ItemID.AmberSquirrelCage)
                .Register();
        }
    }
    public class StardustSquirrelCageTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.CritterCageLidStyle[Type] = TileID.Sets.CritterCageLidStyle[TileID.AmberSquirrelCage];
            Main.tileFrameImportant[Type] = Main.tileFrameImportant[TileID.AmberSquirrelCage];
            Main.tileLavaDeath[Type] = Main.tileLavaDeath[TileID.AmberSquirrelCage];
            Main.tileSolidTop[Type] = Main.tileSolidTop[TileID.AmberSquirrelCage];
            Main.tileTable[Type] = Main.tileTable[TileID.AmberSquirrelCage];
            AdjTiles = [TileID.AmberSquirrelCage, TileID.SquirrelGoldCage];
            AnimationFrameHeight = 54;

            TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.AmberSquirrelCage, 0));
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(122, 217, 232), ModContent.GetInstance<StardustSquirrelCage>().DisplayName);
        }
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY = 2;
            Main.critterCage = true;
        }
        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
            Tile tile = Main.tile[i, j];
            int tileCageFrameIndex = TileDrawing.GetBigAnimalCageFrame(i, j, tile.TileFrameX, tile.TileFrameY);
            frameYOffset = Main.squirrelCageFrame[tileCageFrameIndex] * AnimationFrameHeight;
        }
    }
}