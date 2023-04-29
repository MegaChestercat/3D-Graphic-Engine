using System.Drawing;

namespace Optimized_3D_Graphic_Engine
{
    public class Sphere
    {
        public static Model CreateSphere(float radius, int numSegments)
        {
            Model model;
            List<Vertex> vertices = new List<Vertex>();
            List<Triangle> triangles = new List<Triangle>();

            for (int i = 0; i < numSegments + 1; i++) //The next cycles are useful to iterate over all the segments the sphere is going to have, where each segment is going to have a determined value of latitude, longitude, and as a consequence multiple 3D points will be generated (that are going to be useful so the sphere will be composed of many small triangles at the end). 
            {
                float southPoleLatitude = (float)Math.PI * (-0.5f + (float)(i - 1) / numSegments);
                float south_Z = (float)Math.Sin(southPoleLatitude) * radius;
                float southRadius_Z = (float)Math.Cos(southPoleLatitude) * radius;

                float northPoleLatitude = (float)Math.PI * (-0.5f + (float)i / numSegments);
                float north_Z = (float)Math.Sin(northPoleLatitude) * radius;
                float northRadius_Z = (float)Math.Cos(northPoleLatitude) * radius;

                bool isSouthPole = i == 0;

                for (int j = 0; j < numSegments; j++)
                {
                    float LeftEdgeLng = (float)(2 * Math.PI * (float)(j - 1) / numSegments);
                    float x1 = (float)Math.Cos(LeftEdgeLng) * southRadius_Z;
                    float y1 = (float)Math.Sin(LeftEdgeLng) * southRadius_Z;

                    float RightEdgeLng = (float)(2 * Math.PI * (float)j / numSegments);
                    float x2 = (float)Math.Cos(RightEdgeLng) * southRadius_Z;
                    float y2 = (float)Math.Sin(RightEdgeLng) * southRadius_Z;

                    float x3 = (float)Math.Cos(LeftEdgeLng) * northRadius_Z;
                    float y3 = (float)Math.Sin(LeftEdgeLng) * northRadius_Z;

                    float x4 = (float)Math.Cos(RightEdgeLng) * northRadius_Z;
                    float y4 = (float)Math.Sin(RightEdgeLng) * northRadius_Z;

                    Vertex a = new Vertex(x1, y1, south_Z);
                    Vertex b = new Vertex(x2, y2, south_Z);
                    Vertex c = new Vertex(x3, y3, north_Z);
                    Vertex d = new Vertex(x4, y4, north_Z);

                    if (isSouthPole)
                    {
                        triangles.Add(new Triangle(vertices.Count + 1, vertices.Count, vertices.Count + 2, Color.Yellow));

                    }
                    else
                    {
                        triangles.Add(new Triangle(vertices.Count, vertices.Count + 1, vertices.Count + 2, Color.Yellow));
                    }

                    vertices.Add(a);
                    vertices.Add(b);
                    vertices.Add(c);
                    vertices.Add(d);
                }

            }
            
            model = new Model(vertices.ToArray(), triangles.ToArray(), new Vertex(0, 0, 0), (float)Math.Sqrt(3));

            return model;

        }
    }
}