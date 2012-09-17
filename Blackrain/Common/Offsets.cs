using System;

namespace BlackRain.Common
{
    /// <summary>
    /// A collection of offsets used for memory reading and writing.
    /// </summary>
    public class Offsets
    {
        /****
         * Missing XML Documentation warnings by ReSharper are being supressed in 
         * this file with the use of the #pragma statement below.
         */

        #pragma warning disable 1591

        /// <summary>
        /// Memory locations specific to the WowPlayer type.
        /// </summary>
        public enum WowPlayer: uint
        {
            Name = 0x008BF1E0,
            NameStore = 0xBB6F50 + 0x8,
            NameMask = 0x024,
            NameBase = 0x01c,
            NameString = 0x21 
        }

        /// <summary>
        /// Memory locations specific to the ObjectManager.
        /// Version: 4.0.6 13623
        /// </summary>
        public enum ObjectManager
        {
            Tls = 0xDC9598,
            CurMgr = 0x462C,
            LocalGuid = 0xD0,
            FirstObject = 0xCC,
            NextObject = 0x3C,
        }

        /// <summary>
        /// Memory locations specific to the WowPlayerMe type.
        /// Version: 4.0.6 13623
        /// </summary>
        public enum WowPlayerMe: uint
        {
            Zone = 0x99C690,
            SubZone = 0x99C68C
        }

        /// <summary>
        /// Memory locations specific to the WowObject type.
        /// Version: 4.0.6 13623
        /// </summary>
        public enum WowObject : uint
        {
            X = 0x7E0,
            Y = X + 0x4,
            Z = X + 0x8,
            GameObjectX = 0x110,
            GameObjectY = GameObjectX + 0x4,
            GameObjectZ = GameObjectX + 0x8,
            Pitch = X + 0x14,
            Rotation = X + 0x10,
        }

        /// <summary>
        /// Memory locations specific to the WowGameObject type.
        /// </summary>
        public enum WowGameObject : uint
        {
            Name1 = 0x1B8,
            Name2 = 0xB4,
        }


        #region <Flags>

        [Flags]
        public enum ClassFlags : uint
        {
            None = 0,
            Warrior = 1,
            Paladin = 2,
            Hunter = 3,
            Rogue = 4,
            Priest = 5,
            DeathKnight = 6,
            Shaman = 7,
            Mage = 8,
            Warlock = 9,
            Druid = 11,
        }

        [Flags]
        public enum RaceFlags : uint
        {
            Human = 1,
            Orc,
            Dwarf,
            NightElf,
            Undead,
            Tauren,
            Gnome,
            Troll,
            Goblin,
            BloodElf,
            Draenei,
            FelOrc,
            Naga,
            Broken,
            Skeleton = 15,
        }

        [Flags]
        public enum CorpseFlags
        {
            CORPSE_FLAG_NONE = 0x00,
            CORPSE_FLAG_BONES = 0x01,
            CORPSE_FLAG_UNK1 = 0x02,
            CORPSE_FLAG_UNK2 = 0x04,
            CORPSE_FLAG_HIDE_HELM = 0x08,
            CORPSE_FLAG_HIDE_CLOAK = 0x10,
            CORPSE_FLAG_LOOTABLE = 0x20
        }

        [Flags]
        public enum UnitDynamicFlags
        {
            None = 0,
            Lootable = 0x1,
            TrackUnit = 0x2,
            TaggedByOther = 0x4,
            TaggedByMe = 0x8,
            SpecialInfo = 0x10,
            Dead = 0x20,
            ReferAFriendLinked = 0x40,
            IsTappedByAllThreatList = 0x80,
        }

        [Flags]
        public enum UnitFlags : uint
        {
            None = 0,
            Sitting = 0x1,
            //SelectableNotAttackable_1 = 0x2,
            Influenced = 0x4, // Stops movement packets
            PlayerControlled = 0x8, // 2.4.2
            Totem = 0x10,
            Preparation = 0x20, // 3.0.3
            PlusMob = 0x40, // 3.0.2
            //SelectableNotAttackable_2 = 0x80,
            NotAttackable = 0x100,
            //Flag_0x200 = 0x200,
            Looting = 0x400,
            PetInCombat = 0x800, // 3.0.2
            PvPFlagged = 0x1000,
            Silenced = 0x2000, //3.0.3
            //Flag_14_0x4000 = 0x4000,
            //Flag_15_0x8000 = 0x8000,
            //SelectableNotAttackable_3 = 0x10000,
            Pacified = 0x20000, //3.0.3
            Stunned = 0x40000,
            CanPerformAction_Mask1 = 0x60000,
            Combat = 0x80000, // 3.1.1
            TaxiFlight = 0x100000, // 3.1.1
            Disarmed = 0x200000, // 3.1.1
            Confused = 0x400000, //  3.0.3
            Fleeing = 0x800000,
            Possessed = 0x1000000, // 3.1.1
            NotSelectable = 0x2000000,
            Skinnable = 0x4000000,
            Mounted = 0x8000000,
            //Flag_28_0x10000000 = 0x10000000,
            Dazed = 0x20000000,
            Sheathe = 0x40000000,
            //Flag_31_0x80000000 = 0x80000000,
        }

