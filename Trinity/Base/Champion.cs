﻿namespace Trinity.Base
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
        ///     Gets or sets a value indicating whether [in way danger].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [in way danger]; otherwise, <c>false</c>.
        /// </value>
        public bool InWayDanger { get; set; }
        
        /// <summary>
        ///     Gets or sets the [danger] tick.
        /// </summary>
        /// <value>
        ///     The [danger] tick.
        /// </value>
        public int DangerTick { get; set; }
        
        /// <summary>
        ///     Gets or sets a value indicating whether [in extreme danger].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [in extreme danger]; otherwise, <c>false</c>.
        /// </value>
        public bool InExtremeDanger { get; set; }
        
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
            if ((int)(GameEngine.GameTime * 1000) - DangerTick > 500)
            {
                // todo:
                if (InWayDanger)
                {
                    InWayDanger = false;
                }
                
                // todo:
                if (InExtremeDanger)
                {
                    InExtremeDanger = false;
                }
            }
            
            if (unit.IsAlive)
                if (unit.IsCastingSpell)
                {
                    var currentSpell = unit.GetCurrentCastingSpell();
                    if (currentSpell.SpellData.SpellName is not null)
                    {
                        var gameTime = (int) (GameEngine.GameTime * 1000);
                        var entry = SpellData.HeroSpells.Find(x => 
                            string.Equals(x.SpellName, currentSpell.SpellData.SpellName,
                                StringComparison.CurrentCultureIgnoreCase));
                        
                        var heroTargetAggro = currentSpell.Targets.Find(x => x.NetworkID == Instance.NetworkID) != null;
                        if (heroTargetAggro)
                        {
                            if (entry != null)
                                InExtremeDanger = entry.EmulationTypes.Contains(EmulationType.Ultimate);
                            
                            InWayDanger = true;
                            DangerTick = gameTime;
                        }
                        else
                        {
                            // skillshot projection 
                            var radius = (int) currentSpell.SpellData.SpellWidth + Instance.UnitComponentInfo.UnitBoundingRadius;
                            var proj = Instance.Position.ProjectOn(currentSpell.SpellStartPosition, currentSpell.SpellEndPosition);
                            var nearit = Instance.Position.Distance(proj.SegmentPoint) <= radius;

                            if (proj.IsOnSegment && nearit)
                            {
                                if (entry != null)
                                    InExtremeDanger = entry.EmulationTypes.Contains(EmulationType.Ultimate);
                                
                                InWayDanger = true;
                                DangerTick = gameTime;
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