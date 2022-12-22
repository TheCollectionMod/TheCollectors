using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TheCollectors.Projectiles.Magic;

namespace TheCollectors.Items.Weapons.Magic
{
	public class AmethystStaffTier2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Extremely Poisonous Amethyst Staff");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.CloneDefaults(ItemID.AmethystStaff);
			Item.width = 44;
			Item.height = 44;
			Item.value = Item.sellPrice(0, 1, 4, 0);
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.LightRed;

			//Use Properties
			Item.useTime = 35; //Total time that the item will take
			Item.useAnimation = 35; //Total time that the animation of the item will take
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item43 with { Pitch = -0.40f, PitchVariance = 0.80f };
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff

			//Weapon Properties
			Item.damage = 45; // Base Staff 15
			Item.mana = 10;
			Item.crit = 2; //le suma 1% al base
			Item.shootSpeed = 8f; //Velocity of projectile
			Item.shoot = ModContent.ProjectileType<AmethystBoltTier2>();
		}
	}
}