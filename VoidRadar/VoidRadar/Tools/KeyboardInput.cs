using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace VoidRadar.Tools
{
    public class KeyboardInput
    {
        private static KeyboardState curState;
        private static KeyboardState prvState;

        #region Key Functions

        public static bool isKeyDown(Keys key)
        {
            return curState.IsKeyDown(key);
        }

        public static bool isKeyUp(Keys key)
        {
            return curState.IsKeyUp(key);
        }

        public static bool isKeyPressed(Keys key)
        {
            if (prvState.IsKeyUp(key) && curState.IsKeyDown(key))
                return true;

            return false;
        }

        public static bool isKeyReleased(Keys key)
        {
            if (prvState.IsKeyDown(key) && curState.IsKeyUp(key))
                return true;

            return false;
        }

        public static Keys[] currentKeysPressed()
        {
            return curState.GetPressedKeys();
        }

        #endregion

        public static void UpdateStart()
        {
            curState = Keyboard.GetState();
        }

        public static void UpdateEnd()
        {
            prvState = curState;
        }
    }
}
