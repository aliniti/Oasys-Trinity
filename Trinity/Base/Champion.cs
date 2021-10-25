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
            Instance = instance;
            AuraInfo = new Dictionary<string, int>();

            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
        }

        private async Task CoreEvents_OnCoreMainTick()
        {
            foreach (var u in ObjectManagerExport.HeroCollection)
            {
                var unit = u.Value;
                CheckProjectionSegment(unit);
            }
        }

        public void CheckProjectionSegment(AIBaseClient unit)
        {
            if (unit.Team == UnitManager.MyChampion.Team) return;
            if (unit.IsAlive == false || !unit.IsCastingSpell) return;
                
            var currentSpell = unit.GetCurrentCastingSpell();
            var startTime = currentSpell.CastStartTime * 1000;
            var gameTime = GameEngine.GameTime * 1000;
            var spellTick = Math.Max(0, gameTime - startTime);
            var spellWidth = Math.Max(100, currentSpell.SpellData.SpellWidth);

            var proj = Instance.Position.ProjectOn(
                currentSpell.SpellStartPosition, currentSpell.SpellEndPosition);

            InWayDanger = proj.IsOnSegment && spellTick < 1000 && Instance.Position.Distance(proj.SegmentPoint) <=
                Instance.UnitComponentInfo.UnitBoundingRadius + spellWidth;
        }
    }
}