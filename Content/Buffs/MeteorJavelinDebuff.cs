using TheCollectors.Common.GlobalNPCs;
using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Buffs
{
	public class MeteorJavelinDebuff : ModBuff
	{
		public override void Update(NPC npc, ref int buffIndex) 
		{
			npc.GetGlobalNPC<TheCollectorsDamageOverTimeNPC>().MeteorJavelinDebuff = true;
		}
	}
}
