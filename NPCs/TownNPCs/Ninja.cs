using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Events;
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
using TheCollectors.Projectiles.Throwing;

namespace TheCollectors.NPCs.TownNPCs
{
    public class NinjaProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();
        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)

                return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Ninja");

            if (npc.altTexture == 1)

                return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Ninja_Party");

            return ModContent.Request<Texture2D>("TheCollectors/NPCs/TownNPCs/Ninja");
        }
        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("TheCollectors/NPCs/TownNPCs/Ninja_Head");
    }
    [AutoloadHead]

    public class Ninja : ModNPC
    {
        public override ITownNPCProfile TownNPCProfile()
        {
            return new NinjaProfile();
        }
        public override string Texture => "TheCollectors/NPCs/TownNPCs/Ninja";
        public int NumberOfTimesTalkedTo = 0;
        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Saske",
                "Furamuros",
                "Smooth Figure",
                "Hattori",
                "Boninja"
            };
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ninja");
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 1000;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4; // Posición del Party Hat

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = -1
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
            //.SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
            .SetBiomeAffection<ForestBiome>(AffectionLevel.Like)
            .SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
            .SetBiomeAffection<HallowBiome>(AffectionLevel.Hate)
            .SetNPCAffection(NPCID.Guide, AffectionLevel.Love);
            //.SetNPCAffection(ModContent.NPCType<MasterSan>(), AffectionLevel.Like) // Para los NPCs del mod
            //.SetNPCAffection(ModContent.NPCType<QueenSlime>(), AffectionLevel.Dislike) // Ver como hacer Call al mod bosses as NPC
            //.SetNPCAffection(ModContent.NPCType<KingSlime>(), AffectionLevel.Hate); // Ver como hacer Call al mod bosses as NPC
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
            AnimationType = NPCID.Guide;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("Mods.TheCollectors.Bestiary.Ninja")
            });
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedSlimeKing)
            {
              return true;
            }
            return false;
        }
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "¡Battle Changue!";
        }
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true; // Esto lo convierte en tienda
            }
            else
            {
                Main.npcChatText = Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.BattleChangue");
                Main.LocalPlayer.AddBuff(ModContent.BuffType<Buffs.StealthBuff>(),36000); /*600 = 10seg*/
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.Katana); nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.Shuriken); nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.NinjaHood); nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.NinjaPants); nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.NinjaShirt); nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.InvisibilityPotion); nextSlot++;
            shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Placeable.ThrowingDummy>()); nextSlot++;

            // Bosses y eventos, items permanentes
            if (NPC.downedGoblins) // Goblins invasion
            {
                shop.item[nextSlot].SetDefaults(ItemID.SpikyBall); nextSlot++;
            }

            if (NPC.downedSlimeKing)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Throwing.SlimeShuriken>()); nextSlot++;
            } //este NPC Spawnea al matar al king slime, redundante

            if (NPC.downedBoss1) //Eye of Cthulhu
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Throwing.EyeShuriken>()); nextSlot++;
            }

            if (NPC.downedBoss2) // Eater of Worlds OR the Brain of Cthulhu 
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Throwing.WormShuriken>()); nextSlot++;
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Throwing.BrainShuriken>()); nextSlot++;
            }

            if (NPC.downedQueenBee) //Queen Bee
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Throwing.BeeShuriken>()); nextSlot++;
            }

            if (NPC.downedBoss3) //Skeletron
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Throwing.BoneShuriken>()); nextSlot++;
            }

            if (NPC.downedDeerclops) //Deerclops
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Throwing.DeerShuriken>()); nextSlot++;
            }

            if (Main.hardMode) // = defeat Wall of Flesh
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Throwing.WallShuriken>()); nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.PoisonedKnife); nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.Muramasa); nextSlot++;
            }
            if (BirthdayParty.PartyIsUp) // fiesta activa
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<Items.Weapons.Throwing.PartyShuriken>()); nextSlot++;
            }

            // Weather y eventos temporales
            /*if (Main.IsItRaining) // dia de lluvia?
            {
                shop.item[nextSlot].SetDefaults(ItemID.PoisonedKnife); nextSlot++;
            }

            if (Main.IsItAHappyWindyDay) // dia de viento?
            {
                shop.item[nextSlot].SetDefaults(ItemID.PoisonedKnife); nextSlot++;
            }

            if (Main.IsItStorming) // dia de tormenta?
            {
                shop.item[nextSlot].SetDefaults(ItemID.PoisonedKnife); nextSlot++;
            }

            if (Main.bloodMoon) // durante blood moon
            {
                shop.item[nextSlot].SetDefaults(ItemID.PoisonedKnife); nextSlot++;
            }

            if (Main.slimeRain) // durante lluvia de slimes
            {
                shop.item[nextSlot].SetDefaults(ItemID.PoisonedKnife); nextSlot++;
            }*/
        }
        public override string GetChat()
        {
            NumberOfTimesTalkedTo++;
            switch (Main.rand.Next(4))
            {
                case 0:
                    {
                        switch (Main.rand.Next(5))
                        {
                            case 0:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.StandardDialogue1");
                            case 1:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.StandardDialogue2");
                            case 2:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.StandardDialogue3");
                            case 3:
                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.StandardDialogue4");
                            case 4:
                                if (NumberOfTimesTalkedTo >= 20)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.TalkALot");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.NotTalkALot");
                        }
                    }
                    return null;
                case 1:
                    {
                        int guide = NPC.FindFirstNPC(NPCID.Guide);
                        int partygirl = NPC.FindFirstNPC(NPCID.PartyGirl);
                        //int mastersan = NPC.FindFirstNPC(ModContent.NPCType<MasterSan>());

                            switch (Main.rand.Next(2))
                        {
                            case 0:
                                if (guide >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.Guide1", Main.npc[guide].GivenName);
                                }
                                else return null;

                            case 1:
                                if (partygirl >= 0)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.PartyGirl1", Main.npc[partygirl].GivenName);
                                }
                                else return null;
                        }
                    }
                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.OtrosNPCs");
                case 2:
                    {
                        switch (Main.invasionType)  // (Main.invasionType == X)	GoblinArmy (1), FrostLegion (2), Pirates (3), MartianMadness (4), (Main.eclipse)
                        {
                            case 1:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvasionGenerica");
                            case 2:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvasionGenerica");
                            case 3:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvasionGenerica");
                            case 4:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.InvasionGenerica");
                            default:

                                return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.NotInvansionGenerica");
                        }
                    }
                case 3:
                    {
                        switch (Main.rand.Next(2))
                        {
                            case 0:
                                if (NPC.downedQueenSlime)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.QueenSlime2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.QueenSlime1");
                            case 1:
                                if (Main.slimeRain)
                                {
                                    return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.SlimeRain2");
                                }
                                else return Language.GetTextValue("Mods.TheCollectors.Dialogue.Ninja.SlimeRain1");
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
            if (Main.hardMode)
            {
                projType = ModContent.ProjectileType<WallShuriken>();
                attackDelay = 1;
            }
            else
            {
                projType = ModContent.ProjectileType<GoldShuriken>();
                attackDelay = 1;
            }

            if (Main.snowMoon)
            {
                projType = ModContent.ProjectileType<HellstoneShuriken>();
                attackDelay = 1;
            }
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 30f;
            gravityCorrection = 0f;
            randomOffset = 2f;
        }
        public override void HitEffect(int hitDirection, double damage) //cambiar los gores a troncos
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 8; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Smoke, 2.5f * hitDirection, -2.5f, Scale: 0.8f);
                }

                if (!Main.dedServ)
                {
                    Vector2 pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/NinjaGore3").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/NinjaGore2").Type);

                    pos = NPC.position + new Vector2(Main.rand.Next(NPC.width - 8), Main.rand.Next(NPC.height / 2));
                    Gore.NewGore(NPC.GetSource_Death(), pos, NPC.velocity, ModContent.Find<ModGore>("TheCollectors/NinjaGore1").Type);
                }
            }
            else
            {
                for (int k = 0; k < damage / NPC.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Blood, hitDirection, -1f, Scale: 0.6f);
                }
            }
        }
       /* public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Armor.Vanity.MeteormanMask>(), 10)); //poner revista erotica, con chat especial si la tienes en el inventario, la pierdes
        }
        public override void OnKill() // hacer un ruido tipo tecnica de los troncos
        {
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.GoldBow, 1, false, 0, false, false); 
        }*/
    }
}