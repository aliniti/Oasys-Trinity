using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Oasys.Common.EventsProvider;
using Oasys.Common.GameObject.Clients;
using Oasys.Common.Menu;
using Oasys.SDK;
using Oasys.SDK.Menu;
using Oasys.SDK.Tools;
using ProSeries.Helpers;

namespace ProSeries.Plugins
{
    public class Plugin
    {
        private readonly Dictionary<string, bool> pDict = new();

        private int pNow;
        private Enums.PluginType pType;

        public Dictionary<string, Spell> Spells = new();
        public virtual string PluginName { get; set; }

        public Tab MainTab { get; set; }
        public Tab PluginTab { get; set; }
        public AIHeroClient Me => UnitManager.MyChampion;

        public Plugin Init(Tab pluginTab, Tab rootTab)
        {
            try
            {
                if (Me.ModelName?.ToLower() == PluginName?.ToLower())
                {
                    MainTab = rootTab;
                    PluginTab = new Tab("ProSeries: " + PluginName);
                    pType = Enums.PluginType.Hero;

                    OnLoadPlugin();
                    MenuManager.AddTab(PluginTab);
                    MenuManager.AddTab(rootTab);

                    // check if plugin has been initialized
                    if (!pDict.ContainsKey("Init"))
                    {
                        Logger.Log("ProSeries: Initialized Plugin!", LogSeverity.Warning);
                        CoreEvents.OnCoreMainTick += OnUpdate;
                        pDict["Init"] = true;
                    }
                }
                else
                {
                    Logger.Log("ProSeries: No Plugins Found!", LogSeverity.Danger);
                }

                return this;
            }
            catch (Exception e)
            {
                Logger.Log(e, LogSeverity.Danger);
                throw;
            }
        }


        #region Virtual Voids

        public virtual void OnLoadPlugin()
        {
        }

        public virtual async Task OnUpdate()
        {
        }

        #endregion
    }
}