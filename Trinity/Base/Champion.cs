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
        public bool HasAggro(bool minion = false)
        {
            var tabname = Instance.ModelName + (Instance.IsEnemy ? "e" : "a");

            return PredictionFlags.Contains(PredictionFlag.Hero) && ChampionSwitch[tabname + "hro"].IsOn
                   || PredictionFlags.Contains(PredictionFlag.Tower) && ChampionSwitch[tabname + "twr"].IsOn
                   || PredictionFlags.Contains(PredictionFlag.Particle) && ChampionSwitch[tabname + "vfx"].IsOn
                   || PredictionFlags.Contains(PredictionFlag.Missile) && ChampionSwitch[tabname + "mis"].IsOn
                   || PredictionFlags.Contains(PredictionFlag.Buff) && ChampionSwitch[tabname + "buf"].IsOn
                   || PredictionFlags.Contains(PredictionFlag.Monster) && ChampionSwitch[tabname + "jgl"].IsOn && minion
                   || PredictionFlags.Contains(PredictionFlag.Minion) && ChampionSwitch[tabname + "min"].IsOn && minion;
        }

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

        /// <summary>
        ///     Gets or sets the prediction flags.
        /// </summary>
        /// <value>
        ///     The prediction flag.
        /// </value>
        public List<PredictionFlag> PredictionFlags { get; set; }
        
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
            PredictionFlags = new List<PredictionFlag>();
        }

        #endregion

        #region Override Methods

        public override void OnTick()
        {
            if (Instance.IsEnemy) return;
            
            foreach (var u in ObjectManagerExport.HeroCollection)
            {
                var unit = u.Value;
                if (unit.IsEnemy)
                    if (this.CheckProjectionSegment(unit))
                        PredictionFlags.Add(PredictionFlag.Hero);
            }

            foreach (var t in ObjectManagerExport.TurretCollection)
            {
                var turret = t.Value;
                if (turret.IsEnemy)
                    if (this.CheckProjectionSegment(turret))
                        PredictionFlags.Add(PredictionFlag.Tower);
            }

            foreach (var t in ObjectManagerExport.JungleObjectCollection)
            {
                var minion = t.Value;
                if (minion.IsNeutral)
                    if (this.CheckProjectionSegment(minion))
                        PredictionFlags.Add(PredictionFlag.Monster);
            }
            
            foreach (var t in ObjectManagerExport.MinionCollection)
            {
                var minion = t.Value;
                if (minion.IsEnemy)
                    if (this.CheckProjectionSegment(minion))
                        PredictionFlags.Add(PredictionFlag.Minion);
            }
        }
        
        public override void CreateTab()
        {
            var tabname = Instance.ModelName + (Instance.IsEnemy ? "e" : "a");
            
            ChampionGroupTab = new Tab { Title = "[pred] " + Instance.ModelName };
            ChampionGroupTab.AddItem(ChampionSwitch[tabname + "hro"] = new Switch { IsOn = true, Title = "Predict spell/auto attacks" });
            ChampionGroupTab.AddItem(ChampionSwitch[tabname + "mis"] = new Switch { IsOn = true, Title = "Predict missiles from fow (beta)" });
            ChampionGroupTab.AddItem(ChampionSwitch[tabname + "min"] = new Switch { IsOn = true, Title = "Predict minion attacks" });
            ChampionGroupTab.AddItem(ChampionSwitch[tabname + "jgl"] = new Switch { IsOn = true, Title = "Predict neutral monsters attacks" });
            ChampionGroupTab.AddItem(ChampionSwitch[tabname + "twr"] = new Switch { IsOn = true, Title = "Predict tower attacks" });
            ChampionGroupTab.AddItem(ChampionSwitch[tabname + "vfx"] = new Switch { IsOn = true, Title = "Predict particle/vfx" });
            ChampionGroupTab.AddItem(ChampionSwitch[tabname + "buf"] = new Switch { IsOn = true, Title = "Predict buffs" });

            ChampionTab.AddItem(ChampionGroupTab);
        }

        public override void OnCreate(List<AIBaseClient> callbackobjectlist, AIBaseClient callbackobject, float callbackgametime)
        {
            if (callbackobject.IsEnemy)
                if (this.CheckMissileSegment(callbackobject))
                    PredictionFlags.Add(PredictionFlag.Missile);
        }

        #endregion
    }
}