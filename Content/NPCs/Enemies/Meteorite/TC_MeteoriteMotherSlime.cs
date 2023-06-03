using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using TheCollectors.Content.NPCs.Enemies.Meteorite;
using System;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.DataStructures;

namespace TheCollectors.Content.NPCs.Enemies.Meteorite;

public class TC_MeteoriteMotherSlime : ModNPC
{
    public override void SetStaticDefaults()
    {
        Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.MotherSlime];
        NPCID.Sets.DebuffImmunitySets.Add(NPC.type, new Terraria.DataStructures.NPCDebuffImmunityData
        {
            SpecificallyImmuneTo = new int[]
            {
                    BuffID.OnFire,
                    BuffID.OnFire3, // Hellfire?
                    BuffID.ShadowFlame,
                    BuffID.Burning
            }
        });
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
    {
        bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Meteor,
                new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.MeteoriteMotherSlime")
            });
    }

    public override void SetDefaults()
    {
        base.SetDefaults();
        NPC.width = 44;
        NPC.height = 34;
        NPC.damage = 25;
        NPC.defense = 10;
        NPC.lifeMax = 100;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.value = 300f;
        NPC.knockBackResist = 0.4f;
        NPC.aiStyle = 1;
        AIType = NPCID.MotherSlime;
        AnimationType = NPCID.MotherSlime;

        Banner = NPC.type;
        BannerItem = ModContent.ItemType<Content.Items.Placeable.Banners.TCBigMeteoriteSlime>();
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 1, 2));
        npcLoot.Add(ItemDropRule.Common(ItemID.Meteorite, 2, 2, 5));
        npcLoot.Add(ItemDropRule.Common(ItemID.Compass, 50));
    }

    public override float SpawnChance(NPCSpawnInfo spawnInfo)
    {
        return SpawnCondition.Meteor.Chance * 0.1f;
    }
   /* public virtual void OnKill(NPC npc)
    {
        for (var k = 0; k < 2; k++)
        {
            NPC.NewNPC(NPC.GetSpawnSourceForNaturalSpawn(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<TC_MeteoriteSlime>(), 0);
        }
    }*/

    /*public override void AI()
    {
        if (NPC.life > NPC.lifeMax / 2) // Dividirse cuando tiene más de la mitad de la vida
        {
            NPC.ai[0] = 0;
        }
        else // Dividirse cuando tiene menos de la mitad de la vida
        {
            NPC.ai[0] = 1;
        }
    }*/
    public override void HitEffect(NPC.HitInfo hit)
    {
        for (int i = 0; i < 12; i++)
        {
            Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Flare, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 1.25f);
        }
    }

    /*public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
    {
        int buffType = BuffID.Burning;
        int timeToAdd = 5 * 60; // Esto hace que sean 5 segundos, un segundo equivale a 60 ticks
        target.AddBuff(buffType, timeToAdd);

        if (NPC.life > 0 && NPC.ai[0] == 1) // Dividirse al golpear al jugador cuando tiene menos de la mitad de la vida
        {
            int childCount = Main.rand.Next(2, 4); // Generar de 2 a 3 hijos
            for (int i = 0; i < childCount; i++)
            {
                int childType = ModContent.NPCType<TC_MeteoriteSlime>(); // Cambiar al ID del slime hijo que desees
                NPC.NewNPC((int)NPC.position.X, (int)NPC.position.Y, childType);
            }
        }
    }*/
}