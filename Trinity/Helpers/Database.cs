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
        ///     Gets or sets the display name of the spell.
        /// </summary>
        /// <value>
        ///     The display name of the spell.
        /// </value>
        public string DisplayName { get; internal set; }

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
        public SpellSlot Slot { get; internal set; }

        /// <summary>
        ///     Gets or sets the cast range.
        /// </summary>
        /// <value>
        ///     The cast range.
        /// </value>
        public float CastRange { get; internal set; }
        
        /// <summary>
        ///     Gets or sets the secondary cast range.
        /// </summary>
        /// <value>
        ///     The secondary cast range.
        /// </value>
        public float SecondaryCastRange { get; internal set; }

        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        /// <value>
        ///     The radius.
        /// </value>
        public float Radius { get; internal set; }
        
        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        /// <value>
        ///     The radius.
        /// </value>
        public float SecondaryRadius { get; internal set; }

        /// <summary>
        ///     Gets or sets a value indicating whether spell is global.
        /// </summary>
        /// <value>
        ///     <c>true</c> if spell is global; otherwise, <c>false</c>.
        /// </value>
        public bool Global { get; internal set; }

        /// <summary>
        ///     Gets or sets the cast delay.
        /// </summary>
        /// <value>
        ///     The cast delay.
        /// </value>
        public float CastDelay { get; internal set; } = 250f;
        
        
        /// <summary>
        ///     Gets or sets the secondary cast delay.
        /// </summary>
        /// <value>
        ///     The secondary cast delay.
        /// </value>
        public float SecondaryCastDelay { get; internal  set; }

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
        ///     Gets or sets the cast speed.
        /// </summary>
        /// <value>
        ///     The missile speed.
        /// </value>
        public int CastSpeed { get; internal set; } = 4800;
        
        /// <summary>
        ///     Gets or sets the extra cast speed.
        /// </summary>
        /// <value>
        ///     The cast speeds.
        /// </value>
        public int[] ExtraCastSpeeds { get; set; }
    
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
        public EmulationFlags[] EmuFlags { get; internal set; } = { };

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
        public bool NoProcess { get; internal set; }

        #endregion

        #region Static Fields and Constants

        /// <summary>
        ///     The dangerous spells list
        /// </summary>
        public static List<SpellData> HeroSpells = new ();

        #endregion
        static SpellData()
        {
            #region Aatrox
            HeroSpells.Add(new SpellData
            {
                SpellName = "aatroxqwrappercast",
                ChampionName = "aatrox",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 875f,
                Radius = 200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aatroxw",
                ChampionName = "aatrox",
                Slot = SpellSlot.W,
                DisplayName = "Infernal Chains",
                CastRange = 0f,
                Radius = 160f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1800,
            });

            HeroSpells.Add(new SpellData
            {
                ChampionName = "aatrox",
                Slot = SpellSlot.W,
                DisplayName = "Infernal Chains",
                CastRange = 0f,
                Radius = 160f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aatroxe",
                ChampionName = "aatrox",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1025f,
                Radius = 150f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "aatroxeconemissile",
                CastSpeed = 1250
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "aatroxr",
                ChampionName = "aatrox",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });
            
            #endregion

            #region Ahri
            HeroSpells.Add(new SpellData
            {
                SpellName = "ahriorbofdeception",
                ChampionName = "ahri",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 900f,
                Radius = 80f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "ahriorbmissile",
                ExtraMissileNames = new[] { "ahriorbreturn" },
                CastSpeed = 1450
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
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ahriseduce",
                ChampionName = "ahri",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 975f,
                Radius = 60f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "ahriseducemissile",
                CastSpeed = 1550
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ahritumble",
                ChampionName = "ahri",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 450f,
                Radius = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 2200
            });
            
            #endregion

            #region Akali

            HeroSpells.Add(new SpellData
            {
                SpellName = "akalimota",
                ChampionName = "akali",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                Radius = 171.9f,
                CastRange = 600f,
                CastDelay = 650f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "akalismokebomb",
                ChampionName = "akali",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 1000f, // Range: 700 + additional for stealth detection
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.Stealth },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "akalishadowswipe",
                ChampionName = "akali",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                Radius = 325f,
                CastRange = 325f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "akalishadowdance",
                ChampionName = "akali",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                Radius = 300f,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 2200
            });

            #endregion
            
            #region Akshan
 
            HeroSpells.Add(new SpellData
            {
                SpellName = "akshanq",
                ChampionName = "akshan",
                Slot = SpellSlot.Q,
                DisplayName = "Avengerang",
                CastRange = 850f,
                Radius = 120f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                ExtraCastSpeeds = new[] { 1500, 2400 },
                CastSpeed = 1500,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "akshanw",
                ChampionName = "akshan",
                Slot = SpellSlot.W,
                DisplayName = "Going Rogue",
                CastRange = 0f,
                Radius = 0f,
                CastDelay = 500f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "akshane",
                ChampionName = "akshan",
                Slot = SpellSlot.E,
                DisplayName = "Heroic Swing",
                CastRange = 0f,
                Radius = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                ExtraCastSpeeds = new[] { 2500, 1200, 3000 },
                CastSpeed = 2500,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "akshanr",
                ChampionName = "akshan",
                Slot = SpellSlot.R,
                DisplayName = "Comeuppance",
                CastRange = 2500f,
                Radius = 120f,
                CastDelay = 250f,
                CastType = CastType.Unit,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 3200,
            });
            
            #endregion

            #region Alistar

            HeroSpells.Add(new SpellData
            {
                SpellName = "pulverize",
                ChampionName = "alistar",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 330f,
                Radius = 365f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "headbutt",
                ChampionName = "alistar",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 660f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "alistare",
                ChampionName = "alistar",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Radius = 300f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "feroucioushowl",
                ChampionName = "alistar",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            #endregion

            #region Amumu

            HeroSpells.Add(new SpellData
            {
                SpellName = "bandagetoss",
                ChampionName = "amumu",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1100f,
                Radius = 80f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "sadmummybandagetoss",
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "auraofdespair",
                ChampionName = "amumu",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 300f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tantrum",
                ChampionName = "amumu",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 350f,
                CastDelay = 150f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "curseofthesadmummy",
                ChampionName = "amumu",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 560f,
                Radius = 560f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "",
                CastSpeed = 4800
            });

            #endregion

            #region Anivia

            HeroSpells.Add(new SpellData
            {
                SpellName = "flashfrost",
                ChampionName = "anivia",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 1150f, // 1075 + Shatter Radius
                Radius = 110f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "flashfrostspell",
                CastSpeed = 850
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "crystalize",
                ChampionName = "anivia",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                IsPerpindicular = true,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "frostbite",
                ChampionName = "anivia",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 650f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "glacialstorm",
                ChampionName = "anivia",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 625f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            #endregion

            #region Annie

            HeroSpells.Add(new SpellData
            {
                SpellName = "disintegrate",
                ChampionName = "annie",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 625f,
                Radius = 710f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "incinerate",
                ChampionName = "annie",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                CastRange = 625f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "moltenshield",
                ChampionName = "annie",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "infernalguardian",
                ChampionName = "annie",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 900f, // 600 + Cast Radius
                CastDelay = 0f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                CastSpeed = 4800
            });

            #endregion
            
            #region Aphelios
            HeroSpells.Add(new SpellData
            {
                SpellName = "aphelioscalibrumq",
                ChampionName = "aphelios",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1500f,
                Radius = 120f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1850
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "apheliosinfernumq",
                ChampionName = "aphelios",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 650f,
                Radius = 265f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1850
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "apheliosrv5",
                ChampionName = "aphelios",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1300f,
                Radius = 300f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Ultimate },
                CastSpeed = 1450
            });
            
            #endregion

            #region Ashe
            HeroSpells.Add(new SpellData
            {
                SpellName = "frostshot",
                ChampionName = "ashe",
                Slot = SpellSlot.Q,
                BasicAttackAmplifier = true,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "frostarrow",
                ChampionName = "ashe",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "volley",
                ChampionName = "ashe",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1200f,
                Radius = 250f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "volleyattack",
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ashespiritofthehawk",
                ChampionName = "ashe",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "enchantedcrystalarrow",
                ChampionName = "ashe",
                Slot = SpellSlot.R,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 20000f,
                Global = true,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "enchantedcrystalarrow",
                CastSpeed = 1600
            });
            
            #endregion

            #region AurelionSol
            HeroSpells.Add(new SpellData
            {
                SpellName = "aurelionsolq",
                ChampionName = "aurelionsol",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 1500f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "aurelionsolqmissile",
                CastSpeed = 850
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aurelionsolw",
                ChampionName = "aurelionsol",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.None },
                MissileName = "aurelionsolwmis",
                CastSpeed = 450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aurelionsole",
                ChampionName = "aurelionsol",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.None },
                MissileName = "aurelionsole",
                CastSpeed = 900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aurelionsolr",
                ChampionName = "aurelionsol",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CastRange = 1420f,
                CastDelay = 300f,
                EmuFlags = new[]
                {
                    EmulationFlags.CrowdControl, EmulationFlags.Ultimate, EmulationFlags.Danger,
                    EmulationFlags.Initiator
                },
                MissileName = "aurelionsolrbeammissile",
                CastSpeed = 4600
            });
            
            #endregion

            #region Azir
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "azirq",
                ChampionName = "azir",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 875f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "azirqmissile",
                FromObject = new[] { "AzirSoldier" },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "azirqwrapper",
                ChampionName = "azir",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 875f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "azirqmissile",
                FromObject = new[] { "AzirSoldier" },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "azire",
                ChampionName = "azir",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 1200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "azire",
                FromObject = new[] { "AzirSoldier" },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "azirr",
                ChampionName = "azir",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 475f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl
                    },
                CastSpeed = 4800
            });

            #endregion

            #region Bard
            HeroSpells.Add(new SpellData
            {
                SpellName = "bardq",
                ChampionName = "bard",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 950f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "bardqmissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bardw",
                ChampionName = "bard",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "barde",
                ChampionName = "bard",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 350f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bardr",
                ChampionName = "bard",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 3400f,
                CastDelay = 450f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                MissileName = "bardr",
                CastSpeed = 2100
            });
            
            #endregion
            
            #region Bel'veth
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "belvethq",
                ChampionName = "belveth",
                Slot = SpellSlot.Q,
                DisplayName = "Void Surge",
                CastRange = 400f,
                Radius = 100f,
                CastDelay = 0f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                ExtraCastSpeeds = new[] { 800, 850, 900, 950, 1000 },
                CastSpeed = 800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "belvethw",
                ChampionName = "belveth",
                Slot = SpellSlot.W,
                DisplayName = "Above and Below",
                CastRange = 660f,
                Radius = 200f,
                CastDelay = 500f,
                CastType = CastType.Direction,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "belvethe",
                ChampionName = "belveth",
                Slot = SpellSlot.E,
                DisplayName = "Royal Maelstrom",
                CastRange = 0f,
                Radius = 500f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "belvethr",
                ChampionName = "bel'veth",
                Slot = SpellSlot.R,
                DisplayName = "Endless Banquet",
                CastRange = 0f,
                Radius = 500f,
                CastDelay = 1000f,
                CastType = CastType.Unit,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

           
            #endregion

            #region Blitzcrank
            HeroSpells.Add(new SpellData
            {
                SpellName = "rocketgrab",
                ChampionName = "blitzcrank",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1050f,
                Radius = 70f,
                CastDelay = 250f,
                MissileName = "rocketgrabmissile",
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                CastSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "overdrive",
                ChampionName = "blitzcrank",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Radius = 100f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "powerfist",
                ChampionName = "blitzcrank",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 300f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "staticfield",
                ChampionName = "blitzcrank",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                FixedRange = true,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "",
                CastSpeed = 4800
            });

            #endregion
            
            #region Brand
            HeroSpells.Add(new SpellData
            {
                SpellName = "brandq",
                ChampionName = "brand",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1150f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "brandqmissile",
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "brandw",
                ChampionName = "brand",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 240f,
                CastDelay = 550f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "",
                CastSpeed = 20
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "brande",
                ChampionName = "brand",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 625f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "brandr",
                ChampionName = "brand",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 750f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                CastSpeed = 1000
            });

            #endregion
            
            #region Braum
            HeroSpells.Add(new SpellData
            {
                SpellName = "braumq",
                ChampionName = "braum",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1100f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "braumqmissile",
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "braumqmissle",
                ChampionName = "braum",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1100f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "braumw",
                ChampionName = "braum",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "braume",
                ChampionName = "braum",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "braumrwrapper",
                ChampionName = "braum",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1250f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "braumrmissile",
                CastSpeed = 1200
            });
            
            #endregion

            #region Camille
            HeroSpells.Add(new SpellData
            {
                SpellName = "camilleq",
                ChampionName = "camille",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 325f,
                Radius = 325f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "camillew",
                ChampionName = "camille",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 325f,
                Radius = 325f,
                CastDelay = 500f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2696
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "camillee",
                ChampionName = "camille",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 1100f,
                Radius = 35f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                MissileName = "camilleemissile",
                CastSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "camilleedash2",
                ChampionName = "camille",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 800f,
                Radius = 165f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "camiller",
                ChampionName = "camille",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 475f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 11200
            });

            #endregion

            #region Caitlyn
            HeroSpells.Add(new SpellData
            {
                SpellName = "caitlynpiltoverpeacemaker",
                ChampionName = "caitlyn",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                Radius = 60f,
                CastRange = 1300f,
                CastDelay = 450f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "caitlynpiltoverpeacemaker",
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "caitlynyordletrap",
                ChampionName = "caitlyn",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                Radius = 75f,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "caitlynentrapment",
                ChampionName = "caitlyn",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                Radius = 70f,
                CastRange = 1050f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "caitlynentrapmentmissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "caitlynaceinthehole",
                ChampionName = "caitlyn",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 2000f,
                Radius = 100f,
                CastDelay = 900f,
                FixedRange = false,
                MissileName = "",
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1500
            });
            
            #endregion

            #region Cassiopeia
            HeroSpells.Add(new SpellData
            {
                SpellName = "cassiopeiaq",
                ChampionName = "cassiopeia",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 925f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "cassiopeianoxiousblast",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "cassiopeiw",
                ChampionName = "cassiopeia",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                IsPerpindicular = true,
                CastRange = 925f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 2500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "cassiopeiae",
                ChampionName = "cassiopeia",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "cassiopeiar",
                ChampionName = "cassiopeia",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 875f,
                CastDelay = 350f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "cassiopeiar",
                CastSpeed = 4800
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "cassiopeiarstun",
                ChampionName = "cassiopeia",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 875f,
                CastDelay = 350f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "cassiopeiarstun",
                CastSpeed = 4800
            });
            
            #endregion
            
            #region Chogath
            HeroSpells.Add(new SpellData
            {
                SpellName = "rupture",
                ChampionName = "chogath",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 950f,
                Radius = 250f,
                CastDelay = 900f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "feralscream",
                ChampionName = "chogath",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 300f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vorpalspikes",
                ChampionName = "chogath",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 347
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "feast",
                ChampionName = "chogath",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 300f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                CastSpeed = 4800
            });
            
            #endregion
           
            #region Corki
            HeroSpells.Add(new SpellData
            {
                SpellName = "phosphorusbomb",
                ChampionName = "corki",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 875f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "phosphorusbombmissile",
                CastSpeed = 1125
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "carpetbomb",
                ChampionName = "corki",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                CastSpeed = 700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ggun",
                ChampionName = "corki",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CastRange = 750f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "missilebarrage",
                ChampionName = "corki",
                Slot = SpellSlot.R,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 1225f,
                CastDelay = 150f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "missilebarragemissile",
                ExtraMissileNames = new[] { "missilebarragemissile2" },
                CastSpeed = 2000
            });

            #endregion
            
            #region Darius
            HeroSpells.Add(new SpellData
            {
                SpellName = "dariuscleave",
                ChampionName = "darius",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                FixedRange = true,
                Radius = 425f,
                CastRange = 425f,
                CastDelay = 750f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dariusnoxiantacticsonh",
                ChampionName = "darius",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 205f,
                CastDelay = 150f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dariusaxegrabcone",
                ChampionName = "darius",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 555f,
                CastDelay = 150f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger, EmulationFlags.Initiator },
                MissileName = "dariusaxegrabcone",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dariusexecute",
                ChampionName = "darius",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                Radius = 475f,
                CastRange = 475f,
                CastDelay = 450f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                CastSpeed = 4800
            });
            
            #endregion
            
            #region Diana
            HeroSpells.Add(new SpellData
            {
                SpellName = "dianaarc",
                ChampionName = "diana",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 830f,
                Radius = 195f,
                CastDelay = 300f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "dianaarc",
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dianaorbs",
                ChampionName = "diana",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 200f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dianavortex",
                ChampionName = "diana",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 450f,
                Radius = 450f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dianateleport",
                ChampionName = "diana",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 825f,
                Radius = 250f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 2200
            });
            
            #endregion

            #region Draven
            HeroSpells.Add(new SpellData
            {
                SpellName = "dravenspinning",
                ChampionName = "draven",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dravenfury",
                ChampionName = "draven",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dravendoubleshot",
                ChampionName = "draven",
                Slot = SpellSlot.E,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1050f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "dravendoubleshotmissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "dravenrcast",
                ChampionName = "draven",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CastRange = 20000f,
                Global = true,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                MissileName = "dravenr",
                CastSpeed = 2000
            });

            #endregion

            #region Dr. Mundo
            HeroSpells.Add(new SpellData
            {
                SpellName = "drmundoq",
                ChampionName = "drmundo",
                Slot = SpellSlot.Q,
                DisplayName = "Infected Bonesaw",
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1050f,
                Radius = 120f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "drmundoqmis",
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "drmundow",
                ChampionName = "drmundo",
                Slot = SpellSlot.W,
                DisplayName = "Heart Zapper",
                CastRange = 0f,
                Radius = 325f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "drmundoe",
                ChampionName = "drmundo",
                Slot = SpellSlot.E,
                DisplayName = "Blunt Force Trauma",
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "drmundor",
                ChampionName = "drmundo",
                Slot = SpellSlot.R,
                DisplayName = "Maximum Dosage",
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });
            
            #endregion

            #region Ekko
            HeroSpells.Add(new SpellData
            {
                SpellName = "ekkoq",
                ChampionName = "ekko",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1075f,
                Radius = 60f,
                CastDelay = 66f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "ekkoqmis",
                ExtraMissileNames = new[] { "ekkoqreturn" },
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ekkoeattack",
                ChampionName = "ekko",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 300f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Gapcloser },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ekkor",
                ChampionName = "ekko",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 425f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                FromObject = new[] { "Ekko_Base_R_TrailEnd" },
                CastSpeed = 4800
            });
            
            #endregion 

            #region Elise
            HeroSpells.Add(new SpellData
            {
                SpellName = "elisehumanq",
                ChampionName = "elise",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 625f,
                CastDelay = 550f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisespiderqcast",
                ChampionName = "elise",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 475f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Gapcloser },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisehumanw",
                ChampionName = "elise",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 750f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 5000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisespiderw",
                ChampionName = "elise",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisehumane",
                ChampionName = "elise",
                Slot = SpellSlot.E,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1075f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                MissileName = "elisehumane",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisespidereinitial",
                ChampionName = "elise",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisespideredescent",
                ChampionName = "elise",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "eliser",
                ChampionName = "elise",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "elisespiderr",
                ChampionName = "elise",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });
            
            #endregion

            #region Evelynn
            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynnq",
                ChampionName = "evelynn",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynnq2",
                ChampionName = "evelynn",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 680f,
                CastDelay = 33.33f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "evelynnqlinemissile",
                CastSpeed = 2446
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynnw",
                ChampionName = "evelynn",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 1200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynne",
                ChampionName = "evelynn",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 225f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynne2",
                ChampionName = "evelynn",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 225f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "evelynnr",
                ChampionName = "evelynn",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 400f, // 650f + Radius
                CastDelay = 316f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "evelynnrtrail",
                CastSpeed = 4400
            });
            
            #endregion

            #region Ezreal
            HeroSpells.Add(new SpellData
            {
                SpellName = "ezrealmysticshot",
                ChampionName = "ezreal",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1150f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "ezrealmysticshotmissile",
                ExtraMissileNames = new[] { "ezrealmysticshotpulsemissile" },
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ezrealessenceflux",
                ChampionName = "ezreal",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1050f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "ezrealessencefluxmissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ezrealessencemissle",
                ChampionName = "ezreal",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1050f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ezrealarcaneshift",
                ChampionName = "ezreal",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 750f, // 475f + Bolt Range
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ezrealtrueshotbarrage",
                ChampionName = "ezreal",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 20000f,
                Global = true,
                CastDelay = 1000f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                MissileName = "ezrealtrueshotbarrage",
                CastSpeed = 2000
            });
            
            #endregion

            #region FiddleSticks
            HeroSpells.Add(new SpellData
            {
                SpellName = "fiddlesticksq",
                ChampionName = "fiddlesticks",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 575f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fiddlesticksw",
                ChampionName = "fiddlesticks",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 575f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fiddlestickse",
                ChampionName = "fiddlesticks",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 750f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fiddlesticksr",
                ChampionName = "fiddlesticks",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.ForceExhaust, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            #endregion

            #region Fiora
            HeroSpells.Add(new SpellData
            {
                SpellName = "fioraq",
                ChampionName = "fiora",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 400f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fioraw",
                ChampionName = "fiora",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 750f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fiorae",
                ChampionName = "fiora",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fiorar",
                ChampionName = "fiora",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 500f,
                CastDelay = 150f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            #endregion

            #region Fizz
            HeroSpells.Add(new SpellData
            {
                SpellName = "fizzq",
                ChampionName = "fizz",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                FixedRange = true,
                CastRange = 550f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizzw",
                ChampionName = "fizz",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 175f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizze",
                ChampionName = "fizz",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 450f,
                CastDelay = 700f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizzebuffer",
                ChampionName = "fizz",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 330f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizzejumptwo",
                ChampionName = "fizz",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 270f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fizzr",
                ChampionName = "fizz",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 1275f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                MissileName = "fizzmarinerdoommissile",
                CastSpeed = 1350
            });

            #endregion

            #region Galio
            HeroSpells.Add(new SpellData
            {
                SpellName = "galioq",
                ChampionName = "galio",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 1200f,
                Radius = 60,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "galioqmissile",
                CastSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galioqsuper",
                ChampionName = "galio",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 200f,
                Radius = 200,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galiow",
                ChampionName = "galio",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 275f,
                Radius = 275f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galiow2",
                ChampionName = "galio",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 275f,
                Radius = 275f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galioe",
                ChampionName = "galio",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 950f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                CastSpeed = 750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "galior",
                ChampionName = "galio",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 4800
            });

            #endregion

            #region Gangplank
            HeroSpells.Add(new SpellData
            {
                SpellName = "gangplankqwrapper",
                ChampionName = "gangplank",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 625f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gangplankqproceed",
                ChampionName = "gangplank",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 625f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gangplankw",
                ChampionName = "gangplank",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gangplanke",
                ChampionName = "gangplank",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gangplankr",
                ChampionName = "gangplank",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 20000f,
                Global = true,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2200
            });

            #endregion

            #region Garen
            HeroSpells.Add(new SpellData
            {
                SpellName = "garenq",
                ChampionName = "Garen",
                Slot = SpellSlot.Q,
                DisplayName = "Decisive Strike",
                CastRange = 0f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                CastSpeed = 4800,
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "garenqattack",
                ChampionName = "garen",
                Slot = SpellSlot.Q,
                DisplayName = "Decisive Strike",
                CastType = CastType.Unit,
                CastRange = 350f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                ChampionName = "Garen",
                Slot = SpellSlot.W,
                DisplayName = "Courage",
                CastRange = 0f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                ChampionName = "Garen",
                Slot = SpellSlot.E,
                DisplayName = "Judgment",
                CastRange = 0f,
                Radius = 325f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                ChampionName = "Garen",
                Slot = SpellSlot.R,
                DisplayName = "Demacian Justice",
                CastRange = 400,
                Radius = 0f,
                CastDelay = 435f,
                CastType = CastType.Unit,
                CastSpeed = 4800,
            });

            #endregion

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarq",
                ChampionName = "gnar",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1185f,
                CastDelay = 500f,
                Radius = 55,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1700,
                MissileName = "gnarqmissile",
                ExtraMissileNames = new[] { "gnarqmissilereturn" }
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarqmissilereturn",
                ChampionName = "gnar",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1185f,
                CastDelay = 250f,
                Radius = 75,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 700,
                MissileName = "gnarqmissilereturn"
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarbigq",
                ChampionName = "gnar",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1150f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 2000,
                MissileName = "gnarbigqmissile"
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarw",
                ChampionName = "gnar",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarbigw",
                ChampionName = "gnar",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 600f,
                CastDelay = 600f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnare",
                ChampionName = "gnar",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 475f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser, EmulationFlags.Initiator },
                CastSpeed = 880
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarbige",
                ChampionName = "gnar",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 475f,
                Radius = 350,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser, EmulationFlags.Initiator },
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gnarult",
                ChampionName = "gnar",
                CastRange = 600f,
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastDelay = 250f,
                Radius = 500,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },

                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "garenw",
                ChampionName = "garen",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "garene",
                ChampionName = "garen",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 660f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "garenr",
                ChampionName = "garen",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 400f,
                Radius = 100f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                CastSpeed = 4800
            });

            // todo: improve gragas
            HeroSpells.Add(new SpellData
            {
                SpellName = "gragasq",
                ChampionName = "gragas",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 1000, // 850f + Radius
                CastDelay = 500f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "gragasqmissile",
                CastSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gragasqtoggle",
                ChampionName = "gragas",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 1000, // 850f + Radius
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "gragasq"
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gragasqtoggle",
                ChampionName = "gragas",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 1100f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gragasw",
                ChampionName = "gragas",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gragase",
                ChampionName = "gragas",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl, EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                MissileName = "gragase",
                CastSpeed = 550
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gragasr",
                ChampionName = "gragas",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 1300f,
                Radius = 120f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                MissileName = "gragasrboom",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gravesq",
                ChampionName = "graves",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 1025,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "gravesclustershotattack",
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gravesw",
                ChampionName = "graves",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 1100f, // 950 + Radius
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gravese",
                ChampionName = "graves",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 278f,
                CastDelay = 300f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                CastSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gravesr",
                ChampionName = "graves",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 1000f,
                FixedRange = true,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                MissileName = "graveschargeshotshot",
                CastSpeed = 2100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gwenq",
                ChampionName = "gwen",
                Slot = SpellSlot.Q,
                DisplayName = "Snip Snip!",
                CastRange = 0f,
                Radius = 0f,
                CastDelay = 500f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gwenw",
                ChampionName = "gwen",
                Slot = SpellSlot.W,
                DisplayName = "Hallowed Mist",
                CastRange = 0f,
                Radius = 480f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2000,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gwene",
                ChampionName = "gwen",
                Slot = SpellSlot.E,
                DisplayName = "Skip n Slash",
                CastRange = 350f,
                SecondaryCastRange = 450f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Location,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "gwenr",
                ChampionName = "gwen",
                Slot = SpellSlot.R,
                DisplayName = "Needlework",
                CastRange = 0f,
                Radius = 240f,
                CastDelay = 250f,
                SecondaryCastDelay = 500f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1800,
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "hecarimrapidslash",
                ChampionName = "hecarim",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 350f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hecarimw",
                ChampionName = "hecarim",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hecarimramp",
                ChampionName = "hecarim",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hecarimult",
                ChampionName = "hecarim",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1525f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl
                    },

                MissileName = "hecarimultmissile",
                ExtraMissileNames =
                    new[]
                    {
                        "hecarimultmissileskn4r1", "hecarimultmissileskn4r2", "hecarimultmissileskn4l1",
                        "hecarimultmissileskn4l2", "hecarimultmissileskn4rc"
                    },
                CastSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingerturretenergyblast",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 435f,
                EmuFlags = new EmulationFlags[] { },
                FromObject = new[] { "heimerdinger_turret_idle" },
                CastSpeed = 1650
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingerturretbigenergyblast",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 350f,
                EmuFlags = new EmulationFlags[] { },
                FromObject = new[] { "heimerdinger_base_r" },
                CastSpeed = 1650
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingerw",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1100,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingere",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 1025f, // 925 + Radius
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "heimerdingerespell",
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingerr",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 230f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "heimerdingereult",
                ChampionName = "heimerdinger",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 1450f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ireliagatotsu",
                ChampionName = "irelia",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 650f,
                CastDelay = 150f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ireliahitenstyle",
                ChampionName = "irelia",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 230f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ireliaequilibriumstrike",
                ChampionName = "irelia",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 450f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ireliatranscendentblades",
                ChampionName = "irelia",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                FixedRange = true,
                CastRange = 1200f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "ireliatranscendentbladesspell",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "illaoiq",
                ChampionName = "illaoi",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 950f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "illaoiemis",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "illaoiw",
                ChampionName = "illaoi",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 365f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "illaoie",
                ChampionName = "illaoi",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 950f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "illaoiemis",
                CastSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "illaoir",
                ChampionName = "illaoi",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 450f,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.Ultimate, EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ivernq",
                ChampionName = "ivern",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                Radius = 65f,
                CastRange = 1100f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "ivernq",
                CastSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ivernq",
                ChampionName = "ivern",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "ivernw",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "iverne",
                ChampionName = "ivern",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "iverne",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "howlinggale",
                ChampionName = "janna",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 1550f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "howlinggalespell",
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sowthewind",
                ChampionName = "janna",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "eyeofthestorm",
                ChampionName = "janna",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reapthewhirlwind",
                ChampionName = "janna",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 725f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jarvanivdragonstrike",
                ChampionName = "jarvaniv",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "",
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jarvanivgoldenaegis",
                ChampionName = "jarvaniv",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jarvanivdemacianstandard",
                ChampionName = "jarvaniv",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 830f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "jarvanivdemacianstandard",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jarvanivcataclysm",
                ChampionName = "jarvaniv",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 825f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate, EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaxleapstrike",
                ChampionName = "jax",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaxempowertwo",
                ChampionName = "jax",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaxrelentlessasssault",
                ChampionName = "jax",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycetotheskies",
                ChampionName = "jayce",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger, EmulationFlags.Gapcloser },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jayceshockblast",
                ChampionName = "jayce",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1570f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                MissileName = "jayceshockblastmis",
                CastSpeed = 2350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycestaticfield",
                ChampionName = "jayce",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 285f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycehypercharge",
                ChampionName = "jayce",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 750f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycethunderingblow",
                ChampionName = "jayce",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 325f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jayceaccelerationgate",
                ChampionName = "jayce",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                IsPerpindicular = true,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycestancehtg",
                ChampionName = "jayce",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 750f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jaycestancegth",
                ChampionName = "jayce",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 750f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jhinq",
                ChampionName = "jhin",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 575f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jhinw",
                ChampionName = "jhin",
                Slot = SpellSlot.W,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastType = CastType.Location,
                CastRange = 2250f,
                CastDelay = 750f,
                FixedRange = true,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "jhinwmissile",
                CastSpeed = 5000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jhine",
                ChampionName = "jhin",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 2250f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jhinrshot",
                ChampionName = "jhin",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 3500f,
                CastDelay = 250f,
                FixedRange = true,
                MissileName = "jhinrshotmis",
                EmuFlags = new[] { EmulationFlags.Initiator },
                ExtraMissileNames = new[] { "jhinrmmissile", "jhinrshotmis4" },
                CastSpeed = 5000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jinxq",
                ChampionName = "jinx",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jinxw",
                ChampionName = "jinx",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                Radius = 60f,
                FixedRange = true,
                CastRange = 1500f,
                CastDelay = 450f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "jinxwmissile",
                CastSpeed = 3300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jinxe",
                ChampionName = "jinx",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 900f,
                Radius = 315f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jinxr",
                ChampionName = "jinx",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 25000f,
                Radius = 140f,
                CastDelay = 450f,
                MissileName = "jinxr",
                ExtraMissileNames = new[] { "jinxrwrapper" },
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                CastSpeed = 1700
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "kaisaw",
                ChampionName = "kaisa",
                Slot = SpellSlot.W,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 3000f,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "kaisawmis",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "karmaq",
                ChampionName = "karma",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 1050f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "karmaqmissile",
                CastSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "karmaspiritbind",
                ChampionName = "karma",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "karmasolkimshield",
                ChampionName = "karma",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "karmamantra",
                ChampionName = "karma",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "laywaste",
                ChampionName = "karthus",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 875f,
                CastDelay = 900f,
                EmuFlags = new EmulationFlags[] { },
                ExtraMissileNames = new[]
                {
                    "karthuslaywastea3", "karthuslaywastea1", "karthuslaywastedeada1", "karthuslaywastedeada2",
                    "karthuslaywastedeada3"
                },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "wallofpain",
                ChampionName = "karthus",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "defile",
                ChampionName = "karthus",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 550f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fallenone",
                ChampionName = "karthus",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 22000f,
                Global = true,
                CastDelay = 2800f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nulllance",
                ChampionName = "kassadin",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 650f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                CastSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "netherblade",
                ChampionName = "kassadin",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "forcepulse",
                ChampionName = "kassadin",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "riftwalk",
                ChampionName = "kassadin",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 675f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                MissileName = "riftwalk",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "katarinaq",
                ChampionName = "katarina",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 675f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "katarinaw",
                ChampionName = "katarina",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                Radius = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "katarinae",
                ChampionName = "katarina",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 700f,
                Radius = 200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "katarinar",
                ChampionName = "katarina",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 550f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.ForceExhaust, EmulationFlags.Initiator },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "judicatorreckoning",
                ChampionName = "kayle",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 650f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "judicatordevineblessing",
                ChampionName = "kayle",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 900f,
                CastDelay = 220f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "judicatorrighteousfury",
                ChampionName = "kayle",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "judicatorintervention",
                ChampionName = "kayle",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 900f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            #region Kayn

            HeroSpells.Add(new SpellData
            { 
                SpellName = "kaynq",
                ChampionName = "kayn",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 345f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser, EmulationFlags.Danger },
                CastSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kaynw",
                ChampionName = "kayn",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 700f,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kaynr",
                ChampionName = "kayn",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 550f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kaynrjumpout",
                ChampionName = "kayn",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 450f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            #endregion

            HeroSpells.Add(new SpellData
            {
                SpellName = "kennenshurikenhurlmissile1",
                ChampionName = "kennen",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1175f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "kennenshurikenhurlmissile1",
                CastSpeed = 1700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kennenbringthelight",
                ChampionName = "kennen",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 900f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kennenlightningrush",
                ChampionName = "kennen",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kennenshurikenstorm",
                ChampionName = "kennen",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 550f,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixq",
                ChampionName = "khazix",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 325f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixqlong",
                ChampionName = "khazix",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 375f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixw",
                ChampionName = "khazix",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "khazixwmissile",
                CastSpeed = 81700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixwlong",
                ChampionName = "khazix",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixe",
                ChampionName = "khazix",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 600f,
                CastDelay = 250f,
                Radius = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                MissileName = "khazixe",
                CastSpeed = 800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixelong",
                ChampionName = "khazix",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 900f,
                Radius = 250f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                CastSpeed = 900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixr",
                ChampionName = "khazix",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Stealth, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "khazixrlong",
                ChampionName = "khazix",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Stealth },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kindredq",
                ChampionName = "kindred",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 350f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kindrede",
                ChampionName = "kindred",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 510f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kledq",
                ChampionName = "kled",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 800f,
                Radius = 45f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "kledqmissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kledriderq",
                ChampionName = "kled",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 700f,
                Radius = 40f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "kledriderqmissile",
                CastSpeed = 3000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kledw",
                ChampionName = "kled",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "klede",
                ChampionName = "kled",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 800f,
                Radius = 124f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                MissileName = "kledemissile",
                CastSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kledr",
                ChampionName = "kled",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kogmawq",
                ChampionName = "kogmaw",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1300f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "kogmawqmissile",
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kogmawbioarcanebarrage",
                ChampionName = "kogmaw",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kogmawvoidooze",
                ChampionName = "kogmaw",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1150f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "kogmawvoidoozemissile",
                CastSpeed = 1250
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kogmawlivingartillery",
                ChampionName = "kogmaw",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 2200f,
                CastDelay = 1200f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancq",
                ChampionName = "leblanc",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancw",
                ChampionName = "leblanc",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 650f,
                Radius = 175f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                MissileName = "leblancw",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblacwreturn",
                ChampionName = "leblanc",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblance",
                ChampionName = "leblanc",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 925f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "leblancemissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancrq",
                ChampionName = "leblanc",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancrw",
                ChampionName = "leblanc",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 650f,
                Radius = 175f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate, EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                MissileName = "leblancrw",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancrwreturn",
                ChampionName = "leblanc",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leblancre",
                ChampionName = "leblanc",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 925f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "leblancremissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkqone",
                ChampionName = "leesin",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "blindmonkqone",
                CastSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkqtwo",
                ChampionName = "leesin",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 1100f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                CastSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkwone",
                ChampionName = "leesin",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser, EmulationFlags.Initiator },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkwtwo",
                ChampionName = "leesin",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 700f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkeone",
                ChampionName = "leesin",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 425f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonketwo",
                ChampionName = "leesin",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 350f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindmonkrkick",
                ChampionName = "leesin",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 375f,
                CastDelay = 500f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leonashieldofdaybreak",
                ChampionName = "leona",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 215f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leonasolarbarrier",
                ChampionName = "leona",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 250f,
                CastDelay = 3000f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leonazenithblade",
                ChampionName = "leona",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 900f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                MissileName = "leonazenithblademissile",
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "leonasolarflare",
                ChampionName = "leona",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 1200f,
                CastDelay = 1200f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "leonasolarflare",
                CastSpeed = 4800
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "lilliaq",
                ChampionName = "lillia",
                Slot = SpellSlot.Q,
                DisplayName = "Blooming Blows",
                CastRange = 0f,
                Radius = 225f,
                SecondaryRadius = 485f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lilliaw",
                ChampionName = "lillia",
                Slot = SpellSlot.W,
                DisplayName = "Watch Out! Eep!",
                CastRange = 500f,
                SecondaryCastRange = 350f,
                Radius = 65f,
                SecondaryRadius = 250f,
                CastDelay = 250f,
                CastType = CastType.Location,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lilliae",
                ChampionName = "lillia",
                Slot = SpellSlot.E,
                DisplayName = "Swirlseed",
                CastRange = float.MaxValue,
                Global = true,
                Radius = 150f,
                CastDelay = 400f,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                ExtraCastSpeeds = new[] { 5000, 1400 },
                CastSpeed = 5000,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lilliar",
                ChampionName = "lillia",
                Slot = SpellSlot.R,
                DisplayName = "Lilting Lullaby",
                CastRange = 0f,
                Radius = float.MaxValue,
                CastDelay = 400f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lissandraq",
                ChampionName = "lissandra",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 725f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "lissandraqmissile",
                CastSpeed = 2250
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lissandraw",
                ChampionName = "lissandra",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 450f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lissandrae",
                ChampionName = "lissandra",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1050f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "lissandraemissile",
                CastSpeed = 850
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lissandrar",
                ChampionName = "lissandra",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 550f,
                CastDelay = 250f,
                EmuFlags = new[]
                {
                    EmulationFlags.CrowdControl, EmulationFlags.Initiator,
                    EmulationFlags.Danger, EmulationFlags.Ultimate
                },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lucianq",
                ChampionName = "lucian",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                FixedRange = true,
                CastRange = 1150f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "lucianq",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lucianw",
                ChampionName = "lucian",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1050f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "lucianwmissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luciane",
                ChampionName = "lucian",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 650f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Gapcloser },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lucianr",
                ChampionName = "lucian",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1400f,
                Radius = 110,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "lucianrmissileoffhand",
                ExtraMissileNames = new[] { "lucianrmissile" },
                CastSpeed = 2800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luluq",
                ChampionName = "lulu",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 925f,
                Radius = 60,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "luluqmissile",
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luluw",
                ChampionName = "lulu",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 650f,
                CastDelay = 640f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lulue",
                ChampionName = "lulu",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 650f,
                CastDelay = 640f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "lulur",
                ChampionName = "lulu",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 900f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luxlightbinding",
                ChampionName = "lux",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1300f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "luxlightbindingmis",
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luxprismaticwave",
                ChampionName = "lux",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luxlightstrikekugel",
                ChampionName = "lux",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 1100f,
                Radius = 330f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "luxlightstrikekugel",
                CastSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luxlightstriketoggle",
                ChampionName = "lux",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "luxmalicecannon",
                ChampionName = "lux",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 3500f,
                Radius = 299.3f,
                CastDelay = 1000f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                MissileName = "luxmalicecannonmis",
                CastSpeed = 3000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kalistamysticshot",
                ChampionName = "kalista",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastType = CastType.Direction,
                CastRange = 1200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "kalistamysticshotmis",
                ExtraMissileNames = new[] { "kalistamysticshotmistrue" },
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kalistaw",
                ChampionName = "kalista",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 5000f,
                CastDelay = 800f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "kalistaexpungewrapper",
                ChampionName = "kalista",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "seismicshard",
                ChampionName = "malphite",
                Slot = SpellSlot.Q,
                DisplayName = "Seismic Shard",
                CastRange = 625f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Unit,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1200,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "obduracy",
                ChampionName = "malphite",
                Slot = SpellSlot.W,
                DisplayName = "Thunderclap",
                CastRange = 0f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "landslide",
                ChampionName = "malphite",
                Slot = SpellSlot.E,
                DisplayName = "Ground Slam",
                CastRange = 0f,
                Radius = 400f,
                CastDelay = 241.9f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ufslash",
                ChampionName = "malphite",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 1000f,
                Radius = 325f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "ufslash",
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "malzaharq",
                ChampionName = "malzahar",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                IsPerpindicular = true,
                CastRange = 900f,
                CastDelay = 600f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "alzaharcallofthevoid",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "malzaharw",
                ChampionName = "malzahar",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "malzahare",
                ChampionName = "malzahar",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 650f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "malzaharr",
                ChampionName = "malzahar",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "maokaiq",
                ChampionName = "maokai",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 650f,
                Radius = 110f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "maokaiqmissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "maokaiw",
                ChampionName = "maokai",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 525f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "maokaie",
                ChampionName = "maokai",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 1100f,
                Radius = 120f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "maokaiemissile",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "maokair",
                ChampionName = "maokai",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                Radius = 120f,
                CastRange = 3000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                MissileName = "maokairmis",
                CastSpeed = 400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "alphastrike",
                ChampionName = "masteryi",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 600f,
                EmuFlags = new[] { EmulationFlags.Gapcloser, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "meditate",
                ChampionName = "masteryi",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "wujustyle",
                ChampionName = "masteryi",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 230f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "highlander",
                ChampionName = "masteryi",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 370f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "missfortunericochetshot",
                ChampionName = "missfortune",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 650f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "missfortuneviciousstrikes",
                ChampionName = "missfortune",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "missfortunescattershot",
                ChampionName = "missfortune",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "missfortunebullettime",
                ChampionName = "missfortune",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1400f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "monkeykingdoubleattack",
                ChampionName = "monkeyking",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 300f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 20
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "monkeykingdecoy",
                ChampionName = "monkeyking",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Stealth },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "monkeykingdecoyswipe",
                ChampionName = "monkeyking",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 300f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                FromObject = new[] { "Base_W_Copy" },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "monkeykingnimbus",
                ChampionName = "monkeyking",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 625f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Gapcloser },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "monkeykingspintowin",
                ChampionName = "monkeyking",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 450f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "mordekaisermaceofspades",
                ChampionName = "mordekaiser",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "mordekaisercreepindeathcast",
                ChampionName = "mordekaiser",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 750f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "mordekaisersyphoneofdestruction",
                ChampionName = "mordekaiser",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "mordekaiserchildrenofthegrave",
                ChampionName = "mordekaiser",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 850f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            #region Morgana

            HeroSpells.Add(new SpellData
            {
                SpellName = "morganaq",
                ChampionName = "morgana",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1175f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "darkbindingmissile",
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "morganaw",
                ChampionName = "morgana",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 850f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "morganae",
                ChampionName = "morgana",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "morganar",
                ChampionName = "morgana",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            #endregion

            #region Nami
            HeroSpells.Add(new SpellData
            {
                SpellName = "namiq",
                ChampionName = "nami",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 875f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                MissileName = "namiqmissile",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "namiw",
                ChampionName = "nami",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 725f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "namie",
                ChampionName = "nami",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "namir",
                ChampionName = "nami",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 2550f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                MissileName = "namirmissile",
                CastSpeed = 1200
            });

            #endregion

            #region Nasus

            HeroSpells.Add(new SpellData
            {
                SpellName = "nasusq",
                ChampionName = "nasus",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 450f,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.Danger },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nasusw",
                ChampionName = "nasus",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nasuse",
                ChampionName = "nasus",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 850f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nasusr",
                ChampionName = "nasus",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 200f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            #endregion

            #region Nautilus
            HeroSpells.Add(new SpellData
            {
                SpellName = "nautilusanchordrag",
                ChampionName = "nautilus",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 1080f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger, EmulationFlags.Initiator, EmulationFlags.Gapcloser },
                MissileName = "nautilusanchordragmissile",
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nautiluspiercinggaze",
                ChampionName = "nautilus",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nautilussplashzone",
                ChampionName = "nautilus",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nautilusgrandline",
                ChampionName = "nautilus",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 1250f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 1400
            });

            #endregion

            #region Nidalee

            HeroSpells.Add(new SpellData
            {
                SpellName = "javelintoss",
                ChampionName = "nidalee",
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                Slot = SpellSlot.Q,
                FixedRange = true,
                CastRange = 1500f,
                Radius = 299.3f,
                CastDelay = 125f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "javelintoss",
                CastSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "takedown",
                ChampionName = "nidalee",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 500f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bushwhack",
                ChampionName = "nidalee",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 900f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pounce",
                ChampionName = "nidalee",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 375f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "primalsurge",
                ChampionName = "nidalee",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "swipe",
                ChampionName = "nidalee",
                FixedRange = true,
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CastRange = 350f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "aspectofthecougar",
                ChampionName = "nidalee",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            #endregion
            
            #region Nilah

            HeroSpells.Add(new SpellData
            {
                SpellName = "nilahq",
                ChampionName = "nilah",
                Slot = SpellSlot.Q,
                DisplayName = "Formless Blade",
                CastRange = 600f,
                Radius = 150f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nilahw",
                ChampionName = "nilah",
                Slot = SpellSlot.W,
                DisplayName = "Jubilant Veil",
                CastRange = 0f,
                Radius = 150f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nilahe",
                ChampionName = "nilah",
                Slot = SpellSlot.E,
                DisplayName = "Slipstream",
                CastRange = 550f,
                Radius = 150f,
                CastDelay = 250f,
                CastType = CastType.Unit,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2200,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nilahr",
                ChampionName = "nilah",
                Slot = SpellSlot.R,
                DisplayName = "Apotheosis",
                CastRange = 0f,
                Radius = 450f,
                SecondaryRadius = 1500f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            
            #endregion

            #region Nocturne
            HeroSpells.Add(new SpellData
            {
                SpellName = "nocturneduskbringer",
                ChampionName = "nocturne",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1125f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nocturneshroudofdarkness",
                ChampionName = "nocturne",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nocturneunspeakablehorror",
                ChampionName = "nocturne",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 350f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "nocturneparanoia",
                ChampionName = "nocturne",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 20000f,
                Global = true,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 500
            });
            #endregion

            #region Nunu
            HeroSpells.Add(new SpellData
            {
                SpellName = "consume",
                ChampionName = "nunu",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bloodboil",
                ChampionName = "nunu",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "iceblast",
                ChampionName = "nunu",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 550f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "absolutezero",
                ChampionName = "nunu",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 650f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });
            #endregion

            #region Olaf

            HeroSpells.Add(new SpellData
            {
                SpellName = "olafaxethrowcast",
                ChampionName = "olaf",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "olafaxethrow",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "olaffrenziedstrikes",
                ChampionName = "olaf",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "olafrecklessstrike",
                ChampionName = "olaf",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 325f,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "olafragnarok",
                ChampionName = "olaf",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            #endregion

            #region Orianna

            HeroSpells.Add(new SpellData
            {
                SpellName = "orianaizunacommand",
                ChampionName = "orianna",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 900f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "orianaizuna",
                FromObject = new[] { "yomu_ring" },
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "orianadissonancecommand",
                ChampionName = "orianna",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 400f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "orianadissonancecommand",
                FromObject = new[] { "yomu_ring" },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "orianaredactcommand",
                ChampionName = "orianna",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 1095f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "orianaredact",
                FromObject = new[] { "yomu_ring" },
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "orianadetonatecommand",
                ChampionName = "orianna",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 425f,
                CastDelay = 500f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "orianadetonatecommand",
                FromObject = new[] { "yomu_ring" },
                CastSpeed = 4800
            });

            #endregion

            #region Pantheon

            HeroSpells.Add(new SpellData
            {
                SpellName = "pantheonq",
                ChampionName = "pantheon",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pantheonw",
                ChampionName = "pantheon",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pantheone",
                ChampionName = "pantheon",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pantheonrjump",
                ChampionName = "pantheon",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 1000f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 3000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pantheonrfall",
                ChampionName = "pantheon",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 1000f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 3000
            });

            #endregion

            #region Poppy

            HeroSpells.Add(new SpellData
            {
                SpellName = "poppyq",
                ChampionName = "poppy",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 450f,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });


            HeroSpells.Add(new SpellData
            {
                SpellName = "poppyw",
                ChampionName = "poppy",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "poppye",
                ChampionName = "poppy",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 525f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "poppyrspell",
                ChampionName = "poppy",
                FixedRange = true,
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CastRange = 1150f,
                CastDelay = 300f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "poppyrspellmissile",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "poppyrspellinstant",
                ChampionName = "poppy",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 450f,
                CastDelay = 300f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                CastSpeed = 4800
            });

            #endregion

            #region Pyke
            HeroSpells.Add(new SpellData
            {
                SpellName = "pykeq",
                ChampionName = "pyke",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 400f,
                Radius = 140f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 500
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "pykeqrange",
                ChampionName = "pyke",
                Slot = SpellSlot.Q,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastType = CastType.Direction,
                CastRange = 1100f,
                Radius = 140f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 2000
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "pykee",
                ChampionName = "pyke",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 550f,
                Radius = 110f,
                CastDelay = 750f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 1650
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "pyker",
                ChampionName = "pyke",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 750f,
                Radius = - 282f,
                CastDelay = 750f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl, EmulationFlags.Ultimate },
                CastSpeed = 1200
            });

            #endregion

            #region Qiyana
            HeroSpells.Add(new SpellData
            {
                SpellName = "qiyanaq_rock",
                ChampionName = "qiyana",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 865f,
                Radius = 200f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "qiyanaq_water",
                ChampionName = "qiyana",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 865f,
                Radius = 200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1600
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "qiyanaq_grass",
                ChampionName = "qiyana",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 650f,
                Radius = 250f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "qiyanar",
                ChampionName = "qiyana",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 865f,
                Radius = 280f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Ultimate },
                CastSpeed = 2000
            });

            #endregion

            #region Quinn
            HeroSpells.Add(new SpellData
            {
                SpellName = "quinnq",
                ChampionName = "quinn",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1050f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "quinnqmissile",
                ExtraMissileNames = new[] { "quinnq" },
                CastSpeed = 1550
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "quinnw",
                ChampionName = "quinn",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "quinne",
                ChampionName = "quinn",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                CastSpeed = 775
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "quinnr",
                ChampionName = "quinn",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "quinnrfinale",
                ChampionName = "quinn",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 700f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            #endregion

            #region Rakan
            HeroSpells.Add(new SpellData
            {
                SpellName = "rakanq",
                ChampionName = "rakan",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 900f,
                Radius = 65f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "rakanqmis",
                CastSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakanw",
                ChampionName = "rakan",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 650f,
                Radius = 285f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1425
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakanwcast",
                ChampionName = "rakan",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 285f,
                Radius = 285f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakane",
                ChampionName = "rakan",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 210f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 3430
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakanecast",
                ChampionName = "rakan",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 210f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 3430
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rakanr",
                ChampionName = "rakan",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 210f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            #endregion

            #region Rammus
            HeroSpells.Add(new SpellData
            {
                SpellName = "powerball",
                ChampionName = "rammus",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 775
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "defensiveballcurl",
                ChampionName = "rammus",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "puncturingtaunt",
                ChampionName = "rammus",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 325f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tremors2",
                ChampionName = "rammus",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 300f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            #endregion

            HeroSpells.Add(new SpellData
            {
                SpellName = "renektoncleave",
                ChampionName = "renekton",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 225f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "renektonpreexecute",
                ChampionName = "renekton",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                BasicAttackAmplifier = true,
                CastRange = 275f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "renektonsliceanddice",
                ChampionName = "renekton",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 450f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "renektonreignofthetyrant",
                ChampionName = "renekton",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rengarq2",
                ChampionName = "rengar",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 275f,
                Radius = 150f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rengarq2emp",
                ChampionName = "rengar",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 275f,
                Radius = 150f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rengarw",
                ChampionName = "rengar",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 500f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rengare",
                ChampionName = "rengar",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "rengaremis",
                ExtraMissileNames = new[] { "rengareempmis" },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rengarr",
                ChampionName = "rengar",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaiq",
                ChampionName = "reksai",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                FixedRange = true,
                CastRange = 275f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaiqburrowed",
                ChampionName = "reksai",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastRange = 1650f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "reksaiqburrowedmis",
                CastSpeed = 1950
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaiw",
                ChampionName = "reksai",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 350f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaiwburrowed",
                ChampionName = "reksai",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaie",
                ChampionName = "reksai",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 250f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksaieburrowed",
                ChampionName = "reksai",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 350f,
                CastDelay = 900f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "reksair",
                ChampionName = "reksai",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 850,
                CastDelay = 1000f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.Ultimate },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rellq",
                ChampionName = "rell",
                Slot = SpellSlot.Q,
                DisplayName = "Shattering Strike",
                CastRange = 685f,
                Radius = 150f,
                CastDelay = 350f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rellw",
                ChampionName = "rell",
                Slot = SpellSlot.W,
                DisplayName = "Ferromancy: Crash Down",
                CastRange = 500f,
                SecondaryCastRange = 100f,
                Radius = 0f,
                CastDelay = 625f,
                CastType = CastType.Location,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rellw",
                ChampionName = "rell",
                Slot = SpellSlot.W,
                DisplayName = "Ferromancy: Mount Up",
                CastRange = 0f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "relle",
                ChampionName = "rell",
                Slot = SpellSlot.E,
                DisplayName = "Attract and Repel",
                CastRange = 1500f,
                Radius = 250f,
                CastDelay = 250f,
                CastType = CastType.Unit,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rellr",
                ChampionName = "rell",
                Slot = SpellSlot.R,
                DisplayName = "Magnet Storm",
                CastRange = 0f,
                Radius = 450f,
                SecondaryRadius = 375f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new[] { EmulationFlags.Ultimate },
                CastSpeed = 300,
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "riventricleave",
                ChampionName = "riven",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 270f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rivenmartyr",
                ChampionName = "riven",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 260f,
                CastDelay = 100f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rivenfeint",
                ChampionName = "riven",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rivenfengshuiengine",
                ChampionName = "riven",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rivenizunablade",
                ChampionName = "riven",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1075f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                MissileName = "rivenlightsabermissile",
                ExtraMissileNames = new[] { "rivenlightsabermissileside" },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rumbleflamethrower",
                ChampionName = "rumble",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rumbleshield",
                ChampionName = "rumble",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rumbegrenade",
                ChampionName = "rumble",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 850f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "rumblecarpetbomb",
                ChampionName = "rumble",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CastRange = 1700f,
                CastDelay = 400f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                MissileName = "rumblecarpetbombmissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ryzeq",
                ChampionName = "ryze",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 925f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "ryzeqmissile",
                ExtraMissileNames = new[] { "ryzeq" },
                CastSpeed = 1700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ryzew",
                ChampionName = "ryze",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ryzee",
                ChampionName = "ryze",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ryzer",
                ChampionName = "ryze",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 1400
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "samiraq",
                ChampionName = "samira",
                Slot = SpellSlot.Q,
                DisplayName = "Flair",
                CastRange = 340f,
                SecondaryCastRange = 950f,
                Radius = 120f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes, CollisionObjectType.EnemyMinions },
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2600,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "samiraw",
                ChampionName = "samira",
                Slot = SpellSlot.W,
                DisplayName = "Blade Whirl",
                CastRange = 0f,
                Radius = 325f,
                CastDelay = 100f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "samirae",
                ChampionName = "samira",
                Slot = SpellSlot.E,
                DisplayName = "Wild Rush",
                CastRange = 600f,
                Radius = 265f,
                CastDelay = 250f,
                CastType = CastType.Unit,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "samirar",
                ChampionName = "samira",
                Slot = SpellSlot.R,
                DisplayName = "Inferno Trigger",
                CastRange = 0f,
                Radius = 600f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new[] { EmulationFlags.Ultimate },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sejuaniarcticassault",
                ChampionName = "sejuani",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 650f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                MissileName = "",
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sejuaninorthernwinds",
                ChampionName = "sejuani",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 1000f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sejuaniwintersclaw",
                ChampionName = "sejuani",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 550f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sejuaniglacialprisoncast",
                ChampionName = "sejuani",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 1200f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "sejuaniglacialprison",
                CastSpeed = 1600
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "sennaqcast",
                ChampionName = "senna",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 1100f,
                Radius = 130f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2800
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "sennaw",
                ChampionName = "senna",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes, CollisionObjectType.EnemyMinions },
                CastRange = 1300f,
                Radius = 280f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1200
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "sennar",
                ChampionName = "senna",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = float.MaxValue,
                Radius = 320f,
                CastDelay = 500f,
                Global = true,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 2000
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "seraphineq",
                ChampionName = "seraphine",
                Slot = SpellSlot.Q,
                DisplayName = "High Note",
                CastRange = 900f,
                Radius = 350f,
                CastDelay = 250f,
                CastType = CastType.Location,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1200,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "seraphinew",
                ChampionName = "seraphine",
                Slot = SpellSlot.W,
                DisplayName = "Surround Sound",
                CastRange = 0f,
                Radius = 800f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "seraphinee",
                ChampionName = "seraphine",
                Slot = SpellSlot.E,
                DisplayName = "Beat Drop",
                CastRange = 1300f,
                Radius = 140f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1200,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "seraphiner",
                ChampionName = "seraphine",
                Slot = SpellSlot.R,
                DisplayName = "Encore",
                CastRange = 1200f,
                Radius = 320f,
                CastDelay = 500f,
                CastType = CastType.Direction,
                EmuFlags = new[] {  EmulationFlags.Ultimate },
                CastSpeed = 1600,
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "deceive",
                ChampionName = "shaco",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Stealth },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "jackinthebox",
                ChampionName = "shaco",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twoshivpoison",
                ChampionName = "shaco",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 625f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hallucinatefull",
                ChampionName = "shaco",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 1125f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 395
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shenq",
                ChampionName = "shen",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 1650f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                FromObject = new[] { "ShenArrowVfxHostMinion" },
                CastSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shenw",
                ChampionName = "shen",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shene",
                ChampionName = "shen",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 675f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                MissileName = "shene",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shenr",
                ChampionName = "shen",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanadoubleattack",
                ChampionName = "shyvana",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                BasicAttackAmplifier = true,
                CastRange = 275f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanadoubleattackdragon",
                ChampionName = "shyvana",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 325f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanaimmolationauraqw",
                ChampionName = "shyvana",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 275f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanaimmolateddragon",
                ChampionName = "shyvana",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 250f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanafireball",
                ChampionName = "shyvana",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 925f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "shyvanafireballmissile",
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanafireballdragon2",
                ChampionName = "shyvana",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CastRange = 925f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "shyvanatransformcast",
                ChampionName = "shyvana",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 100f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.CrowdControl,
                        EmulationFlags.Ultimate, EmulationFlags.Initiator
                    },
                MissileName = "shyvanatransformcast",
                CastSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "poisentrail",
                ChampionName = "singed",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 250f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "megaadhesive",
                ChampionName = "singed",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 1175f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "fling",
                ChampionName = "singed",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 125f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "insanitypotion",
                ChampionName = "singed",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sionq",
                ChampionName = "sion",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sionwdetonate",
                ChampionName = "sion",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 350f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sione",
                ChampionName = "sion",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 725f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "sionemissile",
                CastSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sionr",
                ChampionName = "sion",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                MissileName = "",
                CastSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sivirq",
                ChampionName = "sivir",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1165f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "sivirqmissile",
                ExtraMissileNames = new[] { "sivirqmissilereturn" },
                CastSpeed = 1350
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sivirw",
                ChampionName = "sivir",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sivire",
                ChampionName = "sivir",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sivirr",
                ChampionName = "sivir",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "skarnervirulentslash",
                ChampionName = "skarner",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 350f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "skarnerexoskeleton",
                ChampionName = "skarner",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "skarnerfracture",
                ChampionName = "skarner",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1100f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "skarnerfracturemissile",
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "skarnerimpale",
                ChampionName = "skarner",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 350f,
                CastDelay = 350f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sonaq",
                ChampionName = "sona",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sonaw",
                ChampionName = "sona",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sonae",
                ChampionName = "sona",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sonar",
                ChampionName = "sona",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "sonar",
                CastSpeed = 2400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sorakaq",
                ChampionName = "soraka",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 970f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "",
                CastSpeed = 1100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sorakaw",
                ChampionName = "soraka",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sorakae",
                ChampionName = "soraka",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 925f,
                CastDelay = 1750f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sorakar",
                ChampionName = "soraka",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "swainq",
                ChampionName = "swain",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CastRange = 725f,
                Radius = 285f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "swainw",
                ChampionName = "swain",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 5500f,
                Radius = 325f,
                CastDelay = 500f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "swaine",
                ChampionName = "swain",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CastRange = 850f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { EmulationFlags.CrowdControl },
                CastSpeed = 1950
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "swainrsoulflare",
                ChampionName = "swain",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 650f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { EmulationFlags.Ultimate },
                CastSpeed = 4800
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "sylasq",
                ChampionName = "sylas",
                Slot = SpellSlot.Q,
                DisplayName = "Chain Lash",
                CastRange = 50f,
                SecondaryCastRange = 775f,
                Radius = 180f,
                SecondaryRadius = 200f,
                CastDelay = 400f,
                CastType = CastType.Location,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sylasw",
                ChampionName = "sylas",
                Slot = SpellSlot.W,
                DisplayName = "Kingslayer",
                CastRange = 0f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Unit,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sylase",
                ChampionName = "sylas",
                Slot = SpellSlot.E,
                DisplayName = "Abscond",
                CastRange = 400f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Location,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1450,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sylase2",
                ChampionName = "sylas",
                Slot = SpellSlot.E,
                DisplayName = "Abduct",
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 800f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "sylastumble",
                ChampionName = "sylas",
                Slot = SpellSlot.R,
                DisplayName = "Hijack",
                CastRange = 950f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Unit,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2200,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "syndraq",
                ChampionName = "syndra",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "syndraq",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "syndrawcast",
                ChampionName = "syndra",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 950f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "syndrawcast",
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "syndrae",
                ChampionName = "syndra",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 750 + 1000,
                Radius = 250f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "syndrae",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "syndrar",
                ChampionName = "syndra",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 675f,
                CastDelay = 450f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                CastSpeed = 1250
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tahmkenchq",
                ChampionName = "tahmkench",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 950f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 2800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taliyahq",
                ChampionName = "taliyah",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                CastRange = 1000f,
                Radius = 80f,
                CastDelay = 250f,
                FixedRange = true,
                MissileName = "taliyahqmis",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taliyahwvc",
                ChampionName = "taliyah",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 900f,
                Radius = 150f,
                CastDelay = 900f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taliyahe",
                ChampionName = "taliyah",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CastRange = 500f,
                Radius = 165f,
                CastDelay = 250f,
                FixedRange = true,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1650
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "talonq",
                ChampionName = "talon",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 275f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "talonw",
                ChampionName = "talon",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 900f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "talonwmissileone",
                ExtraMissileNames = new[] { "talonwmissiletwo" },
                CastSpeed = 2300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "talone",
                ChampionName = "talon",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "talonr",
                ChampionName = "talon",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CastRange = 750f,
                CastDelay = 260f,
                MissileName = "talonrmisone",
                EmuFlags = new[] { EmulationFlags.Stealth, EmulationFlags.Initiator },
                ExtraMissileNames = new[] { "talonrmistwo" },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taricq",
                ChampionName = "taric",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taricw",
                ChampionName = "taric",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tarice",
                ChampionName = "taric",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 625f,
                CastDelay = 1000f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "taricr",
                ChampionName = "taric",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "blindingdart",
                ChampionName = "teemo",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 580f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "movequick",
                ChampionName = "teemo",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 943
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "toxicshot",
                ChampionName = "teemo",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bantamtrap",
                ChampionName = "teemo",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "threshq",
                ChampionName = "thresh",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1175f,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                MissileName = "threshqmissile",
                CastSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "threshw",
                ChampionName = "thresh",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "threshe",
                ChampionName = "thresh",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 400f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "threshemissile1",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "threshrpenta",
                ChampionName = "thresh",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 420f,
                CastDelay = 300f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 1550
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tristanaq",
                ChampionName = "tristana",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tristanaw",
                ChampionName = "tristana",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                Radius = 270f,
                CastRange = 900f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tristanae",
                ChampionName = "tristana",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                Radius = 210f,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 2400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "tristanar",
                ChampionName = "tristana",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                Radius = 200f,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "trundleq",
                ChampionName = "trundle",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 800f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "trundletrollsmash",
                ChampionName = "trundle",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                Radius = 210f,
                CastRange = 300f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "trundledesecrate",
                ChampionName = "trundle",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "trundlecircle",
                ChampionName = "trundle",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 1000f,
                Radius = 340f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "trundlepain",
                ChampionName = "trundle",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 650f,
                Radius = 300f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bloodlust",
                ChampionName = "tryndamere",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "mockingshout",
                ChampionName = "tryndamere",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 400f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "slashcast",
                ChampionName = "tryndamere",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 660f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "slashcast",
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "undyingrage",
                ChampionName = "tryndamere",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchhideinshadows",
                ChampionName = "twitch",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                CastDelay = 450f,
                EmuFlags = new[] { EmulationFlags.Stealth },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchvenomcask",
                ChampionName = "twitch",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "twitchvenomcaskmissile",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchvenomcaskmissle",
                ChampionName = "twitch",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchexpungewrapper",
                ChampionName = "twitch",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchexpunge",
                ChampionName = "twitch",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "twitchfullautomatic",
                ChampionName = "twitch",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                CastSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "wildcards",
                ChampionName = "twistedfate",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CastRange = 1450f,
                FixedRange = true,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "sealfatemissile",
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "pickacard",
                ChampionName = "twistedfate",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "goldcardpreattack",
                ChampionName = "twistedfate",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "redcardpreattack",
                ChampionName = "twistedfate",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bluecardpreattack",
                ChampionName = "twistedfate",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "cardmasterstack",
                ChampionName = "twistedfate",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "destiny",
                ChampionName = "twistedfate",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "udyrtigerstance",
                ChampionName = "udyr",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "udyrturtlestance",
                ChampionName = "udyr",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "udyrbearstanceattack",
                ChampionName = "udyr",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 250f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "udyrphoenixstance",
                ChampionName = "udyr",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotheatseekinglineqqmissile",
                ChampionName = "urgot",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotheatseekingmissile",
                ChampionName = "urgot",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotterrorcapacitoractive2",
                ChampionName = "urgot",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotplasmagrenade",
                ChampionName = "urgot",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 950f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "urgotplasmagrenadeboom",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotplasmagrenadeboom",
                ChampionName = "urgot",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 950f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "urgotswap2",
                ChampionName = "urgot",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 850f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "varusq",
                ChampionName = "varus",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1250f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "varusqmissile",
                CastSpeed = 1900
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "varusw",
                ChampionName = "varus",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "varuse",
                ChampionName = "varus",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 925f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "varuse",
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "varusr",
                ChampionName = "varus",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1300f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                MissileName = "varusrmissile",
                CastSpeed = 1950
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vaynetumble",
                ChampionName = "vayne",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vaynesilverbolts",
                ChampionName = "vayne",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vaynecondemnmissile",
                ChampionName = "vayne",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 550f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vayneinquisition",
                ChampionName = "vayne",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Stealth, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "veigarbalefulstrike",
                ChampionName = "veigar",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 950f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "veigarbalefulstrikemis",
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "veigardarkmatter",
                ChampionName = "veigar",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 900f,
                CastDelay = 1200f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "veigareventhorizon",
                ChampionName = "veigar",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 650f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "",
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "veigarprimordialburst",
                ChampionName = "veigar",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 850f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "velkozq",
                ChampionName = "velkoz",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1250f,
                CastDelay = 100f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "velkozqmissile",
                CastSpeed = 1300
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "velkozqsplitactivate",
                ChampionName = "velkoz",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                IsPerpindicular = true,
                CastRange = 1050f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                MissileName = "velkozqmissilesplit",
                CastSpeed = 2100
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "velkozw",
                ChampionName = "velkoz",
                Slot = SpellSlot.W,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1050f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "velkozwmissile",
                CastSpeed = 1700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "velkoze",
                ChampionName = "velkoz",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 950f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "velkozemissile",
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "velkozr",
                ChampionName = "velkoz",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 1575f,
                CastDelay = 0f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 1500
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "vexq",
                ChampionName = "vex",
                Slot = SpellSlot.Q,
                DisplayName = "Mistral Bolt",
                CastRange = 1200f,
                Radius = 360f,
                SecondaryRadius = 160f,
                CastDelay = 150f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                ExtraCastSpeeds = new[] { 600, 3200 },
                CastSpeed = 600,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vexw",
                ChampionName = "vex",
                Slot = SpellSlot.W,
                DisplayName = "Personal Space",
                CastRange = 0f,
                Radius = 475f,
                SecondaryRadius = 550f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vexe",
                ChampionName = "vex",
                Slot = SpellSlot.E,
                DisplayName = "Looming Darkness",
                CastRange = 800f,
                Radius = 200f,
                SecondaryRadius = 300f,
                CastDelay = 250f,
                CastType = CastType.Location,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1300,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vexr",
                ChampionName = "vex",
                Slot = SpellSlot.R,
                DisplayName = "Shadow Surge",
                CastRange = 2000f,
                SecondaryCastRange = 3000f,
                Radius = 260f,
                SecondaryRadius = 650, // missile sight radius
                CastDelay = 250f,
                CastType = CastType.DirectionAuto,
                EmuFlags = new EmulationFlags[] { },
                ExtraCastSpeeds = new[] { 1600, 2200 },
                CastSpeed = 1600,
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "viqmissile",
                ChampionName = "vi",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viw",
                ChampionName = "vi",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vie",
                ChampionName = "vi",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vir",
                ChampionName = "vi",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl, EmulationFlags.Initiator },
                CastSpeed = 1400
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "viegoq",
                ChampionName = "viego",
                Slot = SpellSlot.Q,
                DisplayName = "Blade of the Ruined King",
                CastRange = 600f,
                Radius = 125f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viegow",
                ChampionName = "viego",
                Slot = SpellSlot.W,
                DisplayName = "Spectral Maw",
                CastRange = 300f,
                SecondaryCastRange = 900f,
                Radius = 120f,
                CastDelay = 250f,
                CastType = CastType.DirectionAuto,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                ExtraCastSpeeds = new[] { 1000, 1300 },
                CastSpeed = 1000,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viegoe",
                ChampionName = "viego",
                Slot = SpellSlot.E,
                DisplayName = "Harrowed Path",
                CastRange = 775f,
                Radius = 500f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                ExtraCastSpeeds = new[] { 1600, 1200 },
                CastSpeed = 1600,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viegor",
                ChampionName = "viego",
                Slot = SpellSlot.R,
                DisplayName = "Heartbreaker",
                CastRange = 500f,
                Radius = 300f,
                CastDelay = 500f,
                CastType = CastType.Location,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "viktorpowertransfer",
                ChampionName = "viktor",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1050
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viktorgravitonfield",
                ChampionName = "viktor",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 815f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viktordeathray",
                ChampionName = "viktor",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                MissileName = "viktordeathraymis",
                ExtraMissileNames = new[] { "viktoreaugmissile" },
                CastSpeed = 1210
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "viktorchaosstorm",
                ChampionName = "viktor",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 710f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.CrowdControl, EmulationFlags.Ultimate,
                        EmulationFlags.Danger, EmulationFlags.Initiator
                    },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vladimirq",
                ChampionName = "vladimir",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vladimirw",
                ChampionName = "vladimir",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vladimire",
                ChampionName = "vladimir",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 610f,
                CastDelay = 800f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "vladimirr",
                ChampionName = "vladimir",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 875f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "volibearq",
                ChampionName = "volibear",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Initiator, EmulationFlags.CrowdControl },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "volibearw",
                ChampionName = "volibear",
                Slot = SpellSlot.W,
                CastType = CastType.Unit,
                CastRange = 400f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 1450
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "volibeare",
                ChampionName = "volibear",
                CastType = CastType.Proximity,
                Slot = SpellSlot.E,
                CastRange = 425f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 825
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "volibearr",
                ChampionName = "volibear",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 825
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hungeringstrike",
                ChampionName = "warwick",
                Slot = SpellSlot.Q,
                CastType = CastType.Unit,
                CastRange = 400f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "hunterscall",
                ChampionName = "warwick",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "bloodscent",
                ChampionName = "warwick",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 0f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "infiniteduress",
                ChampionName = "warwick",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "infiniteduresschannel",
                ChampionName = "warwick",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 700f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xayahq",
                ChampionName = "xayah",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1100f,
                CastDelay = 500f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "xayahqmissile1",
                CastSpeed = 2060
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xayahw",
                ChampionName = "xayah",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xayahe",
                ChampionName = "xayah",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CastRange = 2000f,
                Radius = 80,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "xayahemissilesfx",
                CastSpeed = 4800,
                NoProcess = true
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xayahr",
                ChampionName = "xayah",
                Slot = SpellSlot.R,
                CastType = CastType.Direction,
                CastRange = 1100f,
                Radius = 25,
                CastDelay = 500f,
                EmuFlags = new[] { EmulationFlags.Initiator },
                MissileName = "xayahrmissile",
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xeratharcanopulsechargeup",
                ChampionName = "xerath",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 750f,
                CastDelay = 750f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xeratharcanebarrage2",
                ChampionName = "xerath",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 1100f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "xeratharcanebarrage2",
                CastSpeed = 20
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xerathmagespear",
                ChampionName = "xerath",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyMinions, CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 1050f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger },
                MissileName = "xerathmagespearmissile",
                CastSpeed = 1600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xerathlocusofpower2",
                ChampionName = "xerath",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 5600f,
                CastDelay = 750f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaocombotarget",
                ChampionName = "xinzhao",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 375,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaothrust",
                ChampionName = "xinzhao",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 625f,
                Radius = 225f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaothrust2",
                ChampionName = "xinzhao",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 625f,
                Radius = 225f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaothrust3",
                ChampionName = "xinzhao",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 625f,
                Radius = 225f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaobattlecry",
                ChampionName = "xinzhao",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 0f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaosweep",
                ChampionName = "xinzhao",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 600f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl, EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 2400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "xenzhaoparry",
                ChampionName = "xinzhao",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 500f,
                Radius = 210f,
                CastDelay = 250f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl
                    },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuoqw",
                ChampionName = "yasuo",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 475f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuoq2w",
                ChampionName = "yasuo",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                FixedRange = true,
                CastRange = 475f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuoq3",
                ChampionName = "yasuo",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1000f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "yasuoq3mis",
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuowmovingwall",
                ChampionName = "yasuo",
                CastType = CastType.Location,
                Slot = SpellSlot.W,
                IsPerpindicular = true,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuodashwrapper",
                ChampionName = "yasuo",
                Slot = SpellSlot.E,
                CastType = CastType.Unit,
                CastRange = 475f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 20
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yasuorknockupcombow",
                ChampionName = "yasuo",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 1200f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yorickq",
                ChampionName = "yorick",
                Slot = SpellSlot.Q,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                BasicAttackAmplifier = true,
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yorickw",
                ChampionName = "yorick",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yoricke",
                ChampionName = "yorick",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 700f,
                Radius = 125f,
                CastDelay = 250f,
                MissileName = "yorickemissile",
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yorickr",
                ChampionName = "yorick",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1500
            });
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "yummiq",
                ChampionName = "yuumi",
                Slot = SpellSlot.Q,
                DisplayName = "Prowling Projectile",
                CastRange = 1150f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1000,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yummiw",
                ChampionName = "yuumi",
                Slot = SpellSlot.W,
                DisplayName = "You and Me!",
                CastRange = 700f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.UnitDirection,
                EmuFlags = new EmulationFlags[] { },
                ExtraCastSpeeds = new[] { 1200, 1300, 1400, 1500, 1600 },
                CastSpeed = 1200,
            });

            HeroSpells.Add(new SpellData
            {               
                SpellName = "yummie",
                ChampionName = "yuumi",
                Slot = SpellSlot.E,
                DisplayName = "Zoomies",
                CastRange = 0f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {                
                SpellName = "yummir",
                ChampionName = "yuumi",
                Slot = SpellSlot.R,
                DisplayName = "Final Chapter",
                CastRange = 1100f,
                Radius = 450f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 3000,
            });
            
            #region Yone
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "yoneq",
                ChampionName = "yone",
                Slot = SpellSlot.Q,
                DisplayName = "Mortal Steel",
                CastRange = 450f,
                Radius = 160f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1500,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yonew",
                ChampionName = "yone",
                Slot = SpellSlot.W,
                DisplayName = "Spirit Cleave",
                CastRange = 0f,
                Radius = 600f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yonee",
                ChampionName = "yone",
                Slot = SpellSlot.E,
                DisplayName = "Soul Unbound",
                CastRange = 0f,
                Radius = float.MaxValue,
                Global = true,
                CastDelay = 250f,
                CastType = CastType.DirectionAuto,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1200,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "yoner",
                ChampionName = "yone",
                Slot = SpellSlot.R,
                DisplayName = "Fate Sealed",
                CastRange = 1000f,
                Radius = 225f,
                CastDelay = 750f,
                CastType = CastType.Direction,
                EmuFlags = new[] { EmulationFlags.Ultimate },
                CastSpeed = 4800,
            });
            
            #endregion
            
            #region Zac
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "zacq",
                ChampionName = "zac",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                FixedRange = true,
                CastRange = 800f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "zaqmissile",
                CastSpeed = 2600
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zacw",
                ChampionName = "zac",
                Slot = SpellSlot.W,
                CastType = CastType.Proximity,
                CastRange = 350f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zace",
                ChampionName = "zac",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 300f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl },
                CastSpeed = 1500
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zacr",
                ChampionName = "zac",
                Slot = SpellSlot.R,
                CastType = CastType.Proximity,
                CastRange = 600f,
                Radius = 300f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.CrowdControl, EmulationFlags.Ultimate },
                CastSpeed = 1800
            });
            
            #endregion

            #region Zed
            
            HeroSpells.Add(new SpellData
            {
                SpellName = "zedq",
                ChampionName = "zed",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 900f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "zedqmissile",
                FromObject = new[] { "Zed_Base_W_tar.troy", "Zed_Base_W_cloneswap_buf.troy" },
                ExtraMissileNames = new[] { "zedqmissiletwo", "zedqmissilethree" },
                CastSpeed = 1700
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zedw",
                ChampionName = "zed",
                Slot = SpellSlot.W,
                DisplayName = "Living Shadow",
                CastRange = 650f,
                Radius = 1950f,
                CastDelay = 250f,
                CastType = CastType.LocationProximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2500,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zede",
                ChampionName = "zed",
                Slot = SpellSlot.E,
                CastType = CastType.Proximity,
                CastRange = 300f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zedr",
                ChampionName = "zed",
                Slot = SpellSlot.R,
                CastType = CastType.Unit,
                CastRange = 850f,
                CastDelay = 450f,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Initiator },
                CastSpeed = 4800
            });

            #endregion
            
            #region Zerri
 
            HeroSpells.Add(new SpellData
            {
                SpellName = "zeriq",
                ChampionName = "zeri",
                Slot = SpellSlot.Q,
                DisplayName = "Burst Fire",
                CastRange = 825f,
                Radius = 80f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                ExtraCastSpeeds = new[] { 2600, 3400 },
                CastSpeed = 2600,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zeriw",
                ChampionName = "zeri",
                Slot = SpellSlot.W,
                DisplayName = "Ultrashock Laser",
                CastRange = 1200f,
                Radius = 80f,
                SecondaryRadius = 200f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2200,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zerie",
                ChampionName = "zeri",
                Slot = SpellSlot.E,
                DisplayName = "Spark Surge",
                CastRange = 300f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Direction,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 600,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zerir",
                ChampionName = "zeri",
                Slot = SpellSlot.R,
                DisplayName = "Lightning Crash",
                CastRange = 0f,
                Radius = 825f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });
            
            #endregion

            #region Ziggs
            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggsq",
                ChampionName = "ziggs",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CollidesWith = new[] { CollisionObjectType.EnemyHeroes },
                CastRange = 850f,
                Radius = 100f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "ziggsqspell",
                ExtraMissileNames = new[] { "ziggsqspell2", "ziggsqspell3" },
                CastSpeed = 1750
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggsw",
                ChampionName = "ziggs",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                DisplayName = "Satchel Charge",
                CastRange = 1000f,
                Radius = 325f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1750,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggswtoggle",
                ChampionName = "ziggs",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                DisplayName = "Satchel Charge",
                CastRange = 1000f,
                Radius = 325f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1750,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggse",
                ChampionName = "ziggs",
                Slot = SpellSlot.E,
                DisplayName = "Hexplosive Minefield",
                CastRange = 900f,
                Radius = 325f,
                CastDelay = 250f,
                CastType = CastType.Location,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1550,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggse2",
                ChampionName = "ziggs",
                Slot = SpellSlot.E,
                DisplayName = "Hexplosive Minefield",
                CastRange = 900f,
                Radius = 325f,
                CastDelay = 250f,
                CastType = CastType.Location,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                CastSpeed = 1550,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "ziggsr",
                ChampionName = "ziggs",
                Slot = SpellSlot.R,
                DisplayName = "Mega Inferno Bomb",
                CastRange = 5000f,
                Radius = 525f,
                CastDelay = 375f,
                CastType = CastType.Location,
                EmuFlags = new[] { EmulationFlags.Danger, EmulationFlags.Ultimate },
                CastSpeed = 2250
            });

            #endregion
            
            #region Zilean
            HeroSpells.Add(new SpellData
            {
                SpellName = "zileanq",
                ChampionName = "zilean",
                Slot = SpellSlot.Q,
                CastType = CastType.Location,
                CastRange = 900f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "zileanqmissile",
                CastSpeed = 2000
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zileanw",
                ChampionName = "zilean",
                Slot = SpellSlot.W,
                DisplayName = "Rewind",
                CastRange = 0f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Proximity,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zileane",
                ChampionName = "zilean",
                Slot = SpellSlot.E,
                DisplayName = "Time Warp",
                CastRange = 550f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Unit,
                EmuFlags = new EmulationFlags[] { EmulationFlags.CrowdControl },
                CastSpeed = 4800
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zileanr",
                ChampionName = "zilean",
                Slot = SpellSlot.R,
                DisplayName = "Chronoshift",
                CastRange = 900f,
                Radius = 0f,
                CastDelay = 250f,
                CastType = CastType.Unit,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 4800,
            });

            #endregion
            
            #region Zoe
            HeroSpells.Add(new SpellData
            {
                SpellName = "zoeq",
                ChampionName = "zoe",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CastRange = 825f,
                CastDelay = 250f,
                Radius = 50,
                MissileName = "zoeqmissile",
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 1200
            });


            HeroSpells.Add(new SpellData
            {
                SpellName = "zoeqrecast",
                ChampionName = "zoe",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CastRange = 2000f,
                CastDelay = 250f,
                FixedRange = false,
                Radius = 60,
                MissileName = "zoeqmis2warning",
                EmuFlags = new EmulationFlags[] { EmulationFlags.Danger, },
                CastSpeed = 2400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zoee",
                ChampionName = "zoe",
                Slot = SpellSlot.E,
                CastType = CastType.Location,
                CastRange = 830f,
                CastDelay = 250f,
                FixedRange = true,
                Radius = 60,
                MissileName = "zoee",
                ExtraMissileNames = new [] {"zoeemisaudio"},
                EmuFlags = new EmulationFlags[] { EmulationFlags.Danger, EmulationFlags.CrowdControl,  },
                CastSpeed = 1800
            });

            #endregion 
            
            #region Zyra
            HeroSpells.Add(new SpellData
            {
                SpellName = "zyraq",
                ChampionName = "zyra",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                CastRange = 800f,
                Radius = 430f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "zyraqmissile",
                CastSpeed = 1400
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zyraqplantmissile",
                ChampionName = "zyra",
                Slot = SpellSlot.Q,
                CastType = CastType.Direction,
                IsPerpindicular = true,
                CastRange = 675f,
                Radius = 710f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                MissileName = "zyraqplantmissile",
                CastSpeed = 1200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zyraw",
                ChampionName = "zyra",
                Slot = SpellSlot.W,
                CastType = CastType.Location,
                CastRange = 0f,
                CastDelay = 250f,
                EmuFlags = new EmulationFlags[] { },
                CastSpeed = 2200
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zyrae",
                ChampionName = "zyra",
                Slot = SpellSlot.E,
                CastType = CastType.Direction,
                FixedRange = true,
                CastRange = 1150f,
                Radius = 70f,
                CastDelay = 250f,
                EmuFlags = new[] { EmulationFlags.CrowdControl },
                MissileName = "zyraemissile",
                CastSpeed = 1150
            });

            HeroSpells.Add(new SpellData
            {
                SpellName = "zyrar",
                ChampionName = "zyra",
                Slot = SpellSlot.R,
                CastType = CastType.Location,
                CastRange = 700f,
                Radius = 500f,
                CastDelay = 500f,
                EmuFlags =
                    new[]
                    {
                        EmulationFlags.Danger, EmulationFlags.Ultimate,
                        EmulationFlags.CrowdControl, EmulationFlags.Initiator
                    },
                CastSpeed = 4800
            });
            
            #endregion 
        }
    }
}