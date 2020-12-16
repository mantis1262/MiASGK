using Potok.Models.Maths;
using Potok.Textures.Light;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Models.Objects
{
    class Cube : Mesh
    {

        public Cube() : base()
        {
            VSize = 8;
            TSize = 12;
            Vertices = new Vertex[8];
            Indices = new Int3[TSize];
            Vertices[0] = new Vertex(new Float3(-1, -1, -1), new Float3());
            Vertices[1] = new Vertex(new Float3(-1, -1, 1), new Float3());
            Vertices[2] = new Vertex(new Float3(-1, 1, -1), new Float3());
            Vertices[3] = new Vertex(new Float3(-1, 1, 1), new Float3());
            Vertices[4] = new Vertex(new Float3(1, -1, -1), new Float3());
            Vertices[5] = new Vertex(new Float3(1, -1, 1), new Float3());
            Vertices[6] = new Vertex(new Float3(1, 1, -1), new Float3());
            Vertices[7] = new Vertex(new Float3(1, 1, 1), new Float3());

            //front
            Indices[0] = new Int3(5, 1, 3);
            Indices[1] = new Int3(5, 3, 7);
            //góra
            Indices[2] = new Int3(5, 4, 1);
            Indices[3] = new Int3(4, 0, 1);
            //dół
            Indices[4] = new Int3(2, 7, 3);
            Indices[5] = new Int3(2, 6, 7);
            //lewo
            Indices[6] = new Int3(3, 1, 0);
            Indices[7] = new Int3(3, 0, 2);

            //prawo
            Indices[8] = new Int3(4, 5, 7);
            Indices[9] = new Int3(7, 6, 4);

            // tył
            Indices[10] = new Int3(2, 0, 4);
            Indices[11] = new Int3(2, 4, 6);
        }

        //public void Draw(Rasterizer rasterizer, VertexProcessor vertexProcessor1)
        //{
        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(-1f, 1f, 1f)),
        //        vertexProcessor1.Tr(new Float3(1f, 1f, 1f)),
        //        vertexProcessor1.Tr(new Float3(1f, -1f, 1f)),
        //        new LightIntensity(1, 0, 0),
        //        new LightIntensity(1, 0, 0),
        //        new LightIntensity(1, 0, 0)
        //    );

        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(-1f, 1f, 1f)),
        //        vertexProcessor1.Tr(new Float3(1f, -1f, 1f)),
        //        vertexProcessor1.Tr(new Float3(-1f, -1f, 1f)),
        //        new LightIntensity(1, 0, 0),
        //        new LightIntensity(1, 0, 0),
        //        new LightIntensity(1, 0, 0)
        //    );

        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(-1f, 1f, -1.0f)),
        //        vertexProcessor1.Tr(new Float3(1f, 1f, 1f)),
        //        vertexProcessor1.Tr(new Float3(-1f, 1f, 1f)),
        //        new LightIntensity(0, 1, 0),
        //        new LightIntensity(0, 1, 0),
        //        new LightIntensity(0, 1, 0)
        //    );

        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(-1f, 1f, -1.0f)),
        //        vertexProcessor1.Tr(new Float3(1f, 1f, -1.0f)),
        //        vertexProcessor1.Tr(new Float3(1f, 1f, 1f)),
        //        new LightIntensity(0, 1, 0),
        //        new LightIntensity(0, 1, 0),
        //        new LightIntensity(0, 1, 0)
        //    );

        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(1f, 1f, 1f)),
        //        vertexProcessor1.Tr(new Float3(1f, 1f, -1.0f)),
        //        vertexProcessor1.Tr(new Float3(1f, -1f, 1f)),
        //        new LightIntensity(0, 1, 0),
        //        new LightIntensity(0, 1, 0),
        //        new LightIntensity(0, 1, 0)
        //    );

        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(1f, 1f, -1.0f)),
        //        vertexProcessor1.Tr(new Float3(1f, -1f, -1.0f)),
        //        vertexProcessor1.Tr(new Float3(1f, -1f, 1f)),
        //        new LightIntensity(0, 1, 0),
        //        new LightIntensity(0, 1, 0),
        //        new LightIntensity(0, 1, 0)
        //    );

        //    //blue
        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(-1f, -1f, 1f)),
        //        vertexProcessor1.Tr(new Float3(1f, -1f, 1f)),
        //        vertexProcessor1.Tr(new Float3(1f, -1f, -1f)),
        //        new LightIntensity(0, 0, 1),
        //        new LightIntensity(0, 0, 1),
        //        new LightIntensity(0, 0, 1)
        //    );

        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(1f, -1f, -1f)),
        //        vertexProcessor1.Tr(new Float3(-1f, -1f, -1f)),
        //        vertexProcessor1.Tr(new Float3(-1f, -1f, 1f)),
        //        new LightIntensity(0, 0, 1),
        //        new LightIntensity(0, 0, 1),
        //        new LightIntensity(0, 0, 1)
        //    );

        //    //purple
        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(-1f, 1f, 1f)),
        //        vertexProcessor1.Tr(new Float3(-1f, -1f, 1f)),
        //        vertexProcessor1.Tr(new Float3(-1f, -1f, -1f)),
        //        new LightIntensity(1, 0, 1),
        //        new LightIntensity(1, 0, 1),
        //        new LightIntensity(1, 0, 1)
        //    );

        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(-1f, -1f, -1f)),
        //        vertexProcessor1.Tr(new Float3(-1f, 1f, -1f)),
        //        vertexProcessor1.Tr(new Float3(-1f, 1f, 1f)),
        //        new LightIntensity(1, 0, 1),
        //        new LightIntensity(1, 0, 1),
        //        new LightIntensity(1, 0, 1)
        //    );

        //    //yellow
        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(1f, -1f, -1f)),
        //        vertexProcessor1.Tr(new Float3(1f, 1f, -1f)),
        //        vertexProcessor1.Tr(new Float3(-1f, 1f, -1f)),
        //        new LightIntensity(1, 1, 0),
        //        new LightIntensity(1, 1, 0),
        //        new LightIntensity(1, 1, 0)
        //    );

        //    rasterizer.Triangle
        //    (
        //        vertexProcessor1.Tr(new Float3(-1f, -1f, -1f)),
        //        vertexProcessor1.Tr(new Float3(1f, -1f, -1f)),
        //        vertexProcessor1.Tr(new Float3(-1f, 1f, -1f)),
        //        new LightIntensity(1, 1, 0),
        //        new LightIntensity(1, 1, 0),
        //        new LightIntensity(1, 1, 0)
        //    );
        //}
    }
}
