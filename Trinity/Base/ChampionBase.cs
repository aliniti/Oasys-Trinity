using System.Collections.Generic;
using Oasys.Common;
using Oasys.Common.GameObject.Clients;
using Oasys.Common.Menu;
using Oasys.Common.Menu.ItemComponents;

namespace Trinity.Base
{
    public delegate void OnChampionInitialize();

    public delegate void OnChampionDispose();


    public abstract class ChampionBase
    {
        private bool _disposed;
        private bool _initialized;

        /// <summary>
        ///     The prediction groups
        /// </summary>
        public Dictionary<string, Group> ChampionGroup = new();
        
        /// <summary>
        ///     The prediction switches
        /// </summary>
        public Dictionary<string, Switch> ChampionSwitch = new();
        
        public Tab ChampionTab { get; set; }
        
        public void Initialize(Tab parentTab)
        {
            ChampionTab = parentTab;

            foreach (var u in ObjectManagerExport.HeroCollection)
            {
                var unit = u.Value;
                InitializeChampion(unit);
            }
        }

        public void InitializeChampion(AIHeroClient unit)
        {
            if (_initialized) return;
                    
            _disposed = false;
            _initialized = true;

            if (unit.IsAlly)
            {
                CreateTab();
                OnChampionInitialize?.Invoke();
                Bootstrap.Allies[unit.NetworkID] = new Champion(unit);
            }
            else
            {
                DisposeChampion(unit);
            }
        }

        public void DisposeChampion(AIHeroClient unit)
        {
            if (_disposed) return;

            _disposed = true;
            _initialized = false;
            
            OnChampionDispose?.Invoke();
            Bootstrap.Enemies[unit.NetworkID] = new Champion(unit);
        }

        public abstract void OnTick();
        public abstract void CreateTab();


        public event OnChampionInitialize OnChampionInitialize;
        public event OnChampionDispose OnChampionDispose;
    }
}