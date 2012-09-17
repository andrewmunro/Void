namespace BlackRain.Common.Objects
{
    /// <summary>
    /// An item.
    /// </summary>
    public class WowItem : WowObject
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="baseAddress"></param>
        public WowItem(uint baseAddress)
            : base(baseAddress)
        {
        }

        /// <summary>
        /// The item's remaining durability.
        /// </summary>
        public int Durability
        {
            get { return GetStorageField<int>((uint)Offsets.WowItemFields.ITEM_FIELD_DURABILITY); }
        }

        /// <summary>
        /// The item's maximum durability.
        /// </summary>
        public int MaximumDurability
        {
            get { return GetStorageField<int>((uint)Offsets.WowItemFields.ITEM_FIELD_MAXDURABILITY); }
        }

        /// <summary>
        /// The amount of items stacked.
        /// </summary>
        public int StackCount
        {
            get { return GetStorageField<int>((uint)Offsets.WowItemFields.ITEM_FIELD_STACK_COUNT); }
        }

        /// <summary>
        /// The amount of charges this item has.
        /// </summary>
        public int Charges
        {
            get { return GetStorageField<int>((uint)Offsets.WowItemFields.ITEM_FIELD_SPELL_CHARGES); }
        }

        /// <summary>
        /// Does the item have charges?
        /// </summary>
        public bool HasCharges
        {
            get { return Charges > 0 ? true : false; }
        }
    }
}
