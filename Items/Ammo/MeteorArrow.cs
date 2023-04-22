using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Ammo
{
    public class MeteorArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Arrow");
            Tooltip.SetDefault("'Hits like a meteor'");
        }
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 14;
            Item.height = 34;
            Item.shoot = ModContent.ProjectileType<Projectiles.MeteorArrow>();
            Item.shootSpeed = 6.0f;
            Item.knockBack = 10.0f;
            Item.value = Item.sellPrice(0, 0, 0, 4);
            Item.value = Item.buyPrice(0, 0, 0, 20);
            Item.rare = ItemRarityID.Blue;
            Item.ammo = AmmoID.Arrow;
        }
    }
}
