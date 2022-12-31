using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectors.Buffs
{
    public class CopptinPolishBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
            DisplayName.SetDefault("Copptin Polish");
            //DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Cuerpo meteoro");
            Description.SetDefault("mejora cosas");
            //Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "+20 de defensa");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 20;
        }
    }
}
