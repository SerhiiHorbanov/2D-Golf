﻿using Golf_2D.States;
using SFML.Graphics;

namespace Golf_2D
{
    class Golf2D
    {
        static public bool endedPlaying = false;
        static public State currentState = new Starting();
        static public RenderWindow window;

        public void Start()
        {
            while (!endedPlaying)
            {
                Update();
                Render();
                Timing();
                Input();
            }
        }

        public static void SetState(State state)
        {
            currentState = state;
        }

        private void Input()
        {
            currentState.Input();
        }

        private void Update()
        {
            currentState.Update();
        }

        private void Render()
        {
            currentState.Render();
        }

        private void Timing()
        {
            
        }
    }
}