namespace Trinity
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Helpers;
    using Items;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.EventsProvider;
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
            AllItems.AddRange(PostAttackItems);

            Initialize();
            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
        }

        private static async Task GameEvents_OnGameMatchComplete()
        {
            CoreEvents.OnCoreMainTick -= CoreEvents_OnCoreMainTick;
        }

        private static List<ActiveItemBase> AllItems = new();
        private static readonly List<ActiveItemBase> InitializedTickItems = new();
        private static readonly List<ActiveItemBase> InitializedPostAttackItems = new();

  
        private static readonly List<ActiveItem> ConsumableItems = new()
        {
            // item: Health_Potion
            new ActiveItem(ItemID.Health_Potion, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP }),
            
            // item: Refillable_Potion
            new ActiveItem(ItemID.Refillable_Potion, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP }),
            
            // item: Corrupting_Potion
            new ActiveItem(ItemID.Corrupting_Potion, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckAllyLowMP }),
            
            // item: Total_Biscuit_of_Rejuvenation
            new ActiveItem(ItemID.Total_Biscuit_of_Rejuvenation, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckAllyLowMP }),
            
            // item: Elixir_of_Iron
            new ActiveItem(ItemID.Elixir_of_Iron, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] {Enums.ActivationType.CheckOnlyOnMe }),
            
            // item: Elixir_of_Wrath
            new ActiveItem(ItemID.Elixir_of_Wrath, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] {Enums.ActivationType.CheckOnlyOnMe }),
            
            // item: Elixir_of_Sorcery
            new ActiveItem(ItemID.Elixir_of_Sorcery, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] {Enums.ActivationType.CheckOnlyOnMe }),
            
            // item: Your_Cut (Pyke Assist)
            new ActiveItem(ItemID.Your_Cut, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe }),
        };

        private static readonly List<ActiveItem> PostAttackItems = new()
        {
            // item: tiamat
            new ActiveItem(ItemID.Tiamat, Enums.TargetingType.ProximityEnemy, 350,
                new[] {Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.PostAttack }),
            
            // item: titanic_hydra
            new ActiveItem(ItemID.Titanic_Hydra, Enums.TargetingType.ProximityEnemy, float.MaxValue,
                new[] {Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.PostAttack }),
            
            // item: ravenous_hydra
            new ActiveItem(ItemID.Ravenous_Hydra, Enums.TargetingType.ProximityEnemy, 350,
                new[] {Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.PostAttack })
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

            var postAttackItemMenu = new Tab("Trinity: PostAttack");

            foreach (var item in PostAttackItems)
            {
                item.OnItemInitialize += () => InitializedPostAttackItems.Add(item);
                item.OnItemDispose += () => InitializedPostAttackItems.Remove(item);
                item.Initialize(postAttackItemMenu);
            }

            MenuManager.AddTab(postAttackItemMenu);
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
