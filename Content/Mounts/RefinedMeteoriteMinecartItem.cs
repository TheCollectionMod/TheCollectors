using TheCollectors.Content.Mounts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheCollectors.Content.Mounts
{
	public class RefinedMeteoriteMinecartItem : ModItem
	{
		public override void SetDefaults() {
			Item.mountType = ModContent.MountType<RefinedMeteoriteMinecartMount>();
			Item.width = 34;
			Item.height = 22;
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = ItemRarityID.Blue;
		}
	}
}
