using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Golf_2D.States
{
    class Starting : State
    {
        public override void Update()
        {
            Golf2D.window = new RenderWindow(new VideoMode(500, 500), "2D golf");
            //Golf2D.SetState(new MainMenu(...)); чи щось таке
        }

        public override void Render()
        {
            
        }

        public override void Input()
        {
            
        }
    }
}
