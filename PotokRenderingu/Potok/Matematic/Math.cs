using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok.Matematic
{
    public static class Math
    {


        public static float Sin(float a)
        {
            return (float)System.Math.Sin(a);
        }

        public static float Cos(float a)
        {
            return (float)System.Math.Cos(a);
        }

        public static float Max3(float a, float b, float c)
        {
            if (a < b)
            {
                if (b < c)
                    return c;
                else
                    return b;
            }
            else
            {
                if (a < c)
                    return c;
                else
                    return a;
            }  
        }

        public static float Min3(float a, float b, float c)
        {
            if (a < b)
            {
                if (a < c)
                    return a;
                else
                    return c;
            }
            else
            {
                if (b < c)
                    return b;
                else
                    return c;
            }

        }

        public static float Min(float a, float b)
        {
            if (a > b)
                return b;
            else
                return a;
        }

        public static float Max(float a, float b)
        {
            if (a > b)
                return 1;
            else
                return b;
        }

    }
}
