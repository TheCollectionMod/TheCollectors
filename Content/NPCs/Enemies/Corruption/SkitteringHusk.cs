﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;

namespace TheCollectors.Content.NPCs.Enemies.Corruption;

public class SkitteringHusk : ModNPC 
    {
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Skittering husk");
        Main.npcFrameCount[NPC.type] = 7;
        NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers()
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
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheCorruption,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.SkitteringHusk")
            });
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        NPC.width = 26;
        NPC.height = 50;
        NPC.damage = 20;
        NPC.defense = 10;
        NPC.lifeMax = 50;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 80f;
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = 3;
        AIType = NPCID.Zombie;
        AnimationType = NPCID.Zombie;

        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Content.Items.Placeable.Banners.SkitteringHuskBanner>();
    }

    public override void OnKill()
    {
        if (!Main.dedServ)
        {
            Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
            Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/SkitteringHuskGore1").Type);

            pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
            Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/SkitteringHuskGore2").Type);

            pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
            Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/SkitteringHuskGore1").Type);
        }
    }
    public override void HitEffect(NPC.HitInfo hit) 
    {
        for(int i = 0; i < 12; i++) 
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
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.ZoneCorrupt && Main.hardMode) return 0.50f;
        return 0f;
    }
}    