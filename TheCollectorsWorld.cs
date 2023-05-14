using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;
using System;
using System.Diagnostics.PerformanceData;
using System.Linq;
using Terraria.ObjectData;
using Terraria.Graphics.Effects;
using Terraria.UI;

namespace TheCollectors
{
	public class TheCollectorsWorld : ModSystem
	{
		public static bool savedMeteorman = false;
		public static bool meteormanJustRescued = false; // Not important for saving.
		public static bool savedEnchanter = false;
		public static bool enchanterJustRescued = false; // Not important for saving.
		public static bool savedCarver = false;
		public static bool CarverJustRescued = false; // Not important for saving.
		public static bool spawnedCopperGuardian = false;

		public override void OnWorldLoad()
		{
			savedMeteorman = false;
			meteormanJustRescued = false;
			savedEnchanter = false;
			enchanterJustRescued = false;
			savedCarver = false;
			CarverJustRescued = false;
			spawnedCopperGuardian = false;
		}

		public override void OnWorldUnload()
		{
			savedMeteorman = false;
			meteormanJustRescued = false;
			savedEnchanter = false;
			enchanterJustRescued = false;
			savedCarver = false;
			CarverJustRescued = false;
			spawnedCopperGuardian = false;
		}

		public override void SaveWorldData(TagCompound tag)
		{
			if (savedMeteorman)
			{
				tag["savedMeteorman"] = true;
			}
			if (savedEnchanter)
			{
				tag["savedEnchanter"] = true;
			}
			if (savedCarver)
			{
				tag["savedCarver"] = true;
			}
			if (spawnedCopperGuardian)
			{
				tag["spawnedCopperGuardian"] = true;
			}
		}
		public override void LoadWorldData(TagCompound tag)
		{
			savedMeteorman = tag.ContainsKey("savedMeteorman");
			savedMeteorman = tag.ContainsKey("savedEnchanter");
			savedCarver = tag.ContainsKey("savedCarver");
			spawnedCopperGuardian = tag.ContainsKey("spawnedCopperGuardian");
		}

		public override void NetSend(BinaryWriter writer)
		{
			//Remember that Bytes/BitsByte only have 8 entries. If you have more than 8 flags you want to sync, use multiple BitsByte
			var flags = new BitsByte();
			flags[0] = savedMeteorman;
			flags[1] = savedEnchanter;
			flags[2] = savedCarver;
			flags[3] = spawnedCopperGuardian;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			savedMeteorman = flags[0];
			savedEnchanter = flags[1];
			savedCarver = flags[2];
			spawnedCopperGuardian = flags[3];
		}
		public static void UpdateWorldBool() //from Calamity's Vanities
		{
			if (Main.netMode == NetmodeID.Server)
			{
				NetMessage.SendData(MessageID.WorldData);
			}
		}
	}
}