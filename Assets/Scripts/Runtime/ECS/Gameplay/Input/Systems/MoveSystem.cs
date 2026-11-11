using Entitas;

public class MoveSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _movable;
    
    private readonly UnityEngine.Vector2 _direction = UnityEngine.Vector2.up;

    public MoveSystem(Contexts contexts)
    {
        var matcher = GameMatcher.AllOf(GameMatcher.Position, GameMatcher.Movable)
            .NoneOf(GameMatcher.ManualInput);

        _movable = contexts.game.GetGroup(matcher);
    }

    public void Execute()
    {
        if(_movable.count == 0)
            return;

        foreach (var e in _movable.GetEntities())
        {
            var position = e.position.position;
            position += _direction * e.movable.speed * UnityEngine.Time.deltaTime;
            e.ReplacePosition(position);
        }
    }
}
