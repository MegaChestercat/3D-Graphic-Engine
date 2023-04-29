﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
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
        Vertex line1, line2;
        Vertex triangleNormal;
        float[,]depth_buffer;
        float z;
        //float[] z_segment;

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
            depth_buffer = new float[width,height];
           // z_segment = new float[(int)Width];

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    depth_buffer[j, i] = 0;
                }
            }
            ClippingPlanes(90);
        }

        public void SetModelInstances(Instance[] instances)
        {
            /*
            cube = new Model(vertices, triangles);
            instances = new Instance[] {
                                    new Instance(cube, new Vertex( -1.25f,    0,    7 ), Matrix.Identity, 0.75f) };
                                    //new Instance(cube, new Vertex(  1.25f, 2.5f, 7.5f ), Matrix.RotY(195)),
                                    //new Instance(cube, new Vertex(     0,     0,  -10 ), Matrix.RotY(195))};
            */
            
            Render(instances);
        }

        private void ClippingPlanes(float fov)
        {
            Vertex left, right, bottom, top;
            float aspect = 1f;
            float near = 0.1f;

            float tanFov = (float)Math.Tan(fov * 0.5f * Math.PI / 180f);
            float height = 2f * tanFov * near;
            float width = height * aspect;

            // Left plane
            float sx = 1f * (width / 2f);
            float sy = 0f;
            float sz = near;

            left = new Vertex(sx, sy, sz);
            left = left.Normalize();

            // Right plane
            sx = -width / 2f;
            sy = 0f;
            sz = near;
            right = new Vertex(sx, sy, sz);
            right = right.Normalize();

            // Bottom plane
            sx = 0f;
            sy = -1f * (height / 2f);
            sz = near;
            bottom = new Vertex(sx, sy, sz);
            bottom = bottom.Normalize();

            // Top plane
            sx = 0f;
            sy = height / 2f;
            sz = near;
            top = new Vertex(sx, sy, sz);
            top = top.Normalize();

            camera.clipping_planes.Add(new Plane(new Vertex(0, 0, 1), 0));   // near
            camera.clipping_planes.Add(new Plane(left, 0));  // left
            camera.clipping_planes.Add(new Plane(right, 0));  // right
            camera.clipping_planes.Add(new Plane(top, 0));  // top
            camera.clipping_planes.Add(new Plane(bottom, 0));  // bottom
        }
        private void Render(Instance[] i)
        {
            RenderScene(camera, i);
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

        List<float> Interpolate(float i0, float d0, float i1, float d1)
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
        private void HiddenFaces(Triangle triangle, Vertex[] vertices)
        {
            line1 = new Vertex(vertices[triangle.v1].X - vertices[triangle.v0].X, vertices[triangle.v1].Y - vertices[triangle.v0].Y, vertices[triangle.v1].Z - vertices[triangle.v0].Z);
            line2 = new Vertex(vertices[triangle.v2].X - vertices[triangle.v0].X, vertices[triangle.v2].Y - vertices[triangle.v0].Y, vertices[triangle.v2].Z - vertices[triangle.v0].Z);
            triangleNormal = new Vertex(line1.Y * line2.Z - line1.Z * line2.Y, line1.Z * line2.X - line1.X * line2.Z, line1.X * line2.Y - line1.Y * line2.X);
            triangleNormal = triangleNormal.Normalize();
        }
        void RenderTriangle(Triangle triangle, List<Vertex> projected, Vertex[] vertices)
        {
            if (triangleNormal.X * (vertices[triangle.v0].X - camera.position.X) + triangleNormal.Y * (vertices[triangle.v0].Y - camera.position.Y) + triangleNormal.Z * (vertices[triangle.v0].Z - camera.position.Z) <= 0)
            {
                DrawFilledTriangle(projected[triangle.v0], projected[triangle.v1], projected[triangle.v2], triangle.color);
            }
            //DrawWireFrameTriangle(projected[triangle.v0], projected[triangle.v1], projected[triangle.v2], triangle.color);
        }

        
        public void DrawFilledTriangle(Vertex p1, Vertex p2, Vertex p3, Color c)
        {
            if (p2.Y < p1.Y) Swap(ref p2, ref p1);
            if (p3.Y < p1.Y) Swap(ref p3, ref p1);
            if (p3.Y < p2.Y) Swap(ref p3, ref p2);

            List<float> x01, x12, x02, x012;
            List<float> z01, z12, z02, z012;

            x01 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            x12 = Interpolate(p2.Y, p2.X, p3.Y, p3.X);
            x02 = Interpolate(p1.Y, p1.X, p3.Y, p3.X);

            z01 = Interpolate(p1.Z, p1.X, p2.Z, p2.X);
            z12 = Interpolate(p2.Z, p2.X, p3.Z, p3.X);
            z02 = Interpolate(p1.Z, p1.X, p3.Z, p3.X);

            //remove_last(x01);
            //Array.Resize(ref x01, x01.Length - 1);
            //x012 = x01.Concat(x12).ToArray();
            x012 = new List<float>();
            x012.AddRange(x01);
            x012.AddRange(x12);

            z012 = new List<float>();
            z012.AddRange(z01);
            z012.AddRange(z12);

            int m = x02.Count / 2;
            int m2 = z02.Count / 2;
            List<float> x_left, x_right;
            List<float> z_left, z_right;

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

            if (z02[m2] < z012[m2])
            {
                z_left = z02;
                z_right = z012;
            }
            else
            {
                z_left = z012;
                z_right = z02;
            }

            for (int y = (int)p1.Y; y < p3.Y; y++)
            {
                
                if(y - (int)p1.Y >= 0 && y - (int)p1.Y < x_left.Count && y - (int)p1.Y < x_right.Count)
                {
                    for (int x = (int)x_left[y - (int)p1.Y]; x < (int)x_right[y - (int)p1.Y]; x++)
                    {
                        z = (int)(x_right[(int)x - (int)p1.X] - x_left[(int)x - (int)p1.X]);
                        if(z <= depth_buffer[x,y])
                        {
                            PutPixel(x, y, c);
                            depth_buffer[x,y] = z;
                        }
                        
                    }
                }
                
            }
        }

        private List<Triangle> ClipTriangle(Triangle triangle, Plane plane, List<Triangle> triangles, List<Vertex> vertices)
        {
            Vertex v0 = vertices[triangle.v0];
            Vertex v1 = vertices[triangle.v1];
            Vertex v2 = vertices[triangle.v2];

            // vertices in front of the camera
            bool in0 = ((plane.normal * v0) + plane.Distance) > 0;
            bool in1 = ((plane.normal * v1) + plane.Distance) > 0;
            bool in2 = ((plane.normal * v2) + plane.Distance) > 0;

            int in_count = (in0 ? 1 : 0) + (in1 ? 1 : 0) + (in2 ? 1 : 0);

            if (in_count == 0)
            {
                //Console.WriteLine("count zero");
                // Nothing to do - the triangle is fully clipped out.
            }
            else if (in_count == 3)
            {
                // The triangle is fully in front of the plane.
                triangles.Add(triangle);
            }
            else if (in_count == 1)// one positive  
            {
                //Console.WriteLine("count one");
                // The triangle has one vertex in. Output is one clipped triangle.
            }
            else if (in_count == 2)// one negative
            {
                //Console.WriteLine("count two");
                // The triangle has two vertices in. Output is two clipped triangles.
            }

            return triangles;
        }


        private Model TransformAndClip(Plane[] clipping_planes, Model model, float scale, Matrix transform)
        {
            // Transform the bounding sphere, and attempt early discard.
            Vertex center = transform * model.bounds_center;
            float radius = model.bounds_radius * scale;
            for (int p = 0; p < clipping_planes.Length; p++)
            {
                float distance = (clipping_planes[p].normal * center) + clipping_planes[p].Distance;
                if (distance < -radius)
                {
                    return null;
                }
            }

            // Apply modelview transform.
            List<Vertex> vertices = new List<Vertex>();
            for (int i = 0; i < model.vertices.Length; i++)
            {
                vertices.Add(transform * model.vertices[i]);
            }

            // Clip the entire model against each successive plane.
            List<Triangle> triangles = new List<Triangle>(model.triangles);
            for (int p = 0; p < clipping_planes.Length; p++)
            {
                List<Triangle> new_triangles = new List<Triangle>();
                for (int i = 0; i < triangles.Count; i++)
                {
                    new_triangles = (ClipTriangle(triangles[i], clipping_planes[p], new_triangles, vertices));
                }
                triangles.AddRange(new_triangles);
            }

            return new Model(vertices.ToArray(), triangles.ToArray(), center, model.bounds_radius);
        }

        private void RenderModel(Model model)
        {
            List<Vertex> projected = new List<Vertex>();
            //Model model = instance.model;

            for (int i = 0; i < model.vertices.Length; i++)
            {
                projected.Add(ProjectVertex(model.vertices[i]));
            }

            for (int i = 0; i < model.triangles.Length; i++)
            {
                HiddenFaces(model.triangles[i],model.vertices);
                RenderTriangle(model.triangles[i], projected, model.vertices);
            }
        }

        Vertex ViewportToCanvas(Vertex p2d)
        {
            float vW = (float)bitmap.Width / bitmap.Height;
            return new Vertex((p2d.X * bitmap.Width / vW), (p2d.Y * bitmap.Height / viewport_size), p2d.Z);
        }

        Vertex ProjectVertex(Vertex v)
        {
            return ViewportToCanvas(new Vertex(v.X * projection_plane_z / (v.Z), v.Y * projection_plane_z / (v.Z), v.Z));
        }

        public void RenderScene(Camera camera, Instance[] instances)
        {
            Matrix cameraMatrix;
            Matrix transform;
            Model clipped;

            cameraMatrix = (camera.orientation.Transposed()) * Matrix.MakeTranslationMatrix(-camera.position) * Matrix.FOV();
            for (int i = 0; i < instances.Length; i++)
            {
                transform = (cameraMatrix * instances[i].transform);
                clipped = TransformAndClip(camera.clipping_planes.ToArray(), instances[i].model, instances[i].scale, transform);
                
                if(clipped != null)
                {
                    RenderModel(clipped);
                }
            }
        }
    }
}