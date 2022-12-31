using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Buffs
{
	public class MeteorHoverboard : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Meteor Hoverboard");
			Description.SetDefault("Great for exploring floating islands.");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		public override void Update(Player player, ref int buffIndex) {
			player.mount.SetMount(ModContent.MountType<Mounts.MeteorHoverboard>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
