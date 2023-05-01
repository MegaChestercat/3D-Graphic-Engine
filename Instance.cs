namespace Optimized_3D_Graphic_Engine
{
    public class Instance
    {
        public Model model;
        public Vertex position;
        public Matrix orientation;
        public float scale;
        public Matrix transform;
        public Vertex translation;
        public Vertex angle;
        public Matrix initialTransform;
        public float scalation;
        public List<MatrixTransform> transformations;

        public Instance(Model model, Vertex position, Matrix orientation = null, float scale = 1.0f)
        {
            this.model = model;
            this.position = position;
            this.orientation = orientation ?? Matrix.Identity;
            this.scale = scale;
            this.translation = new Vertex(0, 0, 0);
            this.transform = Matrix.MakeTranslationMatrix(this.position) * this.orientation * Matrix.MakeScalingMatrix(this.scale);
            initialTransform = transform;
            this.angle = new Vertex(0, 0, 0);
            this.transformations = new List<MatrixTransform>();
            this.scalation = 1.0f;
        }

        public void SaveTransformations(int time)
        {
            transformations.Add(new MatrixTransform(transform, time));
        }
        public MatrixTransform FindTransformation(int time)
        {
            for (int i = 0; i < transformations.Count; i++)
            {
                if (transformations[i].time == time)
                    return transformations[i];
            }
            return null;
        }
        public void CalculateSteps(int initialFrame, int finalFrame)
        {
            float steps = finalFrame - initialFrame;
            MatrixTransform initialTranformation = FindTransformation(initialFrame);
            MatrixTransform finalTranformation = FindTransformation(finalFrame);
            if (steps > 0)
            {
                Matrix deltaTraslation = (finalTranformation.matrix - initialTranformation.matrix) / steps;

                for (int i = initialFrame; i < finalFrame; i++)
                {
                    transformations.Add(new MatrixTransform(deltaTraslation * (i - initialFrame) + initialTranformation.matrix, i));

                }
            }
            transformations = transformations.OrderBy(x => x.time).ToList();
        }
    }
}