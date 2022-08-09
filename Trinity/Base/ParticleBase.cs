namespace Trinity.Base
{
    #region

    using System.Collections.Generic;
    using Helpers;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.Menu;
    using Oasys.Common.Menu.ItemComponents;

    #endregion

    public delegate void OnEmitterInitialize();
    public delegate void OnEmitterDispose();

    /// <summary>
    ///     The particle emitter class responsible for in-game troys
    /// </summary>
    public abstract class ParticleBase
    {
        #region Fields

        private bool _disposed;
        private bool _initialized;
        
        /// <summary>
        ///     The prediction groups
        /// </summary>
        public Dictionary<string, Group> PredictionGroup = new();
        
        /// <summary>
        ///     The prediction switches
        /// </summary>
        public Dictionary<string, Switch> PredictionSwitch = new();

        #endregion

        #region Properties and Encapsulation

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ParticleBase" /> is included.
        /// </summary>
        /// <value>
        ///     <c>true</c> if included; otherwise, <c>false</c>.
        /// </value>
        public bool Included { get; set; }

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
        public Tab PredictionTab { get; set; }

        #endregion
        
        /// <summary>
        ///     Initialized the emitter/troy
        /// </summary>
        /// <param name="parentTab"></param>
        public void Initialize(Tab parentTab)
        {
            PredictionTab = parentTab;
            InitializeEmitter();
        }
        
        public void InitializeEmitter()
        {
            if (_initialized) return;

            if (ChampionString.EnemyExists())
            {
                _disposed = false;
                _initialized = true;

                CreateTab();
                OnEmitterInitialize?.Invoke();
                //Logger.Log("Initialized " + ChampionString.ToLower() + " vfx/troy prediction!");
            }
            else
            {
                DisposeEmitter();
            }
        }

        public void DisposeEmitter()
        {
            if (_disposed) return;

            _disposed = true;
            _initialized = false;
            OnEmitterDispose?.Invoke();
            //Logger.Log("Disposed " + ChampionString + " vfx/troy prediction!");
        }

        #region Public Methods and Operators

        public abstract void OnTick();
        public abstract void CreateTab();
        public abstract void OnCreate(List<AIBaseClient> objList, AIBaseClient obj, float callbackGameTime);
        public abstract void OnDelete(List<AIBaseClient> objList, AIBaseClient obj, float callbackGameTime);

        #endregion


        public event OnEmitterInitialize OnEmitterInitialize;
        public event OnEmitterDispose OnEmitterDispose;
    }
}