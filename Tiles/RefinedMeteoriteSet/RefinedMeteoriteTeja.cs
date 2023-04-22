using TheCollectors.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

using Microsoft.Xna.Framework.Graphics;


namespace TheCollectors.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteTeja : ModTile
	{
		public override void SetStaticDefaults()
	{
		Main.tileLighted[Type] = true;
		Main.tileSolid[Type] = true;
		AddMapEntry(new Color(22, 19, 28));
		ItemDrop = ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteTeja>();
	}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			//Texture2D texture;
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
		}
	}
}