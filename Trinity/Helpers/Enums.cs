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
        /// <summary>
        /// The item activation type
        /// </summary>
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

        /// <summary>
        /// The auto spell type (not yet implemented)
        /// </summary>
        public enum AutoSpellType
        {
            Evade,
            Gapclose,
            Heal,
            LowHealth,
            Shield,
            Slow
        }

        /// <summary>
        /// The spell cast type (not yet implemented)
        /// </summary>
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

        /// <summary>
        /// The collision object type (not yet implemented)
        /// </summary>
        public enum CollisionObjectType
        {
            AllyHeroes,
            EnemyHeroes,
            AllyMinions,
            EnemyMinions,
            Terrain
        }

        /// <summary>
        /// The consumable item type (not yet implemented)
        /// </summary>
        public enum ConsumableItemType
        {
            MP,
            HP,
            Both,
            Instant
        }

        /// <summary>
        /// The emulation type (not yet implemented)
        /// </summary>
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

        /// <summary>
        /// The offensive item type (not yet implemented)
        /// </summary>
        public enum OffensiveItemTypes
        {
            Evade,
            Gapclose,
            Heal,
            LowHealth,
            Shield,
            Slow
        }

        /// <summary>
        /// The smite type (not yet implemented)
        /// </summary>
        public enum SmiteType
        {
            Basic,
            RedSmite,
            BlueSmite
        }

        /// <summary>
        /// The targeting type
        /// </summary>
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