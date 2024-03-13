using System;
using System.Security.Cryptography.X509Certificates;
using MultiShapeDraw;
using SplashKitSDK;

namespace MultiShapeDraw
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            // Create a window and a drawing object
            Window window = new Window("Shape Drawer", 800, 600);
            Drawing myDrawing = new Drawing(Color.White);
            ShapeKind kindToAdd = ShapeKind.Circle;

            do
            {
                // Process events and clear the screen
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                // Get the mouse position
                Point2D pt = SplashKit.MousePosition();

                // Check for keyboard input to change the kind of shape to add
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                // Check for left mouse button click to add a new shape
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;

                    // Create a new shape based on the selected kind
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newShape = newCircle;
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newShape = newRect;
                    }
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine newLine = new MyLine();
                        newShape = newLine;
                    }
                    else
                    {
                        newShape = null;
                    }

                    if (newShape != null)
                    {
                        myDrawing.AddShape(newShape);

                        // Set X and Y coordinates after adding the shape
                        newShape.X = SplashKit.MouseX();
                        newShape.Y = SplashKit.MouseY();
                    }
                }

                // Remove Shapes
                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape shape in myDrawing.SelectedShapes)
                    {
                        myDrawing.RemoveShape(shape);
                    }
                }

                // Check for right mouse button click to select shapes
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    // Select shapes first
                    myDrawing.SelectShapesAt(pt);
                }

                // Check for 'S' key press to save the drawing
                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string filename = Path.Combine(desktopPath, "TestDrawing.txt");

                    myDrawing.Save(filename);
                    Console.WriteLine("Drawing saved to " + filename);
                }

                // Check for 'O' key press to open (load) the test drawing file
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string filename = Path.Combine(desktopPath, "TestDrawing.txt");

                        myDrawing.Load(filename);
                        Console.WriteLine("Drawing loaded from " + filename);
                    } catch (Exception e) 
                    { 
                        Console.WriteLine("Error Loading File: {0}", e.Message); 
                    }

                }

                // Draw the shapes and refresh the screen
                myDrawing.Draw();
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