        #endregion

        #region <Descriptors>

        public enum WowObjectFields
        {
           OBJECT_FIELD_GUID = 0x0,
           OBJECT_FIELD_TYPE = 0x8,
           OBJECT_FIELD_ENTRY = 0xC,
           OBJECT_FIELD_SCALE_X = 0x10,
           OBJECT_FIELD_DATA = 0x14,
           OBJECT_FIELD_PADDING = 0x1C,
        };

        public enum WowUnitFields
        {
           UNIT_FIELD_CHARM = 0x20,
           UNIT_FIELD_SUMMON = 0x28,
           UNIT_FIELD_CRITTER = 0x30,
           UNIT_FIELD_CHARMEDBY = 0x38,
           UNIT_FIELD_SUMMONEDBY = 0x40,
           UNIT_FIELD_CREATEDBY = 0x48,
           UNIT_FIELD_TARGET = 0x13,
           UNIT_FIELD_CHANNEL_OBJECT = 0x58,
           UNIT_CHANNEL_SPELL = 0x60,
           UNIT_FIELD_BYTES_0 = 0x64,
           UNIT_FIELD_HEALTH = 0x1B,
           UNIT_FIELD_POWER1 = 0x1C, // Mana
           UNIT_FIELD_POWER2 = 0x1D, // Rage
           UNIT_FIELD_POWER3 = 0x1E, // Focus
           UNIT_FIELD_POWER4 = 0x1F, // Energy
           UNIT_FIELD_POWER5 = 0x7C, // Happinnes
           UNIT_FIELD_POWER6 = 0x80, // RunicPower
           UNIT_FIELD_POWER7 = 0x84, // Runes
           UNIT_FIELD_POWER8 = 0x88,
           UNIT_FIELD_POWER9 = 0x8C,
           UNIT_FIELD_POWER10 = 0x90,
           UNIT_FIELD_POWER11 = 0x94,
           UNIT_FIELD_MAXHEALTH = 0x21, // 
           UNIT_FIELD_MAXPOWER1 = 0x22,
           UNIT_FIELD_MAXPOWER2 = 0x23,
           UNIT_FIELD_MAXPOWER3 = 0xA4,
           UNIT_FIELD_MAXPOWER4 = 0xA8,
           UNIT_FIELD_MAXPOWER5 = 0xAC,
           UNIT_FIELD_MAXPOWER6 = 0xB0,
           UNIT_FIELD_MAXPOWER7 = 0xB4,
           UNIT_FIELD_MAXPOWER8 = 0xB8,
           UNIT_FIELD_MAXPOWER9 = 0xBC,
           UNIT_FIELD_MAXPOWER10 = 0xC0,
           UNIT_FIELD_MAXPOWER11 = 0xC4,
           UNIT_FIELD_POWER_REGEN_FLAT_MODIFIER = 0xC8,
           UNIT_FIELD_POWER_REGEN_INTERRUPTED_FLAT_MODIFIER = 0xF4,
           UNIT_FIELD_LEVEL = 0x120,
           UNIT_FIELD_FACTIONTEMPLATE = 0x124,
           UNIT_VIRTUAL_ITEM_SLOT_ID = 0x128,
           UNIT_FIELD_FLAGS = 0x134,
           UNIT_FIELD_FLAGS_2 = 0x138,
           UNIT_FIELD_AURASTATE = 0x13C,
           UNIT_FIELD_BASEATTACKTIME = 0x140,
           UNIT_FIELD_RANGEDATTACKTIME = 0x148,
           UNIT_FIELD_BOUNDINGRADIUS = 0x14C,
           UNIT_FIELD_COMBATREACH = 0x150,
           UNIT_FIELD_DISPLAYID = 0x154,
           UNIT_FIELD_NATIVEDISPLAYID = 0x158,
           UNIT_FIELD_MOUNTDISPLAYID = 0x15C,
           UNIT_FIELD_MINDAMAGE = 0x160,
           UNIT_FIELD_MAXDAMAGE = 0x164,
           UNIT_FIELD_MINOFFHANDDAMAGE = 0x168,
           UNIT_FIELD_MAXOFFHANDDAMAGE = 0x16C,
           UNIT_FIELD_BYTES_1 = 0x170,
           UNIT_FIELD_PETNUMBER = 0x174,
           UNIT_FIELD_PET_NAME_TIMESTAMP = 0x178,
           UNIT_FIELD_PETEXPERIENCE = 0x17C,
           UNIT_FIELD_PETNEXTLEVELEXP = 0x180,
           UNIT_DYNAMIC_FLAGS = 0x184,
           UNIT_MOD_CAST_SPEED = 0x188,
           UNIT_CREATED_BY_SPELL = 0x18C,
           UNIT_NPC_FLAGS = 0x190,
           UNIT_NPC_EMOTESTATE = 0x194,
           UNIT_FIELD_STAT0 = 0x198,
           UNIT_FIELD_STAT1 = 0x19C,
           UNIT_FIELD_STAT2 = 0x1A0,
           UNIT_FIELD_STAT3 = 0x1A4,
           UNIT_FIELD_STAT4 = 0x1A8,
           UNIT_FIELD_POSSTAT0 = 0x1AC,
           UNIT_FIELD_POSSTAT1 = 0x1B0,
           UNIT_FIELD_POSSTAT2 = 0x1B4,
           UNIT_FIELD_POSSTAT3 = 0x1B8,
           UNIT_FIELD_POSSTAT4 = 0x1BC,
           UNIT_FIELD_NEGSTAT0 = 0x1C0,
           UNIT_FIELD_NEGSTAT1 = 0x1C4,
           UNIT_FIELD_NEGSTAT2 = 0x1C8,
           UNIT_FIELD_NEGSTAT3 = 0x1CC,
           UNIT_FIELD_NEGSTAT4 = 0x1D0,
           UNIT_FIELD_RESISTANCES = 0x1D4,
           UNIT_FIELD_RESISTANCEBUFFMODSPOSITIVE = 0x1F0,
           UNIT_FIELD_RESISTANCEBUFFMODSNEGATIVE = 0x20C,
           UNIT_FIELD_BASE_MANA = 0x228,
           UNIT_FIELD_BASE_HEALTH = 0x71,
           UNIT_FIELD_BYTES_2 = 0x230,
           UNIT_FIELD_ATTACK_POWER = 0x234,
           UNIT_FIELD_ATTACK_POWER_MOD_POS = 0x238,
           UNIT_FIELD_ATTACK_POWER_MOD_NEG = 0x23C,
           UNIT_FIELD_ATTACK_POWER_MULTIPLIER = 0x240,
           UNIT_FIELD_RANGED_ATTACK_POWER = 0x244,
           UNIT_FIELD_RANGED_ATTACK_POWER_MOD_POS = 0x248,
           UNIT_FIELD_RANGED_ATTACK_POWER_MOD_NEG = 0x24C,
           UNIT_FIELD_RANGED_ATTACK_POWER_MULTIPLIER = 0x250,
           UNIT_FIELD_MINRANGEDDAMAGE = 0x254,
           UNIT_FIELD_MAXRANGEDDAMAGE = 0x258,
           UNIT_FIELD_POWER_COST_MODIFIER = 0x25C,
           UNIT_FIELD_POWER_COST_MULTIPLIER = 0x278,
           UNIT_FIELD_MAXHEALTHMODIFIER = 0x294,
           UNIT_FIELD_HOVERHEIGHT = 0x298,
           UNIT_FIELD_MAXITEMLEVEL = 0x29C,
        };

