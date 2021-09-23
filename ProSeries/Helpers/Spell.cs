using Oasys.Common.Enums.GameEnums;
using Oasys.Common.GameObject.Clients.ExtendedInstances.Spells;
using Oasys.SDK;

namespace ProSeries.Helpers
{
    public class Spell
    {
        public Spell(SpellSlot slot, float[] mana, float range)
        {
            Mana = mana;
            Slot = slot;
            SpellClass = UnitManager.MyChampion.GetSpellBook().GetSpellClass(slot);
            Range = range;
        }

        public float Delay { get; set; }
        public float Range { get; set; }
        public float Speed { get; set; }
        public float Width { get; set; }

        public float[] Mana { get; set; }
        public bool Collision { get; set; }

        public SpellSlot Slot { get; set; }
        public SpellClass SpellClass { get; set; }

        public Spell SetSkillShot(float delay, float width, float speed, bool collision)
        {
            Delay = delay;
            Width = width;
            Speed = speed;
            Collision = collision;
            return this;
        }
    }
}