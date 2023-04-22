using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.Utilities;
using ItemID = Terraria.ID.ItemID;
using NPCID = Terraria.ID.NPCID;

namespace TheCollectors.Tiles.Trees
{
    class ShroomiteTree : ModTree
	{
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
			GrowsOnTileId = new int[1] { ModContent.TileType<Items.NPCStash.Meteorman.ShroomiteSoilTile>() };
		}
		public override Asset<Texture2D> GetTexture()
		{
			return ModContent.Request<Texture2D>("TheCollectors/Tiles/Trees/ShroomiteTree");
		}       // This is the primary texture for the trunk. Branches and foliage use different settings.
		public override Asset<Texture2D> GetBranchTextures()
		{
			return ModContent.Request<Texture2D>("TheCollectors/Tiles/Trees/ShroomiteTree_Branches");
		}       // Branch Textures
		public override Asset<Texture2D> GetTopTextures()
		{
			return ModContent.Request<Texture2D>("TheCollectors/Tiles/Trees/ShroomiteTree_Tops");
		}       // Top Textures
		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return ModContent.TileType<ShroomiteTreeSapling>();
		} 
		public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
		{
			// This is where fancy code could go, but let's save that for an advanced example
		}
		public override int DropWood()
		{
			return ModContent.ItemType<Items.NPCStash.Meteorman.ShroomiteOre>();
		}
		public enum ShroomiteTreeShakeEffect
		{
			None = 0,
			Acorn,
			NPC,
			Gore,
			Fruit
		}
		public override bool Shake(int x, int y, ref bool createLeaves)
		{
			WeightedRandom<ShroomiteTreeShakeEffect> options = new WeightedRandom<ShroomiteTreeShakeEffect>();
			options.Add(ShroomiteTreeShakeEffect.None, 1f);
			options.Add(ShroomiteTreeShakeEffect.Acorn, 0.8f);
			options.Add(ShroomiteTreeShakeEffect.NPC, 0.8f);
			//options.Add(CopperTreeShakeEffect.Gore, 0.5f);
			options.Add(ShroomiteTreeShakeEffect.Fruit, 0.8f);

			ShroomiteTreeShakeEffect effect = options;
			if (effect == ShroomiteTreeShakeEffect.Acorn)
			{
				Vector2 offset = this.GetRandomTreePosition(Main.tile[x, y]);
				Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16 + offset, ItemID.Acorn, Main.rand.Next(1, 3));
			}
			else if (effect == ShroomiteTreeShakeEffect.NPC)
			{
				WeightedRandom<int> npcType = new WeightedRandom<int>();
				npcType.Add(ModContent.NPCType<NPCs.Critters.ShroomiteSquirrel>(),1); 

				Vector2 offset = this.GetRandomTreePosition(Main.tile[x, y]);
				Vector2 pos = new Vector2(x * 16, y * 16) + offset;
				NPC.NewNPC(WorldGen.GetItemSource_FromTreeShake(x, y), (int)pos.X, (int)pos.Y, npcType);
			}
			/*else if (effect == CopperTreeShakeEffect.Gore)
			{
				WeightedRandom<int> goreType = new WeightedRandom<int>();
				goreType.Add(911, 1); // Gores
				goreType.Add(912, 0.6f); // Gores

				Vector2 offset = this.GetRandomTreePosition(Main.tile[x, y]);
				Gore.NewGore(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16 + offset, Vector2.Zero, goreType);
			}*/
			else if (effect == ShroomiteTreeShakeEffect.Fruit)
			{
				WeightedRandom<int> getRepeats = new WeightedRandom<int>();
				getRepeats.Add(1, 1f);
				getRepeats.Add(2, 0.2f);
				getRepeats.Add(4, 0.1f);
				getRepeats.Add(8, 0.01f);

				int repeats = getRepeats;
				for (int i = 0; i < repeats; ++i)
				{
					Vector2 offset = this.GetRandomTreePosition(Main.tile[x, y]);
					Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16 + offset, Main.rand.NextBool() ? ModContent.ItemType<Items.Consumables.Food.ShroomiteFruit>() : ModContent.ItemType<Items.Consumables.Food.ShroomiteFruit>(), 1);
				}
			}

			createLeaves = effect != ShroomiteTreeShakeEffect.None;
			return false;
		}
		public override int TreeLeaf()
		{
			return ModContent.GoreType<ShroomiteTreeLeaf>();
		}
	}
}
