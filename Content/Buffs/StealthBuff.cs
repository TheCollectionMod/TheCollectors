using Terraria;
using Terraria.ModLoader;

namespace TheCollectors.Content.Buffs
{
    public class StealthBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.aggro -= 750;
        }
    }
}
