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