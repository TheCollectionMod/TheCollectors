using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Buffs
{
    public class StealthBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
            DisplayName.SetDefault("Ninja Art - Stealth");
            Description.SetDefault("Greatly reduced the aggro from enemies");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.aggro -= 750;
        }
    }
}
