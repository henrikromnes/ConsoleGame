using System;
using System.Collections.Generic;
using System.Text;

namespace blitzCodeDraft
{
    class Figure
    {
        public Shape Shape;
        public Color Color;

        public Figure(Shape shape, Color color)
        {
            Shape = shape;
            Color = color;
        }
    }
}
