using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace TheCollectors.Content.Projectiles.Magic
{
	public class PearlBolt : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rayo de perlas");
		}

		public override void SetDefaults()
		{
			Projectile.timeLeft = 600;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 3;
			Projectile.light = 0.5f;
			Projectile.extraUpdates = 1;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.scale = 1.2f;
		}

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.velocity.Y += 0.15f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.penetrate <= 0)
            {
                return true;
            }

            Projectile.penetrate--;

            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.MagicMirror, oldVelocity.X * -0.5f, oldVelocity.Y * -0.5f);
            }

            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }

            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }

            return false;
        }
    }
}



