using System;
using System.Collections.Generic;
using SplashKitSDK;
using System.IO;

namespace MultiShapeDraw
{
    public class Drawing
    {
        // private fields
        private readonly List<Shape> _shapes;
        private Color _background;

        // public properties 
        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        // A default constructor
        public Drawing() : this(Color.White)
        {
        }
        // Readonly property to access the shape count
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }
        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }
        // Select shapes
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> selectedShapes = new List<Shape>();
                foreach (Shape shape in _shapes)
                {
                    if (shape.Selected)
                    {
                        selectedShapes.Add(shape);
                    }
                }
                return selectedShapes;
            }
        }
        // Tells SplashKit to clear the screen to the background color
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape shape in _shapes)
            {
                shape.Draw();
            }
        }
        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape shape in _shapes)
            {
                shape.Selected = shape.IsAt(pt);
            }
        }
        // Method to add a shape to the list of shapes
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }
        // Removes the shapes 
        public void RemoveShape(Shape shape)
        {
            if (SelectedShapes.Count > 0)
            {
                    _shapes.Remove(shape);
            }
        }

        // Method to save the drawing to a file
        public void Save(string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    // Write the background color to the file
                    writer.WriteColor(Background);

                    // Write the number of shapes
                    writer.WriteLine(ShapeCount);

                    // Iterate through each shape and save it to the file
                    foreach (Shape s in _shapes)
                    {
                        s.SaveTo(writer);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving the drawing: " + ex.Message);
            }
        }

        // Method to load a drawing from a file
        public void Load(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    // Load background color
                    Background = reader.ReadColor();

                    // Clear existing shapes
                    _shapes.Clear();

                    // Read the number of shapes
                    int shapeCount = reader.ReadInteger();

                    for (int i = 0; i < shapeCount; i++)
                    {
                        string shapeType = reader.ReadLine();

                        Shape newShape = null;

                        // Create the appropriate shape based on the shapeType
                        switch (shapeType)
                        {
                            case "Rectangle":
                                newShape = new MyRectangle();
                                break;
                            case "Circle":
                                newShape = new MyCircle();
                                break;
                            case "Line":
                                newShape = new MyLine();
                                break;
                            default:
                                // Handle unknown shape types or errors
                                throw new InvalidDataException("Unknown shape kind: " + shapeType);
                        }

                        // Load the shape's data
                        newShape.LoadFrom(reader);

                        // Add the loaded shape to the drawing
                        _shapes.Add(newShape);
                    }
                }
            }
            //Bug fixing
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading drawing from {filename}: {ex.Message}");
            }
        }
    }
}

