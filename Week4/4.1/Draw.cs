using System;
using System.Collections.Generic;
using SplashKitSDK;

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
    }
}
