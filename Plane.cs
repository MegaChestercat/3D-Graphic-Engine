namespace Optimized_3D_Graphic_Engine
{
    public class Plane
    {
        public Vertex normal;
        private float distance;

        public float Distance
        {
            get { return distance; }
        }

        public Plane(Vertex normal, float distance)
        {
            this.normal = normal;
            this.distance = distance;
        }
    }
}