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
        private static float velocityReduce = 0.97f;
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
            {
                if (gameObject is Wall)
                    TryCollideWith((Wall)gameObject);

                if (gameObject is Hole)
                    TryCollideWith((Hole)gameObject);
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

            DrawDebugLine(position, position + velocity);
        }

        private void DrawDebugLine(Vector2f firstPoint, Vector2f secondPoint)
        {
            VertexArray line = new VertexArray(PrimitiveType.LinesStrip, 2);
            line[0] = new Vertex(firstPoint, Color.Red);
            line[1] = new Vertex(secondPoint, Color.Red);
            Game.window.Draw(line);
        }

        public void Hit(Vector2f velocity)
        {
            this.velocity += velocity;
        }

        public void TryCollideWith(Wall wall)
        {
            float clampedX = Math.Clamp(position.X, wall.Left, wall.Right);
            float clampedY = Math.Clamp(position.Y, wall.Top, wall.Bottom);
            if (DistanceTo(new Vector2f(clampedX, clampedY)) < radius)
                CollideWith(wall);
        }

        public void CollideWith(Wall wall)
        {
            bool isXInsideWall = position.X <= wall.Right && position.X >= wall.Left;
            bool isYInsideWall = position.Y <= wall.Bottom && position.Y >= wall.Top;

            if (isXInsideWall)
            {
                if (YDistanceToWall(wall) < radius)
                {
                    velocity.Y = -velocity.Y;

                    if (position.Y < wall.Top)
                        position.Y = wall.Top - radius;

                    if (position.Y > wall.Bottom)
                        position.Y = wall.Bottom + radius;

                    return;
                }
            }

            else if (isYInsideWall)
            {
                if (XDistanceToWall(wall) < radius)
                {
                    velocity.X = -velocity.X;

                    if (position.X < wall.Left)
                        position.X = wall.Left - radius;

                    if (position.X > wall.Right)
                        position.X = wall.Right + radius;

                    return;
                }
            }

            velocity.X = -velocity.X;
            velocity.Y = -velocity.Y;
        }

        public float YDistanceToWall(Wall wall) 
            => Math.Min(Math.Abs(position.Y - wall.Bottom), Math.Abs(position.Y - wall.Top));
        public float XDistanceToWall(Wall wall) 
            => Math.Min(Math.Abs(position.X - wall.Right), Math.Abs(position.X - wall.Left));

        public float DistanceTo(Vector2f secondPosition)
        {
            float XDifference = position.X - secondPosition.X;
            float YDifference = position.Y - secondPosition.Y;
            float distance = (float)Math.Sqrt((XDifference * XDifference) + (YDifference * YDifference));
            return distance;
        }

        public bool TryCollideWith(Hole hole)
        {
            if (hole == null)
                return false;

            return DistanceTo(hole.position) < hole.radius;
        }
    }
}