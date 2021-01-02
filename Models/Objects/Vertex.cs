using System;

namespace Potok
{
    public class Vertex
    {
        Float3 _position;
        Float3 _normal;
        LightIntensity _color;
        Float3 _hPos;


        public Float3 Position { get => _position; set => _position = value; }
        public Float3 Normal { get => _normal; set => _normal = value; }
        public LightIntensity Color { get => _color; set => _color = value; }
        public Float3 HPos { get => _hPos; set => _hPos = value; }

        public Vertex(Float3 position, Float3 normal)
        {
            _position = position;
            _normal = normal;
        }

        public Vertex(Float3 position, Float3 normal, LightIntensity color, Float3 hPos) : this(position, normal)
        {
            _color = color;
            _hPos = hPos;
        }



        public Vertex()
        {
        }


    }
}