using System.Collections.Specialized;
using System;

namespace BlackRain.Common.Objects
{
    /// <summary>
    /// An unit, such as an NPC, but also a player.
    /// </summary>
    public class WowUnit : WowObject
    {
        /// <summary>
        /// Instantiates a new instance of the WowUnit object.
        /// </summary>
        /// <param name="baseAddress">The units base address.</param>
        public WowUnit(uint baseAddress)
            : base(baseAddress)
        {
        }

        /// <summary>
        /// Returns the Dynamic Flags.
        /// </summary>
        private BitVector32 DynamicFlags { get { return GetStorageField<BitVector32>((uint)Offsets.WowUnitFields.UNIT_DYNAMIC_FLAGS); } }

        /// <summary>
        /// Returns the Unit Flags.
        /// </summary>
        private BitVector32 UnitFlags { get { return GetStorageField<BitVector32>((uint)Offsets.WowUnitFields.UNIT_FIELD_FLAGS); } }

        /// <summary>
        /// Does the unit have this flag?
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        private bool HasFlag(Offsets.UnitDynamicFlags flags)
        {
            return DynamicFlags[(int)flags];
        }


        internal bool HasUnitFlag(Offsets.UnitFlags flag)
        {
            return UnitFlags[(int)flag];
        }

        /// <summary>
        /// Is this unit a critter?
        /// </summary>
        public bool Critter
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_CRITTER) == 1 ? true : false; }
        }

        /// <summary>
        /// Returns whether the unit is a unit.
        /// </summary>
        public bool IsUnit { get { return Type == 3; } }

        /// <summary>
        /// Returns whether the unit is a Player.
        /// </summary>
        public bool IsPlayer { get { return Type == 4; } }


        /// <summary>
        /// The GUID of the object this unit is charmed by.
        /// </summary>
        public ulong CharmedBy
        {
            get { return GetStorageField<ulong>((uint)Offsets.WowUnitFields.UNIT_FIELD_CHARMEDBY); }
        }

        /// <summary>
        /// The GUID of the object this unit is summoned by.
        /// </summary>
        public ulong SummonedBy
        {
            get { return GetStorageField<ulong>((uint)Offsets.WowUnitFields.UNIT_FIELD_SUMMONEDBY); }
        }

        /// <summary>
        /// The GUID of the object this unit was created by.
        /// </summary>
        public ulong CreatedBy
        {
            get { return GetStorageField<ulong>((uint)Offsets.WowUnitFields.UNIT_FIELD_CREATEDBY); }
        }

        /// <summary>
        /// The unit's health.
        /// </summary>
        public int Health
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_HEALTH); }
        }

        public void FuckingDumpThatShit()
        {
            uint curOffset = (uint)Offsets.WowUnitFields.UNIT_FIELD_TARGET;

            for (int index = 0; index < 50; index++)
            {
                curOffset = curOffset + 0x1;
                int value = GetStorageField<int>((uint)curOffset);

                Console.WriteLine(curOffset.ToString("X4") + " - " + value);
            }
        }

        /// <summary>
        /// The unit's maximum health.
        /// </summary>
        public int MaximumHealth
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_MAXHEALTH); }
        }

        /// <summary>
        /// The unit's health as a percentage of its total.
        /// </summary>
        public int HealthPercentage
        {
            get { return ((100 * Health) / (MaximumHealth + 1)); }
        }

        /// <summary>
        /// The unit's mana as a percentage of its total.
        /// </summary>
        public int ManaPercentage
        {
            get { return (100 * Mana) / MaximumMana; }
        }

        /// <summary>
        /// The unit's base health.
        /// </summary>
        public int BaseHealth
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_BASE_HEALTH); }
        }

        /// <summary>
        /// The unit's base health.
        /// </summary>
        public int BaseMana
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_BASE_MANA); }
        }

        /// <summary>
        /// The unit's mana.
        /// </summary>
        public int Mana
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_POWER1); }
        }

        /// <summary>
        /// The unit's rage.
        /// </summary>
        public int Rage
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_POWER2); }
        }

        /// <summary>
        /// The unit's focus.
        /// </summary>
        public int Focus
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_POWER3); }
        }

        /// <summary>
        /// The unit's energy.
        /// </summary>
        public int Energy
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_POWER4); }
        }

        /// <summary>
        /// The unit's happinnes.
        /// </summary>
        public int Happinnes
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_POWER4); }
        }

        /// <summary>
        /// The unit's runic power.
        /// </summary>
        public int RunicPower
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_POWER5); }
        }

        /// <summary>
        /// The unit's runes.
        /// </summary>
        public int Runes
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_POWER6); }
        }

        /// <summary>
        /// The unit's maximum mana.
        /// </summary>
        public int MaximumMana
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_MAXPOWER1); }
        }

        /// <summary>
        /// The unit's maximum rage.
        /// </summary>
        public int MaximumRage
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_MAXPOWER2); }
        }

        /// <summary>
        /// The unit's maximum focus.
        /// </summary>
        public int MaximumFocus
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_MAXPOWER3); }
        }

        /// <summary>
        /// The unit's maximum energy.
        /// </summary>
        public int MaximumEnergy
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_MAXPOWER4); }
        }

        /// <summary>
        /// The unit's maximum runic power.
        /// </summary>
        public int MaximumRunicPower
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_MAXPOWER5); }
        }

        /// <summary>
        /// The unit's maximum runes.
        /// <!-- This is presumably always 6, two blood, two frost, two unholy. But may be different on DK based bosses/mobs? -->
        /// </summary>
        public int MaximumRunes
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_MAXPOWER6); }
        }

        /// <summary>
        /// The unit's level.
        /// </summary>
        public new int Level
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_LEVEL); }
        }

        /// <summary>
        /// The name of the unit.
        /// </summary>
        public virtual string Name
        {
            get {
                return ObjectManager.Memory.ReadASCIIString(ObjectManager.Memory.ReadUInt(ObjectManager.Memory.ReadUInt(BaseAddress + (uint)0x968) + (uint)0x64), 24); 
            }
        }

        /// <summary>
        /// The unit's DisplayID.
        /// </summary>
        public int DisplayID
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_DISPLAYID); }
        }

        /// <summary>
        /// The mount display of the mount the unit is mounted on.
        /// </summary>
        public int MountDisplayID
        {
            get { return GetStorageField<int>((uint)Offsets.WowUnitFields.UNIT_FIELD_MOUNTDISPLAYID); }
        }

        /// <summary>
        /// The GUID of the object this unit is targeting.
        /// </summary>
        public ulong TargetGUID
        {
            get { return GetStorageField<ulong>((uint)Offsets.WowUnitFields.UNIT_FIELD_TARGET); }
        }

        /// <summary>
        /// The GUID of the object this unit is targeting.
        /// </summary>
        public WowUnit Target
        {
            get { return (WowUnit)ObjectManager.Objects.Find(o => o.GUID == TargetGUID); }
        }

        /// <summary>
        /// Determines if the unit is dead.
        /// </summary>
        public bool Dead
        {
            get { return Health == 0 || Health == 1; }
        }

        /// <summary>
        /// Is the unit lootable?
        /// </summary>
        public bool Lootable
        {
            get { return HasFlag(Offsets.UnitDynamicFlags.Lootable); }
        }

        /// <summary>
        /// The <see cref="Point"/> location of the unit.
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


        /// <summary>
        /// Gets the race of the unit.
        /// </summary>
        public Offsets.RaceFlags Race
        {
            get
            {
                uint ret = GetStorageField<uint>((int)Offsets.WowUnitFields.UNIT_FIELD_BYTES_0);
                return (Offsets.RaceFlags)(ret & 0xFF);
            }
        }


        /// <summary>
        /// Gets the class of the unit.
        /// </summary>
        public Offsets.ClassFlags Class
        {
            get
            {
                uint ret = GetStorageField<uint>((int)Offsets.WowUnitFields.UNIT_FIELD_BYTES_0);
                return (Offsets.ClassFlags)((ret >> 8) & 0xFF);
            }
        }
    }
}
