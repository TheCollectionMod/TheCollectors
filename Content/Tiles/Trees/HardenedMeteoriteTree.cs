using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace TheCollectors.Content.Tiles.Trees
{
    class HardenedMeteoriteTree : ModTree
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
			GrowsOnTileId = new int[1] { ModContent.TileType<Items.NPCStash.Meteorman.HardenedMeteoriteSoilTile>() };
		}
		public override Asset<Texture2D> GetTexture()
		{
			return ModContent.Request<Texture2D>("TheCollectors/Content/Tiles/Trees/HardenedMeteoriteTree");
		}       // This is the primary texture for the trunk. Branches and foliage use different settings.
		public override Asset<Texture2D> GetBranchTextures()
		{
			return ModContent.Request<Texture2D>("TheCollectors/Content/Tiles/Trees/HardenedMeteoriteTree_Branches");
		}       // Branch Textures
		public override Asset<Texture2D> GetTopTextures()
		{
			return ModContent.Request<Texture2D>("TheCollectors/Content/Tiles/Trees/HardenedMeteoriteTree_Tops");
		}       // Top Textures
		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return ModContent.TileType<HardenedMeteoriteTreeSapling>();
		} 
		public override void SetTreeFoliageSettings(Tile tile, ref int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
		{
			// This is where fancy code could go, but let's save that for an advanced example
		}
		public override int DropWood()
		{
			return ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.HardenedMeteoriteOre>();
		}
		public enum HardenedMeteoriteTreeShakeEffect
		{
			None = 0,
			Acorn,
			NPC,
			Fruit
		}
		public override bool Shake(int x, int y, ref bool createLeaves)
		{
			WeightedRandom<HardenedMeteoriteTreeShakeEffect> options = new WeightedRandom<HardenedMeteoriteTreeShakeEffect>();
			options.Add(HardenedMeteoriteTreeShakeEffect.None, 1f);
			options.Add(HardenedMeteoriteTreeShakeEffect.Acorn, 0.8f);
			options.Add(HardenedMeteoriteTreeShakeEffect.NPC, 0.8f);
			options.Add(HardenedMeteoriteTreeShakeEffect.Fruit, 0.8f);

			HardenedMeteoriteTreeShakeEffect effect = options;
			if (effect == HardenedMeteoriteTreeShakeEffect.Acorn)
			{
				Vector2 offset = this.GetRandomTreePosition(Main.tile[x, y]);
				Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16 + offset, ItemID.Acorn, Main.rand.Next(1, 3));
			}
			else if (effect == HardenedMeteoriteTreeShakeEffect.NPC)
			{
				WeightedRandom<int> npcType = new WeightedRandom<int>();
				npcType.Add(ModContent.NPCType<NPCs.Critters.HardenedMeteoriteSquirrel>(),1); 

				Vector2 offset = this.GetRandomTreePosition(Main.tile[x, y]);
				Vector2 pos = new Vector2(x * 16, y * 16) + offset;
				NPC.NewNPC(WorldGen.GetItemSource_FromTreeShake(x, y), (int)pos.X, (int)pos.Y, npcType);
			}
			else if (effect == HardenedMeteoriteTreeShakeEffect.Fruit)
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
					Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16 + offset, ModContent.ItemType<Content.Items.Consumables.Food.HardenedMeteoriteFruit>(), Main.rand.Next(1, 3));
				}
			}

			createLeaves = effect != HardenedMeteoriteTreeShakeEffect.None;
			return false;
		}
		public override int TreeLeaf()
		{
			return ModContent.GoreType<HardenedMeteoriteTreeLeaf>();
		}
	}
}
