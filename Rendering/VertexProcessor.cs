using Potok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class VertexProcessor
    {
        public Float4x4 Obj2world;
        public Float4x4 World2view;
        public Float4x4 View2proj;
        public Float4x4 Obj2proj;
        public Float4x4 Obj2view;

        public VertexProcessor()
        {
            Obj2world = Float4x4.Identity;
            World2view = Float4x4.Identity;
            View2proj = Float4x4.Identity;
            Obj2proj = Float4x4.Identity;
            Obj2view = Float4x4.Identity;
        }

        public void SetIdentityView()
        {
            Obj2view = Float4x4.Identity;
        }

        public void SetIdentity()
        {
            Obj2world = Float4x4.Identity;
            World2view = Float4x4.Identity;
            View2proj = Float4x4.Identity;
            Obj2proj = Float4x4.Identity;
            Obj2view = Float4x4.Identity;
        }

        public void SetPerspective(Camera camera)
        {
            camera.Fovy *= (float)(Math.PI / 360); //FOVy/2
            float f = (float)(Math.Cos(camera.Fovy) / Math.Sin(camera.Fovy));
            View2proj.SetColumn(0, new Float4(f / camera.Aspect, 0, 0, 0));
            View2proj.SetColumn(1, new Float4(0, f, 0, 0));
            View2proj.SetColumn(2, new Float4(0, 0, (camera.Far + camera.Near) / (camera.Near - camera.Far), -1));
            View2proj.SetColumn(3, new Float4(0, 0, (2 * camera.Far * camera.Near) / (camera.Near - camera.Far), 0));
        }

        public void SetLookAt(Camera camera)
        {
            Float3 f = camera.Center - camera.Eye;
            f.Normalize();
            camera.Up.Normalize();
            Float3 s = f.Cross(camera.Up);
            Float3 u = s.Cross(f);
            World2view.SetColumn(0, new Float4(s.X, u.X, -f.X, 0));
            World2view.SetColumn(1, new Float4(s.Y, u.Y, -f.Y, 0));
            World2view.SetColumn(2, new Float4(s.Z, u.Z, -f.Z, 0));
            World2view.SetColumn(3, new Float4(0, 0, 0, 1));
            Float4x4 m = Float4x4.Identity;
            m.SetColumn(3, new Float4(-camera.Eye, 1));
            World2view = World2view * m;
        }

        public void MultByTranslation(Float3 v)
        {
            Float4x4 m = Float4x4.Identity;
            m.SetTranslation(v);
            Obj2world = Obj2world * m;
        }

        public void MultByScale(Float3 v)
        {
            Float4x4 m = Float4x4.Identity;
            m.SetScale(v);
            Obj2world = Obj2world * m;
        }

        public void MultByRotation(float a, Float3 v)
        {
            float s = (float)Math.Sin(a * Math.PI / 180);
            float c = (float)Math.Cos(a * Math.PI / 180);
            v.Normalize();
            Float4x4 m = Float4x4.Identity;
            m.SetColumn(0, new Float4
                (
                    v.X * v.X * (1 - c) + c,
                    v.X * v.Y * (1 - c) + v.Z * s,
                    v.X * v.Z * (1 - c) - v.Y * s,
                    0
                ));
            m.SetColumn(1, new Float4
                (
                    v.X * v.Y * (1 - c) - v.Z * s,
                    v.Y * v.Y * (1 - c) + c,
                    v.Y * v.Z * (1 - c) + v.X * s,
                    0
                ));
            m.SetColumn(2, new Float4
                (
                    v.X * v.Z * (1 - c) + v.Y * s,
                    v.Y * v.Z * (1 - c) - v.X * s,
                    v.Z * v.Z * (1 - c) + c,
                    0
                ));
            m.SetColumn(3, new Float4
                (
                    0, 0, 0, 1
                ));
            Obj2world = m * Obj2world;
        }

        public void Transform()
        {
            Obj2view = World2view * Obj2world;
            Obj2proj = View2proj * Obj2view;


            Console.WriteLine( "Obj2world\n" +  PrintMatrix("Obj2world"));
            Console.WriteLine("World2view\n" + PrintMatrix("World2view"));
            Console.WriteLine("View2proj\n" + PrintMatrix("View2proj"));
            Console.WriteLine("Obj2proj\n" + PrintMatrix("Obj2proj"));
            Console.WriteLine("Obj2view\n" + PrintMatrix("Obj2view"));
        }

        public Float3 Tr(Float3 v)
        {
            Float4 r = Obj2proj * (new Float4(v, 1));



            float x1 = r.X / r.W;
            float y1 = r.Y / r.W;
            float z1 = r.Z / r.W;

            Console.WriteLine("{" + r.X + ";" + r.Y + ";" + r.Z + ";" + r.W+ "}");

            return new Float3(r.X / r.W, r.Y / r.W, r.Z / r.W);
        }

        private String Print(Float4x4 matrix)
        {
            return String.Format
                (
                    "{0}, {1}, {2}, {3}\n" +
                    "{4}, {5}, {6}, {7}\n" +
                    "{8}, {9}, {10}, {11}\n" +
                    "{12}, {13}, {14}, {15}\n",
                    matrix.M11, matrix.M12, matrix.M13, matrix.M14,
                    matrix.M21, matrix.M22, matrix.M23, matrix.M24,
                    matrix.M31, matrix.M32, matrix.M33, matrix.M34,
                    matrix.M41, matrix.M42, matrix.M43, matrix.M44
                );
        }

        public String PrintMatrix(string matrixType)
        {
            switch(matrixType)
            {
                case "Obj2world":
                    {
                        return Print(Obj2world);
                    }
                case "World2view":
                    {
                        return Print(World2view);
                    }
                case "View2proj":
                    {
                        return Print(View2proj);
                    }
                case "Obj2proj":
                    {
                        return Print(Obj2proj);
                    }
                case "Obj2view":
                    {
                        return Print(Obj2view);
                    }
                default:
                    {
                        return String.Empty;
                    }
            }
        }
    }
}
