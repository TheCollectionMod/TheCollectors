using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Terraria.ID;

namespace TheCollectors.Tiles.MeteormanStash
{
	public class HellstonePot : ModTile
	{
		public override void SetStaticDefaults()
		{
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Hellstone Pot");
			//name.AddTranslation(GameCulture.Spanish, "Alcorque de piedra infernal");
			AddMapEntry(new Color(200, 200, 200), name);

			DustType = DustType<Dusts.Sparkle>();
			Main.tileSolid[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileNoAttach[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.CoordinateHeights = new[] { 16 };
			TileObjectData.addTile(Type);
			TileObjectData.newTile.StyleWrapLimit = 360;

		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Placeable.MeteormanStash.HellstonePot>());
		}
	}
}