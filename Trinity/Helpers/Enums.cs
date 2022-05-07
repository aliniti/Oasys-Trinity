namespace Trinity.Helpers
{
    public class Enums
    {
        public enum ActivationType
        {
            CheckPlayerMana,
            CheckOnlyOnMe,
            CheckAllyLowMP,
            CheckAllyLowHP,
            CheckEnemyLowHP,
            CheckAuras,
            CheckAoECount
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