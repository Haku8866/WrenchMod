using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WrenchMod.Items
{
    public class FrameWrench : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Activates components, doesn't interfere with wires!\n(Does not work with gemspark blocks as they're processed differently)");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.maxStack = 1;
            Item.value = 100;
            Item.rare = 2;
            Item.useStyle = ItemUseStyleID.Guitar;
            Item.autoReuse = false;
            Item.mech = false;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.tileBoost = 50;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Tile target = Framing.GetTileSafely((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
                target.TileFrameX -= 18;
            }
            else
            {
                Tile target = Framing.GetTileSafely((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
                target.TileFrameX += 18;
            }
            return base.CanUseItem(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MulticolorWrench);
            recipe.AddIngredient(ItemID.Timer1Second);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}