        public enum WowItemFields
        {
           ITEM_FIELD_OWNER = 0x20,
           ITEM_FIELD_CONTAINED = 0x28,
           ITEM_FIELD_CREATOR = 0x30,
           ITEM_FIELD_GIFTCREATOR = 0x38,
           ITEM_FIELD_STACK_COUNT = 0x40,
           ITEM_FIELD_DURATION = 0x44,
           ITEM_FIELD_SPELL_CHARGES = 0x48,
           ITEM_FIELD_FLAGS = 0x5C,
           ITEM_FIELD_ENCHANTMENT_1_1 = 0x60,
           ITEM_FIELD_ENCHANTMENT_1_3 = 0x68,
           ITEM_FIELD_ENCHANTMENT_2_1 = 0x6C,
           ITEM_FIELD_ENCHANTMENT_2_3 = 0x74,
           ITEM_FIELD_ENCHANTMENT_3_1 = 0x78,
           ITEM_FIELD_ENCHANTMENT_3_3 = 0x80,
           ITEM_FIELD_ENCHANTMENT_4_1 = 0x84,
           ITEM_FIELD_ENCHANTMENT_4_3 = 0x8C,
           ITEM_FIELD_ENCHANTMENT_5_1 = 0x90,
           ITEM_FIELD_ENCHANTMENT_5_3 = 0x98,
           ITEM_FIELD_ENCHANTMENT_6_1 = 0x9C,
           ITEM_FIELD_ENCHANTMENT_6_3 = 0xA4,
           ITEM_FIELD_ENCHANTMENT_7_1 = 0xA8,
           ITEM_FIELD_ENCHANTMENT_7_3 = 0xB0,
           ITEM_FIELD_ENCHANTMENT_8_1 = 0xB4,
           ITEM_FIELD_ENCHANTMENT_8_3 = 0xBC,
           ITEM_FIELD_ENCHANTMENT_9_1 = 0xC0,
           ITEM_FIELD_ENCHANTMENT_9_3 = 0xC8,
           ITEM_FIELD_ENCHANTMENT_10_1 = 0xCC,
           ITEM_FIELD_ENCHANTMENT_10_3 = 0xD4,
           ITEM_FIELD_ENCHANTMENT_11_1 = 0xD8,
           ITEM_FIELD_ENCHANTMENT_11_3 = 0xE0,
           ITEM_FIELD_ENCHANTMENT_12_1 = 0xE4,
           ITEM_FIELD_ENCHANTMENT_12_3 = 0xEC,
           ITEM_FIELD_ENCHANTMENT_13_1 = 0xF0,
           ITEM_FIELD_ENCHANTMENT_13_3 = 0xF8,
           ITEM_FIELD_ENCHANTMENT_14_1 = 0xFC,
           ITEM_FIELD_ENCHANTMENT_14_3 = 0x104,
           ITEM_FIELD_PROPERTY_SEED = 0x108,
           ITEM_FIELD_RANDOM_PROPERTIES_ID = 0x10C,
           ITEM_FIELD_DURABILITY = 0x110,
           ITEM_FIELD_MAXDURABILITY = 0x114,
           ITEM_FIELD_CREATE_PLAYED_TIME = 0x118,
           ITEM_FIELD_PAD = 0x11C,
        };

