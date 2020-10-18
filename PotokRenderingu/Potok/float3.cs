using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class float3
    {
        private float _x;
        private float _y;
        private float _z;

        public float3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public float3()
        {
        }

        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }
        public float Z { get => _z; set => _z = value; }

        #region Operators

        public static float3 operator *(float scalar, float3 right)
        {
            return new float3(right.X * scalar, right.Y * scalar, right.Z * scalar);
        }
        public static float3 operator *(float3 left, float scalar)
        {
            return new float3(left.X * scalar, left.Y * scalar, left.Z * scalar);
        }


        public static float3 operator *(float3 left, float3 right)
        {
            return new float3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }


        public static float3 operator +(float3 left, float3 right)
        {
            return new float3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static float3 operator -(float3 left, float3 right)
        {
            return new float3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static float3 operator -(float3 left)
        {
            return new float3(-left.X, -left.Y, -left.Z);
        }
        public static bool operator ==(float3 left, float3 right)
        {
            return (left.X == right.X && left.Y == right.Y && left.Z == right.Z);
        }

        public static bool operator !=(float3 left, float3 right)
        {
            return (left.X != right.X || left.Y != right.Y || left.Z != right.Z);
        }

        public static float3 operator /(float3 left, float scalar)
        {
            float3 vector = new float3();
            float inverse = 1.0f / scalar;
            vector.X = left.X * inverse;
            vector.Y = left.Y * inverse;
            vector.Z = left.Z * inverse;
            return vector;
        }
        #endregion Operators

    }
}
