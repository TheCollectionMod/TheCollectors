using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Mounts
{
	public class MeteorHoverboard : ModMount
	{
		public override void SetStaticDefaults() {
			MountData.spawnDust = (ushort)DustType<Dusts.Flame>();
			MountData.buff = ModContent.BuffType<Buffs.MeteorHoverboard>();
			MountData.heightBoost = 20;
			MountData.fallDamage = 0.5f;
			MountData.runSpeed = 5f;
			MountData.dashSpeed = 7f;
			MountData.flightTimeMax = 600;
			MountData.fatigueMax = 0;
			MountData.jumpHeight = 5;
			MountData.acceleration = 0.19f;
			MountData.jumpSpeed = 4f;
			MountData.blockExtraJumps = false;
			MountData.totalFrames = 4;
			MountData.constantJump = true;
			int[] array = new int[MountData.totalFrames];
			for (int l = 0; l < array.Length; l++) {
				array[l] = 20;
			}
			MountData.playerYOffsets = array;
			MountData.xOffset = 0;
			MountData.bodyFrame = 3;
			MountData.yOffset = 12;
			MountData.playerHeadOffset = 22;
			MountData.standingFrameCount = 4;
			MountData.standingFrameDelay = 12;
			MountData.standingFrameStart = 0;
			MountData.runningFrameCount = 4;
			MountData.runningFrameDelay = 12;
			MountData.runningFrameStart = 0;
			MountData.flyingFrameCount = 0;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
			MountData.inAirFrameCount = 1;
			MountData.inAirFrameDelay = 12;
			MountData.inAirFrameStart = 0;
			MountData.idleFrameCount = 4;
			MountData.idleFrameDelay = 12;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = true;
			MountData.swimFrameCount = MountData.inAirFrameCount;
			MountData.swimFrameDelay = MountData.inAirFrameDelay;
			MountData.swimFrameStart = MountData.inAirFrameStart;
			if (Main.netMode == NetmodeID.Server) {
				return;
			}
			MountData.textureWidth = MountData.backTexture.Width();
			MountData.textureHeight = MountData.backTexture.Height();
		}
	}
}