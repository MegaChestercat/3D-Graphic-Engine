namespace Optimized_3D_Graphic_Engine
{
    public class Instance
    {
        public Model model;
        public Vertex position;
        public Matrix orientation;
        public float scale;
        public Matrix transform;

        public Instance(Model model, Vertex position, Matrix orientation = null, float scale = 1.0f)
        {
            this.model = model;
            this.position = position;
            this.orientation = orientation ?? Matrix.Identity;
            this.scale = scale;

            this.transform = Matrix.MakeTranslationMatrix(this.position) * this.orientation * Matrix.MakeScalingMatrix(this.scale);
        }
    }
}