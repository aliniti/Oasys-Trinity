namespace Trinity.Spells
{
    using Helpers;
    using Oasys.SDK;
    using Oasys.Common.Extensions;
    using Oasys.SDK.SpellCasting;
    using System.Linq;

    public class AutoSpell : AutoSpellBase
    {
        public int UsePct { get; set; }
        public int LastUsedTimeStamp { get; set; }

        public Enums.ActivationType[] ActivationTypes { get; set; }
        public Enums.TargetingType TargetingType { get; set; }

        public AutoSpell(int usePct, string championName, CastSlot slot, Enums.TargetingType tType, float range, 
            Enums.ActivationType[] aType)
        {
            ChampionName = championName;
            Slot = slot;
            TargetingType = tType;
            ActivationTypes = aType;
            Range = range;
            UsePct = usePct;
        }

        public override void CreateTab()
        {
            // the enable disable switch
            this.CreateSpellTabEnableSwitch();

            if (ActivationTypes.Contains(Enums.ActivationType.CheckEnemyLowHP))
                this.CreateSpellTabEnemyLowHP();

            if (ActivationTypes.Contains(Enums.ActivationType.CheckAllyLowHP))
                this.CreateSpellTabAllyLowHP(UsePct);

            if (ActivationTypes.Contains(Enums.ActivationType.CheckEnemyLowHP))
                this.CreateSpellTabEnemyLowHP();

            if (ActivationTypes.Contains(Enums.ActivationType.CheckPlayerMana))
                this.CreateSpellTabAllyMinimumMP();
        }

        public override void OnTick()
        {
            if (ActivationTypes.Contains(Enums.ActivationType.CheckPlayerMana))
            {
                if (this.SpellCheckMinimumMana(UnitManager.MyChampion))
                {
                    return;
                }
            }

            if (ActivationTypes.Contains(Enums.ActivationType.CheckOnlyOnMe))
            {
                this.SpellCheckAllyLowHealth(UnitManager.MyChampion);
                this.SpellCheckAllyLowMana(UnitManager.MyChampion);
            }
            else
            {
                foreach (var u in Bootstrap.Allies)
                {
                    var hero = u.Value;
                    if (hero.Instance.Team == UnitManager.MyChampion.Team)
                    {
                        if (UnitManager.MyChampion.Position.Distance(hero.Instance.Position) <= Range)
                        {
                            this.SpellCheckAllyLowHealth(hero.Instance);
                            this.SpellCheckAllyLowMana(hero.Instance);
                        }
                    }
                }
            }
        }
    }
}
