using Potok.Cam;
using Potok.Matematic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math = Potok.Matematic.Math;

namespace Potok
{
    class VertexProcessor
    {
        Float4x4 _obj2world, _world2view, _view2proj;
        Float4x4 _obj2view, _obj2proj;

        public VertexProcessor()
        {
            _obj2proj = Float4x4.Identity();
            _world2view = Float4x4.Identity();
            _view2proj = Float4x4.Identity();
            _obj2view = Float4x4.Identity();
            _obj2world = Float4x4.Identity();
        }

        public void SetPerspective(Camera camera)
        {


            camera.Fovy = camera.Fovy * (float)(System.Math.PI / 360);
            Console.WriteLine(camera.Fovy);

            float f = (float)(System.Math.Cos(camera.Fovy) / System.Math.Sin(camera.Fovy));
            Console.WriteLine(f);

            _view2proj.Matrix[0] = new Float4(f / camera.Aspect, 0, 0, 0);
            _view2proj.Matrix[1] = new Float4(0, f, 0, 0);
           _view2proj.Matrix[2] = new Float4(0, 0, (camera.Far + camera.Near) /(camera.Near - camera.Far), -1);
            _view2proj.Matrix[3] = new Float4(0, 0, (2 * camera.Far * camera.Near) / (camera.Near - camera.Far), 0);

            Console.WriteLine(_view2proj.ToString() + "\n");


        }

        public void SetLookAt(Camera camera)
        {
            Float3 f = camera.Center - camera.Eye;
            f.Normalize();
            camera.Up.Normalize();
            Float3 s = f.Cross(camera.Up);
            Float3 u = s.Cross(f);
            _world2view.Matrix[0] = new Float4(s.X, u.X, -f.X, 0.0f); 
            _world2view.Matrix[1] = new Float4(s.Y, u.Y, -f.Y, 0.0f); 
            _world2view.Matrix[2] = new Float4(s.Z, u.Z, -f.Z, 0.0f); 
            _world2view.Matrix[3] = new Float4(0, 0, 0, 1.0f);
            Float4x4 m = Float4x4.Identity();
            m.Matrix[3] = new Float4(-camera.Eye, 1);
            _world2view = Float4x4.Mul(_world2view, m);
        }

        public void SetIdentityView()
        {
            _world2view = Float4x4.Identity();
        }

        public void SetIdentity()
        {
            _obj2world = Float4x4.Identity();
        }

        public void MulityByRotation(float a, Float3 rotation)
        {
            float s = Math.Sin((float)(a * System.Math.PI / 180)); 
            float c = Math.Cos((float)(a * System.Math.PI / 180));
            rotation.Normalize();

            Float4x4 m = new Float4x4( new Float4[4]
            {
            new Float4(
                rotation.X * rotation.X * (1 - c) + c,
                rotation.Y * rotation.X * (1 - c) + rotation.Z * s,
                rotation.X * rotation.Z * (1 - c) - rotation.Y * s, 0 ) ,
            new Float4(
                rotation.X * rotation.Y * (1 - c) - rotation.Z * s,
                rotation.Y * rotation.Y * (1 - c) + c,
                rotation.Y * rotation.Z * (1 - c) + rotation.X * s, 0 ) ,
            new Float4(
                rotation.X * rotation.Z * (1 - c) + rotation.Y * s,
                rotation.Y * rotation.Z * (1 - c) - rotation.X * s,
                rotation.Z * rotation.Z * (1 - c) + c, 0) ,
            new Float4(0, 0, 0, 1)
            });
            _obj2world  = Float4x4.Mul(m, _obj2world);
        }

        public void MulityByTranslation(Float3 translation)
        {
            Float4x4 m = Float4x4.Identity();
            m.Matrix[3] = new Float4(translation.X, translation.Y, translation.Z, 1);
            _obj2world = Float4x4.Mul(m, _obj2world);
        }

        public void MulityByScale(Float3 scale)
        {
            Float4x4 m = new Float4x4(
                    new Float4[4]
                    {
                        new Float4(scale.X,0,0,0),
                        new Float4(0,scale.Y,0,0),
                        new Float4(0,0,scale.Z,0),
                        new Float4(0,0,0,1)
                    }
                );
            _obj2world = Float4x4.Mul(m, _obj2world);

        }


        public void Transfrom()
        {
            _obj2view = Float4x4.Mul(_world2view, _obj2world);
            _obj2proj = Float4x4.Mul(_view2proj, _obj2view);

        }

        public Float3 tr(Float3 v)
        {
            Float4 r = Float4x4.MulCol(_view2proj, new Float4(v.X, v.Y, v.Z, 1));

            Console.WriteLine(r.ToString() + "\n");


            return new Float3(r.X/r.V,r.Y/r.V,r.Z/r.V);

        }

    }
}
