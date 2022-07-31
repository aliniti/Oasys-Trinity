using System;

namespace Trinity
{
    #region
    
    using Base;
    using Helpers;
    using Items;
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

    #endregion

    public static class Bootstrap
    {
        #region Static Fields and Constants
        
        public static Dictionary<uint, Champion> Allies = new();
        public static Dictionary<uint, Champion> Enemies = new(); 
        
        public static readonly List<ActiveItemBase> AllItems = new();
        public static readonly List<AutoSpellBase> AllSpells = new();
        
        private static readonly List<BuffBase> AllAuras = new();
        private static readonly List<BuffBase> InitializedAuras = new();
        
        private static readonly List<ParticleEmitterBase> AllParticleEmitters = new();
        private static readonly List<ParticleEmitterBase> InitializedParticleEmitters = new();

        private static readonly List<ChampionBase> AllChampions = new();
        private static readonly List<ChampionBase> InitializedChampions = new();
        
        private static readonly List<ActiveItemBase> InitializedTickItems = new();
        private static readonly List<ActiveItemBase> InitializedInputItems = new();
        
        private static readonly List<AutoSpellBase> InitializedTickSpells = new();
        private static readonly List<AutoSpellBase> InitializedInputSpells = new();

        #region DefensiveItemsList
        
        /// <summary>
        ///     The defensive items
        /// </summary>
        private static readonly List<ActiveItem> DefensiveItems = new()
        {
            // item: Stopwatch
            new ActiveItem(35, ItemID.Stopwatch, TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),

            // item: Zhonyas_Hourglass
            new ActiveItem(35, ItemID.Zhonyas_Hourglass, TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),

            // item: Locket_of_the_Iron_Solari
            new ActiveItem(55, ItemID.Locket_of_the_Iron_Solari, TargetingType.ProximityAlly, 600,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckDangerous }),

            // item: Redemption
            new ActiveItem(55, ItemID.Redemption, TargetingType.ProximityAlly, 5500,
                new[] { ActivationType.CheckAllyLowHP }),

            // item: Seraphs_Embrace
            new ActiveItem(55, ItemID.Seraphs_Embrace, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),

            // item: Shurelyas_Battlesong
            new ActiveItem(55, ItemID.Shurelyas_Battlesong, TargetingType.ProximityAlly, 450,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckDangerous, ActivationType.CheckAllyLowHP }),

            // item: Gargoyle_Stoneplate
            new ActiveItem(2, ItemID.Gargoyle_Stoneplate, TargetingType.ProximityEnemy, 450,
                new[] { ActivationType.CheckProximityCount, ActivationType.CheckOnlyOnMe }),

            // item: Zekes Convergence
            new BindingItem(100, ItemID.Zekes_Convergence, "3050ally", TargetingType.BindingUnit, 1200,
                new[] { ActivationType.CheckAllyLowHP })

