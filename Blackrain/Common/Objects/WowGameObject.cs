namespace BlackRain.Common.Objects
{
    /// <summary>
    /// A Game Object, such as a herb, but also a treasure box.
    /// </summary>
    public class WowGameObject : WowObject
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="baseAddress"></param>
        public WowGameObject(uint baseAddress)
            : base(baseAddress)
        {
        }

        /// <summary>
        /// The GameObject's Display ID.
        /// </summary>
        public int DisplayID
        {
            get { return GetStorageField<int>((uint)Offsets.WowGameObjectFields.GAMEOBJECT_DISPLAYID); }
        }

        /// <summary>
        /// The GameObject's faction.
        /// </summary>
        public int Faction
        {
            get { return GetStorageField<int>((uint)Offsets.WowGameObjectFields.GAMEOBJECT_FACTION); }
        }

        /// <summary>
        /// The GameObject's level.
        /// </summary>
        public new int Level
        {
            get { return GetStorageField<int>((uint)Offsets.WowGameObjectFields.GAMEOBJECT_LEVEL); }
        }

        /// <summary>
        /// The GUID of the object this object was created by.
        /// <!-- Presumably, hasn't been double-checked. -->
        /// </summary>
        public ulong CreatedBy
        {
            get { return /*GetStorageField<ulong>((uint)Offsets.WowGameObjectFields.OBJECT_FIELD_CREATED_BY)*/ 0; }
        }

        /// <summary>
        /// Returns the object's name.
        /// </summary>
        public string Name
        {
            get { return ObjectManager.Memory.ReadASCIIString(ObjectManager.Memory.ReadUInt(ObjectManager.Memory.ReadUInt(BaseAddress + (uint)Offsets.WowGameObject.Name1) + (uint)Offsets.WowGameObject.Name2), 40); }
        }

        /// <summary>
        /// Returns the GameObject's X position.
        /// </summary>
        public override float X
        {
            get
            {
                return ObjectManager.Memory.ReadFloat(BaseAddress + (uint)Offsets.WowObject.GameObjectX);
            }
        }

        /// <summary>
        /// Returns the GameObject's Y position.
        /// </summary>
        public override float Y
        {
            get
            {
                return ObjectManager.Memory.ReadFloat(BaseAddress + (uint)Offsets.WowObject.GameObjectY);
            }
        }

        /// <summary>
        /// Returns the GameObject's Z position.
        /// </summary>
        public override float Z
        {
            get
            {
                return ObjectManager.Memory.ReadFloat(BaseAddress + (uint)Offsets.WowObject.GameObjectZ);
            }
        }

        /// <summary>
        /// Returns the <see cref="Point">Point</see> location of the Game Object.
        /// </summary>
        public Point Location
        {
            get { return new Point(X, Y, Z); }
        }

        /// <summary>
        /// The distance.
        /// </summary>
        public float Distance
        {
            get { return (float)Point.Distance(ObjectManager.Me.Location, Location); }
        }
    }
}
