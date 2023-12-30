using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Content.Items.Placeable.RefinedMeteoriteSet;

namespace TheCollectors.Common.GlobalNPCs
{
    public class TheCollectorsNPCShop : GlobalNPC
	{
		public override void ModifyShop(NPCShop shop)
		{
			if (shop.NpcType == NPCID.WitchDoctor)
			{
				shop.Add(ModContent.ItemType<RefinedMeteoriteFountain>(), Condition.DownedPlantera);
			}
		}
	}
}