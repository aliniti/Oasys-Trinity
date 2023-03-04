// ReSharper disable CollectionNeverQueried.Global
namespace Trinity.Helpers
{
    #region

    using System.Collections.Generic;
    using Base;
    using Items;
    using Oasys.Common;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.SDK.SpellCasting;
    using Spells;
    using Spells.UniqueSpells;

    #endregion

    public static class Lists
    {
        #region Static Fields and Constants

        public static readonly List<ActiveItemBase> AllItems = new();
        public static readonly List<AutoSpellBase> AllSpells = new();

        public static readonly List<BuffBase> AllAuras = new();
        public static readonly List<BuffBase> InitializedAuras = new();

        public static readonly List<ParticleBase> AllParticles = new();
        public static readonly List<ParticleBase> InitializedParticles = new();

        public static readonly List<ChampionBase> AllChampions = new();
        public static readonly List<ChampionBase> InitializedChampions = new();

        public static readonly List<ActiveItemBase> InitializedTickItems = new();
        public static readonly List<ActiveItemBase> InitializedInputItems = new();

        public static readonly List<AutoSpellBase> InitializedTickSpells = new();
        public static readonly List<AutoSpellBase> InitializedInputSpells = new();

        public static readonly Dictionary<ItemID, string> TranslationEng = new()
        {
            [ItemID.Everfrost] = "Everfrost",
            [ItemID.Ironspike_Whip] = "Ironspike Whip",
            [ItemID.Prowlers_Claw] = "Prowler's Claw",
            [ItemID.Goredrinker] = "Goredrinker",
            [ItemID.Gargoyle_Stoneplate] = "Gargoyle Stoneplate",
            [ItemID.Stridebreaker] = "Stridebreaker",
            [ItemID.Silvermere_Dawn] = "Silvermere Dawn",
            [ItemID.Seraphs_Embrace] = "Seraph's Embrace",
            [ItemID.Edge_of_Night] = "Edge of Night",
            [ItemID.Randuins_Omen] = "Randuin's Omen",
            [ItemID.Frostfang] = "Timeworn Frost Queen's Claim",
            [ItemID.Youmuus_Ghostblade] = "Youmuu's Ghostblade",
            [ItemID.Gargoyle_Stoneplate] = "Gargoyle Stoneplate",
            [ItemID.Knights_Vow] = "Knight's Vow",
            [ItemID.Redemption] = "Redemption",
            [ItemID.Zekes_Convergence] = "Zeke's Convergence",
            [ItemID.Shurelyas_Battlesong] = "Shurelya's Battlesong",
            [ItemID.Locket_of_the_Iron_Solari] = "Locket of the Iron Solari",
            [ItemID.Control_Ward] = "Control Ward",
            [ItemID.Oracle_Lens] = "Oracle Lens",
            [ItemID.Farsight_Alteration] = "Farsight Alteration",
            [ItemID.Health_Potion] = "Health Potion",
            [ItemID.Elixir_of_Wrath] = "Elixir of Wrath",
            [ItemID.Elixir_of_Iron] = "Elixir of Iron",
            [ItemID.Elixir_of_Wrath] = "Elixir of Wrath",
            [ItemID.Elixir_of_Sorcery] = "Elixir of Sorcery",
            [ItemID.Refillable_Potion] = "Refillable Potion",
            [ItemID.Corrupting_Potion] = "Corrupting Potion",
            [ItemID.Total_Biscuit_of_Everlasting_Will] = "Biscuit",
            [ItemID.Mikaels_Blessing] = "Mikael's Blessing",
            [ItemID.Quicksilver_Sash] = "Quicksilver Sash",
            [ItemID.Mercurial_Scimitar] = "Mercurial Scimitar",
            [ItemID.Stopwatch] = "Stopwatch",
            [ItemID.Perfectly_Timed_Stopwatch] = "Perfectly Timed Stopwatch",
            [ItemID.Zhonyas_Hourglass] = "Zhonya's Hourglass",
            [ItemID.Your_Cut] = "Your Cut (Pyke)",
            [ItemID.Blade_of_The_Ruined_King] = "Blade of the Ruined King",
            [ItemID.Hextech_Rocketbelt] = "Hextech Protobelt",
            [ItemID.Tiamat] = "Tiamat",
            [ItemID.Titanic_Hydra] = "Titanic Hydra",
            [ItemID.Ravenous_Hydra] = "Ravenous Hydra",
            [ItemID.Anathemas_Chains] = "Anathema's Chains"
        };

