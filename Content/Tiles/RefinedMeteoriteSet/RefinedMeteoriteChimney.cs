using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace TheCollectors.Content.Tiles.RefinedMeteoriteSet
{
	public class RefinedMeteoriteChimney : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<RefinedMeteoriteChimneyTE>().Hook_AfterPlacement, -1, 0, false);
            TileObjectData.addTile(Type);
            AnimationFrameHeight = 56;
            // Etc
            AddMapEntry(new Color(191, 142, 111), CreateMapEntryName());
        }

        public override void KillMultiTile(int i, int j, int TileFrameX, int TileFrameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 48, ModContent.ItemType<Content.Items.Placeable.RefinedMeteoriteSet.RefinedMeteoriteChimney>());
            ModContent.GetInstance<RefinedMeteoriteChimneyTE>().Kill(i, j);
        }

        //Don't animate if deactivated
        public override void AnimateIndividualTile(int type, int i, int j, ref int TileFrameXOffset, ref int TileFrameYOffset)
        {
            //Top left tile
            int x = i - Main.tile[i, j].TileFrameX / 18;
            int y = j - Main.tile[i, j].TileFrameY % AnimationFrameHeight / 18;

            var tileEntity = (RefinedMeteoriteChimneyTE)TileEntity.ByPosition[new Point16(x, y)];
            if (tileEntity.CurrentState == RefinedMeteoriteChimneyTE.State.Deactivated)
            {
                TileFrameYOffset = AnimationFrameHeight * 7;
            }
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frame = (Main.tileFrame[TileID.Chimney] + 4) % 7;
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


            var tileEntity = (RefinedMeteoriteChimneyTE)TileEntity.ByPosition[new Point16(x, y)];
            tileEntity.CurrentState = tileEntity.CurrentState.NextEnum();
            NetMessage.SendData(MessageID.TileEntitySharing, -1, -1, null, tileEntity.ID, x, y);
        }
    }
}