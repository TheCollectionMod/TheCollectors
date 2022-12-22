using TheCollectors.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;


namespace TheCollectors.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteWall : ModWall
	{
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = true;

			DustType = ModContent.DustType<Sparkle>();
			ItemDrop = ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteWall>();

			AddMapEntry(new Color(238, 153, 255));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}