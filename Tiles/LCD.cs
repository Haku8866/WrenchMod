using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace WrenchMod.Tiles
{
    public class LCD : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileNoAttach[Type] = false;
            Main.tileNoFail[Type] = true;
            Main.tileWaterDeath[Type] = false;
            Main.tileLavaDeath[Type] = false;
            Main.tileSpelunker[Type] = true;
            DustType = DustID.Blood;
            TileObjectData.newTile.FullCopyFrom(TileID.LogicGate);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16};
            TileObjectData.newTile.Height = 2;
            TileObjectData.addTile(Type);
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ItemType<Items.LCD>());
        }
        public override void HitWire(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            int adjust = 0;
            if (Framing.GetTileSafely(i, j+1).TileType == (ushort)TileType<LCD>() && Framing.GetTileSafely(i, j+1).HasTile)
            {
                Wiring.SkipWire(i, j + 1);
                adjust += 1;
            }
            else
            {
                Wiring.SkipWire(i, j - 1);
                adjust -= 1;
            }
            switch (Wiring._currentWireColor)
            {
                case 1:
                    if (tile.TileFrameX == 0 || tile.TileFrameX == 36 || tile.TileFrameX == 72 || tile.TileFrameX == 108 || tile.TileFrameX == 144 || tile.TileFrameX == 180 || tile.TileFrameX == 216 || tile.TileFrameX == 252)
                    {
                        Framing.GetTileSafely(i, j).TileFrameX += 18;
                        Framing.GetTileSafely(i, j + adjust).TileFrameX += 18;
                    } else
                    {
                        Framing.GetTileSafely(i, j).TileFrameX -= 18;
                        Framing.GetTileSafely(i, j + adjust).TileFrameX -= 18;
                    }
                    break;
                case 2:
                    if (tile.TileFrameX == 0 || tile.TileFrameX == 18 || tile.TileFrameX == 72 || tile.TileFrameX == 90 || tile.TileFrameX == 144 || tile.TileFrameX == 162 || tile.TileFrameX == 216 || tile.TileFrameX == 234)
                    {
                        Framing.GetTileSafely(i, j).TileFrameX += 36;
                        Framing.GetTileSafely(i, j + adjust).TileFrameX += 36;
                    }
                    else
                    {
                        Framing.GetTileSafely(i, j).TileFrameX -= 36;
                        Framing.GetTileSafely(i, j + adjust).TileFrameX -= 36;
                    }
                    break;
                case 3:
                    if (tile.TileFrameX == 0 || tile.TileFrameX == 18 || tile.TileFrameX == 36 || tile.TileFrameX == 54 || tile.TileFrameX == 144 || tile.TileFrameX == 162 || tile.TileFrameX == 180 || tile.TileFrameX == 198)
                    {
                        Framing.GetTileSafely(i, j).TileFrameX += 72;
                        Framing.GetTileSafely(i, j + adjust).TileFrameX += 72;
                    }
                    else
                    {
                        Framing.GetTileSafely(i, j).TileFrameX -= 72;
                        Framing.GetTileSafely(i, j + adjust).TileFrameX -= 72;
                    }
                    break;
                default:
                    if (tile.TileFrameX < 144)
                    {
                        Framing.GetTileSafely(i, j).TileFrameX += 144;
                        Framing.GetTileSafely(i, j + adjust).TileFrameX += 144;
                    }
                    else
                    {
                        Framing.GetTileSafely(i, j).TileFrameX -= 144;
                        Framing.GetTileSafely(i, j + adjust).TileFrameX -= 144;
                    }
                    break;
            }
        }
    }
}