using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using Terraria.IO;
using Terraria.WorldBuilding;


namespace TheCollectors.Tiles.RefinedMeteoriteSet
{
	public class HardenedMeteoriteOre : ModTile
	{
		public override void SetStaticDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileOreFinderPriority[Type] = 675; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = false; // Modifies the draw color slightly.
			Main.tileShine[Type] = 875; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = false;
			Main.tileFlame[Type] = true;
			Main.tileLighted[Type] = true;
			Main.tileLavaDeath[Type] = false;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Hardened Meteorite Ore");
			AddMapEntry(new Color(207, 170, 216), name);
			//name.AddTranslation(GameCulture.Spanish, "Meteorito endurecido");

			DustType = DustID.FlameBurst;
			ItemDrop = ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.HardenedMeteoriteOre>();
			HitSound = SoundID.Tink;
			//soundStyle = 1;
			MineResist = 4f;
			MinPick = 190;
		}

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            base.ModifyLight(i, j, ref r, ref g, ref b);
			r = 0.5f;
			g = 0.75f;
			b = 1f;
        }
	}
}