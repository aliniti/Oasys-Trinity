namespace Trinity
{
    using System;
    using Base;
    using Items;
    using Helpers;
    using Spells;
    using Spells.UniqueSpells;
    using Oasys.Common;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.EventsProvider;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.Menu;
    using Oasys.SDK;
    using Oasys.SDK.Menu;
    using Oasys.SDK.SpellCasting;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Oasys.SDK.Tools;

    public class Bootstrap
    {
        public static Dictionary<uint, Champion> Allies = new();
        public static Dictionary<uint, Champion> Enemies = new();

        private static readonly List<ActiveItemBase> AllItems = new();
        private static readonly List<AutoSpellBase> AllSpells = new();

        private static readonly List<ActiveItemBase> InitializedTickItems = new();
        private static readonly List<ActiveItemBase> InitializedInputItems = new();

        private static readonly List<AutoSpellBase> InitializedTickSpells = new();
        private static readonly List<AutoSpellBase> InitializedInputSpells = new();

        [Oasys.SDK.OasysModuleEntryPoint]
        public static void Execute()
        {
            GameEvents.OnGameLoadComplete += GameEvents_OnGameLoadComplete;
            GameEvents.OnGameMatchComplete += GameEvents_OnGameMatchComplete;
        }

        private static async Task GameEvents_OnGameLoadComplete()
        {
            AllSpells.AddRange(AutoSpells);
            AllSpells.AddRange(SummonerInputSpells);
            AllSpells.AddRange(SummonerTickSpells);
            AllItems.AddRange(ConsumableItems);
            AllItems.AddRange(DefensiveItems);
            AllItems.AddRange(CleanseItems);
            AllItems.AddRange(OffensiveItems);

            try
            {
                Initialize();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync += CoreEvents_OnCoreMainInputAsync;
        }

        private static async Task GameEvents_OnGameMatchComplete()
        {
            AllItems.Clear();
            AllSpells.Clear();
            CoreEvents.OnCoreMainTick -= CoreEvents_OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync -= CoreEvents_OnCoreMainInputAsync;
        }

        private static readonly List<ActiveItem> DefensiveItems = new()
        {
            // item: Stopwatch
            new ActiveItem(40, ItemID.Stopwatch, Enums.TargetingType.ProximityAlly, 1200,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Zhonyas_Hourglass
            new ActiveItem(40, ItemID.Zhonyas_Hourglass, Enums.TargetingType.ProximityAlly, 1200,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Locket_of_the_Iron_Solari
            new ActiveItem(65, ItemID.Locket_of_the_Iron_Solari, Enums.TargetingType.ProximityAlly, 600,
                new[] { Enums.ActivationType.CheckAllyLowHP }),

            // item: Redemption
            new ActiveItem(35, ItemID.Redemption, Enums.TargetingType.ProximityAlly, 5500,
                new[] { Enums.ActivationType.CheckAllyLowHP }),

            // item: Seraphs_Embrace
            new ActiveItem(55, ItemID.Seraphs_Embrace, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Shurelyas_Battlesong
            new ActiveItem(55, ItemID.Shurelyas_Battlesong, Enums.TargetingType.ProximityAlly, 450,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckAllyLowHP }),

            // item: Gargoyle_Stoneplate
            new ActiveItem(2, ItemID.Gargoyle_Stoneplate, Enums.TargetingType.ProximityEnemy, 450,
                new[] { Enums.ActivationType.CheckAoECount, Enums.ActivationType.CheckOnlyOnMe }),
        };

        private static readonly List<ActiveItem> OffensiveItems = new()
        {
            // item: Ironspike_Whip
            new ActiveItem(90, ItemID.Ironspike_Whip, Enums.TargetingType.ProximityEnemy, 450,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckAoECount, 
                    Enums.ActivationType.CheckOnlyOnMe }),

            // item: Stridebreaker
            new ActiveItem(90, ItemID.Stridebreaker, Enums.TargetingType.ProximityEnemy, 450,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckAoECount, 
                    Enums.ActivationType.CheckOnlyOnMe }),

            // item: Goredrinker
            new ActiveItem(90, ItemID.Goredrinker, Enums.TargetingType.ProximityEnemy, 450,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckAoECount, 
                    Enums.ActivationType.CheckOnlyOnMe }),

            // item: Prowlers_Claw
            new ActiveItem(90, ItemID.Prowlers_Claw, Enums.TargetingType.UnitEnemy, 500,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Everfrost
            new ActiveItem(90, ItemID.Everfrost, Enums.TargetingType.SkillshotEnemy, 525,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Youmuus_Ghostblade
            new ActiveItem(90, ItemID.Youmuus_Ghostblade, Enums.TargetingType.ProximityEnemy, 1100,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Blade_of_the_Ruined_King
            new ActiveItem(90, ItemID.Blade_of_The_Ruined_King, Enums.TargetingType.UnitEnemy, 575,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Hextech_Protobelt_RocketBelt
            new ActiveItem(75, ItemID.Hextech_Rocketbelt, Enums.TargetingType.SkillshotEnemy, 575,
                new[] { Enums.ActivationType.CheckEnemyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Randuins_Omen
            new ActiveItem(2, ItemID.Randuins_Omen, Enums.TargetingType.ProximityEnemy, 450,
                new[] { Enums.ActivationType.CheckAoECount, Enums.ActivationType.CheckOnlyOnMe }),
        };

        private static readonly List<ActiveItem> CleanseItems = new()
        {
            // item: Quicksilver_Sash
            new ActiveItem(100, ItemID.Quicksilver_Sash, Enums.TargetingType.ProximityAlly, 1100,
                new[] { Enums.ActivationType.CheckAuras, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Mercurial_Scimitar
            new ActiveItem(100, ItemID.Mercurial_Scimitar, Enums.TargetingType.ProximityAlly, 1100,
                new[] { Enums.ActivationType.CheckAuras, Enums.ActivationType.CheckOnlyOnMe }),

            // item: Mikaels_Crucible
            new ActiveItem(20, ItemID.Mikaels_Blessing, Enums.TargetingType.UnitAlly, 600,
                new[] { Enums.ActivationType.CheckAuras, Enums.ActivationType.CheckAllyLowHP }),

            // item: Silvermere_Dawn
            new ActiveItem(100, ItemID.Silvermere_Dawn, Enums.TargetingType.ProximityAlly, 1100,
                new[] { Enums.ActivationType.CheckAuras, Enums.ActivationType.CheckOnlyOnMe }),
        };

        private static readonly List<ActiveItem> ConsumableItems = new()
        {
            // item: Health_Potion
            new ActiveItem(65, ItemID.Health_Potion, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP },
                "Item2003"),

            // item: Refillable_Potion
            new ActiveItem(65, ItemID.Refillable_Potion, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP },
                "ItemCrystalFlask"),

            // item: Corrupting_Potion
            new ActiveItem(65, ItemID.Corrupting_Potion, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckOnlyOnMe, Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckAllyLowMP },
                "ItemDarkCrystalFlask"),

            // item: Total_Biscuit_of_Rejuvenation
            new ActiveItem(65, ItemID.Total_Biscuit_of_Everlasting_Will, Enums.TargetingType.ProximityAlly, float.MaxValue,
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
                new[] { Enums.ActivationType.CheckOnlyOnMe })
        };

        private static readonly List<AutoSpell> SummonerInputSpells = new()
        {
            new Ignite(55, "Ignite", "SummonerDot",Enums.TargetingType.UnitEnemy, 600, 
                new [] { Enums.ActivationType.CheckEnemyLowHP }),

            new AutoSpell(55, "Exhaust", "SummonerExhaust", Enums.TargetingType.UnitEnemy, 650,
                new[] { Enums.ActivationType.CheckEnemyLowHP }),
        };

        private static readonly List<AutoSpell> SummonerTickSpells = new()
        {
            new AutoSpell(35, "Barrier", "SummonerBarrier", Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            new AutoSpell(35, "Heal", "SummonerHeal", Enums.TargetingType.ProximityAlly, 850,
                new[] { Enums.ActivationType.CheckAllyLowHP }),

            new AutoSpell(100, "Cleanse", "SummonerBoost", Enums.TargetingType.ProximityAlly, 1200,
                new[] { Enums.ActivationType.CheckAuras, Enums.ActivationType.CheckOnlyOnMe }),
        };

        private static readonly List<AutoSpell> AutoSpells = new()
        {
            #region Shield Spells

            new AutoSpell(90, "Orianna", CastSlot.E, Enums.TargetingType.UnitAlly, 1100,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckPlayerMana }),

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

            #region Anti-Kill Secure Spells

            new AutoSpell(20, "Zilean", CastSlot.R, Enums.TargetingType.UnitAlly, 900,
                new[] { Enums.ActivationType.CheckAllyLowHP }),

            new AutoSpell(20, "Kindred", CastSlot.R, Enums.TargetingType.UnitAlly, 400,
                new[] { Enums.ActivationType.CheckAllyLowHP }),

            new AutoSpell(20, "Aatrox", CastSlot.R, Enums.TargetingType.UnitAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            new AutoSpell(20, "Lulu", CastSlot.R, Enums.TargetingType.UnitAlly, 900,
                new[] { Enums.ActivationType.CheckAllyLowHP }),

            new AutoSpell(20, "Tryndamere", CastSlot.R, Enums.TargetingType.UnitAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

            new AutoSpell(35, "Soraka", CastSlot.R, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP }),

            new AutoSpell(25, "Mundo", CastSlot.R, Enums.TargetingType.ProximityAlly, float.MaxValue,
                new[] { Enums.ActivationType.CheckAllyLowHP, Enums.ActivationType.CheckOnlyOnMe }),

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

            #region Evader Spells

            #endregion

            #region Unique Spells

            new Kalista(25, "Kalista", CastSlot.R, Enums.TargetingType.ProximityAlly, 1200,
                new[] { Enums.ActivationType.CheckAllyLowHP })

            #endregion
        };

        private static void Initialize()
        {
            #region Tidy: Defensive Item Menu

            var defensiveItemMenu = new Tab("Trinity: Defensive");

            foreach (var item in DefensiveItems)
            {
                item.OnItemInitialize += () => InitializedTickItems.Add(item);
                item.OnItemDispose += () => InitializedTickItems.Remove(item);
                item.Initialize(defensiveItemMenu);
            }

            MenuManager.AddTab(defensiveItemMenu);

            #endregion

            #region Tidy : Offensive Item Menu

            var offensiveItemMenu = new Tab("Trinity: Offensive");

            foreach (var item in OffensiveItems)
            {
                item.OnItemInitialize += () => InitializedInputItems.Add(item);
                item.OnItemDispose += () => InitializedInputItems.Remove(item);
                item.Initialize(offensiveItemMenu);
            }

            MenuManager.AddTab(offensiveItemMenu);

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

            #region Tidy : Summoner Spells Menu

            var summonerSpellMenu = new Tab("Trinity: Summoners");

            foreach (var spell in SummonerTickSpells)
            {
                spell.OnSpellInitialize += () => InitializedTickSpells.Add(spell);
                spell.OnSpellDispose += () => InitializedTickSpells.Remove(spell);
                spell.Initialize(summonerSpellMenu);
            }

            foreach (var spell in SummonerInputSpells)
            {
                spell.OnSpellInitialize += () => InitializedInputSpells.Add(spell);
                spell.OnSpellDispose += () => InitializedInputSpells.Remove(spell);
                spell.Initialize(summonerSpellMenu);
            }

            MenuManager.AddTab(summonerSpellMenu);

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
                if (unit.Value is AIHeroClient hero)
                {
                    if (hero.Team == UnitManager.MyChampion.Team)
                    {
                        if (!Allies.ContainsKey(hero.NetworkID))
                        {
                            Allies[hero.NetworkID] = new Champion(hero);
                            break;
                        }
                    }
                    else
                    {
                        if (!Enemies.ContainsKey(hero.NetworkID))
                        {
                            Enemies[hero.NetworkID] = new Champion(hero);
                            break;
                        }
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

            foreach (var initializedInputSpell in InitializedInputSpells)
            {
                initializedInputSpell.OnTick();
            }
        }
    }
}