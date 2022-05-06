namespace Trinity.Spells.UniqueSpells
{
    using Helpers;

    class Ignite : AutoSpell
    {
        public Ignite(int usePct, string championName, string spellName, Enums.TargetingType tType, float range, Enums.ActivationType[] aType) 
            : base(usePct, championName, spellName, tType, range, aType) { }

        public override void CreateTab()
        {
            this.CreateIgniteTabs();
        }

        public override void OnTick()
        {

        }
    }
}
