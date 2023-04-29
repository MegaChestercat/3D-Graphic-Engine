using System.Numerics;

namespace Optimized_3D_Graphic_Engine
{
    public class Camera
    {
        public Vertex position;
        public Matrix orientation;
        public List<Plane> clipping_planes;

        public Camera(Vertex position, Matrix orientation)
        {
            this.position = position;
            this.orientation = orientation;
            this.clipping_planes = new List<Plane>();
        }
    }
}