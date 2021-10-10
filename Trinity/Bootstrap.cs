namespace Trinity
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Helpers;
    using Items;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.EventsProvider;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.GameObject.Clients.ExtendedInstances.Spells;
    using Oasys.Common.Menu;
    using Oasys.SDK;
    using Oasys.SDK.Menu;

    public class Bootstrap
    {
        [OasysModuleEntryPoint]
        public static void Execute()
        {
            GameEvents.OnGameLoadComplete += GameEvents_OnGameLoadComplete;
            GameEvents.OnGameMatchComplete += GameEvents_OnGameMatchComplete;
        }

        private static async Task GameEvents_OnGameLoadComplete()
        {
            AllItems.AddRange(ConsumableItems);
            //AllItems.AddRange(PostAttackItems);

            Initialize();
            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
            //GameEvents.OnGameProcessSpell += GameEvents_OnGameProcessSpell;
        }

        private static async Task GameEvents_OnGameMatchComplete()
        {
            CoreEvents.OnCoreMainTick -= CoreEvents_OnCoreMainTick;
        }

        private static List<ActiveItemBase> AllItems = new();
        private static readonly List<ActiveItemBase> InitializedTickItems = new();

        private static readonly List<ActiveItem> ConsumableItems = new()
        {
            // item: Health_Potion
            new ActiveItem(55, ItemID.Health_Potion, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP }, 
                "Item2003"),
            
            // item: Refillable_Potion
            new ActiveItem(55, ItemID.Refillable_Potion, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP }, 
                "ItemCrystalFlask"),
            
            // item: Corrupting_Potion
            new ActiveItem(55, ItemID.Corrupting_Potion, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckAllyLowMP },
                "ItemDarkCrystalFlask"),
            
            // item: Total_Biscuit_of_Rejuvenation
            new ActiveItem(55, ItemID.Total_Biscuit_of_Everlasting_Will, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckAllyLowMP }, 
                "Item2010"),
            
            // item: Elixir_of_Iron
            new ActiveItem(100, ItemID.Elixir_of_Iron, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] {Enums.ActivationType.CheckOnlyOnMe }, 
                "ElixirOfIron"),
            
            // item: Elixir_of_Wrath
            new ActiveItem(100, ItemID.Elixir_of_Wrath, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] {Enums.ActivationType.CheckOnlyOnMe }, 
                "ElixirOfWrath"),
            
            // item: Elixir_of_Sorcery
            new ActiveItem(100, ItemID.Elixir_of_Sorcery, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] {Enums.ActivationType.CheckOnlyOnMe }, 
                "ElixirOfSorcery"),
            
            // item: Your_Cut (Pyke Assist)
            new ActiveItem(100, ItemID.Your_Cut, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe }),
        };

        private static void Initialize()
        {
 
            var consumablesItemMenu = new Tab("Trinity: Regen");

            foreach (var item in ConsumableItems)
            {
                item.OnItemInitialize += () => InitializedTickItems.Add(item);
                item.OnItemDispose += () => InitializedTickItems.Remove(item);
                item.Initialize(consumablesItemMenu);
            }

            MenuManager.AddTab(consumablesItemMenu);
        }

        private static async Task CoreEvents_OnCoreMainTick()
        {
            foreach (var initializedNormalTickItem in InitializedTickItems)
            {
                initializedNormalTickItem.OnTick();
            }
        }
    }

}
