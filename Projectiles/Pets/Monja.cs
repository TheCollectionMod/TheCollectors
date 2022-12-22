using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Projectiles.Pets
{
    public class Monja : ModProjectile
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Monja");
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
            ProjectileID.Sets.LightPet[Projectile.type] = true;
        }

        public override void SetDefaults() {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.penetrate = -1;
            Projectile.netImportant = true;
            Projectile.timeLeft *= 5;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.scale = 0.8f;
            Projectile.tileCollide = false;
        }

        const int fadeInTicks = 30;
        const int fullBrightTicks = 200;
        const int fadeOutTicks = 30;
        const int range = 500;
        int rangeHypoteneus = (int)Math.Sqrt(range * range + range * range);

        public override void AI() {
            Player player = Main.player[Projectile.owner];
            TheCollectorsPlayer modPlayer = player.GetModPlayer<TheCollectorsPlayer>();
            if (!player.active) {
                Projectile.active = false;
                return;
            }
            if (player.dead) {
                modPlayer.MyLightPet = false;
            }
            if (modPlayer.MyLightPet) {
                Projectile.timeLeft = 2;
            }
            Projectile.ai[1]++;
            if (Projectile.ai[1] > 1000 && ((int)Projectile.ai[0] % 100 == 0)) {
                for (int i = 0; i < Main.npc.Length; i++) {
                    if (Main.npc[i].active && !Main.npc[i].friendly && player.Distance(Main.npc[i].Center) < rangeHypoteneus) {
                        Vector2 vectorToEnemy = Main.npc[i].Center - Projectile.Center;
                        Projectile.velocity += 10f * Vector2.Normalize(vectorToEnemy);
                        Projectile.ai[1] = 0f;
                        //Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/Custom/WatchOut"));
                        break;
                    }
                }
            }
            Projectile.rotation += Projectile.velocity.X / 20f;
            Lighting.AddLight(Projectile.Center, ((255 - Projectile.alpha) * 0.9f) / 255f, ((255 - Projectile.alpha) * 0.1f) / 255f, ((255 - Projectile.alpha) * 0.3f) / 255f);
            if (Projectile.velocity.Length() > 1f) {
                Projectile.velocity *= .98f;
            }
            if (Projectile.velocity.Length() == 0) {
                Projectile.velocity = Vector2.UnitX.RotatedBy(Main.rand.NextFloat() * Math.PI * 2);
                Projectile.velocity *= 2f;
            }
            Projectile.ai[0]++;
            if (Projectile.ai[0] < fadeInTicks) {
                Projectile.alpha = (int)(255 - 255 * Projectile.ai[0] / fadeInTicks);
            }
            else if (Projectile.ai[0] < fadeInTicks + fullBrightTicks) {
                Projectile.alpha = 0;
                if (Main.rand.NextBool(6)) {
                    int num145 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PinkFairy, 0f, 0f, 200, default(Color), 0.8f);
                    Main.dust[num145].velocity *= 0.3f;
                }
            }
            else if (Projectile.ai[0] < fadeInTicks + fullBrightTicks + fadeOutTicks) {
                Projectile.alpha = (int)(255 * (Projectile.ai[0] - fadeInTicks - fullBrightTicks) / fadeOutTicks);
            }
            else {
                Projectile.Center = new Vector2(Main.rand.Next((int)player.Center.X - range, (int)player.Center.X + range), Main.rand.Next((int)player.Center.Y - range, (int)player.Center.Y + range));
                Projectile.ai[0] = 0;
                Vector2 vectorToPlayer = player.Center - Projectile.Center;
                Projectile.velocity = 2f * Vector2.Normalize(vectorToPlayer);
            }
            if (Vector2.Distance(player.Center, Projectile.Center) > rangeHypoteneus) {
                Projectile.Center = new Vector2(Main.rand.Next((int)player.Center.X - range, (int)player.Center.X + range), Main.rand.Next((int)player.Center.Y - range, (int)player.Center.Y + range));
                Projectile.ai[0] = 0;
                Vector2 vectorToPlayer = player.Center - Projectile.Center;
                Projectile.velocity += 2f * Vector2.Normalize(vectorToPlayer);
            }
            if ((int)Projectile.ai[0] % 100 == 0) {
                Projectile.velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(90));
            }
        }
    }
}