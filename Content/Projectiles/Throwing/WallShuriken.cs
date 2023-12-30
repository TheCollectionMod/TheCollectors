using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace TheCollectors.Content.Projectiles.Throwing
{
	public class WallShuriken : ModProjectile
	{
		private const float AttractionRange = 150f;
		private const float AttractionForce = 0.8f;

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wall Shuriken");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Shuriken);
			Projectile.width = 22; // The width of the projectile
			Projectile.height = 22; // The height of the projectile

			//Projectile.aiStyle = -1; // We are setting the aiStyle to -1 to use the custom AI below. If just want the vanilla behavior, you can set the aiStyle to 159.
			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.DamageType = DamageClass.Throwing; // Set the damage type to ranged damage.
			Projectile.penetrate = 5; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			AIType = ProjectileID.Shuriken; // Act exactly like default Bullet
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.NPCHit8, Projectile.position);

			return base.OnTileCollide(oldVelocity);

		}

		public override void OnKill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.NPCHit8, Projectile.position);
			for (int i = 0; i < 25; i++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Blood, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f);
			}
		}

		/*public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[Projectile.owner];
			Projectile.ai[1] = 1;
			Projectile.netUpdate = true;
			if (Main.rand.NextBool(10))
			{
				target.AddBuff(BuffID.TheTongue, 300, false);
			}
			else if (Main.rand.NextBool(3))
				target.AddBuff(BuffID.TheTongue, 90, false);
		}*/

		public override void AI()
		{
			if (Projectile.ai[1] != 1f)
			{
				// No se activa la atracción hasta que el proyectil golpee a un NPC
				return;
			}

			// Buscamos los NPC cercanos al proyectil en el rango de atracción
			for (int i = 0; i < Main.npc.Length; i++)
			{
				NPC npc = Main.npc[i];
				if (npc.CanBeChasedBy(Projectile) && npc.active && !npc.friendly)
				{
					float distance = Vector2.Distance(npc.Center, Projectile.Center);
					if (distance <= AttractionRange)
					{
						// Aplicamos la fuerza de atracción al NPC seleccionado
						Vector2 direction = Projectile.velocity;
						direction.Normalize();
						npc.velocity += direction * AttractionForce;

						// Creamos un efecto visual para el NPC arrastrado
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Smoke);
						Main.dust[dust].velocity = npc.velocity;
						Main.dust[dust].scale *= 0.5f;
					}
				}
			}
		}/*public override void AI()
		{
			if (Projectile.ai[1] != 1f)
			{
				// No se activa la atracción hasta que el proyectil haya sido lanzado
				return;
			}

			// Buscamos todos los NPC en el rango de atracción
			for (int i = 0; i < Main.npc.Length; i++)
			{
				NPC npc = Main.npc[i];
				if (npc.CanBeChasedBy(Projectile) && npc.active && !npc.friendly)
				{
					float distance = Vector2.Distance(npc.Center, Projectile.Center);
					if (distance < AttractionRange)
					{
						// Aplicamos la fuerza de atracción al NPC seleccionado
						Vector2 direction = Projectile.velocity;
						direction.Normalize();
						npc.velocity += direction * AttractionForce;
					}
				}
			}
		}*/

		/*public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			// Activa la atracción de enemigos cuando el proyectil golpea a un NPC
			Projectile.ai[1] = 1;
			Projectile.netUpdate = true;
			base.OnHitNPC(target, damage, knockback, crit);
		}*/
	}
}

