using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using Golf.Scripts.GameObjects;

namespace Golf.States
{
    internal class PlayingGame : State
    {
        Vector2i mousePullStartPosition = new Vector2i(0, 0);

        GolfBall golfBall = new GolfBall(20, new Vector2f(250, 250), new Vector2f(-2, -5));
        GolfHole hole = new GolfHole(25, new Vector2f(250, 50));
        GolfWall[] walls = new GolfWall[1]{ new GolfWall(new Rectangle(100, 100, 60, 130)) };

        public override void Update()
        {
            golfBall.Update();
        }

        public override void Render()
        {
            Game.window.Clear(SFML.Graphics.Color.Black);
            
            golfBall.Render();

            foreach (GolfWall wall in walls)
            {
                wall.Render();
            }

            Game.window.Display();
        }

        public override void Input()
        {
            Game.window.DispatchEvents();

            if (mousePullStartPosition.X == 0 && mousePullStartPosition.Y == 0 && Mouse.IsButtonPressed(Mouse.Button.Left))
                mousePullStartPosition = Mouse.GetPosition();

            if ((mousePullStartPosition.X != 0 || mousePullStartPosition.Y != 0) && !Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                golfBall.Hit((Vector2f)(mousePullStartPosition - Mouse.GetPosition()));
                mousePullStartPosition = new Vector2i(0, 0);
            }
        }
    }
}
