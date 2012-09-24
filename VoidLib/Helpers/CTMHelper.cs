using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackRain.Common.Objects;

namespace VoidLib
{
    public class CTMHelper
    {
        public enum CTM : uint
        {
            CGPlayer_C__ClickToMove = 0x493760,     // 5.0.5 
            CTM_Base = 0xC2BD04,                    // 5.0.5 
            CTM_Push = 0x24,                        // 5.0.5 
            CTM_X = 0x8C,                           // 5.0.5 
            CTM_Y = CTM_X + 0x4,                    // 5.0.5 
            CTM_Z = CTM_X + 0x8,                    // 5.0.5 
            CTM_GUID = 0x1C,                        // 5.0.5 
            CTM_Distance = 0xC                      // 5.0.5 
        }

        public enum CTMAction
        {
            FaceTarget = 0x1,
            Stop = 0x3,
            WalkTo = 0x4,
            InteractNpc = 0x5,
            Loot = 0x6,
            InteractObject = 0x7,
            Unknown1 = 0x8,
            Unknown2 = 0x9,
            AttackPos = 0xA,
            AttackGuid = 0xB,
            WalkAndRotate = 0xC
        }

        public static void ClickToMove(float x, float y, float z, CTMAction action = CTMAction.WalkTo, ulong GUID = 0)
        {
            ObjectManager.Write<float>(ObjectManager.WowBaseAddress + (uint)CTM.CTM_Base + (uint)CTM.CTM_X, x);
            ObjectManager.Write<float>(ObjectManager.WowBaseAddress + (uint)CTM.CTM_Base + (uint)CTM.CTM_Y, y);
            ObjectManager.Write<float>(ObjectManager.WowBaseAddress + (uint)CTM.CTM_Base + (uint)CTM.CTM_Z, z);

            if (GUID != 0)
            {
                ObjectManager.Write<ulong>(ObjectManager.WowBaseAddress + (uint)CTM.CTM_Base + (uint)CTM.CTM_GUID, GUID);
            }

            ObjectManager.Write<uint>(ObjectManager.WowBaseAddress + (uint)CTM.CTM_Base + (uint)CTM.CTM_Push, (uint)action);
        }

    }
}
