namespace Trinity.Helpers
{
    using Oasys.SDK;
    using Oasys.SDK.SpellCasting;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.GameObject.Clients.ExtendedInstances;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using System.Collections.Generic;
    using System.Linq;
    using Items;

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

        public static void ItemCheckAuras(this ActiveItem item, AIHeroClient hero)
        {
            if (item.ActivationTypes.Contains(Enums.ActivationType.CheckAuras))
            {
                var champObj = Bootstrap.AllChampions.FirstOrDefault(x => x.Instance.NetworkID == hero.NetworkID);
                if (champObj?.Instance != null)
                {
                    var healthPct = champObj.Instance.Health / champObj.Instance.MaxHealth * 100;

                    if (!(healthPct > item.ItemCounter[item.ItemId + "MinimumBuffsHP"].Value) 
                        || !item.ItemSwitch[item.ItemId + "SwitchMinimumBuffHP"].IsOn)
                    {
                        champObj.AuraInfo[item.ItemId + "BuffCount"] = GetAuras(item, champObj).Count();
                        champObj.AuraInfo[item.ItemId + "BuffHighestTime"] = 0;

                        if (champObj.AuraInfo[item.ItemId + "BuffCount"] > 0)
                        {
                            foreach (var buff in GetAuras(item, champObj))
                            {
                                var length = (int) (buff.EndTime - buff.StartTime);
                                if (length >= champObj.AuraInfo[item.ItemId + "BuffHighestTime"])
                                {
                                    champObj.AuraInfo[item.ItemId + "BuffHighestTime"] = length * 1000;
                                }
                            }

                            champObj.AuraInfo[item.ItemId + "BuffTimestamp"] = (int) (GameEngine.GameTime * 1000);
                        }
                        else
                        {
                            if (champObj.AuraInfo[item.ItemId + "BuffHighestTime"] > 0)
                            {
                                champObj.AuraInfo[item.ItemId + "BuffHighestTime"] -= champObj.AuraInfo[item.ItemId + "BuffHighestTime"];
                            }
                            else
                            {
                                champObj.AuraInfo[item.ItemId + "BuffHighestTime"] = 0;
                            }
                        }

                        if (champObj.AuraInfo[item.ItemId + "BuffCount"] >= item.ItemCounter[item.ItemId + "MinimumBuffs"].Value &&
                            champObj.AuraInfo[item.ItemId + "BuffHighestTime"] >= item.ItemCounter[item.ItemId + "MinimumBuffsDuration"].Value)
                        {
                            UseItem(item, champObj.Instance);
                            champObj.AuraInfo[item.ItemId + "BuffCount"] = 0;
                            champObj.AuraInfo[item.ItemId + "BuffHighestTime"] = 0;
                        }
                    }
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

        public static IEnumerable<BuffEntry> GetAuras(this ActiveItem item, Champion champion)
        {
            return champion.Instance.BuffManager.GetBuffList()
                .Where(buff => buff.IsActive && 
                 (buff.EntryType == BuffType.Snare && item.ItemSwitch[item.ItemId + "Snares"].IsOn ||
                  buff.EntryType == BuffType.Sleep && item.ItemSwitch[item.ItemId + "Sleep"].IsOn ||
                  buff.EntryType == BuffType.Knockup && item.ItemSwitch[item.ItemId + "Knockups"].IsOn ||
                  buff.EntryType == BuffType.Silence && item.ItemSwitch[item.ItemId + "Silence"].IsOn ||
                  buff.EntryType == BuffType.Charm && item.ItemSwitch[item.ItemId + "Charms"].IsOn ||
                  buff.EntryType == BuffType.Taunt && item.ItemSwitch[item.ItemId + "Taunts"].IsOn ||
                  buff.EntryType == BuffType.Stun && item.ItemSwitch[item.ItemId + "Stuns"].IsOn ||
                  buff.EntryType == BuffType.Flee && item.ItemSwitch[item.ItemId + "Fear"].IsOn ||
                  buff.EntryType == BuffType.Polymorph && item.ItemSwitch[item.ItemId + "Polymorphs"].IsOn ||
                  buff.EntryType == BuffType.Blind && item.ItemSwitch[item.ItemId + "Blinds"].IsOn ||
                  buff.EntryType == BuffType.Suppression && item.ItemSwitch[item.ItemId + "Suppression"].IsOn ||
                  buff.EntryType == BuffType.Poison && item.ItemSwitch[item.ItemId + "Poison"].IsOn ||
                  buff.EntryType == BuffType.Slow && item.ItemSwitch[item.ItemId + "Slows"].IsOn) ||
                  buff.Name.ToLower() == "summonerexhaust" && item.ItemSwitch[item.ItemId + "Exhaust"].IsOn ||
                  buff.Name.ToLower() == "summonerdot" && item.ItemSwitch[item.ItemId + "Ignite"].IsOn);
        }
    }
}