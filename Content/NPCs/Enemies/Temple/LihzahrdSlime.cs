using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;

namespace TheCollectors.Content.NPCs.Enemies.Temple;

public class LihzahrdSlime : ModNPC
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Lihzahrd Slime");
		Main.npcFrameCount[NPC.type] = 2;
	}

	public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
	{
		// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
		bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheTemple,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.LihzahrdSlime")
			});
	}

	public override void SetDefaults()
	{
		base.SetDefaults();
		NPC.width = 32;
		NPC.height = 26;
		NPC.damage = 20;
		NPC.defense = 8;
		NPC.lifeMax = 100;
		NPC.HitSound = SoundID.NPCHit1;
		NPC.DeathSound = SoundID.NPCDeath1;
		NPC.value = 25f;
		NPC.knockBackResist = 0.3f;
		NPC.aiStyle = 1;
		AIType = NPCID.BlueSlime;
		AnimationType = NPCID.BlueSlime; 

		Banner = NPC.type;
		BannerItem = ModContent.ItemType<Content.Items.Placeable.Banners.LihzardSlimeBanner>();
	}

	public override void HitEffect(NPC.HitInfo hit)
	{
		for (int i = 0; i < 12; i++)
		{
			Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Lihzahrd, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
		}
	}

	public override void ModifyNPCLoot(NPCLoot npcLoot)
	{
		npcLoot.Add(new CommonDrop(ItemID.LihzahrdBrick, 1, 2, 7));
	}

	public override float SpawnChance(NPCSpawnInfo spawnInfo)
	{
		if (spawnInfo.Player.ZoneLihzhardTemple) return 10f;
		return 0f;
	}
}