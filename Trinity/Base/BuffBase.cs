namespace Trinity.Base
{
    using System.Collections.Generic;
    using Helpers;
    using Oasys.Common.Menu;
    using Oasys.Common.Menu.ItemComponents;

    public delegate void OnAuraInitialize();
    public delegate void OnAuraDispose();
    
    /// <summary>
    ///     The aura class responsible for in-game buffs
    /// </summary>
    public abstract class BuffBase
    {

        private bool _disposed;
        private bool _initialized;
        
        /// <summary>
        ///     The buff groups
        /// </summary>
        public Dictionary<string, Group> BuffGroup = new();
        
        /// <summary>
        ///     The buff switches
        /// </summary>
        public Dictionary<string, Switch> BuffSwitch = new();

        /// <summary>
        ///     Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        ///     The owner identifier.
        /// </value>
        public string ChampionString { get; set; }
        
        /// <summary>
        ///     Gets or sets the prediction tab.
        /// </summary>
        /// <value>
        ///     The prediction tab.
        /// </value>
        public Tab BuffTab { get; set; }


        public void Initialize(Tab parentTab)
        {
            BuffTab = parentTab;
            InitializeAura();
        }

        public void InitializeAura()
        {
            if (_initialized) return;

            if (ChampionString.EnemyExists() || ChampionString.Equals("All"))
            {
                _disposed = false;
                _initialized = true;

                CreateTab();
                OnAuraInitialize?.Invoke();
                //Logger.Log("Initialized " + ChampionString.ToLower() + " aura prediction!");
            }
            else
            {
                DisposeAura();
            }
        }

        public void DisposeAura()
        {
            if (_disposed) return;

            _disposed = true;
            _initialized = false;
            OnAuraDispose?.Invoke();
            //Logger.Log("Disposed " + ChampionString.ToLower() + " aura prediction!");
        }
        
        public abstract void OnTick();
        public abstract void CreateTab();

        public event OnAuraInitialize OnAuraInitialize;
        public event OnAuraDispose OnAuraDispose;

    }
}