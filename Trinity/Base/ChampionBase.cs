namespace Trinity.Base
{
    using System.Collections.Generic;
    using Oasys.Common.Menu;
    using Oasys.Common.Menu.ItemComponents;
    using Oasys.Common.GameObject.Clients;

    public delegate void OnChampionInitialize();
    public delegate void OnChampionDispose();


    public abstract class ChampionBase
    {
        private bool _disposed;
        private bool _initialized;

        /// <summary>
        ///     The prediction switches
        /// </summary>
        public Dictionary<string, Switch> ChampionSwitch = new();
        
        /// <summary>
        ///     Gets or sets the champion tab.
        /// </summary>
        /// <value>
        ///     The champion tab.
        /// </value>
        public Tab ChampionTab { get; set; }
        
        /// <summary>
        ///     Gets or sets the champion group tab.
        /// </summary>
        /// <value>
        ///     The champion group tab.
        /// </value>
        public Tab ChampionGroupTab { get; set; }
        
        
        public void Initialize(Tab parentTab, Champion champion)
        {
            ChampionTab = parentTab;
            InitializeChampion(champion);
        }

        public void InitializeChampion(Champion champion)
        {
            if (_initialized) return;
                    
            _disposed = false;
            _initialized = true;

            if (champion.Instance.IsAlly)
            {
                CreateTab();
                OnChampionInitialize?.Invoke();
                Bootstrap.Allies[champion.Instance.NetworkID] = champion;
            }
            else
            {
                DisposeChampion(champion);
            }
        }

        public void DisposeChampion(Champion champion)
        {
            if (_disposed) return;

            _disposed = true;
            _initialized = false;
            
            OnChampionDispose?.Invoke();
            Bootstrap.Enemies[champion.Instance.NetworkID] = champion;
        }

        public abstract void OnTick();
        public abstract void CreateTab();
        public abstract void OnCreate(List<AIBaseClient> callbackobjectlist, AIBaseClient callbackobject, float callbackgametime);
        
        public event OnChampionInitialize OnChampionInitialize;
        public event OnChampionDispose OnChampionDispose;
    }
}