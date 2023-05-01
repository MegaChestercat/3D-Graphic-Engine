namespace Optimized_3D_Graphic_Engine
{
    public class Matrix
    {
        public static int fovValue = 90;
        public float[,] data;

        public float this[int x, int y]
        {
            get { return data[x, y]; }
            set { data[x, y] = value; }
        }
        public static Matrix FOV()
        {
            float a = fovValue; // aperture DEGREES
            float r = 1; // aspecto ratio
            float zNear = 1f;
            float zFar = 10000;
            float fov = (float)((Math.PI / 180) * (a));//aperture rads
            float tanHalfFOV = (float)Math.Tan(fov / 2);
            float zRange = zNear - zFar;
            float f = 1.0f / tanHalfFOV;
            float q = (zNear + zFar) / zRange;

            return new Matrix(new float[,]
            {
                {f*r, 0, 0, 0 },
                {0, f, 0, 0 },
                {0, 0, -q, 2*zNear*q },
                {0, 0, 1, 0 }
            });
        }

        public Matrix Transposed()
        {
            Matrix result = new Matrix(new float[4, 4]);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i, j] = data[j, i];
                }
            }
            return result;
        }

        public static Matrix Identity = new Matrix(new float[,] {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}});

        
        public static Matrix MakeScalingMatrix(float scale)
        {
            return new Matrix(new float[,] {
                {scale,     0,     0,  0},
                {    0, scale,     0,  0},
                {    0,     0, scale,  0},
                {    0,     0,     0,  1}});
        }

        
        public static Matrix MakeTranslationMatrix(Vertex translation)
        {
            return new Matrix(new float[,] {
                {1,  0,  0,  translation.X},
                {0,  1,  0,  translation.Y},
                {0,  0,  1,  translation.Z},
                {0,  0,  0,              1}});
        }

        public static Matrix Rotate(float angle)
        {
            Matrix x, y, z;

            x = RotX(angle);
            y = RotY(angle);
            z = RotZ(angle);

            return x * y * z;
        }

        public static Matrix RotX(float angle)
        {
            float cos = (float)Math.Cos(angle * Math.PI / 180.0);
            float sin = (float)Math.Sin(angle * Math.PI / 180.0);

            return new Matrix(new float[,]{
                {1,     0 ,  0  , 0},
                {0,   cos ,-sin , 0},
                {0,   sin , cos , 0},
                {0,     0 ,  0  , 1}
            });
        }

        public static Matrix RotY(float angle)
        {
            float cos = (float)Math.Cos(angle * Math.PI / 180.0);
            float sin = (float)Math.Sin(angle * Math.PI / 180.0);

            return new Matrix(new float[,] {
                { cos,   0, -sin,   0},
                {   0,   1,    0,   0},
                { sin,   0,  cos,   0},
                {   0,   0,    0,   1}});
        }

        public static Matrix RotZ(float angle)
        {
            float cos = (float)Math.Cos(angle * Math.PI / 180.0);
            float sin = (float)Math.Sin(angle * Math.PI / 180.0);

            return new Matrix(new float[,]{
                {cos,  -sin ,  0  , 0},
                {sin,   cos ,  0  , 0},
                {0,       0 ,  1  , 0},
                {0,       0 ,  0  , 1}
            });
        }

        public Matrix(float[,] data)
        {
            this.data = data;
        }

        public static Matrix operator *(Matrix m, Matrix r)
        {
            Matrix res = new Matrix(new float[4, 4]);
            //res[i, j] = m[i, 0] * r[0, j] + m[i, 1] * r[1, j] + m[i, 2] * r[2, j] + m[i, 3] * r[3, j];
            res[0, 0] = m[0, 0] * r[0, 0] + m[0, 1] * r[1, 0] + m[0, 2] * r[2, 0] + m[0, 3] * r[3, 0];
            res[0, 1] = m[0, 0] * r[0, 1] + m[0, 1] * r[1, 1] + m[0, 2] * r[2, 1] + m[0, 3] * r[3, 1];
            res[0, 2] = m[0, 0] * r[0, 2] + m[0, 1] * r[1, 2] + m[0, 2] * r[2, 2] + m[0, 3] * r[3, 2];
            res[0, 3] = m[0, 0] * r[0, 3] + m[0, 1] * r[1, 3] + m[0, 2] * r[2, 3] + m[0, 3] * r[3, 3];

            res[1, 0] = m[1, 0] * r[0, 0] + m[1, 1] * r[1, 0] + m[1, 2] * r[2, 0] + m[1, 3] * r[3, 0];
            res[1, 1] = m[1, 0] * r[0, 1] + m[1, 1] * r[1, 1] + m[1, 2] * r[2, 1] + m[1, 3] * r[3, 1];
            res[1, 2] = m[1, 0] * r[0, 2] + m[1, 1] * r[1, 2] + m[1, 2] * r[2, 2] + m[1, 3] * r[3, 2];
            res[1, 3] = m[1, 0] * r[0, 3] + m[1, 1] * r[1, 3] + m[1, 2] * r[2, 3] + m[1, 3] * r[3, 3];

            res[2, 0] = m[2, 0] * r[0, 0] + m[2, 1] * r[1, 0] + m[2, 2] * r[2, 0] + m[2, 3] * r[3, 0];
            res[2, 1] = m[2, 0] * r[0, 1] + m[2, 1] * r[1, 1] + m[2, 2] * r[2, 1] + m[2, 3] * r[3, 1];
            res[2, 2] = m[2, 0] * r[0, 2] + m[2, 1] * r[1, 2] + m[2, 2] * r[2, 2] + m[2, 3] * r[3, 2];
            res[2, 3] = m[2, 0] * r[0, 3] + m[2, 1] * r[1, 3] + m[2, 2] * r[2, 3] + m[2, 3] * r[3, 3];

            res[3, 0] = m[3, 0] * r[0, 0] + m[3, 1] * r[1, 0] + m[3, 2] * r[2, 0] + m[3, 3] * r[3, 0];
            res[3, 1] = m[3, 0] * r[0, 1] + m[3, 1] * r[1, 1] + m[3, 2] * r[2, 1] + m[3, 3] * r[3, 1];
            res[3, 2] = m[3, 0] * r[0, 2] + m[3, 1] * r[1, 2] + m[3, 2] * r[2, 2] + m[3, 3] * r[3, 2];
            res[3, 3] = m[3, 0] * r[0, 3] + m[3, 1] * r[1, 3] + m[3, 2] * r[2, 3] + m[3, 3] * r[3, 3];

            return res;
        }

        
    }
}