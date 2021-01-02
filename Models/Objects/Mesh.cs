using Potok.Models.Maths;
using Potok.Textures.Light;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class Mesh
    {
        int _vSize, _tSize;
        Vertex[] _vertices;
        Int3[] _indices;
        LightIntensity[] _colors;   

        public int VSize { get => _vSize; set => _vSize = value; }
        public int TSize { get => _tSize; set => _tSize = value; }
        public Vertex[] Vertices { get => _vertices; set => _vertices = value; }
        public Int3[] Indices { get => _indices; set => _indices = value; }
        public LightIntensity[] Colors { get => _colors; set => _colors = value; }



        public Mesh()
        {
        }

        public Mesh(int vSize, int tSize, Vertex[] verticles, Int3[] indices)
        {
            this._vSize = vSize;
            this._tSize = tSize;
            this._vertices = verticles;
            this._indices = indices;
        }

        public void SetNormal()
        {
            for (int i = 0; i < _vSize; i++)
                Vertices[i].Normal = new Float3(0, 0, 0);
            for (int i = 0; i < _tSize; i++)
            {
                Float3 s = (Vertices[Indices[i].C].Position - Vertices[Indices[i].A].Position)
                    .Cross (Vertices[Indices[i].B].Position - Vertices[Indices[i].A].Position)
                    .Normalized;

                Vertices[Indices[i].A].Normal += s;
                Vertices[Indices[i].B].Normal += s;
                Vertices[Indices[i].C].Normal += s;
            }

            for (int i = 0; i < _vSize; i++)
            {
                Vertices[i].Normal.Normalize();
            }
        }

        public void Draw(Rasterizer r, VertexProcessor vp)
        {
            for (int i = 0; i < _tSize; ++i)
            {
                r.Triangle(
                    vp.Tr(_vertices[_indices[i].A].Position),
                    vp.Tr(_vertices[_indices[i].B].Position),
                    vp.Tr(_vertices[_indices[i].C].Position),
                    new LightIntensity(1, 0, 0), new LightIntensity(0, 1, 0), new LightIntensity(0, 0, 1)
                    );

            }
        }

        public void Draw(Rasterizer r, VertexProcessor vp, Light light)
        {
            for (int i = 0; i < _tSize; ++i)
            {
                r.Triangle(
                    vp.Tr(_vertices[_indices[i].A].Position),
                    vp.Tr(_vertices[_indices[i].B].Position),
                    vp.Tr(_vertices[_indices[i].C].Position),
                    new LightIntensity(light.Calculate(_vertices[_indices[i].A], vp)),
                    new LightIntensity(light.Calculate(_vertices[_indices[i].B], vp)),
                    new LightIntensity(light.Calculate(_vertices[_indices[i].C], vp))
                    );
            }
        }

         public void DrawPiksel(Rasterizer r, VertexProcessor vp)
        {
            for (int i = 0; i < _tSize; ++i)
            {
                _vertices[_indices[i].A].HPos = vp.Tr(_vertices[_indices[i].A].Position);
                _vertices[_indices[i].B].HPos = vp.Tr(_vertices[_indices[i].B].Position);
                _vertices[_indices[i].C].HPos = vp.Tr(_vertices[_indices[i].C].Position);

                r.TrianglePixel(
                    _vertices[_indices[i].A],
                    _vertices[_indices[i].B],
                    _vertices[_indices[i].C], vp
                    );

            }
        }
    }
}
