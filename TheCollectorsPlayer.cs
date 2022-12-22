using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;

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
        }
    }
}
