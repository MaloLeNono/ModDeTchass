using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Buffs;

class Insectes : ModBuff
{
    public override void SetStaticDefaults()
    {
        Main.debuff[Type] = true;
        Main.buffNoSave[Type] = false;
        Main.buffNoTimeDisplay[Type] = true;
        BuffID.Sets.LongerExpertDebuff[Type] = true;
    }

    public override void Update(Player player, ref int buffIndex)
    {
        player.GetModPlayer<InsectsPlayer>().insectsDebuff = true;
    }
}

class InsectsPlayer : ModPlayer
{
    public bool insectsDebuff;

    public override void ResetEffects()
    {
        insectsDebuff = false;
    }

    public override void UpdateBadLifeRegen()
    {
        if (insectsDebuff)
        {
            if (Player.lifeRegen > 0)
                Player.lifeRegen = 0;

            Player.lifeRegenTime = 0;
            Player.lifeRegen -= 20;
        }
    }
}