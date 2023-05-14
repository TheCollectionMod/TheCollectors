using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace TheCollectors.Content.Pets.LivingSpaceRock
{
	public class LivingSpaceRockProjectile : ModProjectile
	{
		private const int DashCooldown = 1000; // How frequently this pet will dash at enemies.
		private const float DashSpeed = 20f; // The speed with which this pet will dash at enemies.
		private const int FadeInTicks = 30;
		private const int FullBrightTicks = 200;
		private const int FadeOutTicks = 30;
		private const float Range = 500f;

		private static readonly float RangeHypoteneus = (float)(Math.Sqrt(2.0) * Range); // This comes from the formula for calculating the diagonal of a square (a * √2)
		private static readonly float RangeHypoteneusSquared = RangeHypoteneus * RangeHypoteneus;

		// The following 2 lines of code are ref properties (learn about them in google) to the projectile.ai array entries, which will help us make our code way more readable.
		// We're using the ai array because it's automatically synchronized by the base game in multiplayer, which saves us from writing a lot of boilerplate code.
		// Note that the projectile.ai array is only 2 entries big. If you need more than 2 synchronized variables - you'll have to use fields and sync them manually.
		public ref float AIFadeProgress => ref Projectile.ai[0];

		public ref float AIDashCharge => ref Projectile.ai[1];

		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Living Space Rock");
			Main.projFrames[Projectile.type] = 1;
			Main.projPet[Projectile.type] = true;
			ProjectileID.Sets.LightPet[Projectile.type] = true;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 10;
		}

		public override void SetDefaults() {
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);
			AIType = ProjectileID.ZephyrFish;
			Projectile.light = 1.5f;
			Projectile.width = 26;
			Projectile.height = 28;
			Projectile.netImportant = true;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.scale = 0.8f;
			Projectile.tileCollide = false;
		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];

			// If the player is no longer active (online) - deactivate (remove) the projectile.
			if (!player.active)
			{
				Projectile.active = false;
				return;
			}

			// Keep the projectile disappearing as long as the player isn't dead and has the pet buff.
			if (!player.dead && player.HasBuff(ModContent.BuffType<Pets.LivingSpaceRock.LivingSpaceRockBuff>()))
			{
				Projectile.timeLeft = 2;
			}

			//UpdateDash(player);
			//UpdateFading(player);
			//UpdateExtraMovement();

			// Rotates the pet when it moves horizontally.
			Projectile.rotation += Projectile.velocity.X / 20f;

			// Lights up area around it.
			if (!Main.dedServ)
			{
				Lighting.AddLight(Projectile.Center, Projectile.Opacity * 0.9f, Projectile.Opacity * 0.1f, Projectile.Opacity * 0.3f);
			}
		}

		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
				dust.noGravity = true;
				dust.scale = 1.6f;
			}
		}
	}
}
