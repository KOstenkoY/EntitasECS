using Entitas;

namespace Runtime.Gameplay.View
{
    public interface IView
    {
        void Link(IEntity entity);
        void Unlink();
    }
}
