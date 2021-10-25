namespace Trinity.Items
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.EventsProvider;
    using Oasys.Common.GameObject.Clients.ExtendedInstances;
    using Oasys.Common.GameObject.Clients.ExtendedInstances.Spells;
    using Oasys.Common.GameObject.ObjectClass;
    using Oasys.Common.Menu;
    using Oasys.Common.Menu.ItemComponents;
    using Oasys.SDK;
    using Oasys.SDK.Tools;

    public delegate void OnItemInitialize();
    public delegate void OnItemDispose();

    public abstract class ActiveItemBase
    {
        #region Public Events

        public event OnItemInitialize OnItemInitialize;
        public event OnItemDispose OnItemDispose;

        #endregion

        #region Fields

        private bool _disposed;
        private bool _initialized;

        #endregion

        public ItemID ItemId { get; set; }
        protected float Range { get; set; }
        public Tab ItemTab { get; set; }
        
        public Dictionary<string, Switch> ItemSwitch = new();
        public Dictionary<string, Counter> ItemCounter = new();

        public SpellClass SpellClass { get; set; }

        public void Initialize(Tab parentTab)
        {
            ItemTab = parentTab;

            if (UnitManager.MyChampion.Inventory.HasItem(ItemId))
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

            var itemSlot = UnitManager.MyChampion.Inventory.GetItemByID(ItemId).Slot;
            SpellClass = UnitManager.MyChampion.GetSpellBook().GetSpellClass((SpellSlot) itemSlot + 6);
            OnItemInitialize?.Invoke();
        }

        public virtual void DisposeItem()
        {
            if (_disposed) return;

            _initialized = false;
            _disposed = true; 
            
            Logger.Log("Disposed " + ItemId);

            SpellClass = null;
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