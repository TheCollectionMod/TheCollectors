using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Currencies
{

    // Base para todas

    public abstract class BaseCurrency : CustomCurrencySingleCoin
    {
        protected BaseCurrency(int coinItemID, long currencyCap, string key) : base(coinItemID, currencyCap)
        {
            CurrencyTextKey = key;
            CurrencyTextColor = Color.BlueViolet;
        }
    }

    // Las monedas

    public class MagicSoul : BaseCurrency
    {
        public MagicSoul(int coinItemID, long currencyCap, string key) : base(coinItemID, currencyCap, key) { }
    }
    public class TerraCoin : BaseCurrency
    {
        public TerraCoin(int coinItemID, long currencyCap, string key) : base(coinItemID, currencyCap, key) { }
    }

    // Sistema de registro

    public sealed class TheCollectorsCurrencies : ModSystem
    {
        public static int TerraCoinId { get; private set; }
        public static int MagicSoulId { get; private set; }

        public override void PostSetupContent()
        {
            TerraCoinId = CustomCurrencyManager.RegisterCurrency( new TerraCoin(ModContent.ItemType<Items.NPCStash.McMoneyPants.TerraCoin>(), 999L, "Mods.TheCollectors.Currencies.TerraCoin")
            );

            MagicSoulId = CustomCurrencyManager.RegisterCurrency( new MagicSoul( ModContent.ItemType<Items.MagicSoul>(),999L, "Mods.TheCollectors.Currencies.MagicSoul")
            );
        }
    }
}