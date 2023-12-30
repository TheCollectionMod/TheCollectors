using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Personalities;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using TheCollectors.Content.Items;
using System;
using System.Linq;
using TheCollectors.Content.Projectiles.Magic;
using TheCollectors.Content.Items.Weapons.Magic;
using Terraria.GameContent.Events;
using static Terraria.ModLoader.ModContent;
using TheCollectors.Content.Dusts;

namespace TheCollectors.Content.NPCs.TownNPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class Enchanter : ModNPC
    {
        public const string ShopName = "Shop";
        public int NumberOfTimesTalkedTo = 0;
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
        public override void LoadData(TagCompound tag)
        {
            NumberOfTimesTalkedTo = tag.GetInt("numberOfTimesTalkedTo");
        }
        public override void SaveData(TagCompound tag)
        {
            tag["numberOfTimesTalkedTo"] = NumberOfTimesTalkedTo;
        }
        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Tim",
                "Timmy",
                "Timonthy",
                "Timote",
                "Timothy",
                "Timot"
            };
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 23;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 4;      // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
            NPCID.Sets.AttackFrameCount[NPC.type] = 3;
            NPCID.Sets.DangerDetectRange[NPC.type] = 100;   // The amount of pixels away from the center of the npc that it tries to attack enemies.
            NPCID.Sets.AttackType[NPC.type] = NPCID.Sets.AttackType[NPCID.Wizard];
            NPCID.Sets.AttackTime[NPC.type] = 10;           // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = 10;           // For when a party is active, the party hat spawns at a Y offset.

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers()
            {
                Velocity = 1f,  // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = -1  // -1 is left and 1 is right. NPCs are drawn facing the left by default.
                                // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                                // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
             //.SetBiomeAffection<ExampleSurfaceBiome>(AffectionLevel.Love) // Para los biomas del mod, cuando tenga
             .SetBiomeAffection<HallowBiome>(AffectionLevel.Like)
             .SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
             .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate)
             .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
             .SetNPCAffection(NPCID.Wizard, AffectionLevel.Like)
             //.SetNPCAffection(ModContent.NPCType<RuneWizard>(), AffectionLevel.Like) // Para los NPCs del mod
             .SetNPCAffection(NPCID.PartyGirl, AffectionLevel.Like)
             .SetNPCAffection(NPCID.GoblinTinkerer, AffectionLevel.Dislike)
             .SetNPCAffection(NPCID.Cyborg, AffectionLevel.Hate);
            //Princess is automatically set

            // This creates a "profile" for Ninja, which allows for different textures during a party and/or while the NPC is shimmered.
            NPCProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party"),
                new Profiles.DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex, Texture + "_Shimmer_Party")
            );
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;         // Sets NPC to be a Town NPC
            NPC.friendly = true;        // NPC Will not attack player
            NPC.width = 36;
            NPC.height = 56;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.knockBackResist = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;

            AnimationType = NPCID.Wizard;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.TheHallow,

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.Enchanter")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            if (TheCollectorsWorld.savedEnchanter && NPC.CountNPCS(ModContent.NPCType<Enchanter>()) < 1)
            {
                return true;
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

                Dust.NewDustPerfect(NPC.Center + position, ModContent.DustType<Sparkle>(), Vector2.Zero).noGravity = true;
            }
        }
        public override void SetChatButtons(ref string button, ref string button2)  // What the chat buttons are when you open up the chat UI
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
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.AmethystStaffTier1>())
                {
                    shopCustomPrice = 20,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.TopazStaffTier1>())
                {
                    shopCustomPrice = 20,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.SapphireStaffTier1>())
                {
                    shopCustomPrice = 30,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.EmeraldStaffTier1>())
                {
                    shopCustomPrice = 30,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.AmberStaffTier1>())
                {
                    shopCustomPrice = 40,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.RubyStaffTier1>())
                {
                    shopCustomPrice = 40,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.DiamondStaffTier1>())
                {
                    shopCustomPrice = 50,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                })
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.AmethystStaffTier2>())
                {
                    shopCustomPrice = 200,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                }, Condition.Hardmode)
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.TopazStaffTier2>())
                {
                    shopCustomPrice = 200,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                }, Condition.Hardmode)
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.SapphireStaffTier2>())
                {
                    shopCustomPrice = 300,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                }, Condition.Hardmode)
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.EmeraldStaffTier2>())
                {
                    shopCustomPrice = 300,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                }, Condition.Hardmode)
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.AmberStaffTier2>())
                {
                    shopCustomPrice = 400,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                }, Condition.Hardmode)
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.RubyStaffTier2>())
                {
                    shopCustomPrice = 400,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                }, Condition.Hardmode)
                .Add(new Item(ModContent.ItemType<Content.Items.Weapons.Magic.DiamondStaffTier2>())
                {
                    shopCustomPrice = 500,
                    shopSpecialCurrency = TheCollectors.MagicSoulId
                }, Condition.Hardmode);

            npcShop.Register(); // Name of this shop tab
        }
        public override string GetChat()
        {
            NumberOfTimesTalkedTo++;
            switch (Main.rand.Next(4))
            {
                case 0:
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                {
                                    switch (Main.rand.Next(5))
                                    {
                                        case 0:
                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.StandardDialogue1");
                                        case 1:
                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.StandardDialogue2");
                                        case 2:
                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.StandardDialogue3");
                                        case 3:
                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.InfoSoul");
                                        case 4:
                                            if (NumberOfTimesTalkedTo >= 20)
                                            {
                                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.TalkALot");
                                            }
                                            else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.NotTalkALot");
                                    }
                                    return null;
                                }
                            case 1:
                                if (BirthdayParty.PartyIsUp)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.PartyIsUp");
                                }
                                else return null;
                        }
                    }
                    return null;
                case 1:
                    {
                        int wizard = NPC.FindFirstNPC(NPCID.Wizard);
                        int partygirl = NPC.FindFirstNPC(NPCID.PartyGirl);
                        int dryad = NPC.FindFirstNPC(NPCID.Dryad);
                        //int runeWizard = NPC.FindFirstNPC(ModContent.NPCType < RuneWizard());

                        switch (Main.rand.Next(3))
                        {
                            case 0:
                                if (wizard >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.Wizard", Main.npc[wizard].GivenName);
                                }
                                else return null;

                            case 1:
                                if (partygirl >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.PartyGirl", Main.npc[partygirl].GivenName);
                                }
                                else return null;
                            case 2:
                                if (dryad >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.Dryad", Main.npc[partygirl].GivenName);
                                }
                                else return null;
                                /*case 2:
                                    if (runeWizard >= 0)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.RuneWizard1", Main.npc[runeWizard].GivenName);
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.RuneWizard2", Main.npc[runeWizard].GivenName);*/
                        }
                    }
                    return null;
                case 2:
                    {
                        switch (Main.invasionType)  // (Main.invasionType == X)	GoblinArmy (1), FrostLegion (2), Pirates (3), MartianMadness (4)
                        {
                            case 1:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.InvansionGenerica");
                            case 2:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.FrostInvasion2");
                            case 3:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.InvansionGenerica");
                            case 4:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.InvansionGenerica");
                            default:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.FrostInvasion1");
                        }
                    }
                case 3:
                    {
                        switch (Main.rand.Next(1))
                        {
                            case 0:
                                if (NPC.downedAncientCultist)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.AncientCultist2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Enchanter.AncientCultist1");
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
            cooldown = 10;
            randExtraCooldown = 10;
        }
        public override void DrawTownAttackGun(ref Texture2D item, ref Rectangle itemFrame, ref float scale, ref int horizontalHoldoutOffset)/* tModPorter Note: closeness is now horizontalHoldoutOffset, use 'horizontalHoldoutOffset = Main.DrawPlayerItemPos(1f, itemtype) - originalClosenessValue' to adjust to the change. See docs for how to use hook with an item type. */ //Allows you to customize how this town NPC's weapon is drawn when this NPC is shooting (this NPC must have an attack type of 1). 
        {
            if (Main.snowMoon)
            {
                int itemType = ModContent.ItemType<RubyStaffTier1>();
                Main.GetItemDrawFrame(itemType, out item, out itemFrame);
                horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 20;
            }
            if (Main.hardMode)
            {
                int itemType = ModContent.ItemType<DiamondStaffTier2>();
                Main.GetItemDrawFrame(itemType, out item, out itemFrame);
                horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 20;
            }
            else
            {
                // If using an existing item, use this approach
                int itemType = ModContent.ItemType<DiamondStaffTier1>();
                Main.GetItemDrawFrame(itemType, out item, out itemFrame);
                horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 20;
            }
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (Main.snowMoon)
            {
                projType = ModContent.ProjectileType<RubyBoltTier1>();
                attackDelay = 1;
            }
            if (Main.hardMode)
            {
                projType = ModContent.ProjectileType<DiamondBoltTier2>();
                attackDelay = 1;
            }
            else
            {
                projType = ModContent.ProjectileType<DiamondBoltTier1>();
                attackDelay = 1;
            }
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
            gravityCorrection = 0f;
            randomOffset = 2f;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.WizardHat, 10)); // Drop a stack of 5 to 15 items with 1 in 2 chance (50% chance)
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
                Gore.NewGore(NPC.GetSource_Death(), NPC.position + new Vector2(0, 20), NPC.velocity, legGore);
            }
        }
    }
}