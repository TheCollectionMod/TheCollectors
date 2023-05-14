using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Buffs
{
    public class ShurikenjutsuBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; 
        }

        public override void Update(Player player, ref int buffIndex)
        {
           player.ThrownVelocity += 0.25f;
           player.GetDamage(DamageClass.Throwing) += 0.25f; // Increase by 25%
           player.GetCritChance(DamageClass.Throwing) += 0.25f; // Increase by 25%
        }
    }
}