using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using Magic;

namespace BlackRain.Common.Objects
{
    /// <summary>
    /// Manages all the BlackRain WowObjects, and maintains them.
    /// </summary>
    public static class ObjectManager
    {
        /// <summary>
        /// To prevent thread racing scenarios.
        /// </summary>
        private static readonly object objPulse = new object();

        private static Process WowProcess { get; set; }

        /// <summary>
        /// Gets the wow base address.
        /// </summary>
        /// <value>The wow base address.</value>
        /// 19/10/2010 17:30
        private static uint WowBaseAddress
        {
            get 
            {
                return WowProcess.MainModule == null ? 0 : (uint)WowProcess.MainModule.BaseAddress;
            }
        }

        /// <summary>
        /// Makes the address absolute.
        /// </summary>
        /// <param name="relativeAddress">The relative address.</param>
        /// <returns></returns>
        /// 19/10/2010 17:33
        public static uint MakeAbsolute(uint relativeAddress)
        {
            return relativeAddress + WowBaseAddress;
        }

        #region <Enums>

        // ReSharper disable UnusedMember.Local
        private enum ObjectType : uint
        {
            Object = 0,
            Item = 1,
            Container = 2,
            Unit = 3,
            Player = 4,
            GameObject = 5,
            DynamicObject = 6,
            Corpse = 7,
            AiGroup = 8,
            AreaTrigger = 9
        }
        // ReSharper restore UnusedMember.Local

        #endregion

        /// <summary>
        /// The instance of BlackMagic used for World of Warcraft memory editing.
        /// </summary>
        internal static BlackMagic Memory { get; set; }

        /// <summary>
        /// Is the ObjectManager initialized?
        /// </summary>
        public static bool Initialized { get { return Memory != null; } }

        /// <summary>
        /// A list of all Objects.
        /// </summary>
        public static List<WowObject> Objects = new List<WowObject>();

        /// <summary>
        /// A list of all Corpses.
        /// </summary>
        public static List<WowCorpse> Corpses { get { return GetObjectsOfType<WowCorpse>(false, true); } }

        /// <summary>
        /// A list of all units.
        /// </summary>
        public static List<WowUnit> Units { get { return GetObjectsOfType<WowUnit>(false, true); } }

        /// <summary>
        /// A list of all units.
        /// </summary>
        public static List<WowPlayer> Players { get { return GetObjectsOfType<WowPlayer>(false, true); } }

        /// <summary>
        /// A list of all Game Objects.
        /// </summary>
        public static List<WowGameObject> GameObjects { get { return GetObjectsOfType<WowGameObject>(false, false); } }

        /// <summary>
        /// The local player.
        /// </summary>
        public static WowPlayerMe Me { get; set; }

        internal static uint CurrentManager { get; set; }

        /// <summary>
        /// The local player's GUID.
        /// </summary>
        public static ulong PlayerGUID { get; set; }

        /// <summary>
        /// Initialized the ObjectManager, and attaches it to the selected process ID.
        /// </summary>
        /// <param name="wowProc">The wow proc.</param>
        public static void Initialize(Process wowProc)
        {

            if (Initialized) // Nothing to do if we're already initialized.
                return;

            WowProcess = wowProc;
            Memory = new BlackMagic(wowProc.Id);

            try
            {
                CurrentManager = Memory.ReadUInt(Memory.ReadUInt(WowBaseAddress + (uint)Offsets.ObjectManager.Tls) + (uint)Offsets.ObjectManager.CurMgr);
                PlayerGUID = Memory.ReadUInt64(CurrentManager + (uint)Offsets.ObjectManager.LocalGuid);
            }
            catch (Exception ex)
            {
                Logging.WriteException(Color.Red, ex);
            }
        }

        /// <summary>
        /// Initialized the ObjectManager, and attaches it to the selected process ID.
        /// </summary>
        /// <param name="pid">The process id.</param>
        /// 19/10/2010 17:40
        public static void Initialize(int pid)
        {
            var p = Process.GetProcessById(pid);
            Initialize(p);
        }

