using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Unique]
public class DirectionComponent : IComponent
{
    public UnityEngine.Vector2Int direction;
}
