using ModDeTchass.Content.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Tiles;

public class MusiqueDeTchassItem : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.CanGetPrefixes[Type] = false;
        ItemID.Sets.ShimmerTransformToItem[Type] = ItemID.MusicBox;
        
        MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Content/Sounds/Music/bfdtchsSong"), ModContent.ItemType<MusiqueDeTchassItem>(), ModContent.TileType<MusiqueDeTchass>());
    }

    public override void SetDefaults()
    {
        Item.DefaultToMusicBox(ModContent.TileType<MusiqueDeTchass>());
    }
}