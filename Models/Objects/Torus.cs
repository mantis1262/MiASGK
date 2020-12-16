using Potok.Models.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Models.Objects
{
    class Torus : Mesh
    {

        public Torus(int sides, int cs_sides, float radius, float cs_radius)
        {


            Vertices = new Vertex[(sides + 1) * (cs_sides + 1)];
            Indices = new Int3[((2 * sides + 4) * cs_sides) / 3];

            int angleincs = 360 / sides;
            int cs_angleincs = 360 / cs_sides;
            float currentradius, zval;
            int i, j;

            int index = 0;
            /* iterate cs_sides: inner ring */
            for (j = 0; j <= 360; j += cs_angleincs)
            {
                currentradius = (float)(radius + (cs_radius * Math.Cos(j * Math.PI / 180)));
                zval = (float)(cs_radius * Math.Sin(j * Math.PI / 180));

                /* iterate sides: outer ring */
                for (i = 0; i <= 360; i += angleincs, index++)
                {
                    Vertices[index] = new Vertex(new Float3((float)(currentradius * Math.Cos(i * Math.PI / 180)), (float)(currentradius * Math.Sin(i * Math.PI / 180)), zval), null);
                }
            }

            /* inner ring */
            int n = 0;
            int[] triangles = new int[Indices.Length * 3];
            //calculating the index array
            for (i = 0; i < cs_sides; i++)
            {
                for (j = 0; j < sides; j++)
                {
                    triangles[n++] = i * sides + j;
                    triangles[n++] = ((i + 1) % cs_sides) * sides + j;
                }

                triangles[n++] = i * sides;
                triangles[n++] = ((i + 1) % cs_sides) * sides;
                triangles[n++] = ((i + 1) % cs_sides) * sides;
            }

            for (i = 0, j = 0; i < Indices.Length; i++, j += 3)
            {
                Indices[i] = new Int3(triangles[j+2], triangles[j + 1], triangles[j]);
            }
        }
    }
}
