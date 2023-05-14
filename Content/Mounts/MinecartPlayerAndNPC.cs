/*using System;
using Terraria;
using Terraria.ModLoader; 

namespace TheCollectors.Content.Mounts.Minecarts
{
	public class MinecartPlayer : ModPlayer
	{
		public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
		{
			if (Player.mount.Type == ModContent.MountType<RefinedMeteoriteMinecart>() && Math.Abs(Player.velocity.X) > 3.5f) //reduces contact damage when ramming
			{
				damage -= (int)(Math.Abs(Player.velocity.X) - 5);
				if (damage < 1) //idk if this is necessary but hey
					damage = 1;
			}
		}
	}

	public class MinecartNPC : GlobalNPC
	{
		public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo)
		{
			if (target.mount.Type == ModContent.MountType<RefinedMeteoriteMinecart>() && Math.Abs(target.velocity.X) > 3.5f) //does extra damage on hit
				npc.StrikeNPC((int)target.velocity.X, 4f, target.direction, true, false, false);
		}
	}
}*/
