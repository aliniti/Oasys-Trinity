namespace Trinity.Helpers
{
    using Oasys.Common.Menu.ItemComponents;
    using Items;
    using Oasys.Common.Menu;
    using Spells;

    public static class Menu
    {
        #region Spell Tabs

        public static void CreateSpellTabEnableSwitch(this AutoSpell spell)
        {
            var tabName = spell.ChampionName + spell.Slot;
            spell.SpellSwitch[tabName] = new Switch()
            {
                IsOn = true,
                Title = "Use " + tabName
            };

            spell.SpellTab.AddItem(spell.SpellSwitch[tabName]);
        }

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

        public static void CreateSpellTabAuraCleanse(this AutoSpell spell)
        {
            var tabName = spell.ChampionName + spell.Slot;
            spell.SpellGroup[tabName + "buffs"] = new Group
            {
                Title = tabName
            };

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Ignite"] = new()
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Ignite"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Exhaust"] = new()
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Exhaust"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Suppression"] = new()
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Suppression"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Knockups"] = new()
                {
                    IsOn = false,
                    Title = "Use " + tabName + " -> Knockups"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Sleep"] = new()
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Sleep"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Stuns"] = new()
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Stuns"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Charms"] = new()
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Charms"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Taunts"] = new()
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Taunts"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Fear"] = new()
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Fear"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Snares"] = new()
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Snares"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Polymorphs"] = new()
                {
                    IsOn = true,
                    Title = "Use " + tabName + " -> Polymorphs"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Silence"] = new()
                {
                    IsOn = false,
                    Title = "Use " + tabName + " -> Silence"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Blinds"] = new()
                {
                    IsOn = false,
                    Title = "Use " + tabName + " -> Blinds"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Slows"] = new()
                {
                    IsOn = false,
                    Title = "Use " + tabName + " -> Slows"
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "Poison"] = new()
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
                    Value = 250,
                    ValueFrequency = 50
                });

            spell.SpellGroup[tabName + "buffs"].AddItem(
                spell.SpellSwitch[tabName + "SwitchMinimumBuffHP"] = new()
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

        #endregion

        #region Ignite Tabs

        public static void CreateIgniteTabs(this AutoSpell spell)
        {
            spell.SpellSwitch["igcombo"] = new Switch()
            {
                IsOn = true,
                Title = "Ignite on Combo"
            };

            spell.SpellTab.AddItem(spell.SpellSwitch["igcombo"]);
            
            spell.SpellCounter["igminhp"] = new Counter
            {
                Title = "Ignite Min Target HP % <=",
                MaxValue = 100,
                MinValue = 5,
                Value = 15,
                ValueFrequency = 5
            };

            spell.SpellTab.AddItem(spell.SpellCounter["igminhp"]);

            spell.SpellCounter["igmaxhp"] = new Counter
            {
                Title = "Ignite Max Target HP % <=",
                MaxValue = 100,
                MinValue = 5,
                Value = 70,
                ValueFrequency = 5
            };

            spell.SpellTab.AddItem(spell.SpellCounter["igmaxhp"]);

            spell.SpellSwitch["igks"] = new Switch()
            {
                IsOn = true,
                Title = "Ignite to KS"
            };

            spell.SpellTab.AddItem(spell.SpellSwitch["igks"]);
        }

        #endregion

        #region Item Tabs

        public static void CreateItemTabEnableSwitch(this ActiveItem item)
        {
            item.ItemSwitch[item.ItemId.ToString()] = new Switch
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId]
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId.ToString()]);
        }

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

        public static void CreateItemTabAuraCleanse(this ActiveItem item, int pctUse = 100)
        {
            item.ItemGroup[item.ItemId + "buffs"] = new Group
            {
                Title = Translations.ItemNames[item.ItemId] + "",
            };

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Ignite"] = new()
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Ignite"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Exhaust"] = new()
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Exhaust"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Suppression"] = new()
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Suppression"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Knockups"] = new()
            {
                IsOn = false,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Knockups"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Sleep"] = new()
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Sleep"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Stuns"] = new()
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Stuns"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Charms"] = new()
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Charms"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Taunts"] = new()
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Taunts"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Fear"] = new()
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Fear"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Snares"] = new()
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Snares"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Polymorphs"] = new()
            {
                IsOn = true,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Polymorphs"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Silence"] = new()
            {
                IsOn = false,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Silence"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Blinds"] = new()
            {
                IsOn = false,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Blinds"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Slows"] = new()
            {
                IsOn = false,
                Title = "Use " + Translations.ItemNames[item.ItemId] + " -> Slows"
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "Poison"] = new()
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
                Value = 250,
                ValueFrequency = 50
            });

            item.ItemGroup[item.ItemId + "buffs"].AddItem(
                item.ItemSwitch[item.ItemId + "SwitchMinimumBuffHP"] = new()
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