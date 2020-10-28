using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Matematic
{
    class Float4x4
    {
        private float[][] matrix;

        public float[][] Matrix { get => matrix; set => matrix = value; }
        public Float4x4()
        {
            Matrix = new float[4][];
            for (int i = 0; i < 4; i++)
            {
                Matrix[i] = new float[4];
            }
        }

        public Float4x4(float[][] matrix)
        {
            Matrix = matrix;
        }
    }
}
