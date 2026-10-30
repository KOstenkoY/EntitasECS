using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class PlayerComponent : IComponent
{
    [PrimaryEntityIndexAttribute]
    public int value;
}
