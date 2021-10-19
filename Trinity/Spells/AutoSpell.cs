using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.Spells
{
    using Helpers;
    using Oasys.Common.Enums.GameEnums;

    public class AutoSpell : AutoSpellBase
    {
        public int UsePct { get; set; }
        public int LastUsedTimeStamp { get; set; }

        public Enums.ActivationType[] ActivationTypes { get; set; }
        public Enums.TargetingType TargetingType { get; set; }

        public AutoSpell(int usePct, string championName, SpellSlot slot, Enums.TargetingType tType, float range, 
            Enums.ActivationType[] aType)
        {
            ChampionName = championName;
            Slot = slot;
            TargetingType = tType;
            ActivationTypes = aType;
            Range = range;
            UsePct = usePct;
        }

        public override void CreateTab()
        {
            // the enable disable switch
            this.CreateSpellTabEnableSwitch();

            if (ActivationTypes.Contains(Enums.ActivationType.CheckAllyLowHP))
                this.CreateSpellTabAllyLowHealth(UsePct);
        }

        public override void OnTick()
        {
            
        }
    }
}
