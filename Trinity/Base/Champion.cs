namespace Trinity.Base
{
    #region
    
    using Helpers;
    using Oasys.Common;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.Menu;
    using Oasys.Common.Menu.ItemComponents;
    using System.Collections.Generic;

    #endregion

    public class Champion : ChampionBase
    {
        #region Properties and Encapsulation

        /// <summary>
        ///     Gets or sets the instance.
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        public AIHeroClient Instance { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [has aggro].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [has aggro]; otherwise, <c>false</c>.
        /// </value>
        public bool HasAggro { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [in crowd control].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [in crowd control]; otherwise, <c>false</c>.
        /// </value>
        public bool InCrowdControl { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [in extreme danger].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [in extreme danger]; otherwise, <c>false</c>.
        /// </value>
        public bool InExtremeDanger { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [in danger].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [in danger]; otherwise, <c>false</c>.
        /// </value>
        public bool InDanger { get; set; }

        /// <summary>
        ///     Gets or sets the aura information.
        /// </summary>
        /// <value>
        ///     The aura information.
        /// </value>
        public Dictionary<string, int> AuraInfo { get; set; }

        /// <summary>
        ///     Gets or sets the [aggro] tick.
        /// </summary>
        /// <value>
        ///     The [aggro] tick.
        /// </value>
        public int AggroTick { get; set; }

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Champion" /> class.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public Champion(AIHeroClient instance)
        {
            Instance = instance;
            AuraInfo = new Dictionary<string, int>();
        }

        #endregion

        #region Override Methods

        public override void OnTick()
        {
            if (Instance.IsEnemy) return;
            var tabname = Instance.ModelName + (Instance.IsEnemy ? "e" : "a");
            
            foreach (var u in ObjectManagerExport.HeroCollection)
            {
                var unit = u.Value;
                if (unit.IsEnemy && ChampionSwitch[tabname + "hro"].IsOn)
                    this.CheckProjectionSegment(unit);
            }

            foreach (var t in ObjectManagerExport.TurretCollection)
            {
                var turret = t.Value;
                if (turret.IsEnemy && ChampionSwitch[tabname + "twr"].IsOn)
                    this.CheckProjectionSegment(turret);
            }

            foreach (var t in ObjectManagerExport.JungleObjectCollection)
            {
                var minion = t.Value;
                if (minion.IsNeutral && ChampionSwitch[tabname + "jgl"].IsOn)
                    this.CheckProjectionSegment(minion);
            }
            
            foreach (var t in ObjectManagerExport.MinionCollection)
            {
                var minion = t.Value;
                if (minion.IsEnemy && ChampionSwitch[tabname + "min"].IsOn)
                    this.CheckProjectionSegment(minion);
            }
        }

        public override void CreateTab()
        {
            var tabname = Instance.ModelName + (Instance.IsEnemy ? "e" : "a");
            this.ChampionGroup[tabname + "grp"] = new Group
            {
                Title = "[Ally] " + Instance.ModelName
            };
            
            this.ChampionGroup[tabname + "grp"].AddItem(ChampionSwitch[tabname + "hro"] = new Switch
            {
                IsOn = true,
                Title = "Enable spell/autoattack prediction on " + Instance.ModelName
            });
            
            this.ChampionGroup[tabname + "grp"].AddItem(ChampionSwitch[tabname + "min"] = new Switch
            {
                IsOn = false,
                Title = "Enable minion prediction on " + Instance.ModelName
            });
            
            this.ChampionGroup[tabname + "grp"].AddItem(ChampionSwitch[tabname + "jgl"] = new Switch
            {
                IsOn = true,
                Title = "Enable neutral monster prediction on " + Instance.ModelName
            });
            
            this.ChampionGroup[tabname + "grp"].AddItem(ChampionSwitch[tabname + "twr"] = new Switch
            {
                IsOn = true,
                Title = "Enable tower prediction on " + Instance.ModelName
            });

            this.ChampionTab.AddGroup(this.ChampionGroup[tabname + "grp"]);
        }

        #endregion
    }
}