namespace Trinity.Helpers
{
    #region

    using Items;
    using Oasys.Common.Menu;
    using Oasys.Common.Menu.ItemComponents;
    using Spells;

    #endregion

    public static class Menu
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Creates the spell tab enable switch.
        /// </summary>
        /// <param name="spell">The spell.</param>
        public static void CreateSpellTabEnableSwitch(this AutoSpell spell)
        {
            var tabName = spell.ChampionName + spell.Slot;
            spell.SpellSwitch[tabName] = new Switch
            {
                IsOn = true,
                Title = "Use " + tabName
            };

            spell.SpellTab.AddItem(spell.SpellSwitch[tabName]);
        }

        /// <summary>
        ///     Creates the spell tab ally low hp.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateSpellTabAllyLowHP(this AutoSpell spell, int pctUse = 90)
        {
            var tabName = spell.ChampionName + spell.Slot;
            spell.SpellCounter[tabName + "ahp"] = new Counter
            {
                Title = "Use " + tabName + " at ALLY Percent HP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };

            spell.SpellTab.AddItem(spell.SpellCounter[tabName + "ahp"]);
        }

        /// <summary>
        ///     Creates the spell tab ally low mp.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateSpellTabAllyLowMP(this AutoSpell spell, int pctUse = 90)
        {
            var tabName = spell.ChampionName + spell.Slot;
            spell.SpellCounter[tabName + "amp"] = new Counter
            {
                Title = "Use " + tabName + " at ALLY Percent MP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };

            spell.SpellTab.AddItem(spell.SpellCounter[tabName + "amp"]);
        }

        /// <summary>
        ///     Creates the spell tab enemy low hp.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateSpellTabEnemyLowHP(this AutoSpell spell, int pctUse = 25)
        {
            var tabName = spell.ChampionName + spell.Slot;
            spell.SpellCounter[tabName + "ehp"] = new Counter
            {
                Title = "Use " + tabName + " at ENEMY Percent HP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };

            spell.SpellTab.AddItem(spell.SpellCounter[tabName + "ehp"]);
        }

        /// <summary>
        ///     Creates the spell tab ally minimum mp.
        /// </summary>
        /// <param name="spell">The spell.</param>
        public static void CreateSpellTabAllyMinimumMP(this AutoSpell spell)
        {
            var tabName = spell.ChampionName + spell.Slot;
            spell.SpellCounter[tabName + "amm"] = new Counter
            {
                Title = "Use " + tabName + " if Mana > (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = 55,
                ValueFrequency = 5
            };

            spell.SpellTab.AddItem(spell.SpellCounter[tabName + "amm"]);
        }

        /// <summary>
        ///     Creates the spell tab aura cleanse.
        /// </summary>
        /// <param name="spell">The spell.</param>
        public static void CreateSpellTabAuraCleanse(this AutoSpell spell)
        {
            var tabName = spell.ChampionName + spell.Slot;
            spell.SpellGroup[tabName + "buffs"] = new Group
            {
                Title = tabName
            };

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Ignite"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Ignite"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Exhaust"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Exhaust"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Suppression"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Suppression"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Knockups"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + tabName + " -> Knockups"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Sleep"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Sleep"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Stuns"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Stuns"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Charms"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Charms"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Taunts"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Taunts"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Fear"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Fear"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Snares"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Snares"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Polymorphs"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Polymorphs"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Silence"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + tabName + " -> Silence"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Blinds"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + tabName + " -> Blinds"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Slows"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + tabName + " -> Slows"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Poison"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + tabName + " -> Posion"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellCounter[tabName + "MinimumBuffs"] = new Counter
                {
                    Title = tabName + " -> Minimum Buffs to Use",
                    MaxValue = 5,
                    MinValue = 1,
                    Value = 1,
                    ValueFrequency = 1
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellCounter[tabName + "MinimumBuffsDuration"] = new Counter
                {
                    Title = tabName + " -> Minimum Buff Duration (in ms)",
                    MaxValue = 2000,
                    MinValue = 250,
                    Value = 1000,
                    ValueFrequency = 250
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "SwitchMinimumBuffHP"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + tabName + " -> Enable Minimum HP (%) to Use"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellCounter[tabName + "MinimumBuffsHP"] = new Counter
                {
                    Title = tabName + " -> Minimum HP (%) to Use",
                    MaxValue = 100,
                    MinValue = 20,
                    Value = 100,
                    ValueFrequency = 15
                });

            spell.SpellTab.AddGroup(spell.SpellGroup[tabName + "buffs"]);
        }

        /// <summary>
        ///     Creates the item tab enable switch.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void CreateItemTabEnableSwitch(this ActiveItem item)
        {
            item.ItemSwitch[item.ItemId.ToString()] = new Switch
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId]
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId.ToString()]);
        }

        /// <summary>
        ///     Creates the item tab enemy low health.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateItemTabEnemyLowHealth(this ActiveItem item, int pctUse = 95)
        {
            item.ItemCounter[item.ItemId + "ehp"] = new Counter
            {
                Title = "Use " + Translations.ItemNames[item.ItemId] + " at Enemy Percent HP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };

            item.ItemTab.AddItem(item.ItemCounter[item.ItemId + "ehp"]);
        }

        /// <summary>
        ///     Creates the item tab ally low health.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateItemTabAllyLowHealth(this ActiveItem item, int pctUse = 80)
        {
            item.ItemCounter[item.ItemId + "ahp"] = new Counter
            {
                Title = "Use " + Translations.ItemNames[item.ItemId] + " at Ally Percent HP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };

            item.ItemTab.AddItem(item.ItemCounter[item.ItemId + "ahp"]);
        }

        /// <summary>
        ///     Creates the item tab ally low mana.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateItemTabAllyLowMana(this ActiveItem item, int pctUse = 55)
        {
            item.ItemCounter[item.ItemId + "amp"] = new Counter
            {
                Title = "Use " + Translations.ItemNames[item.ItemId] + " at Ally Percent MP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };

            item.ItemTab.AddItem(item.ItemCounter[item.ItemId + "amp"]);
        }

        /// <summary>
        ///     Creates the item check aoe count.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateItemCheckAoECount(this ActiveItem item, int pctUse = 2)
        {
            item.ItemCounter[item.ItemId + "aoe"] = new Counter
            {
                Title = "Use " + Translations.ItemNames[item.ItemId] + " when Enemies Near >=",
                MaxValue = 5,
                MinValue = 1,
                Value = pctUse,
                ValueFrequency = 1
            };

            item.ItemTab.AddItem(item.ItemCounter[item.ItemId + "aoe"]);
        }

        /// <summary>
        ///     Creates the item tab aura cleanse.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateItemTabAuraCleanse(this ActiveItem item, int pctUse = 100)
        {
            item.ItemGroup[item.ItemId + "buffs"] = new Group
            {
                Title = Translations.ItemNames[item.ItemId] + ""
            };

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Ignite"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Ignite"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Exhaust"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Exhaust"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Suppression"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Suppression"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Knockups"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Knockups"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Sleep"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Sleep"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Stuns"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Stuns"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Charms"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Charms"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Taunts"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Taunts"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Fear"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Fear"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Snares"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Snares"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Polymorphs"] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Polymorphs"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Silence"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Silence"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Blinds"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Blinds"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Slows"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Slows"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Poison"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Posion"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemCounter[item.ItemId + "MinimumBuffs"] = new Counter
                {
                    Title = Translations.ItemNames[item.ItemId] + " -> Minimum Buffs to Use",
                    MaxValue = 5,
                    MinValue = 1,
                    Value = 1,
                    ValueFrequency = 1
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemCounter[item.ItemId + "MinimumBuffsDuration"] = new Counter
                {
                    Title = Translations.ItemNames[item.ItemId] + " -> Minimum Buff Duration (in ms)",
                    MaxValue = 2000,
                    MinValue = 250,
                    Value = 1000,
                    ValueFrequency = 250
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "SwitchMinimumBuffHP"] = new Switch
                {
                    IsOn = false,
                    Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Enable Minimum HP (%) to Use"
                });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemCounter[item.ItemId + "MinimumBuffsHP"] = new Counter
                {
                    Title = Translations.ItemNames[item.ItemId] + " -> Minimum HP (%) to Use",
                    MaxValue = 100,
                    MinValue = 20,
                    Value = 100,
                    ValueFrequency = 15
                });

            item.ItemTab.AddGroup(item.ItemGroup[item.ItemId + "buffs"]);
        }

        #endregion
    }
}