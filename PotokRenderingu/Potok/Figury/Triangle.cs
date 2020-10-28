using Potok.Matematic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Math = Potok.Matematic.Math;

namespace Potok.Figury
{
    class Triangle
    {
        Float3 _a, _b, _c;
        Float3 _ac, _bc, _cc;

        public Triangle(Float3 a, Float3 b, Float3 c, Float3 ac, Float3 bc, Float3 cc)
        {
            _a = a;
            _b = b;
            _c = c;
            _ac = ac;
            _bc = bc;
            _cc = cc;
        }

        public Triangle(Float3 a, Float3 b, Float3 c, byte R, byte G, byte B)
        {
            _a = a;
            _b = b;
            _c = c;
            _ac = new Float3(R,G,B);
            _bc = new Float3(R,G,B);
            _cc = new Float3(R,G,B);
        }

        public void Draw(Buffor buffor)
        {
            float x1 = (_a.X + 1) * buffor.Width * 0.5f;
            float x2 = (_b.X + 1) * buffor.Width * 0.5f;
            float x3 = (_c.X + 1) * buffor.Width * 0.5f;

            float y1 = (_a.Y + 1) * buffor.Heigth * 0.5f;
            float y2 = (_b.Y + 1) * buffor.Heigth * 0.5f;
            float y3 = (_c.Y + 1) * buffor.Heigth * 0.5f;

            int minX = (int)(Math.Min3(x1, x2, x3) + 0.5f);
            int maxX = (int)(Math.Max3(x1, x2, x3) + 0.5f);
            int minY = (int)(Math.Min3(y1, y2, y3) + 0.5f);
            int maxY = (int)(Math.Max3(y1, y2, y3) + 0.5f);

            minX = (int)Math.Max(minX, buffor.MinX);
            maxX = (int)Math.Min(maxX, buffor.MaxX);
            minY = (int)Math.Max(minY, buffor.MinY);
            maxY = (int)Math.Min(maxY, buffor.MaxY);

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
                        float depth = (lam1 * _a.Z + lam2 * _b.Z + _c.Z);
                        Float3 color = (_ac * lam1 + _bc * lam2 + _cc * lam3) * 255.0f;
                        if (depth < buffor.Depth[x][y])
                        {
                            buffor.SetPixel((byte)color.X, (byte)color.Y, (byte)color.Z, depth, x, y);
                        }
                    }
                }
            }
        }

    }
}
