using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potok
{
    public class LightIntensity
    {
        public float R, G, B;

        public LightIntensity()
        {
            R = 0.0f;
            G = 0.0f;
            B = 0.0f;
        }

        public LightIntensity(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        public LightIntensity(float r, float g)
        {
            R = r;
            G = g;
            B = 0.0f;
        }

        public LightIntensity(float r)
        {
            R = r;
            G = 0.0f;
            B = 0.0f;
        }

        public LightIntensity(LightIntensity li)
        {
            R = li.R;
            G = li.G;
            B = li.B;
        }

        public LightIntensity(Float3 float3)
        {
            R = float3.X;
            G = float3.Y;
            B = float3.Z;
        }

        public LightIntensity(MyColor float3)
        {
            R = float3.Red/255f;
            G = float3.Green/255f;
            B = float3.Blue/255f;
        }

        public override string ToString()
        {
            return "LightIntensity(" + R.ToString() + ";" + G.ToString() + ";" + B.ToString() + ")";
        }

        public void SetIntensities(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        public void Add(float r, float g, float b)
        {
            R += r;
            G += g;
            B += b;
        }

        public void Sub(float r, float g, float b)
        {
            R -= r;
            G -= g;
            B -= b;
        }

        public void Div(float f)
        {
            // if number is != from 0
            if (f != 0.0f)
            {
                R /= f;
                G /= f;
                B /= f;
            }
            else
            {
                // divider cannot be nagative
                R = G = B = 0.0f;
            }
        }

        public void Mag(float f)
        {
            // if number is >= from 0
            if (f != 0.0f)
            {
                R *= f;
                G *= f;
                B *= f;
            }
            else
            {
                // number cannot be nagative
                R = G = B = 0.0f;
            }
        }

        public MyColor ToMyColor()
        {
            return new MyColor
            (
                (uint)(R * 255),
                (uint)(G * 255),
                (uint)(B * 255)
            );
        }

        #region Operators
        public static LightIntensity operator +(LightIntensity left, LightIntensity right)
        {
            LightIntensity result = new LightIntensity(left);
            result.Add(right.R, right.G, right.B);
            return result;
        }

        public static LightIntensity operator -(LightIntensity left, LightIntensity right)
        {
            LightIntensity result = new LightIntensity(left);
            result.Sub(right.R, right.G, right.B);
            return result;
        }

        public static LightIntensity operator *(float scalar, LightIntensity right)
        {
            LightIntensity result = new LightIntensity(right);
            result.Mag(scalar);
            return result;
        }

        public static LightIntensity operator *(LightIntensity left, LightIntensity right)
        {
            LightIntensity result = new LightIntensity(left.R * right.R, left.G * right.G, left.B * left.B);
            return result;
        }

        public static LightIntensity operator *(LightIntensity left, float scalar)
        {
            LightIntensity result = new LightIntensity(left);
            result.Mag(scalar);
            return result;
        }

        public static LightIntensity operator /(LightIntensity left, float scalar)
        {
            LightIntensity result = new LightIntensity(left);
            result.Div(scalar);
            return result;
        }
        #endregion Operators
    }
}
