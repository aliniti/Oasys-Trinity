﻿namespace Trinity.Spells
{
    using Oasys.SDK;
    using Oasys.SDK.SpellCasting;
    using Oasys.SDK.Tools;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.GameObject.Clients.ExtendedInstances.Spells;
    using Oasys.Common.Menu;
    using Oasys.Common.Menu.ItemComponents;
    using System.Collections.Generic;
    using Helpers;

    public delegate void OnSpellInitialize();
    public delegate void OnSpellDispose();

    public abstract class AutoSpellBase
    {
        #region Public Events

        public event OnSpellInitialize OnSpellInitialize;
        public event OnSpellDispose OnSpellDispose;

        #endregion

        #region Fields

        private bool _disposed;
        private bool _initialized;

        #endregion

        public Tab SpellTab { get; set; }
        public string ChampionName { get; set; }
        public string SpellName { get; set; }
        public CastSlot Slot { get; set; }
        public float Range { get; set; }

        public SpellClass SpellClass { get; set; }
        public Dictionary<string, Switch> SpellSwitch = new();
        public Dictionary<string, Counter> SpellCounter = new();
        public Dictionary<string, Group> SpellGroup = new();

        public void Initialize(Tab parentTab)
        {
            SpellTab = parentTab;

            if (UnitManager.MyChampion.ModelName == ChampionName)
            {
                InitializeSpell();
            }
            else switch (string.IsNullOrEmpty(SpellName))
            {
                case false:
                    InitializeSpell();
                    break;
                default:
                    DisposeSpell();
                    break;
            }
        }

        public virtual void InitializeSpell()
        {
            if (_initialized)
            {
                return;
            }

            _disposed = false;
            _initialized = true;

            switch (string.IsNullOrEmpty(SpellName))
            {
                case false:
                    this.GetSpellClassByName();
                    break;
                default:
                    SpellClass = UnitManager.MyChampion.GetSpellBook().GetSpellClass((SpellSlot) Slot - 16);
                    break;
            }

            if (SpellClass != null)
            {
                CreateTab();
                OnSpellInitialize?.Invoke();
                Logger.Log("Initialized " + ChampionName + " " + Slot);
            }
            else
            {
                DisposeSpell();
            }
        }

        public virtual void DisposeSpell()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            _initialized = false;

            SpellClass = null;
            //Logger.Log("Disposed " + ChampionName + " " + Slot);
            OnSpellDispose?.Invoke();
        }

        public abstract void OnTick();
        public abstract void CreateTab();
    }
}
