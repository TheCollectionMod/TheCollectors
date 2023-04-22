using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;

namespace TheCollectors.Currencies
{
	public class TerraCoin : CustomCurrencySingleCoin
	{
		public TerraCoin(int coinItemID, long currencyCap, string CurrencyTextKey) : base(coinItemID, currencyCap)
		{
			this.CurrencyTextKey = CurrencyTextKey;
			CurrencyTextColor = Color.BlueViolet;
		}
	}
}