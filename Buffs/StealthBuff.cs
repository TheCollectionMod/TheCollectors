using Terraria;
using Terraria.Localization;
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
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Arte Ninja - Sigilo");
            Description.SetDefault("Greatly reduced the aggro from enemies");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Reduce mucho el aggro de los enemigos");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.aggro -= 750;
        }
    }
}
