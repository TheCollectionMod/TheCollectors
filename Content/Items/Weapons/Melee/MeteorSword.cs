using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace TheCollectors.Content.Items.Weapons.Melee
{
    public class MeteorSword : ModItem
    {
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Inflicts On Fire"); // The (English) text shown below your weapon's name.

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 40; // The item texture's width.
			Item.height = 40; // The item texture's height.
			Item.value = Item.buyPrice(0, 3, 0, 0);
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Orange;

			//Use Properties
			Item.useStyle = ItemUseStyleID.Swing; // The useStyle of the Item.
			Item.useTime = 20; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
			Item.useAnimation = 20; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
			Item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button.
			Item.UseSound = SoundID.Item1; // The sound when the weapon is being used.

			//Weapon Properties
			Item.DamageType = DamageClass.Melee;
			Item.damage = 30;
			Item.knockBack = 6;
			Item.crit = 4;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(10))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0.0f, 0.0f, 0, new Color(), 1f);
			}
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 300); // 60 frames = 1 second
		}
	}
}
