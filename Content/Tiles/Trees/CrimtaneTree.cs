using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using TheCollectors.Content.Items.NPCStash.Meteorman;

namespace TheCollectors.Content.Tiles.Trees
{
    public class CrimtaneTree : ModTree
    {
        private Asset<Texture2D> texture;
        private Asset<Texture2D> branchesTexture;
        private Asset<Texture2D> topsTexture;
        public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
        {
            UseSpecialGroups = true,
            SpecialGroupMinimalHueValue = 11f / 72f,
            SpecialGroupMaximumHueValue = 0.25f,
            SpecialGroupMinimumSaturationValue = 0.88f,
            SpecialGroupMaximumSaturationValue = 1f
        };
        public override void SetStaticDefaults()
        {
            GrowsOnTileId = [ModContent.TileType<CrimtaneSoilTile>()];
            texture = ModContent.Request<Texture2D>("TheCollectors/Content/Tiles/Trees/CrimtaneTree");
            branchesTexture = ModContent.Request<Texture2D>("TheCollectors/Content/Tiles/Trees/CrimtaneTree_Branches");
            topsTexture = ModContent.Request<Texture2D>("TheCollectors/Content/Tiles/Trees/CrimtaneTree_Tops");
        }
        public override Asset<Texture2D> GetTexture()
        {
            return texture;
        }
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<CrimtaneTreeSapling>();
        }
        public override void SetTreeFoliageSettings(int i, int j, Tile tile, int xoffset, ref int treeFrame, int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {
            // This is where fancy code could go, but let's save that for an advanced example
        }
        public override Asset<Texture2D> GetBranchTextures() => branchesTexture;
        public override Asset<Texture2D> GetTopTextures() => topsTexture;
        public override int DropWood()
        {
            return ItemID.CrimtaneOre;
        }
        public override bool Shake(int x, int y, ref bool createLeaves)
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16, ItemID.Acorn);
                    break;

                case 1:
                    Item.NewItem(WorldGen.GetItemSource_FromTreeShake(x, y), new Vector2(x, y) * 16, ModContent.ItemType<Items.Consumables.Food.CrimtaneFruit>());
                    break;

                default:
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        NPC.NewNPC(WorldGen.GetItemSource_FromTreeShake(x, y), x * 16, y * 16, ModContent.NPCType<NPCs.Critters.CrimtaneSquirrel>());
                    }
                    break;
            }
            return false;
        }
        public override int TreeLeaf()
        {
            return ModContent.GoreType<CrimtaneTreeLeaf>();
        }
    }
}