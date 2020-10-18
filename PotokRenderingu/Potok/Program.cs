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
           buffor.SetColor(0xFFFF00FF); //ARGB
            buffor.SetDepth(2.0f);

            Rasteryzer rasteryzer = new Rasteryzer(buffor);

            rasteryzer.Triangle(
                         new float3(0f, 0.7f, 0.0f),
                         new float3(1f, 0.9f, 0.0f),
                         new float3(-0.5f, -0.5f, 0.0f),  0xFFFFFF00);

            rasteryzer.Triangle(
             new float3(-1.0f, -1f, 0.0f),
             new float3(0f, 0.7f, 0.0f),
             new float3(-0.5f, -0.5f, 0.0f), 0xFF00FF00);

            buffor.Save("Result.png");
        }
    }
}
