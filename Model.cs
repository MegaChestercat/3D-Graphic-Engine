namespace Optimized_3D_Graphic_Engine
{
    public class Model
    {
        public Vertex[] vertices;
        public Triangle[] triangles;

        public Model(Vertex[] vertices, Triangle[] triangles)
        {
            this.vertices = vertices;
            this.triangles = triangles;
        }
    }
}