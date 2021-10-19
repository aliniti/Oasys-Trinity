namespace Trinity
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Helpers;
    using Items;
    using Oasys.Common;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.EventsProvider;
    using Oasys.Common.Menu;
    using Oasys.SDK.Menu;
    using Spells;

    public class Bootstrap
    {
        public static List<Champion> AllChampions = new();
        private static List<ActiveItemBase> AllItems = new();
        private static List<AutoSpellBase> AllSpells = new();

        private static readonly List<ActiveItemBase> InitializedTickItems = new();
        private static readonly List<ActiveItemBase> InitializedInputItems = new();
        private static readonly List<AutoSpellBase> InitializedTickSpells = new();

        [Oasys.SDK.OasysModuleEntryPoint]
        public static void Execute()
        {
            GameEvents.OnGameLoadComplete += GameEvents_OnGameLoadComplete;
            GameEvents.OnGameMatchComplete += GameEvents_OnGameMatchComplete;
        }

        private static async Task GameEvents_OnGameLoadComplete()
        {
            AllItems.AddRange(ConsumableItems);
            AllItems.AddRange(CleanseItems);
            AllItems.AddRange(OffensiveItems);
            AllItems.AddRange(KleptoItems);
            //AllSpells.AddRange(AutoSpells);

            Initialize();
            NewHeroCache();
            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync += CoreEvents_OnCoreMainInputAsync;
        }

        private static async Task GameEvents_OnGameMatchComplete()
        {
            AllItems.Clear();
            CoreEvents.OnCoreMainTick -= CoreEvents_OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync -= CoreEvents_OnCoreMainInputAsync;
        }

        private static readonly List<AutoSpell> AutoSpells = new()
        {
            new AutoSpell(90, "Annie", SpellSlot.E, Enums.TargetingType.UnitAlly, 
                800, new [] { Enums.ActivationType.CheckAllyLowHP })
        };

        private static readonly List<ActiveItem> KleptoItems = new()
        {
            // item: Elixir_Of_Skill
            new ActiveItem(100, ItemID.Elixir_Of_Skill, Enums.TargetingType.ProximityAlly, 
                float.MaxValue,new[] { Enums.ActivationType.CheckOnlyOnMe }),

            // item: Sly_Sack_of_Gold
            new ActiveItem(100, ItemID.Sly_Sack_of_Gold, Enums.TargetingType.ProximityAlly, 
                float.MaxValue,new[] { Enums.ActivationType.CheckOnlyOnMe }),

            // item: Oracles_Extract
            new ActiveItem(100, ItemID.Oracles_Extract, Enums.TargetingType.ProximityAlly, 
                float.MaxValue, new[] { Enums.ActivationType.CheckOnlyOnMe }),

            // item: Looted_Oracles_Extract
            new ActiveItem(100, ItemID.Looted_Oracles_Extract, Enums.TargetingType.ProximityAlly,
                float.MaxValue, new[] { Enums.ActivationType.CheckOnlyOnMe }),

            // item: Pilfered_Potion_of_Rouge
            new ActiveItem(100, ItemID.Pilfered_Potion_of_Rouge, Enums.TargetingType.ProximityAlly, 
                float.MaxValue, new[] { Enums.ActivationType.CheckOnlyOnMe }),

            // item: Travel_Size_Elixir_of_Iron
            new ActiveItem(100, ItemID.Travel_Size_Elixir_of_Iron, Enums.TargetingType.ProximityAlly, 
                float.MaxValue, new[] { Enums.ActivationType.CheckOnlyOnMe }),

            // item: Travel_Size_Elixir_of_Sorcery
            new ActiveItem(100, ItemID.Travel_Size_Elixir_of_Sorcery, Enums.TargetingType.ProximityAlly, 
                float.MaxValue, new[] { Enums.ActivationType.CheckOnlyOnMe }),

            // item: Travel_Size_Elixir_of_Wrath
            new ActiveItem(100, ItemID.Travel_Size_Elixir_of_Wrath, Enums.TargetingType.ProximityAlly, 
                float.MaxValue, new[] { Enums.ActivationType.CheckOnlyOnMe }),

            // item: Mana_Potion
            new ActiveItem(100, ItemID.Mana_Potion, Enums.TargetingType.ProximityAlly, 
                float.MaxValue, new[] { Enums.ActivationType.CheckAllyLowMP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Pilfered_Health_Potion
            new ActiveItem(100, ItemID.Pilfered_Health_Potion, Enums.TargetingType.ProximityAlly, 
                float.MaxValue, new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckOnlyOnMe })
        };

        private static readonly List<ActiveItem> OffensiveItems = new()
        {
            // item: Twin_Shadows
            new ActiveItem(90, ItemID.Twin_Shadows, Enums.TargetingType.ProximityEnemy, 1100,
                new[]  { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckAllyLowHP }),

            // item: Youmuus_Ghostblade
            new ActiveItem(90, ItemID.Youmuus_Ghostblade, Enums.TargetingType.ProximityEnemy, 1100, 
                new[] { Enums.ActivationType.CheckEnemyLowHP}),

            // item: Bilgewater_Cutlass
            new ActiveItem(90, ItemID.Bilgewater_Cutlass, Enums.TargetingType.UnitEnemy, 575,
                new[]  { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Blade_of_the_Ruined_King
            new ActiveItem(90, ItemID.Blade_of_the_Ruined_King, Enums.TargetingType.UnitEnemy, 575,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Hextech_GLP_800
            new ActiveItem(90, ItemID.Hextech_GLP_800, Enums.TargetingType.SkillshotEnemy, 575,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Hextech_Protobelt_RocketBelt
            new ActiveItem(90, ItemID.Hextech_Protobelt_RocketBelt, Enums.TargetingType.SkillshotEnemy, 575,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Hextech_Gunblade
            new ActiveItem(90, ItemID.Hextech_Gunblade, Enums.TargetingType.UnitEnemy, 575,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe })
        };

        private static readonly List<ActiveItem> CleanseItems = new()
        {
            // item: Quicksilver_Sash
            new ActiveItem(100, ItemID.Quicksilver_Sash, Enums.TargetingType.ProximityAlly, 1100, 
                new [] { Enums.ActivationType.CheckAuras, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Mercurial_Scimitar
            new ActiveItem(100, ItemID.Mercurial_Scimitar, Enums.TargetingType.ProximityAlly, 1100, 
                new [] { Enums.ActivationType.CheckAuras, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Dervish_Blade
            new ActiveItem(100, ItemID.Dervish_Blade, Enums.TargetingType.ProximityAlly, 1100,
                new[] { Enums.ActivationType.CheckAuras, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Mikaels_Crucible
            new ActiveItem(20, ItemID.Mikaels_Crucible, Enums.TargetingType.ProximityAlly, 600,
                new[] { Enums.ActivationType.CheckAuras, Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP  }),
        };

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
                new[] { Enums.ActivationType.CheckOnlyOnMe }, 
                "ElixirOfIron"),
            
            // item: Elixir_of_Wrath
            new ActiveItem(100, ItemID.Elixir_of_Wrath, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe }, 
                "ElixirOfWrath"),
            
            // item: Elixir_of_Sorcery
            new ActiveItem(100, ItemID.Elixir_of_Sorcery, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe }, 
                "ElixirOfSorcery"),
            
            // item: Your_Cut (Pyke Assist)
            new ActiveItem(100, ItemID.Your_Cut, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe }),
        };

        private static void Initialize()
        {
            #region Tidy : Offensive Item Menu

            var offensseItemMenu = new Tab("Trinity: Offense");

            foreach (var item in OffensiveItems)
            {
                item.OnItemInitialize += () => InitializedInputItems.Add(item);
                item.OnItemDispose += () => InitializedInputItems.Remove(item);
                item.Initialize(offensseItemMenu);
            }

            MenuManager.AddTab(offensseItemMenu);
            #endregion

            #region Tidy : Cosumable Item Menu

            var consumablesItemMenu = new Tab("Trinity: Regen");

            foreach (var item in ConsumableItems)
            {
                item.OnItemInitialize += () => InitializedTickItems.Add(item);
                item.OnItemDispose += () => InitializedTickItems.Remove(item);
                item.Initialize(consumablesItemMenu);
            }

            MenuManager.AddTab(consumablesItemMenu);
            #endregion

            #region Tidy : Cleanse Item Menu

            var cleanseItemMenu = new Tab("Trinity: Cleanse");

            foreach (var item in CleanseItems)
            {
                item.OnItemInitialize += () => InitializedTickItems.Add(item);
                item.OnItemDispose += () => InitializedTickItems.Remove(item);
                item.Initialize(cleanseItemMenu);
            }

            MenuManager.AddTab(cleanseItemMenu);
            #endregion

            #region Tidy : Klepto Items

            var kleptoItemMenu = new Tab("Trinity: Klepto");

            foreach (var item in KleptoItems)
            {
                item.OnItemInitialize += () => InitializedTickItems.Add(item);
                item.OnItemDispose += () => InitializedTickItems.Remove(item);
                item.Initialize(kleptoItemMenu);
            }

            MenuManager.AddTab(kleptoItemMenu);
            #endregion

            var autoSpellsMenu = new Tab("Trinity: Auto Spells");
            foreach (var spell in AutoSpells)
            {
                spell.OnSpellInitialize += () => InitializedTickSpells.Add(spell);
                spell.OnSpellDispose += () => InitializedTickSpells.Remove(spell);
                spell.Initialize(autoSpellsMenu);
            }

            MenuManager.AddTab(autoSpellsMenu);
        }

        private static void NewHeroCache()
        {
            foreach (var u in ObjectManagerExport.HeroCollection)
            {
                var hero = u.Value;
                if (hero.IsAlive)
                {
                    AllChampions.Add(new Champion(hero));
                }
            }
        }

        private static async Task CoreEvents_OnCoreMainTick()
        {
            foreach (var initializedOnTickItem in InitializedTickItems)
            {
                initializedOnTickItem.OnTick();
            }
        }

        private static async Task CoreEvents_OnCoreMainInputAsync()
        {
            foreach (var initializedInputItem in InitializedInputItems)
            {
                initializedInputItem.OnTick();
            }
        }
    }
}
