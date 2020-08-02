using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Therion.Items
{
    public abstract class TherionItem : ModItem
    {
        public override bool CloneNewInstances => true;
        public int therionCost = 0;
        public int therionBuff = -1;
        public int therionBuffTime = 0;

        public virtual void SetSafeDefaults() { }

        public sealed override void SetDefaults()
        {
            SetSafeDefaults();
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return (TherionPlayer.ModPlayer(player).therionResourceCurrent >= therionCost);
        }

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            add += TherionPlayer.ModPlayer(player).therionDamageAdd;
            mult *= TherionPlayer.ModPlayer(player).therionDamageMult;
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            knockback += TherionPlayer.ModPlayer(player).therionKnockback;
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            crit += TherionPlayer.ModPlayer(player).therionCrit;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");

            if(tt != null)
            {
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWorld = splitText.Last();

                tt.text = damageValue + " Therion " + damageWorld;
            }

            if(therionCost > 0)
            {
                tooltips.Add(new TooltipLine(mod, "Therion Cost", $"Special uses {therionCost} Therion Energy."));
            }
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (CanUseSpecial(player))
                {
                    item.useStyle = ItemUseStyleID.HoldingUp;
                    item.buffType = therionBuff;
                    item.buffTime = therionBuffTime;
                    item.damage = 0;
                    item.useTime = 50;
                    item.useAnimation = 50;
                    item.shoot = ProjectileID.None;
                    item.noUseGraphic = false;
                    item.autoReuse = false;
                }
                else
                {
                    item.buffType = 0;
                    item.buffTime = 0;
                    return false;
                }
            }
            else
            {
                item.buffType = 0;
                item.buffTime = 0;
                SetSafeDefaults();
            }
            return base.CanUseItem(player);
        }

        public virtual bool CanUseSpecial(Player player)
        {
            if(therionBuff != 0 && player.HasBuff(therionBuff)) return false;

            var therionPlayer = TherionPlayer.ModPlayer(player);
            if (therionPlayer.therionResourceCurrent >= therionCost)
            {
                therionPlayer.therionResourceCurrent -= therionCost;
                return true;
            }
            return false;
        }

    }
}
