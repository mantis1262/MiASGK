using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Models.Objects
{
    class Cube : Mesh
    {
        public void Draw(Rasterizer rasterizer, VertexProcessor vertexProcessor1)
        {
            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(-1f, 1f, 1f)),
                vertexProcessor1.Tr(new Float3(1f, 1f, 1f)),
                vertexProcessor1.Tr(new Float3(1f, -1f, 1f)),
                new LightIntensity(1, 0, 0),
                new LightIntensity(1, 0, 0),
                new LightIntensity(1, 0, 0)
            );

            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(-1f, 1f, 1f)),
                vertexProcessor1.Tr(new Float3(1f, -1f, 1f)),
                vertexProcessor1.Tr(new Float3(-1f, -1f, 1f)),
                new LightIntensity(1, 0, 0),
                new LightIntensity(1, 0, 0),
                new LightIntensity(1, 0, 0)
            );

            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(-1f, 1f, -1.0f)),
                vertexProcessor1.Tr(new Float3(1f, 1f, 1f)),
                vertexProcessor1.Tr(new Float3(-1f, 1f, 1f)),
                new LightIntensity(0, 1, 0),
                new LightIntensity(0, 1, 0),
                new LightIntensity(0, 1, 0)
            );

            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(-1f, 1f, -1.0f)),
                vertexProcessor1.Tr(new Float3(1f, 1f, -1.0f)),
                vertexProcessor1.Tr(new Float3(1f, 1f, 1f)),
                new LightIntensity(0, 1, 0),
                new LightIntensity(0, 1, 0),
                new LightIntensity(0, 1, 0)
            );

            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(1f, 1f, 1f)),
                vertexProcessor1.Tr(new Float3(1f, 1f, -1.0f)),
                vertexProcessor1.Tr(new Float3(1f, -1f, 1f)),
                new LightIntensity(0, 1, 0),
                new LightIntensity(0, 1, 0),
                new LightIntensity(0, 1, 0)
            );

            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(1f, 1f, -1.0f)),
                vertexProcessor1.Tr(new Float3(1f, -1f, -1.0f)),
                vertexProcessor1.Tr(new Float3(1f, -1f, 1f)),
                new LightIntensity(0, 1, 0),
                new LightIntensity(0, 1, 0),
                new LightIntensity(0, 1, 0)
            );

            //blue
            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(-1f, -1f, 1f)),
                vertexProcessor1.Tr(new Float3(1f, -1f, 1f)),
                vertexProcessor1.Tr(new Float3(1f, -1f, -1f)),
                new LightIntensity(0, 0, 1),
                new LightIntensity(0, 0, 1),
                new LightIntensity(0, 0, 1)
            );

            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(1f, -1f, -1f)),
                vertexProcessor1.Tr(new Float3(-1f, -1f, -1f)),
                vertexProcessor1.Tr(new Float3(-1f, -1f, 1f)),
                new LightIntensity(0, 0, 1),
                new LightIntensity(0, 0, 1),
                new LightIntensity(0, 0, 1)
            );

            //purple
            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(-1f, 1f, 1f)),
                vertexProcessor1.Tr(new Float3(-1f, -1f, 1f)),
                vertexProcessor1.Tr(new Float3(-1f, -1f, -1f)),
                new LightIntensity(1, 0, 1),
                new LightIntensity(1, 0, 1),
                new LightIntensity(1, 0, 1)
            );

            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(-1f, -1f, -1f)),
                vertexProcessor1.Tr(new Float3(-1f, 1f, -1f)),
                vertexProcessor1.Tr(new Float3(-1f, 1f, 1f)),
                new LightIntensity(1, 0, 1),
                new LightIntensity(1, 0, 1),
                new LightIntensity(1, 0, 1)
            );

            //yellow
            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(1f, -1f, -1f)),
                vertexProcessor1.Tr(new Float3(1f, 1f, -1f)),
                vertexProcessor1.Tr(new Float3(-1f, 1f, -1f)),
                new LightIntensity(1, 1, 0),
                new LightIntensity(1, 1, 0),
                new LightIntensity(1, 1, 0)
            );

            rasterizer.Triangle
            (
                vertexProcessor1.Tr(new Float3(-1f, -1f, -1f)),
                vertexProcessor1.Tr(new Float3(1f, -1f, -1f)),
                vertexProcessor1.Tr(new Float3(-1f, 1f, -1f)),
                new LightIntensity(1, 1, 0),
                new LightIntensity(1, 1, 0),
                new LightIntensity(1, 1, 0)
            );
        }
    }
}
