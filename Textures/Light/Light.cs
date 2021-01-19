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
        protected float _shiness;
        private Buffer _texture;


        public Light(Float3 position, Float3 ambient, Float3 diffuse, Float3 specular, float shiness = 10, Buffer tex = null)
        {
            _position = position.Normalized;
            _ambient = ambient;
            _diffuse = diffuse;
            _specular = specular;
            _shiness = shiness;
            _texture = tex;
        }

        public Float3 Position { get => _position; set => _position = value; }
        public Float3 Ambient { get => _ambient; set => _ambient = value; }
        public Float3 Diffuse { get => _diffuse; set => _diffuse = value; }
        public Float3 Specular { get => _specular; set => _specular = value; }
        public float Shiness { get => _shiness; set => _shiness = value; }
        public Buffer Texture { get => _texture; set => _texture = value; }

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

        public static LightIntensity GetSphereMappingLightIntensity(MyColor[,] colorMap, Float3 hitPoint)
        {
            Float3 normalizedPos = hitPoint.Normalized;
            float theta = (float)Math.Acos(normalizedPos.Y);
            float phi = (float)Math.Atan2(normalizedPos.X, normalizedPos.Z);

            if (phi < 0.0f)
                phi += 2.0f * (float)Math.PI;

            float u = phi * (1 / (2 * (float)Math.PI));
            float v = 1 - theta * (1 / (float)Math.PI);

            int texturePosX = (int)((colorMap.GetLength(0) - 1) * u);
            int texturePosY = (int)((colorMap.GetLength(1) - 1) * v);

            return new LightIntensity(colorMap[texturePosX, texturePosY]);
        }

    }
}
