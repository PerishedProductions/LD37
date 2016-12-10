﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LD37.Managers
{

    enum MouseButton { Left, Middle, Right }

    class InputManager
    {

        private static InputManager instance;

        private InputManager() { }

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputManager();
                }
                return instance;
            }
        }

        //Keyboard Inputs
        KeyboardState oldKeyState;
        KeyboardState newKeyState;

        //Mouse Inputs
        MouseState mouseState;
        MouseState oldMouseState;

        public void Update()
        {
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();

            oldKeyState = newKeyState;
            newKeyState = Keyboard.GetState();
        }

        public int getMouseWheelState()
        {
            return mouseState.ScrollWheelValue;
        }

        public int getOldMouseWheelState()
        {
            return oldMouseState.ScrollWheelValue;
        }

        public Vector2 getMousePos()
        {
            return mouseState.Position.ToVector2();
        }

        public bool mouseIsPressed(MouseButton mouseButton)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                    {
                        return true;
                    }
                    break;
                case MouseButton.Middle:
                    if (mouseState.MiddleButton == ButtonState.Pressed && oldMouseState.MiddleButton == ButtonState.Released)
                    {
                        return true;
                    }
                    break;
                case MouseButton.Right:
                    if (mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        public bool isPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyUp(key) && oldKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isUp(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyUp(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}