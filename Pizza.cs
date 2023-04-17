using System.Drawing;

namespace Optimized_3D_Graphic_Engine
{
   public class Pizza
    {
        public static Model CreateCircle(int radius, int height, int slices)
        {
            Model model;

            double initialAngle = 0;
            double finalAngle = (360 / slices) * (Math.PI / 180);

            List<Vertex> vertices = new List<Vertex>();
            List<Triangle> triangles = new List<Triangle>();

            Vertex a = new Vertex(0, 0, height);
            vertices.Add(a);

            for (int i = 0; i < slices; i++) //This loop helps so all the triangles that compose a circle/pizza can be created with a certain rotation angle depending the number of slices that is being used.
            {
                Vertex b = new Vertex((float)(radius * Math.Cos(initialAngle)), (float)(radius * Math.Sin(initialAngle)), height);
                Vertex c = new Vertex((float)(radius * Math.Cos(finalAngle)), (float)(radius * Math.Sin(finalAngle)), height);

                triangles.Add(new Triangle(0, vertices.Count, vertices.Count+1, Color.Yellow));
                
                initialAngle = finalAngle;
                finalAngle += (360.0 / slices) * (Math.PI / 180.0);

                vertices.Add(b);
                vertices.Add(c);
            }
            model = new Model(vertices.ToArray(), triangles.ToArray());
            return model;
        }
    }
}