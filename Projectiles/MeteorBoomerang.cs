using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;


namespace TheCollectors.Projectiles
{
    public class MeteorBoomerang : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Boomerang");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Bumerán de meteorito");
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.LightDisc);
            AIType = ProjectileID.LightDisc;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(2))
            {
                target.AddBuff(30, 180);
                target.AddBuff(24, 180);
            }
        }
    }
}
