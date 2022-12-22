using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;

namespace TheCollectors.NPCs.Enemies.Corruption;

public class CorruptedFlameElemental : ModNPC 
    {
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Corrupted Flame Elemental");
        Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Wraith];
        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
        {
            Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
    }
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.CorruptedFlameElemental")
            });
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        NPC.width = 40;
        NPC.height = 58;
        NPC.damage = 50;
        NPC.defense = 30;
        NPC.lifeMax = 1000/3;
        NPC.HitSound = SoundID.NPCHit54 with { Pitch = -0.45f, PitchVariance = 0.68f };
        NPC.DeathSound = SoundID.NPCDeath6 with { Pitch = 0.25f };
        NPC.value = 150f;
        NPC.knockBackResist = 0.5f;
        NPC.noGravity = true;
        NPC.aiStyle = 22;
        NPC.noTileCollide = true;
        AIType = NPCID.Wraith;
        AnimationType = NPCID.Wraith;

        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Placeable.Banners.CorruptedFlameElementalBanner>();
    }

    public override void OnKill()
    {
        if (!Main.dedServ)
        {
            Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
            Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/ClawclopsGore1").Type);

            pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
            Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/ClawclopsGore2").Type);

            pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
            Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/ClawclopsGore1").Type);
        }
    }

    public override void HitEffect(int hitDirection, double damage) 
    {
        for(int i = 0; i < 12; i++) 
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }
    public override void AI()
    {
        NPC.TargetClosest(true);
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(new CommonDrop(ItemID.RottenChunk, 3));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) 
    {
        if(spawnInfo.Player.ZoneCorrupt && Main.hardMode) return 0.50f;
        return 0f;
    }
}    