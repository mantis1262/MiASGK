using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    class Rasteryzer
    {

        Buffor buffor;

        public Rasteryzer(Buffor buffor)
        {
            this.buffor = buffor;
        }


        public void Triangle(float3 v1, float3 v2, float3 v3, uint color)
        {
            float x1 = (v1.X + 1) * buffor.Width * 0.5f;   
            float x2 = (v2.X + 1) * buffor.Width * 0.5f;   
            float x3 = (v3.X + 1) * buffor.Width * 0.5f;

            float y1 = (v1.Y + 1) * buffor.Heigth * 0.5f;
            float y2 = (v2.Y + 1) * buffor.Heigth * 0.5f;
            float y3 = (v3.Y + 1) * buffor.Heigth * 0.5f;

            int minX = (int)(Math.min3(x1, x2, x3) + 0.5f);
            int maxX = (int)(Math.max3(x1, x2, x3) + 0.5f);
            int minY = (int)(Math.min3(y1, y2, y3) + 0.5f);
            int maxY = (int)(Math.max3(y1, y2, y3) + 0.5f);

            minX = (int)Math.max(minX, buffor.MinX);
            maxX = (int)Math.min(maxX, buffor.MaxX);
            minY = (int)Math.max(minY, buffor.MinY);
            maxY = (int)Math.min(maxY, buffor.MaxY);

            float x12 = x1 - x2;
            float x23 = x2 - x3;
            float x31 = x3 - x1;
            float y12 = y1 - y2;
            float y23 = y2 - y3;
            float y31 = y3 - y1;

            bool TL1 = false, TL2 = false, TL3 = false;

            if (y12 < 0 || (y12 == 0 && x12 > 0)) TL1 = true;
            if (y23 < 0 || (y23 == 0 && x23 > 0)) TL2 = true;
            if (y31 < 0 || (y31 == 0 && x31 > 0)) TL3 = true;

            for(int y=minY; y<=maxY; y++ )
            {
                for (int x = minX; x <= maxX; x++)
                {
                    if(
                        ((x12 * (y - y1) - y12 * (x - x1) > 0 && !TL1 ) || (x12 * (y - y1) - y12 * (x - x1) >= 0 && TL1)) &&
                        ((x23 * (y - y2) - y23 * (x - x2) > 0 && !TL2 ) || (x23 * (y - y2) - y23 * (x - x2) >= 0 && TL2)) &&
                        ((x31 * (y - y3) - y31 * (x - x3) > 0 && !TL3 ) || (x31 * (y - y3) - y31 * (x - x3) >= 0 && TL3))
                       )
                    {
                        buffor.SetPixel(color, x,y);
                    }
                }
            }
        }
       
    }
}
