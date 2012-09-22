namespace BlackRain.Common.Objects
{
    /// <summary>
    /// Player corpses.
    /// </summary>
    public class WowCorpse : WowUnit
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="baseAddress"></param>
        public WowCorpse(uint baseAddress)
            : base(baseAddress)
        {
        }

        /// <summary>
        /// The corpse's owner.
        /// </summary>
        public ulong Owner
        {
            get { return GetStorageField<ulong>((uint) Offsets.WowCorpseFields.CORPSE_FIELD_OWNER); }
        }

        /// <summary>
        /// The Corpses Display ID.
        /// </summary>
        public new int DisplayID
        {
            get { return GetStorageField<int>((uint) Offsets.WowCorpseFields.CORPSE_FIELD_DISPLAY_ID); }
        }
    }
}
