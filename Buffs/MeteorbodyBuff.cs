using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectors.Buffs
{
    public class MeteorbodyBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
            DisplayName.SetDefault("Meteor Body");
            Description.SetDefault("+20 Increased defense");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 20;
        }
    }
}
