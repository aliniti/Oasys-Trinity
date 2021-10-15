#region Copyright © 2021 Kurisu Solutions
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//       Document:	Helpers\Enums.cs
//       Date:		10/14/2021
//       Author:	Robin Kurisu
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see http://www.gnu.org/licenses/
#endregion

namespace Trinity.Helpers
{
    public class Enums
    {
        public enum ActivationType
        {
            PostAttack,
            CheckEnemyProximity,
            CheckOnlyOnMe,
            CheckAllyLowMP,
            CheckAllyLowHP,
            CheckEnemyLowHP,
            CheckAuras
        }

        public enum AutoSpellType
        {
            Evade,
            Gapclose,
            Heal,
            LowHealth,
            Shield,
            Slow
        }

        public enum CastType
        {
            Unknown,
            Linear,
            MissileLinear,
            LinearAoE,
            MissileLinearAoE,
            Proximity,
            Targeted,
            Circular,
            Sector
        }

        public enum CollisionObjectType
        {
            AllyHeroes,
            EnemyHeroes,
            AllyMinions,
            EnemyMinions,
            Terrain
        }

        public enum ConsumableItemType
        {
            MP,
            HP,
            Both,
            Instant
        }

        public enum EmulationType
        {
            None,
            AutoAttack,
            MinionAttack,
            TurretAttack,
            Spell,
            MissileSpell,
            Danger,
            Ultimate,
            CrowdControl,
            Stealth,
            ForceExhaust,
            Initiator,
            Gapcloser,
            Emitter,
            Item,
            Buff
        }

        public enum OffensiveItemTypes
        {
            Evade,
            Gapclose,
            Heal,
            LowHealth,
            Shield,
            Slow
        }

        public enum SmiteType
        {
            Basic,
            RedSmite,
            BlueSmite
        }

        public enum TargetingType
        {
            UnitAlly,
            UnitEnemy,
            ProximityAlly,
            ProximityEnemy,
            SkillshotAlly,
            SkillshotEnemy
        }
    }
}