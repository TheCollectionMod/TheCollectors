using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace TheCollectors.Projectiles.Magic
{
	public class TopazBoltTier2 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Greedy Opulent Topaz Bolt");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.TopazBolt);
			AIType = ProjectileID.TopazBolt;
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
			if (Main.rand.NextBool(10))
			{
				target.AddBuff(BuffID.Midas, 600, false);
			}
			if (!player.HasBuff(BuffID.Panic) && player.statLife < 0.3f * player.statLifeMax)
			{
				player.AddBuff(BuffID.Panic, 900, false);
			}
			if (!player.HasBuff(BuffID.Battle))
			{
				player.AddBuff(BuffID.Battle, 18000, false);
			}
			if (!player.HasBuff(BuffID.WaterCandle))
			{
				player.AddBuff(BuffID.WaterCandle, 18000, false);
			}
		}
	}
}

