using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using System;

namespace TheCollectors.Content.NPCs.Enemies.Granite;

public class GraniteEnergy : ModNPC 
    {
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Gastropod];
        /*NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
        {
            Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
        };
        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);*/
    }
    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Granite,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.GraniteEnergy")
            });
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        NPC.width = 48;
        NPC.height = 42;
        NPC.damage = 50;
        NPC.defense = 30;
        NPC.lifeMax = 100;
        NPC.HitSound = SoundID.NPCHit54 with { Pitch = -0.45f, PitchVariance = 0.68f };
        NPC.DeathSound = SoundID.NPCDeath6 with { Pitch = 0.25f };
        NPC.value = 150f;
        NPC.knockBackResist = 0.5f;
        NPC.noGravity = true;
        NPC.aiStyle = 22;
        NPC.noTileCollide = true;
        AIType = NPCID.Gastropod;
        AnimationType = NPCID.Gastropod;

        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Content.Items.Placeable.Banners.GraniteEnergyBanner>();
    }

    public override void HitEffect(NPC.HitInfo hit) 
    {
        for(int i = 0; i < 12; i++) 
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }
    /*public override void AI()
    {
        NPC.TargetClosest(true);
    }*/
	public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(new CommonDrop(ItemID.Granite, 3));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo) 
    {
        if(spawnInfo.Player.ZoneGranite && Main.hardMode) return 0.50f;
        return 0f;
    }
}    