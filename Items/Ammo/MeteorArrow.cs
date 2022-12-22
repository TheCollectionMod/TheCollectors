using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors.Items.Ammo
{
    public class MeteorArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Meteor Arrow");
            Tooltip.SetDefault("'Hits like a meteor'");
            //Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "Flecha de meteorito");
           // DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Spanish), "'Golpea como un meteorito'");
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
