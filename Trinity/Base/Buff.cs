namespace Trinity.Base
{
    using System.Linq;
    using Helpers;
    using Oasys.Common;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.Extensions;
    using Oasys.Common.Menu.ItemComponents;
    using Oasys.SDK;
    using Oasys.SDK.Tools;

    public class Buff : BuffBase
    {
        /// <summary>
        ///     Gets or sets the interval.
        /// </summary>
        /// <value>
        ///     The interval.
        /// </value>
        public double Interval { get; set; }
        
        /// <summary>
        ///     Gets or sets the limiter.
        /// </summary>
        /// <value>
        ///     The limiter.
        /// </value>
        public int Limiter { get; set; }

        /// <summary>
        ///     Gets or sets the emulation type.
        /// </summary>
        /// <value>
        ///     The emulation type.
        /// </value>
        public EmulationFlags EmulationFlags { get; set; }
        
        /// <summary>
        ///     Gets or sets the delay from start.
        /// </summary>
        /// <value>
        ///     The delay from start.
        /// </value>
        public float Delay { get; set; }
        
        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        /// <value>
        ///     The radius.
        /// </value>
        public float Radius { get; set; }
        
        /// <summary>
        ///     Gets or sets the aura name.
        /// </summary>
        /// <value>
        ///     The aura name.
        /// </value>
        public string Name { get; set; }
        

        /// <summary>
        ///     Initializes a new instance of the <see cref="Buff"/> class
        /// </summary>
        /// <param name="champion"></param>
        /// <param name="name"></param>
        /// <param name="interval"></param>
        /// <param name="delay"></param>
        /// <param name="emulationFlags"></param>
        public Buff(string champion, string name, double interval = 0.5, float delay = 0, EmulationFlags emulationFlags = EmulationFlags.None)
        {
            ChampionString = champion;
            Interval = interval;
            EmulationFlags = emulationFlags;
            Delay = delay;
            Name = name;
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Buff"/> class
        /// </summary>
        /// <param name="champion"></param>
        /// <param name="name"></param>
        /// <param name="radius"></param>
        /// <param name="interval"></param>
        /// <param name="delay"></param>
        /// <param name="emulationFlags"></param>
        public Buff(string champion, string name, float radius, double interval = 0.69, float delay = 0, EmulationFlags emulationFlags = EmulationFlags.None)
        {
            ChampionString = champion;
            Interval = interval;
            EmulationFlags = emulationFlags;
            Delay = delay;
            Radius = radius;
            Name = name;
        }

        public override void OnTick()
        {
            foreach (var b in Bootstrap.Allies)
            {
                // gets the value in the key/value pair
                var unit = b.Value;
                
                // todo: failsafe: need a better way to implement this
                if ((int) (GameEngine.GameTime * 1000) - unit.AggroTick > 500)
                {
                    unit.ResetAggro();
                }
                
                if (!BuffSwitch[Name + "ene"].IsOn) continue;
                if (!Interval.Equals(0.69))
                {
                    var buff = unit.Instance.BuffManager.GetActiveBuff(Name);
                    if (buff != null && buff.IsActive)
                    {
                        var gameTime = (int) (GameEngine.GameTime * 1000);
                        var buffTime = (int) (buff.StartTime * 1000);

                        // check delay (e.g zed ult)
                        if (gameTime - buffTime >= Delay)
                        {
                            if ((int) (GameEngine.GameTime * 1000) - Limiter >= Interval * 1000)
                            {
                                unit.InDanger = EmulationFlags.Equals(EmulationFlags.Danger);
                                unit.InCrowdControl = EmulationFlags.Equals(EmulationFlags.CrowdControl);
                                unit.InExtremeDanger = EmulationFlags.Equals(EmulationFlags.Ultimate);
                                unit.AggroTick = (int) (GameEngine.GameTime * 1000);
                                unit.HasAggro = true;

                                Limiter = (int) (GameEngine.GameTime * 1000);
                            }
                        }
                    }
                }
                else
                {
                    CheckReverseBuff(unit);
                }
            }
        }

        public override void CreateTab()
        {
            this.BuffSwitch[Name + "ene"] = new Switch
            {
                IsOn = true,
                Title = "[buff] Predict " + Name.ToLower()
            };
            
            this.BuffTab.AddItem(BuffSwitch[Name + "ene"]);
        }

        public void CheckReverseBuff(Champion champion)
        {
            var ene = Bootstrap.Enemies.Select(x => x.Value).FirstOrDefault();
            if (ene != null && ene.Instance.BuffManager.HasActiveBuff(Name))
            {
                var buff = ene.Instance.BuffManager.GetActiveBuff(Name);
                if (buff != null && buff.IsActive)
                {
                    var gameTime = (int) (GameEngine.GameTime * 1000);
                    var buffTime = (int) (buff.StartTime * 1000);

                    if (champion.Instance.Distance(ene.Instance) <= Radius + champion.Instance.UnitComponentInfo.UnitBoundingRadius)
                    {
                        // check delay (e.g zed ult)
                        if (gameTime - buffTime >= Delay)
                        {
                            if ((int) (GameEngine.GameTime * 1000) - Limiter >= Interval * 1000)
                            {
                                champion.InDanger = EmulationFlags.Equals(EmulationFlags.Danger);
                                champion.InCrowdControl = EmulationFlags.Equals(EmulationFlags.CrowdControl);
                                champion.InExtremeDanger = EmulationFlags.Equals(EmulationFlags.Ultimate);
                                champion.AggroTick = (int) (GameEngine.GameTime * 1000);
                                champion.HasAggro = true;

                                Limiter = (int) (GameEngine.GameTime * 1000);
                            }
                        }
                    }
                }
            }
        }
    }
}