using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;

namespace TheCollectors.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteVase : ModTile
	{
		public override void SetStaticDefaults()
		{
			// Properties
			Main.tileLavaDeath[Type] = false;
			Main.tileFrameImportant[Type] = true;

			// Names
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Refined Meteorite Vase");
			AddMapEntry(new Color(100, 100, 100));

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
			TileObjectData.addTile(Type);
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteVase>());
		}
	}
}