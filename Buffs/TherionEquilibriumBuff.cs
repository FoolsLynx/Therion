using Terraria;
using Terraria.ModLoader;
using Therion.Items;

namespace Therion.Buffs
{
    public class TherionEquilibriumBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Therion Equilibrium");
            Description.SetDefault("Drains Life but gain Therion Energy.");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var therionPlayer = TherionPlayer.ModPlayer(player);
            if(player.statLife > 1 && therionPlayer.therionResourceCurrent != therionPlayer.therionResourceMax2)
            {
                therionPlayer.equilibriumEffect = true;
            }
        }
    }
}
