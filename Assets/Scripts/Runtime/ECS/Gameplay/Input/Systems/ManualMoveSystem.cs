using Entitas;
using UnityEngine;

[Input]
public class ManualMoveSystem : IExecuteSystem
{
    private GameEntity _movableEntity;
    private InputContext _inputContext;

    public ManualMoveSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.Movable, GameMatcher.Position, GameMatcher.ManualInput);
        _movableEntity = contexts.game.GetGroup(matcher).GetSingleEntity();
        _inputContext = contexts.input;
    }

    public void Execute()
    {
        if (_movableEntity != null)
        {
            var speed = _movableEntity.movable.speed * Time.deltaTime;
            _movableEntity.ReplacePosition(
                new Vector2(_inputContext.direction.direction.x * speed, 
                _inputContext.direction.direction.y * speed)
                );
        }
    }
}
