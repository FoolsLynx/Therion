using Terraria;
using Terraria.ModLoader;
using Therion.Items;

namespace Therion.Buffs
{
    public class TherionUltimateBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Impulse Desire");
            Description.SetDefault("Greatly increases Therion Power.");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            TherionPlayer.ModPlayer(player).therionDamageMult *= 5f;
            TherionPlayer.ModPlayer(player).therionKnockback += 3f;
            TherionPlayer.ModPlayer(player).therionCrit += 10;
            if (player.HeldItem.modItem is TherionItem)
            {
                player.moveSpeed *= 3f;
                player.meleeSpeed *= 2f;
            }
        }
    }
}
