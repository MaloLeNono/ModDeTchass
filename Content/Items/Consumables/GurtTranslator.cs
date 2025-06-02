using ModDeTchass.Common.Systems;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace ModDeTchass.Content.Items.Consumables;

public class GurtTranslator : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.value = Item.buyPrice(gold: 10);
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.useTurn = true;
        Item.rare = ItemRarityID.Green;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.UseSound = SoundID.MenuOpen;
        Item.maxStack = 1;
    }

    public override bool CanUseItem(Player player)
    {
        return TownNPCRespawnSystem.UnlockedGurt;
    }

    public override bool? UseItem(Player player)
    {
        IngameFancyUI.OpenUIState(UI.GurtTranslator.Instance);
        return true;
    }
}