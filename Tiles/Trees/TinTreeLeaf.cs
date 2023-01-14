using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.GameContent.Metadata;
using static Terraria.ModLoader.ModContent;


namespace TheCollectors.Tiles.Trees
{
    class TinTreeLeaf : ModGore
	{
		public override string Texture => "TheCollectors/Tiles/Trees/TinTreeLeaf";

		public override void SetStaticDefaults()
		{

			GoreID.Sets.SpecialAI[Type] = 3;
		}
	}
}