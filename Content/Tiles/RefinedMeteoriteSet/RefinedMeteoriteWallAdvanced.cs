using TheCollectors.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Common;
using Terraria.Utilities;

namespace TheCollectors.Content.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteWallAdvanced : ModWall
	{
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = true;

			DustType = DustID.Stone;
			//ItemDrop = ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteWallAdvanced>();

			AddMapEntry(new Color(68, 68, 68));
		}

		public override bool CreateDust(int i, int j, ref int type)
		{
			type = DustType;
			if (Main.tile[i, j].WallFrameNumber == 0)
				type = DustID.GemEmerald;
			return true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 3 : 10;
		}

		public override void AnimateWall(ref byte frame, ref byte frameCounter)
		{
			// Loop through 8 frames of animation, changing every 5 game frames
			if (++frameCounter >= 5)
			{
				frameCounter = 0;
				frame = (byte)(++frame % 8);
			}
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			base.ModifyLight(i, j, ref r, ref g, ref b);
			r = 0.5f;
			g = 0.75f;
			b = 1f;
		}


		/*public override bool WallFrame(int i, int j, bool randomizeFrame, ref int style, ref int frameNumber)
		{
			if (randomizeFrame)
			{
				// Here we make the chance of WallFrameNumber 0 very rare, just for visual variety: https://i.imgur.com/9Irak3p.png
				if (frameNumber == 0 && WorldGen.genRand.NextBool(3, 4))
				{
					frameNumber = WorldGen.genRand.Next(1, 3);
				}
			}
			return base.WallFrame(i, j, randomizeFrame, ref style, ref frameNumber);
		}*/
	}
}