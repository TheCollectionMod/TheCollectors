using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;

namespace TheCollectors.Tiles
{
	public class ThrowingDummy : ModTile
	{
		public override void SetStaticDefaults()
		{
			// Properties
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileNoSunLight[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;

			DustType = ModContent.DustType<Dusts.Sparkle>();

			// Names
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Throwing Dummy");
			AddMapEntry(new Color(200, 200, 200), name);

			// Placement
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
			TileObjectData.newTile.StyleWrapLimit = 2; //not really necessary but allows me to add more subtypes of chairs below the example chair texture
			TileObjectData.newTile.StyleMultiplier = 2; //same as above
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight; //allows me to place furniture facing the same way as the player
			TileObjectData.addAlternate(1); //facing right will use the second texture style
			TileObjectData.addTile(Type);


			//disableSmartCursor = true;
		}

		public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<Items.Placeable.ThrowingDummy>());
		}

		public override bool RightClick(int i, int j)
		{
			Player player = Main.player[Main.myPlayer];
			int style = Main.tile[i, j].TileFrameX / 15;
			//player.AddBuff(BuffID.Endurance, 36000);
			player.AddBuff(ModContent.BuffType<Buffs.ShurikenjutsuBuff>(), 36000); 
			return true;
		}

		/*public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.player[Main.myPlayer];
				int style = Main.tile[i, j].TileFrameX / 15;
				player.AddBuff(87, 3600, true); //falta testear para k sea un buff sin tiempo
			}
		}*/
	}
}