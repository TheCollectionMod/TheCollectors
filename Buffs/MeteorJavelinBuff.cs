﻿using TheCollectors.NPCs;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Buffs
{
	public class MeteorJavelinBuff : ModBuff
	{
		/*public override bool Autoload(ref string name, ref string texture) {
			// NPC only buff so we'll just assign it a useless buff icon.
			texture = "TheCollectionMod/Buffs/BuffTemplate";
			return base.Autoload(ref name, ref texture);
		}*/

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Meteorite Javelin");
			Description.SetDefault("Losing life");
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<TheCollectorsGlobalNPC>().MeteorJavelin = true;
		}
	}
}
