using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace TheCollectors.Content.Projectiles.Throwing
{
	public class WormShuriken : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Worm Shuriken");
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
			Projectile.penetrate = 5; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			Projectile.tileCollide = true; // Can the projectile collide with tiles?
			Projectile.timeLeft = 100;
			AIType = ProjectileID.Shuriken; // Act exactly like default Bullet
			SoundEngine.PlaySound(SoundID.WormDig, Projectile.position);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.WormDig, Projectile.position);

			return base.OnTileCollide(oldVelocity);

		}
		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			SoundEngine.PlaySound(SoundID.WormDig, Projectile.position);
		}

		public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.WormDig, Projectile.position);
			for (int i = 0; i < 25; i++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Corruption, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f);
			}
			if (Projectile.owner == Main.myPlayer)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 circularVelocity = new Vector2(2, 0).RotatedBy(MathHelper.ToRadians(i * 45));
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, circularVelocity.X, circularVelocity.Y, ModContent.ProjectileType<WormShurikenSub>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
				}
			}
		}
	}
}

