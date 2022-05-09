namespace Trinity.Base
{
    #region

    using System.Collections.Generic;
    using Oasys.Common.Enums.GameEnums;
    using Oasys.Common.GameObject;

    #endregion

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
        ///     Gets or sets the object.
        /// </summary>
        /// <value>
        ///     The object.
        /// </value>
        public GameObjectBase Obj { get; set; }


        /// <summary>
        ///     Gets or sets the damage.
        /// </summary>
        /// <value>
        ///     The damage.
        /// </value>
        public int Damage { get; set; }

        /// <summary>
        ///     Gets or sets the start tick.
        /// </summary>
        /// <value>
        ///     The start.
        /// </value>
        public int Start { get; set; }


        /// <summary>
        ///     Gets or sets the slot.
        /// </summary>
        /// <value>
        ///     The slot.
        /// </value>
        public SpellSlot Slot { get; set; }

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
        public uint OwnerId { get; set; }

        #endregion

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
    }
}