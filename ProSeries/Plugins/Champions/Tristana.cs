using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oasys.Common.EventsProvider;
using Oasys.Common.GameObject.Clients;
using Oasys.Common.Menu;
using Oasys.Common.Menu.ItemComponents;
using Oasys.SDK;
using Oasys.SDK.Tools;


namespace ProSeries.Plugins.Champions
{

    class Tristana : Plugin
    {
        public override string PluginName => "Tristana";

        public override void OnLoadPlugin()
        {
            var Tabs = new Dictionary<string, TabItem>
            {
                ["useQ"] = new Switch { IsOn = true, Title = "Enable (Q)"},
                ["useW"] = new Switch { IsOn = false, Title = "Enable (W)" },
                ["useE"] = new Switch { IsOn = true, Title = "Enable (E)" },
                ["useR"] = new Switch { IsOn = true, Title = "Enable Ultimate (R)" }
            };

            foreach (var tab in Tabs.Select(t => t.Value))
            {
                PluginTab?.AddItem(tab);
            }
        }

        public override async Task OnUpdate()
        {

        }
    }
}
