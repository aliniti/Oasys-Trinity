namespace Trinity.Base
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK.Events;

    public class Champion
    {
        public AIHeroClient Instance { get; set; }
        public Dictionary<string, int> AuraInfo;
        public Dictionary<uint, Spell> ActiveSpells = new();

        public Champion(AIHeroClient instance)
        {
            Instance = instance;
            AuraInfo = new Dictionary<string, int>();

            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
        }

        private async Task CoreEvents_OnCoreMainTick()
        {
            if (Instance != null && Instance.IsAlive && Instance.IsCastingSpell)
            {
                ActiveSpells[Instance.NetworkID] = new Spell();
            }
        }

        internal void IsGettingHitBySpell()
        {

        }
    }
}
