using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace TheCollectors.Content.Projectiles.Magic
{
	public class AmethystBoltTier2 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Reducing Poisonous Amethyst Bolt");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.AmethystBolt);
			AIType = ProjectileID.AmethystBolt;
			Projectile.penetrate += 2;
			Projectile.timeLeft = 150;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

			return base.OnTileCollide(oldVelocity);

		}

		public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
		{
			Player player = Main.player[Projectile.owner];
			Projectile.ai[1] = 1;
			Projectile.netUpdate = true;
			if (Main.rand.NextBool(10))
			{
				target.AddBuff(BuffID.Poisoned, 300, false);
			}
			else if (Main.rand.NextBool(3))
				target.AddBuff(BuffID.Poisoned, 90, false);

			if (Main.rand.NextBool(10))
			{
				target.AddBuff(BuffID.Venom, 300, false);
			}
			else if (Main.rand.NextBool(3))
				target.AddBuff(BuffID.Venom, 90, false);
		}
	}
}

