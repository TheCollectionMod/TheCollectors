using TheCollectors.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheCollectors.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteSink : ModTile
	{
		public override void SetStaticDefaults()
		{
			// Hielo! As you may have noticed, this is a sink --- and as such, it ought to be a water source, right?
			// Well, let's do it one better, shall we?
			TileID.Sets.CountsAsWaterSource[Type] = true;
			//TileID.Sets.CountsAsHoneySource[Type] = true;
			TileID.Sets.CountsAsLavaSource[Type] = true;
			// By using these three sets, we've registered our sink as counting as a water, lava, and honey source for crafting purposes! The future is now.
			// Each one works individually and independently of the other two, so feel free to make your sink a source for whatever you'd like it to be!

			// ...modded liquids sold separately.

			Main.tileSolid[Type] = false;
			Main.tileLavaDeath[Type] = false;
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.addTile(Type);

			AddMapEntry(new Color(100, 100, 100));

			DustType = 84;
			AdjTiles = new int[] { Type };
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteSink>());
		}
	}
}