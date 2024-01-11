using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Achievements;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.Player;
using TheCollectors.Content.Achievements;
using TheCollectors.Content.Items.NPCStash.McMoneyPants;

namespace TheCollectors
{
    // ModPlayer classes provide a way to attach data to Players and act on that data. TheCollectionModPlayer has a lot of functionality related to 
    // several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
    public class TheCollectorsPlayer : ModPlayer
    {
        // Pets
        public bool MyLightPet;
        public bool LivingSpaceRock;
        public bool FlyingEyeling;

        // Armor, Weapons And SetEffects
        public bool MeteorbodyBuff;
        public bool FakeCrystalLeafSet;

        // FutureFeatures
        public bool geodePickaxe;
        public bool oysterRake;
        public bool MinionSandSlime;
        public bool PolishArmor;

        // LeafCrystalEffect
        public bool LeafCrystalEffectActive;
        public int leafCrystalEffectTimer;

        // Achievements
        // (TerraCoin logic handled in PostUpdate)

        // Museum Donation System
        private HashSet<int> donatedStatues = new HashSet<int>();
        private HashSet<int> donatedPaintings = new HashSet<int>();
        private int totalDonations;

        public static TheCollectorsPlayer Get(Player player, Mod mod)
        {
            return player.GetModPlayer<TheCollectorsPlayer>();
        }

        public override void Initialize()
        {

        }
        public override void ResetEffects()
        {
            // ACTIVE PETS
            MyLightPet = false;
            LivingSpaceRock = false;
            FlyingEyeling = false;

            // ARMOR / SET EFFECTS
            MeteorbodyBuff = false;

            // FUTURE FEATURES
            geodePickaxe = false;
            oysterRake = false;
            //MinionSandSlime = false;

            // DO NOT RESET:
            // FakeCrystalLeafSet → persists until HP > 50%
            // PolishArmor → persists until animation logic ends
        }

        public void ApplyLeafCrystalEffect()
         {
             LeafCrystalEffectActive = true;
             leafCrystalEffectTimer = 600;
         }
        public override void PostUpdateEquips()
        {
            if (MeteorbodyBuff)
            {
                Player.statDefense += 20;
            }
        }
        public override void PostUpdate()
        {
            // PolishArmorInteraction
            if (Player.talkNPC == -1)
            {
                PolishArmor = false;
            }
            else
            {
                int dir = Math.Sign(Main.npc[Player.talkNPC].Center.X - Player.Center.X);

                if (Player.controlLeft || Player.controlRight || Player.controlUp || Player.controlDown || Player.controlJump || Player.pulley || Player.mount.Active || dir != Player.direction)
                {
                    PolishArmor = false;
                }
            }

            if (PolishArmor)
            {
                int timer = Player.miscCounter % 14 / 7;
                CompositeArmStretchAmount stretch = CompositeArmStretchAmount.ThreeQuarters;

                if (timer == 1)
                    stretch = CompositeArmStretchAmount.Full;

                Player.SetCompositeArmBack(true, stretch, (float)Math.PI * -0.2f * Player.direction);
            }
            else
            {
                Player.SetCompositeArmBack(false, CompositeArmStretchAmount.None, 0f);
            }

            // LeafCrystalEffect
            if (LeafCrystalEffectActive)
            {
                leafCrystalEffectTimer--;

                if (leafCrystalEffectTimer <= 0)
                {
                    LeafCrystalEffectActive = false;
                    leafCrystalEffectTimer = 0;
                }
                else
                {
                    Player.AddBuff(BuffID.LeafCrystal, 2);
                }
            }

           /* // Achievements — TerraCoin
            if (Player.whoAmI == Main.myPlayer)
            {
                if (GachaCoinAchievement.TerraCoinPickupCondition != null && GachaCoinAchievement.TerraCoinPickupCondition.IsCompleted)
                {
                    return;
                }

                int totalCoins = 0;

                foreach (Item item in Player.inventory)
                {
                    if (!item.IsAir && item.type == ModContent.ItemType<TerraCoin>())
                    {
                        totalCoins += item.stack;
                    }
                }

                if (GachaCoinAchievement.TerraCoinPickupCondition != null)
                {
                    GachaCoinAchievement.TerraCoinPickupCondition.Value = totalCoins;
                }
            }*/
        }
        public void PetAnimal(int animalNpcIndex)
        {
            var npc = Main.npc[animalNpcIndex];

            var targetDirection = ((npc.Center.X > Player.Center.X) ? 1 : (-1));
            var playerPositionWhenPetting = npc.Bottom + new Vector2(-targetDirection * 25, 0);
            playerPositionWhenPetting = playerPositionWhenPetting.Floor();
            Vector2 offset = playerPositionWhenPetting - Player.Bottom;

            bool flag = Player.CanSnapToPosition(offset);
            if (flag && !WorldGen.SolidTileAllowBottomSlope((int)playerPositionWhenPetting.X / 16, (int)playerPositionWhenPetting.Y / 16))
            {
                flag = false;
            }
            if (!flag)
            {
                return;
            }
            if (PolishArmor && Player.Bottom == playerPositionWhenPetting)
            {
                PolishArmor = false;
                return;
            }
            Player.StopVanityActions();
            Player.RemoveAllGrapplingHooks();
            if (Player.mount.Active)
            {
                Player.mount.Dismount(Player);
            }
            Player.Bottom = playerPositionWhenPetting;
            Player.ChangeDir(targetDirection);
            PolishArmor = true;
            Player.isTheAnimalBeingPetSmall = true;
            Player.velocity = Vector2.Zero;
            Player.gravDir = 1f;
            npc.direction = targetDirection;
            npc.spriteDirection = targetDirection;
            if (Player.whoAmI == Main.myPlayer)
            {
                AchievementsHelper.HandleSpecialEvent(Player, 21);
            }
        }

        // Museum Donation System — Public API

        public bool AddStatue(int id)
        {
            bool added = donatedStatues.Add(id);
            if (added)
                totalDonations++;
            return added;
        }

        public bool AddPainting(int id)
        {
            bool added = donatedPaintings.Add(id);
            if (added)
                totalDonations++;
            return added;
        }

        public bool HasStatue(int id) => donatedStatues.Contains(id);
        public bool HasPainting(int id) => donatedPaintings.Contains(id);
        public int GetTotalDonations() => totalDonations;

        // Museum Donation System — Save / Load

        public override void SaveData(TagCompound tag)
        {
            if (donatedStatues.Count > 0)
                tag["donatedStatues"] = new List<int>(donatedStatues);

            if (donatedPaintings.Count > 0)
                tag["donatedPaintings"] = new List<int>(donatedPaintings);

            tag["totalDonations"] = totalDonations;
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("donatedStatues"))
                donatedStatues = new HashSet<int>(tag.GetList<int>("donatedStatues"));
            else
                donatedStatues.Clear();

            if (tag.ContainsKey("donatedPaintings"))
                donatedPaintings = new HashSet<int>(tag.GetList<int>("donatedPaintings"));
            else
                donatedPaintings.Clear();

            if (tag.ContainsKey("totalDonations"))
                totalDonations = tag.GetInt("totalDonations");
            else
                totalDonations = donatedStatues.Count + donatedPaintings.Count;
        }
    }
}