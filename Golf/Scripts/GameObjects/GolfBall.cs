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
    struct GolfBall
    {
        private static float velocityReduce = 0.95f;
        private int radius;
        private Vector2f position;
        private Vector2f velocity;
        private CircleShape shape;

        public GolfBall(int radius, Vector2f position, Vector2f velocity = new Vector2f())
        {
            this.radius = radius;
            this.position = position;
            this.velocity = velocity;
            shape = new CircleShape(radius);
        }

        public void Update()
        {
            velocity *= velocityReduce;
            position += velocity;

            CheckBoundsCollisions();

            foreach (GolfWall wall in PlayingGame.walls)
                if (IsCollidesWith(wall))
                    CollideWith(wall);

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

        public void Render()
        {
            shape.Position = new Vector2f(position.X - radius, position.Y - radius);

            Game.window.Draw(shape);
        }

        public void Hit(Vector2f velocity)
        {
            this.velocity += velocity;
        }

        public bool IsCollidesWith(GolfWall wall)
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
            float XDifference = position.X - PlayingGame.hole.position.X;
            float YDifference = position.Y - PlayingGame.hole.position.Y;
            float distance = ((XDifference * XDifference) + (YDifference * YDifference));
            return distance < PlayingGame.hole.radius;
        }

        private void CollideWith(GolfWall wall)
        {

        }
        /* я спочатку так хотів зробити :skull:
        public bool CollidesWith(GolfWall wall)
        {
            bool xInsideWall = position.X <= wall.Right|| position.X >= wall.Left;
            bool yInsideWall = position.Y <= wall.Bottom || position.Y >= wall.Top;

            if (xInsideWall || yInsideWall)
                return false;

            else if (xInsideWall)
                return YDistanceToWall(wall) < radius;

            else if (yInsideWall)
                return XDistanceToWall(wall) < radius;

            float xDistanceToWall = XDistanceToWall(wall);
            float yDistanceToWall = YDistanceToWall(wall);
            return Math.Sqrt((xDistanceToWall * xDistanceToWall) + (yDistanceToWall * yDistanceToWall)) < radius;
        }

        public float YDistanceToWall(GolfWall wall) 
            => Math.Min(Math.Abs(position.Y - wall.Bottom), Math.Abs(position.Y - wall.Top));
        public float XDistanceToWall(GolfWall wall) 
            => Math.Min(Math.Abs(position.X - wall.Right), Math.Abs(position.X - wall.Left));*/
    }
}