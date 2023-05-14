using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TheCollectors.Content.Projectiles.Magic;

namespace TheCollectors.Content.Items.Weapons.Magic
{
	public class AmberStaffTier1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Amber Staff Tier 1");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.AmberStaff);
			Item.width = 40;
			Item.height = 40;
			Item.value = Item.sellPrice(0, 0, 80, 0);
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Orange;

			//Use Properties
			Item.useTime = 27; //Total time that the item will take
			Item.useAnimation = 27; //Total time that the animation of the item will take
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item43 with { Pitch = -0.10f, PitchVariance = 0.80f };
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff

			//Weapon Properties
			Item.damage = 31; // Base Staff 21
			Item.mana = 11;
			Item.crit = 1; //le suma 1% al base
			Item.shootSpeed = 10f; //Velocity of projectile
			Item.shoot = ModContent.ProjectileType<AmberBoltTier1>();
		}
	}
}