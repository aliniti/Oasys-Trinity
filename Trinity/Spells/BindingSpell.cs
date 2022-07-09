namespace Trinity.Spells
{
    #region

    using System.Linq;
    using Helpers;
    using Oasys.Common.Extensions;
    using Oasys.SDK.SpellCasting;

    #endregion

    internal class BindingSpell : AutoSpell
    {
        #region Properties and Encapsulation

        public string BoundBuffName { get; set; }

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BindingUnit" /> class.
        /// </summary>
        /// <param name="usePct">The use PCT.</param>
        /// <param name="championName">Name of the champion.</param>
        /// <param name="castSlot">The cast slot.</param>
        /// <param name="targetingType">Type of the targeting.</param>
        /// <param name="range">The range.</param>
        /// <param name="activationTypes">The activation types.</param>
        public BindingSpell(int usePct, string championName, string boundBuffName, CastSlot castSlot, TargetingType targetingType, float range,
            ActivationType[] activationTypes)
            : base(usePct, championName, castSlot, targetingType, range, activationTypes)
        {
            BoundBuffName = boundBuffName;
        }

        #endregion

        #region Override Methods

        /// <summary>
        ///     Called when [OnTick].
        /// </summary>
        public override void OnTick()
        {
            var tabName = IsSummonerSpell
                ? ChampionName
                : ChampionName + Slot;

            if (!SpellSwitch[tabName].IsOn) return;
            if (!SpellClass.IsSpellReady) return;

            var max_hp = from t in Bootstrap.Allies
                where t.Value.Instance.IsValidTarget(Range, false)
                orderby t.Value.Instance.HealthPercent descending
                select t.Value;

            var most_ad = from t in Bootstrap.Allies
                where t.Value.Instance.IsValidTarget(Range, false)
                orderby t.Value.Instance.UnitStats.BaseAttackDamage + t.Value.Instance.UnitStats.TotalAttackDamage descending
                select t.Value;

            var units = SpellModeDisplay[tabName + "mode"].SelectedModeName == "MostAD"
                ? most_ad
                : max_hp;

            foreach (var ally in units)
                if (!ally.Instance.IsMe && ally.Instance.IsValidTarget(Range, false))
                {
                    if (TargetingType == TargetingType.BindingUnit && UsePct == 100)
                        if (!ally.Instance.BuffManager.HasBuff(BoundBuffName))
                            this.CheckSpellAllyLowHealth(ally.Instance);

                    if (TargetingType == TargetingType.ProximityAlly)
                        if (ally.Instance.BuffManager.HasBuff(BoundBuffName) && ally.InWayDanger)
                            this.CheckSpellAllyLowHealth(ally.Instance);
                }
        }

        #endregion
    }
}