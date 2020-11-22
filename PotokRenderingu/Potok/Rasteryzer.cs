using Potok.Figury;
using Potok.Matematic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Math = Potok.Matematic.Math;

namespace Potok
{
    public class Rasteryzer
    {

        Buffor _buffor;
        private List<Triangle> _triangleList;
        public List<Triangle> TriangleList { get => _triangleList; set => _triangleList = value; }

        public Rasteryzer(Buffor buffor)
        {
            _buffor = buffor;
            _triangleList = new List<Triangle>() ;
        }

        public Rasteryzer(Buffor buffor, List<Triangle> triangles)
        {
            _buffor = buffor;
            _triangleList = triangles;
        }


        public void Draw()
        {
            foreach (Triangle triangle in _triangleList)
                    triangle.Draw(_buffor);
        }


        public void Triangle(Float3 v1, Float3 v2, Float3 v3, Float3 c1, Float3 c2, Float3 c3)
        {
            float x1 = (v1.X + 1) * _buffor.Width * 0.5f;
            float x2 = (v2.X + 1) * _buffor.Width * 0.5f;
            float x3 = (v3.X + 1) * _buffor.Width * 0.5f;

            float y1 = (v1.Y + 1) * _buffor.Heigth * 0.5f;
            float y2 = (v2.Y + 1) * _buffor.Heigth * 0.5f;
            float y3 = (v3.Y + 1) * _buffor.Heigth * 0.5f;

            int minX = (int)(Math.Min3(x1, x2, x3) + 0.5f);
            int maxX = (int)(Math.Max3(x1, x2, x3) + 0.5f);
            int minY = (int)(Math.Min3(y1, y2, y3) + 0.5f);
            int maxY = (int)(Math.Max3(y1, y2, y3) + 0.5f);

            minX = (int)Math.Max(minX, _buffor.MinX);
            maxX = (int)Math.Min(maxX, _buffor.MaxX);
            minY = (int)Math.Max(minY, _buffor.MinY);
            maxY = (int)Math.Min(maxY, _buffor.MaxY);

            float x12 = x1 - x2;
            float x23 = x2 - x3;
            float x31 = x3 - x1;
            float y12 = y1 - y2;
            float y23 = y2 - y3;
            float y31 = y3 - y1;

            bool TL1 = false;
            bool TL2 = false;
            bool TL3 = false;

            if (y12 < 0 || (y12 == 0 && x12 > 0)) TL1 = true;
            if (y23 < 0 || (y23 == 0 && x23 > 0)) TL2 = true;
            if (y31 < 0 || (y31 == 0 && x31 > 0)) TL3 = true;

            float lamd1 = 1.0f / ((-y23 * x31) + (x23 * y31));
            float lamd2 = 1.0f / ((y31 * x23) - (x31 * y23));

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    if (
                        ((x12 * (y - y1) - y12 * (x - x1) > 0 && !TL1) || (x12 * (y - y1) - y12 * (x - x1) >= 0 && TL1)) &&
                        ((x23 * (y - y2) - y23 * (x - x2) > 0 && !TL2) || (x23 * (y - y2) - y23 * (x - x2) >= 0 && TL2)) &&
                        ((x31 * (y - y3) - y31 * (x - x3) > 0 && !TL3) || (x31 * (y - y3) - y31 * (x - x3) >= 0 && TL3))
                       )
                    {
                        float lam1 = (y23 * (x - x3) - x23 * (y - y3)) * lamd1;
                        float lam2 = (y31 * (x - x3) - x31 * (y - y3)) * lamd2;
                        float lam3 = 1 - lam1 - lam2;
                        float depth = (lam1 * v1.Z + lam2 * v2.Z + v3.Z);
                        Float3 color = (c1 * lam1 + c2 * lam2 + c3 * lam3) * 255.0f;
                        if (depth < _buffor.Depth[x][y])
                        {
                            _buffor.SetPixel((byte)color.X, (byte)color.Y, (byte)color.Z, depth, x, y);
                        }
                    }
                }
            }
        }


            public void Clean()
        {
            _triangleList.Clear();
        }
    }
}
