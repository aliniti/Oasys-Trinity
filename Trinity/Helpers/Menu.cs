using Oasys.Common.Menu.ItemComponents;
using Trinity.Items;

namespace Trinity.Helpers
{
    public static class Menu
    {
        public static void CreateTabEnableSwitch(this ActiveItem item)
        {
            item.ItemSwitch[item.ItemId.ToString()] = new Switch
            {
                IsOn = true,
                Title = "Use " + item.ItemId
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId.ToString()]);
        }
        
        public static void CreateTabAllyLowHealth(this ActiveItem item, int pctUse = 80)
        {
            item.ItemCounter[item.ItemId.ToString()] = new Counter
            {
                Title = "Use " + item.ItemId + " at Ally Percent HP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };

            item.ItemTab.AddItem(item.ItemCounter[item.ItemId.ToString()]);
        }

        public static void CreateTabAllyLowMana(this ActiveItem item, int pctUse = 55)
        {
            item.ItemCounter[item.ItemId.ToString()] = new Counter
            {
                Title = "Use " + item.ItemId + " at Ally Percent MP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };
            
            item.ItemTab.AddItem(item.ItemCounter[item.ItemId.ToString()]);
        }

        public static void CreateTabEnemyLowHealth(this ActiveItem item, int pctUse = 95)
        {
            item.ItemCounter[item.ItemId.ToString()] = new Counter
            {
                Title = "Use " + item.ItemId + " at Enemy Percent HP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };
            
            item.ItemTab.AddItem(item.ItemCounter[item.ItemId.ToString()]);
        }
        
        
    }
}