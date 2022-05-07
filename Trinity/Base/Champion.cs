namespace Trinity.Base
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Oasys.Common;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK;
    using Oasys.SDK.Events;

    public class Champion
    {
        public bool InWayDanger { get; set; }
        public AIHeroClient Instance { get; set; }
        public Dictionary<string, int> AuraInfo;
        
        public Champion(AIHeroClient instance)
        {
            this.Instance = instance;
            this.AuraInfo = new Dictionary<string, int>();

            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
        }

        private async Task CoreEvents_OnCoreMainTick()
        {
            if (this.Instance.IsEnemy)
            {
                return;
            }

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

        public void CheckProjectionSegment(AIBaseClient unit)
        {
            if (unit.IsAlive)
            {
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

                        var proj = this.Instance.Position.ProjectOn(currentSpell.SpellStartPosition, currentSpell.SpellEndPosition);

                        this.InWayDanger = proj.IsOnSegment && spellTick < 1000 && this.Instance.Position.Distance(proj.SegmentPoint) <=
                            (int) (this.Instance.UnitComponentInfo.UnitBoundingRadius + spellWidth);
                    }
                }
            }
        }
    }
}