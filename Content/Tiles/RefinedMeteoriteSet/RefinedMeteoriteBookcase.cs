using TheCollectors.Content.Dusts;
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

namespace TheCollectors.Content.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteBookcase : ModTile
	{
		public override void SetStaticDefaults()
		{
			// Properties
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileSolidTop[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;

			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

			DustType = ModContent.DustType<Sparkle>();
			AdjTiles = new int[] { TileID.Bookcases };

			// Names
			AddMapEntry(new Color(191, 142, 111), Language.GetText("MapObject.Bookcase"));

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 16, 18 };
			TileObjectData.addTile(Type);
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		/*public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBookcase>());
		}*/
	}
}