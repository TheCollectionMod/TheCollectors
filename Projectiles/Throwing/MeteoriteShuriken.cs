using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace TheCollectors.Projectiles.Throwing
{
	public class MeteoriteShuriken : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteorite Shuriken");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Shuriken);
			AIType = ProjectileID.Shuriken;
			Projectile.light = 2f;
		}
		public override void AI()
		{
			Projectile.alpha++;
			for (int i = 0; i < 1; i += 10)
			{
				Vector2 circularLocation = new Vector2(1, 1).RotatedBy(MathHelper.ToRadians(i));

				int num1 = Dust.NewDust(new Vector2(Projectile.Center.X + circularLocation.X - 4, Projectile.Center.Y + circularLocation.Y - 4), 4, 4, DustID.YellowStarDust);
				Main.dust[num1].noGravity = true;
				Main.dust[num1].velocity *= 1f;
				Main.dust[num1].alpha = Projectile.alpha;
			}
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item4, Projectile.position);
			for (int i = 0; i < 25; i++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.YellowStarDust, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f);
			}
		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[Projectile.owner];
			Projectile.ai[1] = 1;
			Projectile.netUpdate = true;
			if (Main.rand.NextBool(10))
			{
				target.AddBuff(BuffID.OnFire, 300, false);
			}
			else if (Main.rand.NextBool(3))
				target.AddBuff(BuffID.OnFire, 90, false);
		}
	}
}

