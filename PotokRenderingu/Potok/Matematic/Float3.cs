using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Matematic
{
    public class Float3
    {
        private float _x;
        private float _y;
        private float _z;

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float Z { get => _z; set => _z = value; }

        public Float3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public Float3()
        {
        }

        public void Normalize()
        {
            float length = Length();
            X = X / length;
            Y = Y / length;
            Z = Z / length;
        }

        public float Length()
        {
            return (float)System.Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }

        public float Dot(Float3 v)
        {
            return _x * v.X + _y * v.Y + _z * v.Z;
        }

        public Float3 Cross(Float3 v)
        {
            return new Float3
                (
                _y * v.Z - _z * v.Y,
                _z * v.X - _x * v.Z,
                _x * v.Y - _y * v.X);
        }

        #region Operators

        public static Float3 operator *(float scalar, Float3 right)
        {
            return new Float3(right.X * scalar, right.Y * scalar, right.Z * scalar);
        }
        public static Float3 operator *(Float3 left, float scalar)
        {
            return new Float3(left.X * scalar, left.Y * scalar, left.Z * scalar);
        }


        public static Float3 operator *(Float3 left, Float3 right)
        {
            return new Float3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }


        public static Float3 operator +(Float3 left, Float3 right)
        {
            return new Float3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Float3 operator -(Float3 left, Float3 right)
        {
            return new Float3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Float3 operator -(Float3 left)
        {
            return new Float3(-left.X, -left.Y, -left.Z);
        }
        public static bool operator ==(Float3 left, Float3 right)
        {
            return (left.X == right.X && left.Y == right.Y && left.Z == right.Z);
        }

        public static bool operator !=(Float3 left, Float3 right)
        {
            return (left.X != right.X || left.Y != right.Y || left.Z != right.Z);
        }

        public static Float3 operator /(Float3 left, float scalar)
        {
            Float3 vector = new Float3();
            float inverse = 1.0f / scalar;
            vector.X = left.X * inverse;
            vector.Y = left.Y * inverse;
            vector.Z = left.Z * inverse;
            return vector;
        }

        public override bool Equals(object obj)
        {
            return (this.X == ((Float3)obj).X && this.Y == ((Float3)obj).Y && this.Z == ((Float3)obj).Z);
        }
        #endregion Operators

    }
}
