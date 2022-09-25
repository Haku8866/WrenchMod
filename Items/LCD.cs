﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WrenchMod.Items
{
    public class LCD : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A quick and easy 7-seg display!\n(Red=1, Blue=2, Green=4, Yellow=8)");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.maxStack = 999;
            Item.value = 100;
            Item.rare = ItemRarityID.White;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.mech = true;
            Item.tileBoost = 50;
            Item.consumable = true;
            Item.createTile = Mod.Find<ModTile>("LCD").Type;

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WireBulb, 7);
            recipe.AddIngredient(ItemID.Wire, 40);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }
    }
}