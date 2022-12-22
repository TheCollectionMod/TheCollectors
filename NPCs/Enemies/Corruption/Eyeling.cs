using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;

namespace TheCollectors.NPCs.Enemies.Corruption;

public class Eyeling : ModNPC 
    {
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Eyeling");
        Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Crab];
        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
    }
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
        {
            BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
            new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.Eyeling")
        });
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        NPC.width = 30;
        NPC.height = 22;
        NPC.damage = 20;
        NPC.defense = 10;
        NPC.lifeMax = 50;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 80f;
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = 3;
        AIType = NPCID.Crab;
        AnimationType = NPCID.Crab;

        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Placeable.Banners.EyelingBanner>();
    }

    public override void OnKill()
    {
        if (!Main.dedServ)
        {
            Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
            Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/EyelingGore1").Type);

            pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
            Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/EyelingGore2").Type);
        }
    }
    public override void HitEffect(int hitDirection, double damage)
    {
        for (int i = 0; i < 12; i++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Copper, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }
    public override void AI()
    {
        NPC.TargetClosest(true);
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) 
    {
        npcLoot.Add(new CommonDrop(ItemID.RottenChunk, 3));
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Pets.FlyingEyeling>(), 100)); 
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) 
    {
        if(spawnInfo.Player.ZoneCorrupt) return 1f;
        return 0f;
    }
}    