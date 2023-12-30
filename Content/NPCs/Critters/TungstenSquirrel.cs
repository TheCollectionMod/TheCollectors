using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Bestiary;

namespace TheCollectors.Content.NPCs.Critters
{
	public class TungstenSquirrel : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tungsten Squirrel");
			NPCID.Sets.TownCritter[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Squirrel];
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
			{
				Velocity = 1f 
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.TungstenSquirrel")
			});
		}
		public override void SetDefaults()
		{
			base.SetDefaults();
			NPC.width = 48;
			NPC.height = 38;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0f;
			NPC.aiStyle = 7;
			NPC.catchItem = (short)ModContent.ItemType<Content.Items.Consumables.Critters.TungstenSquirrelItem>();
			NPC.dontTakeDamageFromHostiles = false;
			AIType = NPCID.Squirrel;
			AnimationType = NPCID.Squirrel;
			Banner = Item.NPCtoBanner(NPCID.Squirrel); 
			BannerItem = Item.BannerToItem(Banner); 
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
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.Find<ModGore>(Mod.Name + "/" + Name + "Gore").Type, 1f);
			}
		}
	}
}