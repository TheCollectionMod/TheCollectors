using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace TheCollectors.Content.Projectiles.Magic
{
	public class DiamondBoltTier2 : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Draining Homing Diamond Bolt");
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
		}
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.DiamondBolt);
			AIType = ProjectileID.DiamondBolt;
			Projectile.penetrate += 3;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 150;
			Projectile.DamageType = DamageClass.Magic;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			return base.OnTileCollide(oldVelocity);
		}

		public override void AI()
		{
			float maxDetectRadius = 400f; // The maximum radius at which a projectile can detect a target
			float projSpeed = 10f; // The speed at which the projectile moves towards the target

			// Trying to find NPC closest to the projectile
			NPC closestNPC = FindClosestNPC(maxDetectRadius);
			if (closestNPC == null)
				return;

			// If found, change the velocity of the projectile and turn it in the direction of the target
			// Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
			Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
			Projectile.rotation = Projectile.velocity.ToRotation();
		}

		// Finding the closest NPC to attack within maxDetectDistance range
		// If not found then returns null
		public NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;

			// Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			// Loop through all NPCs(max always 200)
			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				// Check if NPC able to be targeted. It means that NPC is
				// 1. active (alive)
				// 2. chaseable (e.g. not a cultist archer)
				// 3. max life bigger than 5 (e.g. not a critter)
				// 4. can take damage (e.g. moonlord core after all it's parts are downed)
				// 5. hostile (!friendly)
				// 6. not immortal (e.g. not a target dummy)
				if (target.CanBeChasedBy())
				{
					// The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					// Check if it is within the radius
					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Player p = Main.player[Projectile.owner];
			int healingAmount = (int)(Projectile.damage) / 10; //decrease the value 30 to increase heal, increase value to decrease. Or you can just replace damage/x with a set value to heal, instead of making it based on damage.
			p.statLife += healingAmount;
			p.HealEffect(healingAmount, true);
			target.immune[Projectile.owner] = 15;
		}
		public override void OnKill(int timeLeft)
		{
			Player player = Main.player[Projectile.owner];
			Terraria.Audio.SoundEngine.PlaySound(SoundID.Item94, Projectile.Center);
			if (Projectile.owner == Main.myPlayer)
			{
				for (int i = 0; i < 8; i++)
				{
					Vector2 circularVelocity = new Vector2(2, 0).RotatedBy(MathHelper.ToRadians(i * 45));
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, circularVelocity.X, circularVelocity.Y, ModContent.ProjectileType<DiamondBoltTier1>(), Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
				}
			}
		}
	}
}

