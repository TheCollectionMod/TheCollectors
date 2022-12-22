using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace TheCollectors.Projectiles.Magic
{
	public class AmberBoltTier1 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Bolt Tier 1");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.AmberBolt);
			AIType = ProjectileID.AmberBolt;
			Projectile.penetrate += 2;
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
	}
}

