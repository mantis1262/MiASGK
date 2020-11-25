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

        public void SetIndentityObj()
        {
            Obj2world = Float4x4.Identity;
            Obj2proj = Float4x4.Identity;
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
            View2proj.Matrix[0] = new Float4(f / camera.Aspect, 0, 0, 0);
            View2proj.Matrix[1] = new Float4(0, f, 0, 0);
            View2proj.Matrix[2] = new Float4(0, 0, (camera.Far + camera.Near) / (camera.Near - camera.Far), -1);
            View2proj.Matrix[3] = new Float4(0, 0, (2 * camera.Far * camera.Near) / (camera.Near - camera.Far), 0);
        }

        public void SetLookAt(Camera camera)
        {
            Float3 f = camera.Center - camera.Eye;
            f.Normalize();
            camera.Up.Normalize();
            Float3 s = f.Cross(camera.Up);
            Float3 u = s.Cross(f);
            World2view.Matrix[0] = new Float4(s.X, u.X, -f.X, 0);
            World2view.Matrix[1] = new Float4(s.Y, u.Y, -f.Y, 0);
            World2view.Matrix[2] = new Float4(s.Z, u.Z, -f.Z, 0);
            World2view.Matrix[3] = new Float4(0, 0, 0, 1);
            Float4x4 m = Float4x4.Identity;
            m.Matrix[3] = new Float4(-camera.Eye, 1);
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
            m.Matrix[0] = new Float4
                (
                    v.X * v.X * (1 - c) + c,
                    v.X * v.Y * (1 - c) + v.Z * s,
                    v.X * v.Z * (1 - c) - v.Y * s,
                    0
                );
            m.Matrix[1] = new Float4
                (
                    v.X * v.Y * (1 - c) - v.Z * s,
                    v.Y * v.Y * (1 - c) + c,
                    v.Y * v.Z * (1 - c) + v.X * s,
                    0
                );
            m.Matrix[2] = new Float4
                (
                    v.X * v.Z * (1 - c) + v.Y * s,
                    v.Y * v.Z * (1 - c) - v.X * s,
                    v.Z * v.Z * (1 - c) + c,
                    0
                );
            m.Matrix[3] = new Float4
                (
                    0, 0, 0, 1
                );
            Obj2world = m * Obj2world;
        }

        public void Transform()
        {
            Obj2view = World2view * Obj2world;
            Obj2proj = View2proj * Obj2view;
        }

        public Float3 Tr(Float3 v)
        {
            Float4 r = Obj2proj * (new Float4(v, 1));

            return new Float3(r.X / r.W, r.Y / r.W, r.Z / r.W);
        }

    }
}
