using TheCollectors.Content.Projectiles.Throwing;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Items.Weapons.Throwing
{
	public class MeteorJavelin : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Meteor Javelin");
			/* Tooltip.SetDefault("Has a chance of inflicting 'On Fire!' and 'Bleeding' to enemies"
			+ "\n'Hits like a meteor'"); */
			/*DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Jabalina de meteorito");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Puede infligir ¡En llamas! y 'Hemorragia' a los enemigos"
			+ "\n'Golpea como un meteorito'");*/
		}
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			Item.shootSpeed = 15f;
			Item.damage = 40;
			Item.knockBack = 20f;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 999;
			Item.value = 50;
			Item.rare = ItemRarityID.Pink;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Throwing;

			Item.UseSound = SoundID.Item1;

			// Look at the javelin projectile for a lot of custom code
			// If you are in an editor like Visual Studio, you can hold CTRL and Click ExampleJavelinProjectile
			Item.shoot = ProjectileType<MeteorJavelinProjectile>();
		}
	}
}
