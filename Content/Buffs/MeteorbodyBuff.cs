using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectors.Content.Buffs
{
    public class MeteorbodyBuff : ModBuff
    {
        public static readonly int DefenseBonus = 20;

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += DefenseBonus; // Grant a +20 defense boost to the player while the buff is active.
        }
    }
}