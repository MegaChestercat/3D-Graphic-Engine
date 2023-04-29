namespace Optimized_3D_Graphic_Engine
{
    public class Model
    {
        public Vertex[] vertices;
        public Triangle[] triangles;
        public Vertex bounds_center;
        public float bounds_radius;

        public Model(Vertex[] vertices, Triangle[] triangles, Vertex bounds_center, float bounds_radius)
        {
            this.vertices = vertices;
            this.triangles = triangles;
            this.bounds_center = bounds_center;
            this.bounds_radius = bounds_radius;
        }
    }
}