using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace TheCollectors.Projectiles.Magic
{
	public class AmberBoltTier2 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Bolt Tier 2");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.AmberBolt);
			AIType = ProjectileID.AmberBolt;
			Projectile.penetrate += 3;
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
			if (!player.HasBuff(BuffID.Honey))
			{
				player.AddBuff(BuffID.Honey, 18000, false);
			}
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
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, circularVelocity.X, circularVelocity.Y, ProjectileID.Bee, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
				}
			}
		}
	}
}

