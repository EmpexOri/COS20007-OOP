using MultiShapeDraw;
using SplashKitSDK;

public class MyLine : Shape
{
    // Private fields for the end coordinates
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

    // Public properties for start and end coordinates

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
        //const double Tolerance = 5.0;
        //double distanceToStart = SplashKit.PointPointDistance(pt, new Point2D() { X = 10, Y = 10 });
        //double distanceToEnd = SplashKit.PointPointDistance(pt, new Point2D() { X = EndX, Y = EndY });
        //return distanceToStart < Tolerance || distanceToEnd < Tolerance;
        return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, EndX, EndY), 10.0f);
    }
}
