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
        GolfBall golfBall = new GolfBall(20, new Vector2f(250, 250), new Vector2f(-2, -5));
        GolfWall wall = new GolfWall(new Rectangle(100, 100, 60, 130));

        public override void Update()
        {
            golfBall.Update();
        }

        public override void Render()
        {
            Game.window.Clear(SFML.Graphics.Color.Black);
            golfBall.Render(wall);
            wall.Render();
            Game.window.Display();
        }

        public override void Input()
        {
            Game.window.DispatchEvents();
        }
    }
}
