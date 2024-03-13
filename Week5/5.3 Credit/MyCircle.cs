using MultiShapeDraw;
using SplashKitSDK;
using System.IO;

namespace MultiShapeDraw
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color color, float x, float y, int radius) : base(color)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public MyCircle() : this(Color.Blue, 0, 0, 50)
        {
        }

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void Draw()
        {
            SplashKit.FillCircle(Color, X, Y, Radius);
            if (Selected) DrawOutline();
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, Radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, Radius));
        }

        // Override the SaveTo method to save MyCircle-specific information
        public override void SaveTo(StreamWriter writer)
        {
            // Save shape type
            writer.WriteLine("Circle");

            // Save base class properties (color, X, Y)
            base.SaveTo(writer);

            // Save radius
            writer.WriteLine(Radius);
        }

        // Override the LoadFrom method to load MyCircle-specific information
        public override void LoadFrom(StreamReader reader)
        {
            // Load base class properties (color, X, Y)
            base.LoadFrom(reader);

            // Load radius
            Radius = reader.ReadInteger();
        }
    }
}
