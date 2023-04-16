using System.Numerics;

namespace Optimized_3D_Graphic_Engine
{
    public class Camera
    {
        public Vertex position;
        public Matrix orientation;

        public Camera(Vertex position, Matrix orientation)
        {
            this.position = position;
            this.orientation = orientation;
        }
    }
}