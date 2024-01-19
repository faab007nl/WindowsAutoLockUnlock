using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsAutoLockUnlock
{
    internal class UserInteractController
    {

        public bool userHasInteracted = false;

        private int lastMousePosX;
        private int lastMousePosY;

        public UserInteractController()
        {
            lastMousePosX = Cursor.Position.X;
            lastMousePosY = Cursor.Position.Y;

            Thread thread = new Thread(new ThreadStart(Loop));
            thread.Start();
            thread.Join();
        }


        public void Loop()
        {
            while (!userHasInteracted)
            {
                int currentMousePosX = Cursor.Position.X;
                int currentMousePosY = Cursor.Position.Y;

                if (
                    currentMousePosX != lastMousePosX ||
                    currentMousePosY != lastMousePosY
                )
                {
                    lastMousePosX = currentMousePosX;
                    lastMousePosY = currentMousePosY;

                    userHasInteracted = true;
                }


                for (int i = 0; i < 254; i++)
                {
                    short keyState = GetAsyncKeyState(i);
                    if (keyState < 0) // If key is pressed
                    {
                        userHasInteracted = true;
                    }
                }
                Thread.Sleep(50);
            }
        }

        // External functions
        [DllImport(("user32.dll"))]
        public static extern short GetAsyncKeyState(int vKey);

    }

}
