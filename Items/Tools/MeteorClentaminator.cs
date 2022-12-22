using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace TheCollectors.Items.Tools
{
	public class MeteorClentaminator : ModItem
    {

        public override void SetStaticDefaults()
        {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Meteor Clentaminator");
			Tooltip.SetDefault("Not as good as Clentaminator");
			//DisplayName.AddTranslation(GameCulture.Spanish, "Clentaminator de meteorito");
			//Tooltip.AddTranslation(GameCulture.Spanish, "No tan bueno como el Clentaminator");
        }

        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Clentaminator);
			Item.value = Item.buyPrice(0, 0, 24, 0);
			Item.value = Item.sellPrice(0, 0, 8, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.autoReuse = false;
			Item.shootSpeed = 1f;
		}
	}
}