            //// item: Knights Vow
            //new BindingItem(100, ItemID.Knights_Vow, "itemknightsvowliege", TargetingType.BindingUnit, 1200,
            //    new[] { ActivationType.CheckAllyLowHP })
        };
        
        #endregion

        #region OffensiveItemsList
        
        /// <summary>
        ///     The offensive items
        /// </summary>
        private static readonly List<ActiveItem> OffensiveItems = new()
        {
            // item: Ironspike_Whip
            new ActiveItem(90, ItemID.Ironspike_Whip, TargetingType.ProximityEnemy, 450,
                new[]
                {
                    ActivationType.CheckEnemyLowHP, ActivationType.CheckProximityCount,
                    ActivationType.CheckOnlyOnMe
                }),

            // item: Stridebreaker
            new ActiveItem(90, ItemID.Stridebreaker, TargetingType.ProximityEnemy, 450,
                new[]
                {
                    ActivationType.CheckEnemyLowHP, ActivationType.CheckProximityCount,
                    ActivationType.CheckOnlyOnMe
                }),

            // item: Goredrinker
            new ActiveItem(90, ItemID.Goredrinker, TargetingType.ProximityEnemy, 450,
                new[]
                {
                    ActivationType.CheckEnemyLowHP, ActivationType.CheckProximityCount,
                    ActivationType.CheckOnlyOnMe
                }),

            // item: Prowlers_Claw
            new ActiveItem(90, ItemID.Prowlers_Claw, TargetingType.EnemyUnit, 500,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Everfrost
            new ActiveItem(90, ItemID.Everfrost, TargetingType.SkillshotEnemy, 525,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Youmuus_Ghostblade
            new ActiveItem(90, ItemID.Youmuus_Ghostblade, TargetingType.ProximityEnemy, 1100,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Blade_of_the_Ruined_King
            new ActiveItem(90, ItemID.Blade_of_The_Ruined_King, TargetingType.EnemyUnit, 575,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Hextech_Protobelt_RocketBelt
            new ActiveItem(75, ItemID.Hextech_Rocketbelt, TargetingType.SkillshotEnemy, 575,
                new[] { ActivationType.CheckEnemyLowHP, ActivationType.CheckOnlyOnMe }),

            // item: Randuins_Omen
            new ActiveItem(2, ItemID.Randuins_Omen, TargetingType.ProximityEnemy, 450,
                new[] { ActivationType.CheckProximityCount, ActivationType.CheckOnlyOnMe })
        };
        
        #endregion

        #region CleanseItemsList
        
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
            new ActiveItem(20, ItemID.Mikaels_Blessing, TargetingType.AllyUnit, 600,
                new[] { ActivationType.CheckAuras, ActivationType.CheckAllyLowHP }),

            // item: Silvermere_Dawn
            new ActiveItem(100, ItemID.Silvermere_Dawn, TargetingType.ProximityAlly, 1100,
                new[] { ActivationType.CheckAuras, ActivationType.CheckOnlyOnMe })
        };

        #endregion
        
        #region ConsumableItemsList
        
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
                new[]
                {
                    ActivationType.CheckAllyLowHP, ActivationType.CheckAllyLowMP,
                    ActivationType.CheckOnlyOnMe
                },
                "ItemDarkCrystalFlask"),

            // item: Total_Biscuit_of_Rejuvenation
            new ActiveItem(65, ItemID.Total_Biscuit_of_Everlasting_Will, TargetingType.ProximityAlly, float.MaxValue,
                new[]
                {
                    ActivationType.CheckAllyLowHP, ActivationType.CheckAllyLowMP,
                    ActivationType.CheckOnlyOnMe
                },
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
        
        #endregion

        #region SummonerInputSpellsList
        
        /// <summary>
        ///     The summoner input spells
        /// </summary>
        private static readonly List<AutoSpell> SummonerInputSpells = new()
        {
            new Ignite(55, "Ignite", "SummonerDot", TargetingType.EnemyUnit, 600,
                new[] { ActivationType.CheckEnemyLowHP }),

            new AutoSpell(55, "Exhaust", "SummonerExhaust", TargetingType.EnemyUnit, 650,
                new[] { ActivationType.CheckEnemyLowHP })
        };

        #endregion
        
        #region SummonerTickSpellsList
        
        /// <summary>
        ///     The summoner tick spells
        /// </summary>
        private static readonly List<AutoSpell> SummonerTickSpells = new()
        {
            new AutoSpell(25, "Heal", "SummonerHeal", TargetingType.ProximityAlly, 850,
                new[] { ActivationType.CheckAllyLowHP }),

            new Smite(100, "Smite", "SummonerSmite", TargetingType.EnemyUnit, 500,
                new ActivationType[] { }),

            new AutoSpell(25, "Barrier", "SummonerBarrier", TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            new AutoSpell(100, "Cleanse", "SummonerBoost", TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAuras, ActivationType.CheckOnlyOnMe })
        };

        #endregion

        #region AutomaticSpellsList
        
        /// <summary>
        ///     The automatic spells
        /// </summary>
        private static readonly List<AutoSpell> AutoSpells = new()
        {
            #region Shield Spells

            new AutoSpell(90, "Orianna", CastSlot.E, TargetingType.AllyUnit, 1100,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Diana", CastSlot.W, TargetingType.ProximityAlly, float.MaxValue,
                new[]
                {
                    ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, 
                    ActivationType.CheckPlayerMana, ActivationType.CheckOnlyOnMe
                }),

            new AutoSpell(90, "Janna", CastSlot.E, TargetingType.AllyUnit, 800,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Garen", CastSlot.W, TargetingType.ProximityAlly, float.MaxValue,
                new[]
                {
                    ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous,
                    ActivationType.CheckPlayerMana, ActivationType.CheckOnlyOnMe
                }),

            new AutoSpell(90, "Lulu", CastSlot.E, TargetingType.AllyUnit, 650,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Lux", CastSlot.W, TargetingType.SkillshotAlly, 1075,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Annie", CastSlot.E, TargetingType.SkillshotAlly, 800,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Nautilus", CastSlot.W, TargetingType.ProximityAlly, float.MaxValue,
                new[]
                {
                    ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous,
                    ActivationType.CheckPlayerMana,ActivationType.CheckOnlyOnMe
                }),

            #endregion

            #region Low-HP Spells

            new AutoSpell(25, "Zilean", CastSlot.R, TargetingType.AllyUnit, 900,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(25, "Kindred", CastSlot.R, TargetingType.AllyUnit, 400,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(25, "Aatrox", CastSlot.R, TargetingType.AllyUnit, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            new AutoSpell(25, "Lulu", CastSlot.R, TargetingType.AllyUnit, 900,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(25, "Tryndamere", CastSlot.R, TargetingType.AllyUnit, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            new AutoSpell(25, "Soraka", CastSlot.R, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(25, "Kayle", CastSlot.R, TargetingType.AllyUnit, 900,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous }),

            new AutoSpell(25, "Mundo", CastSlot.R, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            #endregion

            #region Healing Spells

            new AutoSpell(90, "Kayle", CastSlot.W, TargetingType.AllyUnit, 900,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Nami", CastSlot.W, TargetingType.AllyUnit, 725,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Seraphine", CastSlot.W, TargetingType.ProximityAlly, 800,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Sona", CastSlot.W, TargetingType.ProximityAlly, 1000,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckPlayerMana }),

            #endregion

            #region Evader Spells

            new AutoSpell(55, "MasterYi", CastSlot.Q, TargetingType.DodgeEnemyUnitOrMinion, 600,
                new[] { ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),
            
            new AutoSpell(55, "Maokai", CastSlot.W, TargetingType.DodgeEnemyUnitOrMinion, 525,
                new[] { ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),
            
            new AutoSpell(55, "Sivir", CastSlot.E, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),
            
            new AutoSpell(55, "Nocturne", CastSlot.W, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),
            
            new AutoSpell(55, "Morgana", CastSlot.E, TargetingType.AllyUnit, 750,
                new[] { ActivationType.CheckDangerous, ActivationType.CheckPlayerMana }),
            
            new AutoSpell(35, "Lissandra", CastSlot.R, TargetingType.AllyUnit, float.MaxValue,
                new[] { ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),
            
            new AutoSpell(35, "Zed", CastSlot.R, TargetingType.DodgeEnemyUnit, 625,
                new[] { ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),
            
            
            #endregion

            #region Unique Spells
            
            new BindingSpell(35, "Kalista", "kalistacoopstrikeally", CastSlot.R, TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAllyLowHP })

            #endregion
        };
        
        #endregion
        
        #region AurasList
        
        /// <summary>
        ///     The auras for income damage prediction
        /// </summary>
        private static readonly List<Buff> Auras = new ()
        {
            new Buff("All", "summonerdot"),
            new Buff("All", "itemsmitechallenge"),
            new Buff("Ahri", "ahrifoxfire", 525f),
            new Buff("Alistar", "alistare", 300f),
            new Buff("Amumu", "auraofdespair", 175f),
            new Buff("Brand", "brandablaze"),
            new Buff("Cassiopeia", "cassiopeiaqdebuff"),
            new Buff("Darius", "dariushemo"),
            new Buff("Diana", "dianashield", 200f),
            new Buff("DrMundo", "drmundow", 325f),
            new Buff("FiddleSticks", "fiddlestickswdrain"),
            new Buff("Fizz", "fizzwdot"),
            new Buff("Gangplank", "gangplankpassiveattackdot"),
            new Buff("Garen", "garene", 300f),
            new Buff("Hecarim", "hecarimdefilelifeleech"),
            new Buff("Jayce", "jaycestaticfield", 285f),
            new Buff("Jax", "jaxcounterstrike", 200f),
            new Buff("Kennen", "kennenlightningrush", 165f),
            new Buff("Kennen", "kennenshurikenstorm", 525f, 0.69, 0, EmulationFlags.Ultimate),
            new Buff("Leona", "leonasolarbarrier", 425f),
            new Buff("Leblanc", "leblance", 1, 1250, EmulationFlags.CrowdControl),
            new Buff("Leblanc", "leblancre", 1, 1250, EmulationFlags.CrowdControl),
            new Buff("Lissandra", "lissandrarself", 600f),
            new Buff("Malzahar", "malzahare"),
            new Buff("Morgana", "morganardebuff", 1, 2750, EmulationFlags.Ultimate),
            new Buff("Nidalee", "nidaleepassivehunted"),
            new Buff("Shyvana", "shyvanaimmolationaura", 175f),
            new Buff("Shyvana", "shyvanaimmolatedragon", 250f),
            new Buff("Shyvana", "shyvanafireballmissile"),
            new Buff("Talon", "talonbleeddebuf"),
            new Buff("Teemo", "bantamtraptarget"),
            new Buff("Teemo", "toxicshotparticle"),
            new Buff("Tristana", "tristanaechargesound"),
            new Buff("Twitch", "twitchdeadlyvenon"),
            new Buff("Velkoz", "velkozresearchstack"),
            new Buff("Vladimir", "vladimirhemoplaguedebuff", 1, 2750, EmulationFlags.Ultimate),
            new Buff("Yasuo", "yasuorknockupcombo"),
            new Buff("Yasuo", "yasuorknockupcombotar"),
            new Buff("Zed", "zedrdeathmark", 1, 2750, EmulationFlags.Ultimate),
            new Buff("Zac", "zacemove", 300f, 0.69, 0f, EmulationFlags.CrowdControl)
        };
        
        #endregion
        
        #region ParticleEmittersList
        
        /// <summary>
        ///     The particle emitters for income damage prediction
        /// </summary>
        private static readonly List<ParticleEmitter> ParticleEmitters = new()
        {  
            new ParticleEmitter("Akshan", "R_mis", 100, 1, 0, EmulationFlags.Ultimate),
            new ParticleEmitter("Lux", "e_tar_aoe", 175, 0.65),
            new ParticleEmitter("Qiyana", "R_Indicator_Ring", 175, 1, 0f, EmulationFlags.Ultimate),
            new ParticleEmitter("Renekton", "R_buf", 266, 0.65),
            new ParticleEmitter("Nasus", "SpiritFire", 385, 0.65),
            new ParticleEmitter("Nasus", "R_Avatar", 266, 0.65),
            new ParticleEmitter("Annie", "AnnieTibbers", 266),
            new ParticleEmitter("Alistar", "E_TrampleAOE", 266),
            new ParticleEmitter("Ryze", "_E", 100),
            new ParticleEmitter("Gangplank", "_R", 400, 1.3),
            new ParticleEmitter("Morgana", "W_tar", 275, 0.75),
            new ParticleEmitter("Hecarim", "Hecarim_Defile", 400, 0.75),
            new ParticleEmitter("Hecarim", "W_AoE", 400, 0.75),
            new ParticleEmitter("Diana", "W_Shield", 225, 1),
            new ParticleEmitter("Sion", "W_Shield", 225, 1),
            new ParticleEmitter("Karthus", "P_Defile", 400, 0.35),
            new ParticleEmitter("Karthus", "E_Defile", 400, 0.35),
            new ParticleEmitter("Karthus", "R_Target", 100, 1, 750f, EmulationFlags.Ultimate),
            new ParticleEmitter("Elise", "W_volatile", 250, 0.3),
            new ParticleEmitter("FiddleSticks", "Crowstorm", 400, 0.5, 0f, EmulationFlags.Ultimate),
            new ParticleEmitter("Fizz", "R_Ring", 300, 1, 800, EmulationFlags.Ultimate),
            new ParticleEmitter("Fizz", "E1_Indicator_Ring", 300, 1, 800, EmulationFlags.Danger),
            new ParticleEmitter("Katarina", "deathLotus_tar", 500, 0.6, 0f, EmulationFlags.Ultimate),
            new ParticleEmitter("Nautilus", "R_sequence_impact", 250, 1, 0f, EmulationFlags.Ultimate),
            new ParticleEmitter("Kennen", "lr_buf", 250, 0.8),
            new ParticleEmitter("Kennen", "ss_aoe", 450, 0.5, 0f, EmulationFlags.Ultimate),
            new ParticleEmitter("Caitlyn", "yordleTrap", 265),
            new ParticleEmitter("Caitlyn", "R_mis", 100, 1, 0, EmulationFlags.Ultimate),
            new ParticleEmitter("Viktor", "_ChaosStorm", 425, 0.5, 0f, EmulationFlags.Ultimate),
            new ParticleEmitter("Viktor", "_Catalyst", 375, 0.5, 0f, EmulationFlags.CrowdControl),
            new ParticleEmitter("Viktor", "W_AUG", 375, 0.5, 0f, EmulationFlags.CrowdControl),
            new ParticleEmitter("Anivia", "cryo_storm", 400),
            new ParticleEmitter("Ziggs", "ZiggsE", 325),
            new ParticleEmitter("Ziggs", "ZiggsWRing", 325, 0.5, 0f, EmulationFlags.CrowdControl),
            new ParticleEmitter("Soraka", "E_rune", 375, 0.5, 500f, EmulationFlags.CrowdControl),
            new ParticleEmitter("Cassiopeia", "Miasma_tar", 150)
        };
        
        #endregion

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The Oasys module entry point
        /// </summary>
        [Oasys.SDK.OasysModuleEntryPoint]
        public static void Execute()
        {
            GameEvents.OnGameLoadComplete += OnGameLoadComplete;
            GameEvents.OnGameMatchComplete += OnGameMatchComplete;
        }

        #endregion

        #region Private Methods and Operators

        /// <summary>
        ///     Games events [on game load complete].
        /// </summary>
        private static async Task OnGameLoadComplete()
        {
            CoreEvents.OnCoreMainTick += OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync += OnCoreMainInputAsync;
            CoreEvents.OnCoreRender += OnCoreRender;
            
            Oasys.SDK.Events.GameEvents.OnCreateObject += OnCreateObject;
            Oasys.SDK.Events.GameEvents.OnDeleteObject += OnDeleteObject;

            AllAuras.AddRange(Auras);
            AllParticleEmitters.AddRange(ParticleEmitters);
            AllSpells.AddRange(AutoSpells);
            AllSpells.AddRange(SummonerInputSpells);
            AllSpells.AddRange(SummonerTickSpells);
            AllItems.AddRange(ConsumableItems);
            AllItems.AddRange(DefensiveItems);
            AllItems.AddRange(CleanseItems);
            AllItems.AddRange(OffensiveItems);

            // initialize champion objects
            foreach (var h in ObjectManagerExport.HeroCollection)
            {
                var hero = h.Value;
                if (hero != null)
                {
                    AllChampions.Add(new Champion(hero));
                }
            }
            
            InitializeTrinity();
        }

        /// <summary>
        ///     Games events [on game match complete].
        /// </summary>
        private static async Task OnGameMatchComplete()
        {
            CoreEvents.OnCoreMainTick -= OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync -= OnCoreMainInputAsync;
            CoreEvents.OnCoreRender -= OnCoreRender;
            
            Oasys.SDK.Events.GameEvents.OnCreateObject -= OnCreateObject;
            Oasys.SDK.Events.GameEvents.OnDeleteObject -= OnDeleteObject;

            AllItems.Clear();
            AllSpells.Clear();
            AllParticleEmitters.Clear();
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

            #region Tidy : Prediction Menu

            var config = new Tab("Trinity: Prediction");

            foreach (var troy in ParticleEmitters)
            {
                troy.OnEmitterInitialize += () => InitializedParticleEmitters.Add(troy);
                troy.OnEmitterDispose += () => InitializedParticleEmitters.Remove(troy);
                troy.Initialize(config);
            }
            
            foreach (var championBase in AllChampions)
            {
                var hero = (Champion) championBase;
                hero.OnChampionInitialize += () => InitializedChampions.Add(hero);
                hero.OnChampionDispose += () => InitializedChampions.Remove(hero);
                hero.Initialize(config, hero);
            }
            
            foreach (var aura in Auras)
            {
                aura.OnAuraInitialize += () => InitializedAuras.Add(aura);
                aura.OnAuraDispose += () => InitializedAuras.Remove(aura);
                aura.Initialize(config);
            }

            MenuManager.AddTab(config);

            #endregion
        }

        /// <summary>
        ///     Cores events [on core main tick].
        /// </summary>
        private static async Task OnCoreMainTick()
        {
            if (!GameEngine.IsGameWindowFocused) return;

            foreach (var initializedEmitter in InitializedParticleEmitters)
                initializedEmitter.OnTick();
            
            foreach (var initializedAura in InitializedAuras)
                initializedAura.OnTick();
            
            foreach (var initializedTickItem in InitializedTickItems)
                initializedTickItem.OnTick();

            foreach (var initializedTickSpell in InitializedTickSpells)
                initializedTickSpell.OnTick();

            foreach (var initializedChampion in InitializedChampions)
                initializedChampion.OnTick();
        }

        /// <summary>
        ///     Cores events [on core main input asynchronous].
        /// </summary>
        private static async Task OnCoreMainInputAsync()
        {
            if (!GameEngine.IsGameWindowFocused) return;
            
            foreach (var initializedInputItem in InitializedInputItems)
                initializedInputItem.OnTick();

            foreach (var initializedInputSpell in InitializedInputSpells)
                initializedInputSpell.OnTick();
        }

        /// <summary>
        ///     Cores events [on core render].
        /// </summary>
        private static void OnCoreRender()
        {
            if (!GameEngine.IsGameWindowFocused) return;
            
            foreach (var initializedTickItem in InitializedTickItems)
                initializedTickItem.OnRender();

            foreach (var initializedTickSpell in InitializedTickSpells)
                initializedTickSpell.OnRender();
        }

        /// <summary>
        ///     Game events [on create object].
        /// </summary>
        private static async Task OnCreateObject(List<AIBaseClient> callbackobjectlist, AIBaseClient callbackobject, float callbackgametime)
        {
            foreach (var initializedEmitter in InitializedParticleEmitters)
                initializedEmitter.OnCreate(callbackobjectlist, callbackobject, callbackgametime);
        }
        
        /// <summary>
        ///     Game events [on delete object].
        /// </summary>
        private static async Task OnDeleteObject(List<AIBaseClient> callbackobjectlist, AIBaseClient callbackobject, float callbackgametime)
        {
            foreach (var initializedEmitter in InitializedParticleEmitters)
                initializedEmitter.OnDelete(callbackobjectlist, callbackobject, callbackgametime);
        }

        #endregion
    }
}