        /// <summary>
        ///     The auras for income damage prediction
        /// </summary>
        public static readonly List<Buff> Auras = new ()
        {
            new Buff("All", "summonerdot"),
            //new Buff("All", "itemsmitechallenge"),
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

        /// <summary>
        ///     The particles for income damage prediction
        /// </summary>
        public static readonly List<Particle> Particles = new()
        {
            new Particle("Akshan", "R_mis", 100, 1, 0, EmulationFlags.Ultimate),
            new Particle("Lux", "e_tar_aoe", 175, 0.65),
            new Particle("Qiyana", "R_Indicator_Ring", 175, 1, 0f, EmulationFlags.Ultimate),
            new Particle("Renekton", "R_buf", 266, 0.65),
            new Particle("Nasus", "SpiritFire", 385, 0.65),
            new Particle("Nasus", "R_Avatar", 266, 0.65),
            new Particle("Annie", "AnnieTibbers", 266),
            new Particle("Alistar", "E_TrampleAOE", 266),
            new Particle("Ryze", "_E", 100),
            new Particle("Gangplank", "_R", 400, 1.3),
            new Particle("Morgana", "W_tar", 275, 0.75),
            new Particle("Hecarim", "Hecarim_Defile", 400, 0.75),
            new Particle("Hecarim", "W_AoE", 400, 0.75),
            new Particle("Diana", "W_Shield", 225, 1),
            new Particle("Sion", "W_Shield", 225, 1),
            new Particle("Karthus", "P_Defile", 400, 0.35),
            new Particle("Karthus", "E_Defile", 400, 0.35),
            new Particle("Karthus", "R_Target", 100, 1, 750f, EmulationFlags.Ultimate),
            new Particle("Elise", "W_volatile", 250, 0.3),
            new Particle("FiddleSticks", "Crowstorm", 400, 0.5, 0f, EmulationFlags.Ultimate),
            new Particle("Fizz", "R_Ring", 300, 1, 800, EmulationFlags.Ultimate),
            new Particle("Fizz", "E1_Indicator_Ring", 300, 1, 800, EmulationFlags.Danger),
            new Particle("Katarina", "deathLotus_tar", 500, 0.6, 0f, EmulationFlags.Ultimate),
            new Particle("Nautilus", "R_sequence_impact", 250, 1, 0f, EmulationFlags.Ultimate),
            new Particle("Kennen", "lr_buf", 250, 0.8),
            new Particle("Kennen", "ss_aoe", 450, 0.5, 0f, EmulationFlags.Ultimate),
            new Particle("Caitlyn", "yordleTrap", 265),
            new Particle("Caitlyn", "R_mis", 100, 1, 0, EmulationFlags.Ultimate),
            new Particle("Viktor", "_ChaosStorm", 425, 0.5, 0f, EmulationFlags.Ultimate),
            new Particle("Viktor", "_Catalyst", 375, 0.5, 0f, EmulationFlags.CrowdControl),
            new Particle("Viktor", "W_AUG", 375, 0.5, 0f, EmulationFlags.CrowdControl),
            new Particle("Riven", "Q_tar", 150),
            new Particle("Anivia", "cryo_storm", 400),
            new Particle("Ziggs", "ZiggsE", 325),
            new Particle("Ziggs", "ZiggsWRing", 325, 0.5, 0f, EmulationFlags.CrowdControl),
            new Particle("Soraka", "E_rune", 375, 0.5, 500f, EmulationFlags.CrowdControl),
            new Particle("Cassiopeia", "Miasma_tar", 150)
        };

        /// <summary>
        ///     The defensive items
        /// </summary>
        public static readonly List<ActiveItem> DefensiveItems = new()
        {
            // item: Stopwatch
            new ActiveItem(35, ItemID.Stopwatch, TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),
            
            // new ActiveItem(35, ItemID.Commencing_Stopwatch, TargetingType.ProximityAlly, 1200,
            //     new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),
            
            new ActiveItem(35, ItemID.Perfectly_Timed_Stopwatch, TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),

            // item: Zhonyas_Hourglass
            new ActiveItem(35, ItemID.Zhonyas_Hourglass, TargetingType.ProximityAlly, 1200,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),

            // item: Locket_of_the_Iron_Solari
            new ActiveItem(55, ItemID.Locket_of_the_Iron_Solari, TargetingType.ProximityAlly, 600,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckDangerous }),

            // item: Redemption
            new ActiveItem(55, ItemID.Redemption, TargetingType.SkillshotAlly, 5500,
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
            new BindingItem(100, ItemID.Zekes_Convergence, "3050ally", TargetingType.BindingUnitAlly, 1200,
                new[] { ActivationType.CheckAllyLowHP }),
            
            // item: Anathemas_Chains
            new BindingItem(100, ItemID.Anathemas_Chains, "8001EnemyDebuff", TargetingType.BindingUnitEnemy, float.MaxValue,
            new[] { ActivationType.CheckAllyLowHP })

            //// item: Knights Vow
            //new BindingItem(100, ItemID.Knights_Vow, "itemknightsvowliege", TargetingType.BindingUnit, 1200,
            //    new[] { ActivationType.CheckAllyLowHP })
        };

        /// <summary>
        ///     The offensive items
        /// </summary>
        public static readonly List<ActiveItem> OffensiveItems = new()
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
        public static readonly List<ActiveItem> CleanseItems = new()
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


        /// <summary>
        ///     The consumable items
        /// </summary>
        public static readonly List<ActiveItem> ConsumableItems = new()
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

        /// <summary>
        ///     The summoner input spells
        /// </summary>
        public static readonly List<AutoSpell> SummonerInputSpells = new()
        {
            new Ignite(55, "Ignite", "SummonerDot", TargetingType.EnemyUnit, 600,
                new[] { ActivationType.CheckEnemyLowHP }),

            new AutoSpell(55, "Exhaust", "SummonerExhaust", TargetingType.EnemyUnit, 650,
                new[] { ActivationType.CheckEnemyLowHP })
        };

        /// <summary>
        ///     The summoner tick spells
        /// </summary>
        public static readonly List<AutoSpell> SummonerTickSpells = new()
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

        /// <summary>
        ///     The automatic spells
        /// </summary>
        public static readonly List<AutoSpell> AutoSpells = new()
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

            new AutoSpell(90, "Annie", CastSlot.E, TargetingType.AllyUnit, 800,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous, ActivationType.CheckPlayerMana }),

