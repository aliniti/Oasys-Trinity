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

        public AutoSpell(int usePct, string championName, string spellName, Enums.TargetingType tType, float range,
            Enums.ActivationType[] aType)
        {
            ChampionName = championName;
            SpellName = spellName;
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

            if (ActivationTypes.Contains(Enums.ActivationType.CheckAuras))
                this.CreateSpellTabAuraCleanse();
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
                var myChampionOnly = Bootstrap.Allies.Select(x => x.Value)
                    .FirstOrDefault(x => x.Instance.NetworkID == UnitManager.MyChampion.NetworkID);

                if (myChampionOnly != null)
                {
                    if (myChampionOnly.InWayDanger)
                    {
                        this.SpellCheckAllyLowHealth(myChampionOnly.Instance);
                        this.SpellCheckAllyLowMana(myChampionOnly.Instance);
                        this.SpellCheckAuras(myChampionOnly.Instance);
                    }
                }
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
                            if (hero.InWayDanger)
                            {
                                this.SpellCheckAllyLowHealth(hero.Instance);
                                this.SpellCheckAllyLowMana(hero.Instance);
                                this.SpellCheckAuras(hero.Instance);
                            }
                        }
                    }
                }
            }
        }
    }
}
