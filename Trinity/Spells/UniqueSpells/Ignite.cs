namespace Trinity.Spells.UniqueSpells
{
    #region
    
    using Helpers;
    
    using Oasys.Common;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.Menu.ItemComponents;
    
    using Oasys.SDK;
    using Oasys.SDK.Rendering;
    
    using System.Linq;
    using System.Windows.Forms;
    using Oasys.SDK.Tools;
    using SharpDX;

    #endregion

    internal class Ignite : AutoSpell
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Ignite" /> class.
        /// </summary>
        /// <param name="usePct">The use PCT.</param>
        /// <param name="championName">Name of the champion.</param>
        /// <param name="spellName">Name of the spell.</param>
        /// <param name="tType">Type of the t.</param>
        /// <param name="range">The range.</param>
        /// <param name="aType">a type.</param>
        public Ignite(int usePct, string championName, string spellName, TargetingType tType, float range, ActivationType[] aType)
            : base(usePct, championName, spellName, tType, range, aType)
        {
        }

        #endregion

        #region Override Methods

        /// <summary>
        ///     Creates the tab.
        /// </summary>
        public override void CreateTab()
        {
            this.CreateSpellTabEnableSwitch(Keys.N);
            var tabName = ChampionName;

            SpellGroupTab.AddItem(SpellSwitch["igcombo"] = new Switch
            {
                IsOn = true,
                Title = "Ignite on Combo"
            });

            SpellGroupTab.AddItem(SpellCounter["igminhp"] = new Counter
            {
                Title = "Ignite Min Target HP (%)",
                MaxValue = 100,
                MinValue = 5,
                Value = 25,
                ValueFrequency = 5
            });

            SpellGroupTab.AddItem(SpellCounter["igmaxhp"] = new Counter
            {
                Title = "Ignite Max Target HP (%)",
                MaxValue = 100,
                MinValue = 5,
                Value = 70,
                ValueFrequency = 5
            });

            SpellGroupTab.AddItem(SpellSwitch["igks"] = new Switch
            {
                IsOn = false,
                Title = "Ignite on KS"
            });
            
            SpellGroupTab.AddItem(
                SpellSwitch[tabName + "draw"] = new Switch
                {
                    IsOn = true,
                    Title = "Ignite Drawings"
                });
            
            SpellTab.AddItem(SpellGroupTab);
        }
        
        /// <summary>
        ///     Called when [on render].
        /// </summary>
        public override void OnRender()
        {
            //this.CorrectSpellClass();
            var tabName = ChampionName;

            if (!SpellSwitch[tabName + "draw"].IsOn) return;

            var circ = SpellClass.IsSpellReady
                ? new ColorBGRA(255, 102, 51, 100)
                : new ColorBGRA(115, 115, 115, 75);

            var key = "(" + SpellKeybind[tabName].SelectedKey + ")";
            var text = SpellSwitch[tabName].IsOn ? key + " Ignite: ON" : key + " Ignite: OFF";

            var myPos = UnitManager.MyChampion.Position;
            var myPosToScreen = LeagueNativeRendererManager.WorldToScreen(UnitManager.MyChampion.Position);

            RenderFactory.DrawNativeCircle(myPos, Range, circ, 3);
            RenderFactory.DrawText(text, 20, new Vector2(myPosToScreen.X, myPosToScreen.Y + 20), circ);
        }

        /// <summary>
        ///     Called when [OnTick].
        /// </summary>
        public override void OnTick()
        {
            if (!SpellClass.IsSpellReady) return;

            if (SpellSwitch["igcombo"].IsOn)
                if (TargetSelector.GetBestChampionTarget() is AIHeroClient target && target.IsValidTarget(Range))
                {
                    var hpPct = target.HealthPercent;
                    if (hpPct > SpellCounter["igminhp"].Value &&
                        hpPct < SpellCounter["igmaxhp"].Value)
                        this.UseSpell(target);
                }

            if (SpellSwitch["igks"].IsOn)
                foreach (var unit in Bootstrap.Enemies.Select(x => x.Value))
                {
                    var igniteDmg = (float) 50 + 20 * ObjectManagerExport.LocalPlayer.Level;
                    if (igniteDmg > unit.Instance.Health) this.UseSpell(unit.Instance);
                }
        }

        #endregion
    }
}