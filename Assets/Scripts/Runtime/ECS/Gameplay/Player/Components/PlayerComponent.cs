using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Runtime.ECS.Gameplay.Player.Components
{
    [Game]
    public class PlayerComponent : IComponent
    {
        [PrimaryEntityIndexAttribute]
        public int value;
    }
}
