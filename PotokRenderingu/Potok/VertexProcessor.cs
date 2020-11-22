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
    public class VertexProcessor
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

            float f = (float)(System.Math.Cos(camera.Fovy) / System.Math.Sin(camera.Fovy));

            _view2proj.Matrix[0] = new Float4(f / camera.Aspect, 0, 0, 0);
            _view2proj.Matrix[1] = new Float4(0, f, 0, 0);
            _view2proj.Matrix[2] = new Float4(0, 0, (camera.Far + camera.Near) / (camera.Near - camera.Far), -1);
            _view2proj.Matrix[3] = new Float4(0, 0, (2 * camera.Far * camera.Near) / (camera.Near - camera.Far), 0);


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
            m.Matrix[3] = new Float4(-camera.Eye, 1.0f);
            _world2view = Float4x4.Mul(_world2view, m);
        }

        public void SetIdentityView()
        {
            _world2view = Float4x4.Identity();
        }

        public void SetIdentity()
        {
            _obj2world = Float4x4.Identity();
            _obj2view = Float4x4.Identity();
            _obj2proj = Float4x4.Identity();
        }

        public void MulityByRotation(float a, Float3 rotation)
        {
            float s = Math.Sin((float)(a * System.Math.PI / 180f));
            float c = Math.Cos((float)(a * System.Math.PI / 180f));
            rotation.Normalize();

            Float4x4 m = new Float4x4(new Float4[4]
            {
            new Float4(
                rotation.X * rotation.X * (1.0f - c) + c,
                rotation.Y * rotation.X * (1f - c) + rotation.Z * s,
                rotation.X * rotation.Z * (1f - c) - rotation.Y * s, 0f ) ,
            new Float4(
                rotation.X * rotation.Y * (1f - c) - rotation.Z * s,
                rotation.Y * rotation.Y * (1f - c) + c,
                rotation.Y * rotation.Z * (1f - c) + rotation.X * s, 0f) ,
            new Float4(
                rotation.X * rotation.Z * (1f - c) + rotation.Y * s,
                rotation.Y * rotation.Z * (1f - c) - rotation.X * s,
                rotation.Z * rotation.Z * (1f - c) + c, 0f) ,
            new Float4(0f, 0f, 0f, 1f)
            });
            _obj2world = Float4x4.Mul( _obj2world, m);
        }

        public void MulityByTranslation(Float3 translation)
        {
            Float4x4 m = Float4x4.Identity();
            m.Matrix[3] = new Float4(translation.X, translation.Y, translation.Z, 1);
            _obj2world = Float4x4.Mul( _obj2world, m);
        }

        public void MulityByScale(Float3 scale)
        {
            Float4x4 m = new Float4x4(
                    new Float4[4]
                    {
                        new Float4(scale.X,0,0,0),
                        new Float4(0,scale.Y,0,0),
                        new Float4(0,0,scale.Z,0),
                        new Float4(0,0,0,1f)
                    }
                );
            _obj2world = Float4x4.Mul(m, _obj2world);

        }

        public void Transfrom()
        {
            _obj2view = Float4x4.Mul(_world2view, _obj2world);
            _obj2proj = Float4x4.Mul(_view2proj, _obj2view);

          Console.WriteLine("_obj2world\n" +  _obj2world.ToString());
          Console.WriteLine("_world2view\n" +  _world2view.ToString());
          Console.WriteLine("_view2proj\n" +  _view2proj.ToString());
            Console.WriteLine("_obj2view\n" + _obj2view.ToString());
            Console.WriteLine("_obj2proj\n" + _obj2proj.ToString());
        }

        public Float3 tr(Float3 v)
        {
            Float4 r = Float4x4.MulCol(_obj2proj, new Float4(v.X, v.Y, v.Z, 1f));

            Console.WriteLine(r.ToString());

            float x1 = r.X / r.V;
            float y1 = r.Y / r.V;
            float z1 = r.Z / r.V;


            return new Float3(x1,y1,z1);

        }
    }
}
