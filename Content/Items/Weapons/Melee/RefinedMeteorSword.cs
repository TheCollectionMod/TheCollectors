using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Content.Items.Weapons.Melee
{
	public class RefinedMeteorSword : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Meteor Wrath");
			// Tooltip.SetDefault("Can fire meteoric waves");
			// Be sure to have "using Terraria.Localization".
			//DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Ira meteórica");
			//Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Dispara ondas meteóricas");
		}

		public override void SetDefaults() 
		{
			Item.CloneDefaults(ItemID.StarWrath);
			Item.shootSpeed *= 0.75f;
			Item.damage = (int)(Item.damage * 0.5f);
			Item.width = 42;
			Item.height = 50;
			Item.shoot = ModContent.ProjectileType<Projectiles.MeteorProjectile>();
		}

		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			type = (ushort)ProjectileType<Projectiles.MeteorProjectile>(); 
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}*/

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
				target.AddBuff(BuffID.OnFire, 100);
		}
	}
}