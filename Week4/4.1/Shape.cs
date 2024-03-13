using System;
using SplashKitSDK;

namespace MultiShapeDraw
{
    public abstract class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private bool _selected;

        public Shape() : this(Color.White)
        {
        }

        // Constructor to initialize the shape's properties.
        public Shape(Color color)
        {
            _color = color;
            _x = 0;
            _y = 0;
        }

        // Property to get or set the X-coordinate of the shape
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        // Property to get or set the Y-coordinate of the shape
        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        // Property to get or set the color of the shape
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        // Property to get or set whether the shape is selected
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        // Method to draw the shape on the screen using SplashKit
        public abstract void Draw();

        // Method to draw a black outline when the shape is selected
        public abstract void DrawOutline();

        // Method to check if a given point is within the boundaries of the shape
        public abstract bool IsAt(Point2D pt);


    }
}