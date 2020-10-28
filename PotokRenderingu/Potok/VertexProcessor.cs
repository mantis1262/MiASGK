using Potok.Matematic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math = Potok.Matematic.Math;

namespace Potok
{
    class VertexProcessor
    {
        Float4x4 _obj2world, _world2view, _view2proj;
        Float4x4 _obj2view, obj2proj;

        public void SetPerspective(float fovy, float aspect, float near, float far)
        {
            fovy *= Math.PI / 360;
            float f = Math.Sin(fovy) / Math.Cos(fovy);
            _view2proj.Matrix[0] = new Float4(f / aspect, 0, 0, 0);
            _view2proj.Matrix[1] = new Float4(0, f, 0, 0);
            _view2proj.Matrix[2] = new Float4(0, 0, (far+near)/(near-far), -1);
            _view2proj.Matrix[3] = new Float4(0, 0, (2 * far * near) / (near - far), 0);
        }

        public void SetLookAt(Float3 eye, Float3 center, Float3 up)
        {
            Float3 f = center - eye;
            f.Normalize();
            up.Normalize();
            Float3 s = f.Cross(up);
            Float3 u = s.Cross(f);
            _world2view.Matrix[0] = new Float4(s.X, u.X, -f.X, 0.0f); 
            _world2view.Matrix[1] = new Float4(s.Y, u.Y, -f.Y, 0.0f); 
            _world2view.Matrix[2] = new Float4(s.Z, u.Z, -f.Z, 0.0f); 
            _world2view.Matrix[3] = new Float4(0, 0, 0, 1.0f);
            Float4x4 m = Float4x4.Identity();
            m.Matrix[3] = new Float4(-eye, 1);
            _world2view = Float4x4.Mul(_world2view, m);
        }

        public void SetIdentityView()
        {
            _view2proj = Float4x4.Identity();
        }

        public void SetIdentity()
        {
            _obj2world = Float4x4.Identity();
            _world2view = Float4x4.Identity();
        }

        public void MulityByRotation(float a, Float3 rotation)
        {
            float s = Math.Sin(a * Math.PI / 180); 
            float c = Math.Cos(a * Math.PI / 180);
            rotation.Normalize();

            //Float4x4 m = new Float4x4(
            //                    new Float4[4]
            //                    {
            //            new Float4(rotation.X * rotation.X * (1-c)+c,0,0,0),
            //            new Float4(0,scale.Y,0,0),
            //            new Float4(0,0,scale.Z,0),
            //            new Float4(0,0,0,1)
            //                    }
            //                );
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

    }
}
