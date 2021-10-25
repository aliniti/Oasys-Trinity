namespace Trinity
{
    using Items;
    using Helpers;
    using Oasys.Common;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.EventsProvider;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.Menu;
    using Oasys.SDK.Menu;
    using Oasys.SDK.SpellCasting;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Spells;
    using Base;
    using Oasys.SDK;

    public class Bootstrap
    {
        public static Dictionary<uint, Champion> Allies = new();

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
            AllSpells.AddRange(AutoSpells);
            AllItems.AddRange(ConsumableItems);
            AllItems.AddRange(CleanseItems);
            AllItems.AddRange(OffensiveItems);
            AllItems.AddRange(KleptoItems);

            Initialize();
            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync += CoreEvents_OnCoreMainInputAsync;
        }

        private static async Task GameEvents_OnGameMatchComplete()
        {
            AllItems.Clear();
            CoreEvents.OnCoreMainTick -= CoreEvents_OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync -= CoreEvents_OnCoreMainInputAsync;
        }

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
            new ActiveItem(20, ItemID.Mikaels_Crucible, Enums.TargetingType.UnitAlly, 600,
                new[] { Enums.ActivationType.CheckAuras, Enums.ActivationType.CheckAllyLowHP  }),
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

        private static readonly List<AutoSpell> AutoSpells = new()
        {
            #region Shield Spells

            new AutoSpell(90, "Orianna", CastSlot.E, Enums.TargetingType.UnitAlly, 1100,
                new []{ Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana }),
            new AutoSpell(90, "Diana", CastSlot.W, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana, Enums.ActivationType.CheckOnlyOnMe }),
            new AutoSpell(90, "Janna", CastSlot.E, Enums.TargetingType.UnitAlly, 800,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana }),
            new AutoSpell(90, "Garen", CastSlot.W, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana, Enums.ActivationType.CheckOnlyOnMe }),
            new AutoSpell(90, "Lulu", CastSlot.E, Enums.TargetingType.UnitAlly, 650,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana }),
            new AutoSpell(90, "Lux", CastSlot.W, Enums.TargetingType.SkillshotAlly, 1075,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana }),
            new AutoSpell(90, "Annie", CastSlot.E, Enums.TargetingType.SkillshotAlly, 800,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana }),
            new AutoSpell(90, "Nautilus", CastSlot.W, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana, Enums.ActivationType.CheckOnlyOnMe }),

            #endregion

            #region Anti-Lethal Spells

            new AutoSpell(20, "Zilean", CastSlot.R, Enums.TargetingType.UnitAlly, 900,
                new[] { Enums.ActivationType.CheckAllyLowHP }),
            new AutoSpell(20, "Kindred", CastSlot.R, Enums.TargetingType.UnitAlly, 400, 
                new[] { Enums.ActivationType.CheckAllyLowHP }),
            new AutoSpell(20, "Aatrox", CastSlot.R, Enums.TargetingType.UnitAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP }),
            new AutoSpell(20, "Lulu", CastSlot.R, Enums.TargetingType.UnitAlly, 900,
                new[] { Enums.ActivationType.CheckAllyLowHP }),
            new AutoSpell(20, "Tryndamere", CastSlot.R, Enums.TargetingType.UnitAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP }),
            new AutoSpell(35, "Soraka", CastSlot.R, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP }),
            new AutoSpell(25, "Mundo", CastSlot.R, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP }),

            #endregion

            #region Healing Spells

            new AutoSpell(90, "Kayle", CastSlot.W, Enums.TargetingType.UnitAlly, 900,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Nami", CastSlot.W, Enums.TargetingType.UnitAlly, 725,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Seraphine", CastSlot.W, Enums.TargetingType.ProximityAlly, 800,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Sona", CastSlot.W, Enums.TargetingType.ProximityAlly, 1000,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana }),

            #endregion
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

            #region Tidy : Auto Spells Menu

            var autoSpellsMenu = new Tab("Trinity: Auto Spells");
            foreach (var spell in AutoSpells)
            {
                spell.OnSpellInitialize += () => InitializedTickSpells.Add(spell);
                spell.OnSpellDispose += () => InitializedTickSpells.Remove(spell);
                spell.Initialize(autoSpellsMenu);
            }

            MenuManager.AddTab(autoSpellsMenu);
            #endregion
        }

        private static async Task CoreEvents_OnCoreMainTick()
        {
            foreach (var initializedTickItem in InitializedTickItems)
            {
                initializedTickItem.OnTick();
            }

            foreach (var initializedTickSpell in InitializedTickSpells)
            {
                initializedTickSpell.OnTick();
            }

            foreach (var unit in ObjectManagerExport.HeroCollection)
            {
                if (unit.Value is AIHeroClient hero && Allies.ContainsKey(hero.NetworkID) == false)
                {
                    if (hero.Team == UnitManager.MyChampion.Team)
                    {
                        Allies[hero.NetworkID] = new Champion(hero);
                        break;
                    }
                }
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
