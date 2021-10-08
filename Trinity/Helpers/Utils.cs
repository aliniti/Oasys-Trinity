using System.Linq;
using Oasys.Common;
using Oasys.Common.Extensions;
using Oasys.Common.GameObject.Clients;
using Oasys.Common.Menu.ItemComponents;
using Oasys.SDK;
using Oasys.SDK.SpellCasting;
using Trinity.Items;

namespace Trinity.Helpers
{
    using System;
    using Oasys.Common.Enums.GameEnums;

    public static class Utils
    {
        public static bool IsSafeCast(this ActiveItem item, AIHeroClient unit)
        {
            if (unit.IsRecalling || unit.IsCastingSpell || unit.IsEmpoweredRecalling)
            {
                return false;
            }
            
            var nexus = UnitManager.AllyNexus;
            if (nexus != null && nexus.Distance(unit.Position) <= 1000)
            {
                return false;
            }
            
            return true;
        }

        public static void ItemCheckEnemyLowHealth(this ActiveItem item, AIHeroClient unit)
        {
            if (item.ActivationTypes.Contains(Enums.ActivationType.CheckEnemyLowHP))
            {
                var pctHealth = unit.Health / unit.MaxHealth * 100;
                if (pctHealth <= item.ItemCounter[item.ItemId.ToString()].Value && 
                    item.ItemSwitch[item.ItemId.ToString()].IsOn)
                {
                    UseItem(item, unit);
                }
            }
        }

        public static void ItemCheckLowHealth(this ActiveItem item, AIHeroClient unit)
        {
            if (item.ActivationTypes.Contains(Enums.ActivationType.CheckAllyLowHP))
            {
                var pctHealth = unit.Health / unit.MaxHealth * 100;
                if (pctHealth <= item.ItemCounter[item.ItemId.ToString()].Value &&
                    item.ItemSwitch[item.ItemId.ToString()].IsOn)
                {
                    UseItem(item, unit);
                }
            }
        }

        public static void ItemCheckLowMana(this ActiveItem item, AIHeroClient unit)
        {
            if (item.ActivationTypes.Contains(Enums.ActivationType.CheckAllyLowMP))
            {
                var pctMana = unit.Mana / unit.MaxMana * 100;
                if (pctMana <= item.ItemCounter[item.ItemId.ToString()].Value && 
                    item.ItemSwitch[item.ItemId.ToString()].IsOn)
                {
                    UseItem(item, unit);
                }
            }
        }

        public static void UseItem(this ActiveItem item, AIHeroClient unit)
        {
            if (!IsSafeCast(item, unit))
            {
                return;
            }

            if (item.TargetingType.ToString().Contains("Proximity"))
            {
                ItemCastProvider.CastItem(item.ItemId);
                item.LastUsedTimeStamp = (int) (GameEngine.GameTime * 1000);
            }

            if (item.TargetingType.ToString().Contains("Unit"))
            {
                if (unit != null)
                {
                    ItemCastProvider.CastItem(item.ItemId, unit);
                    item.LastUsedTimeStamp = (int) (GameEngine.GameTime * 1000);
                }
            }

            if (item.TargetingType.ToString().Contains("Skillshot"))
            {
                if (unit != null)
                {
                    ItemCastProvider.CastItem(item.ItemId, unit.AIManager.ServerPosition);
                    item.LastUsedTimeStamp = (int) (GameEngine.GameTime * 1000);
                }
            }
        }
    }
}