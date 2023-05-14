using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;

namespace TheCollectors.Content.Items.NPCStash.McMoneyPants
{
	public class DyesTerrabox : ModItem
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

			var purrela = new IItemDropRule[15] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.RedDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.OrangeDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.YellowDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LimeDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GreenDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.TealDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.CyanDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.SkyBlueDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlueDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PurpleDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.VioletDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PinkDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrownDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.SilverDye, 1),
			};

			var comun = new IItemDropRule[25] 
			{
				ItemDropRule.NotScalingWithLuck(ItemID.BrightRedDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightOrangeDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightYellowDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightLimeDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightGreenDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightTealDye, 1), 
				ItemDropRule.NotScalingWithLuck(ItemID.BrightCyanDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightSkyBlueDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightBlueDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightPurpleDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightVioletDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightPinkDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightBrownDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrightSilverDye, 1), 
				ItemDropRule.NotScalingWithLuck(ItemID.FlameDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlueFlameDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GreenFlameDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.YellowGradientDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.CyanGradientDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.VioletGradientDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.RainbowDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.IntenseFlameDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.IntenseBlueFlameDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.IntenseGreenFlameDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.IntenseRainbowDye, 1),
			};

			var raro = new IItemDropRule[34]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.RedandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.OrangeandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.YellowandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LimeandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GreenandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.TealandBlackDye, 1), 
				ItemDropRule.NotScalingWithLuck(ItemID.CyanandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.SkyBlueandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlueandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PurpleandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.VioletandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PinkandBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrownAndBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.SilverAndBlackDye, 1), 
				ItemDropRule.NotScalingWithLuck(ItemID.FlameAndBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GreenFlameAndBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlueFlameAndBlackDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.RedandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.OrangeandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.YellowandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LimeandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GreenandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.TealandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.CyanandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.SkyBlueandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlueandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PurpleandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.VioletandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PinkandSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BrownAndSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlackAndWhiteDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.FlameAndSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GreenFlameAndSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlueFlameAndSilverDye, 1),
			};

			var muyraro = new IItemDropRule[33]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.AcidDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BlueAcidDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.RedAcidDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ChlorophyteDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.GelDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.MushroomDye, 1), //Glowing Mushroom Dye
				ItemDropRule.NotScalingWithLuck(ItemID.GrimDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.HadesDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BurningHadesDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ShadowflameHadesDye, 1), 
				ItemDropRule.NotScalingWithLuck(ItemID.LivingOceanDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LivingFlameDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LivingRainbowDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.MartianArmorDye, 1), //Martian Dye
				ItemDropRule.NotScalingWithLuck(ItemID.MidnightRainbowDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.MirageDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.NegativeDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PixieDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PhaseDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PurpleOozeDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ReflectiveDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ReflectiveCopperDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ReflectiveGoldDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ReflectiveObsidianDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ReflectiveMetalDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ReflectiveSilverDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ShadowDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ShiftingSandsDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.DevDye, 1), //Skiphs'Blood
				ItemDropRule.NotScalingWithLuck(ItemID.TwilightDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.WispDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.InfernalWispDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.UnicornWispDye, 1),
			};

			var sugorare = new IItemDropRule[12]
			{
				ItemDropRule.NotScalingWithLuck(ItemID.NebulaDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.SolarDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.StardustDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.VortexDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.LokisDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.PinkGelDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.ShiftingPearlSandsDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.TeamDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.BloodbathDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.FogboundDye, 1),
				ItemDropRule.NotScalingWithLuck(ItemID.HallowBossDye, 1), //Prismatic Dye
				ItemDropRule.NotScalingWithLuck(ItemID.VoidDye, 1),
			};

			IItemDropRule[] bolsa = new IItemDropRule[1] 
			{
				ItemDropRule.SequentialRulesNotScalingWithLuck(1,
					new OneFromRulesRule(3, purrela),
					new OneFromRulesRule(4, comun),
					new OneFromRulesRule(5, raro),
					new OneFromRulesRule(8, muyraro),
					new OneFromRulesRule(20, sugorare)), //4%
			};
			itemLoot.Add(ItemDropRule.AlwaysAtleastOneSuccess(bolsa));
		}
	}
}