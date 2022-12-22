using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;


namespace TheCollectors.Projectiles.Pets
{
	public class FlyingEyeling : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 12;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.BabyFaceMonster); // Copy the stats of the BabyFaceMonster

			AIType = ProjectileID.BabyFaceMonster; // Copy the AI of the BabyFaceMonster
			Projectile.width = 52;
			Projectile.height = 22;
		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];

			player.babyFaceMonster = false; // Relic from aiType

			return true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];

			// Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
			if (!player.dead && player.HasBuff(ModContent.BuffType<Buffs.FlyingEyeling>()))
			{
				Projectile.timeLeft = 2;
			}
		}
	}
}