using Microsoft.Xna.Framework.Graphics;
using ModDeTchass.Content.Backgrounds;
using ReLogic.Content;
using Terraria.ModLoader;

namespace ModDeTchass;

public class TchassMenu : ModMenu
{
    public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>("ModDeTchass/Content/Textures/Logo");
    public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>("ModDeTchass/Content/Textures/Sun");
    public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>("ModDeTchass/Content/Textures/Sun");
    public override int Music => MusicLoader.GetMusicSlot(Mod, "Content/Sounds/Music/MenuMusic");
    public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<BfdtchsBack>();
    public override string DisplayName => "Tchass Menu";
    public override bool IsAvailable => true;
}