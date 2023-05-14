using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace TheCollectors.Content.Projectiles.Magic
{
	public class EmeraldBoltTier2 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Spiky Furious Emerald Bolt");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.EmeraldBolt);
			AIType = ProjectileID.EmeraldBolt;
			Projectile.width = 26; // The width of the projectile
			Projectile.height = 26; // The height of the projectile
			Projectile.penetrate += 3;
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
			TheCollectorsPlayer modPlayer = player.GetModPlayer<TheCollectorsPlayer>();
			modPlayer.FakeCrystalLeafSet = true;

			if (!player.HasBuff(BuffID.Thorns))
			{
				player.AddBuff(BuffID.Thorns, 18000, false);
			}

			/*if (player.statLife < 0.5f * player.statLifeMax)
			{
				player.AddBuff(BuffID.LeafCrystal, 18000, false);
			} //no funca, no cuenta como si la armadura de clorofita estuviera puesta*/

			if (player.statLife < 0.5f * player.statLifeMax)
			{
				modPlayer.ApplyLeafCrystalEffect();
			}
		}
		/*public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[Projectile.owner];
			Projectile.ai[1] = 1;
			Projectile.netUpdate = true;
			if (!player.HasBuff(BuffID.Thorns))
			{
				player.AddBuff(BuffID.Thorns, 18000, false);
			}
			if (player.statLife < 0.5f * player.statLifeMax)
			{
				player.AddBuff(BuffID.DryadsWard, 3600, false);
				player.AddBuff(BuffID.DryadsWardDebuff, 3600, false);
			} //no funca, no cuenta como si la armadura de clorofita estuviera puesta
		}*/
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.immune[Projectile.owner] = 15;
		}
		/*public override void Kill(int timeLeft)
		{
			Vector2 launchVelocity = new Vector2(-4, 0); // Create a velocity moving the left.
			for (int i = 0; i < 4; i++)
			{
				// Every iteration, rotate the newly spawned projectile by the equivalent 1/4th of a circle (MathHelper.PiOver4)
				// (Remember that all rotation in Terraria is based on Radians, NOT Degrees!)
				launchVelocity = launchVelocity.RotatedBy(MathHelper.PiOver4);

				// Spawn a new projectile with the newly rotated velocity, belonging to the original projectile owner. The new projectile will inherit the spawning source of this projectile.
				/*Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<EmeraldThornBall>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
			}
		}*/
	}
}

