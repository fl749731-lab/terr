using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace xiwang.Content.Items
{
    // Texture: Content/Items/AuriteOre.png (keep next to this file)
    public class AuriteOre : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(copper: 50);
            Item.rare = ItemRarityID.White;
        }
    }
}

