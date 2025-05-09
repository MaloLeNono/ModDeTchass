using ModDeTchass.Common.Systems;
using ModDeTchass.Content.NPCs.Bosses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ModDeTchass.Content.Items.Materials
{
    class BouffeDeTchass : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.value = Item.buyPrice(silver: 50);
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Blue;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(ModDeTchass.LudoLaugh);

                int type = ModContent.NPCType<BFDTCHS>();

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.SpawnOnPlayer(player.whoAmI, type);
                }
                else
                {
                    NetMessage.SendData(MessageID.SpawnBossUseLicenseStartEvent, number: player.whoAmI, number2: type);
                }
            }

            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (Condition.Hardmode.IsMet() && DownedBossSystem.downedBossDeTchass && Condition.DownedMechBossAll.IsMet())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<RawTchass>(4)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
