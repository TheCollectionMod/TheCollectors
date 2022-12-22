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

namespace TheCollectors.NPCs.TownNPCs
{
	public class MeteormanBroken : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Injured Meteorman");
			Main.npcFrameCount[NPC.type] = 1;
			NPCID.Sets.NPCBestiaryDrawModifiers bestiaryData = new(0)
			{
				Hide = true // Hides this NPC from the bestiary
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, bestiaryData);

			//NPCID.Sets.TownCritter[NPC.type] = true;
			NPCID.Sets.DebuffImmunitySets.Add(NPC.type, new Terraria.DataStructures.NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[]
				{
					BuffID.OnFire,
					BuffID.OnFire3, // Hellfire?
                    BuffID.ShadowFlame,
					BuffID.Burning
				}
			});
		}
		public override void SetDefaults()
		{
			NPC.friendly = true;
			//NPC.townNPC = true;
			//NPC.dontTakeDamage = true;
			NPC.width = 54;
			NPC.height = 22;
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

			chat.Add(Language.GetTextValue("Mods.TheCollectors.Dialogue.MeteormanBroken.RescueDialogue"));
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
			NPC.Transform(NPCType<Meteorman>());
			NPC.dontTakeDamage = false;
			TheCollectorsWorld.savedMeteorman = true;
			TheCollectorsWorld.UpdateWorldBool();
			TheCollectorsWorld.meteormanJustRescued = true;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) //from Rijam's Mod
		{
			if (spawnInfo.Player.ZoneMeteor && !TheCollectorsWorld.savedMeteorman && !NPC.AnyNPCs(ModContent.NPCType<MeteormanBroken>()) && !NPC.AnyNPCs(ModContent.NPCType<Meteorman>()))
			{
				if (spawnInfo.SpawnTileType == TileID.Meteorite)
				{
					return 1f;
				}
			}
			return 0f;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				for (int k = 0; k < 8; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Lava, 2.5f * hitDirection, -2.5f, Scale: 0.8f);
				}

				if (!Main.dedServ)
				{
					Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
					Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/MeteormanGore3").Type);

					pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
					Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/MeteormanGore2").Type);

					pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
					Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/MeteormanGore1").Type);
				}
			}
			else
			{
				for (int k = 0; k < damage / NPC.lifeMax * 50.0; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, hitDirection, -1f, Scale: 0.6f);
				}
			}
		}
	}
}
