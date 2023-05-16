using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace Golf.States
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
            Game.window.Clear(Color.White);
            golfBall.Render();
            Game.window.Display();
        }

        public override void Input()
        {
            Game.window.DispatchEvents();
        }
    }
}
