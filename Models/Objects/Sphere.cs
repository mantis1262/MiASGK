using Potok.Models.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Models.Objects
{
    public class Sphere : Mesh
    {
        public Sphere(int hor, int ver)
        {


            VSize = ver * (hor + 2);
            TSize = 2 * ver * hor;
            Verticles = new Vertex[VSize];
            Indices = new Int3[TSize];
            int yy;
            for (yy = 0; yy <= hor + 1; yy++)
            {
                float y = (float)Math.Cos(Math.PI / (hor + 1.0f) * (float)yy);
                float r = (float)Math.Sqrt(1 - y * y);
                for (int rr = 0; rr < ver; rr++)
                {
                    float x = (float)(r * Math.Cos(2.0f * Math.PI / ver * rr));
                    float z = (float)(r * Math.Sin(2.0f * Math.PI / ver * rr));
                    Verticles[rr + yy * ver] = new Vertex(new Float3(x, y, z), null);
                    
                }
            }
            for (yy = 0; yy < hor; yy++)
            {
                for (int rr = 0; rr < ver; rr++)
                {
                    Indices[rr + 2 * yy * ver] = new Int3(
                        (rr + 1) % ver      + yy * ver,
                       rr + ver             + yy * ver,
                       (rr + 1) % ver + ver + yy * ver
                );
                    Indices[rr + ver + 2 * yy * ver] = new Int3(
                       rr + ver             + yy * ver,
                       rr + 2 * ver         + yy * ver,
                       (rr + 1) % ver + ver + yy * ver
                );
                }
            }
        }
    }
}
