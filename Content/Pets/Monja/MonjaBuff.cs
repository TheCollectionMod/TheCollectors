﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Pets.Monja
{
    public class MonjaBuff : ModBuff
    {
        public override void SetStaticDefaults() {
            // DisplayName.SetDefault("Monja");
            // Description.SetDefault("Light Monja!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
            player.GetModPlayer<TheCollectorsPlayer>().MyLightPet = true;
            player.buffTime[buffIndex] = 18000;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ProjectileType<Pets.Monja.MonjaProjectile>()] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
                var entitySource = player.GetSource_Buff(buffIndex);
                Projectile.NewProjectile(entitySource, player.position.X + (player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Pets.Monja.MonjaProjectile>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
            if ((player.controlDown && player.releaseDown)) {
                if (player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15) {
                    for (int j = 0; j < 1000; j++) {
                        if (Main.projectile[j].active && Main.projectile[j].type == ModContent.ProjectileType< Pets.Monja.MonjaProjectile >() && Main.projectile[j].owner == player.whoAmI) {
                            Projectile lightpet = Main.projectile[j];
                            Vector2 vectorToMouse = Main.MouseWorld - lightpet.Center;
                            lightpet.velocity += 5f * Vector2.Normalize(vectorToMouse);
                        }
                    }
                }
            }
        }
    }
}
