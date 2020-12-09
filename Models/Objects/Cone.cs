using Potok.Models.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Models.Objects
{
    public class Cone :Mesh
    {

        public Cone(int ntria, float radius, float height)
        {
            int horizontal = ntria + 1;
            VSize = horizontal + 2;
            TSize = horizontal * 2;
                Verticles = new Vertex[VSize];
            Indices = new Int3[TSize];
            int[] triangles = new int[TSize * 3];
            Verticles[0] = new Vertex(new Float3(0f, 0f, 0f), null);
            for (int i = 0, n = horizontal - 1; i < horizontal; i++)
            {
                float ratio = (float)i / n;
                float r = (float)(ratio * (Math.PI * 2));
                float x = (float)Math.Cos(r) * radius;
                float z = (float)Math.Sin(r) * radius;
                Verticles[i + 1] = new Vertex(new Float3(x, 0f, z), null);

            }
            Verticles[horizontal + 1] = new Vertex(new Float3(0f, -height, 0f), null);
            //bottom
            for (int i = 0, n = horizontal - 1; i < n; i++)
            {
                int offset = i * 3;
                triangles[offset] = 0;
                triangles[offset + 1] = i + 1;
                triangles[offset + 2] = i + 2;
            }

            //sides
            int bottomOffset = horizontal * 3;
            for (int i = 0, n = horizontal - 1; i < n; i++)
            {
                int offset = i * 3 + bottomOffset;
                triangles[offset] = i + 1;
                triangles[offset + 1] = horizontal + 1;
                triangles[offset + 2] = i + 2;
            }

            for (int i = 0; i < TSize; i++)
            {
                int triangleOffset = i * 3;
                Indices[i] = new Int3(triangles[triangleOffset], triangles[triangleOffset + 1], triangles[triangleOffset + 2]);
            }
        }
    }
}
