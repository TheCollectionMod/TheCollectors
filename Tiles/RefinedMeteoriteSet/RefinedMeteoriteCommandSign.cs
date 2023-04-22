using System.Reflection;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using TheCollectors.Dusts;
using Terraria.GameContent.ObjectInteractions;

namespace TheCollectors.Tiles.RefinedMeteoriteSet
{
    public class RefinedMeteoriteCommandSign : ModTile
	{
		public override void SetStaticDefaults()
		{
			// Credits to Dark;Light for finding this flag
			// Keep in mind that the max amount of signs is 1000 (the size of the tileSign array)
			// The Main.tileSign flag will do the following:
			//  *Automatically manages the sign for the specified tile
			//   -Adds a right-click to the tile to bring up an edit sign window
			//   -Allows editing of the sign text
			//   -Saves and loads sign data to world file
			Main.tileSign[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;

			// Use a 2x2 style as our foundation
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);

			// Allow hanging from ceilings
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.StyleHorizontal = true;
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
			TileObjectData.newAlternate.Origin = new Point16(0, 0);
			TileObjectData.newAlternate.AnchorLeft = AnchorData.Empty;
			TileObjectData.newAlternate.AnchorRight = AnchorData.Empty;
			TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidBottom, TileObjectData.newTile.Width, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(1);

			// Allow attaching to a solid object that is to the left of the sign
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.StyleHorizontal = true;
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
			TileObjectData.newAlternate.Origin = new Point16(0, 0);
			TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree, TileObjectData.newTile.Width, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(2);

			// Allow attaching to a solid object that is to the right of the sign
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.StyleHorizontal = true;
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
			TileObjectData.newAlternate.Origin = new Point16(0, 0);
			TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree, TileObjectData.newTile.Width, 0);
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(3);

			// Allow attaching to a wall behind the sign
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.StyleHorizontal = true;
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
			TileObjectData.newAlternate.Origin = new Point16(0, 0);
			TileObjectData.newAlternate.AnchorWall = true;
			TileObjectData.newAlternate.AnchorBottom = AnchorData.Empty;
			TileObjectData.addAlternate(4);

			// Allow attaching sign to the ground
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.StyleHorizontal = true;
			TileObjectData.newAlternate.AnchorAlternateTiles = new int[] { 124 };
			TileObjectData.newAlternate.Origin = new Point16(0, 0);
			TileObjectData.addAlternate(5);
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Refined Meteorite Command Sign");
			AddMapEntry(new Color(200, 200, 200), name);

			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);

			DustType = ModContent.DustType<Sparkle>();
			AdjTiles = new int[] { Type };
		}

		public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override void PlaceInWorld(int i, int j, Item item)
		{
			Main.sign[Sign.ReadSign(i, j, true)].text = "Type in a command, right-click sign to activate it!";
		}

		public override bool RightClick(int i, int j)
		{
			// Uses the text from the sign to run a command
			Main.ExecuteCommand(Main.sign[Sign.ReadSign(i, j, true)].text, new RefinedMeteoriteCommandCaller());
			return true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Terraria.Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteCommandSign>());
			Sign.KillSign(i, j);
		}

		// When a command is finished executing, it will return the output of the command
		// via the Reply method. Console commands do not return output, only ModCommands
		public class RefinedMeteoriteCommandCaller : CommandCaller
		{
			public CommandType CommandType => CommandType.Console;

			public Player Player => null;

			public void Reply(string text, Color color = default(Color))
			{
				foreach (string value in text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries))
					Main.NewText(value);
			}
		}
	}
}