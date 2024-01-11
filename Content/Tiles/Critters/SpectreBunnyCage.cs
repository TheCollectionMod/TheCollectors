using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TheCollectors.Content.Items.Consumables.Critters;

namespace TheCollectors.Content.Tiles.Critters
{
    public class SpectreBunnyCage : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AmberBunnyCage);
            Item.createTile = ModContent.TileType<SpectreBunnyCageTile>();
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SpectreBunnyItem>(), 1)
                .AddIngredient(ItemID.Terrarium, 1)
                .AddTile(TileID.WorkBenches)
                .SortAfterFirstRecipesOf(ItemID.AmberBunnyCage)
                .Register();
        }
    }
    public class SpectreBunnyCageTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.CritterCageLidStyle[Type] = TileID.Sets.CritterCageLidStyle[TileID.AmberBunnyCage];
            Main.tileFrameImportant[Type] = Main.tileFrameImportant[TileID.AmberBunnyCage];
            Main.tileLavaDeath[Type] = Main.tileLavaDeath[TileID.AmberBunnyCage];
            Main.tileSolidTop[Type] = Main.tileSolidTop[TileID.AmberBunnyCage];
            Main.tileTable[Type] = Main.tileTable[TileID.AmberBunnyCage];
            AdjTiles = [TileID.AmberBunnyCage, TileID.GoldBunnyCage];
            AnimationFrameHeight = 54;

            TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.AmberBunnyCage, 0));
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(122, 217, 232), ModContent.GetInstance<SpectreBunnyCage>().DisplayName);
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
            frameYOffset = Main.bunnyCageFrame[tileCageFrameIndex] * AnimationFrameHeight;
        }
    }
}