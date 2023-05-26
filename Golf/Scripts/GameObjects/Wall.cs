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

        public Vector2f LeftTopCorner => new Vector2f(Left, Top);
        public Vector2f LeftBottomCorner => new Vector2f(Left, Bottom);
        public Vector2f RightTopCorner => new Vector2f(Right, Top);
        public Vector2f RightBottomCorner => new Vector2f(Right, Bottom);

        public Wall(Rectangle rectangle)
        {
            this.rectangle = rectangle;
            shape = new RectangleShape(new Vector2f(rectangle.Width, rectangle.Height));
            shape.Position = new Vector2f(Left, Top);
        }
    }
}
