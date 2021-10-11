namespace Trinity.Items
{
    using Helpers;
    using Oasys.SDK;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.Extensions;
    using System.Linq;

    public class ActiveItem : ActiveItemBase
    {
        public int UsePct { get; set; }
        public int LastUsedTimeStamp { get; set; }
        public Enums.ActivationType[] ActivationTypes { get; set; }
        public string ItemBuffName { get; set; }
        public Enums.TargetingType TargetingType { get; set; }

        public ActiveItem(int usePct, ItemID itemId, Enums.TargetingType tType, float range,  Enums.ActivationType[] aTypes, 
            string itemBuffName = "")
        {
            UsePct = usePct;
            TargetingType = tType;
            Range = range;
            ActivationTypes = aTypes;
            ItemBuffName = itemBuffName;
            ItemId = itemId;
        }
        
        public override void CreateTab()
        {
            // the enable disable switch
            this.CreateTabEnableSwitch();
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckAllyLowHP))
                this.CreateTabAllyLowHealth(UsePct);
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckEnemyLowHP))
                this.CreateTabEnemyLowHealth(UsePct);
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckAllyLowMP))
                this.CreateTabAllyLowMana(UsePct);

            if (ActivationTypes.Contains(Enums.ActivationType.CheckAuras))
                this.CreateTabAuraCleanse(UsePct);
        }

        public override void OnTick()
        {
            if (TargetingType.ToString().Contains("Enemy"))
            {
                var hero = Bootstrap.AllChampions
                    .FirstOrDefault(x => x.Instance.NetworkID == 
                                         TargetSelector.GetBestChampionTarget().NetworkID);

                if (hero != null && hero.Instance.IsValidTarget(Range))
                {
                    this.ItemCheckEnemyLowHealth(hero.Instance);
                }
            }
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckOnlyOnMe))
            {
                if (!UnitManager.MyChampion.BuffManager.HasBuff(ItemBuffName))
                {
                    this.ItemCheckLowHealth(UnitManager.MyChampion);
                    this.ItemCheckLowMana(UnitManager.MyChampion);
                    this.ItemCheckAuras(UnitManager.MyChampion);
                }
            }
            else
            {
                foreach (var hero in Bootstrap.AllChampions.Where(x => x.Instance.Team == UnitManager.MyChampion.Team))
                {
                    if (UnitManager.MyChampion.Position.Distance(hero.Instance.Position) <= Range)
                    {
                        this.ItemCheckLowHealth(hero.Instance);
                        this.ItemCheckLowMana(hero.Instance);
                        this.ItemCheckAuras(hero.Instance);
                    }
                }
            }
        }
    }
}