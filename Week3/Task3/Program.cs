using System;
using SplashKitSDK;


namespace ShapeDrawer
{

    public class Program
    {
        public static void Main()
        {
            new Window("Shape Drawer", 800, 600);
            Drawing drawing = new Drawing();
            do
            {
                SplashKit.ProcessEvents(); //Check user inputs - should only call once
                SplashKit.ClearScreen(); //Clear screen to white                
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    //No good way to instantiate a shape with different params directly in method?
                    //Shape constructor needs ability to accept X/Y paramters, I guess?
                    Shape tempShape = new Shape();
                    tempShape.X = SplashKit.MouseX();
                    tempShape.Y = SplashKit.MouseY();
                    drawing.AddShape(tempShape);
                }
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255); //Alpha set to 255
                }
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    // Select shapes at the mouse's location
                    Point2D mousePosition = SplashKit.MousePosition();
                    drawing.SelectShapesAt(mousePosition);
                }
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in drawing.SelectedShapes)
                        drawing.RemoveShape(s);
                }
                drawing.Draw();
                SplashKit.RefreshScreen(); //Target FPS? Should have an uint argument?
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}