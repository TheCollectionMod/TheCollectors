using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;

namespace TheCollectors.Currencies
{
	public class MagicSoul : CustomCurrencySingleCoin
	{
		public MagicSoul(int coinItemID, long currencyCap, string CurrencyTextKey) : base(coinItemID, currencyCap)
		{
			this.CurrencyTextKey = CurrencyTextKey;
			CurrencyTextColor = Color.BlueViolet;
		}
	}
}