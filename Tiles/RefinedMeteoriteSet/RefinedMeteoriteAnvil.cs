using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using IL.Terraria.ID;
using Terraria.GameContent.ObjectInteractions;
using Terraria.DataStructures;

namespace TheCollectors.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteAnvil : ModTile
	{
		public override void SetStaticDefaults() 
		{
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.CoordinateHeights = new[] { 18 };
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Refined Meteorite Anvil");
			//name.AddTranslation(GameCulture.Spanish, "Yunque de meteorito refinado");
			AddMapEntry(new Color(200, 200, 200), name);
			DustType = ModContent.DustType<Dusts.Sparkle>();
		}
		public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 16, ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteAnvil>());
		}
	}
}