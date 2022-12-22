using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace TheCollectors.Projectiles.Magic
{
	public class RubyBoltTier2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosive Burning Ruby Bolt");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.RubyBolt);
			AIType = ProjectileID.RubyBolt;
			Projectile.penetrate += 3;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 150;
			Projectile.DamageType = DamageClass.Magic;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

			return true;

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
		public override void AI()
		{
			// The only reason this code works is because the author read the vanilla code and comprehended it well enough to tack on additional logic.
			/*if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 2f && Projectile.ai[1] == 0f)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ProjectileID.DD2BetsyFlameBreath, Projectile.damage, Projectile.knockBack, Main.myPlayer);
				Projectile.ai[1]++;
			}*/
			Projectile.alpha++;
			for (int i = 0; i < 360; i += 15)
			{
				Vector2 circularLocation = new Vector2(-28, 0).RotatedBy(MathHelper.ToRadians(i));

				int num1 = Dust.NewDust(new Vector2(Projectile.Center.X + circularLocation.X - 4, Projectile.Center.Y + circularLocation.Y - 4), 4, 4, DustID.PinkFairy);
				Main.dust[num1].noGravity = true;
				Main.dust[num1].velocity *= 0.1f;
				Main.dust[num1].alpha = Projectile.alpha;
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 15;
		}
		public override void Kill(int timeLeft)
		{
			Player player = Main.player[Projectile.owner];
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item94, Projectile.Center);
			if (Projectile.owner == Main.myPlayer)
			{
				for (int i = 0; i < 8; i++)
				{
					Vector2 circularVelocity = new Vector2(2, 0).RotatedBy(MathHelper.ToRadians(i * 45));
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, circularVelocity.X, circularVelocity.Y, ModContent.ProjectileType<RubyBoltTier1>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
				}
			}
		}
	}
}

