namespace Optimized_3D_Graphic_Engine
{
    public class Cylinder
    {
        public static Model createCylinder(float radius, float height, int slices, bool front)
        {
            List<Vertex> vertices = new List<Vertex>();
            List<Triangle> triangles = new List<Triangle>();

            float angle = 2 * (float)Math.PI / slices;
            Vertex topCircle = new Vertex(0, height / 2, 0);
            Vertex bottomCircle = new Vertex(0, -height / 2, 0);
            int vertexIndex = 0;

            if (front)
            {
                for (int i = 0; i < slices; i++)
                {
                    //Top base of the cylinder
                    Vertex v1 = topCircle;
                    Vertex v2 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), height / 2, radius * (float)Math.Sin((i - 1) * angle));
                    Vertex v3 = new Vertex(radius * (float)Math.Cos(i * angle), height / 2, radius * (float)Math.Sin(i * angle));
                    triangles.Add(new Triangle(vertexIndex + 1, vertexIndex, vertexIndex + 2, Color.Yellow));
                    vertexIndex += 3;

                    //Bottom base of the cylinder
                    Vertex v4 = bottomCircle;
                    Vertex v5 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), -height / 2, radius * (float)Math.Sin((i - 1) * angle));
                    Vertex v6 = new Vertex(radius * (float)Math.Cos(i * angle), -height / 2, radius * (float)Math.Sin(i * angle));
                    triangles.Add(new Triangle(vertexIndex + 1, vertexIndex, vertexIndex + 2, Color.Yellow));
                    triangles.Add(new Triangle(vertexIndex, vertexIndex + 1, vertexIndex + 2, Color.Yellow));
                    vertexIndex += 3;

                    //Vertices that help on the construction of the cylinder
                    Vertex v7 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), height / 2, radius * (float)Math.Sin((i - 1) * angle));
                    Vertex v8 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), -height / 2, radius * (float)Math.Sin((i - 1) * angle));
                    Vertex v9 = new Vertex(radius * (float)Math.Cos(i * angle), height / 2, radius * (float)Math.Sin(i * angle));
                    Vertex v10 = new Vertex(radius * (float)Math.Cos(i * angle), -height / 2, radius * (float)Math.Sin(i * angle));
                    triangles.Add(new Triangle(vertexIndex, vertexIndex + 1, vertexIndex + 2, Color.Yellow));
                    triangles.Add(new Triangle(vertexIndex + 1, vertexIndex + 3, vertexIndex + 2, Color.Yellow));
                    vertexIndex += 4;

                    vertices.Add(v1);
                    vertices.Add(v2);
                    vertices.Add(v3);
                    vertices.Add(v4);
                    vertices.Add(v5);
                    vertices.Add(v6);
                    vertices.Add(v7);
                    vertices.Add(v8);
                    vertices.Add(v9);
                    vertices.Add(v10);
                }
            }
            else
            {
                for (int i = 0; i < slices; i++)
                {
                    //Top base of the cylinder
                    Vertex v1 = topCircle;
                    Vertex v2 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), height / 2, radius * (float)Math.Sin((i - 1) * angle));
                    Vertex v3 = new Vertex(radius * (float)Math.Cos(i * angle), height / 2, radius * (float)Math.Sin(i * angle));
                    triangles.Add(new Triangle(vertexIndex + 1, vertexIndex, vertexIndex + 2, Color.Yellow));
                    vertexIndex += 3;

                    //Bottom base of the cylinder
                    Vertex v4 = bottomCircle;
                    Vertex v5 = new Vertex(radius * (float)Math.Cos(i * angle), -height / 2, radius * (float)Math.Sin(i * angle));
                    Vertex v6 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), -height / 2, radius * (float)Math.Sin((i - 1) * angle));
                    triangles.Add(new Triangle(vertexIndex + 1, vertexIndex, vertexIndex + 2, Color.Yellow));
                    //triangles.Add(new Triangle(vertexIndex, vertexIndex + 1, vertexIndex + 2, Color.Yellow));
                    vertexIndex += 3;

                    //Vertices that help on the construction of the cylinder
                    Vertex v7 = new Vertex(radius * (float)Math.Cos(i * angle), height / 2, radius * (float)Math.Sin(i * angle));
                    Vertex v8 = new Vertex(radius * (float)Math.Cos(i * angle), -height / 2, radius * (float)Math.Sin(i * angle));
                    Vertex v9 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), height / 2, radius * (float)Math.Sin((i - 1) * angle));
                    Vertex v10 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), -height / 2, radius * (float)Math.Sin((i - 1) * angle));
                    //Vertex v7 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), height / 2, radius * (float)Math.Sin((i - 1) * angle));
                    //Vertex v8 = new Vertex(radius * (float)Math.Cos((i - 1) * angle), -height / 2, radius * (float)Math.Sin((i - 1) * angle));
                    //Vertex v9 = new Vertex(radius * (float)Math.Cos(i * angle), height / 2, radius * (float)Math.Sin(i * angle));
                    //Vertex v10 = new Vertex(radius * (float)Math.Cos(i * angle), -height / 2, radius * (float)Math.Sin(i * angle));
                    triangles.Add(new Triangle(vertexIndex, vertexIndex + 1, vertexIndex + 2, Color.Yellow));
                    triangles.Add(new Triangle(vertexIndex + 1, vertexIndex + 3, vertexIndex + 2, Color.Yellow));
                    vertexIndex += 4;

                    vertices.Add(v1);
                    vertices.Add(v2);
                    vertices.Add(v3);
                    vertices.Add(v4);
                    vertices.Add(v5);
                    vertices.Add(v6);
                    vertices.Add(v7);
                    vertices.Add(v8);
                    vertices.Add(v9);
                    vertices.Add(v10);
                }
            }

            Model mesh = new Model(vertices.ToArray(), triangles.ToArray(), new Vertex(0, 0, 0), (float)Math.Sqrt(3));
            return mesh;
        }
    }
}