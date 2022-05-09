namespace Trinity.Spells.UniqueSpells
{
    #region

    using System.Linq;
    using Helpers;
    using Oasys.SDK.SpellCasting;

    #endregion

    internal class Kalista : AutoSpell
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Kalista" /> class.
        /// </summary>
        /// <param name="usePct">The use PCT.</param>
        /// <param name="championName">Name of the champion.</param>
        /// <param name="castSlot">The cast slot.</param>
        /// <param name="targetingType">Type of the targeting.</param>
        /// <param name="range">The range.</param>
        /// <param name="activationTypes">The activation types.</param>
        public Kalista(int usePct, string championName, CastSlot castSlot, TargetingType targetingType, float range, ActivationType[] activationTypes)
            : base(usePct, championName, castSlot, targetingType, range, activationTypes)
        {
        }

        #endregion

        #region Override Methods

        /// <summary>
        ///     Called when [OnTick].
        /// </summary>
        public override void OnTick()
        {
            var ally = Bootstrap.Allies.Select(x => x.Value)
                .FirstOrDefault(x => x.Instance.BuffManager.HasBuff("kalistacoopstrikeally"));

            if (ally != null && !ally.Instance.IsMe && ally.InWayDanger) this.CheckSpellAllyLowHealth(ally.Instance);
        }

        #endregion
    }
}