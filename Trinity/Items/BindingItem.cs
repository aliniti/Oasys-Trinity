namespace Trinity.Items
{
    #region

    using System.Linq;
    using Helpers;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.Extensions;

    #endregion

    internal class BindingItem : ActiveItem
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BindingItem" /> class.
        /// </summary>
        /// <param name="usePct">The use PCT.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="tType">Type of the t.</param>
        /// <param name="range">The range.</param>
        /// <param name="aTypes">a types.</param>
        /// <param name="itemBuffName">Name of the item buff.</param>
        public BindingItem(int usePct, ItemID itemId, string itemBuffName, TargetingType tType, float range,
            ActivationType[] aTypes) : base(usePct, itemId, tType, range, aTypes, itemBuffName)
        {
        }

        #endregion

        #region Override Methods

        /// <summary>
        ///     Called when [on tick].
        /// </summary>
        public override void OnTick()
        {
            if (!ItemSwitch[ItemId.ToString()].IsOn) return;
            if (!SpellClass.IsSpellReady) return;

            var units = TargetingType.ToString().Contains("Ally") 
                ? Bootstrap.Allies
                : Bootstrap.Enemies;

            var maxHp = from t in units
                where t.Value.Instance.IsValidTarget(Range, false)
                orderby t.Value.Instance.HealthPercent descending
                select t.Value;

            var mostDmg = from t in units
                where t.Value.Instance.IsValidTarget(Range, false)
                orderby t.Value.Instance.UnitStats.BaseAttackDamage + t.Value.Instance.UnitStats.TotalAttackDamage descending
                select t.Value;

            var heroes = ItemModeDisplay[ItemId + "mode"].SelectedModeName == "MostAD" 
                ? mostDmg 
                : maxHp;

            foreach (var h in heroes)
                if (!h.Instance.IsMe && h.Instance.Position.IsOnScreen())
                {
                    if (TargetingType.ToString().Contains("Binding") && UsePct == 100)
                        if (!h.Instance.BuffManager.HasBuff(ItemBuffName))
                            this.CheckItemAllyLowHealth(h.Instance);

                    if (TargetingType == TargetingType.ProximityAlly)
                        if (h.Instance.BuffManager.HasBuff(ItemBuffName) && h.HasAggro())
                            this.CheckItemAllyLowHealth(h.Instance);
                }
        }

        #endregion
    }
}