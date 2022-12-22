using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;


namespace TheCollectors.Projectiles.Magic
{
	public class EmeraldThornBall : ModProjectile
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Emerald Thorn Ball");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ThornBall);
			AIType = ProjectileID.ThornBall;
			Projectile.friendly = true;
			Projectile.hostile = false; // Can the projectile deal damage to the player?
										//Projectile.penetrate += 4;
										//Projectile.timeLeft = 150;
			//Projectile.width = 26; // The width of the projectile
			//Projectile.height = 26; // The height of the projectile
			Projectile.DamageType = DamageClass.Magic; // Set the damage type to ranged damage.
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

			return base.OnTileCollide(oldVelocity);

		}

		/*public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) //inventarse debufo espinas, o mesmo de sempre con otro nombre
		{
			Player player = Main.player[Projectile.owner];
			Projectile.ai[1] = 1;
			Projectile.netUpdate = true;
			if (!player.HasBuff(BuffID.Thorns))
			{
				player.AddBuff(BuffID.Thorns, 18000, false);
			}
		}*/
	}
}

