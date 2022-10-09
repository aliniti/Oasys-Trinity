namespace Trinity
{
    #region
    
    using Base;
    using Helpers;
 
    using Oasys.Common.EventsProvider;
    using Oasys.Common.GameObject.Clients;
    using Oasys.Common.Menu;
    
    using Oasys.SDK;
    using Oasys.SDK.Menu;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion

    public static class Bootstrap
    {
        public static int LastActivationTs { get; set; }
        public static readonly Dictionary<uint, Champion> Allies = new();
        public static readonly Dictionary<uint, Champion> Enemies = new();

        #region Public Methods and Operators

        /// <summary>
        ///     The Oasys module entry point
        /// </summary>
        [Oasys.SDK.OasysModuleEntryPoint]
        public static void Execute()
        {
            GameEvents.OnGameLoadComplete += OnGameLoadComplete;
            GameEvents.OnGameMatchComplete += OnGameMatchComplete;
        }

        #endregion

        #region Private Methods and Operators

        /// <summary>
        ///     Games events [on game load complete].
        /// </summary>
        private static async Task OnGameLoadComplete()
        {            
            Lists.Populate();
            
            CoreEvents.OnCoreMainTick += OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync += OnCoreMainInputAsync;
            CoreEvents.OnCoreRender += OnCoreRender;
            
            Oasys.SDK.Events.GameEvents.OnCreateObject += OnCreateObject;
            Oasys.SDK.Events.GameEvents.OnDeleteObject += OnDeleteObject;
            
            InitializeTrinity();
        }

        /// <summary>
        ///     Games events [on game match complete].
        /// </summary>
        private static async Task OnGameMatchComplete()
        {
            Lists.Dispose();
            
            CoreEvents.OnCoreMainTick -= OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync -= OnCoreMainInputAsync;
            CoreEvents.OnCoreRender -= OnCoreRender;
            
            Oasys.SDK.Events.GameEvents.OnCreateObject -= OnCreateObject;
            Oasys.SDK.Events.GameEvents.OnDeleteObject -= OnDeleteObject;
        }
        
        /// <summary>
        ///     Initializes the trinity add-on.
        /// </summary>
        private static void InitializeTrinity()
        {

            #region Tidy : Purify Item Menu

            var cleanseItemMenu = new Tab("Trinity: Purifiers");
            
            foreach (var item in Lists.CleanseItems)
            {
                item.OnItemInitialize += () => Lists.InitializedTickItems.Add(item);
                item.OnItemDispose += () => Lists.InitializedTickItems.Remove(item);
                item.Initialize(cleanseItemMenu);
            }

            MenuManager.AddTab(cleanseItemMenu);

            #endregion

            #region Tidy : Offensive Item Menu

            var offensiveItemMenu = new Tab("Trinity: Offensives");

            foreach (var item in Lists.OffensiveItems)
            {
                item.OnItemInitialize += () => Lists.InitializedInputItems.Add(item);
                item.OnItemDispose += () => Lists.InitializedInputItems.Remove(item);
                item.Initialize(offensiveItemMenu);
            }

            MenuManager.AddTab(offensiveItemMenu);

            #endregion

            #region Tidy : Defensive Item Menu

            var defensiveItemMenu = new Tab("Trinity: Defensives");

            foreach (var item in Lists.DefensiveItems)
            {
                item.OnItemInitialize += () => Lists.InitializedTickItems.Add(item);
                item.OnItemDispose += () => Lists.InitializedTickItems.Remove(item);
                item.Initialize(defensiveItemMenu);
            }

            MenuManager.AddTab(defensiveItemMenu);

            #endregion

            #region Tidy : Cosumable Item Menu

            var consumablesItemMenu = new Tab("Trinity: Consumables");

            foreach (var item in Lists.ConsumableItems)
            {
                item.OnItemInitialize += () => Lists.InitializedTickItems.Add(item);
                item.OnItemDispose += () => Lists.InitializedTickItems.Remove(item);
                item.Initialize(consumablesItemMenu);
            }

            MenuManager.AddTab(consumablesItemMenu);

            #endregion

            #region Tidy : Summoner Spells Menu

            var summonerSpellMenu = new Tab("Trinity: Summoners");

            foreach (var spell in Lists.SummonerTickSpells)
            {
                spell.OnSpellInitialize += () => Lists.InitializedTickSpells.Add(spell);
                spell.OnSpellDispose += () => Lists.InitializedTickSpells.Remove(spell);
                spell.Initialize(summonerSpellMenu);
            }

            foreach (var spell in Lists.SummonerInputSpells)
            {
                spell.OnSpellInitialize += () => Lists.InitializedInputSpells.Add(spell);
                spell.OnSpellDispose += () => Lists.InitializedInputSpells.Remove(spell);
                spell.Initialize(summonerSpellMenu);
            }

            MenuManager.AddTab(summonerSpellMenu);

            #endregion

            #region Tidy : Auto Spells Menu

            var autoSpellsMenu = new Tab("Trinity: Auto Spells");

            foreach (var spell in Lists.AutoSpells)
            {
                spell.OnSpellInitialize += () => Lists.InitializedTickSpells.Add(spell);
                spell.OnSpellDispose += () => Lists.InitializedTickSpells.Remove(spell);
                spell.Initialize(autoSpellsMenu);
            }

            MenuManager.AddTab(autoSpellsMenu);

            #endregion

            #region Tidy : Prediction Menu

            var config = new Tab("Trinity: Prediction");

            foreach (var troy in Lists.Particles)
            {
                troy.OnEmitterInitialize += () => Lists.InitializedParticles.Add(troy);
                troy.OnEmitterDispose += () => Lists.InitializedParticles.Remove(troy);
                troy.Initialize(config);
            }
            
            foreach (var championBase in Lists.AllChampions)
            {
                var hero = (Champion) championBase;
                hero.OnChampionInitialize += () => Lists.InitializedChampions.Add(hero);
                hero.OnChampionDispose += () => Lists.InitializedChampions.Remove(hero);
                hero.Initialize(config, hero);
            }
            
            foreach (var aura in Lists.Auras)
            {
                aura.OnAuraInitialize += () => Lists.InitializedAuras.Add(aura);
                aura.OnAuraDispose += () => Lists.InitializedAuras.Remove(aura);
                aura.Initialize(config);
            }

            MenuManager.AddTab(config);

            #endregion
        }

        /// <summary>
        ///     Cores events [on core main tick].
        /// </summary>
        private static async Task OnCoreMainTick()
        {
            if (!GameEngine.IsGameWindowFocused) return;
            
            foreach (var initializedEmitter in Lists.InitializedParticles)
                initializedEmitter.OnTick();
            
            foreach (var initializedAura in Lists.InitializedAuras)
                initializedAura.OnTick();
            
            foreach (var initializedTickItem in Lists.InitializedTickItems)
                initializedTickItem.OnTick();

            foreach (var initializedTickSpell in Lists.InitializedTickSpells)
                initializedTickSpell.OnTick();

            foreach (var initializedChampion in Lists.InitializedChampions)
                initializedChampion.OnTick();
        }

        /// <summary>
        ///     Cores events [on core main input asynchronous].
        /// </summary>
        private static async Task OnCoreMainInputAsync()
        {
            if (!GameEngine.IsGameWindowFocused) return;
            
            foreach (var initializedInputItem in Lists.InitializedInputItems)
                initializedInputItem.OnTick();

            foreach (var initializedInputSpell in Lists.InitializedInputSpells)
                initializedInputSpell.OnTick();
        }

        /// <summary>
        ///     Cores events [on core render].
        /// </summary>
        private static void OnCoreRender()
        {
            if (!GameEngine.IsGameWindowFocused) return;
            
            foreach (var initializedTickItem in Lists.InitializedTickItems)
                initializedTickItem.OnRender();

            foreach (var initializedTickSpell in Lists.InitializedTickSpells)
                initializedTickSpell.OnRender();
        }

        /// <summary>
        ///     Game events [on create object].
        /// </summary>
        private static async Task OnCreateObject(List<AIBaseClient> callbackobjectlist, AIBaseClient callbackobject, float callbackgametime)
        {
            foreach (var initializedEmitter in Lists.InitializedParticles)
                initializedEmitter.OnCreate(callbackobjectlist, callbackobject, callbackgametime);
            
            foreach (var initializedChampion in Lists.InitializedChampions)
                initializedChampion.OnCreate(callbackobjectlist, callbackobject, callbackgametime);
        }
        
        /// <summary>
        ///     Game events [on delete object].
        /// </summary>
        private static async Task OnDeleteObject(List<AIBaseClient> callbackobjectlist, AIBaseClient callbackobject, float callbackgametime)
        {
            foreach (var initializedEmitter in Lists.InitializedParticles)
                initializedEmitter.OnDelete(callbackobjectlist, callbackobject, callbackgametime);
        }

        #endregion
    }
}