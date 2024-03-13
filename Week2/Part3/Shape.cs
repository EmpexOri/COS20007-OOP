using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;
        private double _x;
        private double _y;
        private int _width;
        private int _height;

        public Shape()
        {
            _color = Color.Green;
            _x = 100;
            _y = 100;
            _width = 100;
            _height = 100;
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public bool IsAt(Point2D pt)
        {
            return pt.X >= _x && pt.X <= _x + _width && pt.Y >= _y && pt.Y <= _y + _height;
        }
    }
}