namespace Optimized_3D_Graphic_Engine
{
    public class Cube
    {
        public static Model CreateCube()
        {
            Model model;

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

            model = new Model(vertices, triangles);
            return model;
        }
    }
}