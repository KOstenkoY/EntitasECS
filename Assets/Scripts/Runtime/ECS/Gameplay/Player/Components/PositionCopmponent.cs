using Entitas;

namespace Runtime.ECS.Gameplay.Player.Components
{
    [Game]
    public class PositionComponent : IComponent
    {
        public UnityEngine.Vector2Int position;
    }
}
