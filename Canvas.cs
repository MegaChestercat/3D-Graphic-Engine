using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Optimized_3D_Graphic_Engine
{
    public class Canvas
    {

        public Bitmap bitmap;
        public float Width, Height;
        public byte[] bits;
        Graphics g;
        int pixelFormatSize, stride;
        float viewport_size = 1;
        float projection_plane_z = 1;

        Model cube;
        public Camera camera = new Camera(new Vertex(0, 0, 0), Matrix.RotY(0));
        Instance[] instances;

        public Bitmap Bitmap
        {
            get { return bitmap; }
        }

        public Canvas(Size s)
        {
            Init(s.Width, s.Height);
        }

        Vertex[] vertices = new Vertex[] {
                                            new Vertex(1, 1, 1),
                                            new Vertex(-1, 1, 1),
                                            new Vertex(-1, -1, 1),
                                            new Vertex(1, -1, 1),
                                            new Vertex(1, 1, -1),
                                            new Vertex(-1, 1, -1),
                                            new Vertex(-1, -1, -1),
                                            new Vertex(1, -1, -1)
        };


        Triangle[] triangles = new Triangle[] {
                                            new Triangle(0, 1, 2, Color.Red),
                                            new Triangle(0, 2, 3, Color.Red),
                                            new Triangle(4, 0, 3, Color.Green),
                                            new Triangle(4, 3, 7, Color.Green),
                                            new Triangle(5, 4, 7, Color.Blue),//-----------------------
                                            new Triangle(5, 7, 6, Color.Blue),
                                            new Triangle(1, 5, 6, Color.Yellow),
                                            new Triangle(1, 6, 2, Color.Yellow),
                                            new Triangle(4, 5, 1, Color.Purple),
                                            new Triangle(4, 1, 0, Color.Purple),
                                            new Triangle(2, 6, 7, Color.Cyan),
                                            new Triangle(2, 7, 3, Color.Cyan)
        };

        

        public void Init(int width, int height)
        {
            PixelFormat format;
            GCHandle handle; //puntero
            IntPtr bitPtr; // puntero the two previous pointers are to protect the images and the bits from being deleted
            int padding;

            format = PixelFormat.Format32bppArgb;

            Width = width;
            Height = height;
            pixelFormatSize = Image.GetPixelFormatSize(format) / 8; // 8 bits = 1 byte
            stride = width * pixelFormatSize;
            padding = (stride % 4);
            stride += padding == 0 ? 0 : 4 - padding; //4 byte multiple Alpha, Red, Green, Blue
            bits = new byte[stride * height]; //Total pixels (width) times ARGB (4) times height
            handle = GCHandle.Alloc(bits, GCHandleType.Pinned);
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bitmap = new Bitmap(width, height, stride, format, bitPtr);

            g = Graphics.FromImage(bitmap);
        }

        public void SetModelInstances()
        {
            cube = new Model(vertices, triangles);
            instances = new Instance[] {
                                    new Instance(cube, new Vertex( -1.25f,    0,    7 ), Matrix.Identity, 0.75f) };
                                    //new Instance(cube, new Vertex(  1.25f, 2.5f, 7.5f ), Matrix.RotY(195)),
                                    //new Instance(cube, new Vertex(     0,     0,  -10 ), Matrix.RotY(195))};
            Render();
        }
        private void Render()
        {
            RenderScene(camera, instances);
        }
        public void PutPixel(int x, int y, Color c)
        {
            x = (int)(Width/2) + x;
            y = (int)(Height/2) - y -1;

            if (x < 0 || x >= Width || y < 0 || y >= Height) return;

            int res = (int)((x * pixelFormatSize) + (y * stride)); //x an y point of your image. Stride is the complete size of a row and its multiply by x that is the number of rows
            
            bits[res + 0] = c.B;
            bits[res + 1] = c.G;
            bits[res + 2] = c.R;
            bits[res + 3] = c.A; //Transparency
        }

        public void FastClear()
        {
            unsafe
            {
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadWrite, bitmap.PixelFormat);

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* bits = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0; //(byte) Blue;
                        bits[x + 1] = 0; //(byte) Green;
                        bits[x + 2] = 0; //(byte) Red;
                        bits[x + 3] = 0; //(byte) Alpha
                    }
                });
                bitmap.UnlockBits(bitmapData);
            }
        }

        public void Swap(ref Vertex p1, ref Vertex p2)
        {
            Vertex temp = p1;

            p1 = p2;
            p2 = temp;
        }

        List<float> Interpolate(int i0, float d0, int i1, float d1)
        {
            if (i0 == i1)
            {
                return new List<float>(){ d0 };
            }

            List<float> values = new List<float>();
            float a = (d1 - d0) / (i1 - i0);
            float d = d0;

            for (var i = i0; i <= i1; i++)
            {
                values.Add(d);
                d += a;
            }
            return values;
        }

        public void DrawLine(Vertex p1, Vertex p2, Color c)
        {
            var dx = p2.X - p1.X;
            var dy = p2.Y - p1.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (dx < 0) Swap(ref p1, ref p2);
                var ys = Interpolate((int)p1.X, p1.Y, (int)p2.X, p2.Y);
                for (var x = (int)p1.X; x <= p2.X; x++)
                {
                    PutPixel(x, (int)ys[x - (int)p1.X], c);
                }
            }
            else
            {
                if (dy < 0) Swap(ref p1, ref p2);
                var xs = Interpolate((int)p1.Y, p1.X, (int)p2.Y, p2.X);
                for (var y = (int)p1.Y; y <= p2.Y; y++)
                {
                    PutPixel((int)xs[y - (int)p1.Y], y, c);
                }
            }
        }

        public void DrawWireFrameTriangle(Vertex p1, Vertex p2, Vertex p3, Color c)
        {
            DrawLine(p1, p2, c);
            DrawLine(p2, p3, c);
            DrawLine(p1, p3, c);
        }
        void RenderTriangle(Triangle triangle, List<Vertex> projected)
        {
            DrawWireFrameTriangle(projected[triangle.v0], projected[triangle.v1], projected[triangle.v2], triangle.color);
        }

        /*
        public void DrawFilledTriangle(PointF3D p1, PointF3D p2, PointF3D p3, Color c)
        {
            if (p2.Y < p1.Y) Swap(ref p2, ref p1);
            if (p3.Y < p1.Y) Swap(ref p3, ref p1);
            if (p3.Y < p2.Y) Swap(ref p3, ref p2);

            Double[] x01, x12, x02, x012;

            x01 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            x12 = Interpolate(p2.Y, p2.X, p3.Y, p3.X);
            x02 = Interpolate(p1.Y, p1.X, p3.Y, p3.X);

            //remove_last(x01);
            Array.Resize(ref x01, x01.Length - 1);
            x012 = x01.Concat(x12).ToArray();

            int m = (int)Math.Floor(x02.Length / 2.0);
            Double[] x_left, x_right;
            if (x02[m] < x012[m])
            {
                x_left = x02;
                x_right = x012;
            }
            else
            {
                x_left = x012;
                x_right = x02;
            }

            for (int y = p1.Y; y < p3.Y; y++)
            {
                for (int x = (int)x_left[y - p1.Y]; x < (int)x_right[y - p1.Y]; x++)
                {
                    PutPixel(x, y, c);
                }
            }
        }*/
        private void RenderModel(Instance instance, Matrix transform)
        {
            List<Vertex> projected = new List<Vertex>();
            Model model = instance.model;

            for (int i = 0; i < model.vertices.Length; i++)
            {
                projected.Add(ProjectVertex(transform * model.vertices[i]));
            }

            for (int i = 0; i < model.triangles.Length; i++)
            {
                RenderTriangle(model.triangles[i], projected);
            }
        }

        Vertex ViewportToCanvas(Vertex p2d)
        {
            float vW = (float)bitmap.Width / bitmap.Height;
            return new Vertex((p2d.X * bitmap.Width / vW), (p2d.Y * bitmap.Height / viewport_size), 0);
        }

        Vertex ProjectVertex(Vertex v)
        {
            return ViewportToCanvas(new Vertex(v.X * projection_plane_z / (v.Z), v.Y * projection_plane_z / (v.Z), 0));
        }

        public void RenderScene(Camera camera, Instance[] instances)
        {
            Matrix cameraMatrix;
            Matrix transform;

            cameraMatrix = (camera.orientation.Transposed()) * Matrix.MakeTranslationMatrix(-camera.position) * Matrix.FOV();
            for (int i = 0; i < instances.Length; i++)
            {
                transform = (cameraMatrix * instances[i].transform);
                RenderModel(instances[i], transform);
            }
        }
    }
}