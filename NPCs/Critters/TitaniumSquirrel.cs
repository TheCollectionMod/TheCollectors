using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Bestiary;

namespace TheCollectors.NPCs.Critters
{
	public class TitaniumSquirrel : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Titanium Squirrel");
			NPCID.Sets.TownCritter[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Squirrel];
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = 1f 
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}
		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.TitaniumSquirrel")
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
			NPC.catchItem = (short)ModContent.ItemType<Items.Consumables.Critters.TitaniumSquirrelItem>();
			NPC.dontTakeDamageFromHostiles = false;
			AIType = NPCID.Squirrel;
			AnimationType = NPCID.Squirrel;
			Banner = Item.NPCtoBanner(NPCID.Squirrel); 
			BannerItem = Item.BannerToItem(Banner); 
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (NPC.life <= 0)
			{
				for (int k = 0; k < 10; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, 1.75f * hitDirection, -1.75f, 0, new Color(), 0.6f);
			}
		}
	}
}