using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Ammo
{
	public class MeteoriteHardenerSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 99;
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
