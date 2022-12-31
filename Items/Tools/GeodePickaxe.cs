using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Items.Tools
{
	public class GeodePickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Geode Pickaxe");
			Tooltip.SetDefault("Stone has a 10% Geode Drop");
		}

		public override void SetDefaults()
		{
			//Common Properties
			Item.width = 32;
			Item.height = 32;
			Item.value = 22000;
			Item.rare = ItemRarityID.Green;

			//Use Properties
			Item.useTime = 14;
			Item.useAnimation = 22;
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item1;
			Item.useStyle = ItemUseStyleID.Swing;

			//Weapon Properties
			Item.DamageType = DamageClass.Melee;
			Item.damage = 12;
			Item.knockBack = 4;

			//Tool Propierties
			Item.pick = 85;
			Item.scale = 1.15f;
		}
		public override void HoldItem(Player player)
		{
			TheCollectorsPlayer modPlayer = player.GetModPlayer<TheCollectorsPlayer>();
			modPlayer.geodePickaxe = true;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(10))
			{
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.GemRuby, 0.0f, 0.0f, 0, new Color(), 1f);
			}
		}
	}
}