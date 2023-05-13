using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Golf_2D
{
    class GolfBall
    {
        int radius;
        Vector2f position;
        Vector2f velocity;
        CircleShape shape;

        public GolfBall(int radius, Vector2f position)
        {
            this.radius = radius;
            this.position = position;
            shape = new CircleShape(radius);
        }

        public void Update()
        {
            position += velocity;
        }

        public void Render()
        {
            shape.Position = new Vector2f(position.X + radius, position.Y + radius);
            Golf2D.window.Draw(shape);
        }
    }
}
