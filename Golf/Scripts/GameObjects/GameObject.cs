using SFML.Graphics;

namespace Golf.Scripts.GameObjects
{
    abstract class GameObject
    {
        protected Shape shape;

        abstract public void Update();
        public virtual void Render()
        => Game.window.Draw(shape);
    }
}
