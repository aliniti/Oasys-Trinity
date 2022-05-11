namespace Trinity.Base
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Oasys.Common;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK;
    using Oasys.SDK.Events;

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
            if (unit.IsAlive)
                if (unit.IsCastingSpell)
                {
                    var currentSpell = unit.GetCurrentCastingSpell();
                    if (currentSpell.SpellData.SpellName is not null)
                    {
                        var startTime = currentSpell.CastStartTime * 1000;
                        var gameTime = GameEngine.GameTime * 1000;
                        var spellTick = Math.Max(0, gameTime - startTime);

                        var width = currentSpell.SpellData.SpellRadius > 0 ? currentSpell.SpellData.SpellRadius : currentSpell.SpellData.SpellWidth;
                        var spellWidth = Math.Max(50, width);

                        var proj = Instance.Position.ProjectOn(currentSpell.SpellStartPosition, currentSpell.SpellEndPosition);

                        InWayDanger = proj.IsOnSegment && spellTick < 1000 && Instance.Position.Distance(proj.SegmentPoint) <=
                            (int) (Instance.UnitComponentInfo.UnitBoundingRadius + spellWidth);
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
        }

        #endregion
    }
}