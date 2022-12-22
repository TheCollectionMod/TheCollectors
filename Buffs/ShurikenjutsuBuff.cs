using IL.Terraria.GameContent.Events;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectors.Buffs
{
    public class ShurikenjutsuBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
            DisplayName.SetDefault("Shuriken Jutsu");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Arte Ninja - Shuriken");
            Description.SetDefault("Increases throwing damage, speed and critical strike chance by 25%");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Aumento de daño, probabilidad de crítico y velocidad de lanzamiento a las armas arrojadizas en 25%");
        }

        public override void Update(Player player, ref int buffIndex)
        {
           player.ThrownVelocity += 0.25f;
           player.GetDamage(DamageClass.Throwing) += 0.25f; // Increase by 25%
           player.GetCritChance(DamageClass.Throwing) += 0.25f; // Increase by 25%
        }
    }
}