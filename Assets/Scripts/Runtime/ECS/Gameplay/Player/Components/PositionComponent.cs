using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class PositionComponent : IComponent
{
    public UnityEngine.Vector2 position;
}
