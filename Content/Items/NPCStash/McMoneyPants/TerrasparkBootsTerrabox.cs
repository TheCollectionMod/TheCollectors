using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;

namespace TheCollectors.Content.Items.NPCStash.McMoneyPants
{
	public class TerrasparkBootsTerrabox : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
		}

		public override void SetDefaults()
		{
			Item.width = 12; 
			Item.height = 12;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(0, 2);
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void ModifyItemLoot(ItemLoot itemLoot) //from Origins Mod
		{
			itemLoot.Add(ItemDropRule.Common(ItemID.Terrarium, 1));

			var purrela = new IItemDropRule[1] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.Obsidian, 1, 5, 10),
			};

			var comun = new IItemDropRule[5] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.ObsidianSkull, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.SailfishBoots, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.HermesBoots, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.SandBoots, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.FlurryBoots, 1),
			};

			var raro = new IItemDropRule[7] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.WaterWalkingBoots, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.RocketBoots, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Aglet, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.AnkletoftheWind, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.IceSkates, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ObsidianRose, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LavaCharm, 1),
			};

			var muyraro = new IItemDropRule[5]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.SpectreBoots, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LightningBoots, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ObsidianWaterWalkingBoots, 1), 
				ItemDropRule.NotScalingWithLuck(ItemID.MoltenCharm, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.MoltenSkullRose, 1),
			};

			var sugorare = new IItemDropRule[2]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.FrostsparkBoots, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LavaWaders, 1),
			};

			IItemDropRule[] bolsa = new IItemDropRule[1] 
			{
				ItemDropRule.SequentialRulesNotScalingWithLuck(1,
					new OneFromRulesRule(2, purrela),
					new OneFromRulesRule(4, comun),
					new OneFromRulesRule(8, raro),
					new OneFromRulesRule(25, muyraro),
					new OneFromRulesRule(50, sugorare)),
			};
			itemLoot.Add(ItemDropRule.AlwaysAtleastOneSuccess(bolsa));
		}
	}
}