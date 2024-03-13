using MultiShapeDraw;
using SplashKitSDK;
using System.IO;

namespace MultiShapeDraw
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public MyRectangle() : this(Color.Green, 0, 0, 100, 100)
        {
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
            if (Selected) DrawOutline();
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X - 2, Y - 2, Width + 4, Height + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInRectangle(pt, SplashKit.RectangleFrom(X, Y, Width, Height));
        }

        // Override the SaveTo method to save MyRectangle-specific information
        public override void SaveTo(StreamWriter writer)
        {
            // Save shape type
            writer.WriteLine("Rectangle");

            // Save base class properties (color, X, Y)
            base.SaveTo(writer);

            // Save width and height
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }

        // Override the LoadFrom method to load MyRectangle-specific information
        public override void LoadFrom(StreamReader reader)
        {
            // Load base class properties (color, X, Y)
            base.LoadFrom(reader);

            // Load width and height
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
