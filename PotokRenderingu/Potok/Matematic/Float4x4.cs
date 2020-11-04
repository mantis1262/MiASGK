using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Matematic
{
    class Float4x4
    {
        private Float4[] matrix;
        #region properties
        public Float4[] Matrix { get => matrix; set => matrix = value; }
        public float M11 { get => matrix[0].X; }
        public float M12 { get => matrix[0].Y; }
        public float M13 { get => matrix[0].Z; }
        public float M14 { get => matrix[0].V; }

        public float M21 { get => matrix[1].X; }
        public float M22 { get => matrix[1].Y; }
        public float M23 { get => matrix[1].Z; }
        public float M24 { get => matrix[1].V; }

        public float M31 { get => matrix[2].X; }
        public float M32 { get => matrix[2].Y; }
        public float M33 { get => matrix[2].Z; }
        public float M34 { get => matrix[2].V; }

        public float M41 { get => matrix[3].X; }
        public float M42 { get => matrix[3].Y; }
        public float M43 { get => matrix[3].Z; }
        public float M44 { get => matrix[3].V; }

        #endregion
        public Float4x4()
        {
            Matrix = new Float4[4];
        }

        public Float4x4(Float4[] matrix)
        {
            Matrix = matrix;
        }

        public static Float4 MulColumn(Float4x4 m1, Float4 m2)
        {
                var m11 = (((m1.M11 * m2.X) + (m1.M12 * m2.Y)) + (m1.M13 * m2.Z)) + (m1.M14 * m2.V);
                var m21 = (((m1.M21 * m2.X) + (m1.M22 * m2.Y)) + (m1.M23 * m2.Z)) + (m1.M24 * m2.V);
                var m31 = (((m1.M31 * m2.X) + (m1.M32 * m2.Y)) + (m1.M33 * m2.Z)) + (m1.M34 * m2.V);
                var m41 = (((m1.M41 * m2.X) + (m1.M42 * m2.Y)) + (m1.M43 * m2.Z)) + (m1.M44 * m2.V);
            return  new Float4(m11,m21,m31, m41); 
        }

        public static Float4 MulRow(Float4x4 m1, Float4 m2)
        {
            var m11 = (((m1.M11 * m2.X) + (m1.M21 * m2.Y)) + (m1.M31 * m2.Z)) + (m1.M41 * m2.V);
            var m21 = (((m1.M12 * m2.X) + (m1.M22 * m2.Y)) + (m1.M32 * m2.Z)) + (m1.M42 * m2.V);
            var m31 = (((m1.M13 * m2.X) + (m1.M23 * m2.Y)) + (m1.M33 * m2.Z)) + (m1.M43 * m2.V);
            var m41 = (((m1.M14 * m2.X) + (m1.M24 * m2.Y)) + (m1.M34 * m2.Z)) + (m1.M44 * m2.V);
            return new Float4(m11, m21, m31, m41);
        }

        public static Float4x4 Mul(Float4x4 m1, Float4x4 m2)
        {
            var m11 = (((m1.M11 * m2.M11) + (m1.M12 * m2.M21)) + (m1.M13 * m2.M31)) + (m1.M14 * m2.M41);
            var m12 = (((m1.M11 * m2.M12) + (m1.M12 * m2.M22)) + (m1.M13 * m2.M32)) + (m1.M14 * m2.M42);
            var m13 = (((m1.M11 * m2.M13) + (m1.M12 * m2.M23)) + (m1.M13 * m2.M33)) + (m1.M14 * m2.M43);
            var m14 = (((m1.M11 * m2.M14) + (m1.M12 * m2.M24)) + (m1.M13 * m2.M34)) + (m1.M14 * m2.M44);
            var m21 = (((m1.M21 * m2.M11) + (m1.M22 * m2.M21)) + (m1.M23 * m2.M31)) + (m1.M24 * m2.M41);
            var m22 = (((m1.M21 * m2.M12) + (m1.M22 * m2.M22)) + (m1.M23 * m2.M32)) + (m1.M24 * m2.M42);
            var m23 = (((m1.M21 * m2.M13) + (m1.M22 * m2.M23)) + (m1.M23 * m2.M33)) + (m1.M24 * m2.M43);
            var m24 = (((m1.M21 * m2.M14) + (m1.M22 * m2.M24)) + (m1.M23 * m2.M34)) + (m1.M24 * m2.M44);
            var m31 = (((m1.M31 * m2.M11) + (m1.M32 * m2.M21)) + (m1.M33 * m2.M31)) + (m1.M34 * m2.M41);
            var m32 = (((m1.M31 * m2.M12) + (m1.M32 * m2.M22)) + (m1.M33 * m2.M32)) + (m1.M34 * m2.M42);
            var m33 = (((m1.M31 * m2.M13) + (m1.M32 * m2.M23)) + (m1.M33 * m2.M33)) + (m1.M34 * m2.M43);
            var m34 = (((m1.M31 * m2.M14) + (m1.M32 * m2.M24)) + (m1.M33 * m2.M34)) + (m1.M34 * m2.M44);
            var m41 = (((m1.M41 * m2.M11) + (m1.M42 * m2.M21)) + (m1.M43 * m2.M31)) + (m1.M44 * m2.M41);
            var m42 = (((m1.M41 * m2.M12) + (m1.M42 * m2.M22)) + (m1.M43 * m2.M32)) + (m1.M44 * m2.M42);
            var m43 = (((m1.M41 * m2.M13) + (m1.M42 * m2.M23)) + (m1.M43 * m2.M33)) + (m1.M44 * m2.M43);
            var m44 = (((m1.M41 * m2.M14) + (m1.M42 * m2.M24)) + (m1.M43 * m2.M34)) + (m1.M44 * m2.M44);
            return new Float4x4
                    (
                        new Float4[4]
                        {
                                new Float4(m11,m12,m13,m14),
                                new Float4(m21,m22,m23,m24),
                                new Float4(m31,m32,m33,m34),
                                new Float4(m41,m42,m43,m44)

                        }
                    );
        }


        public static Float4x4 Add(Float4x4 m1, Float4x4 m2)
        {
            m1.Matrix[0].X += m2.Matrix[0].X;
            m1.Matrix[0].Y += m2.Matrix[0].Y;
            m1.Matrix[0].Z += m2.Matrix[0].Z;
            m1.Matrix[0].V += m2.Matrix[0].V;

            m1.Matrix[1].X += m2.Matrix[1].X;
            m1.Matrix[1].Y += m2.Matrix[1].Y;
            m1.Matrix[1].Z += m2.Matrix[1].Z;
            m1.Matrix[1].V += m2.Matrix[1].V;

            m1.Matrix[2].X += m2.Matrix[2].X;
            m1.Matrix[2].Y += m2.Matrix[2].Y;
            m1.Matrix[2].Z += m2.Matrix[2].Z;
            m1.Matrix[2].V += m2.Matrix[2].V;

            m1.Matrix[3].X += m2.Matrix[3].X;
            m1.Matrix[3].Y += m2.Matrix[3].Y;
            m1.Matrix[3].Z += m2.Matrix[3].Z;
            m1.Matrix[3].V += m2.Matrix[3].V;

            return m1;
        }

        public static Float4x4 Identity()
        {
            return new Float4x4
                (
                new Float4[4]
                    {
                        new Float4(1,0,0,0),
                        new Float4(0,1,0,0),
                        new Float4(0,0,1,0),
                        new Float4(0,0,0,1)
                    }
                );
        }

        public override string ToString()
        {
            string result = "";
            for(int i = 0; i<4; i++)
            {
                result += matrix[i].ToString();
                result += "\n";
            }
            return result;
        }
    }
}
