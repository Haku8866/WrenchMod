using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WrenchMod.Items
{
    public class LightWrench : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Places invisible light sources using wire. They can be broken with a pickaxe and will become visible when activated with a wire.");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.maxStack = 1;
            Item.value = 100;
            Item.rare = 2;
            Item.useStyle = 1;
            Item.autoReuse = true;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.mech = true;
            Item.tileBoost = 50;
            Item.consumable = false;
            Item.createTile = Mod.Find<ModTile>("LightWire").Type;
            Item.tileWand = ItemID.Wire;

        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
            }
            else
            {
                for (int d = 0; d < 20; d++)
                {
                    int dustType = DustID.PlatinumCoin;
                    Dust.NewDust(new Vector2((int)Main.MouseWorld.X, (int)Main.MouseWorld.Y), 16, 16, dustType);
                }
            }
            return base.CanUseItem(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MulticolorWrench);
            recipe.AddIngredient(ItemID.DiamondGemsparkBlock, 50);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}