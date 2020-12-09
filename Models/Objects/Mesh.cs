using Potok.Models.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class Mesh
    {
        int vSize, tSize;
        Vertex[] _verticles;
        Int3[] _indices;
        LightIntensity[] _colors;   

        public int VSize { get => vSize; set => vSize = value; }
        public int TSize { get => tSize; set => tSize = value; }
        public Vertex[] Verticles { get => _verticles; set => _verticles = value; }
        public Int3[] Indices { get => _indices; set => _indices = value; }


        public Mesh()
        {
        }

        public Mesh(int vSize, int tSize, Vertex[] verticles, Int3[] indices)
        {
            this.vSize = vSize;
            this.tSize = tSize;
            this._verticles = verticles;
            this._indices = indices;
        }


        public void Draw(Rasterizer r, VertexProcessor vp)
        {
            for (int i = 0; i < tSize; ++i)
            {
                r.Triangle(
                    vp.Tr(_verticles[_indices[i].A].Position),
                    vp.Tr(_verticles[_indices[i].B].Position),
                    vp.Tr(_verticles[_indices[i].C].Position),
                    new LightIntensity(1, 0, 0), new LightIntensity(0, 1, 0), new LightIntensity(0, 0, 1)
                    );

            }
        }
    }
}
