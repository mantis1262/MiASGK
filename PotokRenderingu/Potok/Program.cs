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
                new Float3(0, 0f, 5.0f), //eye
                new Float3(0.0f, 0.0f, 0.0f),   //center
                new Float3(0, -1, 0),    //up
                120, 1.0f, 1f, 1000);    //fovy,aspect, near, far

            vertex.SetPerspective(camera);
            vertex.SetLookAt(camera);

           // vertex.MulityByTranslation(new Float3(0, 0, 0));
              vertex.MulityByRotation(-5.0f, new Float3(1, 1, 0f));
          //  vertex.MulityByTranslation(new Float3(0, 0, 0));
           vertex.MulityByScale(new Float3(1f, 1.0f, 1.0f));

            vertex.Transfrom();

            //front
            rasteryzer.TriangleList.Add(new Triangle(
               vertex.tr(new Float3(-1.0f, 1.0f, 1.0f)),
               vertex.tr(new Float3(1.0f, 1.0f, 1.0f)),
               vertex.tr(new Float3(-1.0f, -1.0f, 1.0f)),
               new Float3(0f, 0.6f, 0), new Float3(0, 1f, 0), new Float3(0, 0.8f, 0)));

            rasteryzer.TriangleList.Add(new Triangle(
               vertex.tr(new Float3(1.0f, 1.0f, 1.0f)),
               vertex.tr(new Float3(1.0f, - 1.0f, 1.0f)),
               vertex.tr(new Float3(-1.0f, -1.0f, 1.0f)),
               new Float3(0f, 0.9f, 0), new Float3(0, 1f, 0), new Float3(0, 0.8f, 0)));

            //top
            rasteryzer.TriangleList.Add(new Triangle(
              vertex.tr(new Float3(-1.0f, -1.0f, 1.0f)),
              vertex.tr(new Float3(-1.0f, -1.0f, -1.0f)),
              vertex.tr(new Float3(1.0f, -1.0f, 1.0f)),
               new Float3(0, 0, 0.8f), new Float3(0, 0f, 0.9f), new Float3(0, 0, 1.0f)));

            //rasteryzer.TriangleList.Add(new Triangle(
             //vertex.tr(new Float3(-1.0f, 1.0f, -1.0f)),
             //  vertex.tr(new Float3(-1.0f, 1.0f, 1.0f)),
             // vertex.tr(new Float3(1.0f, 1.0f, 1.0f)),
            //  new Float3(0, 0, 0.8f), new Float3(0, 0f, 0.9f), new Float3(0, 0, 1.0f)));

            //rasteryzer.TriangleList.Add(new Triangle(
            // vertex.tr(new Float3(-1.1f, 0.5f, -1.0f)),
            // vertex.tr(new Float3(-1.1f, 0.5f, -2.0f)),
            // vertex.tr(new Float3(-3.5f, -0.5f, -1.5f)),
            // new Float3(1.0f, 0, 0), new Float3(0.8f, 0.0f, 0), new Float3(0.9f, 0, 0.0f)));

            ////

            vertex.SetIdentity();
           // vertex.MulityByTranslation(new Float3(0, 0, 0));
           // vertex.MulityByRotation(30.0f, new Float3(0, 0, 1f));
           // vertex.MulityByTranslation(new Float3(0, 0, 0));
           // vertex.MulityByScale(new Float3(2f, 2.0f, 1.0f));
            vertex.Transfrom();


            //rasteryzer.TriangleList.Add(new Triangle(
            //  vertex.tr(new Float3(2.5f, -1.5f, -3.5f)),
            //   vertex.tr(new Float3(3f, 1.5f, -3.0f)),
            //   vertex.tr(new Float3(3.5f, -1.5f, -3.0f)),
            //   new Float3(0, 0, 0.8f), new Float3(0, 0f, 0.9f), new Float3(0, 0, 1.0f)));

            //rasteryzer.TriangleList.Add(new Triangle(
            //  vertex.tr(new Float3(2.5f, -1.5f, -3.5f)),
            //   vertex.tr(new Float3(3f, 1.5f, -4.0f)),
            //   vertex.tr(new Float3(3.5f, -1.5f, -3.0f)),
            //   new Float3(0f, 0.9f, 0), new Float3(0, 1f, 0), new Float3(0, 0.8f, 0)));

            //rasteryzer.TriangleList.Add(new Triangle(
            // vertex.tr(new Float3(-2.1f, 1.5f, -3.0f)),
            // vertex.tr(new Float3(-2.1f, 1.5f, -4.0f)),
            // vertex.tr(new Float3(-4.5f, -0.5f, -3.5f)),
            // new Float3(1.0f, 0, 0), new Float3(0.8f, 0.0f, 0), new Float3(0.9f, 0, 0.0f)));


            rasteryzer.Draw();

            buffor.Save("Result.png");

            Console.ReadKey();
        }
    }
}
