using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Textures.Light
{
    public class Spot : Light
    {

        Float3 _direcion;
        float _cutOff;
        float _outercutOff;
        bool _soft;

        public Spot(Float3 position, Float3 ambient, Float3 diffuse, Float3 specular, Float3 dir, float coff, float outercoff, float shiness = 10, bool soft = true , Buffer texture = null) : base(position, ambient, diffuse, specular, shiness, texture)
        {
            _direcion = dir;
            _cutOff = 1f - (coff / 180f);
            _outercutOff = 1f - (outercoff / 180f);
            _soft = soft;
            
        }

        public Float3 Direcion { get => _direcion; set => _direcion = value; }

        public override Float3 Calculate(Vertex v, VertexProcessor vp)
        {
            Float3 N = vp.TrView3(v.Normal).Normalized;
            Float3 V = vp.TrView(-v.Position);
            Float3 L = (Position - V).Normalized;
            V.Normalize();
            Float3 R = L.Reflect(N).Normalized;
            float diff = Cut(L.Dot(N));
            float spec = (float)Math.Pow(Cut(R.Dot(V)), Shiness);
            Float3 textureColor = new Float3(1, 1, 1);


            if(Texture != null)
            {
                LightIntensity c = GetSphereMappingLightIntensity(Texture.Color, v.HPos);
                textureColor = new Float3(c.R, c.G, c.B);
            }

            Float3 dirs = Position - v.Position;


            float theta = _direcion.Normalized.Dot(dirs.Normalized);

            if (_soft)
            {
                float epsilon = _cutOff - _outercutOff;
                float intensity = Cut((theta - _outercutOff) / epsilon);
                diff = diff * intensity;
                spec = spec * intensity;
                return Cut((Ambient + Diffuse * diff + Specular * spec) * textureColor);

            }
            else
            {
                if (theta > _cutOff)
                    return Cut((Ambient + Diffuse * diff + Specular * spec) * textureColor) ;
                else
                    return Cut(Ambient * textureColor);
            }

        }
    }
}
