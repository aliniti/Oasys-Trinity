namespace Trinity.Helpers
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Base;
    using Items;
    using Oasys.Common;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.GameObject.Clients.ExtendedInstances;
    using Oasys.SDK;
    using Oasys.SDK.SpellCasting;
    using Spells;

    #endregion

    public static class Utils
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Resets the champion aggro values
        /// </summary>
        /// <param name="champion"></param>
        public static void ResetAggro(this Champion champion)
        {
            champion.AggroTick = 0;
            champion.HasAggro = false;
            champion.InDanger = false;
            champion.InCrowdControl = false;
            champion.InExtremeDanger = false;
        }
        
        /// <summary>
        ///     Checks if the enemy exists by string
        /// </summary>
        /// <param name="champion"></param>
        /// <returns></returns>
        public static bool EnemyExists(this string champion)
        {
            return UnitManager.Enemies.Any(x => x.ModelName == champion);
        }
        
        /// <summary>
        ///     Gets the best unit for cluster.
        /// </summary>
        /// <param name="units">The units.</param>
        /// <param name="clusterRange">The cluster range.</param>
        /// <returns></returns>
        public static AIBaseClient GetBestUnitForCluster(IEnumerable<AIBaseClient> units, float clusterRange)
        {
            IEnumerable<AIBaseClient> aiUnits = units as AIBaseClient[] ?? units.ToArray();

            if (aiUnits.Any())
            {
                var firstOrDefault = (from u in aiUnits
                    select new
                    {
                        Count = GetRadiusClusterCount(u, aiUnits, clusterRange),
                        Unit = u
                    }).OrderByDescending(a => a.Count).FirstOrDefault();

                if (firstOrDefault != null)
                    return firstOrDefault.Unit;
            }

            return null;
        }

        public static List<AIBaseClient> GetEnemyUnitsOnSegment(this ProjectionInfo proj, float radius, bool heroes, bool minions)
        {
            var objList = new List<AIBaseClient>();
            
            foreach (var u in ObjectManagerExport.HeroCollection)
            {
                var unit = u.Value;
                if (unit.IsValidTarget() && heroes)
                {
                    var nearit = unit.Position.Distance(proj.SegmentPoint) <= radius;
                    if (nearit)
                    {
                        objList.Add(unit);
                    }
                }
            }
            
            foreach (var u in ObjectManagerExport.MinionCollection)
            {
                var minion = u.Value;
                if (minion.IsValidTarget() && minions)
                {
                    var nearit = minion.Position.Distance(proj.SegmentPoint) <= radius;
                    if (nearit)
                    {
                        objList.Add(minion);
                    }
                }
            }
            
            return objList;
        }

        /// <summary>
        ///     Gets the radius cluster count.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="otherUnits">The other units.</param>
        /// <param name="radius">The radius.</param>
        /// <returns></returns>
        public static int GetRadiusClusterCount(this AIBaseClient target, IEnumerable<AIBaseClient> otherUnits, float radius)
        {
            var rdx = radius * radius;
            var targetLoc = target.Position;

            return otherUnits.Count(u => u.Position.DistanceSquared(targetLoc) <= rdx);
        }

        /// <summary>
        ///     Checks the item for enemy low health.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="unit">The unit.</param>
        public static void CheckItemEnemyLowHealth(this ActiveItem item, AIHeroClient unit)
        {
            if (item.ActivationTypes.Contains(ActivationType.CheckEnemyLowHP))
            {
                var pctHealth = unit.Health / unit.MaxHealth * 100;
                if (pctHealth <= item.ItemCounter[item.ItemId + "ehp"].Value &&
                    item.ItemSwitch[item.ItemId.ToString()].IsOn)
                    UseItem(item, unit);
            }
        }

        /// <summary>
        ///     Checks the item for ally low health.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="unit">The unit.</param>
        public static void CheckItemAllyLowHealth(this ActiveItem item, AIHeroClient unit)
        {
            if (item.ActivationTypes.Contains(ActivationType.CheckAllyLowHP))
            {
                var pctHealth = unit.Health / unit.MaxHealth * 100;
                if (pctHealth <= item.ItemCounter[item.ItemId + "ahp"].Value &&
                    item.ItemSwitch[item.ItemId.ToString()].IsOn)
                    UseItem(item, unit);
            }
        }

        /// <summary>
        ///     Checks the item for ally low mana.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="unit">The unit.</param>
        public static void CheckItemAllyLowMana(this ActiveItem item, AIHeroClient unit)
        {
            if (item.ActivationTypes.Contains(ActivationType.CheckAllyLowMP))
            {
                var pctMana = unit.Mana / unit.MaxMana * 100;
                if (pctMana <= item.ItemCounter[item.ItemId + "amp"].Value &&
                    item.ItemSwitch[item.ItemId.ToString()].IsOn)
                    UseItem(item, unit);
            }
        }
        
        /// <summary>
        ///     Checks the item for dangerous spells.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="unit">The unit.</param>
        public static void CheckItemDangerousSpells(this ActiveItem item, Champion champion)
        {
            if (item.ActivationTypes.Contains(ActivationType.CheckDangerous))
            {
                if (item.ItemSwitch[item.ItemId + "dangerextr"].IsOn)
                {
                    if (champion.HasAggro && champion.InExtremeDanger)
                    {
                        UseItem(item, champion.Instance);
                    }
                }
                
                if (item.ItemSwitch[item.ItemId + "dangercc"].IsOn)
                {
                    if (champion.HasAggro && champion.InCrowdControl)
                    {
                        UseItem(item, champion.Instance);
                    }
                }
                
                if (item.ItemSwitch[item.ItemId + "dangernorm"].IsOn)
                {
                    if (champion.HasAggro && champion.InDanger)
                    {
                        UseItem(item, champion.Instance);
                    }
                }
            }
        }

        /// <summary>
        ///     Checks the item for aoe count.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="unit">The unit.</param>
        public static void CheckItemProximityCount(this ActiveItem item, AIHeroClient unit)
        {
            if (item.ActivationTypes.Contains(ActivationType.CheckProximityCount))
            {
                if (item.TargetingType.ToString().Contains("Ally"))
                {
                    var unitCount = unit.GetRadiusClusterCount(UnitManager.AllyChampions, item.Range);
                    if (unitCount >= item.ItemCounter[item.ItemId + "aoe"].Value) UseItem(item, unit);
                }

                if (item.TargetingType.ToString().Contains("Enemy"))
                {
                    var unitCount = unit.GetRadiusClusterCount(UnitManager.EnemyChampions, item.Range);
                    if (unitCount >= item.ItemCounter[item.ItemId + "aoe"].Value) UseItem(item, unit);
                }
            }
        }

        /// <summary>
        ///     Checks the spell for enemy low health.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="unit">The unit.</param>
        public static void CheckSpellEnemyLowHealth(this AutoSpell spell, AIHeroClient unit)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            if (spell.ActivationTypes.Contains(ActivationType.CheckEnemyLowHP))
            {
                var pctHealth = unit.Health / unit.MaxHealth * 100;
                if (pctHealth <= spell.SpellCounter[tabName + "ehp"].Value &&
                    spell.SpellSwitch[tabName].IsOn)
                    UseSpell(spell, unit);
            }
        }

        /// <summary>
        ///     Checks the spell for ally low health.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="unit">The unit.</param>
        public static void CheckSpellAllyLowHealth(this AutoSpell spell, AIHeroClient unit)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            if (spell.ActivationTypes.Contains(ActivationType.CheckAllyLowHP))
            {
                var pctHealth = unit.Health / unit.MaxHealth * 100;
                if (pctHealth <= spell.SpellCounter[tabName + "ahp"].Value &&
                    spell.SpellSwitch[tabName].IsOn)
                    UseSpell(spell, unit);
            }
        }

        /// <summary>
        ///     Checks the spell for ally low mana.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="unit">The unit.</param>
        public static void CheckSpellAllyLowMana(this AutoSpell spell, AIHeroClient unit)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            if (spell.ActivationTypes.Contains(ActivationType.CheckAllyLowMP))
            {
                var pctMana = unit.Mana / unit.MaxMana * 100;
                if (pctMana <= spell.SpellCounter[tabName + "amp"].Value &&
                    spell.SpellSwitch[tabName].IsOn)
                    UseSpell(spell, unit);
            }
        }

        /// <summary>
        ///     Checks the spell for minimum mana.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
        public static bool CheckSpellMinimumMana(this AutoSpell spell, AIHeroClient unit)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            var pctMana = unit.Mana / unit.MaxMana * 100;

            return pctMana <= spell.SpellCounter[tabName + "amm"].Value &&
                   spell.SpellSwitch[tabName].IsOn;
        }
        
        /// <summary>
        ///     Checks the spell for dangerous spells.
        /// </summary>
        /// <param name="spell">The item.</param>
        /// <param name="unit">The unit.</param>
        public static void CheckSpellDangerousSpells(this AutoSpell spell, Champion champion)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;

            if (spell.ActivationTypes.Contains(ActivationType.CheckDangerous))
            {
                if (spell.SpellSwitch[tabName + "dangerextr"].IsOn)
                {
                    if (champion.HasAggro && champion.InExtremeDanger)
                    {
                        UseSpell(spell, champion.Instance);
                    }
                }

                if (spell.SpellSwitch[tabName + "dangercc"].IsOn)
                {
                    if (champion.HasAggro && champion.InCrowdControl)
                    {
                        UseSpell(spell, champion.Instance);
                    }
                }
                
                if (spell.SpellSwitch[tabName + "dangernorm"].IsOn)
                {
                    if (champion.HasAggro && champion.InDanger)
                    {
                        UseSpell(spell, champion.Instance);
                    }
                }
            }
        }

        /// <summary>
        ///     Determines whether [is safe cast] [the specified unit].
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>
        ///     <c>true</c> if [is safe cast] [the specified unit]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSafeCast(AIBaseClient unit)
        {
            if (unit is AIHeroClient hero)
                if (hero.IsRecalling || hero.IsCastingSpell || hero.IsEmpoweredRecalling)
                    return false;

            var nexus = UnitManager.AllyNexus;
            if (nexus != null && nexus.Distance(unit.Position) <= 1000)
                return false;

            return true;
        }

        /// <summary>
        ///     Uses the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
        public static void UseItem(this ActiveItem item, AIBaseClient unit)
        {
            if (!IsSafeCast(unit)) return;
            if (GameEngine.GameTime * 1000 - item.LastUsedTimeStamp < 250) return;

            if (item.TargetingType.ToString().Contains("Proximity"))
                if (item.SpellClass.IsSpellReady)
                {
                    ItemCastProvider.CastItem(item.ItemId);
                    item.LastUsedTimeStamp = (int) (GameEngine.GameTime * 1000);
                }

            if (item.TargetingType.ToString().Contains("Unit"))
                if (unit != null && item.SpellClass.IsSpellReady)
                {
                    ItemCastProvider.CastItem(item.ItemId, unit.Position);
                    item.LastUsedTimeStamp = (int) (GameEngine.GameTime * 1000);
                }

            if (item.TargetingType.ToString().Contains("Skillshot"))
                if (unit != null && item.SpellClass.IsSpellReady)
                {
                    ItemCastProvider.CastItem(item.ItemId, unit.Position);
                    item.LastUsedTimeStamp = (int) (GameEngine.GameTime * 1000);
                }
        }

        /// <summary>
        ///     Uses the spell.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
        public static void UseSpell(this AutoSpell spell, AIBaseClient unit)
        {
            if (!IsSafeCast(unit)) return;
            if (GameEngine.GameTime * 1000 - spell.LastUsedTimeStamp < 250) return;

            if (spell.TargetingType.ToString().Contains("Proximity"))
                if (spell.SpellClass.IsSpellReady)
                {
                    SpellCastProvider.CastSpell(spell.Slot);
                    spell.LastUsedTimeStamp = (int) (GameEngine.GameTime * 1000);
                }

            if (spell.TargetingType.ToString().Contains("Unit"))
                if (unit != null && spell.SpellClass.IsSpellReady)
                {
                    SpellCastProvider.CastSpell(spell.Slot, unit.Position);
                    spell.LastUsedTimeStamp = (int) (GameEngine.GameTime * 1000);
                }

            if (spell.TargetingType.ToString().Contains("Skillshot"))
                if (unit != null && spell.SpellClass.IsSpellReady)
                {
                    SpellCastProvider.CastSpell(spell.Slot, unit.Position);
                    spell.LastUsedTimeStamp = (int) (GameEngine.GameTime * 1000);
                }
        }

        /// <summary>
        ///     Corrects the spell class if needed.
        /// </summary>
        /// <param name="spell">The spell.</param>
        public static void CorrectSpellClass(this AutoSpellBase spell)
        {
            var summonerOne = UnitManager.MyChampion.GetSpellBook().GetSpellClass(SpellSlot.Summoner1);
            if (summonerOne.SpellData.SpellName.Contains("Smite") && spell.SpellName == "SummonerSmite")
            {
                spell.SpellClass = summonerOne;
                spell.Slot = CastSlot.Summoner1;
                spell.IsSummonerSpell = true;
            }

            else if (summonerOne.SpellData.SpellName == spell.SpellName)
            {
                spell.SpellClass = summonerOne;
                spell.Slot = CastSlot.Summoner1;
                spell.IsSummonerSpell = true;
            }

            var summonerTwo = UnitManager.MyChampion.GetSpellBook().GetSpellClass(SpellSlot.Summoner2);
            if (summonerTwo.SpellData.SpellName == spell.SpellName)
            {
                spell.SpellClass = summonerTwo;
                spell.Slot = CastSlot.Summoner2;
                spell.IsSummonerSpell = true;
            }

            else if (summonerTwo.SpellData.SpellName.Contains("Smite") && spell.SpellName == "SummonerSmite")
            {
                spell.SpellClass = summonerTwo;
                spell.Slot = CastSlot.Summoner2;
                spell.IsSummonerSpell = true;
            }
        }

        /// <summary>
        ///     Gets the auras.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="champion">The champion.</param>
        /// <returns></returns>
        public static IEnumerable<BuffEntry> GetAuras(this ActiveItem item, Champion champion)
        {
            return champion.Instance.BuffManager.GetBuffList()
                .Where(buff => (buff.IsActive &&
                                ((buff.EntryType == BuffType.Snare && item.ItemSwitch[item.ItemId + "Snares"].IsOn) ||
                                 (buff.EntryType == BuffType.Sleep && item.ItemSwitch[item.ItemId + "Sleep"].IsOn) ||
                                 (buff.EntryType == BuffType.Knockup && item.ItemSwitch[item.ItemId + "Knockups"].IsOn) ||
                                 (buff.EntryType == BuffType.Silence && item.ItemSwitch[item.ItemId + "Silence"].IsOn) ||
                                 (buff.EntryType == BuffType.Charm && item.ItemSwitch[item.ItemId + "Charms"].IsOn) ||
                                 (buff.EntryType == BuffType.Taunt && item.ItemSwitch[item.ItemId + "Taunts"].IsOn) ||
                                 (buff.EntryType == BuffType.Stun && item.ItemSwitch[item.ItemId + "Stuns"].IsOn) ||
                                 (buff.EntryType == BuffType.Flee && item.ItemSwitch[item.ItemId + "Fear"].IsOn) ||
                                 (buff.EntryType == BuffType.Polymorph && item.ItemSwitch[item.ItemId + "Polymorphs"].IsOn) ||
                                 (buff.EntryType == BuffType.Blind && item.ItemSwitch[item.ItemId + "Blinds"].IsOn) ||
                                 (buff.EntryType == BuffType.Suppression && item.ItemSwitch[item.ItemId + "Suppression"].IsOn) ||
                                 (buff.EntryType == BuffType.Poison && item.ItemSwitch[item.ItemId + "Poison"].IsOn) ||
                                 (buff.EntryType == BuffType.Slow && item.ItemSwitch[item.ItemId + "Slows"].IsOn))) ||
                               (buff.Name.ToLower() == "summonerexhaust" && item.ItemSwitch[item.ItemId + "Exhaust"].IsOn) ||
                               (buff.Name.ToLower() == "summonerdot" && item.ItemSwitch[item.ItemId + "Ignite"].IsOn));
        }

        /// <summary>
        ///     Gets the auras.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="champion">The champion.</param>
        /// <returns></returns>
        public static IEnumerable<BuffEntry> GetAuras(this AutoSpell spell, Champion champion)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            return champion.Instance.BuffManager.GetBuffList()
                .Where(buff => (buff.IsActive &&
                                ((buff.EntryType == BuffType.Snare && spell.SpellSwitch[tabName + "Snares"].IsOn) ||
                                 (buff.EntryType == BuffType.Sleep && spell.SpellSwitch[tabName + "Sleep"].IsOn) ||
                                 (buff.EntryType == BuffType.Knockup && spell.SpellSwitch[tabName + "Knockups"].IsOn) ||
                                 (buff.EntryType == BuffType.Silence && spell.SpellSwitch[tabName + "Silence"].IsOn) ||
                                 (buff.EntryType == BuffType.Charm && spell.SpellSwitch[tabName + "Charms"].IsOn) ||
                                 (buff.EntryType == BuffType.Taunt && spell.SpellSwitch[tabName + "Taunts"].IsOn) ||
                                 (buff.EntryType == BuffType.Stun && spell.SpellSwitch[tabName + "Stuns"].IsOn) ||
                                 (buff.EntryType == BuffType.Flee && spell.SpellSwitch[tabName + "Fear"].IsOn) ||
                                 (buff.EntryType == BuffType.Polymorph && spell.SpellSwitch[tabName + "Polymorphs"].IsOn) ||
                                 (buff.EntryType == BuffType.Blind && spell.SpellSwitch[tabName + "Blinds"].IsOn) ||
                                 (buff.EntryType == BuffType.Suppression && spell.SpellSwitch[tabName + "Suppression"].IsOn) ||
                                 (buff.EntryType == BuffType.Poison && spell.SpellSwitch[tabName + "Poison"].IsOn) ||
                                 (buff.EntryType == BuffType.Slow && spell.SpellSwitch[tabName + "Slows"].IsOn))) ||
                               (buff.Name.ToLower() == "summonerexhaust" && spell.SpellSwitch[tabName + "Exhaust"].IsOn) ||
                               (buff.Name.ToLower() == "summonerdot" && spell.SpellSwitch[tabName + "Ignite"].IsOn));
        }

        /// <summary>
        ///     Checks the auras per item
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="hero">The hero.</param>
        /// <returns></returns>
        public static void CheckItemAuras(this ActiveItem item, AIHeroClient hero)
        {
            if (item.ActivationTypes.Contains(ActivationType.CheckAuras))
            {
                var champObj = Bootstrap.Allies
                    .FirstOrDefault(x => x.Value.Instance.NetworkID == hero.NetworkID).Value;

                if (champObj?.Instance == null)
                    return;

                var healthPct = champObj.Instance.Health / champObj.Instance.MaxHealth * 100;
                if (healthPct > item.ItemCounter[item.ItemId + "MinimumBuffsHP"].Value &&
                    item.ItemSwitch[item.ItemId + "SwitchMinimumBuffHP"].IsOn)
                    return;

                champObj.AuraInfo[item.ItemId + "BuffCount"] = GetAuras(item, champObj).Count();
                champObj.AuraInfo[item.ItemId + "BuffHighestTime"] = 0;

                if (champObj.AuraInfo[item.ItemId + "BuffCount"] > 0)
                {
                    foreach (var buff in GetAuras(item, champObj))
                    {
                        var length = (int) (buff.EndTime - buff.StartTime);
                        if (length >= champObj.AuraInfo[item.ItemId + "BuffHighestTime"]) champObj.AuraInfo[item.ItemId + "BuffHighestTime"] = length * 1000;
                    }

                    champObj.AuraInfo[item.ItemId + "BuffTimestamp"] = (int) (GameEngine.GameTime * 1000);
                }
                else
                {
                    if (champObj.AuraInfo[item.ItemId + "BuffHighestTime"] > 0)
                        champObj.AuraInfo[item.ItemId + "BuffHighestTime"] -= champObj.AuraInfo[item.ItemId + "BuffHighestTime"];
                    else
                        champObj.AuraInfo[item.ItemId + "BuffHighestTime"] = 0;
                }

                if (champObj.AuraInfo[item.ItemId + "BuffCount"] >= item.ItemCounter[item.ItemId + "MinimumBuffs"].Value)
                    if (champObj.AuraInfo[item.ItemId + "BuffHighestTime"] >= item.ItemCounter[item.ItemId + "MinimumBuffsDuration"].Value)
                    {
                        UseItem(item, champObj.Instance);
                        champObj.AuraInfo[item.ItemId + "BuffCount"] = 0;
                        champObj.AuraInfo[item.ItemId + "BuffHighestTime"] = 0;
                    }
            }
        }

        /// <summary>
        ///     Checks the auras per spell
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="hero">The hero.</param>
        /// <returns></returns>
        public static void CheckSpellAuras(this AutoSpell spell, AIHeroClient hero)
        {
            if (spell.ActivationTypes.Contains(ActivationType.CheckAuras))
            {
                var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
                var champObj = Bootstrap.Allies
                    .FirstOrDefault(x => x.Value.Instance.NetworkID == hero.NetworkID).Value;

                if (champObj?.Instance == null)
                    return;

                var healthPct = champObj.Instance.Health / champObj.Instance.MaxHealth * 100;
                if (healthPct > spell.SpellCounter[tabName + "MinimumBuffsHP"].Value &&
                    spell.SpellSwitch[tabName + "SwitchMinimumBuffHP"].IsOn)
                    return;

                champObj.AuraInfo[tabName + "BuffCount"] = GetAuras(spell, champObj).Count();
                champObj.AuraInfo[tabName + "BuffHighestTime"] = 0;

                if (champObj.AuraInfo[tabName + "BuffCount"] > 0)
                {
                    foreach (var buff in GetAuras(spell, champObj))
                    {
                        var length = (int) (buff.EndTime - buff.StartTime);
                        if (length >= champObj.AuraInfo[tabName + "BuffHighestTime"]) champObj.AuraInfo[tabName + "BuffHighestTime"] = length * 1000;
                    }

                    champObj.AuraInfo[tabName + "BuffTimestamp"] = (int) (GameEngine.GameTime * 1000);
                }
                else
                {
                    if (champObj.AuraInfo[tabName + "BuffHighestTime"] > 0)
                        champObj.AuraInfo[tabName + "BuffHighestTime"] -= champObj.AuraInfo[tabName + "BuffHighestTime"];
                    else
                        champObj.AuraInfo[tabName + "BuffHighestTime"] = 0;
                }

                if (champObj.AuraInfo[tabName + "BuffCount"] >= spell.SpellCounter[tabName + "MinimumBuffs"].Value)
                    if (champObj.AuraInfo[tabName + "BuffHighestTime"] >= spell.SpellCounter[tabName + "MinimumBuffsDuration"].Value)
                    {
                        UseSpell(spell, champObj.Instance);
                        champObj.AuraInfo[tabName + "BuffCount"] = 0;
                        champObj.AuraInfo[tabName + "BuffHighestTime"] = 0;
                    }
            }
        }
        
        /// <summary>
        ///     Checks the projection segment.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public static void CheckProjectionSegment(this Champion Champion, AIBaseClient unit)
        {
            // todo: failsafe: need a better way to implement this
            if ((int)(GameEngine.GameTime * 1000) - Champion.AggroTick > 500)
            {
                Champion.ResetAggro();
            }
            
            if (unit.IsAlive)
                if (unit.IsCastingSpell)
                {
                    var currentSpell = unit.GetCurrentCastingSpell();
                    if (currentSpell.SpellData.SpellName is not null)
                    {
                        var gameTime = (int) (GameEngine.GameTime * 1000);
                        var entry = SpellData.HeroSpells
                            .Find(x =>  x.ChampionName.ToLower() == unit.ModelName.ToLower() && 
                                       (x.Slot == currentSpell.SpellSlot ||
                                        x.SpellName.ToLower() == currentSpell.SpellData.SpellName.ToLower()));
                        
                        var heroTargetAggro = currentSpell.Targets.Find(x => x.NetworkID == Champion.Instance.NetworkID) != null;
                        if (heroTargetAggro)
                        {
                            if (entry != null)
                            {
                                Champion.InDanger = entry.EmulationTypes.Contains(EmulationType.Danger);
                                Champion.InCrowdControl = entry.EmulationTypes.Contains(EmulationType.CrowdControl);
                                Champion.InExtremeDanger = entry.EmulationTypes.Contains(EmulationType.Ultimate);
                            }
                            
                            Champion.HasAggro = true;
                            Champion.AggroTick = gameTime;
                        }
                        else
                        {
                            // skillshot projection 
                            var radius = (int) Math.Max(50, currentSpell.SpellData.SpellWidth) + Champion.Instance.UnitComponentInfo.UnitBoundingRadius;
                            var proj = Champion.Instance.Position.ProjectOn(currentSpell.SpellStartPosition, currentSpell.SpellEndPosition);
                            var nearit = Champion.Instance.Position.Distance(proj.SegmentPoint) <= radius;

                            if (proj.IsOnSegment && nearit)
                            {
                                if (entry != null)
                                {
                                    var minions = entry.CollidesWith.Contains(CollisionObjectType.EnemyMinions);
                                    var heroes  = entry.CollidesWith.Contains(CollisionObjectType.EnemyHeroes);
                                    
                                    var collision = proj.GetEnemyUnitsOnSegment(radius, heroes, minions);
                                    if (collision.Any(x => x.NetworkID != Champion.Instance.NetworkID))
                                    {
                                        return;
                                    }
                                }

                                if (entry != null)
                                {
                                    Champion.InDanger = entry.EmulationTypes.Contains(EmulationType.Danger);
                                    Champion.InCrowdControl = entry.EmulationTypes.Contains(EmulationType.CrowdControl);
                                    Champion.InExtremeDanger = entry.EmulationTypes.Contains(EmulationType.Ultimate);
                                }

                                Champion.HasAggro = true;
                                Champion.AggroTick = gameTime;
                            }
                        }
                    }
                }
        }

        #endregion
    }
}