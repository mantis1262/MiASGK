using Potok.Matematic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Cam
{
    public class Camera
    {

        Float3 _eye;
        Float3 _center;
        Float3 _up;
        float _fovy;
        float _aspect;
        float _near;
        float _far;

        public Float3 Eye { get => _eye; set => _eye = value; }
        public Float3 Center { get => _center; set => _center = value; }
        public Float3 Up { get => _up; set => _up = value; }
        public float Fovy { get => _fovy; set => _fovy = value; }
        public float Aspect { get => _aspect; set => _aspect = value; }
        public float Near { get => _near; set => _near = value; }
        public float Far { get => _far; set => _far = value; }

        public Camera(Float3 eye, Float3 center, Float3 up, float fovy, float aspect, float near = 1.0f, float far = 1000.0f)
        {
            _eye = eye;
            _center = center;
            _up = up;
            _fovy = fovy;
            _aspect = aspect;
            _near = near;
            _far = far;
        }



    }
}
