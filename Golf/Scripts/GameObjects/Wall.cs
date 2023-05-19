using SFML.System;
using SFML.Graphics;
using System.Drawing;

namespace Golf.Scripts.GameObjects
{
    class Wall : GameObject
    {
        public Rectangle rectangle { get; private set; }
        public int Top => rectangle.Top;
        public int Bottom => rectangle.Bottom;
        public int Left => rectangle.Left;
        public int Right => rectangle.Right;

        public Wall(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            shape = new RectangleShape(new Vector2f(rectangle.Width, rectangle.Height));
            shape.Position = new Vector2f(Left, Top);
        }
    }
}
