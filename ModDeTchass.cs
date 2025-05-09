using Terraria.Audio;
using Terraria.ModLoader;

namespace ModDeTchass
{
	public class ModDeTchass : Mod
	{
        public static SoundStyle LudoLaugh;
        public static SoundStyle LudoDrogue;
        public static SoundStyle LudoEi;
        public static SoundStyle PiedsOursin;
        public static SoundStyle StrafeEnd;
        public static SoundStyle M61Fire;

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
        }
    }
}
