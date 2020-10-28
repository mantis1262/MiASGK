using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Matematic
{
    class Float4
    {
        private float _x;
        private float _y;
        private float _z;
        private float _v;

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float Z { get => _z; set => _z = value; }
        public float V { get => _v; set => _v = value; }

        public Float4(float x, float y, float z, float v)
        {
            _x = x;
            _y = y;
            _z = z;
            _v = v;
        }

        public Float4(Float3 vec, float v)
        {
            _x = vec.X;
            _y = vec.Y;
            _z = vec.Z;
            _v = v;
        }

        public Float4()
        {
        }



        #region Operators

        public static Float4 operator *(float scalar, Float4 right)
        {
            return new Float4(right.X * scalar, right.Y * scalar, right.Z * scalar, right.V * scalar);
        }
        public static Float4 operator *(Float4 left, float scalar)
        {
            return new Float4(left.X * scalar, left.Y * scalar, left.Z * scalar, left.V * scalar);
        }


        public static Float4 operator *(Float4 left, Float4 right)
        {
            return new Float4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.V * right.V);
        }


        public static Float4 operator +(Float4 left, Float4 right)
        {
            return new Float4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.V + right.V);
        }

        public static Float4 operator -(Float4 left, Float4 right)
        {
            return new Float4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.V - right.V);
        }

        public static Float4 operator -(Float4 left)
        {
            return new Float4(-left.X, -left.Y, -left.Z, -left.V);
        }
        public static bool operator ==(Float4 left, Float4 right)
        {
            return (left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.V == right.V);
        }

        public static bool operator !=(Float4 left, Float4 right)
        {
            return (left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.V != right.V);
        }

        public static Float4 operator /(Float4 left, float scalar)
        {
            Float4 vector = new Float4();
            float inverse = 1.0f / scalar;
            vector.X = left.X * inverse;
            vector.Y = left.Y * inverse;
            vector.Z = left.Z * inverse;
            vector.V = left.V * inverse;
            return vector;
        }

        public override bool Equals(object obj)
        {
            return (this.X == ((Float4)obj).X && this.Y == ((Float4)obj).Y && this.Z == ((Float4)obj).Z && this.V == ((Float4)obj).V);
        }
        #endregion Operators
    }
}