        public enum WowPlayerFields
        {
           PLAYER_DUEL_ARBITER = 0x2A0,
           PLAYER_FLAGS = 0x2A8,
           PLAYER_GUILDRANK = 0x2AC,
           PLAYER_GUILDDELETE_DATE = 0x2B0,
           PLAYER_GUILDLEVEL = 0x2B4,
           PLAYER_BYTES = 0x2B8,
           PLAYER_BYTES_2 = 0x2BC,
           PLAYER_BYTES_3 = 0x2C0,
           PLAYER_DUEL_TEAM = 0x2C4,
           PLAYER_GUILD_TIMESTAMP = 0x2C8,
           PLAYER_QUEST_LOG_1_1 = 0x2CC,
           PLAYER_QUEST_LOG_1_2 = 0x2D0,
           PLAYER_QUEST_LOG_1_3 = 0x2D4,
           PLAYER_QUEST_LOG_1_4 = 0x2DC,
           PLAYER_QUEST_LOG_2_1 = 0x2E0,
           PLAYER_QUEST_LOG_2_2 = 0x2E4,
           PLAYER_QUEST_LOG_2_3 = 0x2E8,
           PLAYER_QUEST_LOG_2_5 = 0x2F0,
           PLAYER_QUEST_LOG_3_1 = 0x2F4,
           PLAYER_QUEST_LOG_3_2 = 0x2F8,
           PLAYER_QUEST_LOG_3_3 = 0x2FC,
           PLAYER_QUEST_LOG_3_5 = 0x304,
           PLAYER_QUEST_LOG_4_1 = 0x308,
           PLAYER_QUEST_LOG_4_2 = 0x30C,
           PLAYER_QUEST_LOG_4_3 = 0x310,
           PLAYER_QUEST_LOG_4_5 = 0x318,
           PLAYER_QUEST_LOG_5_1 = 0x31C,
           PLAYER_QUEST_LOG_5_2 = 0x320,
           PLAYER_QUEST_LOG_5_3 = 0x324,
           PLAYER_QUEST_LOG_5_5 = 0x32C,
           PLAYER_QUEST_LOG_6_1 = 0x330,
           PLAYER_QUEST_LOG_6_2 = 0x334,
           PLAYER_QUEST_LOG_6_3 = 0x338,
           PLAYER_QUEST_LOG_6_5 = 0x340,
           PLAYER_QUEST_LOG_7_1 = 0x344,
           PLAYER_QUEST_LOG_7_2 = 0x348,
           PLAYER_QUEST_LOG_7_3 = 0x34C,
           PLAYER_QUEST_LOG_7_5 = 0x354,
           PLAYER_QUEST_LOG_8_1 = 0x358,
           PLAYER_QUEST_LOG_8_2 = 0x35C,
           PLAYER_QUEST_LOG_8_3 = 0x360,
           PLAYER_QUEST_LOG_8_5 = 0x368,
           PLAYER_QUEST_LOG_9_1 = 0x36C,
           PLAYER_QUEST_LOG_9_2 = 0x370,
           PLAYER_QUEST_LOG_9_3 = 0x374,
           PLAYER_QUEST_LOG_9_5 = 0x37C,
           PLAYER_QUEST_LOG_10_1 = 0x380,
           PLAYER_QUEST_LOG_10_2 = 0x384,
           PLAYER_QUEST_LOG_10_3 = 0x388,
           PLAYER_QUEST_LOG_10_5 = 0x390,
           PLAYER_QUEST_LOG_11_1 = 0x394,
           PLAYER_QUEST_LOG_11_2 = 0x398,
           PLAYER_QUEST_LOG_11_3 = 0x39C,
           PLAYER_QUEST_LOG_11_5 = 0x3A4,
           PLAYER_QUEST_LOG_12_1 = 0x3A8,
           PLAYER_QUEST_LOG_12_2 = 0x3AC,
           PLAYER_QUEST_LOG_12_3 = 0x3B0,
           PLAYER_QUEST_LOG_12_5 = 0x3B8,
           PLAYER_QUEST_LOG_13_1 = 0x3BC,
           PLAYER_QUEST_LOG_13_2 = 0x3C0,
           PLAYER_QUEST_LOG_13_3 = 0x3C4,
           PLAYER_QUEST_LOG_13_5 = 0x3CC,
           PLAYER_QUEST_LOG_14_1 = 0x3D0,
           PLAYER_QUEST_LOG_14_2 = 0x3D4,
           PLAYER_QUEST_LOG_14_3 = 0x3D8,
           PLAYER_QUEST_LOG_14_5 = 0x3E0,
           PLAYER_QUEST_LOG_15_1 = 0x3E4,
           PLAYER_QUEST_LOG_15_2 = 0x3E8,
           PLAYER_QUEST_LOG_15_3 = 0x3EC,
           PLAYER_QUEST_LOG_15_5 = 0x3F4,
           PLAYER_QUEST_LOG_16_1 = 0x3F8,
           PLAYER_QUEST_LOG_16_2 = 0x3FC,
           PLAYER_QUEST_LOG_16_3 = 0x400,
           PLAYER_QUEST_LOG_16_5 = 0x408,
           PLAYER_QUEST_LOG_17_1 = 0x40C,
           PLAYER_QUEST_LOG_17_2 = 0x410,
           PLAYER_QUEST_LOG_17_3 = 0x414,
           PLAYER_QUEST_LOG_17_5 = 0x41C,
           PLAYER_QUEST_LOG_18_1 = 0x420,
           PLAYER_QUEST_LOG_18_2 = 0x424,
           PLAYER_QUEST_LOG_18_3 = 0x428,
           PLAYER_QUEST_LOG_18_5 = 0x430,
           PLAYER_QUEST_LOG_19_1 = 0x434,
           PLAYER_QUEST_LOG_19_2 = 0x438,
           PLAYER_QUEST_LOG_19_3 = 0x43C,
           PLAYER_QUEST_LOG_19_5 = 0x444,
           PLAYER_QUEST_LOG_20_1 = 0x448,
           PLAYER_QUEST_LOG_20_2 = 0x44C,
           PLAYER_QUEST_LOG_20_3 = 0x450,
           PLAYER_QUEST_LOG_20_5 = 0x458,
           PLAYER_QUEST_LOG_21_1 = 0x45C,
           PLAYER_QUEST_LOG_21_2 = 0x460,
           PLAYER_QUEST_LOG_21_3 = 0x464,
           PLAYER_QUEST_LOG_21_5 = 0x46C,
           PLAYER_QUEST_LOG_22_1 = 0x470,
           PLAYER_QUEST_LOG_22_2 = 0x474,
           PLAYER_QUEST_LOG_22_3 = 0x478,
           PLAYER_QUEST_LOG_22_5 = 0x480,
           PLAYER_QUEST_LOG_23_1 = 0x484,
           PLAYER_QUEST_LOG_23_2 = 0x488,
           PLAYER_QUEST_LOG_23_3 = 0x48C,
           PLAYER_QUEST_LOG_23_5 = 0x494,
           PLAYER_QUEST_LOG_24_1 = 0x498,
           PLAYER_QUEST_LOG_24_2 = 0x49C,
           PLAYER_QUEST_LOG_24_3 = 0x4A0,
           PLAYER_QUEST_LOG_24_5 = 0x4A8,
           PLAYER_QUEST_LOG_25_1 = 0x4AC,
           PLAYER_QUEST_LOG_25_2 = 0x4B0,
           PLAYER_QUEST_LOG_25_3 = 0x4B4,
           PLAYER_QUEST_LOG_25_5 = 0x4BC,
           PLAYER_QUEST_LOG_26_1 = 0x4C0,
           PLAYER_QUEST_LOG_26_2 = 0x4C4,
           PLAYER_QUEST_LOG_26_3 = 0x4C8,
           PLAYER_QUEST_LOG_26_5 = 0x4D0,
           PLAYER_QUEST_LOG_27_1 = 0x4D4,
           PLAYER_QUEST_LOG_27_2 = 0x4D8,
           PLAYER_QUEST_LOG_27_3 = 0x4DC,
           PLAYER_QUEST_LOG_27_5 = 0x4E4,
           PLAYER_QUEST_LOG_28_1 = 0x4E8,
           PLAYER_QUEST_LOG_28_2 = 0x4EC,
           PLAYER_QUEST_LOG_28_3 = 0x4F0,
           PLAYER_QUEST_LOG_28_5 = 0x4F8,
           PLAYER_QUEST_LOG_29_1 = 0x4FC,
           PLAYER_QUEST_LOG_29_2 = 0x500,
           PLAYER_QUEST_LOG_29_3 = 0x504,
           PLAYER_QUEST_LOG_29_5 = 0x50C,
           PLAYER_QUEST_LOG_30_1 = 0x510,
           PLAYER_QUEST_LOG_30_2 = 0x514,
           PLAYER_QUEST_LOG_30_3 = 0x518,
           PLAYER_QUEST_LOG_30_5 = 0x520,
           PLAYER_QUEST_LOG_31_1 = 0x524,
           PLAYER_QUEST_LOG_31_2 = 0x528,
           PLAYER_QUEST_LOG_31_3 = 0x52C,
           PLAYER_QUEST_LOG_31_5 = 0x534,
           PLAYER_QUEST_LOG_32_1 = 0x538,
           PLAYER_QUEST_LOG_32_2 = 0x53C,
           PLAYER_QUEST_LOG_32_3 = 0x540,
           PLAYER_QUEST_LOG_32_5 = 0x548,
           PLAYER_QUEST_LOG_33_1 = 0x54C,
           PLAYER_QUEST_LOG_33_2 = 0x550,
           PLAYER_QUEST_LOG_33_3 = 0x554,
           PLAYER_QUEST_LOG_33_5 = 0x55C,
           PLAYER_QUEST_LOG_34_1 = 0x560,
           PLAYER_QUEST_LOG_34_2 = 0x564,
           PLAYER_QUEST_LOG_34_3 = 0x568,
           PLAYER_QUEST_LOG_34_5 = 0x570,
           PLAYER_QUEST_LOG_35_1 = 0x574,
           PLAYER_QUEST_LOG_35_2 = 0x578,
           PLAYER_QUEST_LOG_35_3 = 0x57C,
           PLAYER_QUEST_LOG_35_5 = 0x584,
           PLAYER_QUEST_LOG_36_1 = 0x588,
           PLAYER_QUEST_LOG_36_2 = 0x58C,
           PLAYER_QUEST_LOG_36_3 = 0x590,
           PLAYER_QUEST_LOG_36_5 = 0x598,
           PLAYER_QUEST_LOG_37_1 = 0x59C,
           PLAYER_QUEST_LOG_37_2 = 0x5A0,
           PLAYER_QUEST_LOG_37_3 = 0x5A4,
           PLAYER_QUEST_LOG_37_5 = 0x5AC,
           PLAYER_QUEST_LOG_38_1 = 0x5B0,
           PLAYER_QUEST_LOG_38_2 = 0x5B4,
           PLAYER_QUEST_LOG_38_3 = 0x5B8,
           PLAYER_QUEST_LOG_38_5 = 0x5C0,
           PLAYER_QUEST_LOG_39_1 = 0x5C4,
           PLAYER_QUEST_LOG_39_2 = 0x5C8,
           PLAYER_QUEST_LOG_39_3 = 0x5CC,
           PLAYER_QUEST_LOG_39_5 = 0x5D4,
           PLAYER_QUEST_LOG_40_1 = 0x5D8,
           PLAYER_QUEST_LOG_40_2 = 0x5DC,
           PLAYER_QUEST_LOG_40_3 = 0x5E0,
           PLAYER_QUEST_LOG_40_5 = 0x5E8,
           PLAYER_QUEST_LOG_41_1 = 0x5EC,
           PLAYER_QUEST_LOG_41_2 = 0x5F0,
           PLAYER_QUEST_LOG_41_3 = 0x5F4,
           PLAYER_QUEST_LOG_41_5 = 0x5FC,
           PLAYER_QUEST_LOG_42_1 = 0x600,
           PLAYER_QUEST_LOG_42_2 = 0x604,
           PLAYER_QUEST_LOG_42_3 = 0x608,
           PLAYER_QUEST_LOG_42_5 = 0x610,
           PLAYER_QUEST_LOG_43_1 = 0x614,
           PLAYER_QUEST_LOG_43_2 = 0x618,
           PLAYER_QUEST_LOG_43_3 = 0x61C,
           PLAYER_QUEST_LOG_43_5 = 0x624,
           PLAYER_QUEST_LOG_44_1 = 0x628,
           PLAYER_QUEST_LOG_44_2 = 0x62C,
           PLAYER_QUEST_LOG_44_3 = 0x630,
           PLAYER_QUEST_LOG_44_5 = 0x638,
           PLAYER_QUEST_LOG_45_1 = 0x63C,
           PLAYER_QUEST_LOG_45_2 = 0x640,
           PLAYER_QUEST_LOG_45_3 = 0x644,
           PLAYER_QUEST_LOG_45_5 = 0x64C,
           PLAYER_QUEST_LOG_46_1 = 0x650,
           PLAYER_QUEST_LOG_46_2 = 0x654,
           PLAYER_QUEST_LOG_46_3 = 0x658,
           PLAYER_QUEST_LOG_46_5 = 0x660,
           PLAYER_QUEST_LOG_47_1 = 0x664,
           PLAYER_QUEST_LOG_47_2 = 0x668,
           PLAYER_QUEST_LOG_47_3 = 0x66C,
           PLAYER_QUEST_LOG_47_5 = 0x674,
           PLAYER_QUEST_LOG_48_1 = 0x678,
           PLAYER_QUEST_LOG_48_2 = 0x67C,
           PLAYER_QUEST_LOG_48_3 = 0x680,
           PLAYER_QUEST_LOG_48_5 = 0x688,
           PLAYER_QUEST_LOG_49_1 = 0x68C,
           PLAYER_QUEST_LOG_49_2 = 0x690,
           PLAYER_QUEST_LOG_49_3 = 0x694,
           PLAYER_QUEST_LOG_49_5 = 0x69C,
           PLAYER_QUEST_LOG_50_1 = 0x6A0,
           PLAYER_QUEST_LOG_50_2 = 0x6A4,
           PLAYER_QUEST_LOG_50_3 = 0x6A8,
           PLAYER_QUEST_LOG_50_5 = 0x6B0,
           PLAYER_VISIBLE_ITEM_1_ENTRYID = 0x6B4,
           PLAYER_VISIBLE_ITEM_1_ENCHANTMENT = 0x6B8,
           PLAYER_VISIBLE_ITEM_2_ENTRYID = 0x6BC,
           PLAYER_VISIBLE_ITEM_2_ENCHANTMENT = 0x6C0,
           PLAYER_VISIBLE_ITEM_3_ENTRYID = 0x6C4,
           PLAYER_VISIBLE_ITEM_3_ENCHANTMENT = 0x6C8,
           PLAYER_VISIBLE_ITEM_4_ENTRYID = 0x6CC,
           PLAYER_VISIBLE_ITEM_4_ENCHANTMENT = 0x6D0,
           PLAYER_VISIBLE_ITEM_5_ENTRYID = 0x6D4,
           PLAYER_VISIBLE_ITEM_5_ENCHANTMENT = 0x6D8,
           PLAYER_VISIBLE_ITEM_6_ENTRYID = 0x6DC,
           PLAYER_VISIBLE_ITEM_6_ENCHANTMENT = 0x6E0,
           PLAYER_VISIBLE_ITEM_7_ENTRYID = 0x6E4,
           PLAYER_VISIBLE_ITEM_7_ENCHANTMENT = 0x6E8,
           PLAYER_VISIBLE_ITEM_8_ENTRYID = 0x6EC,
           PLAYER_VISIBLE_ITEM_8_ENCHANTMENT = 0x6F0,
           PLAYER_VISIBLE_ITEM_9_ENTRYID = 0x6F4,
           PLAYER_VISIBLE_ITEM_9_ENCHANTMENT = 0x6F8,
           PLAYER_VISIBLE_ITEM_10_ENTRYID = 0x6FC,
           PLAYER_VISIBLE_ITEM_10_ENCHANTMENT = 0x700,
           PLAYER_VISIBLE_ITEM_11_ENTRYID = 0x704,
           PLAYER_VISIBLE_ITEM_11_ENCHANTMENT = 0x708,
           PLAYER_VISIBLE_ITEM_12_ENTRYID = 0x70C,
           PLAYER_VISIBLE_ITEM_12_ENCHANTMENT = 0x710,
           PLAYER_VISIBLE_ITEM_13_ENTRYID = 0x714,
           PLAYER_VISIBLE_ITEM_13_ENCHANTMENT = 0x718,
           PLAYER_VISIBLE_ITEM_14_ENTRYID = 0x71C,
           PLAYER_VISIBLE_ITEM_14_ENCHANTMENT = 0x720,
           PLAYER_VISIBLE_ITEM_15_ENTRYID = 0x724,
           PLAYER_VISIBLE_ITEM_15_ENCHANTMENT = 0x728,
           PLAYER_VISIBLE_ITEM_16_ENTRYID = 0x72C,
           PLAYER_VISIBLE_ITEM_16_ENCHANTMENT = 0x730,
           PLAYER_VISIBLE_ITEM_17_ENTRYID = 0x734,
           PLAYER_VISIBLE_ITEM_17_ENCHANTMENT = 0x738,
           PLAYER_VISIBLE_ITEM_18_ENTRYID = 0x73C,
           PLAYER_VISIBLE_ITEM_18_ENCHANTMENT = 0x740,
           PLAYER_VISIBLE_ITEM_19_ENTRYID = 0x744,
           PLAYER_VISIBLE_ITEM_19_ENCHANTMENT = 0x748,
           PLAYER_CHOSEN_TITLE = 0x74C,
           PLAYER_FAKE_INEBRIATION = 0x750,
           PLAYER_FIELD_PAD_0 = 0x754,
           PLAYER_FIELD_INV_SLOT_HEAD = 0x758,
           PLAYER_FIELD_PACK_SLOT_1 = 0x810,
           PLAYER_FIELD_BANK_SLOT_1 = 0x890,
           PLAYER_FIELD_BANKBAG_SLOT_1 = 0x970,
           PLAYER_FIELD_VENDORBUYBACK_SLOT_1 = 0x9A8,
           PLAYER_FIELD_KEYRING_SLOT_1 = 0xA08,
           PLAYER_FARSIGHT = 0xB08,
           PLAYER__FIELD_KNOWN_TITLES = 0xB10,
           PLAYER__FIELD_KNOWN_TITLES1 = 0xB18,
           PLAYER__FIELD_KNOWN_TITLES2 = 0xB20,
           PLAYER_XP = 0xB28,
           PLAYER_NEXT_LEVEL_XP = 0xB2C,
           PLAYER_SKILL_INFO_1_1 = 0xB30,
           PLAYER_CHARACTER_POINTS = 0x1130,
           PLAYER_TRACK_CREATURES = 0x1134,
           PLAYER_TRACK_RESOURCES = 0x1138,
           PLAYER_BLOCK_PERCENTAGE = 0x113C,
           PLAYER_DODGE_PERCENTAGE = 0x1140,
           PLAYER_PARRY_PERCENTAGE = 0x1144,
           PLAYER_EXPERTISE = 0x1148,
           PLAYER_OFFHAND_EXPERTISE = 0x114C,
           PLAYER_CRIT_PERCENTAGE = 0x1150,
           PLAYER_RANGED_CRIT_PERCENTAGE = 0x1154,
           PLAYER_OFFHAND_CRIT_PERCENTAGE = 0x1158,
           PLAYER_SPELL_CRIT_PERCENTAGE1 = 0x115C,
           PLAYER_SHIELD_BLOCK = 0x1178,
           PLAYER_SHIELD_BLOCK_CRIT_PERCENTAGE = 0x117C,
           PLAYER_MASTERY = 0x1180,
           PLAYER_EXPLORED_ZONES_1 = 0x1184,
           PLAYER_REST_STATE_EXPERIENCE = 0x13C4,
           PLAYER_FIELD_COINAGE = 0x13C8,
           PLAYER_FIELD_MOD_DAMAGE_DONE_POS = 0x13D0,
           PLAYER_FIELD_MOD_DAMAGE_DONE_NEG = 0x13EC,
           PLAYER_FIELD_MOD_DAMAGE_DONE_PCT = 0x1408,
           PLAYER_FIELD_MOD_HEALING_DONE_POS = 0x1424,
           PLAYER_FIELD_MOD_HEALING_PCT = 0x1428,
           PLAYER_FIELD_MOD_HEALING_DONE_PCT = 0x142C,
           PLAYER_FIELD_MOD_SPELL_POWER_PCT = 0x1430,
           PLAYER_FIELD_MOD_TARGET_RESISTANCE = 0x1434,
           PLAYER_FIELD_MOD_TARGET_PHYSICAL_RESISTANCE = 0x1438,
           PLAYER_FIELD_BYTES = 0x143C,
           PLAYER_SELF_RES_SPELL = 0x1440,
           PLAYER_FIELD_PVP_MEDALS = 0x1444,
           PLAYER_FIELD_BUYBACK_PRICE_1 = 0x1448,
           PLAYER_FIELD_BUYBACK_TIMESTAMP_1 = 0x1478,
           PLAYER_FIELD_KILLS = 0x14A8,
           PLAYER_FIELD_LIFETIME_HONORBALE_KILLS = 0x14AC,
           PLAYER_FIELD_BYTES2 = 0x14B0,
           PLAYER_FIELD_WATCHED_FACTION_INDEX = 0x14B4,
           PLAYER_FIELD_COMBAT_RATING_1 = 0x14B8,
           PLAYER_FIELD_ARENA_TEAM_INFO_1_1 = 0x1520,
           PLAYER_FIELD_BATTLEGROUND_RATING = 0x1574,
           PLAYER_FIELD_MAX_LEVEL = 0x1578,
           PLAYER_FIELD_DAILY_QUESTS_1 = 0x157C,
           PLAYER_RUNE_REGEN_1 = 0x15E0,
           PLAYER_NO_REAGENT_COST_1 = 0x15F0,
           PLAYER_FIELD_GLYPH_SLOTS_1 = 0x15FC,
           PLAYER_FIELD_GLYPHS_1 = 0x1620,
           PLAYER_GLYPHS_ENABLED = 0x1644,
           PLAYER_PET_SPELL_POWER = 0x1648,
           PLAYER_FIELD_RESEARCHING_1 = 0x164C,
           PLAYER_FIELD_RESERACH_SITE_1 = 0x166C,
           PLAYER_PROFESSION_SKILL_LINE_1 = 0x168C,
           PLAYER_FIELD_UI_HIT_MODIFIER = 0x1694,
           PLAYER_FIELD_UI_SPELL_HIT_MODIFIER = 0x1698,
           PLAYER_FIELD_HOME_REALM_TIME_OFFSET = 0x169C,
           PLAYER_FIELD_MOD_HASTE = 0x16A0,
           PLAYER_FIELD_MOD_RANGED_HASTE = 0x16A4,
           PLAYER_FIELD_MOD_PET_HASTE = 0x16A8,
           PLAYER_FIELD_MOD_HASTE_REGEN = 0x16AC,
        };

