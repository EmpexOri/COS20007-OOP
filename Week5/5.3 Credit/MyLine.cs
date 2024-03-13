using MultiShapeDraw;
using SplashKitSDK;
using System.IO;

public class MyLine : Shape
{
    private float _endX;
    private float _endY;

    public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
    {
        _endX = endX;
        _endY = endY;
    }

    public MyLine() : this(Color.Purple, 0, 0, 100, 100)
    {
    }

    public float EndX
    {
        get { return _endX; }
        set { _endX = value; }
    }

    public float EndY
    {
        get { return _endY; }
        set { _endY = value; }
    }

    public override void Draw()
    {
        SplashKit.DrawLine(Color, X, Y, EndX, EndY);
        if (Selected) DrawOutline();
    }

    public override void DrawOutline()
    {
        SplashKit.FillCircle(Color.Black, X, Y, 5);
        SplashKit.FillCircle(Color.Black, EndX, EndY, 5);
    }

    public override bool IsAt(Point2D pt)
    {
        return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, EndX, EndY), 10.0f);
    }

    // Override the SaveTo method to save MyLine-specific information
    public override void SaveTo(StreamWriter writer)
    {
        // Save shape type
        writer.WriteLine("Line");

        // Save base class properties (color, X, Y)
        base.SaveTo(writer);

        // Save end coordinates
        writer.WriteLine(EndX);
        writer.WriteLine(EndY);
    }

    // Override the LoadFrom method to load MyLine-specific information
    public override void LoadFrom(StreamReader reader)
    {

        // Load base class properties (color, X, Y)
        base.LoadFrom(reader);

        // Load end coordinates
        EndX = reader.ReadInteger();
        EndY = reader.ReadInteger();
    }
}
