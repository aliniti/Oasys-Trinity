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
    using Oasys.SDK.Tools;

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
            if (Instance.IsEnemy)
            {
                return;
            }

            foreach (var u in ObjectManagerExport.HeroCollection)
            {
                var unit = u.Value;
                if (unit.IsEnemy)
                {
                    CheckProjectionSegment(unit);
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
                        var spellWidth = Math.Max(25, currentSpell.SpellData.SpellWidth);

                        var proj = Instance.Position.ProjectOn(currentSpell.SpellStartPosition, currentSpell.SpellEndPosition);

                        InWayDanger = proj.IsOnSegment && spellTick < 1000 && Instance.Position.Distance(proj.SegmentPoint) <=
                            Instance.UnitComponentInfo.UnitBoundingRadius + spellWidth;
                    }
                }
                else
                {
                    InWayDanger = false;
                }
            }
        }
    }
}