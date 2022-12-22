using TheCollectors.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;


namespace TheCollectors.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteBathtub : ModTile
	{
		//public const int NextStyleHeight = 38; //Calculated by adding all CoordinateHeights + CoordinatePaddingFix.Y applied to all of them + 2

		public override void SetStaticDefaults()
		{
			// Properties
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;

			AdjTiles = new int[] { TileID.Bathtubs };

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2); // this style already takes care of direction for us
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.CoordinatePaddingFix = new Point16(0, -2);
			TileObjectData.addTile(Type);

			// Etc
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Refined Meteorite Bathtubs");
			AddMapEntry(new Color(221, 51, 255), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 64, 32, ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteBathtub>());
		}
	}
}