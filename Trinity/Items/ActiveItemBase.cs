#region Copyright © 2021 Kurisu Solutions
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//       Document:	Items\ActiveItemBase.cs
//       Date:		10/14/2021
//       Author:	Robin Kurisu
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see http://www.gnu.org/licenses/
#endregion

namespace Trinity.Items
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.EventsProvider;
    using Oasys.Common.GameObject.Clients.ExtendedInstances;
    using Oasys.Common.GameObject.ObjectClass;
    using Oasys.Common.Menu;
    using Oasys.Common.Menu.ItemComponents;
    using Oasys.SDK.Tools;
    using static Oasys.SDK.UnitManager;

    public delegate void OnItemInitialize();
    public delegate void OnItemDispose();

    public abstract class ActiveItemBase
    {
        public event OnItemInitialize OnItemInitialize;
        public event OnItemDispose OnItemDispose;

        #region Fields

        private bool _disposed;
        private bool _initialized;

        #endregion

        #region Properties and Indexers

        public ItemID ItemId { get; set; }
        protected float Range { get; set; }
        public Tab ItemTab { get; set; }
        
        public Dictionary<string, Switch> ItemSwitch = new();
        public Dictionary<string, Counter> ItemCounter = new();
        private HeroInventory.Item ItemSpell { get; set; }

        #endregion

        public void Initialize(Tab parentTab)
        {
            ItemTab = parentTab;

            if (MyChampion.Inventory.HasItem(ItemId))
                InitializeItem();
            else
                DisposeItem();

            CreateTab();
            GameEvents.OnBuyItem += GameEvents_OnBuyItem;
            GameEvents.OnSellItem += GameEvents_OnSellItem;
        }

        public virtual void InitializeItem()
        {
            if (_initialized) 
                return;

            _initialized = true;
            _disposed = false;
            Logger.Log("Initialized " + ItemId);

            ItemSpell = MyChampion.Inventory.GetItemByID(ItemId);
            OnItemInitialize?.Invoke();
        }

        public virtual void DisposeItem()
        {
            if (_disposed) return;

            _initialized = false;
            _disposed = true;
            Logger.Log("Disposed " + ItemId);

            ItemSpell = null;
            OnItemDispose?.Invoke();
        }

        private async Task GameEvents_OnSellItem(Hero heroUpdatingItem, List<HeroInventory.Item> updatedItemList,
            HeroInventory.Item updatedItem, float updatedGametime)
        {
            if (updatedItem.ID == this.ItemId)
            {
                DisposeItem();
            }
        }

        private async Task GameEvents_OnBuyItem(Hero heroUpdatingItem, List<HeroInventory.Item> updatedItemList,
            HeroInventory.Item updatedItem, float updatedGametime)
        {
            if (updatedItem.ID == this.ItemId)
            {
                InitializeItem();
            }
        }

        public abstract void OnTick();
        public abstract void CreateTab();
    }
}