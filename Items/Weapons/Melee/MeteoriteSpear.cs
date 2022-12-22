using TheCollectors.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Weapons.Melee
{
	public class MeteoriteSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteor Spear");
			Tooltip.SetDefault("Has a chance of inflicting 'On Fire!' to enemies"
			+ "\n'Hits like a meteor'");
			//DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Lanza de meteorito");
			//Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Puede infligir ¡En llamas! a los enemigos"
			//+ "\n'Golpea como un meteorito'");
		}
		public override void SetDefaults() {
			Item.damage = 40;
			Item.useStyle = ItemUseStyleID.HoldUp;
			//Item.useStyle = ItemUseStyleID.HoldingOut;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 5f;
			Item.knockBack = 13f;
			Item.width = 40;
			Item.height = 40;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Orange;
			Item.value = 25000;

			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			Item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			Item.autoReuse = false; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<MeteoriteSpearProjectile>();
		}

		public override bool CanUseItem(Player player) {
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}
	}
}
