using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Potok.Models;

namespace Potok
{
    class Program
    {


        static void Main(string[] args)
        {
            Buffer buffer = new Buffer(width: 800, height: 800);
            buffer.ClearColor();
            buffer.ClearDepth();
            Rasterizer rasterizer = new Rasterizer(buffer);

            Camera camera = new Camera(
             new Float3(0f, 0f, 5.0f), //eye
             new Float3(0.0f, 0.0f, 0.0f),   //center
             new Float3(0, 1f, 0),    //up
             60f, 1.0f / 1.0f, 1f, 1000f);

            VertexProcessor vertexProcessor1 = new VertexProcessor();
            vertexProcessor1.SetPerspective(camera);
            vertexProcessor1.SetLookAt(camera);

            //vertexProcessor1.MultByTranslation(new float3(1f, 1f, 0));
           // vertexProcessor1.MultByRotation(20f, new float3(1, 1, 1));
           // vertexProcessor1.MultByScale(new float3(.5f, .5f, .5f));
            vertexProcessor1.Transform();

            //cube
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
                new LightIntensity(1, 0, 0),
                new LightIntensity(1, 0, 0),
                new LightIntensity(1, 0, 0)
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

            DateTime date = DateTime.Now;
            buffer.Save(date.Hour.ToString() + "_" + date.Minute.ToString() +  "_picture.png");
            Console.Read();
        }
    }
}
