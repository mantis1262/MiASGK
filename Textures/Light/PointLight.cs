using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Textures.Light
{
    public class PointLight : Light
    {

        public PointLight(Float3 position, Float3 ambient, Float3 diffuse, Float3 specular, float shiness = 10) : base(position, ambient, diffuse, specular, shiness)
        {
        }

        public override Float3 Calculate(Vertex v, VertexProcessor vp)
        {
            Float3 N = vp.TrView3(v.Normal).Normalized;
            Float3 V = vp.TrView(-v.Position).Normalized;
            Float3 L = (Position - V).Normalized;
            Float3 R = L.Reflect(N).Normalized;
            float diff = Cut(L.Dot(N));
            float spec = (float)Math.Pow(Cut(R.Dot(V)), Shiness);
            return Cut(Ambient + Diffuse * diff + Specular * spec);
        }
    }
}
