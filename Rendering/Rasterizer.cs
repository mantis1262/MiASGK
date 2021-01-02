using System;
using Potok.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Potok.Textures.Light;

namespace Potok
{
    public class Rasterizer
    {
        private Buffer _buffer;
        private Light _light;
        private const float HALF_FLOAT = .5f;

        public Rasterizer(Buffer target)
        {
            _buffer = target;
        }

        public Rasterizer(Buffer target, VertexProcessor vertexProcessor)
        {
            _buffer = target;
            

        }

        public Rasterizer(Buffer target, VertexProcessor vertexProcessor, Light light)
        {
            _buffer = target;
        }

        public Buffer Buffe { get => _buffer; set => _buffer = value; }
        public Light Light { get => _light; set => _light = value; }

        public void Triangle(Float3 v1, Float3 v2, Float3 v3, LightIntensity c1, LightIntensity c2, LightIntensity c3)
        {
            float x1 = (v1.X + 1) * _buffer.Width * HALF_FLOAT;
            float x2 = (v2.X + 1) * _buffer.Width * HALF_FLOAT;
            float x3 = (v3.X + 1) * _buffer.Width * HALF_FLOAT;

            float y1 = (v1.Y + 1) * _buffer.Heigth * HALF_FLOAT;
            float y2 = (v2.Y + 1) * _buffer.Heigth * HALF_FLOAT;
            float y3 = (v3.Y + 1) * _buffer.Heigth * HALF_FLOAT;

            int minX = (int)Mathematic.Max(Mathematic.Min3(x1, x2, x3), _buffer.MinX);
            int maxX = (int)Mathematic.Min(Mathematic.Max3(x1, x2, x3), _buffer.MaxX);
            int minY = (int)Mathematic.Max(Mathematic.Min3(y1, y2, y3), _buffer.MinY);
            int maxY = (int)Mathematic.Min(Mathematic.Max3(y1, y2, y3), _buffer.MaxY);

            float x12 = x1 - x2;
            float x23 = x2 - x3;
            float x31 = x3 - x1;
            float y12 = y1 - y2;
            float y23 = y2 - y3;
            float y31 = y3 - y1;


            bool topleft1 = false;
            bool topleft2 = false;
            bool topleft3 = false;

            if (y12 < 0 || (x12 == 0 && x12 > 0)) topleft1 = true;
            if (y23 < 0 || (x23 == 0 && x23 > 0)) topleft2 = true;
            if (y31 < 0 || (x31 == 0 && x31 > 0)) topleft3 = true;

            float lambda1den = 1.0f / (-y23 * x31 + x23 * y31);
            float lambda2den = 1.0f / (y31 * x23 - x31 * y23);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if ((x12 * (y - y1) - y12 * (x - x1) > 0 && !topleft1
                        || x12 * (y - y1) - y12 * (x - x1) >= 0 && topleft1)
                    && (x23 * (y - y2) - y23 * (x - x2) > 0 && !topleft2
                        || x23 * (y - y2) - y23 * (x - x2) >= 0 && topleft2)
                    && (x31 * (y - y3) - y31 * (x - x3) > 0 && !topleft3
                        || x31 * (y - y3) - y31 * (x - x3) >= 0 && topleft3))
                    {
                        float lambda1 = (y23 * (x - x3) - x23 * (y - y3)) * lambda1den;
                        float lambda2 = (y31 * (x - x3) - x31 * (y - y3)) * lambda2den;
                        float lambda3 = 1 - lambda1 - lambda2;
                        float depth = v1.Z * lambda1 + v2.Z * lambda2 + v3.Z * lambda3;
                        if (depth < _buffer.Depth[x, y])
                        {
                            LightIntensity c = ((c1 * lambda1) + (c2 * lambda2) + (c3 * lambda3)) * 255f;
                            _buffer.SetPixel(c, depth, x, y);
                        }
                    }
                }
            }
        }


        public void TrianglePixel(Vertex v1, Vertex v2, Vertex v3, VertexProcessor vp)
        {
            float x1 = (v1.Position.X + 1) * _buffer.Width * HALF_FLOAT;
            float x2 = (v2.Position.X + 1) * _buffer.Width * HALF_FLOAT;
            float x3 = (v3.Position.X + 1) * _buffer.Width * HALF_FLOAT;

            float y1 = (v1.Position.Y + 1) * _buffer.Heigth * HALF_FLOAT;
            float y2 = (v2.Position.Y + 1) * _buffer.Heigth * HALF_FLOAT;
            float y3 = (v3.Position.Y + 1) * _buffer.Heigth * HALF_FLOAT;

            int minX = (int)Mathematic.Max(Mathematic.Min3(x1, x2, x3), _buffer.MinX);
            int maxX = (int)Mathematic.Min(Mathematic.Max3(x1, x2, x3), _buffer.MaxX);
            int minY = (int)Mathematic.Max(Mathematic.Min3(y1, y2, y3), _buffer.MinY);
            int maxY = (int)Mathematic.Min(Mathematic.Max3(y1, y2, y3), _buffer.MaxY);

            float x12 = x1 - x2;
            float x23 = x2 - x3;
            float x31 = x3 - x1;
            float y12 = y1 - y2;
            float y23 = y2 - y3;
            float y31 = y3 - y1;


            bool topleft1 = false;
            bool topleft2 = false;
            bool topleft3 = false;

            if (y12 < 0 || (x12 == 0 && x12 > 0)) topleft1 = true;
            if (y23 < 0 || (x23 == 0 && x23 > 0)) topleft2 = true;
            if (y31 < 0 || (x31 == 0 && x31 > 0)) topleft3 = true;

            float lambda1den = 1.0f / (-y23 * x31 + x23 * y31);
            float lambda2den = 1.0f / (y31 * x23 - x31 * y23);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if ((x12 * (y - y1) - y12 * (x - x1) > 0 && !topleft1
                        || x12 * (y - y1) - y12 * (x - x1) >= 0 && topleft1)
                    && (x23 * (y - y2) - y23 * (x - x2) > 0 && !topleft2
                        || x23 * (y - y2) - y23 * (x - x2) >= 0 && topleft2)
                    && (x31 * (y - y3) - y31 * (x - x3) > 0 && !topleft3
                        || x31 * (y - y3) - y31 * (x - x3) >= 0 && topleft3))
                    {
                        float lambda1 = (y23 * (x - x3) - x23 * (y - y3)) * lambda1den;
                        float lambda2 = (y31 * (x - x3) - x31 * (y - y3)) * lambda2den;
                        float lambda3 = 1 - lambda1 - lambda2;

                        Vertex f = new Vertex
                            (
                              (v1.Position * lambda1 + v2.Position * lambda2 + v3.Position * lambda3),
                              (v1.Normal * lambda1 + v2.Normal * lambda2 + v3.Normal * lambda3),
                                v1.Color,
                              (v1.HPos * lambda1 + v2.HPos * lambda2 + v3.HPos * lambda3)
                            );
                        f.Color =new LightIntensity( Light.Calculate(f, vp));
                        
                        float depth = v1.HPos.Z * lambda1 + v2.HPos.Z * lambda2 + v3.HPos.Z * lambda3;
                        if (depth < _buffer.Depth[x, y])
                        {
                           // LightIntensity c = ((c1 * lambda1) + (c2 * lambda2) + (c3 * lambda3)) * 255f;
                            _buffer.SetPixel(f.Color, depth, x, y);
                        }
                    }
                }
            }
        }

    }
}
