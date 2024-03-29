﻿using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;


namespace TheCollectors.Content.NPCs.Enemies.Granite;

public class GraniteSlime : ModNPC
{
    public override void SetStaticDefaults()
    {
        // DisplayName.SetDefault("Granite Slime");
        Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.BlueSlime];
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Granite,
                //BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
                new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.GraniteSlime")
            });
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        NPC.width = 32;
        NPC.height = 26;
        NPC.damage = 10;
        NPC.defense = 2;
        NPC.lifeMax = 20;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 150f;
        NPC.knockBackResist = 0.5f;
        NPC.aiStyle = 1;
        AIType = NPCID.BlueSlime;
        AnimationType = NPCID.BlueSlime;
        //NPC.aiStyle = NPCAIStyleID.Slime;

        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Content.Items.Placeable.Banners.GraniteSlimeBanner>();
    }

    public override void HitEffect(NPC.HitInfo hit)
    {
        for (int i = 0; i < 12; i++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Copper, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 2));
        npcLoot.Add(new CommonDrop(ItemID.Granite, 2, 3, 5));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        if (spawnInfo.Player.ZoneGranite) return 0.15f;
        return 0f;
    }
}