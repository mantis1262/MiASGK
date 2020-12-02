using System;

namespace Potok
{
    public class Vertex
    {
        Float3 _position;
        Float3 _normal;

        public Float3 Position { get => _position; set => _position = value; }
        public Float3 Normal { get => _normal; set => _normal = value; }

        public Vertex(Float3 position, Float3 normal)
        {
            _position = position;
            _normal = normal;
        }

        public Vertex()
        {
        }
    }
}