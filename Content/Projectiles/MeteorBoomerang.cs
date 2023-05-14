using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheCollectors.Content.Projectiles
{
    public class MeteorBoomerang : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.LightDisc);
            AIType = ProjectileID.LightDisc;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(2))
            {
                target.AddBuff(30, 180);
                target.AddBuff(24, 180);
            }
        }
    }
}
