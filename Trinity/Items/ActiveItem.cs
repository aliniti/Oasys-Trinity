namespace Trinity.Items
{
    #region

    using System.Linq;
    using Helpers;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK;

    #endregion

    public class ActiveItem : ActiveItemBase
    {
        #region Properties and Encapsulation

        /// <summary>
        ///     Gets or sets the activation types.
        /// </summary>
        /// <value>
        ///     The activation types.
        /// </value>
        public ActivationType[] ActivationTypes { get; set; }

        /// <summary>
        ///     Gets or sets the range.
        /// </summary>
        /// <value>
        ///     The range.
        /// </value>
        public float Range { get; set; }

        /// <summary>
        ///     Gets or sets the use PCT.
        /// </summary>
        /// <value>
        ///     The use PCT.
        /// </value>
        public int UsePct { get; set; }

        /// <summary>
        ///     Gets or sets the last used time stamp.
        /// </summary>
        /// <value>
        ///     The last used time stamp.
        /// </value>
        public int LastUsedTimeStamp { get; set; }

        /// <summary>
        ///     Gets or sets the name of the item buff.
        /// </summary>
        /// <value>
        ///     The name of the item buff.
        /// </value>
        public string ItemBuffName { get; set; }

        /// <summary>
        ///     Gets or sets the type of the targeting.
        /// </summary>
        /// <value>
        ///     The type of the targeting.
        /// </value>
        public TargetingType TargetingType { get; set; }

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ActiveItem" /> class.
        /// </summary>
        /// <param name="usePct">The use PCT.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="tType">Type of the t.</param>
        /// <param name="range">The range.</param>
        /// <param name="aTypes">a types.</param>
        /// <param name="itemBuffName">Name of the item buff.</param>
        public ActiveItem(int usePct, ItemID itemId, TargetingType tType, float range, ActivationType[] aTypes,
            string itemBuffName = null)
        {
            UsePct = usePct;
            TargetingType = tType;
            Range = range;
            ActivationTypes = aTypes;
            ItemBuffName = itemBuffName;
            ItemId = itemId;
        }

        #endregion

        #region Override Methods

        public override void CreateTab()
        {
            // the enable disable switch
            this.CreateItemTabEnableSwitch();

            if (ActivationTypes.Contains(ActivationType.CheckAllyLowHP))
                this.CreateItemTabAllyLowHealth(UsePct);

            if (ActivationTypes.Contains(ActivationType.CheckEnemyLowHP))
                this.CreateItemTabEnemyLowHealth(UsePct);

            if (ActivationTypes.Contains(ActivationType.CheckAllyLowMP))
                this.CreateItemTabAllyLowMana(UsePct);

            if (ActivationTypes.Contains(ActivationType.CheckAuras))
                this.CreateItemTabAuraCleanse(UsePct);

            if (ActivationTypes.Contains(ActivationType.CheckProximityCount))
                this.CreateItemCheckProximityCount();

            if (TargetingType == TargetingType.BindingUnit)
                this.CreateItemTabBindingUnit();
        }

        public override void OnRender()
        {
        }

        public override void OnTick()
        {
            if (!ItemSwitch[ItemId.ToString()].IsOn) return;
            if (!SpellClass.IsSpellReady) return;

            if (TargetingType.ToString().Contains("Enemy"))
                if (TargetSelector.GetBestChampionTarget() is AIHeroClient target && target.IsValidTarget())
                    this.CheckItemEnemyLowHealth(target);

            if (ActivationTypes.Contains(ActivationType.CheckOnlyOnMe))
            {
                var myHero = Bootstrap.Allies.Select(x => x.Value)
                    .FirstOrDefault(x => x.Instance.NetworkID == UnitManager.MyChampion.NetworkID);

                if (myHero != null)
                {
                    if (ItemBuffName != null && UnitManager.MyChampion.BuffManager.HasBuff(ItemBuffName)) return;

                    this.CheckItemAuras(myHero.Instance);
                    this.CheckItemProximityCount(myHero.Instance);

                    if (myHero.InWayDanger || UsePct == 100)
                    {
                        this.CheckItemAllyLowHealth(myHero.Instance);
                        this.CheckItemAllyLowMana(myHero.Instance);
                    }
                }
            }
            else
            {
                foreach (var u in Bootstrap.Allies)
                {
                    var hero = u.Value;
                    if (hero.Instance.Team == UnitManager.MyChampion.Team)
                    {
                        if (ItemBuffName != null && hero.Instance.BuffManager.HasBuff(ItemBuffName)) return;

                        if (UnitManager.MyChampion.Position.Distance(hero.Instance.Position) <= Range)
                        {
                            this.CheckItemAuras(hero.Instance);
                            this.CheckItemProximityCount(hero.Instance);

                            if (hero.InWayDanger || UsePct == 100)
                            {
                                this.CheckItemAllyLowHealth(hero.Instance);
                                this.CheckItemAllyLowMana(hero.Instance);
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}