﻿namespace Trinity.Helpers
{
    #region

    using Base;
    using Items;
    using Spells;
    
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Oasys.Common;
    using Oasys.Common.Logic;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.GameObject.Clients.ExtendedInstances;
    using Oasys.SDK;
    using Oasys.SDK.SpellCasting;

    #endregion

    public static class Utils
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Resets the champion aggro values
        /// </summary>
        /// <param name="hero">The hero.</param>
        public static void ResetAggro(this Champion hero)
        {
            hero.AggroTick = 0;
            hero.InDanger = false;
            hero.InCrowdControl = false;
            hero.InExtremeDanger = false;
            hero.PredictionFlags.Clear();
        }

        /// <summary>
        ///     Checks if the enemy exists by string
        /// </summary>
        /// <param name="champion">The champion name.</param>
        /// <returns></returns>
        public static bool EnemyExists(this string champion)
        {
            return EnemyExistsExport(champion) || UnitManager.Enemies.Any(x => x.ModelName.ToLower() == champion.ToLower());
        }

        /// <summary>
        ///     Checks if the enemy exists by string
        /// </summary>
        /// <param name="champion">The champion name.</param>
        /// <returns></returns>
        public static bool EnemyExistsExport(this string champion)
        {
            return ObjectManagerExport.HeroCollection.Values.Any(x => x.IsEnemy && x.ModelName.ToLower() == champion.ToLower());
        }

        /// <summary>
        ///     Checks if the hero has the buff of type
        /// </summary>
        /// <param name="hero">The hero.</param>
        /// <param name="type">The buff type.</param>
        /// <returns></returns>
        public static bool HasBuffOfType(this AIHeroClient hero, BuffType type)
        {
            return hero.BuffManager.GetBuffList().FirstOrDefault(x =>  x.IsActive && x.EntryType == type) != null;
        }

        /// <summary>
        ///     Gets the hero by index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static AIBaseClient GetHeroByIndex(short index)
        {
            return ObjectManagerExport.HeroCollection.Values.FirstOrDefault(v => v.Index == index);
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

        public static List<AIBaseClient> GetAllyUnitsOnSegment(this Oasys.Common.Logic.Geometry.ProjectionInfo proj, float radius, bool heroes, bool minions)
        {
            var objList = new List<AIBaseClient>();

            foreach (var u in ObjectManagerExport.HeroCollection)
            {
                var unit = u.Value;
                if (unit.IsValidTarget(float.MaxValue, false) && heroes)
                {
                    var nearit = unit.Position.Distance(proj.SegmentPoint) <= radius;
                    if (nearit && unit.IsAlly)
                        objList.Add(unit);
                }
            }

            foreach (var u in ObjectManagerExport.MinionCollection)
            {
                var minion = u.Value;
                if (minion.IsValidTarget(float.MaxValue, false) && minions)
                {
                    var nearit = minion.Position.Distance(proj.SegmentPoint) <= radius;
                    if (nearit && minion.IsAlly)
                        objList.Add(minion);
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
        public static void CheckItemDangerousSpells(this ActiveItem item, Champion champion, AIBaseClient enemy = null)
        {
            if (item.ActivationTypes.Contains(ActivationType.CheckDangerous))
            {
                if (item.ItemSwitch[item.ItemId + "dangerextr"].IsOn)
                    if (champion.HasAggro() && champion.InExtremeDanger)
                        UseItem(item, enemy ?? champion.Instance);

                if (item.ItemSwitch[item.ItemId + "dangercc"].IsOn)
                    if (champion.HasAggro() && champion.InCrowdControl)
                        UseItem(item, enemy ?? champion.Instance);

                if (item.ItemSwitch[item.ItemId + "dangernorm"].IsOn)
                    if (champion.HasAggro() && champion.InDanger)
                        UseItem(item, enemy ?? champion.Instance);
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
        public static void CheckSpellDangerousSpells(this AutoSpell spell, Champion champion, AIBaseClient enemy = null)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;

            if (spell.ActivationTypes.Contains(ActivationType.CheckDangerous))
            {
                if (spell.SpellSwitch[tabName + "dangerextr"].IsOn)
                    if (champion.HasAggro() && champion.InExtremeDanger)
                        UseSpell(spell, enemy ?? champion.Instance);

                if (spell.SpellSwitch[tabName + "dangercc"].IsOn)
                    if (champion.HasAggro() && champion.InCrowdControl)
                        UseSpell(spell, enemy ?? champion.Instance);

                if (spell.SpellSwitch[tabName + "dangernorm"].IsOn)
                    if (champion.HasAggro() && champion.InDanger)
                        UseSpell(spell, enemy ?? champion.Instance);
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
            {
                if (hero.IsRecalling() || hero.IsCastingSpell /*|| hero.IsEmpoweredRecalling*/
                    || hero.IsChanneling)
                    return false;

                if (hero.HasBuffOfType(BuffType.Invisibility)
                    || hero.HasBuffOfType(BuffType.Invulnerability))
                    return false;
            }

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
        public static bool UseItem(this ActiveItem item, AIBaseClient unit)
        {
            if (!IsSafeCast(unit)) return false;
            if ((int) (GameEngine.GameTime * 1000) - Bootstrap.LastActivationTs < 750) return false;

            if (item.TargetingType.ToString().Contains("Proximity"))
                if (item.SpellClass.IsSpellReady)
                {
                    ItemCastProvider.CastItem(item.ItemId);
                    Bootstrap.LastActivationTs = (int) (GameEngine.GameTime * 1000);
                    return true;
                }

            if (item.TargetingType.ToString().Contains("Unit"))
                if (unit != null && item.SpellClass.IsSpellReady)
                {
                    ItemCastProvider.CastItem(item.ItemId, unit.Position);
                    Bootstrap.LastActivationTs = (int) (GameEngine.GameTime * 1000);
                    return true;
                }

            if (item.TargetingType.ToString().Contains("Skillshot"))
                if (unit != null && item.SpellClass.IsSpellReady)
                {
                    ItemCastProvider.CastItem(item.ItemId, unit.Position);
                    Bootstrap.LastActivationTs = (int) (GameEngine.GameTime * 1000);
                    return true;
                }

            return false;
        }

        /// <summary>
        ///     Uses the spell.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="unit">The unit.</param>
        /// <returns></returns>
        public static bool UseSpell(this AutoSpell spell, AIBaseClient unit)
        {
            if (!IsSafeCast(unit)) return false;
            if ((int) (GameEngine.GameTime * 1000) - Bootstrap.LastActivationTs < 750) return false;

            if (spell.TargetingType.ToString().Contains("Dodge"))
            {
                UseSpellOnBestTarget(spell, unit);
                return true;
            }

            if (spell.TargetingType.ToString().Contains("Proximity"))
                if (spell.SpellClass.IsSpellReady)
                {
                    SpellCastProvider.CastSpell(spell.Slot);
                    Bootstrap.LastActivationTs = (int) (GameEngine.GameTime * 1000);
                    return true;
                }

            if (spell.TargetingType.ToString().Contains("Unit"))
                if (unit != null && spell.SpellClass.IsSpellReady)
                {
                    SpellCastProvider.CastSpell(spell.Slot, unit.Position);
                    Bootstrap.LastActivationTs = (int) (GameEngine.GameTime * 1000);
                    return true;
                }

            if (spell.TargetingType.ToString().Contains("Skillshot"))
                if (unit != null && spell.SpellClass.IsSpellReady)
                {
                    SpellCastProvider.CastSpell(spell.Slot, unit.IsMe
                        ? GameEngine.WorldMousePosition
                        : unit.Position);

                    Bootstrap.LastActivationTs = (int) (GameEngine.GameTime * 1000);
                    return true;
                }

            return false;
        }

        /// <summary>
        ///     Use the spell on the best given target
        /// </summary>
        /// <param name="spell">The autospell.</param>
        /// <param name="hero">The hero.</param>
        public static void UseSpellOnBestTarget(this AutoSpell spell, AIBaseClient hero)
        {
            if (!spell.SpellClass.IsSpellReady) return;

            var units = new List<AIBaseClient>();
            var myHero = ObjectManagerExport.LocalPlayer;

            units.Clear();

            switch (spell.TargetingType)
            {
                case TargetingType.DodgeEnemyUnit:
                case TargetingType.DodgeEnemySkillshot:
                    units.AddRange(UnitManager.EnemyChampions.Where(x => x.Distance(hero) <= spell.Range));
                    break;
                case TargetingType.DodgeEnemyUnitOrMinion:
                    units.AddRange(UnitManager.EnemyChampions.Where(x => x.Distance(hero) <= spell.Range));
                    units.AddRange(UnitManager.EnemyMinions.Where(x => x.Distance(hero) <= spell.Range));
                    break;
            }
            
            var sortedList =
                units.Where(x => x.IsValidTarget(spell.Range))
                    .OrderBy(x => x is AIMinionClient)
                    .ThenBy(x => x.Health / x.MaxHealth * 100)
                    .ThenBy(x => x.Distance(myHero));

            var tar = sortedList.FirstOrDefault();
            if (tar != null && IsSafeCast(tar))
            {
                SpellCastProvider.CastSpell(spell.Slot, tar.Position);
                Bootstrap.LastActivationTs = (int) (GameEngine.GameTime * 1000);
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
                .Where(buff => (buff.IsActive && buff.Stacks > 0 && buff.Name != "UnknownBuff" &&
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
                .Where(buff => (buff.IsActive && buff.Stacks > 0 && buff.Name != "UnknownBuff" &&
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
        public static void CheckItemAuras(this ActiveItem item, Champion hero)
        {
            if (item.ActivationTypes.Contains(ActivationType.CheckAuras))
            {
                var healthPct = hero.Instance.Health / hero.Instance.MaxHealth * 100;
                if (healthPct > item.ItemCounter[item.ItemId + "MinimumBuffsHP"].Value &&
                    item.ItemSwitch[item.ItemId + "SwitchMinimumBuffHP"].IsOn)
                    return;

                hero.AuraInfo[item.ItemId + "BuffCount"] = GetAuras(item, hero).Count();
                hero.AuraInfo[item.ItemId + "BuffHighestTime"] = 0;

                if (hero.AuraInfo[item.ItemId + "BuffCount"] > 0)
                {
                    foreach (var buff in GetAuras(item, hero))
                    {
                        var length = (int) (buff.EndTime - buff.StartTime);
                        if (length >= hero.AuraInfo[item.ItemId + "BuffHighestTime"])
                        {
                            hero.AuraInfo[item.ItemId + "BuffHighestTime"] = length * 1000;
                        }
                    }

                    hero.AuraInfo[item.ItemId + "BuffTimestamp"] = (int) (GameEngine.GameTime * 1000);
                }
                else
                {
                    switch (hero.AuraInfo[item.ItemId + "BuffHighestTime"])
                    {
                        case > 0:
                            hero.AuraInfo[item.ItemId + "BuffHighestTime"] -= hero.AuraInfo[item.ItemId + "BuffHighestTime"];
                            break;
                        default:
                            hero.AuraInfo[item.ItemId + "BuffHighestTime"] = 0;
                            break;
                    }
                }

                if (hero.AuraInfo[item.ItemId + "BuffCount"] < item.ItemCounter[item.ItemId + "MinimumBuffs"].Value) return;
                if (hero.AuraInfo[item.ItemId + "BuffHighestTime"] >= item.ItemCounter[item.ItemId + "MinimumBuffsDuration"].Value)
                {
                    if (UseItem(item, hero.Instance))
                    {
                        hero.AuraInfo[item.ItemId + "BuffCount"] = 0;
                        hero.AuraInfo[item.ItemId + "BuffHighestTime"] = 0;
                    }
                }
            }
        }

        /// <summary>
        ///     Checks the auras per spell
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="hero">The hero.</param>
        /// <returns></returns>
        public static void CheckSpellAuras(this AutoSpell spell, Champion hero)
        {
            if (spell.ActivationTypes.Contains(ActivationType.CheckAuras))
            {
                var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
                
                var healthPct = hero.Instance.Health / hero.Instance.MaxHealth * 100;
                if (healthPct > spell.SpellCounter[tabName + "MinimumBuffsHP"].Value &&
                    spell.SpellSwitch[tabName + "SwitchMinimumBuffHP"].IsOn)
                    return;

                hero.AuraInfo[tabName + "BuffCount"] = GetAuras(spell, hero).Count();
                hero.AuraInfo[tabName + "BuffHighestTime"] = 0;

                if (hero.AuraInfo[tabName + "BuffCount"] > 0)
                {
                    foreach (var buff in GetAuras(spell, hero))
                    {
                        var length = (int) (buff.EndTime - buff.StartTime);
                        if (length >= hero.AuraInfo[tabName + "BuffHighestTime"]) hero.AuraInfo[tabName + "BuffHighestTime"] = length * 1000;
                    }

                    hero.AuraInfo[tabName + "BuffTimestamp"] = (int) (GameEngine.GameTime * 1000);
                }
                else
                {
                    switch (hero.AuraInfo[tabName + "BuffHighestTime"])
                    {
                        case > 0:
                            hero.AuraInfo[tabName + "BuffHighestTime"] -= hero.AuraInfo[tabName + "BuffHighestTime"];
                            break;
                        default:
                            hero.AuraInfo[tabName + "BuffHighestTime"] = 0;
                            break;
                    }
                }

                if (hero.AuraInfo[tabName + "BuffCount"] < spell.SpellCounter[tabName + "MinimumBuffs"].Value) return;
                if (hero.AuraInfo[tabName + "BuffHighestTime"] >= spell.SpellCounter[tabName + "MinimumBuffsDuration"].Value)
                {
                    if (UseSpell(spell, hero.Instance))
                    {
                        hero.AuraInfo[tabName + "BuffCount"] = 0;
                        hero.AuraInfo[tabName + "BuffHighestTime"] = 0;
                    }
                }
            }
        }

        public static bool CheckMissileSegment(this Champion hero, AIBaseClient unit)
        {
            if (unit == null) return false;
            
            // todo: failsafe: need a better way to implement this
            if ((int) (GameEngine.GameTime * 1000) - hero.AggroTick > 500)
                hero.ResetAggro();
            
            if (!unit.IsObject(ObjectTypeFlag.AIMissileClient)) return false;

            var missile = unit.As<AIMissileClient>();
            if (missile is null) return false;

            var uRadius = unit.UnitComponentInfo.UnitBoundingRadius;
            var cRadius = hero.Instance.UnitComponentInfo.UnitBoundingRadius;

            var source = GetHeroByIndex(missile.SourceIndex);
            if (source == null) return false;

            var gameTime = (int) (GameEngine.GameTime * 1000);
            if (missile.SpellData.SpellWidth < 1) return false;
            
            SpellData entry = null;
            foreach (var x in SpellData.HeroSpells)
            {
                if (x.ChampionName.ToLower() != source.ModelName.ToLower())
                    continue;

                if (x.MissileName.ToLower() == missile.Name.ToLower())
                {
                    entry = x;
                    break;
                }

                if (x.ExtraMissileNames.Any(y => missile.Name.ToLower() == y.ToLower()))
                {
                    entry = x;
                    break;
                }
            }
            
            var startPos = missile.StartPosition.ToVector2();
            var endPos = missile.EndPosition.ToVector2();
            var direction = (endPos - startPos).Normalized();
            var radius = (int) Math.Max(50, missile.SpellData.SpellWidth) + cRadius;

            var pInfo = hero.Instance.Position.ToVector2().ProjectOn(startPos, endPos);
            var nearSegment = hero.Instance.Position.Distance(pInfo.SegmentPoint) <= radius;

            if (!pInfo.IsOnSegment || !nearSegment) return false;
            if (entry != null)
            {
                var minions = entry.CollidesWith.Contains(CollisionObjectType.EnemyMinions);
                var heroes  = entry.CollidesWith.Contains(CollisionObjectType.EnemyHeroes);

                var collision = pInfo.GetAllyUnitsOnSegment(radius, heroes, minions);
                if (collision.Any(x => x.NetworkID != hero.Instance.NetworkID))
                    return false;

                hero.InDanger = entry.EmuFlags.Contains(EmulationFlags.Danger);
                hero.InCrowdControl = entry.EmuFlags.Contains(EmulationFlags.CrowdControl);
                hero.InExtremeDanger = entry.EmuFlags.Contains(EmulationFlags.Ultimate);
            }
                
            hero.AggroTick = gameTime;
            return true;
        }
        
        /// <summary>
        ///     Checks the projection segment.
        /// </summary>
        /// <param name="hero">The champion</param>
        /// <param name="unit">The unit.</param>
        public static bool CheckProjectionSegment(this Champion hero, AIBaseClient unit)
        {
            if (unit == null) return false;
            
            // todo: failsafe: need a better way to implement this
            if ((int) (GameEngine.GameTime * 1000) - hero.AggroTick > 500)
                hero.ResetAggro();

            if (!unit.IsAlive) return false;
            if (!unit.IsCastingSpell) return false;
            
            var uRadius = unit.UnitComponentInfo.UnitBoundingRadius;
            var cRadius = hero.Instance.UnitComponentInfo.UnitBoundingRadius;

            var currentSpell = unit.GetCurrentCastingSpell();
            var name = currentSpell.SpellData.SpellName;
            if (name is null) return false;
            
            var gameTime = (int) (GameEngine.GameTime * 1000);
            SpellData entry = null;
            
            foreach (var x in SpellData.HeroSpells)
            {
                if (x.ChampionName.ToLower() != unit.ModelName.ToLower()) continue;
                if (x.Slot == currentSpell.SpellSlot || x.SpellName.ToLower() == name.ToLower())
                {
                    entry = x;
                    break;
                }
            }

            var heroTargetAggro = currentSpell.Targets.Find(x => x.NetworkID == hero.Instance.NetworkID) != null;
            if (heroTargetAggro)
            {
                if (entry != null)
                {
                    hero.InDanger = entry.EmuFlags.Contains(EmulationFlags.Danger);
                    hero.InCrowdControl = entry.EmuFlags.Contains(EmulationFlags.CrowdControl);
                    hero.InExtremeDanger = entry.EmuFlags.Contains(EmulationFlags.Ultimate);
                }
                
                hero.AggroTick = gameTime;
            }
            else
            {
                var startPos = currentSpell.SpellStartPosition.ToVector2();
                var endPos = currentSpell.SpellEndPosition.ToVector2();
                var direction = (endPos - startPos).Normalized();
                var radius = (int) Math.Max(50, currentSpell.SpellData.SpellWidth) + cRadius;

                if (entry != null)
                {
                    if (startPos.Distance(endPos) > entry.CastRange)
                        endPos = startPos + direction * entry.CastRange;
                }

                var pInfo = hero.Instance.Position.ToVector2().ProjectOn(startPos, endPos);
                var nearSegment = hero.Instance.Position.Distance(pInfo.SegmentPoint) <= radius;
                
                if (!pInfo.IsOnSegment || !nearSegment) return false;
                if (entry != null)
                {
                    var minions = entry.CollidesWith.Contains(CollisionObjectType.EnemyMinions);
                    var heroes  = entry.CollidesWith.Contains(CollisionObjectType.EnemyHeroes);

                    var collision = pInfo.GetAllyUnitsOnSegment(radius, heroes, minions);
                    if (collision.Any(x => x.NetworkID != hero.Instance.NetworkID))
                        return false;

                    hero.InDanger = entry.EmuFlags.Contains(EmulationFlags.Danger);
                    hero.InCrowdControl = entry.EmuFlags.Contains(EmulationFlags.CrowdControl);
                    hero.InExtremeDanger = entry.EmuFlags.Contains(EmulationFlags.Ultimate);
                }
                
                hero.AggroTick = gameTime;
            }

            return true;
        }

        #endregion
    }
}