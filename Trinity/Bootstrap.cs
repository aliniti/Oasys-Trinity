namespace Trinity
{
    #region

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Base;
    using Helpers;
    using Items;
    using Oasys.Common;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.EventsProvider;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.Menu;
    using Oasys.SDK;
    using Oasys.SDK.Menu;
    using Oasys.SDK.SpellCasting;
    using Spells;
    using Spells.UniqueSpells;

    #endregion

    public class Bootstrap
    {
        #region Static Fields and Constants

        /// <summary>
        ///     The allies
        /// </summary>
        public static Dictionary<uint, Champion> Allies = new();

        /// <summary>
        ///     The enemies
        /// </summary>
        public static Dictionary<uint, Champion> Enemies = new();

        /// <summary>
        ///     All items
        /// </summary>
        public static readonly List<ActiveItemBase> AllItems = new();

        /// <summary>
        ///     All spells
        /// </summary>
        public static readonly List<AutoSpellBase> AllSpells = new();

        /// <summary>
        ///     The initialized tick items
        /// </summary>
        private static readonly List<ActiveItemBase> InitializedTickItems = new();

        /// <summary>
        ///     The initialized input items
        /// </summary>
        private static readonly List<ActiveItemBase> InitializedInputItems = new();

        /// <summary>
        ///     The initialized tick spells
        /// </summary>
        private static readonly List<AutoSpellBase> InitializedTickSpells = new();

        /// <summary>
        ///     The initialized input spells
        /// </summary>
        private static readonly List<AutoSpellBase> InitializedInputSpells = new();

        /// <summary>
        ///     The defensive items
        /// </summary>
        private static readonly List<ActiveItem> DefensiveItems = new()
        {
            // item: Stopwatch
            new ActiveItem(40, ItemID.Stopwatch, TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Zhonyas_Hourglass
            new ActiveItem(40, ItemID.Zhonyas_Hourglass, TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Locket_of_the_Iron_Solari
            new ActiveItem(65, ItemID.Locket_of_the_Iron_Solari, TargetingType.ProximityAlly, 600,
                new[] { ActivationType.CheckAllyLowHP }),

            // item: Redemption
            new ActiveItem(35, ItemID.Redemption, TargetingType.ProximityAlly, 5500,
                new[] { ActivationType.CheckAllyLowHP }),

            // item: Seraphs_Embrace
            new ActiveItem(55, ItemID.Seraphs_Embrace, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Shurelyas_Battlesong
            new ActiveItem(55, ItemID.Shurelyas_Battlesong, TargetingType.ProximityAlly, 450,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckAllyLowHP }),

            // item: Gargoyle_Stoneplate
            new ActiveItem(2, ItemID.Gargoyle_Stoneplate, TargetingType.ProximityEnemy, 450,
                new[] { ActivationType.CheckProximityCount, ActivationType.CheckOnlyOnMe })
        };

        /// <summary>
        ///     The offensive items
        /// </summary>
        private static readonly List<ActiveItem> OffensiveItems = new()
        {
            // item: Ironspike_Whip
            new ActiveItem(90, ItemID.Ironspike_Whip, TargetingType.ProximityEnemy, 450,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckProximityCount,
                    ActivationType.CheckOnlyOnMe }),

            // item: Stridebreaker
            new ActiveItem(90, ItemID.Stridebreaker, TargetingType.ProximityEnemy, 450,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckProximityCount,
                    ActivationType.CheckOnlyOnMe }),

            // item: Goredrinker
            new ActiveItem(90, ItemID.Goredrinker, TargetingType.ProximityEnemy, 450,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckProximityCount,
                    ActivationType.CheckOnlyOnMe }),

            // item: Prowlers_Claw
            new ActiveItem(90, ItemID.Prowlers_Claw, TargetingType.UnitEnemy, 500,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Everfrost
            new ActiveItem(90, ItemID.Everfrost, TargetingType.SkillshotEnemy, 525,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Youmuus_Ghostblade
            new ActiveItem(90, ItemID.Youmuus_Ghostblade, TargetingType.ProximityEnemy, 1100,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Blade_of_the_Ruined_King
            new ActiveItem(90, ItemID.Blade_of_The_Ruined_King, TargetingType.UnitEnemy, 575,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Hextech_Protobelt_RocketBelt
            new ActiveItem(75, ItemID.Hextech_Rocketbelt, TargetingType.SkillshotEnemy, 575,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Randuins_Omen
            new ActiveItem(2, ItemID.Randuins_Omen, TargetingType.ProximityEnemy, 450,
                new[] { ActivationType.CheckProximityCount, ActivationType.CheckOnlyOnMe })
        };

        /// <summary>
        ///     The cleanse items
        /// </summary>
        private static readonly List<ActiveItem> CleanseItems = new()
        {
            // item: Quicksilver_Sash
            new ActiveItem(100, ItemID.Quicksilver_Sash, TargetingType.ProximityAlly, 1100,
                new[] { ActivationType.CheckAuras, ActivationType.CheckOnlyOnMe }),

            // item: Mercurial_Scimitar
            new ActiveItem(100, ItemID.Mercurial_Scimitar, TargetingType.ProximityAlly, 1100,
                new[] { ActivationType.CheckAuras, ActivationType.CheckOnlyOnMe }),

            // item: Mikaels_Crucible
            new ActiveItem(20, ItemID.Mikaels_Blessing, TargetingType.UnitAlly, 600,
                new[] { ActivationType.CheckAuras, ActivationType.CheckAllyLowHP }),

            // item: Silvermere_Dawn
            new ActiveItem(100, ItemID.Silvermere_Dawn, TargetingType.ProximityAlly, 1100,
                new[] { ActivationType.CheckAuras, ActivationType.CheckOnlyOnMe })
        };

        /// <summary>
        ///     The consumable items
        /// </summary>
        private static readonly List<ActiveItem> ConsumableItems = new()
        {
            // item: Health_Potion
            new ActiveItem(65, ItemID.Health_Potion, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe },
                "Item2003"),

            // item: Refillable_Potion
            new ActiveItem(65, ItemID.Refillable_Potion, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe },
                "ItemCrystalFlask"),

            // item: Corrupting_Potion
            new ActiveItem(65, ItemID.Corrupting_Potion, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckAllyLowMP,
                    ActivationType.CheckOnlyOnMe },
                "ItemDarkCrystalFlask"),

            // item: Total_Biscuit_of_Rejuvenation
            new ActiveItem(65, ItemID.Total_Biscuit_of_Everlasting_Will, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckAllyLowMP, 
                    ActivationType.CheckOnlyOnMe },
                "Item2010"),

            // item: Elixir_of_Iron
            new ActiveItem(100, ItemID.Elixir_of_Iron, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe },
                "ElixirOfIron"),

            // item: Elixir_of_Wrath
            new ActiveItem(100, ItemID.Elixir_of_Wrath, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe },
                "ElixirOfWrath"),

            // item: Elixir_of_Sorcery
            new ActiveItem(100, ItemID.Elixir_of_Sorcery, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe },
                "ElixirOfSorcery"),

            // item: Your_Cut (Pyke Assist)
            new ActiveItem(100, ItemID.Your_Cut, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe })
        };

        /// <summary>
        ///     The summoner input spells
        /// </summary>
        private static readonly List<AutoSpell> SummonerInputSpells = new()
        {
            new Ignite(55, "Ignite", "SummonerDot", TargetingType.UnitEnemy, 600,
                new[] { ActivationType.CheckEnemyLowHP }),

            new AutoSpell(55, "Exhaust", "SummonerExhaust", TargetingType.UnitEnemy, 650,
                new[] { ActivationType.CheckEnemyLowHP })
        };

        /// <summary>
        ///     The summoner tick spells
        /// </summary>
        private static readonly List<AutoSpell> SummonerTickSpells = new()
        {
            new AutoSpell(35, "Heal", "SummonerHeal", TargetingType.ProximityAlly, 850,
                new[] { ActivationType.CheckAllyLowHP }),

            new Smite(100, "Smite", "SummonerSmite", TargetingType.UnitEnemy, 500,
                new ActivationType[] { }),

            new AutoSpell(35, "Barrier", "SummonerBarrier", TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            new AutoSpell(100, "Cleanse", "SummonerBoost", TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAuras, ActivationType.CheckOnlyOnMe }),
        };

        /// <summary>
        ///     The automatic spells
        /// </summary>
        private static readonly List<AutoSpell> AutoSpells = new()
        {
            #region Shield Spells

            new AutoSpell(90, "Orianna", CastSlot.E, TargetingType.UnitAlly, 1100,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Diana", CastSlot.W, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana, 
                    ActivationType.CheckOnlyOnMe }),

            new AutoSpell(90, "Janna", CastSlot.E, TargetingType.UnitAlly, 800,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Garen", CastSlot.W, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana, 
                    ActivationType.CheckOnlyOnMe }),

            new AutoSpell(90, "Lulu", CastSlot.E, TargetingType.UnitAlly, 650,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Lux", CastSlot.W, TargetingType.SkillshotAlly, 1075,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Annie", CastSlot.E, TargetingType.SkillshotAlly, 800,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Nautilus", CastSlot.W, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana,
                    ActivationType.CheckOnlyOnMe }),

            #endregion

            #region Anti-Kill Secure Spells

            new AutoSpell(35, "Zilean", CastSlot.R, TargetingType.UnitAlly, 900,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(35, "Kindred", CastSlot.R, TargetingType.UnitAlly, 400,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(35, "Aatrox", CastSlot.R, TargetingType.UnitAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            new AutoSpell(35, "Lulu", CastSlot.R, TargetingType.UnitAlly, 900,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(35, "Tryndamere", CastSlot.R, TargetingType.UnitAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            new AutoSpell(35, "Soraka", CastSlot.R, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(35, "Kayle", CastSlot.R, TargetingType.UnitAlly, 900,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(35, "Mundo", CastSlot.R, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            #endregion

            #region Healing Spells

            new AutoSpell(90, "Kayle", CastSlot.W, TargetingType.UnitAlly, 900,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Nami", CastSlot.W, TargetingType.UnitAlly, 725,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Seraphine", CastSlot.W, TargetingType.ProximityAlly, 800,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Sona", CastSlot.W, TargetingType.ProximityAlly, 1000,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            #endregion

            #region Evader Spells

            #endregion

            #region Unique Spells

            new Kalista(25, "Kalista", CastSlot.R, TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAllyLowHP })

            #endregion
        };

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The Oasys module entry point
        /// </summary>
        [Oasys.SDK.OasysModuleEntryPoint]
        public static void Execute()
        {
            GameEvents.OnGameLoadComplete += GameEvents_OnGameLoadComplete;
            GameEvents.OnGameMatchComplete += GameEvents_OnGameMatchComplete;
        }

        #endregion

        #region Private Methods and Operators

        /// <summary>
        ///     Games events [on game load complete].
        /// </summary>
        private static async Task GameEvents_OnGameLoadComplete()
        {
            AllSpells.AddRange(AutoSpells);
            AllSpells.AddRange(SummonerInputSpells);
            AllSpells.AddRange(SummonerTickSpells);
            AllItems.AddRange(ConsumableItems);
            AllItems.AddRange(DefensiveItems);
            AllItems.AddRange(CleanseItems);
            AllItems.AddRange(OffensiveItems);

            InitializeTrinity();

            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync += CoreEvents_OnCoreMainInputAsync;
            CoreEvents.OnCoreRender += CoreEvents_OnCoreRender;
        }

        /// <summary>
        ///     Games events [on game match complete].
        /// </summary>
        private static async Task GameEvents_OnGameMatchComplete()
        {
            AllItems.Clear();
            AllSpells.Clear();
            CoreEvents.OnCoreMainTick -= CoreEvents_OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync -= CoreEvents_OnCoreMainInputAsync;
        }


        /// <summary>
        ///     Initializes the trinity add-on.
        /// </summary>
        private static void InitializeTrinity()
        {
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

        /// <summary>
        ///     Gets the heroes.
        /// </summary>
        /// <param name="unit">The unit.</param>
        private static void GetHeroes(AIBaseClient unit)
        {
            if (unit is AIHeroClient hero)
            {
                if (hero.Team == UnitManager.MyChampion.Team)
                {
                    if (!Allies.ContainsKey(hero.NetworkID))
                    {
                        Allies[hero.NetworkID] = new Champion(hero);
                    }
                }
                else
                {
                    if (!Enemies.ContainsKey(hero.NetworkID))
                    {
                        Enemies[hero.NetworkID] = new Champion(hero);
                    }
                }
            }
        }

        /// <summary>
        ///     Cores events [on core main tick].
        /// </summary>
        private static async Task CoreEvents_OnCoreMainTick()
        {
            foreach (var initializedTickItem in InitializedTickItems)
                initializedTickItem.OnTick();

            foreach (var initializedTickSpell in InitializedTickSpells)
                initializedTickSpell.OnTick();

            foreach (var unit in ObjectManagerExport.HeroCollection)
                GetHeroes(unit.Value);
        }

        /// <summary>
        ///     Cores events [on core main input asynchronous].
        /// </summary>
        private static async Task CoreEvents_OnCoreMainInputAsync()
        {
            foreach (var initializedInputItem in InitializedInputItems)
                initializedInputItem.OnTick();

            foreach (var initializedInputSpell in InitializedInputSpells)
                initializedInputSpell.OnTick();
        }

        /// <summary>
        ///     Cores events [on core render].
        /// </summary>
        private static void CoreEvents_OnCoreRender()
        {
            foreach (var initializedTickItem in InitializedTickItems)
                initializedTickItem.OnRender();

            foreach (var initializedTickSpell in InitializedTickSpells)
                initializedTickSpell.OnRender();
        }

        #endregion
    }
}