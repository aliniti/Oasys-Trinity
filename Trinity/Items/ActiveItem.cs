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

        /// <summary> 
        /// <c>CreateTab</c> creates item tabs for various types based on activations types 
        /// and targets, including Enemy Low Health, Ally Low Health, Mana, Aura Cleanse, 
        /// Proximity Count, Binding Unit, and Dangerous Spells. 
        /// </summary> 
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
            
            if (TargetingType.ToString().Contains("Binding"))
                this.CreateItemTabBindingUnit();
            
            if (ActivationTypes.Contains(ActivationType.CheckDangerous))
                this.CreateTabItemDangerousSpells(UsePct);
        }

        /// <summary> 
        /// <c>OnRender</c> renders the component. 
        /// </summary> 
        public override void OnRender()
        {
        }

        /// <summary> 
        /// <c>OnTick</c> checks items for various effects and takes actions based on those 
        /// effects, such as checking item auras, proximity count, and dangerous spells. It 
        /// also checks for low health or low mana allies and acts accordingly. 
        /// </summary> 
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

                    this.CheckItemAuras(myHero);
                    this.CheckItemProximityCount(myHero.Instance);
                    this.CheckItemDangerousSpells(myHero);
                    
                    if (myHero.HasAggro(UsePct > 55) || UsePct == 100)
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
                    if (hero.Instance.Team != UnitManager.MyChampion.Team) continue;
                    if (ItemBuffName != null && hero.Instance.BuffManager.HasBuff(ItemBuffName)) return;

                    if (UnitManager.MyChampion.Position.Distance(hero.Instance.Position) <= Range)
                    {
                        if (hero.Instance.Position.IsOnScreen())
                        {
                            this.CheckItemAuras(hero);
                            this.CheckItemProximityCount(hero.Instance);
                            this.CheckItemDangerousSpells(hero);

                            if (hero.HasAggro(UsePct > 55) || UsePct == 100)
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