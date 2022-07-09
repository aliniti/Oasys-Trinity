namespace Trinity.Base
{
    #region

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Oasys.Common.Extensions;
    using Oasys.Common.GameObject;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK;
    using Oasys.SDK.Events;

    #endregion

    /// <summary>
    ///     The particle emitter class responsible for in-game troys
    /// </summary>
    public class ParticleEmitter
    {
        #region Fields

        /// <summary>
        ///     The particle emitters (troys)
        /// </summary>
        private readonly List<ParticleEmitter> ParticleEmitters = new()
        {
            new ParticleEmitter("Lux", "e_tar_aoe", 175, 0.65),
            new ParticleEmitter("Renekton", "R_buf", 266, 0.65),
            new ParticleEmitter("Nasus", "SpiritFire", 385, 0.65),
            new ParticleEmitter("Nasus", "R_Avatar", 266, 0.65),
            new ParticleEmitter("Annie", "AnnieTibbers", 266),
            new ParticleEmitter("Alistar", "E_TrampleAOE", 266),
            new ParticleEmitter("Ryze", "_E", 100),
            new ParticleEmitter("Gangplank", "_R", 400, 1.3),
            new ParticleEmitter("Morgana", "W_tar", 275, 0.75),
            new ParticleEmitter("Hecarim", "Hecarim_Defile", 400, 0.75),
            new ParticleEmitter("Hecarim", "W_AoE", 400, 0.75),
            new ParticleEmitter("Diana", "W_Shield", 225, 1),
            new ParticleEmitter("Sion", "W_Shield", 225, 1),
            new ParticleEmitter("Karthus", "E_Defile", 400, 1),
            new ParticleEmitter("Elise", "W_volatile", 250, 0.3),
            new ParticleEmitter("FiddleSticks", "Crowstorm", 400),
            new ParticleEmitter("Fizz", "Ring_Red", 300, 1, 800),
            new ParticleEmitter("Katarina", "deathLotus_tar", 500, 0.4),
            new ParticleEmitter("Nautilus", "R_sequence_impact", 250, 0.65),
            new ParticleEmitter("Kennen", "lr_buf", 250, 0.8),
            new ParticleEmitter("Kennen", "ss_aoe", 450),
            new ParticleEmitter("Caitlyn", "yordleTrap", 265),
            new ParticleEmitter("Viktor", "_ChaosStorm", 425),
            new ParticleEmitter("Viktor", "_Catalyst", 375),
            new ParticleEmitter("Viktor", "W_AUG", 375),
            new ParticleEmitter("Anivia", "cryo_storm", 400),
            new ParticleEmitter("Ziggs", "ZiggsE", 325),
            new ParticleEmitter("Ziggs", "ZiggsWRing", 325),
            new ParticleEmitter("Soraka", "E_rune", 375),
            new ParticleEmitter("Cassiopeia", "Miasma_tar", 150)
        };

        #endregion

        #region Properties and Encapsulation

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="ParticleEmitter" /> is included.
        /// </summary>
        /// <value>
        ///     <c>true</c> if included; otherwise, <c>false</c>.
        /// </value>
        public bool Included { get; set; }

        /// <summary>
        ///     Gets or sets the interval.
        /// </summary>
        /// <value>
        ///     The interval.
        /// </value>
        public double Interval { get; set; }

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
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        ///     The owner identifier.
        /// </value>
        public string Champion { get; set; }

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ParticleEmitter" /> class.
        /// </summary>
        /// <param name="champ">The champion</param>
        /// <param name="name">The name.</param>
        /// <param name="slot">The slot.</param>
        /// <param name="inculded">if set to <c>true</c> [inculded].</param>
        public ParticleEmitter(string champ, string name, float radius, double interval = 0.5, float delay = 0)
        {
            Name = name;
            Radius = radius;
            Champion = champ;
            Interval = interval;
            DelayFromStart = delay;

            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
            GameEvents.OnCreateObject += GameEvents_OnCreateObject;
            GameEvents.OnDeleteObject += GameEvents_OnDeleteObject;
        }

        #endregion

        #region Private Methods and Operators

        /// <summary>
        ///     Cores events [on core main tick].
        /// </summary>
        private async Task CoreEvents_OnCoreMainTick()
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
                {
                    // check delay (e.g fizz bait)
                    if ((int)(GameEngine.GameTime * 1000) - CreatedTickTime >= DelayFromStart)
                        // limit the damage using an interval
                        if ((int)(GameEngine.GameTime * 1000) - Limiter >= Interval * 1000)
                            unit.InWayDanger = true;
                }
                else
                {
                    unit.InWayDanger = false;
                    break;
                }
            }
        }

        /// <summary>
        ///     Games events [on create object].
        /// </summary>
        /// <param name="objList">The object list.</param>
        /// <param name="obj">The object.</param>
        /// <param name="callbackGameTime">The callback game time.</param>
        private async Task GameEvents_OnCreateObject(List<AIBaseClient> objList, AIBaseClient obj, float callbackGameTime)
        {
            if (obj.Name.ToLower().Contains(Name.ToLower()))
            {
                Obj = obj;
                CreatedTickTime = (int) (GameEngine.GameTime * 1000);
                Included = Bootstrap.Enemies.Values.Find(x => x.Instance.ModelName == Champion) != null;
                //Logger.Log(obj.Name.ToLower() + " : created");
            }
        }

        /// <summary>
        ///     Games events [on delete object].
        /// </summary>
        /// <param name="objList">The object list.</param>
        /// <param name="obj">The object.</param>
        /// <param name="callbackGameTime">The callback game time.</param>
        private async Task GameEvents_OnDeleteObject(List<AIBaseClient> objList, AIBaseClient obj, float callbackGameTime)
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