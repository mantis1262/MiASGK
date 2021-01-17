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

        public Spot(Float3 position, Float3 ambient, Float3 diffuse, Float3 specular, Float3 dir, float coff, float shiness = 10) : base(position, ambient, diffuse, specular, shiness)
        {
            _direcion = dir;
            _cutOff = 1f - (coff / 180f);
            
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




            Float3 dirs = Position - v.Position;

            float outerCuttoff = 1f - (35f / 180f); 

            float theta = _direcion.Normalized.Dot(dirs.Normalized);
              float epsilon = _cutOff - outerCuttoff;
              float intensity = Cut((theta - outerCuttoff) / epsilon);
            diff = diff * intensity;
            spec = spec * intensity;
            
           // if (theta > _cutOff)
                return Cut(Ambient + Diffuse * diff + Specular * spec);
            //else
            //    return Cut(Ambient);
        }
    }
}
