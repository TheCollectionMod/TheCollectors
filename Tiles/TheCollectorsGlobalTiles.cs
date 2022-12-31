using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using Terraria.IO;
using Terraria.WorldBuilding;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.DataStructures;

namespace TheCollectors.Tiles
{
	public class TheCollectorsGlobalTiles : GlobalTile
	{
		public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if (!Main.dedServ)
			{
				Player player = Main.LocalPlayer;
				TheCollectorsPlayer modPlayer = player.GetModPlayer<TheCollectorsPlayer>();

				if (type == TileID.Stone || type == TileID.Ebonstone || type == TileID.Pearlstone || type == TileID.Crimstone)
				{
					if (Main.rand.NextBool(10) && modPlayer.geodePickaxe && !fail)
					{
						int geodeItem = Main.rand.Next(new int[] { ItemID.Geode });
						//int gemItem = Main.rand.Next(new int[] { ItemID.Ruby, ItemID.Amber, ItemID.Ruby, ItemID.Emerald, ItemID.Sapphire, ItemID.Topaz, ItemID.Amethyst });
						SoundEngine.PlaySound(SoundID.Item4); new Vector2(i * 16, j * 16);
						Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 64, 48, geodeItem, Main.rand.Next(1,3));
					}
				}

				if (type == TileID.Sand && player.ZoneBeach)
				{
					if (Main.rand.NextBool(10) && modPlayer.oysterRake && !fail)
					{
						int oysterItem = Main.rand.Next(new int[] { ItemID.Oyster });
						//int gemItem = Main.rand.Next(new int[] { ItemID.Ruby, ItemID.Amber, ItemID.Ruby, ItemID.Emerald, ItemID.Sapphire, ItemID.Topaz, ItemID.Amethyst });
						SoundEngine.PlaySound(SoundID.Item4); new Vector2(i * 16, j * 16);
						Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 64, 48, oysterItem, Main.rand.Next(1, 3));
					}
				}
			}
		}
	}
}
