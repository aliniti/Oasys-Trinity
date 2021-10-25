namespace Trinity.Base
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Helpers;
    using Oasys.Common;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.GameObject.ObjectClass;
    using Oasys.SDK;
    using Oasys.SDK.Events;

    public class Champion
    {
        public bool InWay { get; set; }
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

            var proj = Instance.Position.ProjectOn(
                currentSpell.SpellStartPosition, currentSpell.SpellEndPosition);

            InWay = proj.IsOnSegment && Instance.Position.Distance(proj.SegmentPoint) <=
                Instance.UnitComponentInfo.UnitBoundingRadius + currentSpell.SpellData.SpellWidth;
        }
    }
    
    
    
}
