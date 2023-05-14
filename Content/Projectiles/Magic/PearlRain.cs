/*using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace TheCollectors.Content.Projectiles.Magic
{
    public class PearlRain : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pearl Rain");
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.alpha = 255;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 600;
        }

        public override void AI()
        {
            // Crear partículas de polvo
            int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 61, 0f, 0f, 100, default(Color), 1.5f);
            Main.dust[dust].velocity *= 0.1f;
            Main.dust[dust].scale *= 1.3f;
            Main.dust[dust].noGravity = true;

            // Crear proyectil de perla
            float pearlSpawnChance = 0.6f; // Probabilidad de que aparezca una perla (0 a 1)
            if (Main.rand.NextFloat() < pearlSpawnChance) // Si se cumple la probabilidad, crear la perla
            {
                int pearl = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(-1f, 1f), ModContent.ProjectileType<PearlRain_Pearl>(), Projectile.damage, 0f, Projectile.owner);
                Main.projectile[pearl].ai[1] = Projectile.position.Y; // Guardar la posición Y del proyectil padre para la perla
            }

            // Reproducir sonido de impacto de lluvia
            if (Main.rand.Next(4) == 0) // Sonido se reproduce con una probabilidad de 1/4 cada tick
            {
                Main.PlaySound(SoundID.Item84, Projectile.position);
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 61, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[dust].velocity *= 3f;
                Main.dust[dust].scale *= 1.3f;
            }
        }
    }
}*/