        /// <summary>
        /// Pulses the ObjectManager, refreshing any objects it holds.
        /// </summary>
        public static void Pulse()
        {
            lock (objPulse)
            {
                if (!Initialized) // Can't pulse if we're not onto something!
                    return;

                if (Objects.Count > 0)
                    Objects.Clear();

                try
                {
                    var currentObject = new WowObject(Memory.ReadUInt(CurrentManager + (uint)Offsets.ObjectManager.FirstObject));

                    while (currentObject.BaseAddress != uint.MinValue && currentObject.BaseAddress%2 == uint.MinValue)
                    {
                        switch (currentObject.Type)
                        {
                            case (int) ObjectType.Unit:
                                Objects.Add(new WowUnit(currentObject.BaseAddress));
                                break;
                            case (int) ObjectType.Item:
                                Objects.Add(new WowItem(currentObject.BaseAddress));
                                break;
                            case (int) ObjectType.Container:
                                Objects.Add(new WowContainer(currentObject.BaseAddress));
                                break;
                            case (int) ObjectType.Corpse:
                                Objects.Add(new WowCorpse(currentObject.BaseAddress));
                                break;
                            case (int) ObjectType.GameObject:
                                Objects.Add(new WowGameObject(currentObject.BaseAddress));
                                break;
                            case (int) ObjectType.DynamicObject:
                                Objects.Add(new WowDynamicObject(currentObject.BaseAddress));
                                break;
                            case (int) ObjectType.Player:
                                Objects.Add(new WowPlayer(currentObject.BaseAddress));
                                break;
                        }

                        if (currentObject.GUID == PlayerGUID && Me == null)
                            Me = new WowPlayerMe(currentObject.BaseAddress);

                        currentObject.BaseAddress = Memory.ReadUInt(currentObject.BaseAddress + (uint)Offsets.ObjectManager.NextObject);
                    }


                }
                catch (Exception ex)
                {
                    Logging.WriteException(Color.Red, ex);
                }
            }
        }

        /// <summary>
        /// Reads the relative memory at the specified address.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        /// 16/10/2010 16:38
        public static T ReadRelative<T>(uint address)
        {
            object ret;
            var t = typeof(T);

            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Int16:
                    ret = Memory.ReadUShort(MakeAbsolute(address));
                    break;
                case TypeCode.Int32:
                    ret = Memory.ReadInt(MakeAbsolute(address));
                    break;
                case TypeCode.Int64:
                    ret = Memory.ReadInt64(MakeAbsolute(address));
                    break;
                case TypeCode.String:
                    ret = Memory.ReadASCIIString(MakeAbsolute(address), 40);
                    break;
                case TypeCode.UInt16:
                    ret = Memory.ReadUShort(MakeAbsolute(address));
                    break;
                case TypeCode.UInt32:
                    ret = Memory.ReadUInt(MakeAbsolute(address));
                    break;
                case TypeCode.UInt64:
                    ret = Memory.ReadUInt64(MakeAbsolute(address));
                    break;
                case TypeCode.Single:
                    ret = Memory.ReadShort(MakeAbsolute(address));
                    break;
                case TypeCode.Byte:
                    ret = Memory.ReadByte(MakeAbsolute(address));
                    break;
                case TypeCode.Object:
                    ret = Memory.ReadObject(MakeAbsolute(address), t);
                    break;
                case TypeCode.Double:
                    ret = Memory.ReadDouble(MakeAbsolute(address));
                    break;
                default: throw new NotSupportedException(string.Format("Type {0} is not currently supported.", typeof(T).FullName));
            }

            return (T)ret;
        }

        /// <summary>
        /// Reads the memory at the specified address.
        /// </summary>
        /// <typeparam name="T">The type of data to be read.</typeparam>
        /// <param name="address">The memory location.</param>
        /// <returns>(T) value</returns>
        public static T Read<T>(uint address)
        {
            object ret;
            var t = typeof (T);

            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Int16:
                    ret = Memory.ReadUShort(address);
                    break;
                case TypeCode.Int32:
                    ret = Memory.ReadInt(address);
                    break;
                case TypeCode.Int64:
                    ret = Memory.ReadInt64(address);
                    break;
                case TypeCode.String:
                    ret = Memory.ReadASCIIString(address, 40);
                    break;
                case TypeCode.UInt16:
                    ret = Memory.ReadUShort(address);
                    break;
                case TypeCode.UInt32:
                    ret = Memory.ReadUInt(address);
                    break;
                case TypeCode.UInt64:
                    ret = Memory.ReadUInt64(address);
                    break;
                case TypeCode.Single:
                    ret = Memory.ReadShort(address);
                    break;
                case TypeCode.Byte:
                    ret = Memory.ReadByte(address);
                    break;
                case TypeCode.Object:
                    ret = Memory.ReadObject(address, t);
                    break;
                case TypeCode.Double:
                    ret = Memory.ReadDouble(address);
                    break;
                default: throw new NotSupportedException(string.Format("Type {0} is not currently supported.", typeof(T).FullName));
            }

