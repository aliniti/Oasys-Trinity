namespace Trinity.Items
{
    using Oasys.SDK;
    using Oasys.Common.Enums.GameEnums;
    using System.Linq;
    using Helpers;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;

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

            //if (ActivationTypes.Contains(Enums.ActivationType.CheckAuras))
            //    this.CreateTabAuraCleanse(UsePct);

        }

        public override void OnTick()
        {
            if (TargetingType.ToString().Contains("Enemy"))
            {
                var hero = UnitManager.EnemyChampions
                    .FirstOrDefault(x => x.NetworkID == TargetSelector.GetBestChampionTarget().NetworkID);

                if (hero != null && hero.IsValidTarget(Range))
                {
                    this.ItemCheckEnemyLowHealth(hero);
                }
            }
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckOnlyOnMe))
            {
                if (!UnitManager.MyChampion.BuffManager.HasBuff(ItemBuffName))
                {
                    this.ItemCheckLowHealth(UnitManager.MyChampion);
                    this.ItemCheckLowMana(UnitManager.MyChampion);
                }
            }
            else
            {
                foreach (var hero in UnitManager.Allies.Select(unit => unit as AIHeroClient))
                {
                    if (UnitManager.MyChampion.Position.Distance(hero.Position) <= Range)
                    {
                        this.ItemCheckLowHealth(hero);
                        this.ItemCheckLowMana(hero);
                    }
                }
            }
        }
    }
}