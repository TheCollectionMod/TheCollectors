using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Terraria.Utilities;
using System;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using TheCollectors.Content.Items;
using System.Linq;

namespace TheCollectors.Content.NPCs.TownNPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class McMoneyPants : ModNPC
    {
        public const string ShopName = "Shop";
        public int NumberOfTimesTalkedTo = 0;
        private static int ShimmerHeadIndex;
        //private static int PartyHeadIndex;
        private static Profiles.StackedNPCProfile NPCProfile;
        public override void Load()
        {
            // Adds our Shimmer Head to the NPCHeadLoader.
            //PartyHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Party_Head");
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
                "Nusk",
                "Vesos",
                "Suquenvergo",
                "Güilito",
                "Duopoly",
                "Jaleculani"
            };
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 26;

            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 6;
            NPCID.Sets.DangerDetectRange[NPC.type] = 300;
            NPCID.Sets.AttackType[NPC.type] = NPCID.Sets.AttackType[NPCID.Guide];
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 10;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = +10;           // For when a party is active, the party hat spawns at a Y offset.

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = -1
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
            .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
            /*.SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
            .SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike)*/
            .SetBiomeAffection<SnowBiome>(AffectionLevel.Hate)
            .SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Love)
            .SetNPCAffection(NPCID.Nurse, AffectionLevel.Like)
            .SetNPCAffection(NPCID.SantaClaus, AffectionLevel.Hate);

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
            NPC.height = 48;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.knockBackResist = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            AnimationType = NPCID.DyeTrader;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.McMoneyPants")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.TerraCoin>())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override bool CanGoToStatue(bool toKingStatue)
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

                Dust.NewDustPerfect(NPC.Center + position, DustID.GoldCoin, Vector2.Zero).noGravity = true;
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
                shop = ShopName;
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
                .Add(new Item(ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.StoryPaintings>())
                {
                    shopCustomPrice = 1,
                    shopSpecialCurrency = TheCollectors.TerraCoinId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.DyesTerrabox>())
                {
                     shopCustomPrice = 1,
                     shopSpecialCurrency = TheCollectors.TerraCoinId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.ShellphoneTerrabox>())
                {
                    shopCustomPrice = 1,
                    shopSpecialCurrency = TheCollectors.TerraCoinId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.AnkhShieldTerrabox>())
                {
                    shopCustomPrice = 1,
                    shopSpecialCurrency = TheCollectors.TerraCoinId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.TerrasparkBootsTerrabox>())
                {
                    shopCustomPrice = 1,
                    shopSpecialCurrency = TheCollectors.TerraCoinId
                }, Condition.Hardmode)
                .Add(new Item(ModContent.ItemType<Content.Items.NPCStash.McMoneyPants.ZenithTerrabox>())
                {
                    shopCustomPrice = 1,
                    shopSpecialCurrency = TheCollectors.TerraCoinId
                }, Condition.DownedMoonLord);

            npcShop.Register(); // Name of this shop tab
        }
        public override string GetChat()
        {
            NumberOfTimesTalkedTo++;
            switch (Main.rand.Next(3))
            {
                case 0:
                    {
                        switch (Main.rand.Next(5))
                        {
                            case 0:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.StandardDialogue1");
                            case 1:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.StandardDialogue2");
                            case 2:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.StandardDialogue3");
                            case 3:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.StandardDialogue4");
                            case 4:
                                if (NumberOfTimesTalkedTo >= 20)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.TalkALot");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.NotTalkALot");
                        }
                    }
                    return null;
                case 1:
                    {
                        int nurse = NPC.FindFirstNPC(NPCID.Nurse);
                        int taxcollector = NPC.FindFirstNPC(NPCID.TaxCollector);
                        int goblintinkerer = NPC.FindFirstNPC(NPCID.GoblinTinkerer);

                        switch (Main.rand.Next(3))
                        {
                            case 0:
                                if (nurse >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.Nurse", Main.npc[nurse].GivenName);
                                }
                                else return null;

                            case 1:
                                if (taxcollector >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.TaxCollector", Main.npc[taxcollector].GivenName);
                                }
                                else return null;
                            case 2:
                                if (goblintinkerer >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.GoblinTinkerer", Main.npc[goblintinkerer].GivenName);
                                }
                                else return null;
                        }
                    }
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.FaltanNPCs");
                case 2:
                    {
                        switch (Main.invasionType)  // (Main.invasionType == X)	GoblinArmy (1), FrostLegion (2), Pirates (3), MartianMadness (4), (Main.eclipse)
                        {
                            case 1:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.InvasionGenerica");
                            case 2:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.InvasionGenerica");
                            case 3:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.InvasionGenerica");
                            case 4:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.InvasionGenerica");
                            default:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.McMoneyPants.NotInvasionGenerica");
                        }
                    }
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
            cooldown = 10;
            randExtraCooldown = 10;
        }
        public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)/* tModPorter Note: closeness is now horizontalHoldoutOffset, use 'horizontalHoldoutOffset = Main.DrawPlayerItemPos(1f, itemtype) - originalClosenessValue' to adjust to the change. See docs for how to use hook with an item type. */ //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). 
        {
            int itemType = ItemID.CoinGun;
            Main.GetItemDrawFrame(itemType, out item, out itemFrame);
            horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 20;
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.GoldenBullet;
            attackDelay = 1;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
            gravityCorrection = 0f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            /*rule => rule is ItemDropWithConditionRule drop // If the rule is an ItemDropWithConditionRule instance
            && drop.itemId == ItemID.GreenCap // And that instance drops a green cap
            && drop.condition is Conditions.NamedNPC npcNameCondition // ..And if its condition is that an npc name must match some string
            && npcNameCondition.neededName == "Andrew" // And the condition's string is "Andrew".*/
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Content.Items.Armor.Vanity.McMoneyHat>(), 10)); // Drop a stack of 5 to 15 items with 1 in 2 chance (50% chance)
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GoldCoin);
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