            new AutoSpell(90, "Nautilus", CastSlot.W, TargetingType.ProximityAlly, float.MaxValue,
                new[]
                {
                    ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous,
                    ActivationType.CheckPlayerMana, ActivationType.CheckOnlyOnMe
                }),

            #endregion

            #region Low-HP Spells

            new AutoSpell(25, "Zilean", CastSlot.R, TargetingType.AllyUnit, 900,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(25, "Kindred", CastSlot.R, TargetingType.ProximityAlly, 400,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(25, "Aatrox", CastSlot.R, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            new AutoSpell(25, "Lulu", CastSlot.R, TargetingType.AllyUnit, 900,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(25, "Tryndamere", CastSlot.R, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckOnlyOnMe }),

            new AutoSpell(25, "Soraka", CastSlot.R, TargetingType.ProximityAlly, float.MaxValue,
                new[] { ActivationType.CheckAllyLowHP }),

            new AutoSpell(25, "Kayle", CastSlot.R, TargetingType.AllyUnit, 900,
                new[] { ActivationType.CheckAllyLowHP, ActivationType.CheckDangerous }),

            new AutoSpell(25, "DrMundo", CastSlot.R, TargetingType.ProximityAlly, float.MaxValue,
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

            new AutoSpell(55, "Fiora", CastSlot.W, TargetingType.DodgeEnemySkillshot, 900,
                new[] { ActivationType.CheckDangerous, ActivationType.CheckOnlyOnMe }),
            
            new AutoSpell(55, "Yasuo", CastSlot.W, TargetingType.DodgeEnemySkillshot, 900,
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

        #region Public Methods and Operators

        public static void Populate()
        {
            AllAuras.AddRange(Auras);
            AllParticles.AddRange(Particles);
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
        }

        public static void Dispose()
        {
            AllItems.Clear();
            AllSpells.Clear();
            AllChampions.Clear();
            AllParticles.Clear();
        }

        #endregion
    }
}