namespace Trinity.Spells.UniqueSpells
{
    using Oasys.SDK.SpellCasting;
    using System.Linq;
    using Helpers;

    internal class Kalista : AutoSpell
    {
        public Kalista(int usePct, string championName, CastSlot castSlot, Enums.TargetingType targetingType,float range, Enums.ActivationType[] activationTypes) 
            : base(usePct, championName, castSlot, targetingType, range, activationTypes) { }

        public override void OnTick()
        {
            var ally = Bootstrap.Allies.Select(x => x.Value)
                .FirstOrDefault(x => x.Instance.BuffManager.HasBuff("kalistacoopstrikeally"));

            if (ally != null && !ally.Instance.IsMe && ally.InWayDanger)
            {
                this.SpellCheckAllyLowHealth(ally.Instance);
            }
        }
    }
}