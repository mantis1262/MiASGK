using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class Triangle
    {
        public Float3 A;
        public Float3 B;
        public Float3 C;
        public Float3 Center;
        public Float3 Normal;

        public Triangle(Float3 a, Float3 b, Float3 c)
        {
            A = a;
            B = b;
            C = c;
            Center = (a + b + c) / 3.0f;
            Normal = (b - a).Cross(c - a);

        }

        public Triangle(Float3 a, Float3 b, Float3 c, Float3 normal)
        {
            A = a;
            B = b;
            C = c;
            Center = (a + b + c) / 3.0f;
            Normal = normal;

        }
    }
}
