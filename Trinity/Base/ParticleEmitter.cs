namespace Trinity.Base
{
    #region

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Oasys.Common.EventsProvider;
    using Oasys.Common.GameObject;
    using Oasys.Common.GameObject.Clients;
    using Oasys.SDK;

    #endregion

    /// <summary>
    ///     The particle emitter class responsible for in-game troys
    /// </summary>
    public class ParticleEmitter
    {
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

            GameEvents.OnCreateObject += GameEvents_OnCreateObject;
            GameEvents.OnDeleteObject += GameEvents_OnDeleteObject;
            CoreEvents.OnCoreMainTick += CoreEvents_OnCoreMainTick;
        }

        #endregion

        #region Private Methods and Operators

        /// <summary>
        ///     Cores events [on core main tick].
        /// </summary>
        private async Task CoreEvents_OnCoreMainTick()
        {
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
                Included = true;
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