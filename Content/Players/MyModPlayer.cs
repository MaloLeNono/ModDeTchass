using ModDeTchass.Content.Items.Guns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Players
{
    class MyModPlayer : ModPlayer
    {
        public bool wasFiring;

        public override void PostUpdate()
        {
            bool isFiring = Player.controlUseItem && Player.HeldItem.type == ModContent.ItemType<M61Vulcan>();


            if (wasFiring && !isFiring)
            {
                SoundEngine.PlaySound(ModDeTchass.StrafeEnd, Player.position);
            }

            wasFiring = isFiring;
        }
    }
}
