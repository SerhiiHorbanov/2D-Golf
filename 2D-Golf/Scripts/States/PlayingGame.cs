using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace Golf_2D.States
{
    internal class PlayingGame : State
    {
        GolfBall golfBall = new GolfBall(20, new Vector2f(250, 250));

        public override void Update()
        {
            golfBall.Update();
        }

        public override void Render()
        {
            Golf2D.window.Clear(Color.Green);
            golfBall.Render();
            Golf2D.window.Display();
        }

        public override void Input()
        {
            Golf2D.window.DispatchEvents();
        }
    }
}
