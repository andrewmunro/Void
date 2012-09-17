namespace BlackRain.Common.Objects
{
    /// <summary>
    /// Represents your player (character).
    /// </summary>
    public class WowPlayerMe : WowPlayer
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="baseAddress"></param>
        public WowPlayerMe(uint baseAddress)
            : base (baseAddress)
        {
        }

        /// <summary>
        /// Your character's current Zone.
        /// </summary>
        public string Zone
        {
            get
            {
                return ObjectManager.Memory.ReadASCIIString(ObjectManager.ReadRelative<uint>((uint)Offsets.WowPlayerMe.Zone), 255);
            }
        }

        /// <summary>
        /// Your character's current SubZone.
        /// </summary>
        public string SubZone
        {
            get
            {
                return ObjectManager.Memory.ReadASCIIString(ObjectManager.ReadRelative<uint>((uint)Offsets.WowPlayerMe.SubZone), 255);
            }
        }

        /// <summary>
        /// Your character's money.
        /// </summary>
        public int Copper
        {
            get { return GetStorageField<int>((uint)Offsets.WowPlayerFields.PLAYER_FIELD_COINAGE); }
        }

        /// <summary>
        /// Gets the silver.
        /// </summary>
        /// <value>The silver.</value>
        /// 19/10/2010 17:57
        public int Silver { get { return Copper/100; } }

        /// <summary>
        /// Gets the gold.
        /// </summary>
        /// <value>The gold.</value>
        /// 19/10/2010 17:57
        public int Gold { get { return Silver/100; } }
    }
}
