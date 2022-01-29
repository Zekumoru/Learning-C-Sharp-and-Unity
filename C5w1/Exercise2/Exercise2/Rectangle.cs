using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{

    public class Rectangle : IComparable
    {
        public float Width { get; private set; }
        public float Height { get; private set; }

        public float Area
        {
            get { return Width * Height; }
        }

        public Rectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Rectangle other = obj as Rectangle;
            if (other == null) throw new ArgumentException("Comparing objects with different types!");
            if (Area < other.Area) return -1;
            if (Area > other.Area) return 1;
            return 0;
        }

        public override string ToString()
        {
            return $"Width: {Width}, Height: {Height}, Area: {Area}";
        }
    }
}
