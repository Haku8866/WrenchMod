using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using ReLogic.Content;

namespace WrenchMod.Tiles
{
    public class LightWire : ModTile
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
            DustType = DustID.PlatinumCoin;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.FullCopyFrom(TileID.LogicSensor);
            TileObjectData.addTile(Type);
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 1.5f;
            g = 1.5f;
            b = 1.5f;
        }
        public override void HitWire(int i, int j)
        {
            Main.tile[i, j].TileFrameX += 18;
            if (Main.tile[i, j].TileFrameX > 18)
            {
                Main.tile[i, j].TileFrameX = 0;
            }
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i);
            Color color = new Color(100, 100, 100, 0);
            int frameX = Main.tile[i, j].TileFrameX;
            int frameY = Main.tile[i, j].TileFrameY;
            int width = 20;
            int offsetY = 0;
            int height = 20;
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            for (int k = 0; k < 7; k++)
            {
                float x = (float)Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                float y = (float)Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("WrenchMod/Tiles/Flame").Value, new Vector2((float)(i * 16 - (int)Main.screenPosition.X) - (width - 16f) / 2f + x, (float)(j * 16 - (int)Main.screenPosition.Y + offsetY) + y) + zero, new Rectangle(frameX, frameY, width, height), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            }
        }
    }
}