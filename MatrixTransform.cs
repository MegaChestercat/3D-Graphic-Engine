using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimized_3D_Graphic_Engine
{
    public class MatrixTransform
    {
        public Matrix matrix;
        public int time;
        public MatrixTransform(Matrix matrix, int time)
        {
            this.matrix = matrix;
            this.time = time;
        }
    }
}
