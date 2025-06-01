using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass;

public class ModDeTchass : Mod
{
    public override void Load()
    {
        TextureAssets.NpcHead[NPCHeadID.Guide] = ModContent.Request<Texture2D>
            ("ModDeTchass/Content/Textures/NPC_Head_1");
        TextureAssets.NpcHead[NPCHeadID.BestiaryGirl] = ModContent.Request<Texture2D>
            ("ModDeTchass/Content/Textures/Null_Head");
    }

    public override void Unload()
    {
        TextureAssets.NpcHead[NPCHeadID.Guide] = ModContent.Request<Texture2D>
            ("Terraria/Images/NPC_Head_1");
        TextureAssets.NpcHead[NPCHeadID.BestiaryGirl] = ModContent.Request<Texture2D>
            ("Terraria/Images/NPC_Head_26");
    }
}