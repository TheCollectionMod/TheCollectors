using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace TheCollectors.Content.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteVase : ModTile
	{
		public override void SetStaticDefaults()
		{
			// Properties
			Main.tileFrameImportant[Type] = true;
			/*Main.tileSolid[Type] = false;
			Main.tileNoSunLight[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;*/

			//AdjTiles = new int[] { TileID.Statues};

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
		    TileObjectData.newTile.Height = 3;
			//TileObjectData.newTile.DrawYOffset = 2; // So the tile sinks into the ground
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };

			// Register the tile data itself
			TileObjectData.addTile(Type);

			// Names
			//LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(191, 142, 111), Language.GetText("MapObject.Vase"));
		}
		/*public override bool CreateDust(int i, int j, ref int type)
		{
			return false;
		}*/

		/*public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}*/
		/*public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteVase>());
		}*/
	}
}