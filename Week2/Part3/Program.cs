using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            // Create an instance of the Shape class
            Shape myShape = new Shape();

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                // Draw the shape
                myShape.Draw();

                // Check for user input
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    // Set shape's x, y to mouse's position
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    // If mouse is over the shape, change its color
                    if (myShape.IsAt(SplashKit.MousePosition()))
                    {
                        myShape.Color = Color.RandomRGB(255);
                    }
                }

                SplashKit.RefreshScreen();
            }
            while (!window.CloseRequested);

            window.Close();
        }
    }
}