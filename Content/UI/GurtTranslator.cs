using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.UI;
using Terraria.UI;

namespace ModDeTchass.Content.UI;

internal class GurtTranslator : UIState, ILoadable
{
    public static GurtTranslator Instance;

    public void Load(Mod mod)
    {
        Instance = this;
    }

    public void Unload()
    {
    }

    public override void OnInitialize()
    {
        UIPanel panel = new UIPanel()
        {
            HAlign = 0.5f,
            VAlign = 0.5f,
            Width = new StyleDimension(600, 0f),
            Height = new StyleDimension(180, 0f)
        };
        Append(panel);

        UIText header = new UIText("Gurt Translator")
        {
            IsWrapped = true,
            Width = StyleDimension.Fill,
            HAlign = 0.5f
        };
        panel.Append(header);
        
        UIText description = new UIText("Translates Gurt's brainrot.") 
        {
            Top = new StyleDimension(40f, 0f),
            TextOriginX = 0f,
            IsWrapped = true,
            Width = StyleDimension.Fill
        };
        panel.Append(description);

        UIText download = new UIText("https://www.mediafire.com/file/ehruswy173w6x0t/GurtTranslator.exe/file")
        {
            Top = new StyleDimension(80f, 0f),
            TextOriginX = 0f,
            IsWrapped = true,
            Width = StyleDimension.Fill
        };
        panel.Append(download);

        var backButton = new UITextPanel<string>("Close", 0.7f)
        {
            TextColor = Color.White,
            VAlign = 1f,
            Width = new StyleDimension(-10, 1 / 3f),
            Height = new StyleDimension(30f, 0)
        };
        backButton.WithFadedMouseOver();
        backButton.OnLeftClick += BackButton_OnLeftClick;
        panel.Append(backButton);
    }

    private void BackButton_OnLeftClick(UIMouseEvent evnt, UIElement listeningElement)
    {
        IngameFancyUI.Close();
    }
}