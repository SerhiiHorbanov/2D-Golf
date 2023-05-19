using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Golf.States;

namespace Golf.Scripts.GameObjects
{
    class Ball : GameObject
    {
        private static float velocityReduce = 0.95f;
        private int radius;
        private Vector2f position;
        private Vector2f velocity;

        public Ball(int radius = 0, Vector2f position = new Vector2f(), Vector2f velocity = new Vector2f())
        {
            this.radius = radius;
            this.position = position;
            this.velocity = velocity;
            shape = new CircleShape(radius);
        }

        public override void Update()
        {
            velocity *= velocityReduce;
            position += velocity;

            CheckBoundsCollisions();

            foreach (GameObject gameObject in PlayingGame.gameObjects)
                if (gameObject is Wall)
                {
                    Wall wall = (Wall) gameObject;
                    if (IsCollidesWith(wall))
                        CollideWith(wall);
                }

            if (CollidesWithHole())
            {
                PlayingGame.Win();
            }

        }

        private void CheckBoundsCollisions()
        {
            if (position.X + radius > Game.window.Size.X)
            {
                position.X = Game.window.Size.X - radius;
                velocity.X = -velocity.X;
            }
            if (position.X < radius)
            {
                position.X = radius;
                velocity.X = -velocity.X;
            }
            if (position.Y + radius > Game.window.Size.Y)
            {
                position.Y = Game.window.Size.Y - radius;
                velocity.Y = -velocity.Y;
            }
            if (position.Y < radius)
            {
                position.Y = radius;
                velocity.Y = -velocity.Y;
            }
        }

        public override void Render()
        {
            shape.Position = new Vector2f(position.X - radius, position.Y - radius);

            Game.window.Draw(shape);
        }

        public void Hit(Vector2f velocity)
        {
            this.velocity += velocity;
        }

        public bool IsCollidesWith(Wall wall)
        {
            float clampX = Math.Clamp(position.X, wall.Left, wall.Right);
            float clampY = Math.Clamp(position.Y, wall.Top, wall.Bottom);

            float XDifference = clampX - position.X;
            float YDifference = clampY - position.Y;

            float distanceToClampPoint = (float)Math.Sqrt((XDifference * XDifference) + (YDifference * YDifference));

            return distanceToClampPoint < radius;
        }

        public bool CollidesWithHole()
        {
            Hole hole = null;
            foreach (GameObject gameObject in PlayingGame.gameObjects)
            {
                if (gameObject is Hole)
                {
                    hole = (Hole)gameObject;
                    break;
                }
            }

            if (hole == null)
                return false;

            float XDifference = position.X - hole.position.X;
            float YDifference = position.Y - hole.position.Y;
            float distance = ((XDifference * XDifference) + (YDifference * YDifference));
            return distance < hole.radius;
        }

        private void CollideWith(Wall wall)
        {
            Console.WriteLine("collided with wall");
        }
    }
}