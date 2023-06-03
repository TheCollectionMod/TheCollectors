using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

namespace TheCollectors.Content.NPCs.Critters
{
	public class MeteorFairy : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Meteor Fairy");
			NPCID.Sets.TownCritter[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.FairyCritterPink];
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				// Influences how the NPC looks in the Bestiary
				Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Meteor,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.MeteorFairy")
			});
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			NPC.width = 16;
			NPC.height = 18;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0f;
			NPC.aiStyle = 112;
			NPC.catchItem = ItemID.FairyCritterPink;
			NPC.noGravity = true;
			NPC.catchItem = (short)ModContent.ItemType<Content.Items.Consumables.Critters.MeteoriteFairyItem>();
			NPC.dontTakeDamageFromHostiles = false;
			AIType = NPCID.FairyCritterPink;
			AnimationType = NPCID.FairyCritterPink;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<Content.Items.Placeable.Banners.MeteoriteFairyBanner>();
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
			int num = NPC.life > 0 ? 1 : 5;

			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.FireflyHit);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.ZoneMeteor) return 0.15f;
			return 0f;
		}
	}
}