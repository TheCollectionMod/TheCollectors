/*using System;
using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Mounts.Minecarts
{
	public class RefinedMeteoriteMinecartBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Refined Meteorite Minecart"); //name tbd?
			// Description.SetDefault("Template");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<RefinedMeteoriteMinecart>(), player);
			player.buffTime[buffIndex] = 10;

			//if (Math.Abs(player.velocity.X) > 3)
			//	player.armorEffectDrawShadow = true;
		}
	}
}*/
