using Terraria.ModLoader;
using Terraria.GameContent.UI;

namespace TheCollectors
{
	public class TheCollectors : Mod
	{		
		public const string AssetPath = $"{nameof(TheCollectors)}/Assets/";

		public static int TerraCoinId;
		public static int MagicSoulId;

		public override void Load()
		{

			{
				// Registers a new custom currency
				TerraCoinId = CustomCurrencyManager.RegisterCurrency(new Content.Currencies.TerraCoin(ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.TerraCoin>(), 999L, "Terra Coin"));
				MagicSoulId = CustomCurrencyManager.RegisterCurrency(new Content.Currencies.MagicSoul(ModContent.ItemType<Content.Items.MagicSoul>(), 999L, "Magic Soul"));

			}
		}
		public override void Unload()
		{
			// The Unload() methods can be used for unloading/disposing/clearing special objects, unsubscribing from events, or for undoing some of your mod's actions.
			// Be sure to always write unloading code when there is a chance of some of your mod's objects being kept present inside the vanilla assembly.
			// The most common reason for that to happen comes from using events, NOT counting On.* and IL.* code-injection namespaces.
			// If you subscribe to an event - be sure to eventually unsubscribe from it.

			// NOTE: When writing unload code - be sure use 'defensive programming'. Or, in other words, you should always assume that everything in the mod you're unloading might've not even been initialized yet.
			// NOTE: There is rarely a need to null-out values of static fields, since TML aims to completely dispose mod assemblies in-between mod reloads.
		}
	}
}