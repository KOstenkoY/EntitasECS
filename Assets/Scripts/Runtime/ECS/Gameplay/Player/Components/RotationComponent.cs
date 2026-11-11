using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class RotationComponent : IComponent
{
    public UnityEngine.Vector2Int rotation;
}
