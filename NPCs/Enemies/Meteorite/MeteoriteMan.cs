using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;

namespace TheCollectors.NPCs.Enemies.Meteorite;

public class MeteoriteMan : ModNPC 
    {
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Meteorite Man");
        Main.npcFrameCount[NPC.type] = 9;
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
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.MeteoriteMan")
            });
    }
    public override void SetDefaults()
    {
        base.SetDefaults();
        NPC.width = 36;
        NPC.height = 52;
        NPC.damage = 50;
        NPC.defense = 30;
        NPC.lifeMax = 400/3;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 150f;
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = 3;
        AIType = NPCID.DesertGhoul;
        AnimationType = NPCID.DesertGhoul;

        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Items.Placeable.Banners.ClawclopsBanner>();
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
        if (spawnInfo.Player.ZoneMeteor) return 0.15f;
        return 0f;
    }
}    