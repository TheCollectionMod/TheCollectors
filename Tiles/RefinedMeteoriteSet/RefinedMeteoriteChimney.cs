using TheCollectors.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheCollectors.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteChimney : ModTile
	{
        public override void SetStaticDefaults()
		{
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16, 18 };
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<RefinedMeteoriteChimneyTE>().Hook_AfterPlacement, -1, 0, false);
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
            name.SetDefault("Chimmey");
			AddMapEntry(new Color(179, 146, 107), name);
			AnimationFrameHeight = 56;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Terraria.Item.NewItem(new Terraria.DataStructures.EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 48, ModContent.ItemType<Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteChimney>());
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Main.SceneMetrics.HasCampfire = true;
            }
        }
		//Don't animate if deactivated
		public override void AnimateIndividualTile(int type, int i, int j, ref int TileFrameXOffset, ref int TileFrameYOffset)
		{
			//Top left tile
			int x = i - Main.tile[i, j].TileFrameX / 18;
			int y = j - Main.tile[i, j].TileFrameY % AnimationFrameHeight / 18;
			try
			{
				var tileEntity = (RefinedMeteoriteChimneyTE)TileEntity.ByPosition[new Point16(x, y)];
				if (tileEntity.CurrentState == RefinedMeteoriteChimneyTE.State.Deactivated)
				{
					TileFrameYOffset = AnimationFrameHeight * 6;
				}
            }
			catch { }
		}

		public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			frame = (Main.tileFrame[TileID.Chimney] + 4) % 6;
		}

		public override void HitWire(int i, int j)
		{
			//Top left tile
			int x = i - Main.tile[i, j].TileFrameX / 18;
			int y = j - Main.tile[i, j].TileFrameY % AnimationFrameHeight / 18;

			Wiring.SkipWire(x, y);
			Wiring.SkipWire(x, y + 1);
			Wiring.SkipWire(x, y + 2);
			Wiring.SkipWire(x + 1, y);
			Wiring.SkipWire(x + 1, y + 1);
			Wiring.SkipWire(x + 1, y + 2);
			Wiring.SkipWire(x + 2, y);
			Wiring.SkipWire(x + 2, y + 1);
			Wiring.SkipWire(x + 2, y + 2);

			try
			{
				var tileEntity = (RefinedMeteoriteChimneyTE)TileEntity.ByPosition[new Point16(x, y)];
				tileEntity.CurrentState = tileEntity.CurrentState.NextEnum();
				NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, tileEntity.ID, x, y);
			}
			catch { }
		}
	}
}