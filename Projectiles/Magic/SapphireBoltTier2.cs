using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace TheCollectors.Projectiles.Magic
{
	public class SapphireBoltTier2 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Protective Freezing Sapphire Bolt");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.SapphireBolt);
			AIType = ProjectileID.SapphireBolt;
			Projectile.penetrate += 2;
			Projectile.timeLeft = 150;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

			return base.OnTileCollide(oldVelocity);

		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[Projectile.owner];
			Projectile.ai[1] = 1;
			Projectile.netUpdate = true;
			if (Main.rand.NextBool(10))
			{
				target.AddBuff(BuffID.Frostburn, 300, false);
			}
			else if (Main.rand.NextBool(3))
				target.AddBuff(BuffID.Frostburn, 90, false);
			if (player.statLife < 0.5f * player.statLifeMax)
			{
				player.AddBuff(BuffID.IceBarrier, 3600, false);
			}
		}
	}
}

