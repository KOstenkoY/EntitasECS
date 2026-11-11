using Entitas;
using UnityEngine;

public class ManualMoveSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _movables;
    private readonly InputContext _inputContext;

    public ManualMoveSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.Movable, GameMatcher.Position, GameMatcher.Rotation, GameMatcher.ManualInput);
        _movables = contexts.game.GetGroup(matcher);
        _inputContext = contexts.input;
    }

    public void Execute()
    {
        Vector2 direction = _inputContext.direction.direction;
        if (direction == Vector2.zero)
        {
            return;
        }

        foreach (var entity in _movables.GetEntities())
        {
            var step = direction * (entity.movable.speed * Time.deltaTime);
            entity.ReplacePosition(entity.position.position + step);
            entity.ReplaceRotation(_inputContext.direction.direction);
        }
    }
}
