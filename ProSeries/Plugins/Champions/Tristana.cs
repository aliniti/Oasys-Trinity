namespace ProSeries.Plugins.Champions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Oasys.Common.Menu;
    using Oasys.Common.Menu.ItemComponents;

    internal class Tristana : Plugin
    {
        public override string PluginName => "Tristana";

        public override void OnLoadPlugin()
        {
            var Tabs = new Dictionary<string, TabItem>
            {
                ["useQ"] = new Switch {IsOn = true, Title = "Enable (Q)"},
                ["useW"] = new Switch {IsOn = true, Title = "Enable (W)"},
                ["useE"] = new Switch {IsOn = true, Title = "Enable (E)"},
                ["useR"] = new Switch {IsOn = true, Title = "Enable Ultimate (R)"}
            };

            foreach (var tab in Tabs.Select(t => t.Value)) PluginTab?.AddItem(tab);
        }

        public override async Task OnUpdate()
        {
        }
    }
}