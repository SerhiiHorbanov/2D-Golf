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

        static public GameObject[] gameObjects = new GameObject[3]
        {
            new Ball(20, new Vector2f(250, 250), new Vector2f(-2, -5)),
            new Hole(25, new Vector2f(250, 50)),
            new Wall(new Rectangle(100, 100, 60, 130)),
        };
        
        public override void Update()
        {
            foreach (GameObject gameObject in gameObjects)
                gameObject.Update();
        }

        public override void Render()
        {
            Game.window.Clear(SFML.Graphics.Color.Black);


            foreach (GameObject gameObject in gameObjects)
                gameObject.Render();

            Game.window.Display();
        }

        public override void Input()
        {
            Game.window.DispatchEvents();

            if (mousePullStartPosition.X == 0 && mousePullStartPosition.Y == 0 && Mouse.IsButtonPressed(Mouse.Button.Left))
                mousePullStartPosition = Mouse.GetPosition();

            if ((mousePullStartPosition.X != 0 || mousePullStartPosition.Y != 0) && !Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Ball ball = null;
                foreach (GameObject gameObject in gameObjects)
                {
                    if (gameObject is Ball)
                    {
                        ball = (Ball)gameObject;
                        break;
                    }
                }
                ball.Hit((Vector2f)(mousePullStartPosition - Mouse.GetPosition()));
                mousePullStartPosition = new Vector2i(0, 0);
            }
        }

        static public void Win()
        {
            Game.endedPlaying = true;
            Game.window.Close();
        }
    }
}
