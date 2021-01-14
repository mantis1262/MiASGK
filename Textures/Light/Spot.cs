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
            _cutOff = (float)Math.Cos(Math.PI / 180f * coff);
            
        }

        public Float3 Direcion { get => _direcion; set => _direcion = value; }

        public override Float3 Calculate(Vertex v, VertexProcessor vp)
        {
            Float3 N = vp.TrView3(v.Normal).Normalized;
            Float3 V = vp.TrView(-v.Position).Normalized;
            Float3 L = (Position - V).Normalized;
            Float3 R = L.Reflect(N).Normalized;
            float diff = Cut(L.Dot(N));
            float spec = (float)Math.Pow(Cut(R.Dot(V)), Shiness);


            Float3 D = vp.TrView(-_direcion).Normalized;
            float theta = L.Dot(D);
            //  float epsilon = light.cutOff - light.outerCutOff;
            //    float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.0, 1.0);

            if (theta > _cutOff)
                return Cut(Ambient + Diffuse * diff + Specular * spec);
            else
                // return Cut(Ambient);
                return new Float3(0, 0, 0);
        }
    }
}
