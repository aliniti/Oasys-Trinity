﻿namespace Trinity
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
        
        #region Tidy : OnExecute
        
        [Oasys.SDK.OasysModuleEntryPoint]
        public static void Execute()
        {
            GameEvents.OnGameLoadComplete += OnGameLoadComplete;
            GameEvents.OnGameMatchComplete += OnGameMatchComplete;
        }

        #endregion

        #region Tidy : OnStart & OnEnd
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
        
        private static async Task OnGameMatchComplete()
        {
            Lists.Dispose();
            
            CoreEvents.OnCoreMainTick -= OnCoreMainTick;
            CoreEvents.OnCoreMainInputAsync -= OnCoreMainInputAsync;
            CoreEvents.OnCoreRender -= OnCoreRender;
            
            Oasys.SDK.Events.GameEvents.OnCreateObject -= OnCreateObject;
            Oasys.SDK.Events.GameEvents.OnDeleteObject -= OnDeleteObject;
        }
        
        #endregion
        
        private static void InitializeTrinity()
        {
            var menu = new Tab("Trinity");

            #region Tidy : Purify Item Menu

            var cleanseItemMenu = new Tab("Purifiers");
            
            foreach (var item in Lists.CleanseItems)
            {
                item.OnItemInitialize += () => Lists.InitializedTickItems.Add(item);
                item.OnItemDispose += () => Lists.InitializedTickItems.Remove(item);
                item.Initialize(cleanseItemMenu);
            }

            menu.AddItem(cleanseItemMenu);

            #endregion

            #region Tidy : Offensive Item Menu

            var offensiveItemMenu = new Tab("Offensives");

            foreach (var item in Lists.OffensiveItems)
            {
                item.OnItemInitialize += () => Lists.InitializedInputItems.Add(item);
                item.OnItemDispose += () => Lists.InitializedInputItems.Remove(item);
                item.Initialize(offensiveItemMenu);
            }

            menu.AddItem(offensiveItemMenu);

            #endregion

            #region Tidy : Defensive Item Menu

            var defensiveItemMenu = new Tab("Defensives");

            foreach (var item in Lists.DefensiveItems)
            {
                item.OnItemInitialize += () => Lists.InitializedTickItems.Add(item);
                item.OnItemDispose += () => Lists.InitializedTickItems.Remove(item);
                item.Initialize(defensiveItemMenu);
            }

            menu.AddItem(defensiveItemMenu);

            #endregion

            #region Tidy : Cosumable Item Menu

            var consumablesItemMenu = new Tab("Consumables");

            foreach (var item in Lists.ConsumableItems)
            {
                item.OnItemInitialize += () => Lists.InitializedTickItems.Add(item);
                item.OnItemDispose += () => Lists.InitializedTickItems.Remove(item);
                item.Initialize(consumablesItemMenu);
            }

            menu.AddItem(consumablesItemMenu);

            #endregion

            #region Tidy : Summoner Spells Menu

            var summonerSpellMenu = new Tab("Summoners");

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

            menu.AddItem(summonerSpellMenu);

            #endregion

            #region Tidy : Auto Spells Menu

            var autoSpellsMenu = new Tab("Auto Spells");

            foreach (var spell in Lists.AutoSpells)
            {
                spell.OnSpellInitialize += () => Lists.InitializedTickSpells.Add(spell);
                spell.OnSpellDispose += () => Lists.InitializedTickSpells.Remove(spell);
                spell.Initialize(autoSpellsMenu);
            }

            menu.AddItem(autoSpellsMenu);

            #endregion
            
            #region Tidy : Advanced Menu
            
            var advancedMenu = new Tab("Advanced");
            
            var auras = new Tab("Auras");
            foreach (var aura in Lists.Auras)
            {
                aura.OnAuraInitialize += () => Lists.InitializedAuras.Add(aura);
                aura.OnAuraDispose += () => Lists.InitializedAuras.Remove(aura);
                aura.Initialize(auras);
            }
            
            var types = new Tab("Aura Types");
            foreach (var aura in Lists.AuraTypes)
            {
                aura.OnAuraInitialize += () => Lists.InitializedAuras.Add(aura);
                aura.OnAuraDispose += () => Lists.InitializedAuras.Remove(aura);
                aura.Initialize(types);
            }
            
            var heroes = new Tab("Heroes");
            foreach (var championBase in Lists.AllChampions)
            {
                var hero = (Champion) championBase;
                hero.OnChampionInitialize += () => Lists.InitializedChampions.Add(hero);
                hero.OnChampionDispose += () => Lists.InitializedChampions.Remove(hero);
                hero.Initialize(heroes, hero);
            }
            
            var particles = new Tab("Particles");
            foreach (var troy in Lists.Particles)
            {
                troy.OnEmitterInitialize += () => Lists.InitializedParticles.Add(troy);
                troy.OnEmitterDispose += () => Lists.InitializedParticles.Remove(troy);
                troy.Initialize(particles);
            }
            
            #endregion
            
            advancedMenu.AddItem(auras);
            advancedMenu.AddItem(types);
            advancedMenu.AddItem(heroes);
            advancedMenu.AddItem(particles);
            
            menu.AddItem(advancedMenu);
            MenuManager.AddTab(menu);
        }

        #region  Tidy: OnTick
        
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
        
        #endregion

        #region Tidy : OnMainInput
        private static async Task OnCoreMainInputAsync()
        {
            if (!GameEngine.IsGameWindowFocused) return;
            
            foreach (var initializedInputItem in Lists.InitializedInputItems)
                initializedInputItem.OnTick();

            foreach (var initializedInputSpell in Lists.InitializedInputSpells)
                initializedInputSpell.OnTick();
        }
        
        #endregion
        
        #region Tidy: OnCreate & OnDelete
        private static async Task OnCreateObject(List<AIBaseClient> callbackObjectList, AIBaseClient callbackObject, float callbackGameTime)
        {
            foreach (var initializedEmitter in Lists.InitializedParticles)
                initializedEmitter.OnCreate(callbackObjectList, callbackObject, callbackGameTime);
            
            foreach (var initializedChampion in Lists.InitializedChampions)
                initializedChampion.OnCreate(callbackObjectList, callbackObject, callbackGameTime);
        }
        
        private static async Task OnDeleteObject(List<AIBaseClient> callbackObjectList, AIBaseClient callbackObject, float callbackGameTime)
        {
            foreach (var initializedEmitter in Lists.InitializedParticles)
                initializedEmitter.OnDelete(callbackObjectList, callbackObject, callbackGameTime);
        }
        
        #endregion
        
        #region Tidy : OnRender
        private static void OnCoreRender()
        {
            if (!GameEngine.IsGameWindowFocused) return;
            
            foreach (var initializedTickItem in Lists.InitializedTickItems)
                initializedTickItem.OnRender();
            
            foreach (var initializedInputItem in Lists.InitializedInputItems)
                initializedInputItem.OnRender();

            foreach (var initializedTickSpell in Lists.InitializedTickSpells)
                initializedTickSpell.OnRender();
            
            foreach (var initializedInputSpell in Lists.InitializedInputSpells)
                initializedInputSpell.OnRender();
            
            foreach (var initializedChampion in Lists.InitializedChampions)
                initializedChampion.OnRender();
        }
        
        #endregion
    }
}