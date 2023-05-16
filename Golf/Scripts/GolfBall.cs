using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Golf
{
    class GolfBall
    {
        private static float velocityReduce = 0.99f;
        private int radius;
        private Vector2f position;
        private Vector2f velocity;
        private CircleShape shape;

        public GolfBall(int radius, Vector2f position)
        {
            this.radius = radius;
            this.position = position;
            shape = new CircleShape(radius);
        }

        public void Update()
        {
            velocity *= velocityReduce;
            position += velocity;

            CheckBoundsCollisions();
        }

        private void CheckBoundsCollisions()
        {
            if (position.X + radius > Game.window.Size.X)
            {
                position.X = Game.window.Size.X - radius;
                velocity.X = -velocity.X;
            }
            if (position.X > radius)
            {
                position.X = radius;
                velocity.X = -velocity.X;
            }
            if (position.Y + radius > Game.window.Size.Y)
            {
                position.Y = Game.window.Size.Y - radius;
                velocity.Y = -velocity.Y;
            }
            if (position.Y > radius)
            {
                position.Y = radius;
                velocity.Y = -velocity.Y;
            }
        }

        public void Render()
        {
            shape.Position = new Vector2f(position.X + radius, position.Y + radius);
            Game.window.Draw(shape);
        }
    }
}
