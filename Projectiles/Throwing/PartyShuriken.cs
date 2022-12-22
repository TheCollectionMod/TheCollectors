using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace TheCollectors.Projectiles.Throwing
{
	public class PartyShuriken : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Party Shuriken");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Shuriken);
			Projectile.width = 22; // The width of the projectile
			Projectile.height = 22; // The height of the projectile

			//Projectile.aiStyle = -1; // We are setting the aiStyle to -1 to use the custom AI below. If just want the vanilla behavior, you can set the aiStyle to 159.
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.DamageType = DamageClass.Throwing; // Set the damage type to ranged damage.
			Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			AIType = ProjectileID.Shuriken; // Act exactly like default Bullet
		}

		// Now, using CloneDefaults() and aiType doesn't copy EVERY aspect of the projectile. In Vanilla, several other methods
		// are used to generate different effects that aren't included in AI. For the case of the Meowmete projectile, since the
		// richochet sound is not included in the AI, we must add it ourselves:

		public override void AI()
		{
			Projectile.alpha++;
			for (int i = 0; i < 1; i += 10)
			{
				Vector2 circularLocation = new Vector2(1, 1).RotatedBy(MathHelper.ToRadians(i));

				int num1 = Dust.NewDust(new Vector2(Projectile.Center.X + circularLocation.X - 4, Projectile.Center.Y + circularLocation.Y - 4), 4, 4, DustID.Confetti);
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
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item54, Projectile.position);
			for (int i = 0; i < 25; i++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Confetti, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f);
			}

			/*Player player = Main.player[Projectile.owner];
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item54, Projectile.Center);*/
			if (Projectile.owner == Main.myPlayer)
			{
				for (int i = 0; i < 8; i++)
				{
					Vector2 circularVelocity = new Vector2(2, 0).RotatedBy(MathHelper.ToRadians(i * 45));
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, circularVelocity.X, circularVelocity.Y, ProjectileID.ConfettiGun, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
				}
			}
		}
	}
}

