using ModDeTchass.Common.Systems;
using ModDeTchass.Content.Buffs;
using ModDeTchass.Content.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Consumables;

public class JobApplication : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 34;
        Item.height = 44;
        Item.scale = 0.7f;
        Item.consumable = true;
        Item.value = Item.buyPrice(silver: 5);
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useTurn = true;
        Item.rare = ItemRarityID.Expert;
        Item.UseSound = Sounds.LudoDrogue;
        Item.maxStack = Item.CommonMaxStack;
    }

    public override bool? UseItem(Player player)
    {
        if (player.HasBuff<Unemployed>() && player.whoAmI == Main.myPlayer)
        {
            SoundEngine.PlaySound(Sounds.LudoLaugh);

            int type = ModContent.NPCType<UnemploymentFinalBoss>();

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, type);
            }
            else
            {
                NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
            }

            return true;
        }
        
        player.AddBuff(ModContent.BuffType<Employed>(), 99999999);
        return true;
    }
}