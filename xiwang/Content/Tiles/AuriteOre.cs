using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace xiwang.Content.Tiles
{
    // Tile texture expected at: Content/Tiles/AuriteOre.png
    public class AuriteOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true; // Highlights with Spelunker
            Main.tileShine2[Type] = true;    // Modest shine
            Main.tileShine[Type] = 975;
            Main.tileValue[Type] = 410;      // Metal detector priority
            Main.tileOreFinderPriority[Type] = 410;
            TileID.Sets.Ore[Type] = true;

            DustType = DustID.IceTorch;
            HitSound = SoundID.Tink;
            MinPick = 55;     // Require at least Gold/Platinum tier
            MineResist = 3f;  // Hardness

            // Drop AuriteOre item when mined
            RegisterItemDrop(ModContent.ItemType<xiwang.Content.Items.AuriteOre>());

            AddMapEntry(new Color(120, 200, 255), CreateMapEntryName());
        }
    }
}
