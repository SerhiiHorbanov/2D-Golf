using SFML.System;
using SFML.Graphics;

namespace Golf.Scripts.GameObjects
{
    class Hole : GameObject
    {
        public int radius { get; private set; }
        public Vector2f position { get; private set; }

        public Hole(int radius = 0, Vector2f position = new Vector2f())
        {
            this.radius = radius;
            this.position = position;
            shape = new CircleShape(radius);
            shape.FillColor = Color.Blue;
            shape.Position = new Vector2f(position.X - radius, position.Y - radius);
        }

        public override void Update()
        {

        }
    }
}
