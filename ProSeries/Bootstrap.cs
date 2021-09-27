namespace ProSeries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Threading.Tasks;
    using Oasys.Common.EventsProvider;
    using Oasys.Common.Menu;
    using Oasys.SDK;
    using Oasys.SDK.Tools;
    using Plugins;

    public class Bootstrap
    {
        private static Tab _rootTab;
        private static readonly List<Plugin> _loadedPlugins = new();

        [OasysModuleEntryPoint]
        public static void Execute()
        {
            GameEvents.OnGameLoadComplete += OnLoad;
        }

        private static async Task OnLoad()
        {
            _rootTab = new Tab("ProSeries: Settings");
            GetTypesByGroup("Plugins.Champions").ForEach(x => { NewPlugin((Plugin) NewInstance(x), _rootTab); });
        }

        private static List<Type> GetTypesByGroup(string nspace)
        {
            try
            {
                Type[] allowedTypes = {typeof(Plugin)};
                Logger.Log("ProSeries: Fetching plugins....", LogSeverity.Warning);

                return
                    Assembly.GetExecutingAssembly()
                        .GetTypes()
                        .Where(
                            t =>
                                t.IsClass && t.Namespace == "ProSeries." + nspace &&
                                allowedTypes.Any(x => x.IsAssignableFrom(t)))
                        .ToList();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Log("Exception thrown at ProSeries.GetTypesByGroup", LogSeverity.Danger);
                return null;
            }
        }

        private static void NewPlugin(Plugin plugin, Tab parent)
        {
            try
            {
                if (_loadedPlugins.Contains(plugin) == false)
                    _loadedPlugins.Add(plugin.Init(parent, _rootTab));
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Log("Exception thrown at ProSeries.NewPlugin", LogSeverity.Danger);
                throw;
            }
        }

        private static object NewInstance(Type type)
        {
            try
            {
                var target = type.GetConstructor(Type.EmptyTypes);
                var dynamic = new DynamicMethod(string.Empty, type, new Type[0], target.DeclaringType);
                var il = dynamic.GetILGenerator();

                il.DeclareLocal(target.DeclaringType);
                il.Emit(OpCodes.Newobj, target);
                il.Emit(OpCodes.Stloc_0);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ret);

                var method = (Func<object>) dynamic.CreateDelegate(typeof(Func<object>));
                return method();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                Logger.Log("Exception thrown at ProSeries.NewInstance", LogSeverity.Danger);
                return null;
            }
        }
    }
}