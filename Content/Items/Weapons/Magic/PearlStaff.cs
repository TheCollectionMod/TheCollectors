using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using TheCollectors.Content.Projectiles.Magic;

namespace TheCollectors.Content.Items.Weapons.Magic
{
	public class PearlStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pearl Staff");
			// Tooltip.SetDefault("Lanza un rayo de perlas que rebota en las paredes");
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
			Item.rare = ItemRarityID.LightRed;

			//Use Properties
			Item.useTime = 20; //Total time that the item will take
			Item.useAnimation = 20; //Total time that the animation of the item will take
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item72;
			Item.staff[Item.type] = true; //this makes the useStyle animate as a staff

			//Weapon Properties
			Item.damage = 45; // Base Staff 21
			Item.mana = 10;
			Item.knockBack = 5;
			Item.shootSpeed = 16f; //Velocity of projectile
			Item.shoot = ModContent.ProjectileType<PearlBolt>();
		}
	}
}