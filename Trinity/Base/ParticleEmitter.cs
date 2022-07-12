namespace Trinity.Base
{
    #region
    
    using System.Collections.Generic;
    using Helpers;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK;
    using Oasys.SDK.Tools;

    #endregion

    public class ParticleEmitter : ParticleEmitterBase
    {
        
        /// <summary>
        ///     Gets or sets the interval.
        /// </summary>
        /// <value>
        ///     The interval.
        /// </value>
        public double Interval { get; set; }

        /// <summary>
        ///     Gets or sets the emulation type.
        /// </summary>
        /// <value>
        ///     The emulation type.
        /// </value>
        public EmulationType EmulationType { get; set; }

        /// <summary>
        ///     Gets or sets the start tick.
        /// </summary>
        /// <value>
        ///     The start.
        /// </value>
        public float CreatedTickTime { get; set; }

        /// <summary>
        ///     Gets or sets the delay from start.
        /// </summary>
        /// <value>
        ///     The delay from start.
        /// </value>
        public float DelayFromStart { get; set; }

        /// <summary>
        ///     Gets or sets the radius.
        /// </summary>
        /// <value>
        ///     The radius.
        /// </value>
        public float Radius { get; set; }

        /// <summary>
        ///     Gets or sets the object.
        /// </summary>
        /// <value>
        ///     The object.
        /// </value>
        public GameObjectBase Obj { get; set; }

        /// <summary>
        ///     Gets or sets the limiter.
        /// </summary>
        /// <value>
        ///     The limiter.
        /// </value>
        public int Limiter { get; set; }

        /// <summary>
        ///     Gets or sets the troy name.
        /// </summary>
        /// <value>
        ///     The troy name.
        /// </value>
        public string Name { get; set; }

        
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ParticleEmitter" /> class.
        /// </summary>
        /// <param name="champ">The champion</param>
        /// <param name="name">The name.</param>
        /// <param name="slot">The slot.</param>
        /// <param name="inculded">if set to <c>true</c> [inculded].</param>
        public ParticleEmitter(string champ, string name, float radius, double interval = 0.5, float delay = 0, EmulationType etype = EmulationType.None)
        {
            Name = name;
            Radius = radius;
            ChampionString = champ;
            Interval = interval;
            DelayFromStart = delay;
            EmulationType = etype;
        }

        #endregion

        #region Override Methods

        /// <summary>
        ///     Called when [core on tick].
        /// </summary>
        public override void OnTick()
        {
            foreach (var b in Bootstrap.Allies)
            {
                var unit = b.Value;
                if (!Included) continue;

                if (Obj == null)
                {
                    Included = false;
                    break;
                }

                if (unit.Instance.Position.Distance(Obj.Position) <= Radius + unit.Instance.UnitComponentInfo.UnitBoundingRadius + 35)
                    // check delay (e.g fizz bait)
                    if ((int)(GameEngine.GameTime * 1000) - CreatedTickTime >= DelayFromStart)
                        // limit the damage using an interval
                        if ((int)(GameEngine.GameTime * 1000) - Limiter >= Interval * 1000)
                        {
                            unit.InWayDanger = true;
                            unit.InExtremeDanger = EmulationType.Equals(EmulationType.Ultimate);
                            Limiter = (int) (GameEngine.GameTime * 1000);
                        }
            }
        }

        public override void CreateTab()
        {
            // todo:
        }

        /// <summary>
        ///     Called when [core on create].
        /// </summary>
        public override void OnCreate(List<AIBaseClient> objList, AIBaseClient obj, float callbackGameTime)
        {
            if (obj.Name.ToLower().Contains(Name.ToLower()))
            {
                Obj = obj;
                CreatedTickTime = (int) (GameEngine.GameTime * 1000);
                Included = true;
                //Logger.Log(obj.Name.ToLower() + " : created");
            }
        }

        /// <summary>
        ///     Called when [core on delete].
        /// </summary>
        public override void OnDelete(List<AIBaseClient> objList, AIBaseClient obj, float callbackGameTime)
        {
            if (obj.Name.ToLower().Contains(Name.ToLower()))
            {
                Obj = null;
                CreatedTickTime = 0;
                Included = false;
                Limiter = 0;
                //Logger.Log(obj.Name.ToLower() + " : deleted");
            }
        }

        #endregion
    }
}