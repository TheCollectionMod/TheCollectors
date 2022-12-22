using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TheCollectors.Items.Ammo
{
	public class MeteoriteSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteoric Solution");
			Tooltip.SetDefault("Used by the Clentaminator, spread meteor ore on stone.");
			// Be sure to have "using Terraria.Localization".
			//DisplayName.AddTranslation(GameCulture.Spanish, "Solución de meteorito");
			//Tooltip.AddTranslation(GameCulture.Spanish, "Úsalo con el clentaminator, transforma la piedra en meteorito");
		}

		public override void SetDefaults()
		{
			Item.width = 10;
			Item.height = 12;
			Item.value = Item.buyPrice(0, 0, 15, 0);
			Item.value = Item.sellPrice(0, 0, 5, 0);
			Item.rare = ItemRarityID.Orange;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.ammo = AmmoID.Solution;
			Item.shoot = ModContent.ProjectileType<Projectiles.MeteoriteSolution>() - ProjectileID.PureSpray;
		}
	}
}
