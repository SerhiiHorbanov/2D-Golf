using SFML.Window;
using SFML.Graphics;

namespace Golf.States
{
    class Starting : State
    {
        public override void Update()
        {
            VideoMode videoMode = new VideoMode(500, 500);

            Game.window = new RenderWindow(videoMode, "2D golf");

            Game.SetState(new PlayingGame());
        }

        public override void Render()
        {

        }

        public override void Input()
        {

        }
    }
}
