namespace Trinity.Items
{
    #region

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

    #endregion

    public delegate void OnItemInitialize();
    public delegate void OnItemDispose();
    public abstract class ActiveItemBase
    {
        #region Fields

        private bool _disposed;
        private bool _initialized;

        /// <summary>
        ///     The item counters
        /// </summary>
        public Dictionary<string, Counter> ItemCounter = new();

        /// <summary>
        ///     The item groups
        /// </summary>
        public Dictionary<string, Group> ItemGroup = new();

        /// <summary>
        ///     The item switchs
        /// </summary>
        public Dictionary<string, Switch> ItemSwitch = new();

        #endregion

        #region Properties and Encapsulation

        /// <summary>
        ///     Gets or sets the item identifier.
        /// </summary>
        /// <value>
        ///     The item identifier.
        /// </value>
        public ItemID ItemId { get; set; }

        /// <summary>
        ///     Gets or sets the spell class.
        /// </summary>
        /// <value>
        ///     The spell class.
        /// </value>
        public SpellClass SpellClass { get; set; }

        /// <summary>
        ///     Gets or sets the item tab.
        /// </summary>
        /// <value>
        ///     The item tab.
        /// </value>
        public Tab ItemTab { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Initializes the specified parent tab/item.
        /// </summary>
        /// <param name="parentTab">The parent tab.</param>
        public void Initialize(Tab parentTab)
        {
            ItemTab = parentTab;

            if (UnitManager.MyChampion.Inventory.HasItem(ItemId))
                InitializeItem();
            else
                DisposeItem();

            GameEvents.OnBuyItem += GameEvents_OnBuyItem;
            GameEvents.OnSellItem += GameEvents_OnSellItem;

            CreateTab();
        }


        /// <summary>
        ///     Initializes the item.
        /// </summary>
        public virtual void InitializeItem()
        {
            if (_initialized) return;

            _initialized = true;
            _disposed = false;
            Logger.Log("Initialized " + ItemId);

            var itemSlot = UnitManager.MyChampion.Inventory.GetItemByID(ItemId).Slot;
            SpellClass = UnitManager.MyChampion.GetSpellBook().GetSpellClass((SpellSlot) itemSlot + 6);
            OnItemInitialize?.Invoke();
        }

        /// <summary>
        ///     Disposes the item.
        /// </summary>
        public virtual void DisposeItem()
        {
            if (_disposed) return;

            _initialized = false;
            _disposed = true;

            //Logger.Log("Disposed " + ItemId);
            SpellClass = null;
            OnItemDispose?.Invoke();
        }

        public abstract void OnTick();
        public abstract void CreateTab();
        public abstract void OnRender();

        #endregion

        #region Private Methods and Operators

        /// <summary>
        ///     Events on sell item.
        /// </summary>
        /// <param name="heroUpdatingItem">The hero updating item.</param>
        /// <param name="updatedItemList">The updated item list.</param>
        /// <param name="updatedItem">The updated item.</param>
        /// <param name="updatedGametime">The updated gametime.</param>
        private async Task GameEvents_OnSellItem(Hero heroUpdatingItem, List<HeroInventory.Item> updatedItemList,
            HeroInventory.Item updatedItem, float updatedGametime)
        {
            if (updatedItem.ID == ItemId)
                if (heroUpdatingItem.NetworkID == UnitManager.MyChampion.NetworkID)
                    DisposeItem();
        }

        /// <summary>
        ///     Events on buy item.
        /// </summary>
        /// <param name="heroUpdatingItem">The hero updating item.</param>
        /// <param name="updatedItemList">The updated item list.</param>
        /// <param name="updatedItem">The updated item.</param>
        /// <param name="updatedGametime">The updated gametime.</param>
        private async Task GameEvents_OnBuyItem(Hero heroUpdatingItem, List<HeroInventory.Item> updatedItemList,
            HeroInventory.Item updatedItem, float updatedGametime)
        {
            if (updatedItem.ID == ItemId)
                if (heroUpdatingItem.NetworkID == UnitManager.MyChampion.NetworkID)
                    InitializeItem();
        }

        #endregion

        public event OnItemInitialize OnItemInitialize;
        public event OnItemDispose OnItemDispose;
    }
}