using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace TheCollectors.Content.Projectiles.Throwing
{
	public class TungstenShuriken : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tungsten Shuriken");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Shuriken);
			AIType = ProjectileID.Shuriken;
		}

		/*public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

			return base.OnTileCollide(oldVelocity);

		}*/
		public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 25; i++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Tungsten, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f);
			}
		}
	}
}

