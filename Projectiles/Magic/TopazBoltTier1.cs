using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace TheCollectors.Projectiles.Magic
{
	public class TopazBoltTier1 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Opulent Topaz Bolt");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.TopazBolt);
			AIType = ProjectileID.TopazBolt;
			Projectile.penetrate += 1;
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
				target.AddBuff(BuffID.Midas, 600, false);
			}
		}
	}
}

