using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;

namespace TheCollectors.Items.Weapons.Magic
{
	public class BookofMeteors : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Book of Meteor Heads");
			Tooltip.SetDefault("Shoots a meteor head");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 34;
			Item.height = 40;
			Item.value = Item.buyPrice(0, 0, 0, 0);
			Item.value = Item.sellPrice(0, 0, 0, 0);
			Item.rare = ItemRarityID.Green;

			//Use Properties
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item8;
			Item.useStyle = ItemUseStyleID.Shoot;

			//Weapon Properties
			Item.noMelee = true; //Weapon sprite does no damage
			Item.DamageType = DamageClass.Magic;
			Item.damage = 20;
			Item.knockBack = 6;
			Item.crit = 0; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
			Item.mana = 12; // This is how much mana the item uses.
			Item.shootSpeed = 4; // How fast the item shoots the projectile.
			Item.shoot = ModContent.ProjectileType<Projectiles.Magic.MeteorHead>();
		}
	}
}