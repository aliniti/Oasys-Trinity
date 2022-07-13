namespace Trinity.Helpers
{
    public enum DangerLevel
    {
        /// <summary>
        ///     The low
        /// </summary>
        Low,

        /// <summary>
        ///     The medium
        /// </summary>
        Medium,

        /// <summary>
        ///     The high
        /// </summary>
        High,

        /// <summary>
        ///     The very high
        /// </summary>
        VeryHigh
    }

    public enum ActivationType
    {
        /// <summary>
        ///     The check of player mana
        /// </summary>
        CheckPlayerMana,

        /// <summary>
        ///     The check if use only on me
        /// </summary>
        CheckOnlyOnMe,

        /// <summary>
        ///     The check if ally low mp
        /// </summary>
        CheckAllyLowMP,

        /// <summary>
        ///     The check if ally low hp
        /// </summary>
        CheckAllyLowHP,

        /// <summary>
        ///     The check if enemy low hp
        /// </summary>
        CheckEnemyLowHP,

        /// <summary>
        ///     The check on auras
        /// </summary>
        CheckAuras,

        /// <summary>
        ///     The check on aoe count
        /// </summary>
        CheckProximityCount,

        /// <summary>
        ///     The check on danger spells
        /// </summary>
        CheckDangerous
    }

    public enum TargetingType
    {
        /// <summary>
        ///     The unit is ally
        /// </summary>
        UnitAlly,

        /// <summary>
        ///     The unit is enemy
        /// </summary>
        UnitEnemy,

        /// <summary>
        ///     The proximity of ally
        /// </summary>
        ProximityAlly,

        /// <summary>
        ///     The proximity of enemy
        /// </summary>
        ProximityEnemy,

        /// <summary>
        ///     The skillshot on ally
        /// </summary>
        SkillshotAlly,

        /// <summary>
        ///     The skillshot on enemy
        /// </summary>
        SkillshotEnemy,

        /// <summary>
        ///     The binding of a unit
        /// </summary>
        BindingUnit
    }
    
    public enum CollisionObjectType
    {
        /// <summary>
        ///     The ally heroes
        /// </summary>
        AllyHeroes,

        /// <summary>
        ///     The enemy heroes
        /// </summary>
        EnemyHeroes,

        /// <summary>
        ///     The ally minions
        /// </summary>
        AllyMinions,

        /// <summary>
        ///     The enemy minions
        /// </summary>
        EnemyMinions,

        /// <summary>
        ///     The terrain
        /// </summary>
        Terrain
    }
    
    public enum CastType
    {
        /// <summary>
        ///     The none
        /// </summary>
        None,

        /// <summary>
        ///     The linear
        /// </summary>
        Linear,

        /// <summary>
        ///     The missile linear
        /// </summary>
        MissileLinear,

        /// <summary>
        ///     The linear ao e
        /// </summary>
        LinearAoE,

        /// <summary>
        ///     The missile linear ao e
        /// </summary>
        MissileLinearAoE,

        /// <summary>
        ///     The proximity
        /// </summary>
        Proximity,

        /// <summary>
        ///     The targeted
        /// </summary>
        Targeted,

        /// <summary>
        ///     The circlular
        /// </summary>
        Circlular,

        /// <summary>
        ///     The sector
        /// </summary>
        Sector
    }
    
    public enum EmulationType
    {
        /// <summary>
        ///     The none
        /// </summary>
        None,

        /// <summary>
        ///     The automatic attack
        /// </summary>
        AutoAttack,

        /// <summary>
        ///     The minion attack
        /// </summary>
        MinionAttack,

        /// <summary>
        ///     The turret attack
        /// </summary>
        TurretAttack,

        /// <summary>
        ///     The spell
        /// </summary>
        Spell,

        /// <summary>
        ///     The danger
        /// </summary>
        Danger,

        /// <summary>
        ///     The ultimate
        /// </summary>
        Ultimate,

        /// <summary>
        ///     The crowd control
        /// </summary>
        CrowdControl,

        /// <summary>
        ///     The stealth
        /// </summary>
        Stealth,

        /// <summary>
        ///     The force exhaust
        /// </summary>
        ForceExhaust,

        /// <summary>
        ///     The initiator
        /// </summary>
        Initiator,

        /// <summary>
        ///     The gapcloser
        /// </summary>
        Gapcloser,

        /// <summary>
        ///     The emitter
        /// </summary>
        Emitter,

        /// <summary>
        ///     The item
        /// </summary>
        Item,

        /// <summary>
        ///     The buff
        /// </summary>
        Buff
    }
}