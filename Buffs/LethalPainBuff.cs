using Terraria;
using Terraria.ModLoader;
using Therion.Items;

namespace Therion.Buffs
{
    public class LethalPainBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lethal Pain");
            Description.SetDefault("Greatly increases Therion Power.");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            TherionPlayer.ModPlayer(player).therionCrit *= 3;
            TherionPlayer.ModPlayer(player).therionDamageMult *= 1.2f;
        }
    }
}
