using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TheCollectors.Content.Projectiles.Magic;

namespace TheCollectors.Content.Items.Weapons.Magic
{
	public class EmeraldStaffTier1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Spiky Emerald Staff");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.EmeraldStaff);
			Item.width = 40;
			Item.height = 40;
			Item.value = Item.sellPrice(0, 0, 70, 0);
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Orange;

			//Use Properties
			Item.useTime = 31; //Total time that the item will take
			Item.useAnimation = 31; //Total time that the animation of the item will take
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item43 with { Pitch = -0.10f, PitchVariance = 0.80f };
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff

			//Weapon Properties
			Item.damage = 29; // Base Staff 19
			Item.mana = 10;
			Item.crit = 1; //le suma 1% al base
			Item.shootSpeed = 9f; //Velocity of projectile
			Item.shoot = ModContent.ProjectileType<EmeraldBoltTier1>();
		}
	}
}