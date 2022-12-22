using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using static Terraria.ModLoader.ModContent;

namespace TheCollectors
{
	public class TheCollectors : Mod
	{
		public override void Load()
		{
			//Census mod support
			if (ModLoader.TryGetMod("Census", out Mod Census))
			{
				Census.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownNPCs.Ninja>(), "Kill King Slime");
				Census.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownNPCs.Archeologist>(), "Have Rope Coil in inventary");
				Census.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownNPCs.Meteorman>(), "Rescue in Meteor crash");
				Census.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownNPCs.Enchanter>(), "Rescue in Dungeon");
				Census.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownNPCs.McMoneyPants>(), "Have a Terra Coin in inventary");
			}
			{
				// Registers a new custom currency
				TerraCoinId = CustomCurrencyManager.RegisterCurrency(new Currencies.TerraCoin(ModContent.ItemType<Items.NPCStash.McMoneyPants.TerraCoin > (), 999L, "Terra Coin"));
				MagicSoulId = CustomCurrencyManager.RegisterCurrency(new Currencies.MagicSoul(ModContent.ItemType<Items.MagicSoul>(), 999L, "Magic Soul"));

			}
			if (ModLoader.TryGetMod("BossesAsNPCs", out Mod BossesAsNPCs))
			{
				//bossesAsNPCs.Call, ModContent.NPCType<KingSlime>();
				BossesAsNPCs.Call("KingSlime");
				//bossesAsNPCs.Call("AddToShop", "DefaultPrice", "IceQueen", ModContent.ItemType<Items.Materials.FestivePlating>(), () => NPC.downedChristmasSantank);
				//bossesAsNPCs.Call("AddToShop", "WithDiv", "IceQueen", ModContent.ItemType<Items.Accessories.Summoner.NaughtyList>(), () => NPC.downedChristmasSantank, 0.1f);
				////bossesAsNPCs.Call("AddToShop", "DefaultPrice", "IceQueen", ModContent.ItemType<Items.Weapons.Summon.Whips.FestiveWhip>(), () => true);
				//bossesAsNPCs.Call("AddToShop", "DefaultPrice", "BrainOfCthulhu", ModContent.ItemType<Items.Materials.CrawlerChelicera>(), () => true);
				//.Call("AddToShop", "DefaultPrice", "QueenSlime", ModContent.ItemType<Items.Weapons.Summon.Cudgels.CrystalClusterCudgel>(), () => true);
			}
			/*if (ModLoader.TryGetMod("BossesAsNPCs", out Mod BossesAsNPCs))
			{
				BossesAsNPCs.Call(ModContent.NPCType<KingSlime>());
				Census.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownNPCs.Archeologist>(), "No requirements");
				Census.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownNPCs.Meteorman>(), "No requirements");
				Census.Call("TownNPCCondition", ModContent.NPCType<NPCs.TownNPCs.Enchanter>(), "No requirements");
			}*/
		}
		
		public const string AssetPath = $"{nameof(TheCollectors)}/Assets/";

		public static int TerraCoinId;
		public static int MagicSoulId;

		public override void Unload()
		{
			// The Unload() methods can be used for unloading/disposing/clearing special objects, unsubscribing from events, or for undoing some of your mod's actions.
			// Be sure to always write unloading code when there is a chance of some of your mod's objects being kept present inside the vanilla assembly.
			// The most common reason for that to happen comes from using events, NOT counting On.* and IL.* code-injection namespaces.
			// If you subscribe to an event - be sure to eventually unsubscribe from it.

			// NOTE: When writing unload code - be sure use 'defensive programming'. Or, in other words, you should always assume that everything in the mod you're unloading might've not even been initialized yet.
			// NOTE: There is rarely a need to null-out values of static fields, since TML aims to completely dispose mod assemblies in-between mod reloads.
		}
	}
}