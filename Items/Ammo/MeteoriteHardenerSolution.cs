using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TheCollectors.Items.Ammo
{
	public class MeteoriteHardenerSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteorite Hardener");
			Tooltip.SetDefault("Used by the Clentaminator, spread true meteorite ore on meteorite ore.");
			// Be sure to have "using Terraria.Localization".
			//DisplayName.AddTranslation(GameCulture.Spanish, "Endurecedor de meteorito");
			//Tooltip.AddTranslation(GameCulture.Spanish, "Úsalo con el clentaminator, transforma el meteorito en meteorito endurecido");
		}

		public override void SetDefaults()
		{
			Item.width = 10;
			Item.height = 12;
			Item.value = Item.buyPrice(0, 0, 30, 0);
			Item.value = Item.sellPrice(0, 0, 10, 0);
			Item.rare = ItemRarityID.Orange;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.ammo = AmmoID.Solution;
			Item.shoot = ModContent.ProjectileType<Projectiles.MeteoriteHardenerSolution>() - ProjectileID.PureSpray;
		}
	}
}
