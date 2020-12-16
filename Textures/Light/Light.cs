using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Textures.Light
{
    public abstract class Light
    {
        protected Float3 _position;
        protected Float3 _ambient;
        protected Float3 _diffuse;
        protected Float3 _specular;
        private float _shiness;

        public Light(Float3 position, Float3 ambient, Float3 diffuse, Float3 specular, float shiness = 10)
        {
            _position = position.Normalized;
            _ambient = ambient;
            _diffuse = diffuse;
            _specular = specular;
            _shiness = shiness;
        }

        public Float3 Position { get => _position; set => _position = value; }
        public Float3 Ambient { get => _ambient; set => _ambient = value; }
        public Float3 Diffuse { get => _diffuse; set => _diffuse = value; }
        public Float3 Specular { get => _specular; set => _specular = value; }
        protected float Shiness { get => _shiness; set => _shiness = value; }

        public abstract Float3 Calculate(Vertex v, VertexProcessor vp);

        public float Cut (float value)
        {
            if (value > 1.0f)
                return 1.0f;
            if (value < 0.0f)
                return 0.0f;
            return value;
        }

        public Float3 Cut(Float3 value)
        {
            if (value.X > 1.0f)
                value.X = 1.0f;

            if (value.Y > 1.0f)
                value.Y = 1.0f;

            if (value.Z > 1.0f)
                value.Z = 1.0f;

            if (value.X < 0.0f)
                value.X = 0.0f;

            if (value.Y < 0.0f)
                value.Y = 0.0f;

            if (value.Z < 0.0f)
                value.Z = 0.0f;

            return value;
        }

    }
}
