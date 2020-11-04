using Potok.Cam;
using Potok.Figury;
using Potok.Matematic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffor buffor = new Buffor(256, 256);
           // buffor.SetSize(512.512);
           //buffor.SetColor(0,0,255);        //RGB
           buffor.ClearColor(); //ARGB
            buffor.SetDepth(2.0f);

            Rasteryzer rasteryzer = new Rasteryzer(buffor);
            VertexProcessor vertex = new VertexProcessor();
            Camera camera = new Camera(
                new Float3(0, 0, 5.0f),
                new Float3(0.0f, 0.0f, -1.0f),
                new Float3(1, 1, 0),
                70.0f, 9.0f / 16.0f, 1.0f, 1000.0f);



            vertex.SetPerspective(camera);
            vertex.SetLookAt(camera);
            vertex.Transfrom();

            rasteryzer.TriangleList.Add(new Triangle(
               vertex.tr(new Float3(-2.5f, -0.5f, 0.1f)),
               vertex.tr(new Float3(0f, 0.5f, 0.0f)),
               vertex.tr(new Float3(0.5f, -0.5f, 0.5f)),
               new Float3(1.0f, 0, 0), new Float3(0, 1.0f, 0), new Float3(0, 0, 0.3f)));

            rasteryzer.TriangleList.Add(new Triangle(
                vertex.tr(new Float3(-1.0f, -1f, -0.2f)),
                vertex.tr(new Float3(0f, 0.9f, 0.6f)),
                vertex.tr(new Float3(-0.5f, -0.5f, 0.0f)),
               new Float3(1.0f, 0, 1), new Float3(1.0f, 0.3f, 0), new Float3(0, 1.0f, 1.0f)));

            rasteryzer.TriangleList.Add(new Triangle(
                vertex.tr(new Float3(-1.1f, 0.5f, 0.9f)),
                vertex.tr(new Float3(0.6f, 0f, -0.1f)),
                vertex.tr(new Float3(-0.9f, -1.1f, 0.5f)),
               new Float3(1.0f, 0, 0), new Float3(0.7f, 0.8f, 0.4f), new Float3(0.0f, 0.0f, 0.0f)));

            rasteryzer.Draw();

            buffor.Save("Result.png");
        }
    }
}