        public enum WowContainerFields
        {
           CONTAINER_FIELD_NUM_SLOTS = 0x120,
           CONTAINER_ALIGN_PAD = 0x124,
           CONTAINER_FIELD_SLOT_1 = 0x128,
        };

        public enum WowGameObjectFields
        {
           OBJECT_FIELD_CREATED_BY = 0x20,
           GAMEOBJECT_DISPLAYID = 0x28,
           GAMEOBJECT_FLAGS = 0x2C,
           GAMEOBJECT_PARENTROTATION = 0x30,
           GAMEOBJECT_DYNAMIC = 0x40,
           GAMEOBJECT_FACTION = 0x44,
           GAMEOBJECT_LEVEL = 0x48,
           GAMEOBJECT_BYTES_1 = 0x4C,
        };

        public enum WowDynamicObjectFields
        {
           DYNAMICOBJECT_CASTER = 0x20,
           DYNAMICOBJECT_BYTES = 0x28,
           DYNAMICOBJECT_SPELLID = 0x2C,
           DYNAMICOBJECT_RADIUS = 0x30,
           DYNAMICOBJECT_CASTTIME = 0x34,
        };

        public enum WowCorpseFields
        {
            CORPSE_FIELD_OWNER = 0x20,
            CORPSE_FIELD_PARTY = 0x28,
            CORPSE_FIELD_DISPLAY_ID = 0x30,
            CORPSE_FIELD_ITEM = 0x34,
            CORPSE_FIELD_BYTES_1 = 0x80,
            CORPSE_FIELD_BYTES_2 = 0x84,
            CORPSE_FIELD_FLAGS = 0x88,
            CORPSE_FIELD_DYNAMIC_FLAGS = 0x8C,
        }

        #endregion

#pragma warning restore 1591

    }
}
