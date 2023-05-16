using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Golf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(500, 500), "window");
            window.Closed += WindowClosed;

            int circleRadius = 50;
            int x = circleRadius;
            int y = circleRadius;

            while (window.IsOpen)
            {
                window.DispatchEvents();

                CircleShape shape = new CircleShape(50);

                shape.Position = new Vector2f(x, y);
                x++;
                y++;

                window.Clear(Color.Green);
                shape.Draw(window, RenderStates.Default);
                window.Display();
            }
        }

        static void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

    }
}