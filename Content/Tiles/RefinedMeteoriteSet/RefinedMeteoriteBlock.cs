using TheCollectors.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheCollectors.Content.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			//Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 20000; // How often tiny dust appear off this tile. Larger is less frequently
			//Main.tileFlame[Type] = true;
			Main.tileLighted[Type] = true;

			DustType = ModContent.DustType<Sparkle>();

			// Etc
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(290, 51, 255), name);
		}

		/*public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}*/
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			base.ModifyLight(i, j, ref r, ref g, ref b);
			r = 0.5f;
			g = 0.75f;
			b = 1f;
		}

		/*public override void NearbyEffects(int i, int j, bool closer)
		{
		    Main.LocalPlayer.AddBuff(BuffID.OnFire, 60); // Cambia el valor de la duración según la duración de la quemadura que desees en tu mod
		}*/
	}
}