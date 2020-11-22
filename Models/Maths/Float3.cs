using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class Float3
    {
         float _x;
         float _y;
         float _z;

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float Z { get => _z; set => _z = value; }

        public float Length { get => (float)Math.Sqrt(X * X + Y * Y + Z * Z); }

        public Float3 Normalized { get { return this / Length; } }


        public Float3()
        {
        }

        public Float3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Float3 operator +(Float3 v1, Float3 v2)
        {
            return new Float3
                (
                    v1.X + v2.X,
                    v1.Y + v2.Y,
                    v1.Z + v2.Z
                );
        }

        public static Float3 operator -(Float3 v)
        {
            return new Float3(-v.X, -v.Y, -v.Z);
        }

        public static Float3 operator -(Float3 v1, Float3 v2)
        {
            return new Float3
                (
                    v1.X - v2.X,
                    v1.Y - v2.Y,
                    v1.Z - v2.Z
                );
        }

        public static Float3 operator *(Float3 v1, float value)
        {
            return new Float3
                (
                    v1.X * value,
                    v1.Y * value,
                    v1.Z * value
                );
        }

        public static Float3 operator /(Float3 v, float value)
        {
            return new Float3
                (
                    v.X / value,
                    v.Y / value,
                    v.Z / value
                );
        }

        public void Normalize()
        {
            float length = Length;
            X = X / length;
            Y = Y / length;
            Z = Z / length;
        }

        public Float3 Cross(Float3 v)
        {
            return new Float3
                (
                    Y * v.Z - Z * v.Y,
                    Z * v.X - X * v.Z,
                    X * v.Y - Y * v.X
                );
        }
    }
}
