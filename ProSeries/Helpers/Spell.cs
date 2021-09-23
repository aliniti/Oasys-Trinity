using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oasys.Common.Enums.GameEnums;
using Oasys.Common.GameObject.Clients.ExtendedInstances.Spells;
using Oasys.SDK;

namespace ProSeries.Helpers
{
    public class Spell
    {
        public float Delay { get; set; }
        public float Range { get; set; }
        public float Speed { get; set; }
        public float Width { get; set; }

        public float[] Mana { get; set; }
        public bool Collision { get; set; }

        public SpellSlot Slot { get; set; }
        public SpellClass SpellClass { get; set; }

        public Spell(SpellSlot slot, float[] mana, float range)
        {
            this.Mana = mana;
            this.Slot = slot;
            this.SpellClass = UnitManager.MyChampion.GetSpellBook().GetSpellClass(slot);
            this.Range = range;
        }

        public Spell SetSkillShot(float delay, float width, float speed, bool collision)
        {
            this.Delay = delay;
            this.Width = width;
            this.Speed = speed;
            this.Collision = collision;
            return this;
        }
    }
}
