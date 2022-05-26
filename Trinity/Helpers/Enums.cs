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
        CheckDanger
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
        BindingUnit,
    }
}