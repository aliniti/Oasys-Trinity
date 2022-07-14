namespace Trinity.Base
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Oasys.Common;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK;
    using Oasys.SDK.Events;
    using Helpers;

    #endregion

    public class Champion
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
        ///     Gets or sets the [aggro] tick.
        /// </summary>
        /// <value>
        ///     The [aggro] tick.
        /// </value>
        public int AggroTick { get; set; }
        
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
        ///     Gets or sets the emulation type.
        /// </summary>
        /// <value>
        ///     The emulation type.
        /// </value>
        public EmulationType EmuType { get; set; }

        /// <summary>
        ///     Gets or sets the aura information.
        /// </summary>
        /// <value>
        ///     The aura information.
        /// </value>
        public Dictionary<string, int> AuraInfo { get; set; }

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

            // todo: split into abstract class
            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
        }
        
        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Checks the projection segment.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void CheckProjectionSegment(AIBaseClient unit)
        {
            // todo: failsafe: need a better way to implement this
            if ((int)(GameEngine.GameTime * 1000) - AggroTick > 500)
            {
                this.ResetAggro();
            }
            
            if (unit.IsAlive)
                if (unit.IsCastingSpell)
                {
                    var currentSpell = unit.GetCurrentCastingSpell();
                    if (currentSpell.SpellData.SpellName is not null)
                    {
                        var gameTime = (int) (GameEngine.GameTime * 1000);
                        var entry = SpellData.HeroSpells.Find(x => x.SpellName.ToLower() == currentSpell.SpellData.SpellName.ToLower());
                        
                        //var heroTargetAggro = currentSpell.Targets.Find(x => x.NetworkID == GameEngine.HoveredGameObjectUnderMouse.NetworkID) != null;
                        var heroTargetAggro = currentSpell.Targets.Find(x => x.NetworkID == Instance.NetworkID) != null;
                        if (heroTargetAggro)
                        {
                            if (entry != null)
                            {
                                InDanger = entry.EmulationTypes.Contains(EmulationType.Danger);
                                InCrowdControl = entry.EmulationTypes.Contains(EmulationType.CrowdControl);
                                InExtremeDanger = entry.EmulationTypes.Contains(EmulationType.Ultimate);
                            }
                            
                            HasAggro = true;
                            AggroTick = gameTime;
                        }
                        else
                        {
                            // skillshot projection 
                            var radius = (int) Math.Max(50, currentSpell.SpellData.SpellWidth) + Instance.UnitComponentInfo.UnitBoundingRadius;
                            var proj = Instance.Position.ProjectOn(currentSpell.SpellStartPosition, currentSpell.SpellEndPosition);
                            var nearit = Instance.Position.Distance(proj.SegmentPoint) <= radius;

                            if (proj.IsOnSegment && nearit)
                            {
                                if (entry != null)
                                {
                                    InDanger = entry.EmulationTypes.Contains(EmulationType.Danger);
                                    InCrowdControl = entry.EmulationTypes.Contains(EmulationType.CrowdControl);
                                    InExtremeDanger = entry.EmulationTypes.Contains(EmulationType.Ultimate);
                                }
                                
                                HasAggro = true;
                                AggroTick = gameTime;
                            }
                        }
                    }
                }
        }

        #endregion

        #region Private Methods and Operators

        /// <summary>
        ///     Cores events [on core main tick].
        /// </summary>
        private async Task CoreEvents_OnCoreMainTick()
        {
            if (Instance.IsEnemy) return;

            foreach (var u in ObjectManagerExport.HeroCollection)
            {
                var unit = u.Value;
                switch (unit.IsEnemy)
                {
                    case true:
                        CheckProjectionSegment(unit);
                        break;
                }
            }

            foreach (var t in ObjectManagerExport.TurretCollection)
            {
                var turret = t.Value;
                switch (turret.IsEnemy)
                {
                    case true:
                        CheckProjectionSegment(turret);
                        break;
                }
            }
            
            foreach (var t in ObjectManagerExport.JungleObjectCollection)
            {
                var minion = t.Value;
                switch (minion.IsNeutral)
                {
                    case true:
                        CheckProjectionSegment(minion);
                        break;
                }
            }
        }
        
        #endregion
    }
}