﻿using SFML.System;
using SFML.Graphics;

namespace Golf.Scripts.GameObjects
{
    internal class GolfHole
    {
        public int radius { get; private set; }
        public Vector2f position { get; private set; }
        private CircleShape shape;

        public GolfHole(int radius, Vector2f position)
        {
            this.radius = radius;
            this.position = position;
            shape = new CircleShape(radius);
            shape.Position = new Vector2f(position.X - radius, position.Y - radius);
        }
    }
}