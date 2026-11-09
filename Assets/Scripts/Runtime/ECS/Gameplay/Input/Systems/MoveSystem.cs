using Entitas;
using UnityEngine;

[Input]
public class MoveSystem : IExecuteSystem
{
    private IGroup<GameEntity> _movableGroup;
    private InputContext _inputContext;

    public MoveSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.Movable, GameMatcher.Position);
        _movableGroup = contexts.game.GetGroup(matcher);
        _inputContext = contexts.input;
    }

    public void Execute()
    {
        var speed = 0f;
        foreach (var e in _movableGroup)
        {
            speed = e.movable.speed * Time.deltaTime;
            e.ReplacePosition(new Vector2(_inputContext.direction.direction.x * speed, 
                _inputContext.direction.direction.y * speed));
        }
    }
}
