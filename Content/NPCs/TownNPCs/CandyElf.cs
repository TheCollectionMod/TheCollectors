using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.Creative;
using System.Linq;
using Terraria.Audio;
using Terraria.Utilities;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.DataStructures;
using ReLogic.Content;
using Terraria.ModLoader.IO;
//using TheBeta.Content.Dusts;

namespace TheCollectors.Content.NPCs.TownNPCs
{
    [AutoloadHead]
    public class CandyElf : ModNPC
    {
        public const string ShopName = "Shop";
        private static int ShimmerHeadIndex;
        private static Profiles.StackedNPCProfile NPCProfile;
        public override void Load()
        {
            // Adds our Shimmer Head to the NPCHeadLoader.
            ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
        }
        public override ITownNPCProfile TownNPCProfile()
        {
            return NPCProfile;
        }
        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Bastónica",
                "Elfividad",
                "Copónida",
                "Dulciva",
                "Caramelina",
                "Nevántica"
            };
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 1000;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4; // Posición del Party Hat

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f,
                Direction = -1
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
            .SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
            .SetBiomeAffection<HallowBiome>(AffectionLevel.Like)
            .SetBiomeAffection<JungleBiome>(AffectionLevel.Dislike)
            .SetBiomeAffection<DesertBiome>(AffectionLevel.Hate)
            .SetNPCAffection(NPCID.SantaClaus, AffectionLevel.Love)
            .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Like)
            .SetNPCAffection(NPCID.Truffle, AffectionLevel.Dislike)
            .SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Hate);

            // This creates a "profile" for Ninja, which allows for different textures during a party and/or while the NPC is shimmered.
            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party"),
                new Profiles.DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex, Texture + "_Shimmer_Party")
            );
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 36;
            NPC.height = 44;
            NPC.aiStyle = 7;
            NPC.damage = 20;
            NPC.defense = 20;
            NPC.lifeMax = 350;
            NPC.knockBackResist = 0.6f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.Item1;
            AnimationType = NPCID.Wizard;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
                new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.CandyElf")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemID.CandyCaneBlock)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override bool CanGoToStatue(bool toQueenStatue)
        {
            return true;
        }
        // Create a square of pixels around the NPC on teleport.
        public void StatueTeleport()
        {
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y))
                {
                    position.X = Math.Sign(position.X) * 20;
                }
                else
                {
                    position.Y = Math.Sign(position.Y) * 20;
                }

                //Dust.NewDustPerfect(NPC.Center + position, ModContent.DustType<Sparkle>(), Vector2.Zero).noGravity = true;
            }
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName; // Esto lo convierte en tienda
            }
        }
        public override void ModifyActiveShop(string shopName, Item[] items)
        {
            foreach (Item item in items)
            {
                // Skip 'air' items and null items.
                if (item == null || item.type == ItemID.None)
                {
                    continue;
                }

                // If NPC is shimmered then reduce all prices by 50%.
                if (NPC.IsShimmerVariant)
                {
                    int value = item.shopCustomPrice ?? item.value;
                    item.shopCustomPrice = value / 2;
                }
            }
        }
        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add(ItemID.CandyCaneBlock)
                .Add(ItemID.CandyCaneSword)
                .Add(ItemID.CnadyCanePickaxe)
                .Add(ItemID.CandyCaneHook)
                .Add(ItemID.FruitcakeChakram)
                .Add(ItemID.HandWarmer)
                .Add(ItemID.Toolbox)
                .Add(ItemID.MrsClauseHat)
                .Add(ItemID.MrsClauseShirt)
                .Add(ItemID.MrsClauseHeels)
                .Add(ItemID.ParkaHood)
                .Add(ItemID.ParkaCoat)
                .Add(ItemID.ParkaPants)
                .Add(ItemID.TreeMask)
                .Add(ItemID.TreeShirt)
                .Add(ItemID.TreeTrunks)
                .Add(ItemID.ReindeerAntlers)
                .Add(ItemID.SnowHat)
                .Add(ItemID.Holly)
                .Add(ItemID.ChristmasPudding)
                .Add(ItemID.SugarCookie)
                .Add(ItemID.GingerbreadCookie)
                .Add(ItemID.Eggnog)
                .Add(new Item(ModContent.ItemType<Content.Items.Placeable.RedCandyCaneSet.RedCandyCaneCraftingStation>())
                {
                    shopCustomPrice = 300,
                    shopSpecialCurrency = TheCollectors.CandyCaneId
                });

            npcShop.Register(); // Name of this shop tab
        }
        public override string GetChat()
        {
            switch (Main.rand.Next(2))
            {
                case 0:
                    {
                        switch (Main.rand.Next(4))
                        {
                            case 0:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.CandyElf.StandardDialogue1");
                            case 1:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.CandyElf.StandardDialogue2");
                            case 2:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.CandyElf.StandardDialogue3");
                            case 3:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.CandyElf.StandardDialogue4");
                        }
                    }
                    return null;
                case 1:
                    {
                        int santaclaus = NPC.FindFirstNPC(NPCID.SantaClaus);
                        int partygirl = NPC.FindFirstNPC(NPCID.PartyGirl);

                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                if (santaclaus >= 0 && Main.rand.NextBool(4))
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.CandyElf.SantaClaus", Main.npc[santaclaus].GivenName);
                                }
                                else return null;

                            case 1:
                                if (partygirl >= 0 && Main.rand.NextBool(4))
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.CandyElf.PartyGirl", Main.npc[partygirl].GivenName);
                                }
                                else return null;
                        }
                    }
                    return null;
            }
            return null;
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
                projType = ProjectileID.StarCannonStar;
                attackDelay = 1;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 30f;
            gravityCorrection = 0f;
            randomOffset = 2f;
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
                // Retrieve the gore types. This NPC has shimmer and party variants for head, arm, and leg gore. (12 total gores)
                string variant = "";
                if (NPC.IsShimmerVariant) variant += "_Shimmer";
                if (NPC.altTexture == 1) variant += "_Party";
                int hatGore = NPC.GetPartyHatGore();
                int headGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Head").Type;
                int armGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Arm").Type;
                int legGore = Mod.Find<ModGore>($"{Name}_Gore{variant}_Leg").Type;

                // Spawn the gores. The positions of the arms and legs are lowered for a more natural look.
                if (hatGore > 0)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, hatGore);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, headGore, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, armGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 34), NPC.velocity, legGore);
            }
        }
    }
}