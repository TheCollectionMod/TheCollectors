using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using Terraria.GameContent.Achievements;
using static Terraria.Player;

namespace TheCollectors
{
	// ModPlayer classes provide a way to attach data to Players and act on that data. TheCollectionModPlayer has a lot of functionality related to 
	// several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class TheCollectorsPlayer : ModPlayer
	{
        public bool MyLightPet;
        public bool LivingSpaceRock;
        public bool FlyingEyeling;
        public bool FireHealing;
        public bool FakeCrystalLeafSet = false;
        public bool fullGraniteSet = false;
        public bool geodePickaxe = false;
        public bool oysterRake = false;
        public bool copptinPolish = false;
        public bool PolishArmor = false;

        public static TheCollectorsPlayer Get(Player player, Mod mod)
        {
            return player.GetModPlayer<TheCollectorsPlayer>();
        }

        public override void Initialize()
        {

        }

        public override void ResetEffects()
        {
            //MinionSandSlime = false;
            fullGraniteSet = false;
            MyLightPet = false;
            LivingSpaceRock = false;
            FlyingEyeling = false;
            FireHealing = false;
            FakeCrystalLeafSet = false;
            geodePickaxe = false;
            oysterRake = false;
            copptinPolish = false;
        }
        public bool LeafCrystalEffectActive { get; set; }
        private int leafCrystalEffectTimer;

        public void ApplyLeafCrystalEffect()
        {
            LeafCrystalEffectActive = true;
            leafCrystalEffectTimer = 600;
        }

        public override void PostUpdate()
        {
            if (Player.talkNPC == -1)
            {
                PolishArmor = false;
            }
            else
            {
                int num = Math.Sign(Main.npc[Player.talkNPC].Center.X - Player.Center.X);
                if (Player.controlLeft || Player.controlRight || Player.controlUp || Player.controlDown || Player.controlJump || Player.pulley || Player.mount.Active || num != Player.direction)
                {
                    PolishArmor = false;
                }

            }
            if (PolishArmor)
            {
                int timer = Player.miscCounter % 14 / 7;
                CompositeArmStretchAmount stretch = CompositeArmStretchAmount.ThreeQuarters;
                if (timer == 1)
                {
                    stretch = CompositeArmStretchAmount.Full;
                }
                Player.SetCompositeArmBack(enabled: true, stretch, (float)Math.PI * -0.2f * (float)Player.direction);
            }

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
                    // Apply the effect here, for example:
                    Player.AddBuff(BuffID.LeafCrystal, 2);
                }
            }
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
    }
}
