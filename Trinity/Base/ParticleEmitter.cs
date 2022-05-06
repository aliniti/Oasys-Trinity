namespace Trinity.Base
{
    using System.Collections.Generic;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.GameObject;

    public class ParticleEmitter
    {
        #region Static Fields and Constants

        /// <summary>
        ///     The emitters
        /// </summary>
        public static List<ParticleEmitter> Emitters = new();

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ParticleEmitter" /> class.
        /// </summary>
        /// <param name="ownerId">The ownerId.</param>
        /// <param name="slot">The slot.</param>
        /// <param name="name">The name.</param>
        /// <param name="start">The start.</param>
        /// <param name="inculded">if set to <c>true</c> [inculded].</param>
        /// <param name="incdmg">The incdmg.</param>
        /// <param name="obj">The object.</param>
        public ParticleEmitter(uint ownerId, SpellSlot slot, string name, int start, bool inculded, int incdmg = 0, GameObjectBase obj = null)
        {
            OwnerId = ownerId;
            Slot = slot;
            Start = start;
            Name = name;
            Obj = obj;
            Included = inculded;
            Damage = incdmg;
        }

        #endregion

        #region Fields

        /// <summary>
        ///     The damage
        /// </summary>
        public int Damage;

        /// <summary>
        ///     The included
        /// </summary>
        public bool Included;

        /// <summary>
        ///     The limiter
        /// </summary>
        public int Limiter;

        /// <summary>
        ///     The name
        /// </summary>
        public string Name;

        /// <summary>
        ///     The object
        /// </summary>
        public GameObjectBase Obj;

        /// <summary>
        ///     The ownerId
        /// </summary>
        public uint OwnerId;

        /// <summary>
        ///     The slot
        /// </summary>
        public SpellSlot Slot;

        /// <summary>
        ///     The start tick
        /// </summary>
        public int Start;

        #endregion
    }
}