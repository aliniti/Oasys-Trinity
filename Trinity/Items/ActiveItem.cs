namespace Trinity.Items
{
    using Helpers;
    using Oasys.SDK;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.Extensions;
    using System.Linq;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK.Tools;

    public class ActiveItem : ActiveItemBase
    {
        public int UsePct { get; set; }
        public int LastUsedTimeStamp { get; set; }
        public Enums.ActivationType[] ActivationTypes { get; set; }
        public string ItemBuffName { get; set; }
        public Enums.TargetingType TargetingType { get; set; }

        public ActiveItem(int usePct, ItemID itemId, Enums.TargetingType tType, float range, Enums.ActivationType[] aTypes, 
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
            this.CreateItemTabEnableSwitch();
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckAllyLowHP))
                this.CreateItemTabAllyLowHealth(UsePct);
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckEnemyLowHP))
                this.CreateItemTabEnemyLowHealth(UsePct);
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckAllyLowMP))
                this.CreateItemTabAllyLowMana(UsePct);

            if (ActivationTypes.Contains(Enums.ActivationType.CheckAuras))
                this.CreateItemTabAuraCleanse(UsePct);
        }

        public override void OnTick()
        {
            if (TargetingType.ToString().Contains("Enemy"))
            {
                if (TargetSelector.GetBestChampionTarget() is AIHeroClient target && target.IsValidTarget())
                {
                    this.ItemCheckEnemyLowHealth(target);
                }
            }

            if (ActivationTypes.Contains(Enums.ActivationType.CheckOnlyOnMe))
            {
                if (!UnitManager.MyChampion.BuffManager.HasBuff(ItemBuffName))
                {
                    this.ItemCheckAllyLowHealth(UnitManager.MyChampion);
                    this.ItemCheckAllyLowMana(UnitManager.MyChampion);
                    this.ItemCheckAuras(UnitManager.MyChampion);
                }
            }
            else
            {
                foreach (var u in Bootstrap.Allies)
                {
                    var hero = u.Value;
                    if (hero.Instance.Team == UnitManager.MyChampion.Team)
                    {
                        if (UnitManager.MyChampion.Position.Distance(hero.Instance.Position) <= Range && hero.InWayDanger)
                        {
                            this.ItemCheckAllyLowHealth(hero.Instance);
                            this.ItemCheckAllyLowMana(hero.Instance);
                            this.ItemCheckAuras(hero.Instance);
                        }
                    }
                }
            }
        }
    }
}