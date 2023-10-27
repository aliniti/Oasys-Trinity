namespace Trinity.Spells.UniqueSpells
{
    #region

    using Helpers;
    
    using Oasys.Common;
    using Oasys.Common.Extensions;
    using Oasys.Common.Menu.ItemComponents;
    using Oasys.SDK;
    using Oasys.SDK.Rendering;
    using SharpDX;
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    #endregion

    internal class Smite : AutoSpell
    {
        #region Structs

        public struct Offset
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="Offset" /> struct.
            /// </summary>
            /// <param name="vec">The vec.</param>
            /// <param name="width">The width.</param>
            /// <param name="height">The height.</param>
            public Offset(Vector2 vec, int width, int height)
            {
                XValue = vec.X;
                YValue = vec.Y;
                Width = width;
                Height = height;
            }

            /// <summary>
            ///     Gets the x value.
            /// </summary>
            /// <value>
            ///     The x value.
            /// </value>
            public float XValue { get; set; }

            /// <summary>
            ///     Gets the y value.
            /// </summary>
            /// <value>
            ///     The y value.
            /// </value>
            public float YValue { get; set; }

            /// <summary>
            ///     Gets the width.
            /// </summary>
            /// <value>
            ///     The width.
            /// </value>
            public int Width { get; set; }

            /// <summary>
            ///     Gets the height.
            /// </summary>
            /// <value>
            ///     The height.
            /// </value>
            public int Height { get; set; }
        }

        #endregion

        #region Static Fields and Constants

        /// <summary>
        ///     The jungle monster drawing offsets
        /// </summary>
        public static readonly Dictionary<string, Offset> Offsets = new()
        {
            { "CampRespawn", new Offset(new Vector2(0, 0), 0, 0) },
            { "SRU_Blue1.1.1", new Offset(new Vector2(-42, -20), 150, 9) },
            { "SRU_Red4.1.1", new Offset(new Vector2(-42, -20), 150, 9) },
            { "SRU_Blue7.1.1", new Offset(new Vector2(-42, -20), 150, 9) },
            { "SRU_Red10.1.1", new Offset(new Vector2(-42, -20), 150, 9) },
            { "Sru_Crab15.1.1", new Offset(new Vector2(-47, -23), 150, 12) },
            { "Sru_Crab16.1.1", new Offset(new Vector2(-47, -23), 150, 12) },
            { "SRU_RiftHerald17.1.1", new Offset(new Vector2(-41, -20), 155, 9) },
            { "SRU_Baron12.1.1", new Offset(new Vector2(-24, -28), 165, 13) },
            { "SRU_BaronSpawn12.1.2", new Offset(new Vector2(-24, -28), 165, 13) },
            { "SRU_Krug5.1.1", new Offset(new Vector2(-45, -21), 150, 10) },
            { "SRU_Krug11.1.1", new Offset(new Vector2(-45, -21), 150, 10) },
            { "SRU_Razorbeak3.1.1", new Offset(new Vector2(-45, -21), 150, 10) },
            { "SRU_Razorbeak9.1.1", new Offset(new Vector2(-45, -21), 150, 10) },
            { "SRU_Murkwolf8.1.1", new Offset(new Vector2(-45, -21), 150, 10) },
            { "SRU_Murkwolf2.1.1", new Offset(new Vector2(-45, -21), 150, 10) },
            { "SRU_Gromp13.1.1", new Offset(new Vector2(-43, -21), 150, 10) },
            { "SRU_Gromp14.1.1", new Offset(new Vector2(-43, -21), 150, 10) },
            { "SRU_Blue2.1.1", new Offset(new Vector2(-42, -20), 150, 9) },
            { "SRU_Krug6.1.1", new Offset(new Vector2(-45, -21), 150, 10) },
            { "SRU_Murkwolf7.1.1", new Offset(new Vector2(-45, -21), 150, 10) },
            { "SRU_Red11.1.1", new Offset(new Vector2(-42, -20), 150, 9) },
            { "SRU_Razorbeak10.1.1", new Offset(new Vector2(-45, -21), 150, 10) },
            { "SRU_Gromp3.1.1", new Offset(new Vector2(-43, -21), 150, 10) },
            { "SRU_Gromp4.1.1", new Offset(new Vector2(-43, -21), 150, 10) },
            { "SLIME_Crab13.1.1", new Offset(new Vector2(-47, -23), 150, 12) },
            { "SRU_RiftHerald12.1.1", new Offset(new Vector2(-41, -20), 155, 9) },
        };

        /// <summary>
        ///     The small minions
        /// </summary>
        public static readonly string[] SmallMinions =
        {
            "SRU_Murkwolf",
            "SRU_Razorbeak",
            "SRU_Krug",
            "SRU_Gromp"
        };

        /// <summary>
        ///     The large minions
        /// </summary>
        public static readonly string[] LargeMinions =
        {
            "SRU_Blue",
            "SRU_Red",
            "Sru_Crab",
            "SLIME_Crab"
        };

        /// <summary>
        ///     The epic minions
        /// </summary>
        public static readonly string[] EpicMinions =
        {
            "SRU_RiftHerald",
            "SRU_Baron",
            "SRU_Dragon"
        };

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Smite" /> class.
        /// </summary>
        /// <param name="usePct">The use pct.</param>
        /// <param name="championName">Name of the champion.</param>
        /// <param name="spellName">Name of the spell.</param>
        /// <param name="tType">The targeting type.</param>
        /// <param name="range">The range.</param>
        /// <param name="aType">The activation type.</param>
        public Smite(int usePct, string championName, string spellName, TargetingType tType, float range, ActivationType[] aType) : base(usePct, championName,
            spellName, tType, range, aType)
        {
        }

        #endregion

        #region Override Methods

        /// <summary>
        ///     Creates the smite tab.
        /// </summary>
        public override void CreateTab()
        {
            this.CreateSpellTabEnableSwitch(Keys.M);
            var tabName = ChampionName;
            
            SpellGroupTab.AddItem(
                SpellSwitch[tabName + "greed"] = new Switch
                {
                    IsOn = true,
                    Title = "Smite Greed"
                });

            SpellGroupTab.AddItem(
                SpellSwitch[tabName + "smt1"] = new Switch
                {
                    IsOn = true,
                    Title = "Smite Small Minions"
                });

            SpellGroupTab.AddItem(
                SpellSwitch[tabName + "smt2"] = new Switch
                {
                    IsOn = true,
                    Title = "Smite Large Minions"
                });

            SpellGroupTab.AddItem(
                SpellSwitch[tabName + "smt3"] = new Switch
                {
                    IsOn = true,
                    Title = "Smite Epic Minions"
                });

            SpellGroupTab.AddItem(
                SpellSwitch[tabName + "draw"] = new Switch
                {
                    IsOn = true,
                    Title = "Smite Drawings"
                });
        }

        /// <summary>
        ///     Called when [on render].
        /// </summary>
        public override void OnRender()
        {
            this.CorrectSpellClass();
            var tabName = ChampionName;
            var spellName = SpellClass.SpellData.SpellName;
        
            if (!SpellSwitch[tabName + "draw"].IsOn) return;
        
            var circ = SpellClass.IsSpellReady
                ? new ColorBGRA(240, 232, 163, 100)
                : new ColorBGRA(115, 115, 115, 75);
        
            var key = "(" + SpellKeybind[tabName].SelectedKey + ")";
            var text = SpellSwitch[tabName].IsOn ? key + " Smite: ON" : key + " Smite : OFF";
        
            var myPos = UnitManager.MyChampion.Position;
            var myPosToScreen = LeagueNativeRendererManager.WorldToScreen(UnitManager.MyChampion.Position);
        
            RenderFactory.DrawNativeCircle(myPos, Range, circ, 3);
            RenderFactory.DrawText(text, 20, new Vector2(myPosToScreen.X, myPosToScreen.Y + 40), circ);
        
            var damage = 600;

            if (spellName.Contains("SmitePlayerGanker"))
                damage = 900;

            if (spellName.Contains("SmiteAvatar"))
                damage = 1200;
        
            foreach (var minion in ObjectManagerExport.JungleObjectCollection.Select(x => x.Value))
                if (minion.IsValidTarget(1000) && minion.Position.IsOnScreen())
                {
                    if (minion.Name.Contains("Mini")) continue;
                    if (minion.Name.Contains("Camp")) continue;
                    if (minion.Name.Contains("Dragon")) continue;
                    if (minion.Name.Contains("Plant")) continue;
                    
                    try
                    {
                        var height = Offsets[minion.Name].Height;
                        var width = Offsets[minion.Name].Width;
                        var yoffset = Offsets[minion.Name].YValue;
                        var xoffset = Offsets[minion.Name].XValue;
        
                        var barpos = minion.HealthBarScreenPosition;
                        var pctafter = Math.Max(0, minion.Health - damage) / minion.MaxHealth;
        
                        var yaxis = barpos.Y + yoffset;
                        var xaxisnow = barpos.X + xoffset + width * pctafter;
                        var xaxisfull = barpos.X + xoffset + width * (minion.Health / minion.MaxHealth);
                        var range = xaxisfull - xaxisnow;
                        var pos = barpos.X + xoffset + 12 + 138 * pctafter;
        
                        for (var i = 0; i < range; i++)
                            RenderFactory.DrawLine(pos + i, yaxis, pos + i, yaxis + height, 1, circ);
                    }
                    catch (Exception e)
                    {
                        // ignored
                    }
                }
        }

        /// <summary>
        ///     Called when [on tick].
        /// </summary>
        public override void OnTick()
        {
            this.CorrectSpellClass();
            var tabName = ChampionName;
            var spellName = SpellClass.SpellData.SpellName;

            if (!SpellClass.IsSpellReady) return;
            if (!SpellSwitch[tabName].IsOn) return;

            var damage = 600;

            if (spellName.Contains("SmitePlayerGanker"))
                damage = 900;

            if (spellName.Contains("SmiteAvatar"))
                damage = 1200;

            foreach (var minion in ObjectManagerExport.JungleObjectCollection.Select(x => x.Value))
            {
                var minionRadius = minion.UnitComponentInfo.UnitBoundingRadius;
                var myHeroRadius = ObjectManagerExport.LocalPlayer.UnitComponentInfo.UnitBoundingRadius;
                
                if (minion.IsValidTarget(Range + minionRadius + myHeroRadius) && !minion.Name.Contains("Mini"))
                    if (damage >= minion.Health)
                    {
                        if (EpicMinions.Any(x => minion.Name.Contains(x)) && SpellSwitch[tabName + "smt3"].IsOn)
                            this.UseSpell(minion);

                        if (SmallMinions.Any(x => minion.Name.Contains(x)) && SpellSwitch[tabName + "smt1"].IsOn)
                            this.UseSpell(minion);

                        if (minion.GetRadiusClusterCount(UnitManager.AllyChampions, Range) <= 1 || SpellSwitch[tabName + "greed"].IsOn)
                            if (LargeMinions.Any(x => minion.Name.Contains(x)) && SpellSwitch[tabName + "smt2"].IsOn)
                                this.UseSpell(minion);
                    }
            }
        }

        #endregion
    }
}