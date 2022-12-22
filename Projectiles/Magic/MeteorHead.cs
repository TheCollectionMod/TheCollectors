using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace TheCollectors.Projectiles.Magic
{
	public class MeteorHead : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MeteorHead");
			Main.projFrames[Projectile.type] = 3;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.BookOfSkullsSkull);
			Projectile.width = 26; // The width of projectile hitbox
			Projectile.height = 28; // The height of projectile hitbox
			//Projectile.aiStyle = ProjAIStyleID.Arrow;  // projectile.aiStyle = 3; This line is not needed since CloneDefaults sets it already.
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.DamageType = DamageClass.Magic; // Is the projectile shoot by a ranged weapon?
			AIType = ProjectileID.BookOfSkullsSkull;
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.timeLeft = 300;
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
		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Meteorite, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * -0.2f);
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * -0.2f);

			}
		}
	}
}

