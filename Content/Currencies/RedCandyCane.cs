using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;

namespace TheCollectors.Content.Currencies
{
	public class RedCandyCane : CustomCurrencySingleCoin
	{
		public RedCandyCane(int coinItemID, long currencyCap, string CurrencyTextKey) : base(coinItemID, currencyCap)
		{
			this.CurrencyTextKey = CurrencyTextKey;
			CurrencyTextColor = Color.BlueViolet;
		}
	}
}