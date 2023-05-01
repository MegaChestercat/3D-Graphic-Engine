namespace Optimized_3D_Graphic_Engine
{

    public class Vertex //The PointF3D class collects the X, Y, and Z coordinates of an specific point. It is also possible to get or set a particular value of a determined coordinate.
    {
        public float xLoc, yLoc, zLoc, w;
        public Color c;

        public float A
        {
            get { return c.A; }
        }
        public float R
        {
            get { return c.R; }
        }
        public float G
        {
            get { return c.G; }
        }
        public float B
        {
            get { return c.B; }
        }
        public Color C
        {
            get { return c; }
            set
            {
                c = value;
            }
        }

        public float X
        {
            get
            {
                return xLoc;
            }
            set
            {
                xLoc = value;
            }
        }

        public float Y
        {
            get
            {
                return yLoc;
            }
            set
            {
                yLoc = value;
            }
        }

        public float Z
        {
            get
            {
                return zLoc;
            }
            set
            {
                zLoc = value;
            }
        }

        public float W
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
            }
        }

        public Vertex(float xLoc, float yLoc, float zLoc)
        {
            this.xLoc = xLoc;
            this.yLoc = yLoc;
            this.zLoc = zLoc;
            this.w = 1;
        }

        public Vertex(float xLoc, float yLoc, float zLoc, Color c)
        {
            this.xLoc = xLoc;
            this.yLoc = yLoc;
            this.zLoc = zLoc;
            this.w = 1;
            this.c = c;
        }

        public static float operator *(Vertex v1, Vertex v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Y * v2.Y;
        }

        public static Vertex operator +(Vertex v1, Vertex v2)
        {
            return new Vertex(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vertex operator -(Vertex v1, Vertex v2)
        {
            return new Vertex(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vertex operator -(Vertex v)
        {
            return new Vertex(-v.X, -v.Y, -v.Z);
        }
        public static Vertex operator /(Vertex v1, float a)
        {
            return new Vertex(v1.X / a, v1.Y / a, v1.Z / a);
        }

        public static Vertex operator *(Vertex v1, float b)
        {
            return new Vertex(v1.X * b, v1.Y * b, v1.Z * b);
        }

        //public static Vertex operator *(Matrix m, Vertex v) // 3D vector
        //{
        //    Vertex pts;

        //    pts = new Vertex(0f, 0f, 0f);

        //    pts.X = (m[0, 0] * v.X) + (m[0, 1] * v.Y) + (m[0, 2] * v.Z) + (m[0, 3] * v.W);
        //    pts.Y = (m[1, 0] * v.X) + (m[1, 1] * v.Y) + (m[1, 2] * v.Z) + (m[1, 3] * v.W);
        //    pts.Z = (m[2, 0] * v.X) + (m[2, 1] * v.Y) + (m[2, 2] * v.Z) + (m[2, 3] * v.W);
        //    pts.W = (m[3, 0] * v.X) + (m[3, 1] * v.Y) + (m[3, 2] * v.Z) + (m[3, 3] * v.W);

        //    return pts;
        //}

        public float Mag()
        {
            return (float)Math.Sqrt(xLoc * xLoc + yLoc * yLoc + zLoc * zLoc);
        }

        public Vertex Normalize()
        {
            float mag = this.Mag();
            return new Vertex(xLoc / mag, yLoc / mag, zLoc / mag);
        }
    }
}