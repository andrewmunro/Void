namespace BlackRain.Common.Objects
{
    /// <summary>
    /// An Object. Everything that inherits from WowObject, such as an item, is also an object.
    /// But an object is not necessarily an item.
    /// </summary>
    public class WowObject
    {
        /// <summary>
        /// The Base Address of the object.
        /// </summary>
        public uint BaseAddress { get; set;}

        /// <summary>
        /// Instantiates a new WowObject.
        /// </summary>
        /// <param name="baseAddress">The Object's Base Address.</param>
        public WowObject(uint baseAddress)
        {
            BaseAddress = baseAddress;
        }

        /// <summary>
        /// The object's GUID.
        /// </summary>
        public virtual ulong GUID
        {
            get { return GetStorageField<ulong>((uint)Offsets.WowObjectFields.OBJECT_FIELD_GUID); }
        }

        /// <summary>
        /// The object's Type.
        /// </summary>
        public int Type
        {
            get { return ObjectManager.Memory.ReadInt(BaseAddress + 0x10); }
        }

        /// <summary>
        /// The object's Entry.
        /// </summary>
        public uint Entry
        {
            get { return GetStorageField<uint>((uint)Offsets.WowObjectFields.OBJECT_FIELD_ENTRY); }
        }

        /// <summary>
        /// The object's level.
        /// </summary>
        public int Level
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_LEVEL); }
        }

        /// <summary>
        /// Returns the object's X position.
        /// </summary>
        public virtual float X
        {
            get { return ObjectManager.Memory.ReadFloat(BaseAddress + (uint)Offsets.WowObject.X); }
        }

        /// <summary>
        /// Returns the object's Y position.
        /// </summary>
        public virtual float Y
        {
            get { return ObjectManager.Memory.ReadFloat(BaseAddress + (uint)Offsets.WowObject.Y); }
        }

        /// <summary>
        /// Returns the object's Z position.
        /// </summary>
        public virtual float Z
        {
            get { return ObjectManager.Memory.ReadFloat(BaseAddress + (uint)Offsets.WowObject.Z); }
        }

        /// <summary>
        /// Returns the Facing orientation.
        /// </summary>
        public virtual float Facing
        {
            get { return ObjectManager.Memory.ReadFloat(BaseAddress + (uint)Offsets.WowObject.Rotation); }
        }

        /// <summary>
        /// Determines if the unit is our local player.
        /// </summary>
        public bool IsMe
        {
            get { return GUID == ObjectManager.Me.GUID ? true : false; }
        }

        /// <summary>
        /// OBJECT_FIELD_SCALE_X
        /// </summary>
        public int Scale_X
        {
            get
            {
                return GetStorageField<int>((uint)Offsets.WowObjectFields.OBJECT_FIELD_SCALE_X);
            }
        }

        /// <summary>
        /// The objects padding.
        /// </summary>
        public int Padding
        {
            get
            {
                return GetStorageField<int>((uint)Offsets.WowObjectFields.OBJECT_FIELD_PADDING);
            }
        }

        #region <Storage Field Methods>

        /// <summary>
        /// Gets the descriptor struct.
        /// </summary>
        /// <typeparam name="T">struct</typeparam>
        /// <param name="field">Descriptor field</param>
        /// <returns>Descriptor field</returns>
        protected T GetStorageField<T>(uint field) where T : struct
        {
            field *= 4;
            var m_pStorage = ObjectManager.Read<uint>(BaseAddress + 0x8);

            // Uses legacy reading because of errors.
            return (T)ObjectManager.Memory.ReadObject(m_pStorage + field, typeof(T));
        }

        /// <summary>
        /// Gets the descriptor struct.
        /// Overload for when not casting uint.
        /// </summary>
        /// <typeparam name="T">struct</typeparam>
        /// <param name="field">Descriptor field</param>
        /// <returns>Descriptor field</returns>
        protected T GetStorageField<T>(Offsets.WowObjectFields field) where T : struct
        {
            return GetStorageField<T>((uint)field);
        }

        #endregion
    }
}
