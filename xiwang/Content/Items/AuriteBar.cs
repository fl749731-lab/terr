using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace xiwang.Content.Items
{
    // Texture: Content/Items/AuriteBar.png (placed alongside this file)
    public class AuriteBar : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            Recipe.Create(ModContent.ItemType<AuriteBar>())
                .AddIngredient(ModContent.ItemType<AuriteOre>(), 3)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
