using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Buffs
{
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
            player.moveSpeed = 0.15f;
            player.maxRunSpeed = 1f;
            player.maxMinions = 1;
            player.lifeRegen = 0;
            player.statDefense -= 50;
            player.AddBuff(BuffID.Confused, 99999999);
        }
    }

    /*class AutismPlayer : ModPlayer
    {
    }*/
}
