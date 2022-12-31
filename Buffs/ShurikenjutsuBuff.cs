using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Buffs
{
    public class ShurikenjutsuBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; 
            DisplayName.SetDefault("Shuriken Jutsu");
            Description.SetDefault("Increases throwing damage, speed and critical strike chance by 25%");
        }

        public override void Update(Player player, ref int buffIndex)
        {
           player.ThrownVelocity += 0.25f;
           player.GetDamage(DamageClass.Throwing) += 0.25f; // Increase by 25%
           player.GetCritChance(DamageClass.Throwing) += 0.25f; // Increase by 25%
        }
    }
}