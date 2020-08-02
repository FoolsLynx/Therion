using Terraria;
using Terraria.ModLoader;
using Therion.Items;

namespace Therion.Buffs
{
    public class TherionFocusBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Therion Focus");
            Description.SetDefault("Greatly increases Therion Power.");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            TherionPlayer.ModPlayer(player).therionDamageMult *= 1.1f;
            TherionPlayer.ModPlayer(player).therionCrit += 3;
        }
    }
}
