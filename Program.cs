using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Potok.Models;
using Potok.Models.Objects;
using Potok.Textures.Light;

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
             new Float3(0f, 0.0f, 5.0f), //eye
             new Float3(0.0f, -1.0f, 0.0f),   //center
             new Float3(0, 1f, 0),    //up
             90f, 1.0f / 1.0f, 1f, 1000f);



            VertexProcessor vertexProcessor1 = new VertexProcessor();

            Direct light = new Direct(new Float3(1f, -1f, 0f), new Float3(0.0f, 0.1f, 0.1f), new Float3(0.1f, 0.5f, 0.1f), new Float3(0.7f, 0.7f, 0.7f), 10);
            PointLight point = new PointLight(new Float3(0f, 5f, -2f), new Float3(0.0f, 0.1f, 0.1f), new Float3(0.1f, 0.5f, 0.1f), new Float3(.7f, .7f, .7f), 10);
            Spot spot = new Spot(new Float3(0f, 0f, -6f), new Float3(0.0f, 0.1f, 0.1f), new Float3(0.1f, 0.5f, 0.1f), new Float3(.7f, .7f, .7f), new Float3(-0.5f,0f,-1f), 10f, 10f);

           // rasterizer.Light = light;
            rasterizer.Light = spot;

            vertexProcessor1.SetPerspective(camera);
            vertexProcessor1.SetLookAt(camera);
            vertexProcessor1.MultByTranslation(new Float3(2f, 0f, 0));
            vertexProcessor1.Transform();


            Sphere sphere = new Sphere(12, 24, new LightIntensity(1.0f,0f,0f));
            sphere.SetNormal();
          //  sphere.Draw(rasterizer, vertexProcessor1, point);
           // sphere.Draw(rasterizer, vertexProcessor1, light);
           sphere.DrawPiksel(rasterizer, vertexProcessor1);

            vertexProcessor1.SetIndentityObj();
            vertexProcessor1.MultByTranslation(new Float3(0f, 0f, 0));
            vertexProcessor1.Transform();


            sphere.SetNormal();
            //sphere.Draw(rasterizer, vertexProcessor1, point);
            //sphere.Draw(rasterizer, vertexProcessor1, light);
            sphere.DrawPiksel(rasterizer, vertexProcessor1);

            //   Cone cone = new Cone(16, 1f, 2f);
            //  cone.SetNormal();
            // cone.Draw(rasterizer,vertexProcessor1, light);




            #region cube1
            vertexProcessor1.SetIndentityObj();
            vertexProcessor1.MultByTranslation(new Float3(2f, -3f, 0));
              //vertexProcessor1.MultByRotation(20f, new Float3(1, 1, 1));
            //  vertexProcessor1.MultByTranslation(new Float3(0f, 1f, 0));
            //  vertexProcessor1.MultByScale(new Float3(.5f, .5f, .5f));
              vertexProcessor1.Transform();

            Cube cube1 = new Cube();
            cube1.SetNormal();
            //cube1.Draw(rasterizer, vertexProcessor1, point);
            //cube1.Draw(rasterizer, vertexProcessor1, light);
            cube1.DrawPiksel(rasterizer, vertexProcessor1);
            

            #endregion

            #region cube2
              vertexProcessor1.SetIndentityObj();
              vertexProcessor1.MultByTranslation(new Float3(-2f, -3f, 0));
            //  vertexProcessor1.MultByRotation(45f, new Float3(0, 1, 0));
            //  vertexProcessor1.MultByTranslation(new Float3(0f, 1f, 0));
            //  vertexProcessor1.MultByScale(new Float3(0.5f, 0.5f, 0.5f));
              vertexProcessor1.Transform();

            //Cube cube1 = new Cube();
            //cube1.Draw(rasterizer, vertexProcessor1, spot);
                        cube1.DrawPiksel(rasterizer, vertexProcessor1);


            #endregion

            #region cube3
            //  vertexProcessor1.SetIndentityObj();
            //  vertexProcessor1.MultByTranslation(new Float3(0f, -2f, 0));
            // // vertexProcessor1.MultByRotation(20f, new Float3(0, 0, 1));
            ////  vertexProcessor1.MultByTranslation(new Float3(0f, 1f, 0));
            //  //vertexProcessor1.MultByScale(new Float3(1.5f, 0.5f, .5f));
            //  vertexProcessor1.Transform();

            //Cube cube3 = new Cube();
            //cube3.draw(rasterizer, vertexProcessor1);

            #endregion

            DateTime date = DateTime.Now;
            buffer.Save(date.Hour.ToString() + "_" + date.Minute.ToString() + "_" + date.Second.ToString() +  "_picture.png");
        }

    }
}



