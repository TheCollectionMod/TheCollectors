using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TheCollectors.Content.Projectiles.Magic;

namespace TheCollectors.Content.Items.Weapons.Magic
{
	public class DiamondStaffTier2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Homing Diamond Staff");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.DiamondStaff);
			Item.width = 44;
			Item.height = 44;
			Item.value = Item.sellPrice(0, 1, 60, 0);
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Pink;

			//Use Properties
			Item.useTime = 24; //Total time that the item will take
			Item.useAnimation = 24; //Total time that the animation of the item will take
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item43 with { Pitch = -0.40f, PitchVariance = 0.80f };
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff

			//Weapon Properties
			Item.damage = 51; // Base Staff 21
			Item.mana = 13;
			Item.crit = 2; //le suma 1% al base
			Item.shootSpeed = 12f; //Velocity of projectile
			Item.shoot = ModContent.ProjectileType<DiamondBoltTier2>();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			for (int i = 0; i < 2; i++)
			{
				Vector2 perturbedSpeed = (velocity * 0.66f).RotatedByRandom(MathHelper.ToRadians(60));
				Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI, 2.5f);
			}
			Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 2.5f);
			return false;
		}
	}
}
