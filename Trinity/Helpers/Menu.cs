namespace Trinity.Helpers
{
    using Oasys.Common.Menu.ItemComponents;
    using Items;
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

        public static void CreateSpellTabAllyMinimumMP(this AutoSpell spell, int pctUse = 65)
        {
            var tabName = spell.ChampionName + spell.Slot;
            spell.SpellCounter[tabName + "amm"] = new Counter
            {
                Title = "Use " + tabName + " at ALLY Percent MP > (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };

            spell.SpellTab.AddItem(spell.SpellCounter[tabName + "amm"]);
        }

        #endregion

        #region Item Tabs

        public static void CreateItemTabEnableSwitch(this ActiveItem item)
        {
            item.ItemSwitch[item.ItemId.ToString()] = new Switch
            {
                IsOn = true,
                Title = "Use " + item.ItemId
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId.ToString()]);
        }

        public static void CreateItemTabEnemyLowHealth(this ActiveItem item, int pctUse = 95)
        {
            item.ItemCounter[item.ItemId + "ehp"] = new Counter
            {
                Title = "Use " + item.ItemId + " at Enemy Percent HP < (%)",
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
                Title = "Use " + item.ItemId + " at Ally Percent HP < (%)",
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
                Title = "Use " + item.ItemId + " at Ally Percent MP < (%)",
                MaxValue = 100,
                MinValue = 10,
                Value = pctUse,
                ValueFrequency = 5
            };

            item.ItemTab.AddItem(item.ItemCounter[item.ItemId + "amp"]);
        }

        public static void CreateItemTabAuraCleanse(this ActiveItem item, int pctUse = 100)
        {
            item.ItemSwitch[item.ItemId + "Ignite"] = new()
            {
                IsOn = true,
                Title = "Use " + item.ItemId + " -> Ignite"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Ignite"]);
            item.ItemSwitch[item.ItemId + "Exhaust"] = new()
            {
                IsOn = true,
                Title = "Use " + item.ItemId + " -> Exhaust"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Exhaust"]);
            item.ItemSwitch[item.ItemId + "Suppression"] = new()
            {
                IsOn = true,
                Title = "Use " + item.ItemId + " -> Suppression"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Suppression"]);
            item.ItemSwitch[item.ItemId + "Knockups"] = new()
            {
                IsOn = false,
                Title = "Use " + item.ItemId + " -> Knockups"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Knockups"]);
            item.ItemSwitch[item.ItemId + "Sleep"] = new()
            {
                IsOn = true,
                Title = "Use " + item.ItemId + " -> Sleep"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Sleep"]);
            item.ItemSwitch[item.ItemId + "Stuns"] = new()
            {
                IsOn = true,
                Title = "Use " + item.ItemId + " -> Stuns"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Stuns"]);
            item.ItemSwitch[item.ItemId + "Charms"] = new()
            {
                IsOn = true,
                Title = "Use " + item.ItemId + " -> Charms"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Charms"]);
            item.ItemSwitch[item.ItemId + "Taunts"] = new()
            {
                IsOn = true,
                Title = "Use " + item.ItemId + " -> Taunts"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Taunts"]);
            item.ItemSwitch[item.ItemId + "Fear"] = new()
            {
                IsOn = true,
                Title = "Use " + item.ItemId + " -> Fear"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Fear"]);
            item.ItemSwitch[item.ItemId + "Snares"] = new()
            {
                IsOn = true,
                Title = "Use " + item.ItemId + " -> Snares"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Snares"]);
            item.ItemSwitch[item.ItemId + "Polymorphs"] = new()
            {
                IsOn = true,
                Title = "Use " + item.ItemId + " -> Polymorphs"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Polymorphs"]);
            item.ItemSwitch[item.ItemId + "Silence"] = new()
            {
                IsOn = false,
                Title = "Use " + item.ItemId + " -> Silence"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Silence"]);
            item.ItemSwitch[item.ItemId + "Blinds"] = new()
            {
                IsOn = false,
                Title = "Use " + item.ItemId + " -> Blinds"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Blinds"]);
            item.ItemSwitch[item.ItemId + "Slows"] = new()
            {
                IsOn = false,
                Title = "Use " + item.ItemId + " -> Slows"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Slows"]);
            item.ItemSwitch[item.ItemId + "Poison"] = new()
            {
                IsOn = false,
                Title = "Use " + item.ItemId + " -> Posion"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "Poison"]);
            item.ItemCounter[item.ItemId + "MinimumBuffs"] = new Counter
            {
                Title = item.ItemId + " -> Minimum Buffs to Use",
                MaxValue = 5,
                MinValue = 1,
                Value = 1,
                ValueFrequency = 1
            };

            item.ItemTab.AddItem(item.ItemCounter[item.ItemId + "MinimumBuffs"]);
            item.ItemCounter[item.ItemId + "MinimumBuffsDuration"] = new Counter
            {
                Title = item.ItemId + " -> Minimum Buff Duration (in ms)",
                MaxValue = 2000,
                MinValue = 250,
                Value = 250,
                ValueFrequency = 50
            };

            item.ItemTab.AddItem(item.ItemCounter[item.ItemId + "MinimumBuffsDuration"]);
            item.ItemSwitch[item.ItemId + "SwitchMinimumBuffHP"] = new()
            {
                IsOn = false,
                Title = "Use " + item.ItemId + " -> Enable Minimum HP (%) to Use"
            };

            item.ItemTab.AddItem(item.ItemSwitch[item.ItemId + "SwitchMinimumBuffHP"]);
            item.ItemCounter[item.ItemId + "MinimumBuffsHP"] = new Counter
            {
                Title = item.ItemId + " -> Minimum HP (%) to Use",
                MaxValue = 100,
                MinValue = 20,
                Value = 100,
                ValueFrequency = 15
            };

            item.ItemTab.AddItem(item.ItemCounter[item.ItemId + "MinimumBuffsHP"]);
        }

        #endregion
    }
}