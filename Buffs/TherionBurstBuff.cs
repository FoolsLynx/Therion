using Terraria;
using Terraria.ModLoader;
using Therion.Items;

namespace Therion.Buffs
{
    public class TherionBurstBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Therion Burst");
            Description.SetDefault("Greatly increases Therion Power.");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            TherionPlayer.ModPlayer(player).therionDamageAdd += 5;
            TherionPlayer.ModPlayer(player).therionKnockback += 3f;
            if(player.HeldItem.modItem is TherionItem)
            {
                player.meleeSpeed *= 1.3f;
            }
        }
    }
}
