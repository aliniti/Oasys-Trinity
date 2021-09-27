namespace ProSeries.Damage
{
    using System;
    using System.Linq;
    using Oasys.Common;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.Logic;
    using static Oasys.Common.Logic.DamageType;

    public static class Damage
    {
        #region Public Methods and Operators

        public static double CalculateDamage(this AIBaseClient source, AIBaseClient target, DamageType damageType,
            double amount)
        {
            var damage = damageType switch
            {
                Magical => source.CalculateMagicDamage(target, amount),
                Physical => source.CalculatePhysicalDamage(target, amount),
                True => Math.Floor(source.PassivePercentMod(target, Math.Max(amount, 0), True)),
                _ => 0d
            };

            return damage;
        }

        public static double CalculateMixedDamage(this AIBaseClient source, AIBaseClient target, double physicalAmount,
            double magicalAmount)
        {
            return source.CalculatePhysicalDamage(target, physicalAmount)
                   + source.CalculateMagicDamage(target, magicalAmount);
        }

        #endregion

        #region Methods

        internal static double CalculatePhysicalDamage(this AIBaseClient source, AIBaseClient target, double amount,
            double ignoreArmorPercent)
        {
            return source.CalculatePhysicalDamage(target, amount) * ignoreArmorPercent;
        }

        private static double CalculateMagicDamage(this AIBaseClient source, AIBaseClient target, double amount)
        {
            if (amount <= 0) return 0;

            // Penetration can't reduce magic resist below 0.
            var magicResist = target.UnitStats.MagicResist;
            var bonusMagicResist = target.UnitStats.BonusMagicResist;

            double value, flatValue = 0d;

            if (magicResist < 0)
                value = 2 - 100 / (100 - magicResist);
            else if (magicResist * source.UnitStats.MagicPercentPenetration
                - bonusMagicResist * (1 - source.UnitStats.PercentBonusMagicPenetration)
                - source.UnitStats.FlatMagicPenetration - source.UnitStats.MagicLethality < 0)
                value = 1;
            else
                value = 100 / (100 + magicResist * source.UnitStats.MagicPercentPenetration
                               - bonusMagicResist * (1 - source.UnitStats.PercentBonusMagicPenetration)
                               - source.UnitStats.FlatMagicPenetration - source.UnitStats.MagicLethality);

            // Amumu P
            if (target.BuffManager.HasBuff("cursedtouch")) flatValue = 0.1 * amount;

            return
                Math.Max(
                    Math.Floor(
                        source.DamageReductionMod(
                            target,
                            source.PassivePercentMod(target, value, Magical) * amount,
                            Magical)) + flatValue,
                    0);
        }

        private static double CalculatePhysicalDamage(this AIBaseClient source, AIBaseClient target, double amount)
        {
            if (amount <= 0) return 0;

            double armorPenetrationPercent = source.UnitStats.ArmorPercentPentration;
            double armorPenetrationFlat = source.UnitStats.FlatArmorPenetration + source.UnitStats.PhysicalLethality;
            double bonusArmorPenetrationMod = source.UnitStats.PercentBonusArmorPenetration;

            // Minions return wrong percent values.
            if (source is AIMinionClient)
            {
                armorPenetrationFlat = 0;
                armorPenetrationPercent = 1;
                bonusArmorPenetrationMod = 1;
            }

            // Turrets passive.
            var turret = source as AIPlacementClient;
            if (turret != null)
            {
                armorPenetrationFlat = 0;
                armorPenetrationPercent = 0.7;
                bonusArmorPenetrationMod = 1;
            }

            // Penetration can't reduce armor below 0.
            var armor = target.Armor;
            var bonusArmor = target.UnitStats.BonusArmor;

            double value;
            if (armor < 0)
                value = 2 - 100 / (100 - armor);
            else if (armor * armorPenetrationPercent - bonusArmor * (1 - bonusArmorPenetrationMod)
                                                     - armorPenetrationFlat < 0)
                value = 1;
            else
                value = 100
                        / (100 + armor * armorPenetrationPercent - bonusArmor * (1 - bonusArmorPenetrationMod)
                                                                 - armorPenetrationFlat);

            // Take into account the percent passives, flat passives and damage reduction.
            return
                Math.Max(
                    Math.Floor(
                        source.DamageReductionMod(
                            target,
                            source.PassivePercentMod(target, value, Physical) * amount,
                            Physical)),
                    0);
        }

        private static double DamageReductionMod(
            this AIBaseClient source,
            AIBaseClient target,
            double amount,
            DamageType damageType)
        {
            var targetHero = target as AIHeroClient;
            var targetMinion = target as AIMinionClient;
            var sourceMinion = source as AIMinionClient;

            if (targetHero != null && source is AIMinionClient && source.Team == TeamFlag.Neutral)
                // Ancient Grudge
                if (new[]
                {
                    "SRU_Dragon_Air", "SRU_Dragon_Earth",
                    "SRU_Dragon_Fire", "SRU_Dragon_Water"
                }.Any(i => i.Equals(source.ModelName)))
                {
                    var dragonBuff = targetHero.BuffManager.GetBuffByName("dragonbuff_tooltipmanager");
                    // if (dragonBuff != null) amount *= 1 + 0.2 * dragonBuff.ToolTipVars.Take(4).Sum();
                }

            if (source is AIHeroClient)
            {
                if (target is AIMinionClient && target.Team == TeamFlag.Neutral)
                {
                    // Baron's Gaze
                    if (source.BuffManager.HasBuff("barontarget") && target.ModelName.Equals("SRU_Baron"))
                        amount *= 0.5;

                    // Ancient Grudge
                    if (new[] {"SRU_Dragon_Air", "SRU_Dragon_Earth", "SRU_Dragon_Fire", "SRU_Dragon_Water"}.Any(i =>
                        i.Equals(target.ModelName)))
                    {
                        var dragonBuff = source.BuffManager.GetBuffByName("dragonbuff_tooltipmanager");
                        //if (dragonBuff != null) amount *= 1 - 0.07 * dragonBuff.ToolTipVars.Take(4).Sum();
                    }

                    // Shyvana P
                    if (source.BuffManager.HasBuff("shyvanapassive")
                        && new[]
                        {
                            "SRU_Dragon_Air", "SRU_Dragon_Earth", "SRU_Dragon_Fire", "SRU_Dragon_Water",
                            "SRU_Dragon_Elder", "TT_Spiderboss"
                        }.Any(i => i.Equals(target.ModelName)))
                        amount *= 1.2;
                }

                // Exhaust
                if (source.BuffManager.HasBuff("SummonerExhaust")) amount *= 0.6;
            }

            // Vladimir R.P
            if (target.BuffManager.HasBuff("vladimirhemoplaguedamageamp")) amount *= 1.1;

            // Sona W
            var sonaW = source.BuffManager.GetBuffByName("sonapassivedebuff");
            if (sonaW != null)
            {
                var sona = (AIHeroClient) sonaW.GetOwnerObject();
                amount *= 1 - 0.25
                            - 0.04 * sona.UnitStats.TotalMagicDamage / 100;
            }

            // Hand of Baron
            if (targetMinion != null && targetMinion.BuffManager.HasBuff("exaltedwithbaronnashorminion"))
                switch (targetMinion.CombatType)
                {
                    case CombatTypes.Ranged:
                        if (source is AIHeroClient)
                            amount *= 0.3;
                        break;
                    case CombatTypes.Melee:
                        if (source is AIHeroClient)
                            amount *= 0.3;
                        if (source is AIMinionClient && source.Team != TeamFlag.Neutral)
                            amount *= 0.25;
                        break;
                }

            if (sourceMinion != null
                && target is AIPlacementClient
                && sourceMinion.ModelName.Contains("Seige")
                && sourceMinion.BuffManager.HasBuff("exaltedwithbaronnashorminion"))
                amount *= 2;

            if (targetHero != null)
            {
                // Alistar R
                if (targetHero.BuffManager.HasBuff("FerociousHowl"))
                    amount *= 1 -
                              new[] {0.55, 0.65, 0.75}[targetHero.GetSpellBook().GetSpellClass(SpellSlot.R).Level - 1];

                // Amumu E
                if (targetHero.BuffManager.HasBuff("Tantrum") && damageType == Physical)
                    amount -= new[] {2, 4, 6, 8, 10}[targetHero.GetSpellBook().GetSpellClass(SpellSlot.E).Level - 1]
                              + 0.03 * targetHero.UnitStats.BonusArmor
                              + 0.03 * targetHero.UnitStats.BonusMagicResist;
                // Annie E
                if (targetHero.BuffManager.HasBuff("AnnieE"))
                    amount *= 1 -
                              new[] {0.16, 0.22, 0.28, 0.34, 0.4}[
                                  targetHero.GetSpellBook().GetSpellClass(SpellSlot.E).Level - 1];
                // Braum E
                if (targetHero.BuffManager.HasBuff("braumeshieldbuff"))
                    amount *= 1 -
                              new[] {0.3, 0.325, 0.35, 0.375, 0.4}
                                  [targetHero.GetSpellBook().GetSpellClass(SpellSlot.E).Level - 1];
                // Galio W
                if (targetHero.BuffManager.HasBuff("galiowbuff"))
                {
                    var percent =
                        new[] {0.2, 0.25, 0.3, 0.35, 0.4}[
                            targetHero.GetSpellBook().GetSpellClass(SpellSlot.W).Level - 1]
                        + 0.05 * targetHero.UnitStats.TotalMagicDamage / 100
                        + 0.08 * targetHero.UnitStats.BonusMagicResist / 100;
                    amount *= 1 - (damageType == Magical ? percent :
                        damageType == Physical ? percent / 2 : 0);
                }

                // Garen W
                var garenW = targetHero.BuffManager.GetBuffByName("GarenW");
                if (garenW != null) amount *= 1 - (EngineManager.GameTime - garenW.StartTime < 0.75 ? 0.6 : 0.3);

                // Gragas W
                if (targetHero.BuffManager.HasBuff("gragaswself"))
                    amount *= 1 - new[] {0.1, 0.12, 0.14, 0.16, 0.18}
                                    [targetHero.GetSpellBook().GetSpellClass(SpellSlot.W).Level - 1]
                                - 0.04 * targetHero.UnitStats.TotalMagicDamage / 100;
                // Irelia W
                if (targetHero.BuffManager.HasBuff("ireliawdefense") && damageType == Physical)
                    amount *= 1 - 0.5
                                - 0.07 * targetHero.UnitStats.TotalMagicDamage / 100;
                // Kassadin P
                if (targetHero.BuffManager.HasBuff("voidstone") && damageType == Magical) amount *= 1 - 0.15;

                // MasterYi W
                if (targetHero.BuffManager.HasBuff("Meditate"))
                    amount *= 1 -
                              new[] {0.6, 0.625, 0.65, 0.675, 0.7}[
                                  targetHero.GetSpellBook().GetSpellClass(SpellSlot.W).Level - 1]
                              * (source is AIPlacementClient ? 0.5 : 1);
                // Warwick E
                if (targetHero.BuffManager.HasBuff("WarwickE"))
                    amount *= 1 -
                              new[] {0.35, 0.4, 0.45, 0.5, 0.55}[
                                  targetHero.GetSpellBook().GetSpellClass(SpellSlot.E).Level - 1];
            }

            return amount;
        }

        private static double PassivePercentMod(this AIBaseClient source, AIBaseClient target, double amount,
            DamageType damageType)
        {
            return amount;
        }

        #endregion
    }
}