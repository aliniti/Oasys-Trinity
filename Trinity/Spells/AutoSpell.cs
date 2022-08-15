namespace Trinity.Spells
{
    #region

    using System.Linq;
    using Helpers;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK;
    using Oasys.SDK.SpellCasting;

    #endregion

    public class AutoSpell : AutoSpellBase
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
        ///     Gets or sets the use PCT.
        /// </summary>
        /// <value>
        ///     The use PCT.
        /// </value>
        public int UsePct { get; set; }

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
        ///     Initializes a new instance of the <see cref="AutoSpell" /> class.
        /// </summary>
        /// <param name="usePct">The use PCT.</param>
        /// <param name="championName">Name of the champion.</param>
        /// <param name="slot">The slot.</param>
        /// <param name="tType">Type of the t.</param>
        /// <param name="range">The range.</param>
        /// <param name="aType">a type.</param>
        public AutoSpell(int usePct, string championName, CastSlot slot, TargetingType tType, float range,
            ActivationType[] aType)
        {
            ChampionName = championName;
            Slot = slot;
            TargetingType = tType;
            ActivationTypes = aType;
            Range = range;
            UsePct = usePct;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AutoSpell" /> class.
        /// </summary>
        /// <param name="usePct">The use PCT.</param>
        /// <param name="championName">Name of the champion.</param>
        /// <param name="spellName">Name of the spell.</param>
        /// <param name="tType">Type of the t.</param>
        /// <param name="range">The range.</param>
        /// <param name="aType">a type.</param>
        public AutoSpell(int usePct, string championName, string spellName, TargetingType tType, float range,
            ActivationType[] aType)
        {
            ChampionName = championName;
            SpellName = spellName;
            TargetingType = tType;
            ActivationTypes = aType;
            Range = range;
            UsePct = usePct;
        }

        #endregion

        #region Override Methods

        /// <summary>
        ///     Creates the tab.
        /// </summary>
        public override void CreateTab()
        {
            // the enable disable switch
            this.CreateSpellTabEnableSwitch();

            if (ActivationTypes.Contains(ActivationType.CheckEnemyLowHP))
                this.CreateSpellTabEnemyLowHP(UsePct);

            if (ActivationTypes.Contains(ActivationType.CheckAllyLowHP))
                this.CreateSpellTabAllyLowHP(UsePct);

            if (ActivationTypes.Contains(ActivationType.CheckPlayerMana))
                this.CreateSpellTabAllyMinimumMP();

            if (ActivationTypes.Contains(ActivationType.CheckAuras))
                this.CreateSpellTabAuraCleanse();

            if (TargetingType.ToString().Contains("Binding"))
                this.CreateSpellTabBindingUnit();
            
            if (ActivationTypes.Contains(ActivationType.CheckDangerous))
                this.CreateTabSpellDangerousSpells(UsePct);
        }

        public override void OnRender()
        {
        }

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

            if (ActivationTypes.Contains(ActivationType.CheckPlayerMana))
                if (this.CheckSpellMinimumMana(UnitManager.MyChampion))
                    return;

            var myChampionOnly = Bootstrap.Allies.Select(x => x.Value)
                .FirstOrDefault(x => x.Instance.NetworkID == UnitManager.MyChampion.NetworkID);
            
            if (TargetingType.ToString().Contains("Enemy"))
            {
                var target = UnitManager.EnemyChampions.MinBy(TargetSelector.AttacksLeftToKill) as AIHeroClient;
                if (target != null && target.IsValidTarget())
                {
                    this.CheckSpellEnemyLowHealth(target);
                    this.CheckSpellDangerousSpells(myChampionOnly, target);
                    return;
                }
            }

            if (ActivationTypes.Contains(ActivationType.CheckOnlyOnMe))
            {
                if (myChampionOnly != null)
                    if (myChampionOnly.HasAggro(UsePct > 55))
                    {
                        this.CheckSpellAuras(myChampionOnly);
                        this.CheckSpellDangerousSpells(myChampionOnly);
                        this.CheckSpellAllyLowHealth(myChampionOnly.Instance);
                        this.CheckSpellAllyLowMana(myChampionOnly.Instance);
                    }
            }
            else
            {
                foreach (var u in Bootstrap.Allies)
                {
                    var hero = u.Value;
                    if (hero.Instance.Team == UnitManager.MyChampion.Team)
                        if (UnitManager.MyChampion.Position.Distance(hero.Instance.Position) <= Range)
                            if (hero.HasAggro(UsePct > 55) && hero.Instance.Position.IsOnScreen())
                            {
                                this.CheckSpellAuras(hero);
                                this.CheckSpellDangerousSpells(hero);
                                this.CheckSpellAllyLowHealth(hero.Instance);
                                this.CheckSpellAllyLowMana(hero.Instance);
                            }
                }
            }
        }

        #endregion
    }
}