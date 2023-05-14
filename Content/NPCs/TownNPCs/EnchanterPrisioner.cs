using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.Utilities;
using System;
using System.Collections.Generic;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.Creative;
using System.Linq;
using Terraria.Audio;
using Terraria.Utilities;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.DataStructures;
using ReLogic.Content;
using Terraria.ModLoader.IO;

namespace TheCollectors.Content.NPCs.TownNPCs
{
	public class EnchanterPrisioner : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Enchanter Prisioner");
			Main.npcFrameCount[NPC.type] = 1;
			NPCID.Sets.NPCBestiaryDrawModifiers bestiaryData = new(0)
			{
				Hide = true // Hides this NPC from the bestiary
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, bestiaryData);
		}
		public override void SetDefaults()
		{
			NPC.friendly = true;
			//NPC.townNPC = true;
			//NPC.dontTakeDamage = true;
			NPC.width = 36;
			NPC.height = 56;
			NPC.aiStyle = 0;
			NPC.damage = 0;
			NPC.defense = 25;
			NPC.lifeMax = 10000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0f;
			NPC.rarity = 1;
		}
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) => false;
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			chat.Add(Language.GetTextValue("Mods.TheCollectors.Dialogue.EnchanterPrisioner.RescueDialogue"));
			return chat; // chat is implicitly cast to a string.
		}
		public override bool CanChat() //from Calamity's Vanities
		{
			return true;
		}
		public override void AI()
		{
			//From Spirit mod
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				NPC.homeless = true;
				NPC.homeTileX = -1;
				NPC.homeTileY = -1;
				NPC.netUpdate = true;
			}

			foreach (var player in Main.player)
			{
				if (!player.active)
					continue;

				if (player.talkNPC == NPC.whoAmI)
				{
					Rescue();
					return;
				}
			}
		}
		public void Rescue() //from Rijam's Mod
		{
			NPC.Transform(NPCType<Enchanter>());
			NPC.dontTakeDamage = false;
			TheCollectorsWorld.savedEnchanter = true;
			TheCollectorsWorld.UpdateWorldBool();
			TheCollectorsWorld.enchanterJustRescued = true;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) //from Rijam's Mod
		{
			if (spawnInfo.Player.ZoneDungeon && !TheCollectorsWorld.savedEnchanter && !NPC.AnyNPCs(ModContent.NPCType<EnchanterPrisioner>()) && !NPC.AnyNPCs(ModContent.NPCType<Enchanter>()))
			{
				if (spawnInfo.SpawnTileType == TileID.BlueDungeonBrick || spawnInfo.SpawnTileType == TileID.GreenDungeonBrick || spawnInfo.SpawnTileType == TileID.PinkDungeonBrick)
				{
					return 1f;
				}
			}
			return 0f;
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
			int num = NPC.life > 0 ? 1 : 5;

			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood);
			}

			if (Main.netMode != NetmodeID.Server && NPC.life <= 0)
			{
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.Find<ModGore>(Mod.Name + "/" + Name + "_Head").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.Find<ModGore>(Mod.Name + "/" + Name + "_Arm").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.Find<ModGore>(Mod.Name + "/" + Name + "_Leg").Type, 1f);
			}
		}
	}
}
