using SFML.Window;
using SFML.Graphics;

namespace Golf_2D.States
{
    class Starting : State
    {
        public override void Update()
        {
            VideoMode videoMode = new VideoMode(500, 500);

            Golf2D.window = new RenderWindow(videoMode, "2D golf");

            Golf2D.SetState(new PlayingGame());
        }

        public override void Render()
        {
            
        }

        public override void Input()
        {
            
        }
    }
}
