namespace Trinity.Helpers
{
    using System.Collections.Generic;
    using Oasys.Common.GameObject.Clients;

    public class Champion
    {
        public AIHeroClient Instance { get; set; }
        public Dictionary<string, int> AuraInfo;

        public Champion(AIHeroClient hero)
        {
            Instance = hero;
            AuraInfo = new Dictionary<string, int>();
        }
    }
}
