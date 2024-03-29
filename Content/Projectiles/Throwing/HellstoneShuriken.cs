using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace TheCollectors.Content.Projectiles.Throwing
{
	public class HellstoneShuriken : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hellstone Shuriken");
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

				int num1 = Dust.NewDust(new Vector2(Projectile.Center.X + circularLocation.X - 4, Projectile.Center.Y + circularLocation.Y - 4), 4, 4, DustID.Lava);
				Main.dust[num1].noGravity = true;
				Main.dust[num1].velocity *= 1f;
				Main.dust[num1].alpha = Projectile.alpha;
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

			return base.OnTileCollide(oldVelocity);

		}
		public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 25; i++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Meteorite, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f);
			}
		}
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			Player player = Main.player[Projectile.owner];
			Projectile.ai[1] = 1;
			Projectile.netUpdate = true;
			if (Main.rand.NextBool(10))
			{
				target.AddBuff(BuffID.OnFire3, 300, false);
			}
			else if (Main.rand.NextBool(3))
				target.AddBuff(BuffID.OnFire3, 90, false);
		}
	}
}

