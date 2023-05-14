using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Bestiary;

namespace TheCollectors.Content.NPCs.Critters
{
	public class CopperBunny : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Copper Bunny");
			NPCID.Sets.TownCritter[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.GemBunnyRuby];
			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = 1f 
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.CopperBunny")
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
			NPC.catchItem = (short)ModContent.ItemType<Content.Items.Consumables.Critters.CopperBunnyItem>();
			NPC.dontTakeDamageFromHostiles = false;
			AIType = NPCID.GemBunnyRuby;
			AnimationType = NPCID.GemBunnyRuby;
			Banner = Item.NPCtoBanner(NPCID.Bunny); // Makes this NPC get affected by the normal bunny.
			BannerItem = Item.BannerToItem(Banner); // Makes kills of this NPC go towards dropping the banner it's associated with.
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
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.Find<ModGore>(Mod.Name + "/" + Name + "Gore1").Type, 1f); // Cabeza
				for (int k = 0; k < 2; k++)
				{
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, ModContent.Find<ModGore>(Mod.Name + "/" + Name + "Gore2").Type, 1f); // Patas
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.Player.ZoneNormalCaverns && spawnInfo.SpawnTileType == ModContent.TileType<Items.NPCStash.Meteorman.CopperSoilTile>())
			{
				return 0.15f;
			}
			else
			{
				return 0f;
			}
		}
	}
}