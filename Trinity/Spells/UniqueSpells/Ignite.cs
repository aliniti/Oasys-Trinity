namespace Trinity.Spells.UniqueSpells
{
    using System.Linq;
    using Helpers;
    using Oasys.Common;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK;

    class Ignite : AutoSpell
    {
        public Ignite(int usePct, string championName, string spellName, Enums.TargetingType tType, float range, Enums.ActivationType[] aType) 
            : base(usePct, championName, spellName, tType, range, aType) { }

        public override void CreateTab()
        {
            this.CreateIgniteTabs();
        }

        public override void OnTick()
        {
            if (!SpellClass.IsSpellReady)
            {
                return;
            }

            if (this.SpellSwitch["igcombo"].IsOn)
            {
                if (TargetSelector.GetBestChampionTarget() is AIHeroClient target && target.IsValidTarget(Range))
                {
                    var hpPct = target.HealthPercent;
                    if (hpPct > this.SpellCounter["igminhp"].Value &&
                        hpPct < this.SpellCounter["igmaxhp"].Value)
                    {
                        this.UseSpell(target);
                    }
                }
            }

            if (this.SpellSwitch["igks"].IsOn)
            {
                foreach (var unit in Bootstrap.Enemies.Select(x => x.Value))
                {
                    var igniteDmg = (float) 50 + (20 * ObjectManagerExport.LocalPlayer.Level);
                    if (igniteDmg > unit.Instance.Health)
                    {
                        this.UseSpell(unit.Instance);
                    }
                }
            }
        }
    }
}
