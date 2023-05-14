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
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.IO;
using System;
using TheCollectors.Content.Projectiles.Magic;
using TheCollectors.Content.Items.Weapons.Magic;
using static Terraria.ModLoader.ModContent;
using TheCollectors.Content.Dusts;

namespace TheCollectors.Content.NPCs.TownNPCs
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class Archeologist : ModNPC
    {
        public const string ShopName = "Shop";
        private static bool LoreNPCs;
        private static bool LoreBosses;
        private static int tiendaNum = 1;
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
                "Dr. Jones",
                "Indy",
                "Capitán Dinamita",
                "Jonesy",
                "Mungo Kidogo"
            };
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 26;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 6;
            NPCID.Sets.DangerDetectRange[NPC.type] = 100;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 10;
            NPCID.Sets.AttackAverageChance[NPC.type] = 10;
            NPCID.Sets.HatOffsetY[NPC.type] = -7;           // For when a party is active, the party hat spawns at a Y offset.

            NPCID.Sets.ShimmerTownTransform[Type] = true; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,  // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = -1  // -1 is left and 1 is right. NPCs are drawn facing the left by default.
                                // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                                // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
            .SetBiomeAffection<JungleBiome>(AffectionLevel.Love)
            .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
            .SetBiomeAffection<HallowBiome>(AffectionLevel.Dislike)
            .SetBiomeAffection<SnowBiome>(AffectionLevel.Hate)
            .SetNPCAffection(NPCID.Dryad, AffectionLevel.Love)
            .SetNPCAffection(NPCID.BestiaryGirl, AffectionLevel.Like)
            .SetNPCAffection(NPCID.Guide, AffectionLevel.Dislike)
            .SetNPCAffection(ModContent.NPCType<Ninja>(), AffectionLevel.Dislike) // Para los NPCs del mod
            .SetNPCAffection(NPCID.WitchDoctor, AffectionLevel.Hate);
            //Princess is automatically set

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
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Jungle,
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.Archeologist")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemID.RopeCoil)
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

                Dust.NewDustPerfect(NPC.Center + position, ModContent.DustType<Sparkle>(), Vector2.Zero).noGravity = true;
            }
        }
        public override void SetChatButtons(ref string button, ref string button2)  // What the chat buttons are when you open up the chat UI
        {
            switch (tiendaNum)
            {
                case 1:
                    button = Language.GetTextValue("LegacyInterface.28");
                    break;

                case 2:
                    button = "Lore - Ciudadanos";
                    break;

                default:
                    button = "Lore - Jefes";
                    break;
            }

            button2 = "Cambiar botón";
                 
           if (tiendaNum >= 4)
           {
               tiendaNum = 1;
           }

        }
        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName;
                switch (tiendaNum)
                {
                    case 1:
                        LoreNPCs = true;
                        LoreBosses = false;
                        break;
                    case 2:
                        LoreNPCs = false;
                        LoreBosses = true;
                        break;
                    case 3:
                        LoreNPCs = false;
                        LoreBosses = false;
                        break;
                }
            }
            else if (!firstButton)
            {
                tiendaNum++;
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
            if (LoreNPCs)
            {
                Main.npcChatText = Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.LoreNPCs");
            }
            else if (LoreBosses)
            {
                Main.npcChatText = Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.LoreBosses");
            }
            else if (!LoreBosses && !LoreNPCs)
            {
                var npcShop = new NPCShop(Type, ShopName)
                .Add(ItemID.Torch)
                .Add(ItemID.Rope)
                .Add(ItemID.RopeCoil)
                .Add(ItemID.Bomb)
                .Add(ItemID.GrapplingHook)
                .Add(ItemID.Boomstick)
                .Add(ItemID.MusketBall)
                .Add(ItemID.ChainKnife)
                .Add(ItemID.DyeTradersScimitar, Condition.Hardmode)
                .Add(ItemID.SilverBullet, Condition.BloodMoon);
                npcShop.Register(); // Name of this shop tab
            }
        }
        public override string GetChat()
        {
            NumberOfTimesTalkedTo++;
            switch (Main.rand.Next(5))
            {
                case 0:
                    {
                        switch (Main.rand.Next(7))
                        {
                            case 0:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.StandardDialogue1");
                            case 1:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.StandardDialogue2");
                            case 2:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.StandardDialogue3");
                            case 3:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.StandardDialogue4");
                            case 4:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.StandardDialogue5");
                            case 5:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.InfoLore");
                            case 6:
                                if (NumberOfTimesTalkedTo >= 20)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.TalkALot");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.NotTalkALot");
                        }
                    }
                    return null;
                case 1:
                    {
                        int dryad = NPC.FindFirstNPC(NPCID.Dryad);
                        int bestiarygirl = NPC.FindFirstNPC(NPCID.BestiaryGirl);
                        int guide = NPC.FindFirstNPC(NPCID.Guide);
                        int witchdoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
                        int ninja = NPC.FindFirstNPC(ModContent.NPCType <Ninja>());

                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                if (dryad >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Dryad", Main.npc[dryad].GivenName);
                                }
                                else return null;
                            case 1:
                                if (bestiarygirl >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.BestiaryGirl", Main.npc[bestiarygirl].GivenName);
                                }
                                else return null;
                            case 2:
                                if (guide >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Guide", Main.npc[guide].GivenName);
                                }
                                else return null;
                            case 3:
                                if (witchdoctor >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.WitchDoctor", Main.npc[witchdoctor].GivenName);
                                }
                                else return null;
                            case 4:
                                if (ninja >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Ninja", Main.npc[ninja].GivenName);
                                }
                                else return null;
                        }
                    }
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.FaltanNPCs");
                case 2:
                    {
                        switch (Main.invasionType)  // (Main.invasionType == X)	GoblinArmy (1), FrostLegion (2), Pirates (3), MartianMadness (4)
                        {
                            case 1:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.GoblinInvasion");
                            case 2:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.FrostLegionInvasion");
                            case 3:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.PiratesInvansion");
                            case 4:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.MartianInvansion");
                            default:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.NotInvasion");
                        }
                    }
                case 3:
                    {
                        switch (Main.rand.Next(7))
                        {
                            case 0:
                                if (NPC.downedSlimeKing)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.SlimeKing2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.SlimeKing1");
                            case 1:
                                if (NPC.downedBoss1)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.EyeofCthulhu2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.EyeofCthulhu1");
                            case 2:
                                if (NPC.downedBoss2)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.BrainWorm2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.BrainWorm1");
                            case 3:
                                if (NPC.downedQueenBee)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.QueenBee2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.QueenBee1");
                            case 4:
                                if (NPC.downedBoss3)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Skeletron2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Skeletron1");
                            case 5:
                                if (NPC.downedDeerclops)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Deerclops2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Deerclops1");
                            case 6:
                                if (Main.hardMode)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Wall2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Wall1");
                            default:
                                if (Main.hardMode)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Hardmode");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.NotHardmode");
                        }
                    }

                case 4:
                    {
                        if (Main.hardMode) 
                        {
                            switch (Main.rand.Next(8))
                            {
                                case 0:
                                    if (NPC.downedMechBoss2)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Twins2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Twins1");
                                case 1:
                                    if (NPC.downedMechBoss1)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Destroyer2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Destroyer1");
                                case 2:
                                    if (NPC.downedMechBoss3)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.SkeletronPrime2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.SkeletronPrime1");
                                case 3:
                                    if (NPC.downedPlantBoss)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Plantera2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Plantera1");
                                case 4:
                                    if (NPC.downedGolemBoss)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Golem2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Golem1");
                                case 5:
                                    if (NPC.downedFishron)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Fishron2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Fishron1");
                                case 6:
                                    if (NPC.downedEmpressOfLight)
                                    {
                                        return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.EmpressOfLight2");
                                    }
                                    else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.EmpressOfLight1");
                                case 7:
                                    if (NPC.downedAncientCultist)
                                    {
                                        switch (Main.rand.Next(2))
                                        {
                                            case 0:
                                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.AncientCultist2");
                                            case 1:
                                                if (NPC.downedTowers)
                                                    switch (Main.rand.Next(2))
                                                    {
                                                        case 0:
                                                            return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Towers2");
                                                        case 1:
                                                            if (NPC.downedMoonlord)
                                                            {
                                                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Moonlord2");
                                                            }
                                                            else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Moonlord1");
                                                    }
                                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.Towers1");
                                        }
                                       return null;
                                    }
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.AncientCultist1");
                            }
                        }
                        else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Archeologist.NotHardmode");
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
            if (Main.hardMode)
            {
                int itemType = ItemID.FireWhip;
                Main.GetItemDrawFrame(itemType, out item, out itemFrame);
                horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 20;
            }
            if (Main.hardMode)
            {
                int itemType = ItemID.SwordWhip;
                Main.GetItemDrawFrame(itemType, out item, out itemFrame);
                horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 20;
            }
            else
            {
                // If using an existing item, use this approach
                int itemType = ItemID.BlandWhip;
                Main.GetItemDrawFrame(itemType, out item, out itemFrame);
                horizontalHoldoutOffset = (int)Main.DrawPlayerItemPos(1f, itemType).X - 20;
            }
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (Main.hardMode)
            {
                projType = ProjectileID.FireWhipProj;
                attackDelay = 1;
            }
            else
            {
                projType = ProjectileID.SwordWhip;
                attackDelay = 1;
            }

            if (Main.snowMoon)
            {
                projType = ProjectileID.BlandWhip;
                attackDelay = 1;
            }

            if (Main.bloodMoon)
            {
                projType = ProjectileID.BoneDagger;
                attackDelay = 1;
            }

            if (Main.pumpkinMoon)
            {
                projType = ProjectileID.MolotovCocktail;
                attackDelay = 1;
            }
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 7f;
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
          /*  // Chat Normal
            switch (Main.rand.Next(5))
            {
                case 0:
                    return "They had to be snakes ...";
                case 1:
                    if (NPC.downedPlantBoss)
                    {
                        return "That key has to be the one that opens the jungle temple.";
                    }
                    else
                    {
                        return "It is said that there is a hidden temple in the jungle.";
                    }

                case 2:
                    return "I wanted to use a whip, but it's not implemented yet ";
                case 3:
                    {
                        // Main.npcChatCornerItem shows a single item in the corner, like the Angler Quest chat.
                        Main.npcChatCornerItem = ItemID.EndlessMusketPouch;
                        return $"Hey, if you find a [i:{ItemID.EndlessMusketPouch}], I can upgrade it for you. 'Not yet implemented'";
                    }
                default: // Default is the default if no other case is true. In this case if random nu
                    return "Hello, I am an experienced archaeologist, I can provide very useful basic equipment.";*/