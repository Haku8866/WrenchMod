using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace WrenchMod.Items
{
    public class SparkWrench : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Activates wires, no switches needed!");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.maxStack = 1;
            Item.value = 100;
            Item.rare = ItemRarityID.Master;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = false;
            Item.mech = true;
            Item.tileBoost = 50;
            Item.useTime = 1;
            Item.useAnimation = 20;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            Wiring.TripWire((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16, 1, 1);
            return true;
        }
        public override void AddRecipes() => CreateRecipe()
            .AddIngredient(ItemID.MulticolorWrench)
            .AddIngredient(ItemID.Timer1Second)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
    }
}