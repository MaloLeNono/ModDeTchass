using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Buffs;

class Autism : ModBuff
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
        player.GetModPlayer<AutismPlayer>().hasAutism = true;
        player.moveSpeed -= 0.85f;
        player.maxMinions = 1;
        player.statDefense -= 50;
        player.AddBuff(BuffID.Confused, 99999999);
    }
}

class AutismPlayer : ModPlayer
{
    public bool hasAutism;

    public override void ResetEffects()
    {
        hasAutism = false;
    }

    public override void PostUpdateRunSpeeds()
    {
        if (hasAutism)
            Player.maxRunSpeed -= 2f;
    }

    public override void UpdateBadLifeRegen()
    {
        if (hasAutism)
            Player.lifeRegen = 0;
    }
}