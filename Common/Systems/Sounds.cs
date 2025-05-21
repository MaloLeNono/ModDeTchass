using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Common.Systems;

public class Sounds : ModSystem
{
    public static SoundStyle LudoLaugh;
    public static SoundStyle LudoDrogue;
    public static SoundStyle LudoEi;
    public static SoundStyle PiedsOursin;
    public static SoundStyle StrafeEnd;
    public static SoundStyle M61Fire;
    public static SoundStyle GlennQuagmire;
    public static SoundStyle OursinEi;
    public static SoundStyle Beuh;
    public static SoundStyle Ai;
    public static SoundStyle StrafeEndGau8;
    public static SoundStyle Gau8Fire;
        
    public override void Load()
    {
        LudoLaugh = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Custom/LetsGo")
        {
            Volume = 0.5f
        };

        LudoDrogue = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Custom/LudoDrogue")
        {
            Volume = 0.2f,
            PitchVariance = 0.2f
        };

        LudoEi = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Custom/LudoEi")
        {
            Volume = 1.5f,
            PitchVariance = 0.1f
        };

        PiedsOursin = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Custom/PiedsOursin")
        {
            Volume = 0.8f,
            PitchVariance = 0.05f
        };

        StrafeEnd = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Guns/StrafeEnd")
        {
            Volume = 1.5f,
            PitchVariance = 0.05f
        };

        M61Fire = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Guns/M61Fire")
        {
            Volume = 1.5f,
            PitchVariance = 0.2f
        };

        GlennQuagmire = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Custom/GlennQuagmire")
        {
            Volume = 1.5f
        };

        OursinEi = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Custom/OursinEi")
        {
            Volume = 0.3f,
            PitchVariance = 0.3f
        };

        Beuh = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Custom/Beuh")
        {
            Volume = 2f
        };

        Ai = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Custom/Ai")
        {
            Volume = 1.5f,
            PitchVariance = 0.2f
        };

        StrafeEndGau8 = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Guns/StrafeEndGau8")
        {
            Volume = 1.5f,
            PitchVariance = 0.05f
        };

        Gau8Fire = new SoundStyle($"{nameof(ModDeTchass)}/Content/Sounds/Guns/Gau8Fire")
        {
            Volume = 5f,
            PitchVariance = 0.2f
        };
    }
}