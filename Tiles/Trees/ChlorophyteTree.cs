using IL.Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using ReLogic.Content;
using Terraria.GameContent;

namespace TheCollectors.Tiles.Trees
{
    class ChlorophyteTree : ModTree
	{
		// This is a blind copy-paste from Vanilla's PurityPalmTree settings.
		//TODO: This needs some explanations
		public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
		{
			UseSpecialGroups = true,
			SpecialGroupMinimalHueValue = 11f / 72f,
			SpecialGroupMaximumHueValue = 0.25f,
			SpecialGroupMinimumSaturationValue = 0.88f,
			SpecialGroupMaximumSaturationValue = 1f
		};

		public override void SetStaticDefaults()
		{
			//GrowsOnTileId = new int[1] { TileID.Gold };
			// Makes Example Tree grow on ExampleBlock
			GrowsOnTileId = new int[1] { ModContent.TileType<ShroomiteOre>() };
		}

		// This is the primary texture for the trunk. Branches and foliage use different settings.
		public override Asset<Texture2D> GetTexture()
		{
			return ModContent.Request<Texture2D>("TheCollectors/Tiles/Trees/ChlorophyteTree");
		}

		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return ModContent.TileType<ChlorophyteTreeSapling>();
		}

		public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
		{
			// This is where fancy code could go, but let's save that for an advanced example
		}

		// Branch Textures
		public override Asset<Texture2D> GetBranchTextures()
		{
			return ModContent.Request<Texture2D>("TheCollectors/Tiles/Trees/ChlorophyteTree_Branches");
		}

		// Top Textures
		public override Asset<Texture2D> GetTopTextures()
		{
			return ModContent.Request<Texture2D>("TheCollectors/Tiles/Trees/ChlorophyteTree_Tops");
		}

		public override int DropWood()
		{
			//return ItemType<ChlorophyteOre>();
			return ModContent.ItemType<Items.Placeable.ShroomiteOre>();
		}

		public override bool Shake(int x, int y, ref bool createLeaves)
		{
			Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16, ModContent.ItemType<Items.Placeable.ThrowingDummy>());
			return false;
		}

		public override int TreeLeaf()
		{
			return ModContent.GoreType<ChlorophyteTreeLeaf>();
		}
	}
	/*{
        private Mod mod => ModLoader.GetMod("TheCollectors");
        public override int CreateDust()
        {
            return DustType<Sparkle>();
        }

        public override int GrowthFXGore()
        {
            return mod.GetGoreSlot("Gores/ShroomiteTreeFX");
        }

        public override int DropWood()
        { 
            return mod.ItemType("ShroomiteOre");  // TODO
         }
        public override Texture2D GetTexture()
        {
            return mod.GetTexture("Tiles/Trees/ShroomiteTree");    //add where is u'r tree tile
        }

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame)
        {
            return mod.GetTexture("Tiles/Trees/ShroomiteTree_Branches"); //add where is u'r tree branches tile
        }

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            frameWidth = 114;
            frameHeight = 96;
            yOffset += 2;
            xOffsetLeft += 16;
            return mod.GetTexture("Tiles/Trees/ShroomiteTree_Top"); //add where is u'r tree tops tile 
        }
    }*/
}
