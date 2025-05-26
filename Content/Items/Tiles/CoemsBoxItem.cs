using ModDeTchass.Content.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Tiles;

public class CoemsBoxItem : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.CanGetPrefixes[Type] = false;
        ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox;
        
        MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Content/Sounds/Music/BossDeTchassSong"), ModContent.ItemType<CoemsBoxItem>(), ModContent.TileType<CoemsBox>());
    }

    public override void SetDefaults()
    {
        Item.DefaultToMusicBox(ModContent.TileType<CoemsBox>());
    }
}