using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;

namespace TheCollectors.Content.Items.NPCStash.McMoneyPants
{
	public class BaitTerrabox : ModItem
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

			var purrela = new IItemDropRule[6] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.MonarchButterfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.SulphurButterfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Grasshopper, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Scorpion, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Snail, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Stinkbug, 1)
			};

			var comun = new IItemDropRule[24] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.ApprenticeBait, 1,5,10),
				ItemDropRule.NotScalingWithLuck(ItemID.BlackScorpion, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.HellButterfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ZebraSwallowtailButterfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GlowingSnail, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Grubby, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LadyBug, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.WaterStrider, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.UlyssesButterfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlackDragonfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlueDragonfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GreenDragonfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.OrangeDragonfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.RedDragonfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.YellowDragonfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Firefly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlueJellyfish, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GreenJellyfish, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PinkJellyfish, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Maggot, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.JuliaButterfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Lavafly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Sluggy, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Worm, 1)
			};

			var raro = new IItemDropRule[7] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.JourneymanBait, 1,5,10),
				ItemDropRule.NotScalingWithLuck(ItemID.RedAdmiralButterfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PurpleEmperorButterfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.EnchantedNightcrawler, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LightningBug, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.MagmaSnail, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.Buggy, 1)
			};

			var muyraro = new IItemDropRule[2]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.MasterBait, 1,5,10),
				ItemDropRule.NotScalingWithLuck(ItemID.TreeNymphButterfly, 1),
			};

			var sugorare = new IItemDropRule[6]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.GoldButterfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GoldDragonfly, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GoldGrasshopper, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GoldLadyBug, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GoldWaterStrider, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GoldWorm, 1)
			};

			IItemDropRule[] bolsa = new IItemDropRule[1] 
			{
				ItemDropRule.SequentialRulesNotScalingWithLuck(1,
					new OneFromRulesRule(2, purrela),		// 50%
					new OneFromRulesRule(4, comun),			// 25%
					new OneFromRulesRule(8, raro),			// 12.5%
					new OneFromRulesRule(25, muyraro),		// 4%
					new OneFromRulesRule(50, sugorare)),	// 2%
			};
			itemLoot.Add(ItemDropRule.AlwaysAtleastOneSuccess(bolsa));
		}
	}
}