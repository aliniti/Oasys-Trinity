namespace Trinity.Items
{
    using Oasys.SDK;
    using Oasys.Common.Enums.GameEnums;
    using System.Linq;
    using Helpers;
    
    public class ActiveItem : ActiveItemBase
    {
        public int LastUsedTimeStamp { get; set; }
        public Enums.ActivationType[] ActivationTypes { get; set; }
        public Enums.TargetingType TargetingType { get; set; }

        public ActiveItem(ItemID itemId, Enums.TargetingType tType, float range,  Enums.ActivationType[] aTypes)
        {
            TargetingType = tType;
            Range = range;
            ActivationTypes = aTypes;
            ItemId = itemId;
        }
        
        public override void CreateTab()
        {
            // the enable disable switch
            this.CreateTabEnableSwitch();
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckAllyLowHP))
                this.CreateTabAllyLowHealth(65);
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckEnemyLowHP))
                this.CreateTabEnemyLowHealth(90);
            
            if (ActivationTypes.Contains(Enums.ActivationType.CheckAllyLowMP))
                this.CreateTabAllyLowMana(35);
        }

        public override void OnTick()
        {
            this.ItemCheckLowHealth(UnitManager.MyChampion);
            this.ItemCheckLowMana(UnitManager.MyChampion);
        }
        
        public override void OnPostAttack()
        {

        }
    }
}