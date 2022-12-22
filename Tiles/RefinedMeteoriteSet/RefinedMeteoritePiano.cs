using TheCollectors.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Audio;
using Terraria.DataStructures;


namespace TheCollectors.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoritePiano : ModTile
	{
		public override void SetStaticDefaults()
		{
			// Properties
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;

			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Piano");
			AddMapEntry(new Color(200, 200, 200));

			//ItemDrop = ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoritePiano>();

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
			TileObjectData.addTile(Type);
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
		{
			offsetY = 2;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoritePiano>());
		}

		public override bool RightClick(int i, int j)
		{
			int rand = Main.rand.Next(2);
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item94);
			SoundEngine.PlaySound(SoundID.Item78);
			//SoundEngine.PlaySound(new SoundStyle(rand == 0 ? "Sounds/Arpiano" : "Sounds/SoftMelodyPiano") with { PitchVariance = 0.05f }, new Vector2(i, j) * 16);
			return true;
		}

		public override void MouseOver(int i, int j)
		{
			Main.LocalPlayer.cursorItemIconText = "Play";
			Main.LocalPlayer.cursorItemIconID = -1;
			Main.LocalPlayer.noThrow = 2;
			Main.LocalPlayer.cursorItemIconEnabled = true;
			Main.LocalPlayer.cursorItemIconID = ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoritePiano>();
		}
	}
}