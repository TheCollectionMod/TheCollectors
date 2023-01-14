using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;

namespace TheCollectors.NPCs.Critters
{
	public class MeteorFairy : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Meteor Fairy");
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
			NPC.catchItem = (short)ModContent.ItemType<Items.Consumables.MeteoriteFairyItem>();
			NPC.dontTakeDamageFromHostiles = false;
			AIType = NPCID.FairyCritterPink;
			AnimationType = NPCID.FairyCritterPink;
			Banner = Item.NPCtoBanner(NPCID.FairyCritterPink); // Makes this NPC get affected by the normal zombie banner.
			BannerItem = Item.BannerToItem(Banner); // Makes kills of this NPC go towards dropping the banner it's associated with.
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				for (int k = 0; k < 10; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Copper, 1.75f * hitDirection, -1.75f, 0, new Color(), 0.6f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.ZoneMeteor) return 0.15f;
			return 0f;
		}
	}
}