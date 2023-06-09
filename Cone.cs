﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimized_3D_Graphic_Engine
{
    public class Cone
    {
        public static Model createCone(float radius, float height, int slices, bool front)
        {

            List<Vertex> vertices = new List<Vertex>();
            List<Triangle> triangles = new List<Triangle>();

            Vertex center = new Vertex(0, 0, 0);

            if (front)
            {
                for (int i = 0; i < slices; i++)
                {
                    float angle1 = 2 * (float)Math.PI * i / slices;
                    float angle2 = 2 * (float)Math.PI * (i + 1) / slices;

                    Vertex v1 = new Vertex(center.X + radius * (float)Math.Cos(angle1), center.Y + radius * (float)Math.Sin(angle1), center.Z);
                    Vertex v2 = new Vertex(center.X + radius * (float)Math.Cos(angle2), center.Y + radius * (float)Math.Sin(angle2), center.Z);
                    Vertex v3 = center;

                    vertices.Add(v2);
                    vertices.Add(v1);
                    vertices.Add(v3);

                    int index1 = (i * 3) + 2;
                    int index2 = (i * 3) + 1;
                    int index3 = (i * 3);

                    triangles.Add(new Triangle(index1, index2, index3, Color.Yellow));
                }
            }
            else
            {
                for (int i = 0; i < slices; i++)
                {
                    float angle1 = 2 * (float)Math.PI * i / slices;
                    float angle2 = 2 * (float)Math.PI * (i + 1) / slices;

                    Vertex v1 = new Vertex(center.X + radius * (float)Math.Cos(angle2), center.Y + radius * (float)Math.Sin(angle2), center.Z);
                    Vertex v2 = new Vertex(center.X + radius * (float)Math.Cos(angle1), center.Y + radius * (float)Math.Sin(angle1), center.Z);
                    Vertex v3 = center;

                    vertices.Add(v2);
                    vertices.Add(v1);
                    vertices.Add(v3);

                    int index1 = (i * 3) + 2;
                    int index2 = (i * 3) + 1;
                    int index3 = (i * 3);

                    triangles.Add(new Triangle(index1, index2, index3, Color.Yellow));
                }
            }
            

            Vertex apex = new Vertex(center.X, center.Y, center.Z + height);

            for (int i = 0; i < slices; i++)
            {
                float angle1 = 2 * (float)Math.PI * i / slices;
                float angle2 = 2 * (float)Math.PI * (i + 1) / slices;

                Vertex v1 = new Vertex(center.X + radius * (float)Math.Cos(angle1), center.Y + radius * (float)Math.Sin(angle1), center.Z);
                Vertex v2 = new Vertex(center.X + radius * (float)Math.Cos(angle2), center.Y + radius * (float)Math.Sin(angle2), center.Z);
                Vertex v3 = apex;

                vertices.Add(v1);
                vertices.Add(v2);
                vertices.Add(v3);

                int index1 = (slices * 3) + (i * 3);
                int index2 = (slices * 3) + (i * 3) + 1;
                int index3 = (slices * 3) + (i * 3) + 2;

                triangles.Add(new Triangle(index1, index2, index3, Color.Yellow));
            }

            Model mesh = new Model(vertices.ToArray(), triangles.ToArray(), new Vertex(0, 0, 0), (float)Math.Sqrt(3));
            return mesh;
        }
    }
}