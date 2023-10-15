namespace Trinity.Helpers
{
    #region
    
    using Items;
    using Spells;
    
    using Oasys.Common.Menu;
    using Oasys.Common.Menu.ItemComponents;
    using Oasys.SDK.InputProviders;
    using Oasys.Common.Tools.Devices;

    using System.Windows.Forms;

    #endregion

    public static class Menu
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Creates the spell tab enable switch.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="key">The key</param>
        public static void CreateSpellTabEnableSwitch(this AutoSpell spell, Keys key = Keys.None)
        {
            var tabName = spell.IsSummonerSpell  ? spell.ChampionName : spell.ChampionName + spell.Slot;
            
            spell.SpellGroupTab = new Tab
            {
                Title = tabName
            };
        
            spell.SpellGroupTab.AddItem(
                spell.SpellSwitch[tabName] = new Switch
                {
                    IsOn = true,
                    Title = "Use " + tabName
                });

            if (key != Keys.None)
            {
                spell.SpellGroupTab.AddItem(
                    spell.SpellKeybind[tabName] = new KeyBinding
                    {
                        SelectedKey = key,
                        Title = tabName + " Toggle Key"
                    });

                KeyboardProvider.OnKeyPress += (pressed, state) =>
                {
                    if (pressed == key && state == Keyboard.KeyPressState.Up)
                    {
                        switch (spell.SpellSwitch[tabName].IsOn)
                        {
                            // toggle state
                            case true:
                                spell.SpellSwitch[tabName].IsOn = false;
                                return;
                            // toggle state
                            case false:
                                spell.SpellSwitch[tabName].IsOn = true;
                                return;
                        }
                    }
                };
            }

            spell.SpellTab.AddItem(spell.SpellGroupTab);
        }

        /// <summary>
        ///     Creates the spell tab binding.
        /// </summary>
        /// <param name="spell">The spell.</param>
        public static void CreateSpellTabBindingUnit(this AutoSpell spell)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            spell.SpellGroupTab.AddItem(spell.SpellModeDisplay[tabName + "mode"] = new ModeDisplay
            {
                Title = "Use " + tabName + " priority unit: ",
                ModeNames = { "MostAD", "MaxHP" },
                SelectedModeName = "MostAD"
            });
        }

        /// <summary>
        ///     Creates the spell tab ally low hp.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateSpellTabAllyLowHP(this AutoSpell spell, int pctUse = 90)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            spell.SpellGroupTab.AddItem(spell.SpellCounter[tabName + "ahp"] = new Counter
            {
                Title = "Use " + tabName + " at ALLY Percent HP < (%)",
                MaxValue = 100,
                MinValue = 0,
                Value = pctUse,
                ValueFrequency = 5
            });
        }

        /// <summary>
        ///     Creates the spell tab ally low mp.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateSpellTabAllyLowMP(this AutoSpell spell, int pctUse = 90)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            spell.SpellGroupTab.AddItem(spell.SpellCounter[tabName + "amp"] = new Counter
            {
                Title = "Use " + tabName + " at ALLY Percent MP < (%)",
                MaxValue = 100,
                MinValue = 0,
                Value = pctUse,
                ValueFrequency = 5
            });
        }

        /// <summary>
        ///     Creates the spell tab enemy low hp.
        /// </summary>
        /// <param name="spell">The spell.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateSpellTabEnemyLowHP(this AutoSpell spell, int pctUse = 25)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            spell.SpellGroupTab.AddItem(spell.SpellCounter[tabName + "ehp"] = new Counter
            {
                Title = "Use " + tabName + " at ENEMY Percent HP < (%)",
                MaxValue = 100,
                MinValue = 0,
                Value = pctUse,
                ValueFrequency = 5
            });
        }

        /// <summary>
        ///     Creates the spell tab ally minimum mp.
        /// </summary>
        /// <param name="spell">The spell.</param>
        public static void CreateSpellTabAllyMinimumMP(this AutoSpell spell)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            spell.SpellGroupTab.AddItem(spell.SpellCounter[tabName + "amm"] = new Counter
            {
                Title = "Use " + tabName + " if Mana > (%)",
                MaxValue = 100,
                MinValue = 0,
                Value = 35,
                ValueFrequency = 5
            });
        }
        
        /// <summary>
        ///     Creates the spell tab for dangerous spells.
        /// </summary>
        /// <param name="spell">The spell.</param>
        public static void CreateTabSpellDangerousSpells(this AutoSpell spell, int usePct)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            spell.SpellGroupTab.AddItem(
                spell.SpellSwitch[tabName + "dangernorm"] = new Switch
                {
                    IsOn = usePct > 60,
                    Title = "Use on Dangerous (Spells)"
                });
            
            spell.SpellGroupTab.AddItem(
                spell.SpellSwitch[tabName + "dangercc"] = new Switch
                {
                    IsOn = usePct > 40,
                    Title = "Use on CrowdControl (Spells)"
                });
            
            spell.SpellGroupTab.AddItem(
                spell.SpellSwitch[tabName + "dangerextr"] = new Switch
                {
                    IsOn = true,
                    Title = "Use on Dangerous (Ultimates Only)"
                });
        }

        /// <summary>
        ///     Creates the spell tab aura cleanse.
        /// </summary>
        /// <param name="spell">The spell.</param>
        public static void CreateSpellTabAuraCleanse(this AutoSpell spell)
        {
            var tabName = spell.IsSummonerSpell ? spell.ChampionName : spell.ChampionName + spell.Slot;
            spell.SpellGroupTab.AddItem(spell.SpellCounter[tabName + "MinimumBuffs"] = new Counter
            {
                Title = "Minimum Buffs to Use",
                MaxValue = 5,
                MinValue = 1,
                Value = 1,
                ValueFrequency = 1
            });

            spell.SpellGroupTab.AddItem(spell.SpellCounter[tabName + "MinimumBuffsDuration"] = new Counter
            {
                Title = "Minimum Buff Duration (in ms)",
                MaxValue = 2000,
                MinValue = 250,
                Value = 1000,
                ValueFrequency = 250
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "SwitchMinimumBuffHP"] = new Switch
            {
                IsOn = false,
                Title = "Enable Minimum HP (%) to Use"
            });

            spell.SpellGroupTab.AddItem(spell.SpellCounter[tabName + "MinimumBuffsHP"] = new Counter
            {
                Title = "Minimum HP (%) to Use",
                MaxValue = 100,
                MinValue = 20,
                Value = 65,
                ValueFrequency = 15
            });
            
            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Ignite"] = new Switch
            {
                IsOn = true,
                Title = "-> Ignite"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Exhaust"] = new Switch
            {
                IsOn = true,
                Title = "-> Exhaust"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Suppression"] = new Switch
            {
                IsOn = true,
                Title = "-> Suppression"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Knockups"] = new Switch
            {
                IsOn = false,
                Title = "-> Knockups"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Sleep"] = new Switch
            {
                IsOn = true,
                Title = "-> Sleep"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Stuns"] = new Switch
            {
                IsOn = true,
                Title = "-> Stuns"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Charms"] = new Switch
            {
                IsOn = true,
                Title = "-> Charms"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Taunts"] = new Switch
            {
                IsOn = true,
                Title = "-> Taunts"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Fear"] = new Switch
            {
                IsOn = true,
                Title = "-> Fear"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Snares"] = new Switch
            {
                IsOn = true,
                Title = "-> Snares"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Polymorphs"] = new Switch
            {
                IsOn = true,
                Title = "-> Polymorphs"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Silence"] = new Switch
            {
                IsOn = false,
                Title = "-> Silence"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Blinds"] = new Switch
            {
                IsOn = false,
                Title = "-> Blinds"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Slows"] = new Switch
            {
                IsOn = false,
                Title = "-> Slows"
            });

            spell.SpellGroupTab.AddItem(spell.SpellSwitch[tabName + "Poison"] = new Switch
            {
                IsOn = false,
                Title = "-> Poison"
            });
        }

        /// <summary>
        ///     Creates the item tab enable switch.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void CreateItemTabEnableSwitch(this ActiveItem item)
        {
            item.ItemGroupTab = new Tab
            {
                Title = Lists.TranslationEng[item.ItemId]
            };

            item.ItemGroupTab.AddItem(item.ItemSwitch[item.ItemId.ToString()] = new Switch
            {
                IsOn = true,
                Title = "Use " + Lists.TranslationEng[item.ItemId]
            });

            item.ItemTab.AddItem(item.ItemGroupTab);
        }

        /// <summary>
        ///     Creates the item tab binding.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void CreateItemTabBindingUnit(this ActiveItem item)
        {
            item.ItemGroupTab.AddItem(item.ItemModeDisplay[item.ItemId + "mode"] = new ModeDisplay
            {
                Title = "Use " + Lists.TranslationEng[item.ItemId] + " priority unit: ",
                ModeNames = { "MostAD", "MaxHP" },
                SelectedModeName = "MostAD"
            });
        }

        /// <summary>
        ///     Creates the item tab for enemy low health.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateItemTabEnemyLowHealth(this ActiveItem item, int pctUse = 95)
        {
            item.ItemGroupTab.AddItem(item.ItemCounter[item.ItemId + "ehp"] = new Counter
            {
                Title = "Use " + Lists.TranslationEng[item.ItemId] + " at Enemy Percent HP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            });
        }

        /// <summary>
        ///     Creates the item tab for ally low health.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateItemTabAllyLowHealth(this ActiveItem item, int pctUse = 80)
        {
            item.ItemGroupTab.AddItem(item.ItemCounter[item.ItemId + "ahp"] = new Counter
            {
                Title = "Use " + Lists.TranslationEng[item.ItemId] + " at Ally Percent HP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            });
        }

        /// <summary>
        ///     Creates the item tab for ally low mana.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateItemTabAllyLowMana(this ActiveItem item, int pctUse = 55)
        {
            item.ItemGroupTab.AddItem(item.ItemCounter[item.ItemId + "amp"] = new Counter
            {
                Title = "Use " + Lists.TranslationEng[item.ItemId] + " at Ally Percent MP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            });
        }

        /// <summary>
        ///     Creates the item tab for aoe count.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateItemCheckProximityCount(this ActiveItem item, int pctUse = 2)
        {
            item.ItemGroupTab.AddItem(item.ItemCounter[item.ItemId + "aoe"] = new Counter
            {
                Title = "Use " + Lists.TranslationEng[item.ItemId] + " when Enemies Near >=",
                MaxValue = 5,
                MinValue = 1,
                Value = pctUse,
                ValueFrequency = 1
            });
        }

        /// <summary>
        ///     Creates the item tab for dangerous spells.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void CreateTabItemDangerousSpells(this ActiveItem item, int usePct)
        {
            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "dangernorm"] = new Switch
                {
                    IsOn = usePct > 60,
                    Title = "Use on Dangerous (Spells)"
                });
            
            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "dangercc"] = new Switch
                {
                    IsOn = usePct > 40,
                    Title = "Use on CrowdControl (Spells)"
                });
            
            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "dangerextr"] = new Switch
                {
                    IsOn = true,
                    Title = "Use on Dangerous (Ultimates Only)"
                });
        }
        

        /// <summary>
        ///     Creates the item tab for aura cleanse.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="pctUse">The PCT use.</param>
        public static void CreateItemTabAuraCleanse(this ActiveItem item, int pctUse = 100)
        {
            item.ItemGroupTab.AddItem(
                item.ItemCounter[item.ItemId + "MinimumBuffs"] = new Counter
                {
                    Title = "Minimum Buffs to Use",
                    MaxValue = 5,
                    MinValue = 1,
                    Value = 1,
                    ValueFrequency = 1
                });

            item.ItemGroupTab.AddItem(
                item.ItemCounter[item.ItemId + "MinimumBuffsDuration"] = new Counter
                {
                    Title = "Minimum Buff Duration (in ms)",
                    MaxValue = 2000,
                    MinValue = 250,
                    Value = 1000,
                    ValueFrequency = 250
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "SwitchMinimumBuffHP"] = new Switch
                {
                    IsOn = false,
                    Title = "Enable Minimum HP (%) to Use"
                });

            item.ItemGroupTab.AddItem(
                item.ItemCounter[item.ItemId + "MinimumBuffsHP"] = new Counter
                {
                    Title = "Minimum HP (%) to Use",
                    MaxValue = 100,
                    MinValue = 20,
                    Value = 65,
                    ValueFrequency = 15
                });
            
            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Ignite"] = new Switch
                {
                    IsOn = true,
                    Title = "-> Ignite"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Exhaust"] = new Switch
                {
                    IsOn = true,
                    Title = "-> Exhaust"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Suppression"] = new Switch
                {
                    IsOn = true,
                    Title = "-> Suppression"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Knockups"] = new Switch
                {
                    IsOn = false,
                    Title = "-> Knockups"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Sleep"] = new Switch
                {
                    IsOn = true,
                    Title = "-> Sleep"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Stuns"] = new Switch
                {
                    IsOn = true,
                    Title = "-> Stuns"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Charms"] = new Switch
                {
                    IsOn = true,
                    Title = "-> Charms"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Taunts"] = new Switch
                {
                    IsOn = true,
                    Title = "-> Taunts"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Fear"] = new Switch
                {
                    IsOn = true,
                    Title = "-> Fear"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Snares"] = new Switch
                {
                    IsOn = true,
                    Title = "-> Snares"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Polymorphs"] = new Switch
                {
                    IsOn = true,
                    Title = "-> Polymorphs"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Silence"] = new Switch
                {
                    IsOn = false,
                    Title = "-> Silence"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Blinds"] = new Switch
                {
                    IsOn = false,
                    Title = "-> Blinds"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Slows"] = new Switch
                {
                    IsOn = false,
                    Title = "-> Slows"
                });

            item.ItemGroupTab.AddItem(
                item.ItemSwitch[item.ItemId + "Poison"] = new Switch
                {
                    IsOn = false,
                    Title = "-> Posion"
                });
        }

        #endregion
    }
}