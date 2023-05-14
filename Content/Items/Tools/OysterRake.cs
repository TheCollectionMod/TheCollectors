using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Items.Tools
{
	public class OysterRake : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			// DisplayName.SetDefault("Oyster Rake");
			// Tooltip.SetDefault("Find oysters in sand");
		}

		public override void SetDefaults()
		{
			//Common Properties
			//Item.CloneDefaults(ItemID.GravediggerShovel);
			Item.width = 32;
			Item.height = 32;
			Item.value = 22000;
			Item.rare = ItemRarityID.Green;

			//Use Properties
			Item.useTime = 10;
			Item.useAnimation = 15;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item1;
			Item.useStyle = ItemUseStyleID.Swing;

			//Weapon Properties
			Item.DamageType = DamageClass.Melee;
			Item.damage = 15;
			Item.knockBack = 4;

			//Tool Propierties
			Item.pick = 20;
			Item.scale = 1.15f;
		}
		public override void HoldItem(Player player)
		{
			TheCollectorsPlayer modPlayer = player.GetModPlayer<TheCollectorsPlayer>();
			modPlayer.oysterRake = true;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(10))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.Sand, 0.0f, 0.0f, 0, new Color(), 1f);
			}
		}
	}
}