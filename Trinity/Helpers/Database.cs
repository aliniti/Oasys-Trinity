namespace Trinity.Helpers
{
    #region

    using System.Collections.Generic;
    using Oasys.Common.Enums.GameEnums;

    #endregion

    public class SpellData
    {
        #region Properties and Encapsulation

        /// <summary>
        ///     Gets or sets the name of the spell.
        /// </summary>
        /// <value>
        ///     The name of the spell.
        /// </value>
        public string SpellName { get; internal set; }

        /// <summary>
        ///     Gets or sets the name of the champion.
        /// </summary>
        /// <value>
        ///     The name of the champion.
        /// </value>
        public string ChampionName { get; internal set; }

        /// <summary>
        ///     Gets or sets the slot.
        /// </summary>
        /// <value>
        ///     The slot.
        /// </value>
        public SpellSlot Slot { get; internal set; } = SpellSlot.NullSpell;

        /// <summary>
        ///     Gets or sets the cast range.
        /// </summary>
        /// <value>
        ///     The cast range.
        /// </value>
        public float CastRange { get; internal set; } = 250;

        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        /// <value>
        ///     The radius.
        /// </value>
        public float Radius { get; internal set; }

        /// <summary>
        ///     Gets or sets a value indicating whether spell is global.
        /// </summary>
        /// <value>
        ///     <c>true</c> if spell is global; otherwise, <c>false</c>.
        /// </value>
        public bool Global { get; internal set; }

        /// <summary>
        ///     Gets or sets the delay.
        /// </summary>
        /// <value>
        ///     The delay.
        /// </value>
        public float Delay { get; internal set; } = 250f;

        /// <summary>
        ///     Gets or sets a value indicating whether is fixed range.
        /// </summary>
        /// <value>
        ///     <c>true</c> if is fixed range; otherwise, <c>false</c>.
        /// </value>
        public bool FixedRange { get; internal set; }

        /// <summary>
        ///     Gets or sets the name of the missile.
        /// </summary>
        /// <value>
        ///     The name of the missile.
        /// </value>
        public string MissileName { get; internal set; } = "";

        /// <summary>
        ///     Gets or sets the extra missile names.
        /// </summary>
        /// <value>
        ///     The extra missile names.
        /// </value>
        public string[] ExtraMissileNames { get; internal set; } = { "" };

        /// <summary>
        ///     Gets or sets the missile speed.
        /// </summary>
        /// <value>
        ///     The missile speed.
        /// </value>
        public int MissileSpeed { get; internal set; } = 4800;

        /// <summary>
        ///     Gets or sets from object.
        /// </summary>
        /// <value>
        ///     From object.
        /// </value>
        public string[] FromObject { get; internal set; } = { "" };

        /// <summary>
        ///     Gets or sets the event types.
        /// </summary>
        /// <value>
        ///     The event types.
        /// </value>
        public EmulationType[] EmulationTypes { get; internal set; } = { };

        /// <summary>
        ///     Gets the type of the cast.
        /// </summary>
        /// <value>
        ///     The type of the cast.
        /// </value>
        public CastType CastType { get; internal set; } = CastType.Proximity;

        /// <summary>
        ///     Gets the collisional values
        /// </summary>
        /// <value>
        ///     What it collides with.
        /// </value>
        public CollisionObjectType[] CollidesWith { get; internal set; } = { };

        /// <summary>
        ///     Gets a value indicating whether this instance is perpindicular.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is perpindicular; otherwise, <c>false</c>.
        /// </value>
        public bool IsPerpindicular { get; internal set; }

        /// <summary>
        ///     Gets a value indicating whether the spell is a basic attack amplifier.
        /// </summary>
        /// <value><c>true</c> if it is a basic attack amplifier; otherwise, <c>false</c>.</value>
        public bool BasicAttackAmplifier { get; internal set; }

        /// <summary>
        ///     Gets the process.
        /// </summary>
        /// <value>
        ///     The type of process.
        /// </value>
        public bool NoProcess { get; internal set; } = false;

        /// <summary>
        ///     Gets the extra end time.
        /// </summary>
        /// <value>
        ///     The extra end time.
        /// </value>
        public int ExtraEndTime { get; internal set; } = 0;

        #endregion

        #region Static Fields and Constants

        /// <summary>
        ///     The dangerous spells list
        /// </summary>
        public static List<SpellData> HeroSpells = new List<SpellData>();

        #endregion

        #region Constructors and Destructors
        
        static SpellData()
        {
            HeroSpells.Add(new SpellData
            {
                SpellName = "aatroxq",
                ChampionName = "aatrox",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 875f,
                Radius = 200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aatroxw",
                ChampionName = "aatrox",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                BasicAttackAmplifier = true,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aatroxw2",
                ChampionName = "aatrox",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                BasicAttackAmplifier = true,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aatroxe",
                ChampionName = "aatrox",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1025f,
                Radius = 150f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "aatroxeconemissile",
                MissileSpeed = 1250
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aatroxr",
                ChampionName = "aatrox",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ahriorbofdeception",
                ChampionName = "ahri",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 900f,
                Radius = 80f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "ahriorbmissile",
                ExtraMissileNames = new[] { "ahriorbreturn" },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ahrifoxfire",
                ChampionName = "ahri",
                Slot = SpellSlot.W,
                FixedRange = true,
                CastType = CastType.Proximity,
                CastRange = 600f,
                Radius = 600f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ahriseduce",
                ChampionName = "ahri",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 975f,
                Radius = 60f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "ahriseducemissile",
                MissileSpeed = 1550
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ahritumble",
                ChampionName = "ahri",
                Slot = SpellSlot.R,
                CastType = CastType.LinearAoE,
                CastRange = 450f,
                Radius = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "akalimota",
                ChampionName = "akali",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                Radius = 171.9f,
                CastRange = 600f,
                Delay = 650f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "akalismokebomb",
                ChampionName = "akali",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 1000f, // Range: 700 + additional for stealth detection
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.Stealth },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "akalishadowswipe",
                ChampionName = "akali",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                Radius = 325f,
                CastRange = 325f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "akalishadowdance",
                ChampionName = "akali",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                Radius = 300f,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pulverize",
                ChampionName = "alistar",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 330f,
                Radius = 365f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "headbutt",
                ChampionName = "alistar",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 660f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "alistare",
                ChampionName = "alistar",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Radius = 300f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "feroucioushowl",
                ChampionName = "alistar",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bandagetoss",
                ChampionName = "amumu",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1100f,
                Radius = 80f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "sadmummybandagetoss",
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "auraofdespair",
                ChampionName = "amumu",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tantrum",
                ChampionName = "amumu",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 350f,
                Delay = 150f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "curseofthesadmummy",
                ChampionName = "amumu",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 560f,
                Radius = 560f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "flashfrost",
                ChampionName = "anivia",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinearAoE,
                CastRange = 1150f, // 1075 + Shatter Radius
                Radius = 110f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "flashfrostspell",
                MissileSpeed = 850
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "crystalize",
                ChampionName = "anivia",
                Slot = SpellSlot.W,
                CastType = CastType.Linear,
                IsPerpindicular = true,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "frostbite",
                ChampionName = "anivia",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 650f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "glacialstorm",
                ChampionName = "anivia",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 625f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "disintegrate",
                ChampionName = "annie",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 625f,
                Radius = 710f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "incinerate",
                ChampionName = "annie",
                Slot = SpellSlot.W,
                CastType = CastType.Sector,
                CastRange = 625f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "moltenshield",
                ChampionName = "annie",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "infernalguardian",
                ChampionName = "annie",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 900f, // 600 + Cast Radius
                Delay = 0f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileSpeed = 4800
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "aphelioscalibrumq",
                ChampionName = "aphelios",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1500f,
                Radius = 120f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1850
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "apheliosinfernumq",
                ChampionName = "aphelios",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 650f,
                Radius = 265f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1850
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "apheliosrv5",
                ChampionName = "aphelios",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1300f,
                Radius = 300f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Ultimate },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "frostshot",
                ChampionName = "ashe",
                Slot = SpellSlot.Q,
                BasicAttackAmplifier = true,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "frostarrow",
                ChampionName = "ashe",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "volley",
                ChampionName = "ashe",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1200f,
                Radius = 250f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "volleyattack",
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ashespiritofthehawk",
                ChampionName = "ashe",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "enchantedcrystalarrow",
                ChampionName = "ashe",
                Slot = SpellSlot.R,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 20000f,
                Global = true,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "enchantedcrystalarrow",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aurelionsolq",
                ChampionName = "aurelionsol",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 1500f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "aurelionsolqmissile",
                MissileSpeed = 850
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aurelionsolw",
                ChampionName = "aurelionsol",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.None },
                MissileName = "aurelionsolwmis",
                MissileSpeed = 450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aurelionsole",
                ChampionName = "aurelionsol",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.None },
                MissileName = "aurelionsole",
                MissileSpeed = 900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aurelionsolr",
                ChampionName = "aurelionsol",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CastRange = 1420f,
                Delay = 300f,
                EmulationTypes = new[]
                {
                    EmulationType.CrowdControl, EmulationType.Ultimate, EmulationType.Danger,
                    EmulationType.Initiator
                },
                MissileName = "aurelionsolrbeammissile",
                MissileSpeed = 4600
            });

            //HeroSpells.Add(new Spelldata
            //{
            //    SpellName = "azirq",
            //    ChampionName = "azir",
            //    Slot = SpellSlot.Q,
            //    CastType = CastType.LinearAoE,
            //    CastRange = 875f,
            //    Delay = 250f,
            //    EventTypes = new[] { EmulationType.CrowdControl },
            //    MissileName = "azirqmissile",
            //    FromObject = new[] { "AzirSoldier" },
            //    MissileSpeed = 1750
            //});

            HeroSpells.Add(new SpellData
            {
                SpellName = "azirqwrapper",
                ChampionName = "azir",
                Slot = SpellSlot.Q,
                CastType = CastType.LinearAoE,
                CastRange = 875f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "azirqmissile",
                FromObject = new[] { "AzirSoldier" },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "azire",
                ChampionName = "azir",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 1200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "azire",
                FromObject = new[] { "AzirSoldier" },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "azirr",
                ChampionName = "azir",
                Slot = SpellSlot.R,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 475f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl
                    },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bardq",
                ChampionName = "bard",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 950f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "bardqmissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bardw",
                ChampionName = "bard",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "barde",
                ChampionName = "bard",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 0f,
                Delay = 350f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bardr",
                ChampionName = "bard",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 3400f,
                Delay = 450f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Initiator },
                MissileName = "bardr",
                MissileSpeed = 2100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rocketgrab",
                ChampionName = "blitzcrank",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1050f,
                Radius = 70f,
                Delay = 250f,
                MissileName = "rocketgrabmissile",
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "overdrive",
                ChampionName = "blitzcrank",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Radius = 100f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "powerfist",
                ChampionName = "blitzcrank",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "staticfield",
                ChampionName = "blitzcrank",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                FixedRange = true,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "brandq",
                ChampionName = "brand",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1150f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "brandqmissile",
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "brandw",
                ChampionName = "brand",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 240f,
                Delay = 550f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "",
                MissileSpeed = 20
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "brande",
                ChampionName = "brand",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 625f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "brandr",
                ChampionName = "brand",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 750f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "braumq",
                ChampionName = "braum",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1100f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "braumqmissile",
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "braumqmissle",
                ChampionName = "braum",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1100f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "braumw",
                ChampionName = "braum",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "braume",
                ChampionName = "braum",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "braumrwrapper",
                ChampionName = "braum",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1250f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "braumrmissile",
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "camilleq",
                ChampionName = "camille",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 325f,
                Radius = 325f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "camillew",
                ChampionName = "camille",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 325f,
                Radius = 325f,
                Delay = 500f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2696
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "camillee",
                ChampionName = "camille",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinearAoE,
                CastRange = 1100f,
                Radius = 35f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileName = "camilleemissile",
                MissileSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "camilleedash2",
                ChampionName = "camille",
                Slot = SpellSlot.E,
                CastType = CastType.LinearAoE,
                CastRange = 800f,
                Radius = 165f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "camiller",
                ChampionName = "camille",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 475f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 11200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "caitlynpiltoverpeacemaker",
                ChampionName = "caitlyn",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                Radius = 60f,
                CastRange = 1300f,
                Delay = 450f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "caitlynpiltoverpeacemaker",
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "caitlynyordletrap",
                ChampionName = "caitlyn",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                Radius = 75f,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "caitlynentrapment",
                ChampionName = "caitlyn",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                Radius = 70f,
                CastRange = 1050f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "caitlynentrapmentmissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "caitlynaceinthehole",
                ChampionName = "caitlyn",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 2000f,
                Radius = 100f,
                Delay = 900f,
                FixedRange = false,
                MissileName = "",
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "cassiopeiaq",
                ChampionName = "cassiopeia",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 925f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "cassiopeianoxiousblast",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "cassiopeiw",
                ChampionName = "cassiopeia",
                Slot = SpellSlot.W,
                CastType = CastType.Linear,
                IsPerpindicular = true,
                CastRange = 925f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 2500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "cassiopeiae",
                ChampionName = "cassiopeia",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "cassiopeiar",
                ChampionName = "cassiopeia",
                Slot = SpellSlot.R,
                CastType = CastType.Sector,
                FixedRange = true,
                CastRange = 875f,
                Delay = 350f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "cassiopeiar",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "cassiopeiarstun",
                ChampionName = "cassiopeia",
                Slot = SpellSlot.R,
                CastType = CastType.Sector,
                FixedRange = true,
                CastRange = 875f,
                Delay = 350f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "cassiopeiarstun",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rupture",
                ChampionName = "chogath",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 950f,
                Radius = 250f,
                Delay = 900f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "feralscream",
                ChampionName = "chogath",
                Slot = SpellSlot.W,
                CastType = CastType.Sector,
                FixedRange = true,
                CastRange = 300f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vorpalspikes",
                ChampionName = "chogath",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 347
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "feast",
                ChampionName = "chogath",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 300f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "phosphorusbomb",
                ChampionName = "corki",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 875f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "phosphorusbombmissile",
                MissileSpeed = 1125
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "carpetbomb",
                ChampionName = "corki",
                Slot = SpellSlot.W,
                CastType = CastType.Linear,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileSpeed = 700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ggun",
                ChampionName = "corki",
                Slot = SpellSlot.E,
                CastType = CastType.Sector,
                CastRange = 750f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "missilebarrage",
                ChampionName = "corki",
                Slot = SpellSlot.R,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.MissileLinearAoE,
                FixedRange = true,
                CastRange = 1225f,
                Delay = 150f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "missilebarragemissile",
                ExtraMissileNames = new[] { "missilebarragemissile2" },
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dariuscleave",
                ChampionName = "darius",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                FixedRange = true,
                Radius = 425f,
                CastRange = 425f,
                Delay = 750f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dariusnoxiantacticsonh",
                ChampionName = "darius",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 205f,
                Delay = 150f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dariusaxegrabcone",
                ChampionName = "darius",
                Slot = SpellSlot.E,
                CastType = CastType.Sector,
                FixedRange = true,
                CastRange = 555f,
                Delay = 150f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger, EmulationType.Initiator },
                MissileName = "dariusaxegrabcone",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dariusexecute",
                ChampionName = "darius",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                Radius = 475f,
                CastRange = 475f,
                Delay = 450f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dianaarc",
                ChampionName = "diana",
                Slot = SpellSlot.Q,
                CastType = CastType.LinearAoE,
                CastRange = 830f,
                Radius = 195f,
                Delay = 300f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "dianaarc",
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dianaorbs",
                ChampionName = "diana",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 200f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dianavortex",
                ChampionName = "diana",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 450f,
                Radius = 450f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dianateleport",
                ChampionName = "diana",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 825f,
                Radius = 250f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dravenspinning",
                ChampionName = "draven",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dravenfury",
                ChampionName = "draven",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dravendoubleshot",
                ChampionName = "draven",
                Slot = SpellSlot.E,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1050f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "dravendoubleshotmissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dravenrcast",
                ChampionName = "draven",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CastRange = 20000f,
                Global = true,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileName = "dravenr",
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "infectedcleavermissilecast",
                ChampionName = "drmundo",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "infectedcleavermissile",
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "burningagony",
                ChampionName = "drmundo",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "masochism",
                ChampionName = "drmundo",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sadism",
                ChampionName = "drmundo",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ekkoq",
                ChampionName = "ekko",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1075f,
                Radius = 60f,
                Delay = 66f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "ekkoqmis",
                ExtraMissileNames = new[] { "ekkoqreturn" },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ekkoeattack",
                ChampionName = "ekko",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Gapcloser },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ekkor",
                ChampionName = "ekko",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 425f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                FromObject = new[] { "Ekko_Base_R_TrailEnd" },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisehumanq",
                ChampionName = "elise",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 625f,
                Delay = 550f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisespiderqcast",
                ChampionName = "elise",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 475f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Gapcloser },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisehumanw",
                ChampionName = "elise",
                Slot = SpellSlot.W,
                CastType = CastType.LinearAoE,
                CastRange = 0f,
                Delay = 750f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 5000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisespiderw",
                ChampionName = "elise",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisehumane",
                ChampionName = "elise",
                Slot = SpellSlot.E,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1075f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileName = "elisehumane",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisespidereinitial",
                ChampionName = "elise",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisespideredescent",
                ChampionName = "elise",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "eliser",
                ChampionName = "elise",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisespiderr",
                ChampionName = "elise",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynnq",
                ChampionName = "evelynn",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynnq2",
                ChampionName = "evelynn",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 680f,
                Delay = 33.33f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "evelynnqlinemissile",
                MissileSpeed = 2446
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynnw",
                ChampionName = "evelynn",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 1200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynne",
                ChampionName = "evelynn",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 225f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynne2",
                ChampionName = "evelynn",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 225f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynnr",
                ChampionName = "evelynn",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinearAoE,
                CastRange = 400f, // 650f + Radius
                Delay = 316f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "evelynnrtrail",
                MissileSpeed = 4400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ezrealmysticshot",
                ChampionName = "ezreal",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1150f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "ezrealmysticshotmissile",
                ExtraMissileNames = new[] { "ezrealmysticshotpulsemissile" },
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ezrealessenceflux",
                ChampionName = "ezreal",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1050f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "ezrealessencefluxmissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ezrealessencemissle",
                ChampionName = "ezreal",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1050f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ezrealarcaneshift",
                ChampionName = "ezreal",
                Slot = SpellSlot.E,
                CastType = CastType.LinearAoE,
                CastRange = 750f, // 475f + Bolt Range
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ezrealtrueshotbarrage",
                ChampionName = "ezreal",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 20000f,
                Global = true,
                Delay = 1000f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileName = "ezrealtrueshotbarrage",
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "terrify",
                ChampionName = "fiddlesticks",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 575f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "drain",
                ChampionName = "fiddlesticks",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 575f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fiddlesticksdarkwind",
                ChampionName = "fiddlesticks",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 750f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "crowstorm",
                ChampionName = "fiddlesticks",
                Slot = SpellSlot.R,
                CastType = CastType.LinearAoE,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.ForceExhaust, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fioraq",
                ChampionName = "fiora",
                Slot = SpellSlot.Q,
                CastType = CastType.LinearAoE,
                CastRange = 400f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fioraw",
                ChampionName = "fiora",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 750f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fiorae",
                ChampionName = "fiora",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fiorar",
                ChampionName = "fiora",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 500f,
                Delay = 150f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizzq",
                ChampionName = "fizz",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                FixedRange = true,
                CastRange = 550f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizzw",
                ChampionName = "fizz",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 175f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizze",
                ChampionName = "fizz",
                Slot = SpellSlot.E,
                CastType = CastType.LinearAoE,
                CastRange = 450f,
                Delay = 700f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizzebuffer",
                ChampionName = "fizz",
                Slot = SpellSlot.E,
                CastType = CastType.LinearAoE,
                CastRange = 330f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizzejumptwo",
                ChampionName = "fizz",
                Slot = SpellSlot.E,
                CastType = CastType.LinearAoE,
                CastRange = 270f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizzr",
                ChampionName = "fizz",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinearAoE,
                CastRange = 1275f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Initiator },
                MissileName = "fizzmarinerdoommissile",
                MissileSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galioq",
                ChampionName = "galio",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinearAoE,
                CastRange = 1200f,
                Radius = 60,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "galioqmissile",
                MissileSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galioqsuper",
                ChampionName = "galio",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 200f,
                Radius = 200,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galiow",
                ChampionName = "galio",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 275f,
                Radius = 275f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galiow2",
                ChampionName = "galio",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 275f,
                Radius = 275f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galioe",
                ChampionName = "galio",
                Slot = SpellSlot.E,
                CastType = CastType.LinearAoE,
                CastRange = 950f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileSpeed = 750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galior",
                ChampionName = "galio",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gangplankqwrapper",
                ChampionName = "gangplank",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 625f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gangplankqproceed",
                ChampionName = "gangplank",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 625f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gangplankw",
                ChampionName = "gangplank",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gangplanke",
                ChampionName = "gangplank",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gangplankr",
                ChampionName = "gangplank",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 20000f,
                Global = true,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "garenq",
                ChampionName = "garen",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 300f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "garenqattack",
                ChampionName = "garen",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 350f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarq",
                ChampionName = "gnar",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1185f,
                Delay = 500f,
                Radius = 55,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1700,
                MissileName = "gnarqmissile",
                ExtraMissileNames = new[] { "gnarqmissilereturn" }
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarqmissilereturn",
                ChampionName = "gnar",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1185f,
                Delay = 250f,
                Radius = 75,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 700,
                MissileName = "gnarqmissilereturn"
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarbigq",
                ChampionName = "gnar",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1150f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 2000,
                MissileName = "gnarbigqmissile"
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarw",
                ChampionName = "gnar",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarbigw",
                ChampionName = "gnar",
                Slot = SpellSlot.W,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 600f,
                Delay = 600f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnare",
                ChampionName = "gnar",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 475f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser, EmulationType.Initiator },
                MissileSpeed = 880
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarbige",
                ChampionName = "gnar",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 475f,
                Radius = 350,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser, EmulationType.Initiator },
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarult",
                ChampionName = "gnar",
                CastRange = 600f,
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                Delay = 250f,
                Radius = 500,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },

                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "garenw",
                ChampionName = "garen",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "garene",
                ChampionName = "garen",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 660f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "garenr",
                ChampionName = "garen",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 400f,
                Radius = 100f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileSpeed = 4800
            });

            // todo: improve gragas
            HeroSpells.Add(new SpellData
            {
                SpellName = "gragasq",
                ChampionName = "gragas",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 1000, // 850f + Radius
                Delay = 500f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "gragasqmissile",
                MissileSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gragasqtoggle",
                ChampionName = "gragas",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 1000, // 850f + Radius
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "gragasq"
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gragasqtoggle",
                ChampionName = "gragas",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 1100f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gragasw",
                ChampionName = "gragas",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gragase",
                ChampionName = "gragas",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl, EmulationType.Initiator, EmulationType.Gapcloser },
                MissileName = "gragase",
                MissileSpeed = 550
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gragasr",
                ChampionName = "gragas",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 1300f,
                Radius = 120f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl, EmulationType.Initiator },
                MissileName = "gragasrboom",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gravesq",
                ChampionName = "graves",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinearAoE,
                CastRange = 1025,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "gravesclustershotattack",
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gravesw",
                ChampionName = "graves",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 1100f, // 950 + Radius
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gravese",
                ChampionName = "graves",
                Slot = SpellSlot.E,
                CastType = CastType.LinearAoE,
                CastRange = 278f,
                Delay = 300f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gravesr",
                ChampionName = "graves",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinearAoE,
                CastRange = 1000f,
                FixedRange = true,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileName = "graveschargeshotshot",
                MissileSpeed = 2100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hecarimrapidslash",
                ChampionName = "hecarim",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 350f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hecarimw",
                ChampionName = "hecarim",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hecarimramp",
                ChampionName = "hecarim",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hecarimult",
                ChampionName = "hecarim",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1525f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl
                    },

                MissileName = "hecarimultmissile",
                ExtraMissileNames =
                    new[]
                    {
                        "hecarimultmissileskn4r1", "hecarimultmissileskn4r2", "hecarimultmissileskn4l1",
                        "hecarimultmissileskn4l2", "hecarimultmissileskn4rc"
                    },
                MissileSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingerturretenergyblast",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 1000f,
                Delay = 435f,
                EmulationTypes = new EmulationType[] { },
                FromObject = new[] { "heimerdinger_turret_idle" },
                MissileSpeed = 1650
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingerturretbigenergyblast",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 1000f,
                Delay = 350f,
                EmulationTypes = new EmulationType[] { },
                FromObject = new[] { "heimerdinger_base_r" },
                MissileSpeed = 1650
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingerw",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1100,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingere",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 1025f, // 925 + Radius
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "heimerdingerespell",
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingerr",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 230f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingereult",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                FixedRange = true,
                CastRange = 1450f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ireliagatotsu",
                ChampionName = "irelia",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 650f,
                Delay = 150f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ireliahitenstyle",
                ChampionName = "irelia",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 230f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ireliaequilibriumstrike",
                ChampionName = "irelia",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 450f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ireliatranscendentblades",
                ChampionName = "irelia",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                FixedRange = true,
                CastRange = 1200f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "ireliatranscendentbladesspell",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "illaoiq",
                ChampionName = "illaoi",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 950f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "illaoiemis",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "illaoiw",
                ChampionName = "illaoi",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 365f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "illaoie",
                ChampionName = "illaoi",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 950f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "illaoiemis",
                MissileSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "illaoir",
                ChampionName = "illaoi",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 450f,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.Ultimate, EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ivernq",
                ChampionName = "ivern",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                Radius = 65f,
                CastRange = 1100f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "ivernq",
                MissileSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ivernq",
                ChampionName = "ivern",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "ivernw",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "iverne",
                ChampionName = "ivern",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "iverne",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "howlinggale",
                ChampionName = "janna",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 1550f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "howlinggalespell",
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sowthewind",
                ChampionName = "janna",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "eyeofthestorm",
                ChampionName = "janna",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reapthewhirlwind",
                ChampionName = "janna",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 725f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jarvanivdragonstrike",
                ChampionName = "jarvaniv",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "",
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jarvanivgoldenaegis",
                ChampionName = "jarvaniv",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jarvanivdemacianstandard",
                ChampionName = "jarvaniv",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 830f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "jarvanivdemacianstandard",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jarvanivcataclysm",
                ChampionName = "jarvaniv",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 825f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate, EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaxleapstrike",
                ChampionName = "jax",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaxempowertwo",
                ChampionName = "jax",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaxrelentlessasssault",
                ChampionName = "jax",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Initiator },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycetotheskies",
                ChampionName = "jayce",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger, EmulationType.Gapcloser },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jayceshockblast",
                ChampionName = "jayce",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1570f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileName = "jayceshockblastmis",
                MissileSpeed = 2350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycestaticfield",
                ChampionName = "jayce",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 285f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycehypercharge",
                ChampionName = "jayce",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 750f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycethunderingblow",
                ChampionName = "jayce",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 325f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jayceaccelerationgate",
                ChampionName = "jayce",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                IsPerpindicular = true,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycestancehtg",
                ChampionName = "jayce",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 750f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycestancegth",
                ChampionName = "jayce",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 750f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jhinq",
                ChampionName = "jhin",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 575f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jhinw",
                ChampionName = "jhin",
                Slot = SpellSlot.W,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastType = CastType.Linear,
                CastRange = 2250f,
                Delay = 750f,
                FixedRange = true,
                EmulationTypes = new EmulationType[] { },
                MissileName = "jhinwmissile",
                MissileSpeed = 5000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jhine",
                ChampionName = "jhin",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 2250f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jhinrshot",
                ChampionName = "jhin",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 3500f,
                Delay = 250f,
                FixedRange = true,
                MissileName = "jhinrshotmis",
                EmulationTypes = new[] { EmulationType.Initiator },
                ExtraMissileNames = new[] { "jhinrmmissile", "jhinrshotmis4" },
                MissileSpeed = 5000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jinxq",
                ChampionName = "jinx",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jinxw",
                ChampionName = "jinx",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                Radius = 60f,
                FixedRange = true,
                CastRange = 1500f,
                Delay = 450f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "jinxwmissile",
                MissileSpeed = 3300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jinxe",
                ChampionName = "jinx",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 900f,
                Radius = 315f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jinxr",
                ChampionName = "jinx",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 25000f,
                Radius = 140f,
                Delay = 450f,
                MissileName = "jinxr",
                ExtraMissileNames = new[] { "jinxrwrapper" },
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileSpeed = 1700
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "kaisaw",
                ChampionName = "kaisa",
                Slot = SpellSlot.W,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 3000f,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "kaisawmis",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "karmaq",
                ChampionName = "karma",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.MissileLinearAoE,
                FixedRange = true,
                CastRange = 1050f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "karmaqmissile",
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "karmaspiritbind",
                ChampionName = "karma",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "karmasolkimshield",
                ChampionName = "karma",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "karmamantra",
                ChampionName = "karma",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "laywaste",
                ChampionName = "karthus",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 875f,
                Delay = 900f,
                EmulationTypes = new EmulationType[] { },
                ExtraMissileNames = new[]
                {
                    "karthuslaywastea3", "karthuslaywastea1", "karthuslaywastedeada1", "karthuslaywastedeada2",
                    "karthuslaywastedeada3"
                },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "wallofpain",
                ChampionName = "karthus",
                Slot = SpellSlot.W,
                CastType = CastType.Linear,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "defile",
                ChampionName = "karthus",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 550f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fallenone",
                ChampionName = "karthus",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 22000f,
                Global = true,
                Delay = 2800f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nulllance",
                ChampionName = "kassadin",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 650f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "netherblade",
                ChampionName = "kassadin",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "forcepulse",
                ChampionName = "kassadin",
                Slot = SpellSlot.E,
                CastType = CastType.Sector,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "riftwalk",
                ChampionName = "kassadin",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 675f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileName = "riftwalk",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "katarinaq",
                ChampionName = "katarina",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 675f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "katarinaw",
                ChampionName = "katarina",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                Radius = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "katarinae",
                ChampionName = "katarina",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 700f,
                Radius = 200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "katarinar",
                ChampionName = "katarina",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 550f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.ForceExhaust, EmulationType.Initiator },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "judicatorreckoning",
                ChampionName = "kayle",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 650f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "judicatordevineblessing",
                ChampionName = "kayle",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 900f,
                Delay = 220f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "judicatorrighteousfury",
                ChampionName = "kayle",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "judicatorintervention",
                ChampionName = "kayle",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 900f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            #region Kayn

            HeroSpells.Add(new SpellData
            { 
                SpellName = "kaynq",
                ChampionName = "kayn",
                Slot = SpellSlot.Q,
                CastType = CastType.LinearAoE,
                FixedRange = true,
                CastRange = 345f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser, EmulationType.Danger },
                MissileSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kaynw",
                ChampionName = "kayn",
                Slot = SpellSlot.W,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 700f,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kaynr",
                ChampionName = "kayn",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 550f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kaynrjumpout",
                ChampionName = "kayn",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 450f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            #endregion

            HeroSpells.Add(new SpellData
            {
                SpellName = "kennenshurikenhurlmissile1",
                ChampionName = "kennen",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1175f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "kennenshurikenhurlmissile1",
                MissileSpeed = 1700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kennenbringthelight",
                ChampionName = "kennen",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 900f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kennenlightningrush",
                ChampionName = "kennen",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kennenshurikenstorm",
                ChampionName = "kennen",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 550f,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixq",
                ChampionName = "khazix",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 325f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixqlong",
                ChampionName = "khazix",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 375f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixw",
                ChampionName = "khazix",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "khazixwmissile",
                MissileSpeed = 81700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixwlong",
                ChampionName = "khazix",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixe",
                ChampionName = "khazix",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 600f,
                Delay = 250f,
                Radius = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileName = "khazixe",
                MissileSpeed = 800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixelong",
                ChampionName = "khazix",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 900f,
                Radius = 250f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileSpeed = 900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixr",
                ChampionName = "khazix",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Stealth, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixrlong",
                ChampionName = "khazix",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Stealth },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kindredq",
                ChampionName = "kindred",
                Slot = SpellSlot.Q,
                CastType = CastType.LinearAoE,
                CastRange = 350f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kindrede",
                ChampionName = "kindred",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 510f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kledq",
                ChampionName = "kled",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 800f,
                Radius = 45f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "kledqmissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kledriderq",
                ChampionName = "kled",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 700f,
                Radius = 40f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "kledriderqmissile",
                MissileSpeed = 3000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kledw",
                ChampionName = "kled",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "klede",
                ChampionName = "kled",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 800f,
                Radius = 124f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator, EmulationType.Gapcloser },
                MissileName = "kledemissile",
                MissileSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kledr",
                ChampionName = "kled",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kogmawq",
                ChampionName = "kogmaw",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1300f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "kogmawqmissile",
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kogmawbioarcanebarrage",
                ChampionName = "kogmaw",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kogmawvoidooze",
                ChampionName = "kogmaw",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1150f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "kogmawvoidoozemissile",
                MissileSpeed = 1250
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kogmawlivingartillery",
                ChampionName = "kogmaw",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 2200f,
                Delay = 1200f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancq",
                ChampionName = "leblanc",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancw",
                ChampionName = "leblanc",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 650f,
                Radius = 175f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator, EmulationType.Gapcloser },
                MissileName = "leblancw",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblacwreturn",
                ChampionName = "leblanc",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblance",
                ChampionName = "leblanc",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 925f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "leblancemissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancrq",
                ChampionName = "leblanc",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancrw",
                ChampionName = "leblanc",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 650f,
                Radius = 175f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate, EmulationType.Initiator, EmulationType.Gapcloser },
                MissileName = "leblancrw",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancrwreturn",
                ChampionName = "leblanc",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancre",
                ChampionName = "leblanc",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 925f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "leblancremissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkqone",
                ChampionName = "leesin",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "blindmonkqone",
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkqtwo",
                ChampionName = "leesin",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 1100f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkwone",
                ChampionName = "leesin",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser, EmulationType.Initiator },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkwtwo",
                ChampionName = "leesin",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 700f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkeone",
                ChampionName = "leesin",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 425f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonketwo",
                ChampionName = "leesin",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 350f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkrkick",
                ChampionName = "leesin",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 375f,
                Delay = 500f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leonashieldofdaybreak",
                ChampionName = "leona",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 215f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leonasolarbarrier",
                ChampionName = "leona",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 250f,
                Delay = 3000f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leonazenithblade",
                ChampionName = "leona",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 900f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Gapcloser },
                MissileName = "leonazenithblademissile",
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leonasolarflare",
                ChampionName = "leona",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 1200f,
                Delay = 1200f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "leonasolarflare",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lissandraq",
                ChampionName = "lissandra",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 725f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "lissandraqmissile",
                MissileSpeed = 2250
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lissandraw",
                ChampionName = "lissandra",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 450f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lissandrae",
                ChampionName = "lissandra",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1050f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "lissandraemissile",
                MissileSpeed = 850
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lissandrar",
                ChampionName = "lissandra",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 550f,
                Delay = 250f,
                EmulationTypes = new[]
                {
                    EmulationType.CrowdControl, EmulationType.Initiator,
                    EmulationType.Danger, EmulationType.Ultimate
                },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lucianq",
                ChampionName = "lucian",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                FixedRange = true,
                CastRange = 1150f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "lucianq",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lucianw",
                ChampionName = "lucian",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinearAoE,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1050f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "lucianwmissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luciane",
                ChampionName = "lucian",
                Slot = SpellSlot.E,
                CastType = CastType.LinearAoE,
                CastRange = 650f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Gapcloser },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lucianr",
                ChampionName = "lucian",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1400f,
                Radius = 110,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "lucianrmissileoffhand",
                ExtraMissileNames = new[] { "lucianrmissile" },
                MissileSpeed = 2800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luluq",
                ChampionName = "lulu",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 925f,
                Radius = 60,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "luluqmissile",
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luluw",
                ChampionName = "lulu",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 650f,
                Delay = 640f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lulue",
                ChampionName = "lulu",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 650f,
                Delay = 640f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lulur",
                ChampionName = "lulu",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 900f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luxlightbinding",
                ChampionName = "lux",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1300f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "luxlightbindingmis",
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luxprismaticwave",
                ChampionName = "lux",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luxlightstrikekugel",
                ChampionName = "lux",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 1100f,
                Radius = 330f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "luxlightstrikekugel",
                MissileSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luxlightstriketoggle",
                ChampionName = "lux",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luxmalicecannon",
                ChampionName = "lux",
                Slot = SpellSlot.R,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 3500f,
                Radius = 299.3f,
                Delay = 1000f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileName = "luxmalicecannonmis",
                MissileSpeed = 3000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kalistamysticshot",
                ChampionName = "kalista",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastType = CastType.MissileLinear,
                CastRange = 1200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "kalistamysticshotmis",
                ExtraMissileNames = new[] { "kalistamysticshotmistrue" },
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kalistaw",
                ChampionName = "kalista",
                Slot = SpellSlot.W,
                CastType = CastType.Linear,
                CastRange = 5000f,
                Delay = 800f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kalistaexpungewrapper",
                ChampionName = "kalista",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "seismicshard",
                ChampionName = "malphite",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 625f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "obduracy",
                ChampionName = "malphite",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "landslide",
                ChampionName = "malphite",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 400f,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ufslash",
                ChampionName = "malphite",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "ufslash",
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "malzaharq",
                ChampionName = "malzahar",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                IsPerpindicular = true,
                CastRange = 900f,
                Delay = 600f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "alzaharcallofthevoid",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "malzaharw",
                ChampionName = "malzahar",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "malzahare",
                ChampionName = "malzahar",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 650f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "malzaharr",
                ChampionName = "malzahar",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "maokaiq",
                ChampionName = "maokai",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 650f,
                Radius = 110f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "maokaiqmissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "maokaiw",
                ChampionName = "maokai",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 525f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl, EmulationType.Initiator },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "maokaie",
                ChampionName = "maokai",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 1100f,
                Radius = 120f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "maokaiemissile",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "maokair",
                ChampionName = "maokai",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinearAoE,
                Radius = 120f,
                CastRange = 3000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileName = "maokairmis",
                MissileSpeed = 400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "alphastrike",
                ChampionName = "masteryi",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 600f,
                EmulationTypes = new[] { EmulationType.Gapcloser, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "meditate",
                ChampionName = "masteryi",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "wujustyle",
                ChampionName = "masteryi",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 230f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "highlander",
                ChampionName = "masteryi",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 370f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "missfortunericochetshot",
                ChampionName = "missfortune",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 650f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "missfortuneviciousstrikes",
                ChampionName = "missfortune",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "missfortunescattershot",
                ChampionName = "missfortune",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "missfortunebullettime",
                ChampionName = "missfortune",
                Slot = SpellSlot.R,
                CastType = CastType.Sector,
                FixedRange = true,
                CastRange = 1400f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "monkeykingdoubleattack",
                ChampionName = "monkeyking",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 20
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "monkeykingdecoy",
                ChampionName = "monkeyking",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Stealth },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "monkeykingdecoyswipe",
                ChampionName = "monkeyking",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                FromObject = new[] { "Base_W_Copy" },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "monkeykingnimbus",
                ChampionName = "monkeyking",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 625f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Gapcloser },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "monkeykingspintowin",
                ChampionName = "monkeyking",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 450f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "mordekaisermaceofspades",
                ChampionName = "mordekaiser",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "mordekaisercreepindeathcast",
                ChampionName = "mordekaiser",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 750f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "mordekaisersyphoneofdestruction",
                ChampionName = "mordekaiser",
                Slot = SpellSlot.E,
                CastType = CastType.Sector,
                FixedRange = true,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "mordekaiserchildrenofthegrave",
                ChampionName = "mordekaiser",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "morganaq",
                ChampionName = "morgana",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1175f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "darkbindingmissile",
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "morganaw",
                ChampionName = "morgana",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "morganae",
                ChampionName = "morgana",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "morganar",
                ChampionName = "morgana",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "namiq",
                ChampionName = "nami",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 875f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileName = "namiqmissile",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "namiw",
                ChampionName = "nami",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 725f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "namie",
                ChampionName = "nami",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "namir",
                ChampionName = "nami",
                Slot = SpellSlot.R,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 2550f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl, EmulationType.Initiator },
                MissileName = "namirmissile",
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nasusq",
                ChampionName = "nasus",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 450f,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.Danger },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nasusw",
                ChampionName = "nasus",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nasuse",
                ChampionName = "nasus",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nasusr",
                ChampionName = "nasus",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 200f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nautilusanchordrag",
                ChampionName = "nautilus",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 1080f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger, EmulationType.Initiator, EmulationType.Gapcloser },
                MissileName = "nautilusanchordragmissile",
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nautiluspiercinggaze",
                ChampionName = "nautilus",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nautilussplashzone",
                ChampionName = "nautilus",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nautilusgrandline",
                ChampionName = "nautilus",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 1250f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "javelintoss",
                ChampionName = "nidalee",
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                Slot = SpellSlot.Q,
                FixedRange = true,
                CastRange = 1500f,
                Radius = 299.3f,
                Delay = 125f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "javelintoss",
                MissileSpeed = 1300
            });

            #region Nidalee

            HeroSpells.Add(new SpellData
            {
                SpellName = "takedown",
                ChampionName = "nidalee",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 500f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bushwhack",
                ChampionName = "nidalee",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 900f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pounce",
                ChampionName = "nidalee",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 375f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "primalsurge",
                ChampionName = "nidalee",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "swipe",
                ChampionName = "nidalee",
                FixedRange = true,
                Slot = SpellSlot.E,
                CastType = CastType.Sector,
                CastRange = 350f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aspectofthecougar",
                ChampionName = "nidalee",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            #endregion

            #region Nocturne
            HeroSpells.Add(new SpellData
            {
                SpellName = "nocturneduskbringer",
                ChampionName = "nocturne",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1125f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nocturneshroudofdarkness",
                ChampionName = "nocturne",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nocturneunspeakablehorror",
                ChampionName = "nocturne",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 350f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nocturneparanoia",
                ChampionName = "nocturne",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 20000f,
                Global = true,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 500
            });
            #endregion

            #region Nunu
            HeroSpells.Add(new SpellData
            {
                SpellName = "consume",
                ChampionName = "nunu",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bloodboil",
                ChampionName = "nunu",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "iceblast",
                ChampionName = "nunu",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 550f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "absolutezero",
                ChampionName = "nunu",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 650f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            }); 
            #endregion

            HeroSpells.Add(new SpellData
            {
                SpellName = "olafaxethrowcast",
                ChampionName = "olaf",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "olafaxethrow",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "olaffrenziedstrikes",
                ChampionName = "olaf",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "olafrecklessstrike",
                ChampionName = "olaf",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 325f,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "olafragnarok",
                ChampionName = "olaf",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "orianaizunacommand",
                ChampionName = "orianna",
                Slot = SpellSlot.Q,
                CastType = CastType.LinearAoE,
                CastRange = 900f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "orianaizuna",
                FromObject = new[] { "yomu_ring" },
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "orianadissonancecommand",
                ChampionName = "orianna",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 400f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "orianadissonancecommand",
                FromObject = new[] { "yomu_ring" },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "orianaredactcommand",
                ChampionName = "orianna",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 1095f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "orianaredact",
                FromObject = new[] { "yomu_ring" },
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "orianadetonatecommand",
                ChampionName = "orianna",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 425f,
                Delay = 500f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "orianadetonatecommand",
                FromObject = new[] { "yomu_ring" },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pantheonq",
                ChampionName = "pantheon",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pantheonw",
                ChampionName = "pantheon",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pantheone",
                ChampionName = "pantheon",
                Slot = SpellSlot.E,
                CastType = CastType.Sector,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pantheonrjump",
                ChampionName = "pantheon",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 1000f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 3000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pantheonrfall",
                ChampionName = "pantheon",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 1000f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 3000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "poppyq",
                ChampionName = "poppy",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 450f,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "poppyw",
                ChampionName = "poppy",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "poppye",
                ChampionName = "poppy",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 525f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "poppyrspell",
                ChampionName = "poppy",
                FixedRange = true,
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CastRange = 1150f,
                Delay = 300f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "poppyrspellmissile",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "poppyrspellinstant",
                ChampionName = "poppy",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                FixedRange = true,
                CastRange = 450f,
                Delay = 300f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileSpeed = 4800
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "pykeq",
                ChampionName = "pyke",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 400f,
                Radius = 140f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 500
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "pykeqrange",
                ChampionName = "pyke",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CastRange = 1100f,
                Radius = 140f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 2000
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "pykee",
                ChampionName = "pyke",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 550f,
                Radius = 110f,
                Delay = 750f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 1650
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "pyker",
                ChampionName = "pyke",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                FixedRange = true,
                CastRange = 750f,
                Radius = - 282f,
                Delay = 750f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl, EmulationType.Ultimate },
                MissileSpeed = 1200
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "qiyanaq_rock",
                ChampionName = "qiyana",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 865f,
                Radius = 200f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "qiyanaq_water",
                ChampionName = "qiyana",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 865f,
                Radius = 200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1600
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "qiyanaq_grass",
                ChampionName = "qiyana",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 650f,
                Radius = 250f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "qiyanar",
                ChampionName = "qiyana",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 865f,
                Radius = 280f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Ultimate },
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "quinnq",
                ChampionName = "quinn",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinearAoE,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1050f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "quinnqmissile",
                ExtraMissileNames = new[] { "quinnq" },
                MissileSpeed = 1550
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "quinnw",
                ChampionName = "quinn",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "quinne",
                ChampionName = "quinn",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Initiator },
                MissileSpeed = 775
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "quinnr",
                ChampionName = "quinn",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "quinnrfinale",
                ChampionName = "quinn",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 700f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakanq",
                ChampionName = "rakan",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinearAoE,
                CastRange = 900f,
                Radius = 65f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "rakanqmis",
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakanw",
                ChampionName = "rakan",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 650f,
                Radius = 285f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1425
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakanwcast",
                ChampionName = "rakan",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 285f,
                Radius = 285f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakane",
                ChampionName = "rakan",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 210f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 3430
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakanecast",
                ChampionName = "rakan",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 210f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 3430
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakanr",
                ChampionName = "rakan",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 210f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "powerball",
                ChampionName = "rammus",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 775
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "defensiveballcurl",
                ChampionName = "rammus",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "puncturingtaunt",
                ChampionName = "rammus",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 325f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tremors2",
                ChampionName = "rammus",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "renektoncleave",
                ChampionName = "renekton",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 225f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "renektonpreexecute",
                ChampionName = "renekton",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                BasicAttackAmplifier = true,
                CastRange = 275f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "renektonsliceanddice",
                ChampionName = "renekton",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 450f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "renektonreignofthetyrant",
                ChampionName = "renekton",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rengarq2",
                ChampionName = "rengar",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                CastRange = 275f,
                Radius = 150f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rengarq2emp",
                ChampionName = "rengar",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                CastRange = 275f,
                Radius = 150f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rengarw",
                ChampionName = "rengar",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 500f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rengare",
                ChampionName = "rengar",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "rengaremis",
                ExtraMissileNames = new[] { "rengareempmis" },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rengarr",
                ChampionName = "rengar",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaiq",
                ChampionName = "reksai",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                FixedRange = true,
                CastRange = 275f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaiqburrowed",
                ChampionName = "reksai",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastRange = 1650f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "reksaiqburrowedmis",
                MissileSpeed = 1950
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaiw",
                ChampionName = "reksai",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 350f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaiwburrowed",
                ChampionName = "reksai",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaie",
                ChampionName = "reksai",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 250f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaieburrowed",
                ChampionName = "reksai",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 350f,
                Delay = 900f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksair",
                ChampionName = "reksai",
                Slot = SpellSlot.R,
                CastType = CastType.Linear,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 850,
                Delay = 1000f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.Ultimate },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "riventricleave",
                ChampionName = "riven",
                Slot = SpellSlot.Q,
                CastType = CastType.LinearAoE,
                FixedRange = true,
                CastRange = 270f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rivenmartyr",
                ChampionName = "riven",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 260f,
                Delay = 100f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rivenfeint",
                ChampionName = "riven",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rivenfengshuiengine",
                ChampionName = "riven",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rivenizunablade",
                ChampionName = "riven",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1075f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileName = "rivenlightsabermissile",
                ExtraMissileNames = new[] { "rivenlightsabermissileside" },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rumbleflamethrower",
                ChampionName = "rumble",
                Slot = SpellSlot.Q,
                CastType = CastType.Sector,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rumbleshield",
                ChampionName = "rumble",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rumbegrenade",
                ChampionName = "rumble",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rumblecarpetbomb",
                ChampionName = "rumble",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CastRange = 1700f,
                Delay = 400f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileName = "rumblecarpetbombmissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ryzeq",
                ChampionName = "ryze",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 925f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "ryzeqmissile",
                ExtraMissileNames = new[] { "ryzeq" },
                MissileSpeed = 1700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ryzew",
                ChampionName = "ryze",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ryzee",
                ChampionName = "ryze",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ryzer",
                ChampionName = "ryze",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sejuaniarcticassault",
                ChampionName = "sejuani",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 650f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Initiator },
                MissileName = "",
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sejuaninorthernwinds",
                ChampionName = "sejuani",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 1000f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sejuaniwintersclaw",
                ChampionName = "sejuani",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 550f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sejuaniglacialprisoncast",
                ChampionName = "sejuani",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 1200f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "sejuaniglacialprison",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "deceive",
                ChampionName = "shaco",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Stealth },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jackinthebox",
                ChampionName = "shaco",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twoshivpoison",
                ChampionName = "shaco",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 625f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hallucinatefull",
                ChampionName = "shaco",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 1125f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 395
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shenq",
                ChampionName = "shen",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 1650f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                FromObject = new[] { "ShenArrowVfxHostMinion" },
                MissileSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shenw",
                ChampionName = "shen",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shene",
                ChampionName = "shen",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 675f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Initiator },
                MissileName = "shene",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shenr",
                ChampionName = "shen",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanadoubleattack",
                ChampionName = "shyvana",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                BasicAttackAmplifier = true,
                CastRange = 275f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanadoubleattackdragon",
                ChampionName = "shyvana",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 325f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanaimmolationauraqw",
                ChampionName = "shyvana",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 275f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanaimmolateddragon",
                ChampionName = "shyvana",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 250f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanafireball",
                ChampionName = "shyvana",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 925f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "shyvanafireballmissile",
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanafireballdragon2",
                ChampionName = "shyvana",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CastRange = 925f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanatransformcast",
                ChampionName = "shyvana",
                Slot = SpellSlot.R,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 1000f,
                Delay = 100f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.CrowdControl,
                        EmulationType.Ultimate, EmulationType.Initiator
                    },
                MissileName = "shyvanatransformcast",
                MissileSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "poisentrail",
                ChampionName = "singed",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 250f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "megaadhesive",
                ChampionName = "singed",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 1175f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fling",
                ChampionName = "singed",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 125f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "insanitypotion",
                ChampionName = "singed",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sionq",
                ChampionName = "sion",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sionwdetonate",
                ChampionName = "sion",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 350f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sione",
                ChampionName = "sion",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 725f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "sionemissile",
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sionr",
                ChampionName = "sion",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileName = "",
                MissileSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sivirq",
                ChampionName = "sivir",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1165f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "sivirqmissile",
                ExtraMissileNames = new[] { "sivirqmissilereturn" },
                MissileSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sivirw",
                ChampionName = "sivir",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sivire",
                ChampionName = "sivir",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sivirr",
                ChampionName = "sivir",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "skarnervirulentslash",
                ChampionName = "skarner",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 350f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "skarnerexoskeleton",
                ChampionName = "skarner",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "skarnerfracture",
                ChampionName = "skarner",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1100f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "skarnerfracturemissile",
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "skarnerimpale",
                ChampionName = "skarner",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 350f,
                Delay = 350f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sonaq",
                ChampionName = "sona",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sonaw",
                ChampionName = "sona",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sonae",
                ChampionName = "sona",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sonar",
                ChampionName = "sona",
                Slot = SpellSlot.R,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "sonar",
                MissileSpeed = 2400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sorakaq",
                ChampionName = "soraka",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 970f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "",
                MissileSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sorakaw",
                ChampionName = "soraka",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sorakae",
                ChampionName = "soraka",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 925f,
                Delay = 1750f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sorakar",
                ChampionName = "soraka",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "swainq",
                ChampionName = "swain",
                Slot = SpellSlot.Q,
                CastType = CastType.Sector,
                CastRange = 725f,
                Radius = 285f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "swainw",
                ChampionName = "swain",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 5500f,
                Radius = 325f,
                Delay = 500f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "swaine",
                ChampionName = "swain",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { EmulationType.CrowdControl },
                MissileSpeed = 1950
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "swainrsoulflare",
                ChampionName = "swain",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 650f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { EmulationType.Ultimate },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "syndraq",
                ChampionName = "syndra",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "syndraq",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "syndrawcast",
                ChampionName = "syndra",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 950f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "syndrawcast",
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "syndrae",
                ChampionName = "syndra",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 750 + 1000,
                Radius = 250f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "syndrae",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "syndrar",
                ChampionName = "syndra",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 675f,
                Delay = 450f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileSpeed = 1250
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tahmkenchq",
                ChampionName = "tahmkench",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 950f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 2800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taliyahq",
                ChampionName = "taliyah",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastRange = 1000f,
                Radius = 80f,
                Delay = 250f,
                FixedRange = true,
                MissileName = "taliyahqmis",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taliyahwvc",
                ChampionName = "taliyah",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 900f,
                Radius = 150f,
                Delay = 900f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taliyahe",
                ChampionName = "taliyah",
                Slot = SpellSlot.E,
                CastType = CastType.Sector,
                CastRange = 500f,
                Radius = 165f,
                Delay = 250f,
                FixedRange = true,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1650
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "talonq",
                ChampionName = "talon",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 275f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "talonw",
                ChampionName = "talon",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 900f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "talonwmissileone",
                ExtraMissileNames = new[] { "talonwmissiletwo" },
                MissileSpeed = 2300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "talone",
                ChampionName = "talon",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "talonr",
                ChampionName = "talon",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CastRange = 750f,
                Delay = 260f,
                MissileName = "talonrmisone",
                EmulationTypes = new[] { EmulationType.Stealth, EmulationType.Initiator },
                ExtraMissileNames = new[] { "talonrmistwo" },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taricq",
                ChampionName = "taric",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taricw",
                ChampionName = "taric",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tarice",
                ChampionName = "taric",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 625f,
                Delay = 1000f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taricr",
                ChampionName = "taric",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindingdart",
                ChampionName = "teemo",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 580f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "movequick",
                ChampionName = "teemo",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 943
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "toxicshot",
                ChampionName = "teemo",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bantamtrap",
                ChampionName = "teemo",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "threshq",
                ChampionName = "thresh",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1175f,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileName = "threshqmissile",
                MissileSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "threshw",
                ChampionName = "thresh",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "threshe",
                ChampionName = "thresh",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 400f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "threshemissile1",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "threshrpenta",
                ChampionName = "thresh",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 420f,
                Delay = 300f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 1550
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tristanaq",
                ChampionName = "tristana",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tristanaw",
                ChampionName = "tristana",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                Radius = 270f,
                CastRange = 900f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tristanae",
                ChampionName = "tristana",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                Radius = 210f,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 2400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tristanar",
                ChampionName = "tristana",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                Radius = 200f,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "trundleq",
                ChampionName = "trundle",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 800f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "trundletrollsmash",
                ChampionName = "trundle",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                Radius = 210f,
                CastRange = 300f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "trundledesecrate",
                ChampionName = "trundle",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "trundlecircle",
                ChampionName = "trundle",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 1000f,
                Radius = 340f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "trundlepain",
                ChampionName = "trundle",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 650f,
                Radius = 300f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bloodlust",
                ChampionName = "tryndamere",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "mockingshout",
                ChampionName = "tryndamere",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 400f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "slashcast",
                ChampionName = "tryndamere",
                Slot = SpellSlot.E,
                CastType = CastType.Linear,
                CastRange = 660f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "slashcast",
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "undyingrage",
                ChampionName = "tryndamere",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchhideinshadows",
                ChampionName = "twitch",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                Delay = 450f,
                EmulationTypes = new[] { EmulationType.Stealth },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchvenomcask",
                ChampionName = "twitch",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "twitchvenomcaskmissile",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchvenomcaskmissle",
                ChampionName = "twitch",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchexpungewrapper",
                ChampionName = "twitch",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchexpunge",
                ChampionName = "twitch",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchfullautomatic",
                ChampionName = "twitch",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "wildcards",
                ChampionName = "twistedfate",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CastRange = 1450f,
                FixedRange = true,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "sealfatemissile",
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pickacard",
                ChampionName = "twistedfate",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "goldcardpreattack",
                ChampionName = "twistedfate",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "redcardpreattack",
                ChampionName = "twistedfate",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bluecardpreattack",
                ChampionName = "twistedfate",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "cardmasterstack",
                ChampionName = "twistedfate",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "destiny",
                ChampionName = "twistedfate",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "udyrtigerstance",
                ChampionName = "udyr",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "udyrturtlestance",
                ChampionName = "udyr",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "udyrbearstanceattack",
                ChampionName = "udyr",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 250f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "udyrphoenixstance",
                ChampionName = "udyr",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotheatseekinglineqqmissile",
                ChampionName = "urgot",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotheatseekingmissile",
                ChampionName = "urgot",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotterrorcapacitoractive2",
                ChampionName = "urgot",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotplasmagrenade",
                ChampionName = "urgot",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 950f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "urgotplasmagrenadeboom",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotplasmagrenadeboom",
                ChampionName = "urgot",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 950f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotswap2",
                ChampionName = "urgot",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "varusq",
                ChampionName = "varus",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1250f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "varusqmissile",
                MissileSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "varusw",
                ChampionName = "varus",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "varuse",
                ChampionName = "varus",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 925f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "varuse",
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "varusr",
                ChampionName = "varus",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinearAoE,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1300f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileName = "varusrmissile",
                MissileSpeed = 1950
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vaynetumble",
                ChampionName = "vayne",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vaynesilverbolts",
                ChampionName = "vayne",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vaynecondemnmissile",
                ChampionName = "vayne",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 550f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vayneinquisition",
                ChampionName = "vayne",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Stealth, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "veigarbalefulstrike",
                ChampionName = "veigar",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 950f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "veigarbalefulstrikemis",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "veigardarkmatter",
                ChampionName = "veigar",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 900f,
                Delay = 1200f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "veigareventhorizon",
                ChampionName = "veigar",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 650f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "",
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "veigarprimordialburst",
                ChampionName = "veigar",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "velkozq",
                ChampionName = "velkoz",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1250f,
                Delay = 100f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "velkozqmissile",
                MissileSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "velkozqsplitactivate",
                ChampionName = "velkoz",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                IsPerpindicular = true,
                CastRange = 1050f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileName = "velkozqmissilesplit",
                MissileSpeed = 2100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "velkozw",
                ChampionName = "velkoz",
                Slot = SpellSlot.W,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1050f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "velkozwmissile",
                MissileSpeed = 1700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "velkoze",
                ChampionName = "velkoz",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 950f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "velkozemissile",
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "velkozr",
                ChampionName = "velkoz",
                Slot = SpellSlot.R,
                CastType = CastType.Linear,
                CastRange = 1575f,
                Delay = 0f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viqmissile",
                ChampionName = "vi",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl, EmulationType.Initiator },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viw",
                ChampionName = "vi",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vie",
                ChampionName = "vi",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vir",
                ChampionName = "vi",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl, EmulationType.Initiator },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viktorpowertransfer",
                ChampionName = "viktor",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1050
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viktorgravitonfield",
                ChampionName = "viktor",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 815f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viktordeathray",
                ChampionName = "viktor",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileName = "viktordeathraymis",
                ExtraMissileNames = new[] { "viktoreaugmissile" },
                MissileSpeed = 1210
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viktorchaosstorm",
                ChampionName = "viktor",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 710f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.CrowdControl, EmulationType.Ultimate,
                        EmulationType.Danger, EmulationType.Initiator
                    },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vladimirq",
                ChampionName = "vladimir",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vladimirw",
                ChampionName = "vladimir",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vladimire",
                ChampionName = "vladimir",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 610f,
                Delay = 800f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vladimirr",
                ChampionName = "vladimir",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 875f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "volibearq",
                ChampionName = "volibear",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Initiator, EmulationType.CrowdControl },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "volibearw",
                ChampionName = "volibear",
                Slot = SpellSlot.W,
                CastType = CastType.Targeted,
                CastRange = 400f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "volibeare",
                ChampionName = "volibear",
                CastType = CastType.Proximity,
                Slot = SpellSlot.E,
                CastRange = 425f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 825
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "volibearr",
                ChampionName = "volibear",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 825
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hungeringstrike",
                ChampionName = "warwick",
                Slot = SpellSlot.Q,
                CastType = CastType.Targeted,
                CastRange = 400f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hunterscall",
                ChampionName = "warwick",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bloodscent",
                ChampionName = "warwick",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 0f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "infiniteduress",
                ChampionName = "warwick",
                Slot = SpellSlot.R,
                CastType = CastType.Linear,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "infiniteduresschannel",
                ChampionName = "warwick",
                Slot = SpellSlot.R,
                CastType = CastType.Linear,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xayahq",
                ChampionName = "xayah",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1100f,
                Delay = 500f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "xayahqmissile1",
                MissileSpeed = 2060
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xayahw",
                ChampionName = "xayah",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xayahe",
                ChampionName = "xayah",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CastRange = 2000f,
                Radius = 80,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "xayahemissilesfx",
                MissileSpeed = 4800,
                NoProcess = true
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xayahr",
                ChampionName = "xayah",
                Slot = SpellSlot.R,
                CastType = CastType.MissileLinear,
                CastRange = 1100f,
                Radius = 25,
                Delay = 500f,
                EmulationTypes = new[] { EmulationType.Initiator },
                MissileName = "xayahrmissile",
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xeratharcanopulsechargeup",
                ChampionName = "xerath",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 750f,
                Delay = 750f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xeratharcanebarrage2",
                ChampionName = "xerath",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 1100f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "xeratharcanebarrage2",
                MissileSpeed = 20
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xerathmagespear",
                ChampionName = "xerath",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1050f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger },
                MissileName = "xerathmagespearmissile",
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xerathlocusofpower2",
                ChampionName = "xerath",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 5600f,
                Delay = 750f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaocombotarget",
                ChampionName = "xinzhao",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 375,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaothrust",
                ChampionName = "xinzhao",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 625f,
                Radius = 225f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaothrust2",
                ChampionName = "xinzhao",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 625f,
                Radius = 225f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaothrust3",
                ChampionName = "xinzhao",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 625f,
                Radius = 225f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaobattlecry",
                ChampionName = "xinzhao",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaosweep",
                ChampionName = "xinzhao",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 600f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl, EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 2400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaoparry",
                ChampionName = "xinzhao",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 500f,
                Radius = 210f,
                Delay = 250f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl
                    },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuoqw",
                ChampionName = "yasuo",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 475f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuoq2w",
                ChampionName = "yasuo",
                Slot = SpellSlot.Q,
                CastType = CastType.Linear,
                FixedRange = true,
                CastRange = 475f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuoq3",
                ChampionName = "yasuo",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1000f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "yasuoq3mis",
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuowmovingwall",
                ChampionName = "yasuo",
                CastType = CastType.Linear,
                Slot = SpellSlot.W,
                IsPerpindicular = true,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuodashwrapper",
                ChampionName = "yasuo",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 475f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 20
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuorknockupcombow",
                ChampionName = "yasuo",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yorickq",
                ChampionName = "yorick",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                BasicAttackAmplifier = true,
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yorickw",
                ChampionName = "yorick",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yoricke",
                ChampionName = "yorick",
                Slot = SpellSlot.E,
                CastType = CastType.LinearAoE,
                CastRange = 700f,
                Radius = 125f,
                Delay = 250f,
                MissileName = "yorickemissile",
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yorickr",
                ChampionName = "yorick",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zacq",
                ChampionName = "zac",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 800f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "zaqmissile",
                MissileSpeed = 2600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zacw",
                ChampionName = "zac",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 350f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zace",
                ChampionName = "zac",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl },
                MissileSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zacr",
                ChampionName = "zac",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 600f,
                Radius = 300f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.CrowdControl, EmulationType.Ultimate },
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zedq",
                ChampionName = "zed",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 900f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "zedqmissile",
                FromObject = new[] { "Zed_Base_W_tar.troy", "Zed_Base_W_cloneswap_buf.troy" },
                ExtraMissileNames = new[] { "zedqmissiletwo", "zedqmissilethree" },
                MissileSpeed = 1700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zedw",
                ChampionName = "zed",
                Slot = SpellSlot.W,
                CastType = CastType.LinearAoE,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zede",
                ChampionName = "zed",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zedr",
                ChampionName = "zed",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 850f,
                Delay = 450f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Initiator },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggsq",
                ChampionName = "ziggs",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 850f,
                Radius = 100f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "ziggsqspell",
                ExtraMissileNames = new[] { "ziggsqspell2", "ziggsqspell3" },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggsw",
                ChampionName = "ziggs",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "ziggsw",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggswtoggle",
                ChampionName = "ziggs",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggse",
                ChampionName = "ziggs",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "ziggse",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggse2",
                ChampionName = "ziggs",
                Slot = SpellSlot.E,
                CastType = CastType.Circlular,
                CastRange = 850f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggsr",
                ChampionName = "ziggs",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 2250f,
                Delay = 1800f,
                EmulationTypes = new[] { EmulationType.Danger, EmulationType.Ultimate },
                MissileName = "ziggsr",
                MissileSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zileanq",
                ChampionName = "zilean",
                Slot = SpellSlot.Q,
                CastType = CastType.Circlular,
                CastRange = 900f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "zileanqmissile",
                MissileSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zileanw",
                ChampionName = "zilean",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zileane",
                ChampionName = "zilean",
                Slot = SpellSlot.E,
                CastType = CastType.Targeted,
                CastRange = 700f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zileanr",
                ChampionName = "zilean",
                Slot = SpellSlot.R,
                CastType = CastType.Targeted,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zoeq",
                ChampionName = "zoe",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CastRange = 825f,
                Delay = 250f,
                Radius = 50,
                MissileName = "zoeqmissile",
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 1200
            });


            HeroSpells.Add(new SpellData
            {
                SpellName = "zoeqrecast",
                ChampionName = "zoe",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CastRange = 2000f,
                Delay = 250f,
                FixedRange = false,
                Radius = 60,
                MissileName = "zoeqmis2warning",
                EmulationTypes = new EmulationType[] { EmulationType.Danger, },
                MissileSpeed = 2400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zoee",
                ChampionName = "zoe",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinearAoE,
                CastRange = 830f,
                Delay = 250f,
                FixedRange = true,
                Radius = 60,
                MissileName = "zoee",
                ExtraMissileNames = new [] {"zoeemisaudio"},
                EmulationTypes = new EmulationType[] { EmulationType.Danger, EmulationType.CrowdControl,  },
                MissileSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zyraq",
                ChampionName = "zyra",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                CastRange = 800f,
                Radius = 430f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "zyraqmissile",
                MissileSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zyraqplantmissile",
                ChampionName = "zyra",
                Slot = SpellSlot.Q,
                CastType = CastType.MissileLinear,
                IsPerpindicular = true,
                CastRange = 675f,
                Radius = 710f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileName = "zyraqplantmissile",
                MissileSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zyraw",
                ChampionName = "zyra",
                Slot = SpellSlot.W,
                CastType = CastType.Circlular,
                CastRange = 0f,
                Delay = 250f,
                EmulationTypes = new EmulationType[] { },
                MissileSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zyrae",
                ChampionName = "zyra",
                Slot = SpellSlot.E,
                CastType = CastType.MissileLinear,
                FixedRange = true,
                CastRange = 1150f,
                Radius = 70f,
                Delay = 250f,
                EmulationTypes = new[] { EmulationType.CrowdControl },
                MissileName = "zyraemissile",
                MissileSpeed = 1150
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zyrar",
                ChampionName = "zyra",
                Slot = SpellSlot.R,
                CastType = CastType.Circlular,
                CastRange = 700f,
                Radius = 500f,
                Delay = 500f,
                EmulationTypes =
                    new[]
                    {
                        EmulationType.Danger, EmulationType.Ultimate,
                        EmulationType.CrowdControl, EmulationType.Initiator
                    },
                MissileSpeed = 4800
            });
        }

        #endregion
    }
}