            return (T) ret;
        }

        /// <summary>
        /// Writes the value of type T to the specified address.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="address">The address.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// 19/10/2010 17:44
        public static bool Write<T>(uint address, T value)
        {
            if (typeof(T) == typeof(string))
                throw new NotSupportedException("BlackRain.Write<T> currently does not support the writing of type " + typeof(T).FullName);

            try
            {
                object val = value;

                byte[] bytes;

                // Handle types that don't have a real typecode
                // and/or can be done without the ReadByte bullshit
                if (typeof(T) == typeof(IntPtr))
                {
                    // Since we're already here...... we might as well do some stuffs.
                    Marshal.WriteIntPtr(new IntPtr(address), (IntPtr)val);
                    return true;
                }

                // Make sure we're handling passing in stuff as a byte array.
                if (typeof(T) == typeof(byte[]))
                {
                    bytes = (byte[])val;
                    return Memory.WriteBytes(address, bytes);
                }
                switch (Type.GetTypeCode(typeof(T)))
                {
                    case TypeCode.Boolean:
                        bytes = BitConverter.GetBytes((bool)val);
                        break;
                    case TypeCode.Char:
                        bytes = BitConverter.GetBytes((char)val);
                        break;
                    case TypeCode.Byte:
                        bytes = new[] { (byte)val };
                        break;
                    case TypeCode.Int16:
                        bytes = BitConverter.GetBytes((short)val);
                        break;
                    case TypeCode.UInt16:
                        bytes = BitConverter.GetBytes((ushort)val);
                        break;
                    case TypeCode.Int32:
                        bytes = BitConverter.GetBytes((int)val);
                        break;
                    case TypeCode.UInt32:
                        bytes = BitConverter.GetBytes((uint)val);
                        break;
                    case TypeCode.Int64:
                        bytes = BitConverter.GetBytes((long)val);
                        break;
                    case TypeCode.UInt64:
                        bytes = BitConverter.GetBytes((ulong)val);
                        break;
                    case TypeCode.Single:
                        bytes = BitConverter.GetBytes((float)val);
                        break;
                    case TypeCode.Double:
                        bytes = BitConverter.GetBytes((double)val);
                        break;
                    default:
                        throw new NotSupportedException(typeof(T).FullName + " is not currently supported by Write<T>");
                }
                return Memory.WriteBytes(address, bytes);
            }
            catch
            {
                return false;
            }
        }

        #region <Search Members>

        /// <summary>
        /// Returns all objects of type T.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <returns></returns>
        public static List<T> ObjectsOfType<T>()
        {
            var objects = (from o in Objects.OfType<T>()
                          select o).ToList();

            return objects;
        }

        /// <summary>
        /// Gets object of the specified type. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="allowInheritance">Indicates whether to also get objects that derives from the specified type (ie. WowPlayer derives from WoWUnit, so specifying WoWUnit and true would also return all players).</param>
        /// <param name="includeMeIfFound">Indicates whether to include the local player.</param>
        /// <returns></returns>
        public static List<T> GetObjectsOfType<T>(bool allowInheritance, bool includeMeIfFound) where T : WowObject
        {
            Type upperType = typeof(T);
            List<WowObject> objects = Objects;
            var tempObjects = new List<T>();

            for (int i = 0; i < objects.Count; i++)
            {
                Type t = objects[i].GetType();

                if (t == upperType || allowInheritance && t.IsSubclassOf(upperType))
                {
                    // ddebug: bug fix, don't include 'Me'
                    if (!includeMeIfFound && objects[i].GUID == Me.GUID)
                        continue;

                    var obj = objects[i] as T;

                    if (obj != null)
                        tempObjects.Add(obj);
                }
            }

            return tempObjects;
        }

        #endregion
    }
}
