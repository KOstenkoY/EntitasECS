using UnityEngine;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class PositionComponent : IComponent
{
    public Vector3 Value;
}

public class PlayerView : UnityView, IPositionListener
{
    public override void Link(Contexts contexts, GameEntity e)
    {
        base.Link(contexts, e);
        e.AddPositionListener(this);
    }

    public void OnPosition(GameEntity entity, Vector3 value)
    {
        transform.position = value;
    }

    public override void DestroyView()
    {
    }
}
